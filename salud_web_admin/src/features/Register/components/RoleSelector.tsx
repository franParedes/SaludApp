// src/features/Register/components/RoleSelector.tsx (DISEÑO FINAL Y ESTABLE)

import { Button, Grid } from '@mui/material';

// Color primario unificado, siguiendo el ejemplo del azul celeste.
const PRIMARY_COLOR = '#0088FF'; 
const PRIMARY_HOVER = '#0066CC'; // Un tono más oscuro para el hover

// Definiciones de IDs de roles
const ROLES = [
    { id: 2, label: 'Médico' }, 
    { id: 4, label: 'Administrador' }, 
    { id: 3, label: 'Recepcionista' }, 
    { id: 5, label: 'Registro' }, // Etiqueta simplificada
];

interface RoleSelectorProps {
    tipo: number | string;
    setTipo: (id: number) => void;
}

export default function RoleSelector({ tipo, setTipo }: RoleSelectorProps) {
    return (
        <Grid container spacing={1} justifyContent="center" sx={{ mb: 3 }}>
            {ROLES.map((role) => (
                <Grid 
                    key={role.id} 
                    // En mobile (xs: 12), el botón ocupa todo el ancho. En desktop (sm: 3), ocupa 1/4.
                    size={{ xs: 12, sm: 3 }} 
                > 
                    <Button
                        variant={tipo === role.id ? "contained" : "outlined"}
                        onClick={() => setTipo(role.id)}
                        fullWidth
                        sx={{
                            paddingX: 2, 
                            paddingY: 1.5, 
                            fontWeight: tipo === role.id ? "700" : "600",
                            textTransform: "none",
                            fontSize: 13, // AJUSTE FINAL: REDUCIDO A 13PX
                            borderRadius: '50px', // Bordes redondeados de píldora

                            // --- ESTILOS UNIFICADOS (PRIMARY_COLOR) ---
                            // Botón NO seleccionado (Outlined)
                            borderColor: PRIMARY_COLOR,
                            color: PRIMARY_COLOR,
                            
                            // Botón SELECCIONADO (Contained)
                            ...(tipo === role.id && {
                                backgroundColor: PRIMARY_COLOR,
                                color: 'white',
                                borderColor: PRIMARY_COLOR,
                            }),
                            
                            // Hover general
                            '&:hover': {
                                borderColor: PRIMARY_COLOR,
                                backgroundColor: tipo === role.id ? PRIMARY_HOVER : `${PRIMARY_COLOR}10`,
                                color: tipo === role.id ? 'white' : PRIMARY_COLOR,
                            }
                        }}
                    >
                        {role.label}
                    </Button>
                </Grid>
            ))}
        </Grid>
    );
}