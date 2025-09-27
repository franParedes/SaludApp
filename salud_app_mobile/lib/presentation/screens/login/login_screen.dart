import 'package:flutter/material.dart';

import '../../widgets/login/email_field.dart';
import '../../widgets/login/login_tittle.dart';
import '../../widgets/login/password_field.dart';
import '../../widgets/login/remember_forgot_row.dart';
import '../../widgets/login/login_button.dart';
import '../../widgets/login/register_text.dart';
import '../../widgets/login/social_login_row.dart';

final email = TextEditingController();
final password = TextEditingController();

class LoginScreen extends StatelessWidget {
  const LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 50),

              const Center(child: LoginTitle(text: "Bienvenido")),

              const SizedBox(height: 100),

              EmailField(controller: email),

              const SizedBox(height: 15),

              PasswordField(controller: password),

              const SizedBox(height: 10),

              const RememberForgotRow(),

              const SizedBox(height: 5),

              LoginButton(email: email, password: password),

              const SizedBox(height: 1),

              // Separador
              Row(
                children: const [
                  Expanded(child: Divider()),
                  Padding(
                    padding: EdgeInsets.symmetric(horizontal: 8.0),
                    child: Text("O iniciar con"),
                  ),
                  Expanded(child: Divider()),
                ],
              ),

              const SizedBox(height: 5),

              const SocialLoginRow(),

              const SizedBox(height: 10),

              const RegisterText(),
            ],
          ),
        ),
      ),
    );
  }
}
