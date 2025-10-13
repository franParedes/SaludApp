import 'dart:async';

import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/widgets/dialogs/dialog.dart';

class RegisterButtom extends StatefulWidget {
  final Future<bool> Function() onRegister;

  const RegisterButtom({
    super.key,
    required this.onRegister,
  });

  @override
  State<RegisterButtom> createState() => _RegisterButtom2State();
}

class _RegisterButtom2State extends State<RegisterButtom> {
  bool _loading = false;

  Future<void> _handleRegister() async {
    if (_loading) return;

    setState(() => _loading = true);

    try {
      final exito = await widget.onRegister();

      if (!mounted) return;

      await showMessageDialog(
        context,
        title: exito ? "Éxito" : "Error",
        message: exito
            ? "Usuario creado correctamente"
            : "Hubo un error al crear el usuario. Intenta de nuevo.",
      );

      if (exito && mounted) {
        Navigator.of(context).pop(); // vuelve atrás solo si se creó correctamente
      }
    } on TimeoutException {
      if (!mounted) return;
      await showMessageDialog(
        context,
        title: "Error de red",
        message: "No hay conexión. Verifique su red e inténtelo de nuevo.",
      );
    } catch (e, stack) {
      debugPrint("❌ Error en registro: $e");
      debugPrint(stack.toString());
      if (!mounted) return;
      await showMessageDialog(
        context,
        title: "Error",
        message: "Ocurrió un error inesperado. Intenta más tarde.",
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
          onPressed: _loading ? null : _handleRegister,
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
                  "Registrar usuario",
                  style: TextStyle(fontSize: 18, color: Colors.white),
                ),
        ),
      ),
    );
  }
}