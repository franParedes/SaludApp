import '../models/cita.dart';
import '../repositories/cita_repository.dart';

class CitaService {
  final CitaRepository _repository = CitaRepository();

  Future<bool> solicitarCita(Cita cita) async {
    return await _repository.agendarCita(cita);
  }
}
