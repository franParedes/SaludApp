import 'package:flutter/material.dart';

class AppColors {
  static const Color primary = Color(0xFF0088ff);
  static const Color secondary = Color(0xFF1c1EC5);
  static const Color hover = Color(0xFF78ABD3);
  static const Color disable = Color(0xFFC5D3DE);
  static const Color textColorPrimary = Color(0xFF1c1EC5);
  static const Color alertWarning = Color(0xFFFFC107);
  static const Color error = Color(0xFFD32F2F);
  static const Color bgLight = Color(0xFFF8F8F8);
  static const Color background00 = Color(0xFFD9D9D9);
  static const Color background01 = Color(0xFF7C7474);


  static const LinearGradient gradientPrimary = LinearGradient(
  colors: [
    AppColors.primary,
    Color.fromARGB(255, 173, 216, 253),
    ],
      begin: Alignment.topLeft,
      end: Alignment.bottomRight,
  );

}