class Tipocita {
  final int id;
  final String nombre;

  Tipocita({required this.id, required this.nombre});

  factory Tipocita.fromJson(Map<String, dynamic> json) {
    return Tipocita(id: json['IdTipoCita'], nombre: json['Tipo']);
  }
}
