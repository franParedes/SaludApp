import { useState } from 'react';
import { verificarCredenciales } from '../services/authService'; // Importar el servicio

// 1. Definimos la interfaz para la respuesta esperada del servicio
interface AuthResponseData {
    TipoUsuario: number; // El ID del rol que necesitamos (2, 4, 3, 5)
    // Agrega aquí cualquier otra propiedad que devuelva el servicio
    IdUsuario: number;
    Verificado: number;
    // ...
}

// 2. Modificamos el tipo de retorno de login: 
//    Ahora devuelve el ID del rol (number) o null si falla.
interface AuthResult {
    data: AuthResponseData | null; // Tipamos el estado 'data'
    error: string | null;
    loading: boolean;
    login: (correo: string, contrasenya: string) => Promise<number | null>; // 👈 CAMBIO CLAVE
}

export function useLogin(): AuthResult {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [data, setData] = useState<AuthResponseData | null>(null); // Usamos el tipo correcto

    const login = async (correo: string, contrasenya: string): Promise<number | null> => {
        setLoading(true);
        setError(null);
        setData(null);

        try {
            // Llama al servicio, la respuesta 'result' contendrá el TipoUsuario
            const result: AuthResponseData = await verificarCredenciales(correo, contrasenya);
            
            setData(result);
            setLoading(false);
            
            // 🚀 CAMBIO CLAVE: Devolver el ID del rol (TipoUsuario)
            return result.TipoUsuario;

        } catch (err: any) {
            // Captura los errores lanzados por el servicio
            setError(err.message || 'Error desconocido al iniciar sesión.');
            setLoading(false);
            
            // Devolver null en caso de fallo de autenticación
            return null;
        }
    };

    return { data, error, loading, login };
}