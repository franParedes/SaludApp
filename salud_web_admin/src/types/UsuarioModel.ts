// -------------------------------------------------------------------------
// NOTA: Replicamos TelefonoModel y DireccionModel aquí para asegurar que
// UsuarioModel sea autocontenido, a menos que ya estén en un archivo común.
// Asumo que DireccionesModel es igual a DireccionModel del Medico.
// -------------------------------------------------------------------------

// Define la estructura para el objeto de Dirección (usando la convención de Medico.ts)
export type DireccionModel = {
    Departamento: number;
    Municipio: number;
    Barrio: number;
    Direccion: string; 
};

// Define la estructura para el objeto de Teléfono (usando la convención de Medico.ts)
export type TelefonoModel = {
    Telefono: number;
    Compania: number | null; // Cambiado a null basado en el frontend RegisterView.tsx
};


/**
 * Tipo base que contiene todos los campos comunes a todos los usuarios 
 * (Médico, Administrador, Recepcionista, Personal de Registro).
 * Corresponde a la clase UsuarioModel del backend.
 */
export type UsuarioModel = {
    // Requeridos (null!)
    Cedula: string;
    PrimerApellido: string;
    Correo: string;
    Contrasenya: string;

    // Con valor predeterminado o nulos (?)
    PrimerNombre: string | null;
    SegundoNombre: string | null;
    SegundoApellido: string | null;
    
    // Tipos primitivos
    Genero: number; // Asumo que 0 es un valor predeterminado si es nulo
    TipoUsuario: number;

    // Manejo de Fechas (DateOnly se convierte a string YYYY-MM-DD)
    FechaNacimiento: string; 

    // Listas
    Telefonos: TelefonoModel[];
    Direcciones: DireccionModel[];
};