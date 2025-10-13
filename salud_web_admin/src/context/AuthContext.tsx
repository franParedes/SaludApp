import React, { createContext, useContext, useState, type ReactNode, useEffect } from 'react';

export type UserRole = 'ADMIN' | 'MEDICO' | 'RECEPCIONISTA' | 'REGISTRO' | null;

// Claves de localStorage
const EMAIL_KEY = 'userEmail';
const ROLE_KEY = 'userRole';

// 1. Definimos la interfaz del Contexto
interface AuthContextType {
    userEmail: string | null;
    userRole: UserRole;
    // Función para iniciar sesión (recibe ID del rol)
    loginUser: (email: string, roleId: number) => void; 
    // Función para cerrar sesión
    logoutUser: () => void; 
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

// Mapeo de IDs de la API a nombres de roles legibles
const ROLE_MAP: Record<number, UserRole> = {
    2: 'MEDICO',
    4: 'ADMIN',
    3: 'RECEPCIONISTA',
    5: 'REGISTRO',
};

export const AuthProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
    // 2. Inicializamos el estado leyendo directamente de localStorage
    const [userEmail, setUserEmailState] = useState<string | null>(
        localStorage.getItem(EMAIL_KEY) || null
    );
    const [userRole, setUserRoleState] = useState<UserRole>(
        (localStorage.getItem(ROLE_KEY) as UserRole) || null
    ); 

    // 3. Función de Login/Persistencia
    const loginUser = (email: string, roleId: number) => {
        const role = ROLE_MAP[roleId] || null;
        
        // A) Actualizar estado de React
        setUserEmailState(email);
        setUserRoleState(role);
        
        // B) Persistir en localStorage
        localStorage.setItem(EMAIL_KEY, email);
        if (role) {
            localStorage.setItem(ROLE_KEY, role);
        } else {
            localStorage.removeItem(ROLE_KEY);
        }
    };

    // 4. Función de Logout/Limpieza
    const logoutUser = () => {
        // A) Limpiar estado de React
        setUserEmailState(null);
        setUserRoleState(null);
        
        // B) Limpiar localStorage
        localStorage.removeItem(EMAIL_KEY);
        localStorage.removeItem(ROLE_KEY);
        localStorage.removeItem('authToken'); // Buena práctica si existe un token
    };

    const value = {
        userEmail,
        userRole,
        loginUser, // Renombrada de setUserEmailAndRole a loginUser
        logoutUser,
    };

    return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

// 5. Hook para consumir el contexto (sin cambios funcionales)
export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);
    if (context === undefined) {
        throw new Error('useAuth debe ser usado dentro de un AuthProvider');
    }
    return context;
};