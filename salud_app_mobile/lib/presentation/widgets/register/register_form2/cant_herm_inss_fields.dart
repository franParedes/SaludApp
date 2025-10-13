import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/text_field_custom.dart';

class CantHermInssFields extends StatelessWidget {
  final TextEditingController hermanosController;
  final TextEditingController inssController;

  const CantHermInssFields({
    super.key,
    required this.hermanosController,
    required this.inssController,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        TextFieldCustom(
          controller: hermanosController, 
          icono: Icons.person_2_rounded, 
          type: TextInputType.number, 
          texto: "Cantidad de hermanos"
        ),

        const SizedBox(height: 10),

        TextFieldCustom(
          controller: inssController, 
          icono: Icons.credit_score, 
          type: TextInputType.text, 
          texto: "Número de INSS"
        )
      ],
    );
  }
}
