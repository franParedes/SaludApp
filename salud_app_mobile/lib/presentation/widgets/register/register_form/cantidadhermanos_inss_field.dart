import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import '../register_text_field.dart';

class HermanosInssField extends StatelessWidget {
  final TextEditingController hermanosController;
  final TextEditingController inssController;

  const HermanosInssField({
    super.key,
    required this.hermanosController,
    required this.inssController,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: RegisterTextField(
            label: "Cantidad de hermanos",
            controller: hermanosController,
            keyboardType: TextInputType.number,
          ),
        ),
        const SizedBox(width: 10),
        Expanded(
          child: RegisterTextField(
            inputFormatters: [LengthLimitingTextInputFormatter(9)],
            label: "N° INSS",
            controller: inssController,
          ),
        ),
      ],
    );
  }
}
