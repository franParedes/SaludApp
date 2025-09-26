import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/screens/home/home_screen.dart';

class LoginButton extends StatelessWidget {
  final String email;
  final String password;

  const LoginButton({
    super.key,
    required String this.email,
    required String this.password,
  });

  @override
  Widget build(BuildContext context) {
    return Center(
      child: SizedBox(
        width: double.infinity,
        height: 50,
        child: ElevatedButton(
          style: ElevatedButton.styleFrom(
            backgroundColor: Color(0xFF1c1ec5),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(10),
            ),
          ),
          onPressed: () {
            print("Email: ${email}");
            print("Password: ${password}");

            if (email.isNotEmpty && password.isNotEmpty) {
              Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => const HomeScreen()),
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
