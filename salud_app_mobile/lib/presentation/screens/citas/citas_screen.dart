import 'package:flutter/material.dart';
import 'package:salud_app_mobile/presentation/widgets/dialogs/cita_dialog.dart';
import 'package:salud_app_mobile/theme/app_colors.dart';
import 'package:table_calendar/table_calendar.dart';

class CitasScreen extends StatefulWidget {
  final VoidCallback onNavigationBack;
  const CitasScreen({
    super.key,
    required this.onNavigationBack
  });

  @override
  State<CitasScreen> createState() => _CitasScreenState();
}

class _CitasScreenState extends State<CitasScreen> {
  DateTime _focusedDay = DateTime.now();
  DateTime? _selectedDay;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
        centerTitle: true,
        backgroundColor: AppColors.primary,
        leading: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            decoration: BoxDecoration(
              // Un fondo sutil para que el botón destaque
              color: Colors.black.withValues(alpha: 0.15),
              shape: BoxShape.circle,
            ),
            child: IconButton(
              // Usamos pop() para volver a la pantalla anterior en el stack (HomeScreen)
              onPressed: widget.onNavigationBack,
              icon: const Icon(Icons.navigate_before),
              color: Colors.white,
              tooltip: 'Regresar', // Buena práctica para accesibilidad
            ),
          ),
        ),
        title: const Text(
          textAlign: TextAlign.center,
          "Gestión de citas",
          style: TextStyle(color: Colors.white),
        ),
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(25.0),
        child: Column(
          children: [
            Container(
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(20),
                boxShadow: [
                  BoxShadow(color: Colors.grey.shade300, blurRadius: 8),
                ],
              ),
              child: TableCalendar(
                firstDay: DateTime.utc(2020, 1, 1),
                lastDay: DateTime.utc(2030, 12, 31),
                focusedDay: _focusedDay,
                selectedDayPredicate: (day) => isSameDay(_selectedDay, day),
                onDaySelected: (selectedDay, focusedDay) {
                  setState(() {
                    _selectedDay = selectedDay;
                    _focusedDay = focusedDay;
                  });
                },
                calendarStyle: CalendarStyle(
                  todayDecoration: BoxDecoration(
                    color: Colors.blue.shade500,
                    shape: BoxShape.circle,
                  ),
                  selectedDecoration: BoxDecoration(
                    color: Colors.brown.shade300,
                    shape: BoxShape.circle,
                  ),
                ),
                headerStyle: const HeaderStyle(
                  formatButtonVisible: false,
                  titleCentered: true,
                ),
              ),
            ),
    
            const SizedBox(height: 20),
    
            Align(
              alignment: Alignment.centerLeft,
              child: Text(
                "Próximas citas",
                style: TextStyle(
                  fontSize: 16,
                  fontWeight: FontWeight.bold,
                  color: Colors.blue,
                ),
              ),
            ),
            const SizedBox(height: 10),
    
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(
                gradient: const LinearGradient(
                  colors: [Color(0xFF3AA0FF), Color(0xFF007BFF)],
                  begin: Alignment.topLeft,
                  end: Alignment.bottomRight,
                ),
                borderRadius: BorderRadius.circular(16),
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text(
                    "Doctor: Dr. Juan Pérez",
                    style: TextStyle(color: Colors.white, fontSize: 14),
                  ),
                  const Text(
                    "Especialidad: Nefrología",
                    style: TextStyle(color: Colors.white, fontSize: 14),
                  ),
                  const SizedBox(height: 8),
                  const Text(
                    "Fecha: jueves 11 septiembre",
                    style: TextStyle(color: Colors.white, fontSize: 14),
                  ),
                  const Text(
                    "Lugar: HEODRA – León",
                    style: TextStyle(color: Colors.white, fontSize: 14),
                  ),
                  const Text(
                    "Hora: 10:00 am",
                    style: TextStyle(color: Colors.white, fontSize: 14),
                  ),
                  const SizedBox(height: 12),
                  Row(
                    children: [
                      Expanded(
                        child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            backgroundColor: Colors.white,
                          ),
                          onPressed: () {},
                          child: const Text(
                            "Reprogramar",
                            style: TextStyle(color: Colors.blue),
                          ),
                        ),
                      ),
                      const SizedBox(width: 10),
                      Expanded(
                        child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            backgroundColor: Colors.blue.shade900,
                          ),
                          onPressed: () {},
                          child: const Text(
                            "Cancelar cita",
                            style: TextStyle(color: Colors.white),
                          ),
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ),
    
            const SizedBox(height: 10),
    
            Column(
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: [
                    Expanded(
                      child: ElevatedButton(
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.teal.shade200,
                          padding: const EdgeInsets.symmetric(
                            horizontal: 20,
                            vertical: 12,
                          ),
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(16),
                          ),
                        ),
                        onPressed: () {
                          showCitaDialog(context);
                        },
                        child: const Text(
                          "Agendar nueva cita",
                          style: TextStyle(color: AppColors.secondary),
                          textAlign: TextAlign.center,
                        ),
                      ),
                    ),
                  ],
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
