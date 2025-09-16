class Generos {
  final int id;
  final String nombre;

  Generos({required this.id, required this.nombre});

  factory Generos.fromJson(Map<String, dynamic> json) {
    return Generos(id: json['IdGenero'], nombre: json['Genero']);
  }
}
