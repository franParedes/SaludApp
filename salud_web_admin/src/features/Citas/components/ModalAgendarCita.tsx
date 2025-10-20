// src/components/citas/ModalAgendarCita.tsx (ADAPTADO A SINTAXIS 'size' DE MUI GRID)

import React, { useState } from 'react';
import { 
    Dialog, DialogTitle, DialogContent, DialogActions, Button, TextField, 
    MenuItem, CircularProgress, Box, Select, FormControl, InputLabel, 
    Typography, Chip, Grid 
} from '@mui/material';
import AttachFileIcon from '@mui/icons-material/AttachFile';
import CloseIcon from '@mui/icons-material/Close';

// ... (Imports de tipos y servicios) ...
import { 
    type CitaMedicaModel, 
    type CitaLaboratorioModel, 
    type CitaModelUnificada, 
    type ArchivoBaseModel 
} from '../../../types/CitaTypes'; 
import { agendarCitaMedica, agendarCitaLaboratorio } from '../../../services/citaService';

import dayjs from 'dayjs';
import { DateTimePicker } from '@mui/x-date-pickers/DateTimePicker';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import useEspecialidades from '../../../hooks/useEspecialidades';
import { useCentrosMedicos } from '../../../hooks/useCentrosMedicos';
import useTiposCita from '../../../hooks/useTiposCita';


// CONSTANTES DE TIPO DE CITA 
const ID_CITA_MEDICA = 1; 
const ID_CITA_LABORATORIO = 2;

// ... (Helper: fileToBase64 y Interface ModalAgendarCitaProps) ...

const fileToBase64 = (file: File): Promise<string> => {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onload = () => {
            const base64String = reader.result as string;
            resolve(base64String.split(',')[1]); 
        };
        reader.onerror = error => reject(error);
        reader.readAsDataURL(file);
    });
};

interface ModalAgendarCitaProps {
    open: boolean;
    onClose: () => void;
    onSuccess: () => void;
}

