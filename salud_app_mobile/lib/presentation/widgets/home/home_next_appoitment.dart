import 'package:flutter/material.dart';

class HomeNextAppoitment extends StatelessWidget {
  const HomeNextAppoitment({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: Colors.blue[100],
        borderRadius: BorderRadius.circular(12),
        boxShadow: const [
          BoxShadow(color: Colors.black12, blurRadius: 4, offset: Offset(0, 2)),
        ],
      ),
      child: Row(
        children: [
          const Icon(Icons.calendar_month, size: 30, color: Colors.blue),
          const SizedBox(width: 16),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: const [
                Text(
                  "Fecha y hora:",
                  style: TextStyle(color: Colors.grey, fontSize: 10),
                ),
                Text(
                  "Jueves, 11 de septiembre | 10:00 a.m.",
                  style: TextStyle(color: Colors.black, fontSize: 10),
                ),
                SizedBox(height: 4),
                Text("Doctor:", style: TextStyle(fontSize: 12)),
                Text("Dr. Juan Pérez", style: TextStyle(fontSize: 10)),
              ],
            ),
          ),
          ElevatedButton(
            onPressed: () {},
            child: const Text(
              "Ver detalles",
              style: TextStyle(color: Colors.blue, fontSize: 8),
            ),
          ),
        ],
      ),
    );
  }
}
