class Ocupacion {
  final int id;
  final String nombre;

  Ocupacion({required this.id, required this.nombre});

  factory Ocupacion.fromJson(Map<String, dynamic> json) {
    return Ocupacion(id: json['IdOcupacion'], nombre: json['Ocupacion']);
  }
}
