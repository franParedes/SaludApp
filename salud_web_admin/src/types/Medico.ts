// src/types/Medico.ts

export type Medico = {
    nombre: string;
    apellido: string;
    especialidad: number;
    telefono: number;
    GeneralInfo: {
        Cedula: string;
        PrimerNombre: string;
        SegundoNombre: string;
        PrimerApellido: string;
        SegundoApellido: string;
        Correo: string;
        Genero: number;
        FechaNacimiento: string; // YYYY-MM-DD
        TipoUsuario: number;
    };
    Cod_sanitario: string;
    Especialidad: number;
    EgresadoDe: number;
    EgresadoEl: string; // YYYY-MM-DD
    Experiencia_anyos: number;
    Area_actual: number;
    Centro_actual: number;
    Turno_actual: number;
    Telefonos: { Telefono: number; Compania: number }[];
};