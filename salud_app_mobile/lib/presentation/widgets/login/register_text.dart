import 'package:flutter/material.dart';

class RegisterText extends StatelessWidget {
  const RegisterText({super.key});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const Text("¿No tienes una cuenta? "),
        GestureDetector(
          onTap: () {},
          child: const Text(
            "Regístrate",
            style: TextStyle(
              color: Color(0xFF1c1ec5),
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ],
    );
  }
}
