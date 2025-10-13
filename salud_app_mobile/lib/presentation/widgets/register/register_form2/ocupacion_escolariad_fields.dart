import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/escolaridad.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/ocupacion.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/drop_down_field_custom.dart';

class OcupacionEscolariadFields extends StatelessWidget {
  final List<Ocupacion> ocupaciones;
  final Ocupacion? ocupacionSeleccionado;
  final bool loadingOcupaciones;
  final Function(Ocupacion) onOcupacionChanged;

  final List<Escolaridad> escolaridad;
  final Escolaridad? escolaridadSeleccionado;
  final bool loadingEscolaridad;
  final Function(Escolaridad) onEscolaridadChanged;

  const OcupacionEscolariadFields({
    super.key,
    required this.ocupaciones,
    required this.ocupacionSeleccionado,
    required this.loadingOcupaciones,
    required this.onOcupacionChanged,

    required this.escolaridad,
    required this.escolaridadSeleccionado,
    required this.loadingEscolaridad,
    required this.onEscolaridadChanged,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        loadingOcupaciones
          ? const Center(child: CircularProgressIndicator())
          : DropdownFieldCustom(
              hintText: "Ocupación",
              selectedValue: ocupacionSeleccionado?.nombre,
              items: ocupaciones.map((o) => o.nombre).toList(),
              icono: Icons.work,
              onChanged: (value) {
                final ocup = ocupaciones.firstWhere(
                  (o) => o.nombre == value,
                  orElse: () => Ocupacion(id: -1, nombre: ''),
                );
                if (ocup.id != -1) {
                  onOcupacionChanged(ocup);
                }
              },
            ),

        const SizedBox(height: 10),

        loadingEscolaridad
          ? const Center(child: CircularProgressIndicator())
          : DropdownFieldCustom(
              hintText: "Escolaridad",
              selectedValue: escolaridadSeleccionado?.nombre,
              items: escolaridad.map((o) => o.nombre).toList(),
              icono: Icons.school,
              onChanged: (value) {
                final escol = escolaridad.firstWhere(
                  (o) => o.nombre == value,
                  orElse: () => Escolaridad(id: -1, nombre: ''),
                );
                if (escol.id != -1) {
                  onEscolaridadChanged(escol);
                }
              },
            ),

        const SizedBox(height: 10),
      ],
    );
  }
}
