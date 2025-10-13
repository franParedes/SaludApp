import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/screens/welcome/welcome.dart';
import 'package:salud_app_mobile/theme/app_colors.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Salud App',
      //Estilos globales, tipografía, colores y estilos
      theme: ThemeData(
        fontFamily: 'Kanit',
        //Paleta de colores base
        colorScheme: ColorScheme.fromSwatch().copyWith( 
          primary: AppColors.primary,
          secondary: AppColors.secondary,
        ),
        //Define los estilos de texto globales
        textTheme: const TextTheme(
          bodySmall: TextStyle(fontSize: 14, color: AppColors.primary),
          bodyLarge: TextStyle(fontSize: 18, fontWeight: FontWeight.w400),
          bodyMedium: TextStyle(fontSize: 16, fontWeight: FontWeight.w200),
          titleLarge: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
        ),
      ),
      debugShowCheckedModeBanner: false,
      home: const WelcomeScreen(),
    );
  }
}
