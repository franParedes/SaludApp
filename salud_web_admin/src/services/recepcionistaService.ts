import type { Recepcionista } from '../types/Recepcionista';

const BASE_URL = "https://localhost:7239/api/Recepcionsitas"; 

export async function createRecepcionista(recepcionistaData: Recepcionista): Promise<any> {
    console.log("Enviando payload de Recepcionista:", recepcionistaData);
    
    try {
        const res = await fetch(`${BASE_URL}/CrearRecepcionista`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(recepcionistaData)
        });

        if (!res.ok) {
            const errorBody = await res.text();
            // Lanza un error para ser capturado por el hook
            throw new Error(`Error ${res.status}: ${errorBody || "Error creando recepcionista"}`);
        }

        const data = await res.json();
        return data; 
    } catch (error) {
        console.error("Fallo en el servicio de creación de recepcionista:", error);
        throw error;
    }
}