class Estadocivil {
  final int id;
  final String nombre;

  Estadocivil({
    required this.id,
    required this.nombre
  });

  factory Estadocivil.fromJson(Map<String, dynamic> json) {
    return Estadocivil(
      id: json['IdEstadoCivil'],
      nombre: json['EstadoCivil'],
    );
  }
}
