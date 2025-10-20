import React, { useState } from 'react'; 
import { Typography, Box, Paper, Button, CircularProgress, Alert } from '@mui/material';
// 💡 Asumo que el hook useCitas proporciona el rechazarCitaHandler
import { useCitas } from '../../hooks/useCitas'; 
import CitasList from './components/CitasList'; 
import ModalAgendarCita from './components/ModalAgendarCita'; 

const CitasPage: React.FC = () => {
  // 🚀 CORRECCIÓN: Desestructuramos el rechazarCitaHandler directamente desde useCitas
  const { citas, loading, error, aprobarCitaHandler, rechazarCitaHandler, refetchCitas } = useCitas();
  
  // Estado para controlar la apertura del modal
  const [isModalOpen, setIsModalOpen] = useState(false);


  return (
    <Box className="p-4">
      <Typography variant="h4" component="h1" gutterBottom color="primary" sx={{ fontWeight: 'bold' }}>
        Gestión de Citas Pendientes
      </Typography>

      {/* Contenedor de botones: UNIFICADO EN UN SOLO BOTÓN */}
      <Box display="flex" justifyContent="flex-end" mb={3}>
        <Button 
            variant="contained" 
            color="primary" 
            onClick={() => setIsModalOpen(true)}
        >
          Solicitar Nueva Cita
        </Button>
      </Box>

      {/* Panel principal de la lista de citas */}
      <Paper elevation={2} className="p-4">
        {loading && <Box display="flex" justifyContent="center"><CircularProgress /></Box>}
        {error && <Alert severity="error">{error}</Alert>}
        
        {!loading && !error && (
            <CitasList 
                citas={citas} 
                // 🚀 Pasamos el handler real del hook
                aprobarCitaHandler={aprobarCitaHandler}
                rechazarCitaHandler={rechazarCitaHandler}
            />
        )}
      </Paper>

      {/* Usamos el componente ModalAgendarCita unificado */}
      <ModalAgendarCita 
          open={isModalOpen}
          onClose={() => setIsModalOpen(false)}
          onSuccess={() => {
              setIsModalOpen(false);
              refetchCitas(); // Refrescar la lista de citas pendientes después de un agendamiento exitoso
          }}
      />
    </Box>
  );
};

export default CitasPage;