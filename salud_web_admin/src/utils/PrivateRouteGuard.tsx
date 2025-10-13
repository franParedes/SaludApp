import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../context/AuthContext'; // Asegura la ruta a tu contexto

interface PrivateRouteGuardProps {
    redirectPath?: string;
}

const PrivateRouteGuard: React.FC<PrivateRouteGuardProps> = ({ redirectPath = '/auth/login' }) => {
    // Obtenemos el estado de autenticación
    const { userEmail } = useAuth();
    
    // Si NO hay email (no está logeado), redirigimos al login
    if (!userEmail) {
        return <Navigate to={redirectPath} replace />;
    }

    // Si SÍ está logeado, permitimos el acceso a la ruta hija (<Dashboard />)
    return <Outlet />;
};

export default PrivateRouteGuard;