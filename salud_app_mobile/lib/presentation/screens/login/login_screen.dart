import 'package:flutter/material.dart';

import '../../widgets/login/email_field.dart';
import '../../widgets/login/login_tittle.dart';
import '../../widgets/login/password_field.dart';
import '../../widgets/login/remember_forgot_row.dart';
import '../../widgets/login/login_button.dart';
import '../../widgets/login/register_text.dart';
import '../../widgets/login/social_login_row.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 80),

              const Center(child: LoginTitle()),

              const SizedBox(height: 100),

              const EmailField(),

              const SizedBox(height: 15),

              const PasswordField(),

              const SizedBox(height: 10),

              const RememberForgotRow(),

              const SizedBox(height: 20),

              const LoginButton(),

              const SizedBox(height: 25),

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

              const SizedBox(height: 20),

              const SocialLoginRow(),

              const RegisterText(),
            ],
          ),
        ),
      ),
    );
  }
}
