class Religion {
  final int id;
  final String nombre;

  Religion({required this.id, required this.nombre});

  factory Religion.fromJson(Map<String, dynamic> json) {
    return Religion(id: json['IdReligion'], nombre: json['Religion']);
  }
}
