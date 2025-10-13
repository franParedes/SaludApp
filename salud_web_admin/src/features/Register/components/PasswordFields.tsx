import { TextField, Grid } from '@mui/material';
import React, { useState, useEffect } from 'react';

interface PasswordFieldsProps {
    setPasswordData: (data: { contrasenya: string, confirmarContrasenya: string }) => void;
}

export default function PasswordFields({ setPasswordData }: PasswordFieldsProps) {
    const [contrasenya, setContrasenya] = useState('');
    const [confirmarContrasenya, setConfirmarContrasenya] = useState('');

    useEffect(() => {
        setPasswordData({ contrasenya, confirmarContrasenya });
    }, [contrasenya, confirmarContrasenya, setPasswordData]);

    // Simple validación visual para la confirmación
    const errorConfirmacion = confirmarContrasenya !== contrasenya && confirmarContrasenya.length > 0;
    
    return (
        <Grid container spacing={2} sx={{ mt: 3, mb: 3 }}>
            <Grid size={{ xs: 12 }}>
                <h3>Credenciales de Acceso</h3>
            </Grid>
            
            <Grid size={{ xs: 12, sm: 6 }}>
                <TextField
                    required
                    label="Contraseña"
                    fullWidth
                    type="password"
                    value={contrasenya}
                    onChange={(e) => setContrasenya(e.target.value)}
                />
            </Grid>
            
            <Grid size={{ xs: 12, sm: 6 }}>
                <TextField
                    required
                    label="Confirmar Contraseña"
                    fullWidth
                    type="password"
                    value={confirmarContrasenya}
                    onChange={(e) => setConfirmarContrasenya(e.target.value)}
                    error={errorConfirmacion}
                    helperText={errorConfirmacion ? "Las contraseñas no coinciden." : ""}
                />
            </Grid>
        </Grid>
    );
}