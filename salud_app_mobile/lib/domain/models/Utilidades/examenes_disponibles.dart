class ExamenesDisponibles {
  final int idExamen;
  final String examen;

  ExamenesDisponibles({
    required this.idExamen,
    required this.examen
  });

 factory ExamenesDisponibles.fromJson(Map<String, dynamic> json) {
    return ExamenesDisponibles(idExamen: json['IdExamen'], examen: json['Examen']);
  } 
}
