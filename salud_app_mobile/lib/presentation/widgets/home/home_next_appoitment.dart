import 'package:flutter/material.dart';
import 'package:salud_app_mobile/theme/app_colors.dart';

class HomeNextAppoitment extends StatelessWidget {
  const HomeNextAppoitment({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(14),
      decoration: BoxDecoration(
        gradient: AppColors.gradientPrimary,
        borderRadius: BorderRadius.circular(12),
        boxShadow: const [
          BoxShadow(color: Colors.black12, blurRadius: 4, offset: Offset(0, 2)),
        ],
      ),
      child: Stack(
        children: [
          Row(
            children: [
              const Icon(Icons.calendar_month,
                  size: 60, color: AppColors.bgLight),
              const SizedBox(width: 9),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: const [
                    Text("Fecha y hora:",
                        style: TextStyle(color: AppColors.bgLight)),
                    Text("Jueves, 11 de septiembre | 10:00 a.m.",
                        style:
                            TextStyle(color: AppColors.bgLight, fontSize: 15)),
                    SizedBox(height: 15),
                    Text("Doctor:",
                        style:
                            TextStyle(color: AppColors.bgLight, fontSize: 15)),
                    Text("Juan Pérez",
                        style:
                            TextStyle(color: AppColors.bgLight, fontSize: 15)),
                  ],
                ),
              ),
            ],
          ),

          Positioned(
            bottom: 0,
            right: 0,
            child: ElevatedButton(
              onPressed: () {},
              style: ElevatedButton.styleFrom(
                backgroundColor: AppColors.bgLight,
                foregroundColor: AppColors.primary,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(30),
                ),
              ),
              child: const Text("Ver detalles"),
            ),
          ),
        ],
      ),
    );
  }
}
