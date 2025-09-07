import 'package:flutter/material.dart';

class LoginTitle extends StatelessWidget {
  final String text; // propiedad para recibir el texto

  const LoginTitle({
    super.key,
    required this.text, // requerido
  });

  @override
  Widget build(BuildContext context) {
    return Text(
      text, // aquí usas el parámetro
      style: const TextStyle(
        fontSize: 30,
        fontWeight: FontWeight.bold,
        color: Color(0xFF1c1ec5),
      ),
    );
  }
}
