class Auth {
  final int idUser;
  final int idPaciente;
  final int tipoUser;
  final int verificacion;

  Auth({
    required this.idUser,
    required this.tipoUser,
    required this.verificacion,
    required this.idPaciente
  });

  factory Auth.fromJson(Map<String, dynamic> json) {
    return Auth(
      idUser: json['IdUsuario'],
      idPaciente: json['IdPaciente'],
      tipoUser: json['TipoUsuario'],
      verificacion: json['Verificado'],
    );
  }
}
