import 'package:flutter/material.dart';
import 'package:salud_app_mobile/theme/app_colors.dart';

class HomeSearch extends StatelessWidget {
  const HomeSearch({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
    decoration: BoxDecoration(
      boxShadow: [
        BoxShadow(
          color: Colors.black12,
          blurRadius: 8,
          spreadRadius: 2,
          offset: Offset(0, 1),
        ),
      ],
      borderRadius: BorderRadius.circular(30),
    ),
    child: TextField(
      decoration: InputDecoration(
        hintText: "Buscar un doctor, medicinas, etc",
        hintStyle: TextStyle(color: AppColors.background01),
        prefixIcon: const Icon(Icons.search, color: AppColors.background01),
        suffixIcon: const Icon(Icons.mic, color: AppColors.background01),
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(30),
          borderSide: BorderSide.none,
        ),
        filled: true,
        fillColor: Colors.white,
      ),
    ),
  );
  }
}
