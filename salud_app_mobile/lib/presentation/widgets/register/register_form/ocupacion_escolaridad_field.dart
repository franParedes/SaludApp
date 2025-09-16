import 'package:flutter/material.dart';
import '../../../../domain/models/ocupacion.dart';
import '../register_droopdown.dart';

class OcupacionEscolaridadField extends StatelessWidget {
  final List<Ocupacion> ocupaciones;
  final Ocupacion? ocupacionSeleccionado;
  final bool loadingOcupaciones;
  final Function(Ocupacion) onOcupacionChanged;

  final String? escolaridad;
  final Function(String) onEscolaridadChanged;

  const OcupacionEscolaridadField({
    super.key,
    required this.ocupaciones,
    required this.ocupacionSeleccionado,
    required this.loadingOcupaciones,
    required this.onOcupacionChanged,
    required this.escolaridad,
    required this.onEscolaridadChanged,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: loadingOcupaciones
              ? const Center(child: CircularProgressIndicator())
              : RegisterDropdown(
                  label: "Ocupación",
                  selectedValue: ocupacionSeleccionado?.nombre,
                  items: ocupaciones.map((o) => o.nombre).toList(),
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
        ),
        const SizedBox(width: 10),
        Expanded(
          child: RegisterDropdown(
            label: "Escolaridad",
            selectedValue: escolaridad,
            items: const ["NO TIENE", "PRIMARIA", "SECUNDARIA", "UNIVERSIDAD"],
            onChanged: (val) {
              if (val != null) {
                onEscolaridadChanged(val);
              }
            },
          ),
        ),
      ],
    );
  }
}
