class Especialidades {
  final int id;
  final String especialidad;

  Especialidades({required this.id, required this.especialidad});

  factory Especialidades.fromJson(Map<String, dynamic> json) {
    return Especialidades(
      id: json['IdEspecialidad'],
      especialidad: json['Especialidad'],
    );
  }
}
