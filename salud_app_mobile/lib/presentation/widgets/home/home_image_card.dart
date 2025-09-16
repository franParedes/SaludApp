import 'package:flutter/material.dart';

class HomeImageCard extends StatelessWidget {
  final String image;
  final String title;
  final VoidCallback? onTap;

  const HomeImageCard({
    super.key,
    required this.image,
    required this.title,
    this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Card(
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
        color: Colors.white,
        elevation: 0,
        child: Image.asset(
          image,
          width: 180,
          fit: BoxFit.cover, // para que la imagen llene el contenedor
        ),
      ),
    );
  }
}
