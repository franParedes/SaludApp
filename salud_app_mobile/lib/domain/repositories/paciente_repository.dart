import '../models/paciente.dart';
import '../services/api_service_paciente.dart';

class PacienteRepository {
  Future<bool> crearPaciente(Paciente paciente) async {
    try {
      final response = await ApiServicePaciente.post("Pacientes/CrearPaciente", paciente.toJson());
      print("✅ Paciente creado: $response");
      return true;
    } catch (e) {
      print("❌ Error en crearPaciente: $e");
      return false;
    }
  }
}
