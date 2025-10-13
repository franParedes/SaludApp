class Paciente {
  //GeneralInfo generalInfo;
  String cedula;
  String primerNombre;
  String segundoNombre;
  String primerApellido;
  String segundoApellido;
  String correo;
  String contrasenya;
  int genero;
  String fechaNacimiento;
  int tipoUsuario;

  String numeroInss;
  int ocupacion;
  int escolaridad;
  int religion;
  int edad;
  int estadoCivil;
  int cantidadHermanos;
  List<Telefono> telefonos;
  List<Direccion> direcciones;

  Paciente({
    required this.cedula,
    required this.primerNombre,
    required this.segundoNombre,
    required this.primerApellido,
    required this.segundoApellido,
    required this.correo,
    required this.contrasenya,
    required this.genero,
    required this.fechaNacimiento,
    required this.tipoUsuario,
    
    required this.numeroInss,
    required this.ocupacion,
    required this.escolaridad,
    required this.religion,
    required this.edad,
    required this.estadoCivil,
    required this.cantidadHermanos,
    required this.telefonos,
    required this.direcciones,
  });

  Map<String, dynamic> toJson() => {
    "Cedula": cedula,
    "PrimerNombre": primerNombre,
    "SegundoNombre": segundoNombre,
    "PrimerApellido": primerApellido,
    "SegundoApellido": segundoApellido,
    "Correo": correo,
    "Contrasenya": contrasenya,
    "Genero": genero,
    "FechaNacimiento": fechaNacimiento,
    "TipoUsuario": tipoUsuario,
    
    "NumeroInss": numeroInss,
    "Ocupacion": ocupacion,
    "Escolaridad": escolaridad,
    "Religion": religion,
    "Edad": edad,
    "EstadoCivil": estadoCivil,
    "CantidadHermanos": cantidadHermanos,
    "Telefonos": telefonos.map((t) => t.toJson()).toList(),
    "Direcciones": direcciones.map((d) => d.toJson()).toList(),
  };
}

class Telefono {
  int telefono;
  int compania;

  Telefono({required this.telefono, required this.compania});

  Map<String, dynamic> toJson() => {"Telefono": telefono, "Compania": compania};
}

class Direccion {
  int departamento;
  int municipio;
  int barrio;
  String direccion;

  Direccion({
    required this.departamento,
    required this.municipio,
    required this.barrio,
    required this.direccion,
  });

  Map<String, dynamic> toJson() => {
    "Departamento": departamento,
    "Municipio": municipio,
    "Barrio": barrio,
    "Direccion": direccion,
  };
}