const ModalAgendarCita: React.FC<ModalAgendarCitaProps> = ({ open, onClose, onSuccess }) => {
  
    // ... (Hooks de utilidades y estado) ...
    const { especialidades, loading: loadingEspecialidades } = useEspecialidades();
    const { centros, loading: loadingCentros } = useCentrosMedicos();
    const { tiposCita, loading: loadingTiposCita } = useTiposCita();
    const isUtilitiesLoading = loadingEspecialidades || loadingCentros || loadingTiposCita;

    const [formData, setFormData] = useState<Partial<CitaModelUnificada>>({
        PacienteId: 1, 
        FechaSolicitud: dayjs().toISOString(),
        Lugar: 0, 
        MotivoCita: '',
        TipoCita: 0, 
        Especialidad: 0, 
        ExamenesRealizar: [], 
    });
    const [loading, setLoading] = useState(false); 
    const [fechaCitaSeleccionada, setFechaCitaSeleccionada] = useState<dayjs.Dayjs | null>(null);
    const [selectedFiles, setSelectedFiles] = useState<File[]>([]);
    
    const isCitaMedica = formData.TipoCita === ID_CITA_MEDICA;
    const isCitaLaboratorio = formData.TipoCita === ID_CITA_LABORATORIO;

    // ... (Funciones handleChange, handleSelectChange, handleFileChange, handleRemoveFile, handleExamenesChange) ...
    
    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData(prev => ({ ...prev, [name]: value }));
    };

    const handleSelectChange = (name: keyof CitaModelUnificada, value: number | string | string[]) => {
        setFormData(prev => ({ ...prev, [name]: value }));
    };

    const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.files) {
            const newFiles = Array.from(event.target.files);
            setSelectedFiles(prev => [...prev, ...newFiles]);
        }
    };

    const handleRemoveFile = (fileName: string) => {
        setSelectedFiles(prev => prev.filter(file => file.name !== fileName));
    };
    
    const handleExamenesChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const text = e.target.value;
        const examenesArray = text.split(',').map(s => s.trim()).filter(s => s.length > 0);
        setFormData(prev => ({ ...prev, ExamenesRealizar: examenesArray }));
    };

    const handleSubmit = async () => {
        // Validación Común
        if (!formData.Lugar || !formData.TipoCita || !formData.MotivoCita) {
            alert("Por favor, complete todos los campos obligatorios.");
            return;
        }
        
        // Validación Específica
        if (isCitaMedica && !formData.Especialidad) {
            alert("Por favor, seleccione una especialidad.");
            return;
        }
        if (isCitaLaboratorio && (!formData.ExamenesRealizar || formData.ExamenesRealizar.length === 0)) {
            alert("Por favor, especifique al menos un examen a realizar.");
            return;
        }

        setLoading(true);

        try {
            // 1. CONVERTIR ARCHIVOS A BASE64
            const adjuntosPromises: Promise<ArchivoBaseModel>[] = selectedFiles.map(async (file) => {
                const base64Bytes = await fileToBase64(file);
                return {
                    nombreArchivo: file.name,
                    tipoArchivo: file.type.split('/')[0],
                    tipoMime: file.type, 
                    bytesArchivo: base64Bytes,
                };
            });
            const adjuntos: ArchivoBaseModel[] = await Promise.all(adjuntosPromises);

            // 2. CONSTRUCCIÓN DEL MODELO BASE
            const baseData = {
                PacienteId: formData.PacienteId!,
                FechaSolicitud: formData.FechaSolicitud!,
                Lugar: formData.Lugar,
                FechaCita: fechaCitaSeleccionada ? fechaCitaSeleccionada.toISOString() : null,
                MotivoCita: formData.MotivoCita,
                TipoCita: formData.TipoCita,
                Adjuntos: adjuntos.length > 0 ? adjuntos : null, 
            };

            let serviceCall: Promise<void>;

            // 3. SELECCIÓN DEL MODELO Y SERVICIO
            if (isCitaLaboratorio) {
                const dataToSend: CitaLaboratorioModel = {
                    ...baseData,
                    ExamenesRealizar: formData.ExamenesRealizar!,
                };
                serviceCall = agendarCitaLaboratorio(dataToSend); 
            } else { // Cita Médica
                const dataToSend: CitaMedicaModel = {
                    ...baseData,
                    Especialidad: formData.Especialidad!,
                };
                serviceCall = agendarCitaMedica(dataToSend);
            }

            // 4. LLAMAR AL SERVICIO
            await serviceCall;

            alert("✅ Cita solicitada con éxito");
            onSuccess();
            onClose();   
        } catch (error) {
            alert("❌ Error al solicitar la cita. Consulte la consola.");
            console.error("Error final en handleSubmit:", error);
        } finally {
            setLoading(false);
        }
    };
    
    // ... (Renderizado Condicional para carga de utilidades) ...

    if (!open) return null;
    
    if (isUtilitiesLoading) {
        return (
            <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
                <DialogContent sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', p: 4 }}>
                    <CircularProgress />
                    <Typography mt={2}>Cargando datos del formulario...</Typography>
                </DialogContent>
            </Dialog>
        );
    }

    return (
        <LocalizationProvider dateAdapter={AdapterDayjs}>
            <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
                <DialogTitle sx={{ backgroundColor: "#0088FF", color: 'white' }}>
                    Solicitar Cita
                </DialogTitle>
                <DialogContent dividers>
                    {/* 🚀 Grid CONTAINER - Se mantiene igual */}
                    <Grid container spacing={3} component="form" noValidate sx={{ pt: 2 }}>
                        
                        {/* 1. TIPO DE CITA (SELECTOR MAESTRO) */}
                        {/* Antes: <Grid item xs={12}> */}
                        <Grid size={12}> 
                            <FormControl fullWidth required>
                                <InputLabel id="tipo-cita-label">Tipo de Cita</InputLabel>
                                <Select
                                    labelId="tipo-cita-label"
                                    label="Tipo de Cita"
                                    name="TipoCita"
                                    value={formData.TipoCita || ''}
                                    onChange={(e) => handleSelectChange('TipoCita', e.target.value as number)}
                                >
                                    {tiposCita.map(tc => (
                                        <MenuItem key={tc.IdTipoCita} value={tc.IdTipoCita}>{tc.Tipo}</MenuItem>
                                    ))}
                                </Select>
                            </FormControl>
                        </Grid>
                        
                        {/* 2. CAMPOS ESPECÍFICOS CONDICIONALES */}
                        
                        {/* A. CAMPO PARA CITA MÉDICA: ESPECIALIDAD */}
                        {isCitaMedica && (
                            // Antes: <Grid item xs={12}>
                            <Grid size={12}>
                                <FormControl fullWidth required>
                                    <InputLabel id="especialidad-label">Especialidad</InputLabel>
                                    <Select
                                        labelId="especialidad-label"
                                        label="Especialidad"
                                        name="Especialidad"
                                        value={formData.Especialidad || ''}
                                        onChange={(e) => handleSelectChange('Especialidad', e.target.value as number)}
                                    >
                                        {especialidades.map(e => (
                                            <MenuItem key={e.IdEspecialidad} value={e.IdEspecialidad}>{e.Especialidad}</MenuItem>
                                        ))}
                                    </Select>
                                </FormControl>
                            </Grid>
                        )}
                        
                        {/* B. CAMPO PARA CITA LABORATORIO: EXÁMENES A REALIZAR */}
                        {isCitaLaboratorio && (
                            // Antes: <Grid item xs={12}>
                            <Grid size={12}>
                                <TextField
                                    label="Exámenes a Realizar (separados por coma)"
                                    name="ExamenesRealizar"
                                    multiline
                                    rows={2}
                                    value={formData.ExamenesRealizar?.join(', ') || ''} 
                                    onChange={handleExamenesChange}
                                    fullWidth
                                    required
                                    helperText="Ej: Glucosa, Hemograma Completo, Orina"
                                />
                            </Grid>
                        )}

                        {/* 3. CAMPOS COMUNES */}
                        
                        {/* Antes: <Grid item xs={12}> */}
                        <Grid size={12}>
                            <TextField
                                label="Motivo de la Cita"
                                name="MotivoCita"
                                multiline
                                rows={3}
                                value={formData.MotivoCita}
                                onChange={handleChange}
                                fullWidth
                                required
                            />
                        </Grid>

                        {/* CENTRO MÉDICO Y FECHA SUGERIDA (50%/50% en pantallas medianas) */}
                        
                        {/* Antes: <Grid item xs={12} sm={6}> */}
                        <Grid size={{ xs: 12, sm: 6 }}>
                            <FormControl fullWidth required>
                                <InputLabel id="centro-medico-label">Centro Médico</InputLabel>
                                <Select
                                    labelId="centro-medico-label"
                                    label="Centro Médico"
                                    name="Lugar"
                                    value={formData.Lugar || ''}
                                    onChange={(e) => handleSelectChange('Lugar', e.target.value as number)}
                                >
                                    {centros.map(cm => (
                                        <MenuItem key={cm.IdCentro} value={cm.IdCentro}>{cm.Centro}</MenuItem>
                                    ))}
                                </Select>
                            </FormControl>
                        </Grid>
                        
                        {/* Antes: <Grid item xs={12} sm={6}> */}
                        <Grid size={{ xs: 12, sm: 6 }}>
                            <DateTimePicker
                                label="Fecha Sugerida (Opcional)"
                                value={fechaCitaSeleccionada}
                                onChange={(newValue) => setFechaCitaSeleccionada(newValue)}
                                slotProps={{ textField: { fullWidth: true } }}
                            />
                        </Grid>

                        {/* 4. ADJUNTOS (COMÚN) */}
                        {/* Antes: <Grid item xs={12}> */}
                        <Grid size={12}>
                            <Box sx={{ display: 'flex', flexDirection: 'column', gap: 1 }}>
                                <input
                                    accept="image/*,application/pdf"
                                    style={{ display: 'none' }}
                                    id="raised-button-file"
                                    multiple
                                    type="file"
                                    onChange={handleFileChange}
                                />
                                <label htmlFor="raised-button-file">
                                    <Button 
                                        variant="outlined" 
                                        component="span" 
                                        startIcon={<AttachFileIcon />}
                                    >
                                        Añadir Archivos Adjuntos
                                    </Button>
                                </label>
                                
                                {selectedFiles.length > 0 && (
                                    <Box sx={{ mt: 1, display: 'flex', flexWrap: 'wrap', gap: 1 }}>
                                        {selectedFiles.map((file, index) => (
                                            <Chip
                                                key={index}
                                                label={`${file.name} (${(file.size / 1024).toFixed(1)} KB)`}
                                                onDelete={() => handleRemoveFile(file.name)}
                                                deleteIcon={<CloseIcon />}
                                                color="info"
                                                variant="outlined"
                                            />
                                        ))}
                                    </Box>
                                )}
                            </Box>
                        </Grid>

                    </Grid>
                </DialogContent>
                <DialogActions>
                    <Button onClick={onClose} color="error" disabled={loading}>
                        Cancelar
                    </Button>
                    <Button 
                        onClick={handleSubmit} 
                        color="primary" 
                        variant="contained"
                        disabled={loading || formData.TipoCita === 0}
                    >
                        {loading ? <CircularProgress size={24} /> : "Solicitar Cita"}
                    </Button>
                </DialogActions>
            </Dialog>
        </LocalizationProvider>
    );
};

export default ModalAgendarCita;