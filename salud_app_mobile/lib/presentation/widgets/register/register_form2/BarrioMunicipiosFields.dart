import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/barrio.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/municipio.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/drop_down_field_custom.dart';

class BarrioMunicipiosFields extends StatelessWidget {
  final List<Barrio> barrios;
  final List<Municipio> municipios;
  final bool loadingBarrios;
  final bool loadingMunicipios;
  final Barrio? barrioSeleccionado;
  final Municipio? municipioSeleccionado;
  final Function(Barrio) onBarrioChanged;
  final Function(Municipio) onMunicipioChanged;

  const BarrioMunicipiosFields({
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
    return Column(
      children: [
        loadingMunicipios
            ? const Center(child: CircularProgressIndicator())
            : DropdownFieldCustom(
                hintText: "Municipio",
                items: municipios.map((m) => m.nombre).toList(),
                selectedValue: municipioSeleccionado?.nombre,
                icono: Icons.location_city_outlined,
                onChanged: (value) {
                  final mun = municipios.firstWhere(
                    (m) => m.nombre == value,
                    orElse: () => Municipio(id: -1, nombre: '', departamentoId: 0),
                  );
                  if (mun.id != -1) onMunicipioChanged(mun);
                },
              ),

        const SizedBox(height: 10),

        loadingBarrios
            ? const Center(child: CircularProgressIndicator())
            : DropdownFieldCustom(
                hintText: "Barrio",
                items: barrios.map((b) => b.nombre).toList(),
                selectedValue: barrioSeleccionado?.nombre,
                icono: Icons.home,
                onChanged: (value) {
                  final bar = barrios.firstWhere(
                    (b) => b.nombre == value,
                    orElse: () => Barrio(id: -1, nombre: '', municipioId: 0),
                  );
                  if (bar.id != -1) onBarrioChanged(bar);
                },
              ),
      ],
    );
  }
}
