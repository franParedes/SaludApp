import 'package:flutter/material.dart';

class AccepTerms extends StatefulWidget {
  const AccepTerms({super.key});

  @override
  State<AccepTerms> createState() => _RememberForgotRowState();
}

class _RememberForgotRowState extends State<AccepTerms> {
  bool acceptTerms = false;

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          children: [
            Checkbox(
              value: acceptTerms,
              activeColor: Color(0xFF1c1ec5),
              onChanged: (value) {
                setState(() {
                  acceptTerms = value!;
                });
              },
            ),
            const Text("Acepto los términos", style: TextStyle(fontSize: 12)),
          ],
        ),
      ],
    );
  }
}
