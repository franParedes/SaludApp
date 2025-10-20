// src/hooks/useReligiones.ts

import { useState, useEffect } from 'react';
import type { Religion } from '../types/Religion'; // Asumiendo esta ruta
import { fetchReligiones } from '../services/utilitiesServices';

interface UseReligionesResult {
    religiones: Religion[];
    loading: boolean;
    error: string | null;
}

/**
 * Hook para obtener la lista de religiones desde la API.
 * @returns Objeto con las religiones, estado de carga y error.
 */
export const useReligiones = (): UseReligionesResult => {
    const [religiones, setReligiones] = useState<Religion[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadReligiones = async () => {
            try {
                const data = await fetchReligiones();
                setReligiones(data);
                setError(null);
            } catch (err) {
                console.error("Error cargando religiones:", err);
                setError("Fallo al cargar la lista de religiones.");
            } finally {
                setLoading(false);
            }
        };
        loadReligiones();
    }, []);

    return { religiones, loading, error };
};