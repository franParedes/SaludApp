import type { Administrador } from '../types/Administrador'; // Usamos el nuevo type

const BASE_URL = "https://localhost:7239/api/Administradores";

export async function createAdministrador(adminData: Administrador): Promise<any> {
    console.log("Enviando payload de Administrador:", adminData);
    
    try {
        const res = await fetch(`${BASE_URL}/CrearAdministrador`, { 
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(adminData)
        });

        if (!res.ok) {
            const errorBody = await res.text();
            throw new Error(`Error ${res.status}: ${errorBody || "Error creando administrador"}`);
        }

        const data = await res.json();
        return data;
    } catch (error) {
        console.error("Fallo en el servicio de creación de administrador:", error);
        throw error;
    }
}