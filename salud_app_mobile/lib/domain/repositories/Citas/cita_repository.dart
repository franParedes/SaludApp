import 'package:flutter/material.dart';
import 'package:salud_app_mobile/domain/models/Citas/cita_labortorio.dart';

import '../../models/Citas/cita.dart';
import '../../services/api_service_cita.dart';

class CitaRepository {
  Future<bool> agendarCita(Cita cita) async {
    try {
      final response = await ApiServiceCita.post(
        "Citas/AgendarCitaMedica",
        cita.toJson(),
      );
      debugPrint("✅ Cita agendada: $response");
      return true;
    } catch (e) {
      debugPrint("❌ Error en agendarCita: $e");
      return false;
    }
  }

  Future<bool> agendarCitaLaboratorio(CitaLabortorio citaLab) async {
    try {
      final response = await ApiServiceCita.post(
        "Citas/AgendarCitaLaboratorio",
        citaLab.toJson(),
      );
      debugPrint("✅ Cita agendada: $response");
      return true;
    } catch (e) {
      debugPrint("❌ Error en agendarCita: $e");
      return false;
    }
  }
}
