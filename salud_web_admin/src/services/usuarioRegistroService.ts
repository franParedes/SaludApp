import type { UsuarioRegistro } from '../types/UsuarioRegistro';

// Asume que el endpoint base es similar a los otros, pero para el personal de registro.
const BASE_URL = "http://localhost:5005/api/UsuarioRegistro"; 

export async function createUsuarioRegistro(registroData: UsuarioRegistro): Promise<any> {
    console.log("Enviando payload de UsuarioRegistro:", registroData);
    
    try {
        const res = await fetch(`${BASE_URL}/CrearUsuarioDeRegistro`, { // Usando un endpoint hipotético
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(registroData)
        });

        if (!res.ok) {
            const errorBody = await res.text();
            throw new Error(`Error ${res.status}: ${errorBody || "Error creando usuario de registro"}`);
        }

        const data = await res.json();
        return data;
    } catch (error) {
        console.error("Fallo en el servicio de creación de usuario de registro:", error);
        throw error;
    }
}