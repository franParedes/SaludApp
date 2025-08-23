import 'package:flutter/material.dart';

class LoginTitle extends StatelessWidget {
  const LoginTitle({super.key});

  @override
  Widget build(BuildContext context) {
    return const Text(
      "Bienvenido",
      style: TextStyle(
        fontSize: 40,
        fontWeight: FontWeight.bold,
        color: Color(0xFF1c1ec5),
      ),
    );
  }
}
