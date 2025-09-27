// ignore_for_file: avoid_print, use_build_context_synchronously

import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/repositories/auth_repository.dart';
import 'package:salud_app_mobile/presentation/screens/home/home_screen.dart';
import '../dialogs/dialog.dart';

class LoginButton extends StatelessWidget {
  final TextEditingController email;
  final TextEditingController password;

  const LoginButton({super.key, required this.email, required this.password});

  @override
  Widget build(BuildContext context) {
    final repo = AuthRepository();

    return Center(
      child: SizedBox(
        width: double.infinity,
        height: 50,
        child: ElevatedButton(
          style: ElevatedButton.styleFrom(
            backgroundColor: const Color(0xFF1c1ec5),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(10),
            ),
          ),
          onPressed: () async {
            print("Email: ${email.text}");
            print("Password: ${password.text}");

            if (email.text.isNotEmpty && password.text.isNotEmpty) {
              try {
                final auth = await repo.userVerification(
                  email.text,
                  password.text,
                );

                if (auth.verificacion == 1) {
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => const HomeScreen()),
                  );
                } else {
                  showMessageDialog(
                    context,
                    title: "Error",
                    message: "Credenciales incorrectas",
                  );
                }
              } catch (e) {
                showMessageDialog(
                  context,
                  title: "Error",
                  message: "Credenciales incorrectas, intenta de nuevo",
                );
              }
            } else {
              showMessageDialog(
                context,
                title: "Error",
                message: "Debe ingresar correo y contraseña",
              );
            }
          },
          child: const Text(
            "Iniciar Sesion",
            style: TextStyle(fontSize: 18, color: Colors.white),
          ),
        ),
      ),
    );
  }
}
