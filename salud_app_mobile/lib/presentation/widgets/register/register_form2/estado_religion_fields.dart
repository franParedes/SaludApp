import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/estadoCivil.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/religion.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/drop_down_field_custom.dart';

class EstadosReligiones extends StatelessWidget {
  //final String? estadoCivil;
  //final Function(String) onEstadoCivilChanged;

  final List<Estadocivil> estadoCivil;
  final bool loadingEstadoCivil;
  final Estadocivil? estadoCivilSeleccionado;
  final Function(Estadocivil) onEstadoCivilChanged;

  final List<Religion> religions;
  final bool loadingReligions;
  final Religion? religionSeleccionado;
  final Function(Religion) onReligionChanged;

  const EstadosReligiones({
    super.key,
    required this.estadoCivil,
    required this.loadingEstadoCivil,
    required this.estadoCivilSeleccionado,
    required this.onEstadoCivilChanged,

    required this.religions,
    required this.loadingReligions,
    required this.religionSeleccionado,
    required this.onReligionChanged,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        loadingReligions
            ? const Center(child: CircularProgressIndicator())
            : DropdownFieldCustom(
                hintText: "Religión",
                items: religions.map((m) => m.nombre).toList(),
                selectedValue: religionSeleccionado?.nombre,
                icono: Icons.local_fire_department ,
                onChanged: (value) {
                  final mun = religions.firstWhere(
                    (m) => m.nombre == value,
                    orElse: () => Religion(id: -1, nombre: ''),
                  );
                  if (mun.id != -1) onReligionChanged(mun);
                },
              ),

        const SizedBox(height: 10),

        loadingEstadoCivil
            ? const Center(child: CircularProgressIndicator())
            : DropdownFieldCustom(
                hintText: "Estado Civil",
                items: estadoCivil.map((m) => m.nombre).toList(),
                selectedValue: estadoCivilSeleccionado?.nombre,
                icono: Icons.favorite,
                onChanged: (value) {
                  final mun = estadoCivil.firstWhere(
                    (m) => m.nombre == value,
                    orElse: () => Estadocivil(id: -1, nombre: ''),
                  );
                  if (mun.id != -1) onEstadoCivilChanged(mun);
                },
              ),
        const SizedBox(height: 10),
      ],
    );
  }
}
