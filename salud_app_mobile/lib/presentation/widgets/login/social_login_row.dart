import 'package:flutter/material.dart';

class SocialLoginRow extends StatelessWidget {
  const SocialLoginRow({super.key});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        IconButton(
          icon: const Icon(Icons.facebook, color: Colors.blue, size: 35),
          onPressed: () {},
        ),
        const SizedBox(width: 20),
        IconButton(
          icon: const Icon(Icons.g_mobiledata, color: Colors.red, size: 40),
          onPressed: () {},
        ),
        const SizedBox(width: 20),
        IconButton(
          icon: const Icon(
            Icons.close,
            color: Colors.black,
            size: 35,
          ), // simulando X
          onPressed: () {},
        ),
      ],
    );
  }
}
