// src/services/authService.ts

const API_BASE_URL = 'http://localhost:5005/api';
const LOGIN_ENDPOINT = '/Auth/VerificarCredenciales';

export async function verificarCredenciales(correo: string, contrasenya: string): Promise<any> {
    
    // Codificar los parámetros de la URL por seguridad
    const encodedCorreo = encodeURIComponent(correo);
    const encodedPassword = encodeURIComponent(contrasenya);

    const url = `${API_BASE_URL}${LOGIN_ENDPOINT}/${encodedCorreo}/${encodedPassword}`;

    try {
        const response = await fetch(url, {
            method: 'GET',
        });

        // 1. Manejo de errores HTTP no 2xx (aunque la API siempre devuelve 200, mantenemos esto por robustez)
        if (!response.ok) {
            const status = response.status;
            let errorMessage = 'Error al verificar credenciales.';

            if (status === 401 || status === 403) {
                errorMessage = 'Credenciales inválidas. Por favor, verifica tu correo y contraseña.';
            } else {
                const errorBody = await response.text();
                errorMessage = `Error del servidor (${status}): ${errorBody || 'Inténtalo más tarde.'}`;
            }
            throw new Error(errorMessage);
        }

        // 2. Procesar el cuerpo JSON (response.ok es true, usualmente 200 OK)
        const data = await response.json(); 

        // 3. VALIDACIÓN CLAVE: Lógica de negocio específica del API
        // Si la API devuelve un 200 OK pero IdUsuario es 0, es un fallo de autenticación.
        if (data.IdUsuario === 0) {
            // Lanzamos un error que será capturado por el hook y mostrado en el Snackbar.
            throw new Error('Credenciales inválidas. Por favor, verifica tu correo y contraseña.');
        }

        // 4. Éxito: El IdUsuario es un valor válido (> 0)
        return data; 
        
    } catch (error) {
        // Relanzar cualquier error (tanto de fetch como el error de validación de IdUsuario: 0)
        throw error;
    }
}