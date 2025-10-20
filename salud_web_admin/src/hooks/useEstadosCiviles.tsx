// src/hooks/useEstadosCiviles.ts

import { useState, useEffect } from 'react';
import type { EstadoCivil } from '../types/EstadoCivil'; // Asumiendo esta ruta
import { fetchEstadosCiviles } from '../services/utilitiesServices';


interface UseEstadosCivilesResult {
    estadosCiviles: EstadoCivil[];
    loading: boolean;
    error: string | null;
}

/**
 * Hook para obtener la lista de estados civiles desde la API.
 * @returns Objeto con los estados civiles, estado de carga y error.
 */
export const useEstadosCiviles = (): UseEstadosCivilesResult => {
    const [estadosCiviles, setEstadosCiviles] = useState<EstadoCivil[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadEstadosCiviles = async () => {
            try {
                const data = await fetchEstadosCiviles();
                setEstadosCiviles(data);
                setError(null);
            } catch (err) {
                console.error("Error cargando estados civiles:", err);
                setError("Fallo al cargar la lista de estados civiles.");
            } finally {
                setLoading(false);
            }
        };
        loadEstadosCiviles();
    }, []);

    return { estadosCiviles, loading, error };
};