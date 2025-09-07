import 'package:flutter/material.dart';

class RegisterDateField extends StatelessWidget {
  final TextEditingController controller;

  const RegisterDateField({super.key, required this.controller});

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: DateTime(2000),
      firstDate: DateTime(1900),
      lastDate: DateTime.now(),
    );

    if (picked != null) {
      controller.text = "${picked.day}/${picked.month}/${picked.year}";
    }
  }

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: controller,
      readOnly: true,
      onTap: () => _selectDate(context),
      decoration: const InputDecoration(
        labelText: "Fecha de Nacimiento",
        border: OutlineInputBorder(),
      ),
    );
  }
}
