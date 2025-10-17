import 'dart:io';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/centrosmedicos.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/especialidades.dart';
import 'package:salud_app_mobile/domain/models/Citas/tipocita.dart';
import 'package:salud_app_mobile/domain/repositories/Citas/tipocita_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/centromedico_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/especialidad_repository.dart';

class CitaDialogWidget extends StatefulWidget {
  const CitaDialogWidget({super.key});

  @override
  State<CitaDialogWidget> createState() => _CitaDialogWidgetState();
}

class _CitaDialogWidgetState extends State<CitaDialogWidget> {
  // --- Variables de Estado ---
  final _descripcionController = TextEditingController();
  final _picker = ImagePicker();
  bool _isLoading = true; // Para mostrar un indicador de carga inicial
  bool _isSubmitting = false; // Para el botón de solicitar

  // Listas para los dropdowns
  List<Especialidades> _especialidades = [];
  List<Tipocita> _tiposCita = [];
  List<Centrosmedicos> _centrosMedicos = [];
  List<String> _examenesDisponibles = []; // Lista de exámenes para los checkboxes

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
    // Usamos Future.wait para ejecutar todas las llamadas a la API en paralelo, es más eficiente.
    final results = await Future.wait([
      EspecialidadRepository().getEspecialidades(),
      TipocitaRepository().getTipocitas(),
      CentromedicoRepository().getCentrosmedicos(),
    ]);

    // Buscamos el ID de la especialidad "General" para preseleccionarla.
    final especialidadGeneral = (results[0] as List<Especialidades>).firstWhere(
      (esp) => esp.especialidad == "General",
      orElse: () => Especialidades(id: 0, especialidad: ""),
    );

    // Una vez cargados los datos, actualizamos el estado para reconstruir la UI.
    if (mounted) {
      setState(() {
        _especialidades = results[0] as List<Especialidades>;
        _tiposCita = results[1] as List<Tipocita>;
        _centrosMedicos = results[2] as List<Centrosmedicos>;
        _especialidadSeleccionada = especialidadGeneral.id;
        _isLoading = false; // Ocultamos el indicador de carga
      });
    }
  }

  // Lógica para cargar exámenes dinámicamente.
  // Future<void> _onTipoCitaChanged(int? newTipoCitaId) async {
  //   setState(() {
  //     _tipoCitaSeleccionada = newTipoCitaId;
  //     _examenesDisponibles.clear();
  //     _examenesSeleccionados.clear();
  //   });

  // Reemplaza '2' con el ID real de tu "Tipo de cita que requiere exámenes".
  //   const int idCitaConExamenes = 2;

  //   if (newTipoCitaId == idCitaConExamenes) {
  //  Muestra un indicador de carga si es necesario.
  //     final examenes = await ExamenesRepository().getExamenesPorTipoCita();
  //     if (mounted) {
  //       setState(() {
  //         _examenesDisponibles = examenes;
  //       });
  //     }
  //   }
  }

  Future<void> _seleccionarImagen() async {
    final XFile? image = await _picker.pickImage(source: ImageSource.gallery);
    if (image != null) {
      setState(() {
        _imagenSeleccionada = File(image.path);
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Container();
  }
}
