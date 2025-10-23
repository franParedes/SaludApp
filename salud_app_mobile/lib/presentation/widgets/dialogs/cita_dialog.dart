import 'dart:convert';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:mime/mime.dart';
import 'package:provider/provider.dart';
import 'package:salud_app_mobile/domain/models/Citas/cita.dart';
import 'package:salud_app_mobile/domain/models/Citas/cita_labortorio.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/centrosmedicos.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/especialidades.dart';
import 'package:salud_app_mobile/domain/models/Citas/tipocita.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/examenes_disponibles.dart';
import 'package:salud_app_mobile/domain/providers/session_provider.dart';
import 'package:salud_app_mobile/domain/repositories/Citas/tipocita_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/centromedico_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/especialidad_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/utilities_repository.dart';
import 'package:salud_app_mobile/domain/services/cita_service.dart';

// La función ahora es muy simple: solo muestra el diálogo.
Future<void> showCitaDialog(BuildContext context) async {
  await showGeneralDialog(
    context: context,
    barrierDismissible: true,
    barrierLabel: MaterialLocalizations.of(context).modalBarrierDismissLabel,
    transitionDuration: const Duration(milliseconds: 300),
    pageBuilder: (context, animation, secondaryAnimation) {
      // Toda la lógica ahora está dentro de este widget.
      return const CitaDialogWidget();
    },
  );
}

class CitaDialogWidget extends StatefulWidget {
  const CitaDialogWidget({super.key});

  @override
  State<CitaDialogWidget> createState() => _CitaDialogWidgetState();
}

class _CitaDialogWidgetState extends State<CitaDialogWidget> {
  static const int citaLabId = 2;

  // --- Variables de Estado ---
  final _descripcionController = TextEditingController();
  final _picker = ImagePicker();
  bool _isLoading = true; // Para mostrar un indicador de carga inicial
  bool _isSubmitting = false; // Para el botón de solicitar

  // Listas para los dropdowns
  List<Tipocita> _tiposCita = [];
  List<Centrosmedicos> _centrosMedicos = [];
  List<ExamenesDisponibles> _examenesDisponibles =
      []; // Lista de exámenes para los checkboxes

  // Valores seleccionados
  int? _tipoCitaSeleccionada;
  int? _centroMedicoSeleccionado;
  int? _especialidadSeleccionada;
  File? _imagenSeleccionada;
  // Usamos un Map para manejar fácilmente el estado de cada checkbox
  final Map<int, bool> _examenesSeleccionados = {};

  @override
  void initState() {
    super.initState();
    //Cargamos todos los datos iniciales en initState.
    // Esto es seguro y se ejecuta solo una vez cuando el widget se crea.
    _cargarDatosIniciales();
  }

  Future<void> _cargarDatosIniciales() async {
    final sessionProvider = context.read<SessionProvider>();
    final auth = sessionProvider.auth;

    // Usamos Future.wait para ejecutar todas las llamadas a la API en paralelo, es más eficiente.
    final results = await Future.wait([
      EspecialidadRepository().getEspecialidades(),
      TipocitaRepository().getTipocitas(),
      CentromedicoRepository().getCentrosMedicosPorDep( auth!.departamento ),
    ]);

    // Buscamos el ID de la especialidad "General" para preseleccionarla.
    final especialidadGeneral = (results[0] as List<Especialidades>).firstWhere(
      (esp) => esp.especialidad == "General",
      orElse: () => Especialidades(id: 0, especialidad: ""),
    );

    // Una vez cargados los datos, actualizamos el estado para reconstruir la UI.
    if (mounted) {
      setState(() {
        _tiposCita = results[1] as List<Tipocita>;
        _centrosMedicos = results[2] as List<Centrosmedicos>;
        _especialidadSeleccionada = especialidadGeneral.id;
        _isLoading = false; // Ocultamos el indicador de carga
      });
    }
  }

  // Lógica para cargar exámenes dinámicamente.
  Future<void> _onTipoCitaChanged(int? newTipoCitaId) async {
    setState(() {
      _tipoCitaSeleccionada = newTipoCitaId;
      _examenesDisponibles.clear();
      _examenesSeleccionados.clear();
    });

    if (newTipoCitaId == citaLabId) {
      //Muestra un indicador de carga si es necesario.
      final examenes = await UtilitiesRepository().getExamenesDisponibles();
      if (mounted) {
        setState(() {
          _examenesDisponibles = examenes;
        });
      }
    }
  }

