import 'package:flutter/material.dart';
import '../../../../domain/models/barrio.dart';
import '../../../../domain/models/municipio.dart';
import '../register_droopdown.dart';

class BarrioMunicipioField extends StatelessWidget {
  final List<Barrio> barrios;
  final List<Municipio> municipios;
  final bool loadingBarrios;
  final bool loadingMunicipios;
  final Barrio? barrioSeleccionado;
  final Municipio? municipioSeleccionado;
  final Function(Barrio) onBarrioChanged;
  final Function(Municipio) onMunicipioChanged;

  const BarrioMunicipioField({
    super.key,
    required this.barrios,
    required this.municipios,
    required this.loadingBarrios,
    required this.loadingMunicipios,
    required this.barrioSeleccionado,
    required this.municipioSeleccionado,
    required this.onBarrioChanged,
    required this.onMunicipioChanged,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: loadingBarrios
              ? const CircularProgressIndicator()
              : RegisterDropdown(
                  label: "Barrio",
                  selectedValue: barrioSeleccionado?.nombre,
                  items: barrios.map((b) => b.nombre).toList(),
                  onChanged: (value) {
                    final bar = barrios.firstWhere(
                      (b) => b.nombre == value,
                      orElse: () => Barrio(id: -1, nombre: '', municipioId: 0),
                    );
                    if (bar.id != -1) onBarrioChanged(bar);
                  },
                ),
        ),
        const SizedBox(width: 10),
        Expanded(
          child: loadingMunicipios
              ? const CircularProgressIndicator()
              : RegisterDropdown(
                  label: "Municipio",
                  selectedValue: municipioSeleccionado?.nombre,
                  items: municipios.map((m) => m.nombre).toList(),
                  onChanged: (value) {
                    final mun = municipios.firstWhere(
                      (m) => m.nombre == value,
                      orElse: () => municipios.first,
                    );
                    onMunicipioChanged(mun);
                  },
                ),
        ),
      ],
    );
  }
}
