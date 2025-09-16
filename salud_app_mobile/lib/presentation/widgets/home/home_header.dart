import 'package:flutter/material.dart';
import 'package:salud_app_mobile/theme/app_colors.dart';

class HomeHeader extends StatelessWidget implements PreferredSizeWidget {
  const HomeHeader({super.key});

  @override
  Widget build(BuildContext context) {
    return AppBar(
      backgroundColor: Colors.white,
      elevation: 0,
      leading: const Padding(
        padding: EdgeInsets.only(left: 14.0, top: 8.0, bottom: 8.0),
        child: CircleAvatar(
          backgroundImage: NetworkImage(
            "https://www.shutterstock.com/image-photo/smiling-african-american-millennial-businessman-600nw-1437938108.jpg",
          ), // pon tu asset
        ),
      ),
      title: const Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            "Buenos días ☀️",
            style: TextStyle(fontSize: 14, fontWeight: FontWeight.w500, color: AppColors.primary),
          ),
          Text(
            "Pedro Romero",
            style: TextStyle(fontSize: 20, color: AppColors.primary,),
          ),
        ],
      ),
      actions: [
        Stack(
          children: [
            IconButton(
              onPressed: () {},
              icon: const Icon(
                Icons.notifications,
                color: Colors.blue,
                size: 28,
              ),
            ),
            Positioned(
              right: 10,
              top: 10,
              child: Container(
                width: 12,
                height: 12,
                decoration: const BoxDecoration(
                  color: Colors.red,
                  shape: BoxShape.circle,
                ),
              ),
            ),
          ],
        ),
      ],
    );
  }

  @override
  Size get preferredSize => const Size.fromHeight(kToolbarHeight);
}
