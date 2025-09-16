import 'package:flutter/material.dart';
import '../../../../domain/models/religion.dart';
import '../register_droopdown.dart';

class EstadoReligionField extends StatelessWidget {
  final String? estadoCivil;
  final Function(String) onEstadoCivilChanged;
  final List<Religion> religions;
  final bool loadingReligions;
  final Religion? religionSeleccionado;
  final Function(Religion) onReligionChanged;

  const EstadoReligionField({
    super.key,
    required this.estadoCivil,
    required this.onEstadoCivilChanged,
    required this.religions,
    required this.loadingReligions,
    required this.religionSeleccionado,
    required this.onReligionChanged,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: RegisterDropdown(
            label: "Estado civil",
            selectedValue: estadoCivil,
            items: ["SOLTER@", "CASAD@", "DIVORCIAD@", "VIUD@", "UNION LIBRE"],
            onChanged: (val) => onEstadoCivilChanged(val!),
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          child: loadingReligions
              ? const CircularProgressIndicator()
              : RegisterDropdown(
                  label: "Religión",
                  selectedValue: religionSeleccionado?.nombre,
                  items: religions.map((r) => r.nombre).toList(),
                  onChanged: (value) {
                    final rel = religions.firstWhere(
                      (r) => r.nombre == value,
                      orElse: () => Religion(id: -1, nombre: ''),
                    );
                    if (rel.id != -1) onReligionChanged(rel);
                  },
                ),
        ),
      ],
    );
  }
}
