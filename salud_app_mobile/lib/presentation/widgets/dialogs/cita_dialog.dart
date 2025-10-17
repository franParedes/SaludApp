import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/especialidades.dart';
import 'dart:io';
import 'dart:convert';
import 'package:salud_app_mobile/domain/services/cita_service.dart';
import 'package:salud_app_mobile/domain/repositories/Citas/tipocita_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/centromedico_repository.dart';
import 'package:salud_app_mobile/domain/repositories/Utilidades/especialidad_repository.dart';

import '../../../domain/models/Citas/cita.dart';

Future<Future<Object?>> showCitaDialog(BuildContext context) async {
  final TextEditingController descripcionController = TextEditingController();

  File? imagenSeleccionada;
  int? tipoCitaSeleccionada;
  int? centroMedicoSeleccionado;
  int especialidad;

  final ImagePicker picker = ImagePicker();
  final repoEspecialidad = EspecialidadRepository();
  final repoTipoCita = TipocitaRepository();
  final repoCentroMedico = CentromedicoRepository();

  final especialidades = await repoEspecialidad.getEspecialidades();
  final tiposCita = await repoTipoCita.getTipocitas();
  final centrosMedicos = await repoCentroMedico.getCentrosmedicos();

  //Por defecto selecciona la especialidad de médico general
  especialidad = especialidades.firstWhere(
    (esp) => esp.especialidad == "General",
    orElse: () => Especialidades(id: 0, especialidad: ""),
  ).id;
  DateTime fechaCitaSolicitada = DateTime.now();

  Future<void> solicitarCita() async {
    final citaService = CitaService();

    String? base64Image;
    if (imagenSeleccionada != null) {
      final bytes = await File(imagenSeleccionada!.path).readAsBytes();
      base64Image = base64Encode(bytes);
    }

    final cita = Cita(
      pacienteId: 4,
      fechaSolicitud: DateTime.now(),
      lugar: centroMedicoSeleccionado ?? 0,
      fechaCita: fechaCitaSolicitada,
      motivoCita: descripcionController.text,
      tipoCita: tipoCitaSeleccionada ?? 0,
      adjuntos: base64Image != null
          ? [
              Adjunto(
                nombreArchivo: imagenSeleccionada!.path.split('/').last,
                tipoArchivo: "imagen",
                tipoMime: "image/jpeg",
                bytesArchivo: base64Image,
              ),
            ]
          : [],
      especialidad: especialidad,
    );

    final success = await citaService.solicitarCita(cita);

    if (success) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text("✅ Cita solicitada con éxito")),
      );
      Navigator.of(context).pop();
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text("❌ Error al solicitar la cita")),
      );
      Navigator.of(context).pop();
    }
  }

  return showGeneralDialog(
    context: context,
    barrierDismissible: true,
    barrierLabel: MaterialLocalizations.of(context).modalBarrierDismissLabel,
    transitionDuration: const Duration(milliseconds: 300),
    pageBuilder: (context, animation, secondaryAnimation) {
      return StatefulBuilder(
        builder: (context, setState) {
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
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withValues(alpha: 0.2),
                      blurRadius: 10,
                      offset: const Offset(0, 4),
                    ),
                  ],
                ),
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      // Descripción
                      TextField(
                        controller: descripcionController,
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

                      // Tipo de cita
                      DropdownButtonFormField<int>(
                        decoration: const InputDecoration(
                          labelText: "Tipo de cita",
                          border: OutlineInputBorder(),
                        ),
                        initialValue: tipoCitaSeleccionada,
                        items: tiposCita
                            .map(
                              (e) => DropdownMenuItem(
                                value: e.id,
                                child: Text(e.nombre),
                              ),
                            )
                            .toList(),
                        onChanged: (value) {
                          setState(() {
                            tipoCitaSeleccionada = value;
                          });
                        },
                      ),
                      const SizedBox(height: 20),

                      // Centro médico
                      DropdownButtonFormField<int>(
                        decoration: const InputDecoration(
                          labelText: "Centro Médico",
                          border: OutlineInputBorder(),
                        ),
                        initialValue: centroMedicoSeleccionado,
                        items: centrosMedicos
                            .map(
                              (e) => DropdownMenuItem(
                                value: e.id,
                                child: Text(e.centroMedico),
                              ),
                            )
                            .toList(),
                        onChanged: (value) {
                          setState(() {
                            centroMedicoSeleccionado = value;
                          });
                        },
                      ),
                      const SizedBox(height: 10),

                      // Preview imagen
                      if (imagenSeleccionada != null) ...[
                        ClipRRect(
                          borderRadius: BorderRadius.circular(8),
                          child: Image.file(
                            imagenSeleccionada!,
                            height: 120,
                            fit: BoxFit.cover,
                          ),
                        ),
                        const SizedBox(height: 10),
                      ],

                      // Botones
                      Row(
                        children: [
                          Expanded(
                            child: ElevatedButton.icon(
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.blue.shade100,
                              foregroundColor: Colors.black,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(12),
                              ),
                            ),
                            onPressed: () async {
                              final XFile? image = await picker.pickImage(
                                source: ImageSource.gallery,
                              );
                              if (image != null) {
                                setState(() {
                                  imagenSeleccionada = File(image.path);
                                });
                              }
                            },
                            icon: const Icon(Icons.attach_file),
                            label: const Text("Añadir archivos",),
                            ),
                          ),
                        ]
                      ),
                      
                      const SizedBox(height: 20),
                      
                      Row(
                        children: [
                          Expanded(
                            child: ElevatedButton(
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.blue,
                              foregroundColor: Colors.white,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(12),
                              ),
                            ),
                            onPressed: solicitarCita,
                            child: const Text("Solicitar cita"),
                            ),
                          ),
                        ]
                      ),
                    ],
                  ),
                ),
              ),
            ),
          );
        },
      );
    },
  );
}
