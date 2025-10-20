// src/hooks/useCitas.ts

import { useState, useEffect, useCallback } from 'react';
// 🚀 Importamos la nueva función del servicio
import { obtenerCitasPendientes, aprobarCita, rechazarCita } from '../services/citaService'; 
import { type CitaPendiente } from '../types/CitaTypes';

// Definición de la interfaz de resultado del hook
interface UseCitasResult {
    citas: CitaPendiente[];
    loading: boolean;
    error: string | null;
    refetchCitas: () => void;
    aprobarCitaHandler: (idCita: number, fechaCita: string) => Promise<void>;
    rechazarCitaHandler: (idCita: number, motivoRechazo: string) => Promise<void>; // 🚀 NUEVO
}

export const useCitas = (): UseCitasResult => {
    const [citas, setCitas] = useState<CitaPendiente[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    const fetchCitas = useCallback(async () => {
        setLoading(true);
        setError(null);
        try {
            // Usamos la función obtenerCitasPendientes del servicio
            const data = await obtenerCitasPendientes();
            setCitas(data);
        } catch (err) {
            console.error("Error al cargar citas:", err);
            // Si el error es una instancia de Error, usamos su mensaje
            setError(err instanceof Error ? err.message : 'Error al cargar la lista de citas pendientes.');
        } finally {
            setLoading(false);
        }
    }, []);

    useEffect(() => {
        fetchCitas();
    }, [fetchCitas]);

    const refetchCitas = () => fetchCitas();

    const aprobarCitaHandler = useCallback(async (idCita: number, fechaCita: string) => {
        try {
            await aprobarCita(idCita, fechaCita);
            alert(`Cita #${idCita} aprobada exitosamente.`);
            refetchCitas(); // Refrescar la lista después de aprobar
        } catch (err) {
            console.error(`Error al aprobar cita ${idCita}:`, err);
            alert(`Fallo al aprobar la cita #${idCita}.`);
        }
    }, [refetchCitas]);
    
    // --- 🚀 IMPLEMENTACIÓN del HANDLER: Rechazar Cita ---
    const rechazarCitaHandler = useCallback(async (idCita: number, motivoRechazo: string) => {
        try {
            // Llama a la nueva función del servicio
            await rechazarCita(idCita, motivoRechazo);
            
            alert(`Cita #${idCita} rechazada exitosamente por: ${motivoRechazo}.`);
            
            refetchCitas(); // Refrescar la lista para que la cita desaparezca
        } catch (err) {
            console.error(`Error al rechazar cita ${idCita}:`, err);
            alert(`Fallo al rechazar la cita #${idCita}.`);
        }
    }, [refetchCitas]);


    return {
        citas,
        loading,
        error,
        refetchCitas,
        aprobarCitaHandler,
        rechazarCitaHandler, // 🚀 Exportamos el handler
    };
};