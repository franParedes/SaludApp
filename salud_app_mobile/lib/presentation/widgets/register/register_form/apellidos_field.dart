import 'package:flutter/material.dart';
import '../register_text_field.dart';

class ApellidosFields extends StatelessWidget {
  final TextEditingController primerApellidoController;
  final TextEditingController segundoApellidoController;

  const ApellidosFields({
    super.key,
    required this.primerApellidoController,
    required this.segundoApellidoController,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: RegisterTextField(
            label: "Primer apellido",
            controller: primerApellidoController,
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          child: RegisterTextField(
            label: "Segundo apellido",
            controller: segundoApellidoController,
          ),
        ),
      ],
    );
  }
}
