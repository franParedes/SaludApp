class Cita {
  final int pacienteId;
  final DateTime fechaSolicitud;
  final int lugar;
  final DateTime fechaCita;
  final String motivoCita;
  final int tipoCita;
  final List<Adjunto> adjuntos;
  final int especialidad;

  Cita({
    required this.pacienteId,
    required this.fechaSolicitud,
    required this.lugar,
    required this.fechaCita,
    required this.motivoCita,
    required this.tipoCita,
    required this.adjuntos,
    required this.especialidad,
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
      "Especialidad": especialidad,
    };
  }
}

class Adjunto {
  final String nombreArchivo;
  final String tipoArchivo;
  final String tipoMime;
  final String bytesArchivo;

  Adjunto({
    required this.nombreArchivo,
    required this.tipoArchivo,
    required this.tipoMime,
    required this.bytesArchivo,
  });

  Map<String, dynamic> toJson() {
    return {
      "NombreArchivo": nombreArchivo,
      "TipoArchivo": tipoArchivo,
      "TipoMime": tipoMime,
      "BytesArchivo": bytesArchivo,
    };
  }
}
