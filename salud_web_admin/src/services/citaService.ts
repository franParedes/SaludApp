// src/services/CitasService.ts
import { type CitaPendiente, type CitaMedicaModel, type CitaLaboratorioModel } from '../types/CitaTypes';

const API_BASE_URL = 'https://localhost:7239/api/Citas'; // Base URL para las llamadas

// ----------------------------------------------------------------------------------
// Fetch para GET /api/Citas/ObtenerListaDeCitasPendientes
// ----------------------------------------------------------------------------------
export const obtenerCitasPendientes = async (): Promise<CitaPendiente[]> => {
    const url = `${API_BASE_URL}/ObtenerListaDeCitasPendientes`;
    
    try {
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                // Agrega headers de autenticación si es necesario (ej: Authorization)
            },
        });

        if (!response.ok) {
            // Lanza un error si la respuesta HTTP no es exitosa (ej: 404, 500)
            throw new Error(`Error al obtener citas: ${response.statusText}`);
        }

        // Parseamos la respuesta JSON al tipo CitaPendiente[]
        const data: CitaPendiente[] = await response.json();
        return data;

    } catch (error) {
        // Propagamos el error para que el hook lo maneje
        console.error("Error en obtenerCitasPendientes:", error);
        throw error;
    }
};

export const aprobarCita = async (idCita: number, fechaCita: string): Promise<void> => {
    const encodedFechaCita = encodeURIComponent(fechaCita);
    const url = `${API_BASE_URL}/AprobarCita/${idCita}/${encodedFechaCita}`; 
    
    try {
        const response = await fetch(url, {
            method: 'PUT', 
        });

        if (!response.ok) {
            const errorBody = await response.text();
            throw new Error(`Fallo la aprobación de la cita ${idCita}. Estado: ${response.status} - ${errorBody}`);
        }
        
    } catch (error) {
        console.error("Error en aprobarCita:", error);
        throw error;
    }
};
export const rechazarCita = async (idCita: number, motivoRechazo: string): Promise<void> => {
    // 1. Codificamos el motivo de rechazo ya que va en la URL.
    const encodedMotivoRechazo = encodeURIComponent(motivoRechazo);
    // 2. Construimos la URL con los parámetros path.
    const url = `${API_BASE_URL}/RechazarCita/${idCita}/${encodedMotivoRechazo}`; 
    
    try {
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            // Enviamos un body vacío para cumplir con PUT
            body: JSON.stringify({}) 
        });

        if (!response.ok) {
            const errorBody = await response.text();
            throw new Error(`Fallo el rechazo de la cita ${idCita}. Estado: ${response.status} - ${errorBody}`);
        }
    } catch (error) {
        console.error("Error en rechazarCita:", error);
        throw error;
    }
};
export const agendarCitaMedica = async (citaData: CitaMedicaModel): Promise<void> => {
    const url = `${API_BASE_URL}/AgendarCitaMedica`;
    
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                // Agregar token de autorización si es necesario
            },
            // El cuerpo es el modelo de datos serializado
            body: JSON.stringify(citaData),
        });

        if (!response.ok) {
            // Intenta leer el cuerpo del error si está disponible
            const errorBody = await response.text();
            throw new Error(`Error al agendar cita: ${response.status} - ${errorBody}`);
        }
        
        // Si el estado es 200 (OK), simplemente retornamos void
        return; 
    } catch (error) {
        console.error("Error en agendarCitaMedica:", error);
        throw error;
    }
};

export const agendarCitaLaboratorio = async (citaData: CitaLaboratorioModel): Promise<void> => {
    // Usamos el nuevo endpoint que definiste en el backend
    const url = `${API_BASE_URL}/AgendarCitaLaboratorio`; 
    
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                // Agregar token de autorización si es necesario
            },
            // El cuerpo es el modelo de datos serializado
            body: JSON.stringify(citaData),
        });

        if (!response.ok) {
            // Intenta leer el cuerpo del error si está disponible
            const errorBody = await response.text();
            throw new Error(`Error al agendar cita de laboratorio: ${response.status} - ${errorBody}`);
        }
        
        return; 
    } catch (error) {
        console.error("Error en agendarCitaLaboratorio:", error);
        throw error;
    }
};