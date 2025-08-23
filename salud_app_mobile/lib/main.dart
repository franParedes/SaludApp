import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/screens/login/login_screen.dart';

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
      debugShowCheckedModeBanner: false,
      home: const LoginScreen(),
    );
  }
}
