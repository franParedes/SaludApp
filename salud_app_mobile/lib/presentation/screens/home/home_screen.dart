import 'package:flutter/material.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: const Padding(
          padding: EdgeInsets.all(6.0),
          child: CircleAvatar(backgroundImage: NetworkImage('')),
        ),
        title: Text('Bienvenido: [Usuario]'),
      ),
      body: Container(),
    );
  }
}
