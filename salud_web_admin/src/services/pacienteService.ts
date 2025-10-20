// src/services/PacientesService.ts (NUEVO ARCHIVO)

import { type PacienteModel } from '../types/PacienteTypes';

const API_BASE_URL = 'https://localhost:7239'; // ⚠️ Ajusta esta URL si es diferente

/**
 * Función para crear un nuevo paciente enviando el modelo completo.
 * @param pacienteData El objeto PacienteModel a enviar.
 * @returns true si la creación fue exitosa.
 */
export const crearPaciente = async (pacienteData: PacienteModel): Promise<boolean> => {
    try {
        const response = await fetch(`${API_BASE_URL}/api/Pacientes/CrearPaciente`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                // Si requieres token de autenticación, agrégalo aquí
            },
            body: JSON.stringify(pacienteData),
        });

        if (!response.ok) {
            // Manejo de errores de respuesta HTTP
            const errorText = await response.text();
            console.error('Error al crear paciente (HTTP):', response.status, errorText);
            throw new Error(`Fallo al crear paciente. Código: ${response.status}`);
        }

        // Si el backend devuelve 200 OK y no hay contenido, simplemente retornamos true
        return true; 
    } catch (error) {
        console.error('Error en el servicio crearPaciente:', error);
        throw error;
    }
};