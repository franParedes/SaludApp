class Escolaridad {
  final int id;
  final String nombre;

  Escolaridad({
    required this.id,
    required this.nombre
  });

  factory Escolaridad.fromJson(Map<String, dynamic> json) {
    return Escolaridad(
      id: json['IdEscolaridad'],
      nombre: json['Escolaridad'],
    );
  }
}
