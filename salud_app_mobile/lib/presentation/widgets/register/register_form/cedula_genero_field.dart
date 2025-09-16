import 'package:flutter/material.dart';
import '../../../../domain/models/generos.dart';
import '../register_text_field.dart';
import '../register_droopdown.dart';

class CedulaGeneroField extends StatelessWidget {
  final TextEditingController cedulaController;
  final List<Generos> generos;
  final Generos? generoSeleccionado;
  final bool loadingGeneros;
  final Function(Generos) onGeneroChanged;

  const CedulaGeneroField({
    super.key,
    required this.cedulaController,
    required this.generos,
    required this.generoSeleccionado,
    required this.loadingGeneros,
    required this.onGeneroChanged,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: RegisterTextField(
            label: "Cédula",
            controller: cedulaController,
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          child: loadingGeneros
              ? const Center(child: CircularProgressIndicator())
              : RegisterDropdown(
                  label: "Género",
                  selectedValue: generoSeleccionado?.nombre,
                  items: generos.map((g) => g.nombre).toList(),
                  onChanged: (value) {
                    final gen = generos.firstWhere(
                      (g) => g.nombre == value,
                      orElse: () => Generos(id: -1, nombre: ''),
                    );
                    if (gen.id != -1) {
                      onGeneroChanged(gen);
                    }
                  },
                ),
        ),
      ],
    );
  }
}
