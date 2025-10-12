// src/hooks/useCrearMedico.ts

import { useState } from "react";
import type { Medico } from "../types/Medico";
import { createMedico } from "../services/medicoService";

export function useCrearMedico() {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [respuesta, setRespuesta] = useState<any>(null);

    const crearMedico = async (medicoData: Medico) => {
        setLoading(true);
        setError(null);
        setRespuesta(null);

        try {
            const data = await createMedico(medicoData);
            setRespuesta(data);
            return data;
        } catch (err: any) {
            setError(err.message || "Error desconocido en la creación");
            throw err; // Propaga el error para manejo adicional en el componente
        } finally {
            setLoading(false);
        }
    };

    return { crearMedico, loading, error, respuesta };
}