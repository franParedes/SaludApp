import { useState } from "react";
import type { Recepcionista } from "../types/Recepcionista";
import { createRecepcionista } from "../services/recepcionistaService";

export function useCrearRecepcionista() {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [respuesta, setRespuesta] = useState<any>(null);

    /**
     * Función que inicia el proceso de creación del Recepcionista.
     * @param recepcionistaData El payload del Recepcionista.
     * @returns Promise<boolean> True si se creó con éxito, False si hubo un error.
     */
    const crearRecepcionista = async (recepcionistaData: Recepcionista): Promise<boolean> => {
        setLoading(true);
        setError(null);
        setRespuesta(null);

        try {
            const data = await createRecepcionista(recepcionistaData);
            setRespuesta(data);
            return true; // Éxito
        } catch (err: any) {
            // Captura el error lanzado por el servicio
            setError(err.message || "Error desconocido en la creación del recepcionista");
            console.error("Hook Error:", err);
            return false; // Falla
        } finally {
            setLoading(false);
        }
    };

    return { crearRecepcionista, loading, error, respuesta };
}