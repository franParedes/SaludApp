// MarcoPrincipal.tsx (CORREGIDO)

import React from 'react';
import { AppBar, Toolbar, IconButton, Typography, Button, Box } from "@mui/material"; // Importamos Box para agrupar elementos
import MenuIcon from "@mui/icons-material/Menu";
import { Outlet, Link } from "react-router-dom"; 
import { UserMenu } from "../features/Dashboard/components/UserMenu"; 

const MarcoPrincipal: React.FC = () => {
    return (
        // Usamos min-h-screen y w-full para el contenedor principal
        <div className="min-h-screen w-full bg-gray-50 flex flex-col p-5"> 
            
            {/* BARRA DE NAVEGACIÓN */}
            <AppBar position="static" sx={{ backgroundColor: "#0088FF", borderRadius: 2 }}>
                <Toolbar className="flex justify-between items-center px-4">
                    
                    {/* 1. SECCIÓN IZQUIERDA: Menú y Título */}
                    <div className="flex items-center space-x-2"> 
                        <IconButton size="large" edge="start" color="inherit" aria-label="menu">
                            <MenuIcon />
                        </IconButton>
                        <Typography 
                            variant="h6" 
                            noWrap // Evita que el texto de SaludApp se desborde
                            component="div"
                            sx={{ fontWeight: "bold" }}
                        >
                            SaludApp
                        </Typography>
                    </div>
                    
                    {/* 2. SECCIÓN DERECHA: Botones de Navegación y Menú de Usuario */}
                    {/* Usamos Box o div con flex para gestionar los botones */}
                    <Box className="flex items-center space-x-4"> 
                        
                        {/* Grupo de Enlaces de Navegación */}
                        <div className="flex space-x-2 sm:space-x-4"> {/* Ajuste el espacio entre enlaces */}
                            
                            <Button component={Link} to="/home" color="inherit">
                                Inicio
                            </Button>
                            
                            <Button component={Link} to="/citas" color="inherit">
                                Citas
                            </Button>
                            
                            <Button component={Link} to="/pacientes" color="inherit">
                                Pacientes
                            </Button>
                            
                            <Button component={Link} to="/historial" color="inherit">
                                Historial
                            </Button>
                        </div>
                        
                        {/* Menú de Usuario */}
                        <UserMenu /> 
                    </Box>
                </Toolbar>
            </AppBar>

            {/* CUERPO DINÁMICO */}
            <main className="flex-1 mt-5"> 
                <Outlet /> 
            </main>

        </div>
    );
};

export default MarcoPrincipal;