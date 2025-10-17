import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/screens/citas/citas_screen.dart';
import 'package:salud_app_mobile/presentation/widgets/home/home_image_card.dart';
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

  // Declaramos late final para inicializar en initState.
  late final List<Widget> _screens;

  @override
  void initState() {
    super.initState();
    // Aquí pasamos el callback _onItemTapped al HomeContent
    _screens = [
      _HomeContent(onItemTapped: _onItemTapped),
      CitasScreen(onNavigationBack: () => _onItemTapped(0)),
      const Center(child: Text("Historial")),
      const Center(child: Text("Perfil")),
    ];
  }

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    // PopScope previene que el usuario salga de la app con el botón de atrás
    // si no está en la pestaña de inicio.
    return PopScope(
      // Solo permite salir de la app si estamos en la primera pestaña (index 0).
      canPop: _selectedIndex == 0,
      onPopInvokedWithResult: (didPop, result) {
        // 'didPop' será true si 'canPop' era true y se salió.
        // Si 'didPop' es false, significa que 'canPop' era false.
        if (!didPop) {
          // Si no se permitió el pop, entonces navegamos a la pestaña de inicio.
          _onItemTapped(0);
        }
      },
      child: Scaffold(
        // IndexedStack mantiene el estado de todas las pestañas en memoria,
        // lo que mejora la experiencia de usuario al cambiar entre ellas.
        body: IndexedStack(
          index: _selectedIndex,
          children: _screens,
        ),
        bottomNavigationBar: CustomBottomNavigationBar(
          selectedIndex: _selectedIndex,
          onItemTapped: _onItemTapped,
        ),
      ),
    );
  }
}

class _HomeContent extends StatelessWidget {
  // Usamos ValueChanged<int> (void Function(int))
  final ValueChanged<int> onItemTapped;

  const _HomeContent({required this.onItemTapped});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: HomeHeader(),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Text(
                "¿Cómo te sientes hoy?",
                  style: TextStyle(
                    fontFamily: 'Kanit',
                    fontWeight: FontWeight.w500,
                    fontSize: 30,
                    color: AppColors.primary,
                  ),
                )
              ],
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
                    onTap: () => onItemTapped(0),
                  ),
                  HomeImageCard(
                    image: "assets/image/seguimiento.png",
                    title: "Filas virtuales",
                    onTap: () => onItemTapped(0),
                  ),
                  HomeImageCard(
                    image: "assets/image/metricas.png",
                    title: "Recordatorios de medicamentos",
                    onTap: () => onItemTapped(0),
                  ),
                  HomeImageCard(
                    image: "assets/image/citas.png",
                    title: "Seguimiento de pacientes",
                    onTap: () => onItemTapped(1),
                  ),
                  HomeImageCard(
                    image: "assets/image/historialmedico.png",
                    title: "Recordatorios de medicamentos",
                    onTap: () => onItemTapped(2),
                  ),
                  HomeImageCard(
                    image: "assets/image/filasv.png",
                    title: "Seguimiento de pacientes",
                    onTap: () => onItemTapped(0),
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
