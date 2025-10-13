class Centrosmedicos {
  final int id;
  final String centroMedico;
  final int departamentoId;
  final int municipioId;

  Centrosmedicos({
    required this.id,
    required this.centroMedico,
    required this.departamentoId,
    required this.municipioId,
  });

  factory Centrosmedicos.fromJson(Map<String, dynamic> json) {
    return Centrosmedicos(
      id: json['IdCentro'],
      centroMedico: json['Centro'],
      departamentoId: json['Departamento'],
      municipioId: json['Municipio'],
    );
  }
}
