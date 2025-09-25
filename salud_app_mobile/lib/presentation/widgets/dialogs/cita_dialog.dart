import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:intl/intl.dart';

import 'dart:io';

import 'package:salud_app_mobile/domain/repositories/tipocita_repository.dart';
import 'package:salud_app_mobile/domain/repositories/centromedico_repository.dart';
import 'package:salud_app_mobile/presentation/widgets/citas/citas_date_field.dart';

import '../../../domain/repositories/especialidad_repository.dart';

Future<Future<Object?>> showCitaDialog(BuildContext context) async {
  final TextEditingController descripcionController = TextEditingController();
  File? imagenSeleccionada;
  String? tipoCitaSeleccionada;
  String? especialidadSeleccionada;
  String? centroMedicoSeleccionado;

  final ImagePicker picker = ImagePicker();
  final repoEspecialidad = EspecialidadRepository();
  final repoTipoCita = TipocitaRepository();
  final repoCentroMedico = CentromedicoRepository();

  final especialidades = await repoEspecialidad.getEspecialidades();
  final tiposCita = await repoTipoCita.getTipocitas();
  final centrosMedicos = await repoCentroMedico.getCentrosmedicos();

  final fechaController = TextEditingController();
  DateTime fechaCitaSolicitada = DateTime.now();

  return showGeneralDialog(
    // ignore: use_build_context_synchronously
    context: context,
    barrierDismissible: true,
    // ignore: use_build_context_synchronously
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
                      // ignore: deprecated_member_use
                      color: Colors.black.withOpacity(0.2),
                      blurRadius: 10,
                      offset: const Offset(0, 4),
                    ),
                  ],
                ),
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      // Campo de texto
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

                      // Fecha solicitud de cita
                      CitasDateField(
                        label: "Fecha de solicitud de cita",
                        controller: fechaController,
                      ),
                      const SizedBox(height: 10),

                      // Dropdown Tipo cita
                      DropdownButtonFormField<String>(
                        decoration: const InputDecoration(
                          labelText: "Tipo de cita",
                          border: OutlineInputBorder(),
                        ),
                        value: tipoCitaSeleccionada,
                        items: tiposCita
                            .map(
                              (e) => DropdownMenuItem(
                                value: e.id.toString(),
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

                      // Dropdown Especialidad
                      DropdownButtonFormField<String>(
                        decoration: const InputDecoration(
                          labelText: "Especialidad",
                          border: OutlineInputBorder(),
                        ),
                        value: especialidadSeleccionada,
                        items: especialidades
                            .map(
                              (e) => DropdownMenuItem(
                                value: e.id.toString(),
                                child: Text(e.especialidad),
                              ),
                            )
                            .toList(),
                        onChanged: (value) {
                          setState(() {
                            especialidadSeleccionada = value;
                          });
                        },
                      ),
                      const SizedBox(height: 20),

                      // Dropdown Centro Médico
                      DropdownButtonFormField<String>(
                        decoration: const InputDecoration(
                          labelText: "Centro Médico",
                          border: OutlineInputBorder(),
                        ),
                        value: centroMedicoSeleccionado,
                        items: centrosMedicos
                            .map(
                              (e) => DropdownMenuItem(
                                value: e.id.toString(),
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
                      const SizedBox(height: 20),

                      // Imagen seleccionada (preview)
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
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          ElevatedButton.icon(
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
                            label: const Text("Añadir archivos"),
                          ),
                          ElevatedButton(
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.blue,
                              foregroundColor: Colors.white,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(12),
                              ),
                            ),
                            onPressed: () {
                              Navigator.of(context).pop();
                              print(
                                "Fecha: ${DateFormat("yyyy-MM-dd").format(fechaCitaSolicitada)}",
                              );
                              print(
                                "Descripción: ${descripcionController.text}",
                              );
                              print("Tipo de cita: $tipoCitaSeleccionada");
                              print("Especialidad: $especialidadSeleccionada");
                              print("Centro Médico: $centroMedicoSeleccionado");
                              if (imagenSeleccionada != null) {
                                print("Imagen: ${imagenSeleccionada!.path}");
                              }
                            },
                            child: const Text("Solicitar cita"),
                          ),
                        ],
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
