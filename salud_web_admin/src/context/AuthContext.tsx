import React, { createContext, useContext, useState, type ReactNode } from 'react';

// Tipos de roles para mapear los IDs
export type UserRole = 'ADMIN' | 'MEDICO' | 'RECEPCIONISTA' | 'REGISTRO' | null;

// 1. Definir el tipo de datos que almacenaremos en el contexto
interface AuthContextType {
    userEmail: string | null;
    userRole: UserRole; // 👈 NUEVO: Almacenaremos el rol
    
    // 2. Modificar la función para recibir ambos datos
    setUserEmailAndRole: (email: string, roleId: number) => void;
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
    const [userEmail, setUserEmailState] = useState<string | null>(null);
    const [userRole, setUserRoleState] = useState<UserRole>(null); // Estado para el rol

    // 3. Función actualizada para guardar Email y Rol
    const setUserEmailAndRole = (email: string, roleId: number) => {
        setUserEmailState(email);
        
        // Mapear el ID a un nombre de rol y guardarlo
        const role = ROLE_MAP[roleId] || null;
        setUserRoleState(role);
    };

    const value = {
        userEmail,
        userRole,
        setUserEmailAndRole,
    };

    return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);
    if (context === undefined) {
        throw new Error('useAuth debe ser usado dentro de un AuthProvider');
    }
    return context;
};