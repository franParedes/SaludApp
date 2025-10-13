import 'dart:async';
import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/repositories/Autenticacion/auth_repository.dart';
import 'package:salud_app_mobile/presentation/screens/home/home_screen.dart';
import '../dialogs/dialog.dart';

class LoginButton extends StatefulWidget {
  final TextEditingController email;
  final TextEditingController password;
  final AuthRepository? authRepository;

  const LoginButton({
    super.key,
    required this.email,
    required this.password,
    this.authRepository,
  });

  @override
  State<LoginButton> createState() => _LoginButtonState();
}

class _LoginButtonState extends State<LoginButton> {
  late final AuthRepository _authRepo;
  bool _loading = false;

  @override
  void initState() {
    super.initState();
    _authRepo = widget.authRepository ?? AuthRepository();
  }

  Future<void> _handleLogin() async {
    final email = widget.email.text.trim();
    final password = widget.password.text;

    // Validación simple
    if (email.isEmpty || password.isEmpty) {

      /*
        la variable mounted es una propiedad booleana que pertenece a la clase State de un 
        StatefulWidget. Indica si el objeto State está actualmente "montado" en el árbol de 
        widgets, es decir, si el State está activo y su widget asociado está insertado en el 
        árbol de widgets de Flutter.
      */
      if (!mounted) return;
      showMessageDialog(
        context,
        title: "Error",
        message: "Debe ingresar correo y contraseña",
      );
      return;
    }

    // Indicar que estamos cargando (deshabilita el botón)
    setState(() => _loading = true);

    try {
      // Llamada asíncrona al repositorio
      final auth = await _authRepo.userVerification(email, password);

      if (!mounted) return;

      if (auth.verificacion == 1) {
        // Reemplaza la pantalla de login para que el usuario no regrese con back
        Navigator.of(context).pushAndRemoveUntil(
          MaterialPageRoute(builder: (_) => const HomeScreen()),
          (route) => false,
        );
      } else {
        showMessageDialog(
          context,
          title: "Error",
          message: "Credenciales incorrectas",
        );
      }
    } on TimeoutException {
      if (!mounted) return;
      showMessageDialog(
        context,
        title: "Error de red",
        message: "No hay conexión. Verifique su red e inténtelo de nuevo.",
      );
    } catch (e) {
      // Aquí podrías loguear el error en un servicio de logs en vez de print
      if (!mounted) return;
      showMessageDialog(
        context,
        title: "Error",
        message: "Ocurrió un error, intenta de nuevo más tarde.",
      );
    } finally {
      if (mounted) {
        setState(() => _loading = false);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
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
          onPressed: _loading ? null : _handleLogin,
          child: _loading
              ? const SizedBox(
                  width: 24,
                  height: 24,
                  child: CircularProgressIndicator(
                    strokeWidth: 2,
                    valueColor: AlwaysStoppedAnimation<Color>(Colors.white),
                  ),
                )
              : const Text(
                  "Iniciar Sesion",
                  style: TextStyle(fontSize: 18, color: Colors.white),
                ),
        ),
      ),
    );
  }
}
