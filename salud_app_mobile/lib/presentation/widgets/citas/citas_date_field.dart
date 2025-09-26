import 'package:flutter/material.dart';

class CitasDateField extends StatelessWidget {
  final String label;
  final TextEditingController controller;

  const CitasDateField({
    super.key,
    required this.label,
    required this.controller,
  });

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: DateTime(2000),
      firstDate: DateTime(1900),
      lastDate: DateTime(3000),
    );

    if (picked != null) {
      controller.text = "${picked.day}/${picked.month}/${picked.year}";
    }
  }

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: controller,
      style: const TextStyle(fontSize: 16, color: Colors.black),
      readOnly: true,
      onTap: () => _selectDate(context),
      decoration: InputDecoration(
        labelText: label,
        labelStyle: const TextStyle(fontSize: 16, color: Colors.black),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(30)),
      ),
    );
  }
}
