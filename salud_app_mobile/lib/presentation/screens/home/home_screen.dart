import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/widgets/home/home_image_card.dart';

import '../../screens/welcome/welcome.dart';
import '../../widgets/home/home_next_appoitment.dart';
import '../../widgets/home/home_search.dart';
import '../../widgets/home/home_header.dart';
import '../../widgets/home/navigation_bar.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  // Índice del ícono seleccionado.
  int _selectedIndex = 0;

  // Lista de widgets para cada pantalla.
  final List<Widget> _screens = [
    // Aquí iría el contenido de la pantalla de inicio
    // (el código que ya tienes).
    _HomeContent(),
    // Aquí irían los otros widgets para las otras 3 pantallas.
    const Center(child: Text("Calendario")),
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
      backgroundColor: Colors.white,
      appBar: HomeHeader(),

      // Muestra la pantalla según el índice seleccionado.
      body: _screens[_selectedIndex],
      bottomNavigationBar: CustomBottomNavigationBar(
        selectedIndex: _selectedIndex,
        onItemTapped: _onItemTapped,
      ),
      // Barra de navegación.
    );
  }
}

class _HomeContent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(16),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text(
            "¿Cómo te sientes hoy?",
            style: TextStyle(
              fontSize: 16,
              fontWeight: FontWeight.bold,
              color: Colors.blue,
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
              fontWeight: FontWeight.bold,
              color: Colors.blue,
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
    );
  }
}
