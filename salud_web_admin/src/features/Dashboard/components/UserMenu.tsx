// src/features/Dashboard/components/UserMenu.tsx

import React, { useState } from 'react';
import { Button, Menu, MenuItem, Typography, Divider } from '@mui/material';
import AccountCircle from '@mui/icons-material/AccountCircle';
import LogoutIcon from '@mui/icons-material/Logout';
import { useAuth } from '../../../context/AuthContext'; // Ajusta la ruta a tu AuthContext
import { useNavigate } from 'react-router-dom';

export const UserMenu: React.FC = () => {
    const navigate = useNavigate();
    
    // Consumimos userEmail, userRole y la nueva función logoutUser
    const { userEmail, userRole, logoutUser } = useAuth();
    
    // Estado para anclar (abrir/cerrar) el menú flotante
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);

    const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    // Lógica para Cerrar Sesión
    const handleLogout = () => {
        // Cierra el menú
        handleClose(); 
        
        // Llama a la función que limpia el estado de React y el localStorage
        logoutUser(); 
        
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
                
                {/* 2. Mostramos el Rol si existe */}
                {userRole && (
                    <MenuItem disabled>
                        <Typography variant="caption" color="text.secondary">
                            Rol: {userRole}
                        </Typography>
                    </MenuItem>
                )}
                
                <Divider />

                {/* 3. Opción de Ajustes (ejemplo) */}
                <MenuItem onClick={handleClose}>
                    Ajustes de Cuenta
                </MenuItem>
                
                {/* 4. Opción de Cerrar Sesión */}
                <MenuItem onClick={handleLogout}>
                    <LogoutIcon sx={{ mr: 1 }} fontSize="small" />
                    Cerrar Sesión
                </MenuItem>
            </Menu>
        </div>
    );
};