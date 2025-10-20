// src/hooks/useTiposCita.ts

import { useEffect, useState } from "react";
import type { TipoCita } from "../types/CitaTypes"; 
import { fetchTiposCita } from "../services/utilitiesServices";

export default function useTiposCita() {
    const [tiposCita, setTiposCita] = useState<TipoCita[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const loadTiposCita = async () => {
            try {
                const data = await fetchTiposCita();
                setTiposCita(data);
            } catch (err) {
                console.error("Fallo al cargar los tipos de cita:", err);
            } finally {
                setLoading(false);
            }
        };

        loadTiposCita();
    }, []);

    return { tiposCita, loading };
}