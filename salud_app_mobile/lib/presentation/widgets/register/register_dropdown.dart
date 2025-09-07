import 'package:flutter/material.dart';

class RegisterDropdown extends StatelessWidget {
  final String? selectedGender;
  final ValueChanged<String?> onChanged;

  const RegisterDropdown({
    super.key,
    required this.selectedGender,
    required this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return DropdownButtonFormField<String>(
      initialValue: selectedGender,
      decoration: const InputDecoration(
        labelText: "Género",
        border: OutlineInputBorder(),
      ),
      items: const [
        DropdownMenuItem(value: "Masculino", child: Text("Masculino")),
        DropdownMenuItem(value: "Femenino", child: Text("Femenino")),
        DropdownMenuItem(value: "Otro", child: Text("Otro")),
      ],
      onChanged: onChanged,
    );
  }
}
