import 'package:flutter/material.dart';
import 'package:salud_app_mobile/theme/app_colors.dart';

class DropdownFieldCustom extends StatelessWidget {
  final String hintText;
  final IconData icono;
  final String? selectedValue;
  final List<String> items;
  final bool loading;
  final ValueChanged<String?> onChanged;

  const DropdownFieldCustom({
    super.key,
    required this.hintText,
    required this.icono,
    required this.selectedValue,
    required this.items,
    required this.onChanged,
    this.loading = false,
  });

  @override
  Widget build(BuildContext context) {
    if (loading) {
      return const Center(child: CircularProgressIndicator());
    }

    return DropdownButtonFormField<String>(
      initialValue: selectedValue,
      isExpanded: true,
      style: const TextStyle(fontSize: 18, color: Colors.black),
      dropdownColor: Colors.white,
      icon: const Icon(Icons.keyboard_arrow_down_rounded, color: Colors.grey),
      decoration: InputDecoration(
        hintText: hintText,
        filled: true,
        fillColor: const Color.fromARGB(252, 252, 252, 254),
        prefixIcon: Icon(icono, color: AppColors.primary),
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
          borderSide: const BorderSide(color: Color(0xffEBDCFA)),
        ),
        enabledBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
          borderSide: const BorderSide(color: Color(0xffEBDCFA)),
        ),
      ),
      items: items.map((value) {
        return DropdownMenuItem<String>(
          value: value,
          child: Text(value, overflow: TextOverflow.ellipsis),
        );
      }).toList(),
      onChanged: onChanged,
    );
  }
}
