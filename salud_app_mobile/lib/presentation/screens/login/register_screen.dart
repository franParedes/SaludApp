import 'package:flutter/material.dart';
import '../../widgets/login/login_tittle.dart';
import '../../widgets/login/social_login_row.dart';
import '../../widgets/register/login_text.dart';
import '../../widgets/register/register_form.dart';

class RegisterScreen extends StatelessWidget {
  const RegisterScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: SingleChildScrollView(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              IconButton(
                iconSize: 30,
                icon: const Icon(Icons.arrow_back, color: Color(0xFF1c1ec5)),
                onPressed: () => Navigator.pop(context),
              ),
              const Center(child: LoginTitle(text: "Regístrate")),
              const SizedBox(height: 10),

              // El formulario ya está aislado
              const RegisterForm(),

              const SizedBox(height: 10),
              Row(
                children: const [
                  Expanded(child: Divider()),
                  Padding(
                    padding: EdgeInsets.symmetric(horizontal: 8.0),
                    child: Text("O registrarte con"),
                  ),
                  Expanded(child: Divider()),
                ],
              ),
              const SizedBox(height: 5),
              const SocialLoginRow(),
              const SizedBox(height: 10),
              const LoginText(),
            ],
          ),
        ),
      ),
    );
  }
}
