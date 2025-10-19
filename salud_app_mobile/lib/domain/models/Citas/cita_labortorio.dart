import 'package:salud_app_mobile/domain/models/Citas/cita.dart';

class CitaLabortorio {
  final int pacienteId;
  final DateTime fechaSolicitud;
  final int lugar;
  final DateTime fechaCita;
  final String motivoCita;
  final int tipoCita;
  final List<Adjunto> adjuntos;
  final List<String> examenesRealzar;

  CitaLabortorio({
    required this.pacienteId,
    required this.fechaSolicitud,
    required this.lugar,
    required this.fechaCita,
    required this.motivoCita,
    required this.tipoCita,
    required this.adjuntos,
    required this.examenesRealzar,
  });

  Map<String, dynamic> toJson() {
    return {
      "PacienteId": pacienteId,
      "FechaSolicitud": fechaSolicitud.toIso8601String(),
      "Lugar": lugar,
      "FechaCita": fechaCita.toIso8601String(),
      "MotivoCita": motivoCita,
      "TipoCita": tipoCita,
      "Adjuntos": adjuntos.map((a) => a.toJson()).toList(),
      "ExamanesRealizar": examenesRealzar,
    };
  }
}
