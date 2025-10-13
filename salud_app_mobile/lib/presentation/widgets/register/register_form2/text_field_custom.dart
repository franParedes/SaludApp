import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:salud_app_mobile/theme/app_colors.dart';

class TextFieldCustom extends StatelessWidget {
  final TextEditingController controller;
  final IconData icono;
  final TextInputType type;
  final bool pass;
  final String texto;
  final List<TextInputFormatter> inputFormatters;

  const TextFieldCustom({
    super.key,
    required this.controller,
    required this.icono,
    required this.type,
    this.pass = false,
    required this.texto,
    this.inputFormatters = const [],
  });

  @override
  Widget build(BuildContext context) {
    return TextField(
      keyboardType: type,
      obscureText: pass,
      controller: controller,
      inputFormatters: inputFormatters,
      decoration: InputDecoration(
        hintText: texto,
        filled: true,
        fillColor: Color.fromARGB(252, 252, 252, 254),
        prefixIcon: Icon(icono, color: AppColors.primary),
        border: OutlineInputBorder(
          borderSide: BorderSide(color: Color.fromARGB(252, 252, 252, 254),),
          borderRadius: BorderRadius.circular(12)
        ),
        enabledBorder: OutlineInputBorder(
          borderSide: BorderSide(color: Color(0xffEBDCFA)),
          borderRadius: BorderRadius.circular(12)
        ),

      ),
    );
  }
}
