import 'package:flutter/material.dart';

class CustomBottomNavigationBar extends StatelessWidget {
  final int selectedIndex;
  final Function(int) onItemTapped;

  const CustomBottomNavigationBar({
    super.key,
    required this.selectedIndex,
    required this.onItemTapped,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(50),
        boxShadow: [
          BoxShadow(
            color: Colors.black.withOpacity(0.1),
            spreadRadius: 2,
            blurRadius: 10,
            offset: const Offset(0, 3),
          ),
        ],
      ),
      margin: const EdgeInsets.only(left: 5, right: 5, bottom: 10),
      child: ClipRRect(
        borderRadius: BorderRadius.circular(50),
        child: BottomNavigationBar(
          type: BottomNavigationBarType.fixed,
          backgroundColor: Colors.white,
          selectedItemColor: Colors.blue,
          unselectedItemColor: Colors.grey,
          showSelectedLabels: false,
          showUnselectedLabels: false,
          currentIndex: selectedIndex,
          onTap: onItemTapped,
          items: <BottomNavigationBarItem>[
            BottomNavigationBarItem(
              icon: Image.asset(
                'assets/image/ico_home.png',
                width: 30,
                height: 30,
                //color: selectedIndex == 0 ? Colors.blue : Colors.grey,
              ),
              label: 'Inicio',
            ),
            BottomNavigationBarItem(
              icon: Image.asset(
                'assets/image/ico_medicamentos.png',
                width: 30,
                height: 30,
                //color: selectedIndex == 1 ? Colors.blue : Colors.grey,
              ),
              label: 'Citas',
            ),
            BottomNavigationBarItem(
              icon: Image.asset(
                'assets/image/ico_historial.png',
                width: 30,
                height: 30,
                //color: selectedIndex == 2 ? Colors.blue : Colors.grey,
              ),
              label: 'Historial',
            ),
            BottomNavigationBarItem(
              icon: Image.asset(
                'assets/image/ico_perfil.png',
                width: 30,
                height: 30,
                //color: selectedIndex == 3 ? Colors.blue : Colors.grey,
              ),
              label: 'Perfil',
            ),
          ],
        ),
      ),
    );
  }
}
