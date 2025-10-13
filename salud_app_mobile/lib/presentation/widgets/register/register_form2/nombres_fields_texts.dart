import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/text_field_custom.dart';

class NombresFieldsText extends StatelessWidget {
  // final primerNombreController = TextEditingController();
  // final segundoNombreController = TextEditingController();
  // final primerApellidoController = TextEditingController();
  // final segundoApellidoController = TextEditingController();

  final TextEditingController primerNombreController;
  final TextEditingController segundoNombreController;
  final TextEditingController primerApellidoController;
  final TextEditingController segundoApellidoController;

  const NombresFieldsText({
    super.key, 
    required this.primerNombreController,
    required this.segundoNombreController,
    required this.primerApellidoController,
    required this.segundoApellidoController,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        //Primer nombre
        TextFieldCustom(
          controller: primerNombreController,
          icono: Icons.person,
          type: TextInputType.text,
          texto: "Primer Nombre",
        ),

        const SizedBox(height: 10),

        //Segundo nombre
        TextFieldCustom(
          controller: segundoNombreController,
          icono: Icons.person,
          type: TextInputType.text,
          texto: "Segundo Nombre",
        ),

        const SizedBox(height: 10),

        //Primer apellido
        TextFieldCustom(
          controller: primerApellidoController,
          icono: Icons.person,
          type: TextInputType.text,
          texto: "Primer Apellido",
        ),

        const SizedBox(height: 10),

        //Segundo Apellido
        TextFieldCustom(
          controller: segundoApellidoController,
          icono: Icons.person,
          type: TextInputType.text,
          texto: "Segundo Apellido",
        ),

        const SizedBox(height: 10),
      ],
    );
  }
}
