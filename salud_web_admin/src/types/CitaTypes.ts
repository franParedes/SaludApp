// src/types/CitaTypes.ts

// Usamos 'type' para definir la estructura de la respuesta del backend
export type CitaPendiente = {
    // Nota: Usamos '?' para propiedades que son opcionales o pueden ser null (como el 'string?')
    IdCita: number;
    IdPendiente: number;
    CentroMedico?: string;
    TipoDeCita?: string; // Corresponde al TipoDeCita del modelo C#
    // Podrías añadir otros campos que necesites, como fecha, paciente, etc., si los devuelve la API
};

// Puedes seguir usando 'type' para el estado de la cita si lo necesitas en otros archivos
export type EstadoCita = 'Pendiente' | 'Aprobada' | 'Rechazada' | 'Finalizada' | 'Cancelada';


export type TipoCita = {
    IdTipoCita: number;
    Tipo: string;
};
// En tu archivo de tipos (ej: ../../../types/CitaTypes.ts)
// Asegúrate de definir estos tipos, ya que el código modificado los usará.

export interface ArchivoBaseModel {
    nombreArchivo: string;
    tipoArchivo: string;
    tipoMime: string;
    bytesArchivo: string;
}

export interface CitaBaseModel {
    PacienteId: number;
    FechaSolicitud: string;
    Lugar: number;
    FechaCita: string | null;
    MotivoCita: string;
    TipoCita: number;
    Adjuntos: ArchivoBaseModel[] | null;
}

export interface CitaMedicaModel extends CitaBaseModel {
    Especialidad: number;
}

export interface CitaLaboratorioModel extends CitaBaseModel {
    ExamenesRealizar: string[];
}

// 🚀 Tipo de Modelo Unificado (Permite todos los campos)
export type CitaModelUnificada = CitaMedicaModel & CitaLaboratorioModel;

// 🚀 Constantes para IDs de Tipo de Cita (Asume que los has configurado en backend/DB)
// Nota: Deberías obtener estos de los datos cargados por useTiposCita si son dinámicos.
const ID_CITA_MEDICA = 1; 
const ID_CITA_LABORATORIO = 2;