  Future<void> _seleccionarImagen() async {
    final XFile? image = await _picker.pickImage(source: ImageSource.gallery);
    if (image != null) {
      setState(() {
        _imagenSeleccionada = File(image.path);
      });
    }
  }

  Future<void> _solicitarCita() async {
    if (_isSubmitting) return;

    final sessionProvider = context.read<SessionProvider>();
    final auth = sessionProvider.auth;

    if (auth == null) {
      // Si por alguna razón no hay datos de sesión, mostramos un error y detenemos la ejecución.
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text(
            "❌ Error: Sesión no encontrada. Por favor, inicie sesión de nuevo.",
          ),
        ),
      );
      return;
    }

    // Validaciones simples
    if (_tipoCitaSeleccionada == null || _centroMedicoSeleccionado == null) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text("Por favor, complete todos los campos obligatorios."),
        ),
      );
      return;
    }

    setState(() => _isSubmitting = true);

    // MODIFICACIÓN 4: Recolectar los IDs de los exámenes seleccionados.
    final nameExamenesSeleccionados = _examenesSeleccionados.entries
        .where((entry) => entry.value) // Filtra solo los que son 'true'
        .map((entry) {
          final examen = _examenesDisponibles.firstWhere(
            (e) => e.idExamen == entry.key,
          );
          return examen.examen;
        })
        .toList();

    bool success = false;
    String? mimeType;

    String? base64Image;
    if (_imagenSeleccionada != null) {
      final fileBytes = await _imagenSeleccionada!.readAsBytes();
      mimeType =
          lookupMimeType(_imagenSeleccionada!.path) ??
          'application/octet-stream';

      base64Image = base64Encode(fileBytes);
    }

    if (_tipoCitaSeleccionada != citaLabId) {
      final citaMedica = Cita(
        pacienteId: auth.idPaciente, // Debería venir de un gestor de estado o SharedPreferences
        fechaSolicitud: DateTime.now(),
        lugar: _centroMedicoSeleccionado!,
        fechaCita: DateTime.now(), // El usuario debería poder seleccionarla
        motivoCita: _descripcionController.text,
        tipoCita: _tipoCitaSeleccionada!,
        adjuntos: base64Image != null
            ? [
                Adjunto(
                  nombreArchivo: _imagenSeleccionada!.path.split('/').last,
                  tipoArchivo: "imagen",
                  tipoMime: mimeType!, // O detectar el mime type real
                  bytesArchivo: base64Image,
                ),
              ]
            : [],
        especialidad: _especialidadSeleccionada!,
        // Añade el campo a tu modelo Cita si es necesario.
        // examenes: idsExamenesSeleccionados.join(','),
      );

      success = await CitaService().solicitarCita(citaMedica);
    } else {
      final citaLab = CitaLabortorio(
        pacienteId: auth.idPaciente,
        fechaSolicitud: DateTime.now(),
        lugar: _centroMedicoSeleccionado!,
        fechaCita: DateTime.now(), // El usuario debería poder seleccionarla
        motivoCita: _descripcionController.text,
        tipoCita: _tipoCitaSeleccionada!,
        adjuntos: base64Image != null
            ? [
                Adjunto(
                  nombreArchivo: _imagenSeleccionada!.path.split('/').last,
                  tipoArchivo: "imagen",
                  tipoMime: mimeType!, // O detectar el mime type real
                  bytesArchivo: base64Image,
                ),
              ]
            : [],
        examenesRealzar: nameExamenesSeleccionados,
      );

      success = await CitaService().solicitarCitaLab(citaLab);
    }

    String message;
    if (success == true) {
      message = "✅ Cita solicitada con éxito";
    } else {
      message = "❌ Error al solicitar la cita";
    }

    // Como estamos dentro de un StatefulWidget, 'context' y 'mounted' están disponibles y son seguros.
    if (mounted) {
      ScaffoldMessenger.of(
        context,
      ).showSnackBar(SnackBar(content: Text(message)));
      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Material(
        color: Colors.transparent,
        child: Container(
          width: MediaQuery.of(context).size.width * 0.9,
          margin: const EdgeInsets.symmetric(horizontal: 20),
          padding: const EdgeInsets.all(20),
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(16),
          ),
          child: _isLoading
              ? const Center(child: CircularProgressIndicator())
              : SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      // --- FORMULARIO ---
                      TextField(
                        controller: _descripcionController,
                        maxLines: 5,
                        decoration: InputDecoration(
                          hintText: "Escribe tu mensaje...",
                          filled: true,
                          fillColor: Colors.grey.shade100,
                          contentPadding: const EdgeInsets.all(12),
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(8),
                          ),
                        ),
                      ),
                      const SizedBox(height: 20),

                      // Dropdown Tipo de cita
                      DropdownButtonFormField<int>(
                        decoration: const InputDecoration(
                          labelText: "Tipo de cita",
                          border: OutlineInputBorder(),
                        ),
                        initialValue: _tipoCitaSeleccionada,
                        items: _tiposCita
                            .map(
                              (e) => DropdownMenuItem(
                                value: e.id,
                                child: Text(e.nombre),
                              ),
                            )
                            .toList(),
                        onChanged:
                            _onTipoCitaChanged, // Llama a la nueva función
                      ),
                      const SizedBox(height: 20),

                      // Dropdown Centro médico
                      DropdownButtonFormField<int>(
                        decoration: const InputDecoration(
                          labelText: "Centro Médico",
                          border: OutlineInputBorder(),
                        ),
                        initialValue: _centroMedicoSeleccionado,
                        items: _centrosMedicos
                            .map(
                              (e) => DropdownMenuItem(
                                value: e.id,
                                child: Text(e.centroMedico),
                              ),
                            )
                            .toList(),
                        onChanged: (value) =>
                            setState(() => _centroMedicoSeleccionado = value),
                      ),
                      const SizedBox(height: 10),

                      // MODIFICACIÓN 5: Sección de exámenes condicional.
                      if (_examenesDisponibles.isNotEmpty)
                        Container(
                          margin: const EdgeInsets.symmetric(vertical: 10),
                          padding: const EdgeInsets.all(8),
                          decoration: BoxDecoration(
                            border: Border.all(color: Colors.grey.shade300),
                            borderRadius: BorderRadius.circular(8),
                          ),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              const Text(
                                "Exámenes a realizar",
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              ..._examenesDisponibles.map((examen) {
                                return CheckboxListTile(
                                  title: Text(examen.examen),
                                  value:
                                      _examenesSeleccionados[examen.idExamen] ??
                                      false,
                                  onChanged: (bool? value) {
                                    setState(() {
                                      _examenesSeleccionados[examen.idExamen] =
                                          value ?? false;
                                    });
                                  },
                                  controlAffinity:
                                      ListTileControlAffinity.leading,
                                  contentPadding: EdgeInsets.zero,
                                );
                              }),
                            ],
                          ),
                        ),

                      // Preview imagen
                      if (_imagenSeleccionada != null) ...[
                        ClipRRect(
                          borderRadius: BorderRadius.circular(8),
                          child: Image.file(
                            _imagenSeleccionada!,
                            height: 120,
                            fit: BoxFit.cover,
                          ),
                        ),
                        const SizedBox(height: 10),
                      ],

                      // MODIFICACIÓN 6: Botón de adjuntar con alineación a la izquierda.
                      ElevatedButton(
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.blue.shade50,
                          foregroundColor: Colors.blue.shade800,
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(12),
                          ),
                          padding: const EdgeInsets.symmetric(
                            vertical: 12,
                            horizontal: 16,
                          ),
                        ),
                        onPressed: _seleccionarImagen,
                        child: const Row(
                          mainAxisAlignment: MainAxisAlignment
                              .start, // Alinea el contenido a la izquierda
                          children: [
                            Icon(Icons.attach_file, size: 20),
                            SizedBox(width: 8),
                            Text("Añadir archivos"),
                          ],
                        ),
                      ),
                      const SizedBox(height: 20),

                      // Botón de Solicitar Cita
                      SizedBox(
                        width: double.infinity,
                        child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            backgroundColor: Colors.blue,
                            foregroundColor: Colors.white,
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(12),
                            ),
                            padding: const EdgeInsets.symmetric(vertical: 16),
                          ),
                          onPressed: _solicitarCita,
                          child: _isSubmitting
                              ? const SizedBox(
                                  height: 20,
                                  width: 20,
                                  child: CircularProgressIndicator(
                                    strokeWidth: 2,
                                    color: Colors.white,
                                  ),
                                )
                              : const Text("Solicitar cita"),
                        ),
                      ),
                    ],
                  ),
                ),
        ),
      ),
    );
  }
}
