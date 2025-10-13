import React, { useState } from 'react';
import { Button, Menu, MenuItem, Typography, Divider } from '@mui/material';
import AccountCircle from '@mui/icons-material/AccountCircle';
import LogoutIcon from '@mui/icons-material/Logout';
import { useAuth } from '../../../context/AuthContext'; // Ajusta la ruta a tu AuthContext
import { useNavigate } from 'react-router-dom';

export const UserMenu: React.FC = () => {
    const navigate = useNavigate();
    
    // 1. Consumir el Contexto para obtener el correo Y el rol
    // NOTA: Asumo que en el AuthContext creaste una función para limpiar la sesión.
    // Si no es así, usaré 'setUserEmailAndRole' con valores nulos/vacíos para limpiar.
    const { userEmail, userRole, setUserEmailAndRole } = useAuth();
    
    // 2. Estado para anclar (abrir/cerrar) el menú flotante
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);

    const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    // 3. Lógica para Cerrar Sesión
    const handleLogout = () => {
        // Cierra el menú
        handleClose(); 
        
        // Limpia el estado del Contexto (Correo: null, Rol: null)
        // Usamos 0 como roleId para limpiar el estado, ya que la función espera un number
        // Si tu AuthContext tiene una función clearAuthData() o similar, úsala en su lugar.
        setUserEmailAndRole("", 0); 
        
        // Opcional: Si usas localStorage para tokens, bórralo aquí
        localStorage.removeItem('authToken'); 

        // Redirige al login
        navigate('/auth/login');
    };

    return (
        <div>
            {/* Botón que actúa como ancla para el menú */}
            <Button
                color="inherit"
                aria-label="Cuenta del usuario"
                aria-controls={open ? 'menu-appbar' : undefined}
                aria-haspopup="true"
                onClick={handleMenu}
                startIcon={<AccountCircle />}
                sx={{ textTransform: 'none' }}
            >
                {/* Muestra el correo o 'Perfil' */}
                {userEmail || 'Perfil'} 
            </Button>
            
            {/* El componente Menu flotante */}
            <Menu
                id="menu-appbar"
                anchorEl={anchorEl}
                anchorOrigin={{
                    vertical: 'bottom',
                    horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                }}
                open={open}
                onClose={handleClose}
            >
                {/* 1. Área del Username/Email (No clickable) */}
                <MenuItem disabled>
                    <Typography variant="body2" color="text.primary" fontWeight="bold">
                        {userEmail}
                    </Typography>
                </MenuItem>
                
                {/* 🚀 NUEVO: Mostramos el Rol */}
                {userRole && (
                    <MenuItem disabled>
                        <Typography variant="caption" color="text.secondary">
                            Rol: {userRole}
                        </Typography>
                    </MenuItem>
                )}
                
                <Divider />

                {/* 2. Opción de Ajustes (ejemplo) */}
                <MenuItem onClick={handleClose}>
                    Ajustes de Cuenta
                </MenuItem>
                
                {/* 3. Opción de Cerrar Sesión */}
                <MenuItem onClick={handleLogout}>
                    <LogoutIcon sx={{ mr: 1 }} fontSize="small" />
                    Cerrar Sesión
                </MenuItem>
            </Menu>
        </div>
    );
};