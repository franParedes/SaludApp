import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/screens/citas/citas_screen.dart';
import 'package:salud_app_mobile/presentation/widgets/home/home_image_card.dart';
import '../../screens/welcome/welcome.dart';
import '../../widgets/home/home_next_appoitment.dart';
import '../../widgets/home/home_search.dart';
import '../../widgets/home/home_header.dart';
import '../../widgets/home/navigation_bar.dart';
import 'package:salud_app_mobile/theme/app_colors.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  int _selectedIndex = 0;

  final List<Widget> _screens = [
    _HomeContent(),

    const CitasScreen(),
    const Center(child: Text("Historial")),
    const Center(child: Text("Perfil")),
  ];

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _screens[_selectedIndex],
      bottomNavigationBar: CustomBottomNavigationBar(
        selectedIndex: _selectedIndex,
        onItemTapped: _onItemTapped,
      ),
    );
  }
}

class _HomeContent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: HomeHeader(),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const Text(
              "¿Cómo te sientes hoy?",
              style: TextStyle(
                fontFamily: 'Kanit',
                fontWeight: FontWeight.w500,
                fontSize: 30,
                color: AppColors.primary,
              ),
            ),
            const SizedBox(height: 12),
            HomeSearch(),
            const SizedBox(height: 20),
            HomeNextAppoitment(),
            const SizedBox(height: 20),
            const Text(
              "Selecciona la categoría",
              style: TextStyle(
                fontSize: 16,
                fontWeight: FontWeight.w500,
                color: AppColors.primary,
              ),
            ),
            const SizedBox(height: 12),
            Expanded(
              child: GridView.count(
                crossAxisCount: 2,
                crossAxisSpacing: 12,
                mainAxisSpacing: 12,
                childAspectRatio: 0.65,
                children: [
                  HomeImageCard(
                    image: "assets/image/medicamentos.png",
                    title: "Historial médico",
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => const WelcomeScreen(),
                        ),
                      );
                    },
                  ),
                  HomeImageCard(
                    image: "assets/image/seguimiento.png",
                    title: "Filas virtuales",
                    onTap: () {},
                  ),
                  HomeImageCard(
                    image: "assets/image/metricas.png",
                    title: "Recordatorios de medicamentos",
                    onTap: () {},
                  ),
                  HomeImageCard(
                    image: "assets/image/citas.png",
                    title: "Seguimiento de pacientes",
                  ),
                  HomeImageCard(
                    image: "assets/image/historialmedico.png",
                    title: "Recordatorios de medicamentos",
                    onTap: () {},
                  ),
                  HomeImageCard(
                    image: "assets/image/filasv.png",
                    title: "Seguimiento de pacientes",
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
