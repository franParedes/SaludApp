// src/components/PublicRouteGuard.tsx

import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../context/AuthContext'; // Asegúrate que esta ruta es correcta

interface PublicRouteGuardProps {
    redirectPath?: string;
}

const PublicRouteGuard: React.FC<PublicRouteGuardProps> = ({ redirectPath = '/home' }) => {
    // 1. Obtener el estado de autenticación
    const { userEmail } = useAuth();
    
    // 2. Si el usuario está logeado (userEmail no es null), redirigir
    if (userEmail) {
        return <Navigate to={redirectPath} replace />;
    }

    // 3. Si el usuario NO está logeado, permitir que las rutas anidadas se rendericen (Login/Register)
    // El componente <Outlet /> se encarga de renderizar la ruta hija.
    return <Outlet />;
};

export default PublicRouteGuard;