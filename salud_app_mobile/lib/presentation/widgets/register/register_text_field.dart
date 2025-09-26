import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class RegisterTextField extends StatelessWidget {
  final String label;
  final TextEditingController controller;
  final TextInputType keyboardType;
  final List<TextInputFormatter> inputFormatters;

  const RegisterTextField({
    super.key,
    required this.label,
    required this.controller,
    this.keyboardType = TextInputType.text,
    this.inputFormatters = const [],
  });

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: controller,
      keyboardType: keyboardType,
      inputFormatters:
          inputFormatters, // siempre tendrá algo (aunque esté vacío)
      style: const TextStyle(fontSize: 10, color: Colors.black),
      decoration: InputDecoration(
        labelText: label,
        labelStyle: const TextStyle(fontSize: 10, color: Colors.black),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(25)),
      ),
    );
  }
}
