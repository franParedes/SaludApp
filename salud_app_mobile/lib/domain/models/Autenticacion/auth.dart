class Auth {
  final int idUser;
  final int idPaciente;
  final int tipoUser;
  final int departamento;
  final int municipio;
  final int barrio;
  final int verificacion;

  Auth({
    required this.idUser,
    required this.tipoUser,
    required this.verificacion,
    required this.idPaciente,
    required this.departamento,
    required this.municipio,
    required this.barrio,
  });

  factory Auth.fromJson(Map<String, dynamic> json) {
    return Auth(
      idUser: json['IdUsuario'],
      idPaciente: json['IdPaciente'],
      tipoUser: json['TipoUsuario'],
      departamento: json['Departamento'],
      municipio: json['Municipio'],
      barrio: json['Barrio'],
      verificacion: json['Verificado'],
    );
  }
}
