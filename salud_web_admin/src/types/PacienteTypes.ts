// src/types/PacienteTypes.ts (NUEVO ARCHIVO)

export type TelefonoModel = {
  Telefono: number;
  Compania: number; // Podría ser un ID a una tabla de utilidades
};

export type DireccionModel = {
  Departamento: number; // ID
  Municipio: number; // ID
  Barrio: number; // ID
  Direccion: string;
};

export type PacienteModel = {
  Cedula: string;
  PrimerNombre: string;
  SegundoNombre: string;
  PrimerApellido: string;
  SegundoApellido: string;
  Correo: string;
  Contrasenya: string;
  Genero: number; // ID de Género
  FechaNacimiento: string; // "YYYY-MM-DD"
  TipoUsuario: number; // ID de Tipo de Usuario (Probablemente 1 para Paciente)
  Telefonos: TelefonoModel[];
  Direcciones: DireccionModel[];
  NumeroInss: string;
  Ocupacion: number; // ID de Ocupación
  Escolaridad: number; // ID de Escolaridad
  Religion: number; // ID de Religión
  Edad: number;
  EstadoCivil: number; // ID de Estado Civil
  CantidadHermanos: number;
};