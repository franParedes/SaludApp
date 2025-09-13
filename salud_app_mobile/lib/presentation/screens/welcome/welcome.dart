import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/screens/login/login_screen.dart';
import 'package:salud_app_mobile/presentation/screens/login/register_screen.dart';
import 'package:salud_app_mobile/presentation/widgets/scaffold_welcome.dart/custom_scaffold.dart';
import 'package:salud_app_mobile/presentation/widgets/scaffold_welcome.dart/welcome_buttons.dart';

class WelcomeScreen extends StatelessWidget {
  const WelcomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return CustomScaffold(
      child: Column(
        children: [
          Flexible(
            flex: 8,
            child: Container(
              padding: const EdgeInsets.symmetric(vertical: 0, horizontal: 40),
              child: Center(
                child: RichText(
                  textAlign: TextAlign.center,
                  text: const TextSpan(
                    children: [
                      TextSpan(
                        text: 'Bienvenido a PacienteApp!\n',
                        style: TextStyle(
                          fontSize: 40.0,
                          fontWeight: FontWeight.w600,
                        ),
                      ),
                      TextSpan(
                        text:
                            '\nInicia sesion si tienes ya una cuenta, o registrate',
                        style: TextStyle(fontSize: 24),
                      ),
                    ],
                  ),
                ),
              ),
            ),
          ),
          const Flexible(
            flex: 1,
            child: Align(
              alignment: Alignment.bottomRight,
              child: Row(
                children: [
                  Expanded(
                    child: WelcomeButtons(
                      buttonText: 'Iniciar Sesion',
                      onTap: LoginScreen(),
                      color: Colors.transparent,
                      textColor: Colors.white,
                    ),
                  ),
                  Expanded(
                    child: WelcomeButtons(
                      buttonText: 'Registrarse',
                      onTap: RegisterScreen(),
                      color: Colors.white,
                      textColor: Colors.blueAccent,
                    ),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
