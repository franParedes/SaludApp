import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/models/Utilidades/generos.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/drop_down_field_custom.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/text_field_custom.dart';

class CedulaGeneroFields extends StatelessWidget {
  final TextEditingController cedulaController;
  final List<Generos> generos;
  final Generos? generoSeleccionado;
  final bool loadingGeneros;
  final Function(Generos) onGeneroChanged;

  const CedulaGeneroFields({
    super.key,
    required this.cedulaController,
    required this.generos,
    required this.generoSeleccionado,
    required this.loadingGeneros,
    required this.onGeneroChanged,
  });
  //const CedulaGeneroFields({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        TextFieldCustom(
          controller: cedulaController, 
          icono: Icons.credit_card, 
          type: TextInputType.text, 
          texto: "Cédula"
        ),

        const SizedBox(height: 10),

        DropdownFieldCustom(
          hintText: "Seleccione Género",
          icono: Icons.person_outline,
          selectedValue: generoSeleccionado?.nombre,
          items: generos.map((g) => g.nombre).toList(),
          loading: loadingGeneros,
          onChanged: (value) {
            final genero = generos.firstWhere(
              (g) => g.nombre == value,
              orElse: () => Generos(id: -1, nombre: ''),
            );
            if (genero.id != -1) {
              onGeneroChanged(genero);
            }
          }
        ),

        const SizedBox(height: 10),
      ],
    );
  }
}
