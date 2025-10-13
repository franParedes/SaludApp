// src/hooks/useLogin.ts

import { useState } from 'react';
import { verificarCredenciales } from '../services/authService'; // Importar el servicio

interface AuthResult {
    data: any; 
    error: string | null;
    loading: boolean;
    login: (correo: string, contrasenya: string) => Promise<boolean>;
}

export function useLogin(): AuthResult {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [data, setData] = useState<any>(null);

    const login = async (correo: string, contrasenya: string): Promise<boolean> => {
        setLoading(true);
        setError(null);
        setData(null);

        try {
            // Llama al servicio, separando la lógica de fetch
            const result = await verificarCredenciales(correo, contrasenya);
            
            setData(result);
            setLoading(false);
            return true;

        } catch (err: any) {
            // Captura los errores lanzados por el servicio
            setError(err.message || 'Error desconocido al iniciar sesión.');
            setLoading(false);
            return false;
        }
    };

    return { data, error, loading, login };
}