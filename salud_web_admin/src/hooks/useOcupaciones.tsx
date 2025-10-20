// src/hooks/useOcupaciones.ts

import { useState, useEffect } from 'react';
import type { Ocupacion } from '../types/Ocupacion'; // Asumiendo esta ruta
import { fetchOcupaciones } from '../services/utilitiesServices';

interface UseOcupacionesResult {
    ocupaciones: Ocupacion[];
    loading: boolean;
    error: string | null;
}

/**
 * Hook para obtener la lista de ocupaciones de pacientes desde la API.
 * @returns Objeto con las ocupaciones, estado de carga y error.
 */
export const useOcupaciones = (): UseOcupacionesResult => {
    const [ocupaciones, setOcupaciones] = useState<Ocupacion[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadOcupaciones = async () => {
            try {
                const data = await fetchOcupaciones();
                // Formatear si es necesario, pero basado en el modelo solo mapeamos
                setOcupaciones(data);
                setError(null);
            } catch (err) {
                console.error("Error cargando ocupaciones:", err);
                setError("Fallo al cargar la lista de ocupaciones.");
            } finally {
                setLoading(false);
            }
        };
        loadOcupaciones();
    }, []);

    return { ocupaciones, loading, error };
};