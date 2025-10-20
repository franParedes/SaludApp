// src/components/CitasList.tsx

import React from 'react';
// Importamos Grid, Box, etc.
import { Box, Typography, Button, Alert, Paper, Grid } from '@mui/material'; 
import { type CitaPendiente } from '../../../types/CitaTypes'; 
import dayjs from 'dayjs'; 

// Definición de las props que el componente recibirá desde la página (CitasPage)
interface CitasListProps {
  citas: CitaPendiente[];
  aprobarCitaHandler: (idCita: number, fechaCita: string) => Promise<void>;
  rechazarCitaHandler: (idCita: number, motivoRechazo: string) => Promise<void>;
}

const CitasList: React.FC<CitasListProps> = ({ 
    citas, 
    aprobarCitaHandler,
    rechazarCitaHandler
}) => {
  
  if (citas.length === 0) {
    return <Alert severity="info">No hay citas pendientes actualmente.</Alert>;
  }

  // Lógica de aprobación (Correcta: No usa FechaSugerida del modelo)
  const handleApproveClick = (idCita: number) => {
    
    const initialDate = dayjs().format('YYYY-MM-DDTHH:mm:ss');
        
    const fechaAprobacion = prompt(
        `Ingrese la fecha y hora de la cita para la Cita #${idCita} (Formato ISO: YYYY-MM-DDTHH:mm:ss):`, 
        initialDate
    );
    
    if (fechaAprobacion) {
        if (fechaAprobacion.trim() !== '' && dayjs(fechaAprobacion).isValid()) {
            aprobarCitaHandler(idCita, fechaAprobacion);
        } else {
            alert("Formato de fecha y hora inválido o campo vacío. Use YYYY-MM-DDTHH:mm:ss.");
        }
    } else {
        alert("Aprobación cancelada.");
    }
  }

  const handleRejectClick = (idCita: number) => {
    const motivo = "Agenda completa"; 
    rechazarCitaHandler(idCita, motivo);
  }

  return (
    <Box>
      <Typography variant="h6" mb={2} sx={{ fontWeight: '600' }}>
        Lista de Solicitudes ({citas.length})
      </Typography>
      
      {citas.map((cita) => (
        <Paper 
            key={cita.IdCita} 
            elevation={2} 
            sx={{ p: 2, mb: 2 }}
        >
            {/* 🚀 Grid container para la fila */}
            <Grid container spacing={2} alignItems="center">
                
                {/* COLUMNA 1: Detalles */}
                {/* 🚀 Usando 'size' en lugar de 'xs/sm' */}
                <Grid size={{ xs: 12, sm: 8 }}> 
                    <Box>
                        <Typography variant="subtitle1" sx={{ fontWeight: 'bold' }}>
                            Cita # {cita.IdCita} | Solicitud # {cita.IdPendiente}
                        </Typography>
                        <Typography variant="body2" color="textSecondary" sx={{ mt: 0.5 }}>
                            Tipo: {cita.TipoDeCita ?? 'General'} | Centro: {cita.CentroMedico ?? 'N/A'}
                        </Typography>
                    </Box>
                </Grid>

                {/* COLUMNA 2: Acciones */}
                {/* 🚀 Usando 'size' en lugar de 'xs/sm' */}
                <Grid size={{ xs: 12, sm: 4 }}>
                    <Box sx={{ 
                        display: 'flex', 
                        flexDirection: 'row', 
                        gap: 1, 
                        // Alineación en pantallas pequeñas: justifica el contenido al final
                        justifyContent: { xs: 'flex-start', sm: 'flex-end' } 
                    }}>
                        <Button 
                            size="small" 
                            color="success" 
                            variant="contained"
                            onClick={() => handleApproveClick(cita.IdCita)} 
                        >
                            APROBAR
                        </Button>
                        <Button 
                            size="small" 
                            color="error"
                            variant="outlined"
                            onClick={() => handleRejectClick(cita.IdCita)}
                        >
                            RECHAZAR
                        </Button>
                        <Button size="small" color="info">
                            DETALLE
                        </Button>
                    </Box>
                </Grid>
            </Grid>
        </Paper>
      ))}
    </Box>
  );
};

export default CitasList;