import 'package:flutter/material.dart';

class CustomScaffold extends StatelessWidget {
  const CustomScaffold ({super.key, this.child});
  final Widget? child;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      extendBodyBehindAppBar: true,
      //Stack permite suponer widgets
      body: Stack(
        children: [
          Image.asset(
            'assets/image/background.jpg',
            fit: BoxFit.cover,
            width: double.infinity,
            height: double.infinity,
            ),
           //Asegura que el contenido no se oculte bajo la barra de estado
           SafeArea(
            child: child!,
          ),
        ],
      ),
    );
  }
}