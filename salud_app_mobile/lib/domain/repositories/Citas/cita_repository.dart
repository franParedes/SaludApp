import '../../models/Citas/cita.dart';
import '../../services/api_service_cita.dart';

class CitaRepository {
  Future<bool> agendarCita(Cita cita) async {
    try {
      final response = await ApiServiceCita.post(
        "Citas/AgendarCitaMedica",
        cita.toJson(),
      );
      print("✅ Cita agendada: $response");
      return true;
    } catch (e) {
      print("❌ Error en agendarCita: $e");
      return false;
    }
  }
}
