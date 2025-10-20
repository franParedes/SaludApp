// src/hooks/useEscolaridades.ts

import { useState, useEffect } from 'react';
import type { Escolaridad } from '../types/Escolaridad'; // Asumiendo esta ruta
import { fetchEscolaridades } from './utilitiesServices';

interface UseEscolaridadesResult {
    escolaridades: Escolaridad[];
    loading: boolean;
    error: string | null;
}

/**
 * Hook para obtener la lista de niveles de escolaridad desde la API.
 * @returns Objeto con las escolaridades, estado de carga y error.
 */
export const useEscolaridades = (): UseEscolaridadesResult => {
    const [escolaridades, setEscolaridades] = useState<Escolaridad[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadEscolaridades = async () => {
            try {
                const data = await fetchEscolaridades();
                setEscolaridades(data);
                setError(null);
            } catch (err) {
                console.error("Error cargando escolaridades:", err);
                setError("Fallo al cargar la lista de niveles de escolaridad.");
            } finally {
                setLoading(false);
            }
        };
        loadEscolaridades();
    }, []);

    return { escolaridades, loading, error };
};