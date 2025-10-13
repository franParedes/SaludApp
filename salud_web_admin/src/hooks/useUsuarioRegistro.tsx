import { useState } from "react";
import type { UsuarioRegistro } from "../types/UsuarioRegistro";
import { createUsuarioRegistro } from "../services/usuarioRegistroService";

export function useCrearUsuarioRegistro() {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [respuesta, setRespuesta] = useState<any>(null);

    const crearUsuarioRegistro = async (registroData: UsuarioRegistro) => {
        setLoading(true);
        setError(null);
        setRespuesta(null);

        try {
            const data = await createUsuarioRegistro(registroData);
            setRespuesta(data);
            return data; 
        } catch (err: any) {
            setError(err.message || "Error desconocido en la creación del usuario de registro");
            throw err; 
        } finally {
            setLoading(false);
        }
    };

    return { crearUsuarioRegistro, loading, error, respuesta };
}