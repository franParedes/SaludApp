import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/widgets/register/register_form2/register_form2.dart';
import '../../widgets/login/login_tittle.dart';
import '../../widgets/login/social_login_row.dart';
import '../../widgets/register/login_text.dart';
//import '../../widgets/register/register_form.dart';

class RegisterScreen extends StatelessWidget {
  const RegisterScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      //Permite hacer desplazable un único hijo
      body: SingleChildScrollView(
        child: SingleChildScrollView(
          //padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 10),
              const Center(child: LoginTitle(text: "Regístrate")),
              const SizedBox(height: 10),

              // El formulario ya está aislado
              const RegisterForm2(),

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
