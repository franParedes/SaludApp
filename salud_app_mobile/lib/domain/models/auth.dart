class Auth {
  final int idUser;
  final int tipoUser;
  final int verificacion;

  Auth({
    required this.idUser,
    required this.tipoUser,
    required this.verificacion,
  });

  factory Auth.fromJson(Map<String, dynamic> json) {
    return Auth(
      idUser: json['IdUsuario'],
      tipoUser: json['TipoUsuario'],
      verificacion: json['Verificado'],
    );
  }
}
