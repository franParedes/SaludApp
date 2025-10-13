// src/services/medicoService.ts

import type { Medico } from '../types/Medico';

const BASE_URL = "http://localhost:5005/api/Medicos";

export async function createMedico(medicoData: Medico): Promise<any> {
    console.log(medicoData)
    try {
        const res = await fetch(`${BASE_URL}/CrearMedico`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(medicoData)
        });
        console.log(res)
        if (!res.ok) {
            const errorBody = await res.text();
            throw new Error(`Error ${res.status}: ${errorBody || "Error creando médico"}`);
        }

        const data = await res.json();
        return data;
    } catch (error) {
        console.error("Fallo en el servicio de creación de médico:", error);
        throw error;
    }
}