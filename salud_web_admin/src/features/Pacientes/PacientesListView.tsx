// src/features/Pacientes/PacientesListView.tsx (NUEVO ARCHIVO)

import React from 'react';
import { useNavigate } from 'react-router-dom'; // 🚀 Nuevo import
import { Typography, Box, Paper, Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import PersonAddIcon from '@mui/icons-material/PersonAdd';
import { type PacienteModel } from '../../types/PacienteTypes'; // Importamos el tipo

// Datos de prueba para simular una lista de pacientes
const mockPacientes: Partial<PacienteModel>[] = [
    { Cedula: '001-010190-0001X', PrimerNombre: 'Ana', PrimerApellido: 'Gómez', Correo: 'ana@mail.com', Edad: 35 },
    { Cedula: '002-150585-0002Y', PrimerNombre: 'Carlos', PrimerApellido: 'Pérez', Correo: 'carlos@mail.com', Edad: 40 },
    { Cedula: '003-201200-0003Z', PrimerNombre: 'Luisa', PrimerApellido: 'Martínez', Correo: 'luisa@mail.com', Edad: 23 },
];

const PacientesListView: React.FC = () => {
    // Aquí podrías usar un hook como usePacientes para obtener datos reales
    
    const navigate = useNavigate(); // 🚀 Hook de navegación

    const handleAgregarPaciente = () => {
        // Redirigir al formulario de creación
        navigate('/pacientes/nuevo'); // 🚀 Nueva ruta
    };

    return (
        <Box className="p-4">
            <Typography variant="h4" component="h1" gutterBottom color="primary" sx={{ fontWeight: 'bold' }}>
                Gestión de Pacientes
            </Typography>

            <Box display="flex" justifyContent="flex-end" mb={3}>
                <Button 
                    variant="contained" 
                    color="primary" 
                    startIcon={<PersonAddIcon />}
                    onClick={handleAgregarPaciente}
                >
                    Agregar Paciente
                </Button>
            </Box>

            <Paper elevation={2}>
                <TableContainer>
                    <Table aria-label="lista de pacientes">
                        <TableHead>
                            <TableRow sx={{ backgroundColor: '#f0f0f0' }}>
                                <TableCell sx={{ fontWeight: 'bold' }}>Cédula</TableCell>
                                <TableCell sx={{ fontWeight: 'bold' }}>Nombre Completo</TableCell>
                                <TableCell sx={{ fontWeight: 'bold' }}>Correo</TableCell>
                                <TableCell sx={{ fontWeight: 'bold' }}>Edad</TableCell>
                                <TableCell sx={{ fontWeight: 'bold' }}>Acciones</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {mockPacientes.map((paciente, index) => (
                                <TableRow key={index} hover>
                                    <TableCell>{paciente.Cedula}</TableCell>
                                    <TableCell>{`${paciente.PrimerNombre} ${paciente.PrimerApellido}`}</TableCell>
                                    <TableCell>{paciente.Correo}</TableCell>
                                    <TableCell>{paciente.Edad}</TableCell>
                                    <TableCell>
                                        <Button size="small" variant="outlined">Ver/Editar</Button>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Paper>
        </Box>
    );
};

export default PacientesListView;