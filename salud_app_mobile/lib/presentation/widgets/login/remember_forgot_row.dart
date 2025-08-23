import 'package:flutter/material.dart';

class RememberForgotRow extends StatefulWidget {
  const RememberForgotRow({super.key});

  @override
  State<RememberForgotRow> createState() => _RememberForgotRowState();
}

class _RememberForgotRowState extends State<RememberForgotRow> {
  bool rememberMe = false;

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          children: [
            Checkbox(
              value: rememberMe,
              activeColor: Color(0xFF1c1ec5),
              onChanged: (value) {
                setState(() {
                  rememberMe = value!;
                });
              },
            ),
            const Text("Recordarme"),
          ],
        ),
        TextButton(
          onPressed: () {},
          child: const Text(
            "Olvidé mi contraseña",
            style: TextStyle(color: Color.fromARGB(255, 91, 91, 97)),
          ),
        ),
      ],
    );
  }
}
