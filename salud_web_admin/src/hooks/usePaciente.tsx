// src/hooks/useCrearPaciente.ts (NUEVO ARCHIVO)

import { useState } from 'react';
import { type PacienteModel } from '../types/PacienteTypes';
import { crearPaciente } from '../services/pacienteService';

export const useCrearPaciente = () => {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [success, setSuccess] = useState(false);

    const submitPaciente = async (pacienteData: PacienteModel) => {
        setLoading(true);
        setError(null);
        setSuccess(false);

        try {
            await crearPaciente(pacienteData);
            setSuccess(true);
            return true;
        } catch (err) {
            setError('No se pudo registrar el paciente. Intente de nuevo.');
            console.error(err);
            setSuccess(false);
            return false;
        } finally {
            setLoading(false);
        }
    };

    return { submitPaciente, loading, error, success };
};