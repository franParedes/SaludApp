import 'package:flutter/material.dart';
import '../register_text_field.dart';

class NombresFields extends StatelessWidget {
  final TextEditingController primerNombreController;
  final TextEditingController segundoNombreController;

  const NombresFields({
    super.key,
    required this.primerNombreController,
    required this.segundoNombreController,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: RegisterTextField(
            label: "Primer nombre",
            controller: primerNombreController,
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          child: RegisterTextField(
            label: "Segundo nombre",
            controller: segundoNombreController,
          ),
        ),
      ],
    );
  }
}
