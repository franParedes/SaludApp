class Municipio {
  final int id;
  final String nombre;
  final int departamentoId;

  Municipio({
    required this.id,
    required this.nombre,
    required this.departamentoId,
  });

  factory Municipio.fromJson(Map<String, dynamic> json) {
    return Municipio(
      id: json['IdMunicipio'],
      nombre: json['Municipio'],
      departamentoId: json['DepartamentoAlQuePertenece'],
    );
  }
}
