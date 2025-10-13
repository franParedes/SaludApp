import { useState } from "react";
import type { Administrador } from "../types/Administrador";
import { createAdministrador } from "../services/adminService";

export function useCrearAdministrador() {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [respuesta, setRespuesta] = useState<any>(null);

    const crearAdministrador = async (adminData: Administrador) => {
        setLoading(true);
        setError(null);
        setRespuesta(null);

        try {
            const data = await createAdministrador(adminData);
            setRespuesta(data);
            return data; 
        } catch (err: any) {
            setError(err.message || "Error desconocido en la creación del administrador");
            throw err; 
        } finally {
            setLoading(false);
        }
    };

    return { crearAdministrador, loading, error, respuesta };
}