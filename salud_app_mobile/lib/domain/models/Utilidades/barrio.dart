class Barrio {
  final int id;
  final String nombre;
  final int municipioId;

  Barrio({required this.id, required this.nombre, required this.municipioId});

  factory Barrio.fromJson(Map<String, dynamic> json) {
    return Barrio(
      id: json['IdBarrio'],
      nombre: json['Barrio'],
      municipioId: json['MunicipioAlQuePertenece'],
    );
  }
}
