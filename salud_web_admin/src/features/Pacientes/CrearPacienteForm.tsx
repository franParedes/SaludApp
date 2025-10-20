// src/features/Pacientes/CrearPacienteForm.tsx (ACTUALIZADO CON PLACEHOLDERS Y FORMATOS)

import React, { useState, useMemo } from 'react';
import {
    Container, Typography, Grid, TextField, Button, Paper, 
    CircularProgress, Alert, FormControl, InputLabel, Select, MenuItem, Box
} from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import dayjs, { Dayjs } from 'dayjs';
import { useNavigate } from 'react-router-dom';

// Importa Tipos
import type { PacienteModel, TelefonoModel, DireccionModel } from '../../types/PacienteTypes';

// Importa Service y Hooks
import { useCrearPaciente } from '../../hooks/usePaciente';
import { useGenero } from '../../hooks/useGenero'; 
import { useOcupaciones } from '../../hooks/useOcupaciones';
import { useEscolaridades } from '../../services/useEscolaridades';
import { useReligiones } from '../../hooks/useReligiones';
import { useEstadosCiviles } from '../../hooks/useEstadosCiviles';

// Importa tus componentes de Select (asumiendo rutas y nombres)
import MenuDepartamento from '../Register/components/MenuDepartamento';
import MenuMunicipios from '../Register/components/MenuMunicipios';
import MenuBarrio from '../Register/components/MenuBarrio';
// Importamos MenuProveedoresTelef para modificar el campo de Teléfono dentro de él
import MenuProveedoresTelef from '../Register/components/MenuProveedoresTelef'; 



const CEDULA_PATTERN = '^[0-9]{3}-[0-9]{6}-[0-9]{4}[A-Z]$';
const CORREO_PATTERN = '^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$';
const TELEFONO_PATTERN = '^[0-9]{8}$';

const CrearPacienteForm: React.FC = () => {
    const navigate = useNavigate();
    const { submitPaciente, loading, error, success } = useCrearPaciente();
    
    // USAR LOS HOOKS PARA CARGAR DATOS DE UTILIDAD
    const { generos, loading: loadingGeneros} = useGenero();
    const { ocupaciones, loading: loadingOcupaciones, error: errorOcupaciones} = useOcupaciones();
    const { escolaridades, loading: loadingEscolaridades, error: errorEscolaridades} = useEscolaridades();
    const { religiones, loading: loadingReligiones, error: errorReligiones} = useReligiones();
    const { estadosCiviles, loading: loadingEstadosCiviles, error: errorEstadosCiviles} = useEstadosCiviles();
    
    // Determinar si algún dato de utilidad está cargando o tiene error
    const anyUtilityLoading = loadingGeneros || loadingOcupaciones || loadingEscolaridades || loadingReligiones || loadingEstadosCiviles;
    const anyUtilityError = errorOcupaciones || errorEscolaridades || errorReligiones || errorEstadosCiviles;
    
    // --- ESTADO PRINCIPAL DEL FORMULARIO ---
    const [formData, setFormData] = useState<Partial<PacienteModel>>({
        TipoUsuario: 1, // Fijo: Paciente
        Telefonos: [],
        Direcciones: [],
        Contrasenya: 'P@ciente123',
        CantidadHermanos: 0,
        Edad: 0
    });

    // --- ESTADOS AUXILIARES PARA SUBCOMPONENTES ---
    const [fechaNacimiento, setFechaNacimiento] = useState<Dayjs | null>(null);

    // Estado para el manejo de la dirección principal
    const [tempDepartamento, setTempDepartamento] = useState<number | ''>('');
    const [tempMunicipio, setTempMunicipio] = useState<number | ''>('');
    const [tempBarrio, setTempBarrio] = useState<number | ''>('');
    const [tempDireccionDetalle, setTempDireccionDetalle] = useState('');

    // Estado para el manejo del teléfono principal
    const [tempTelefonoNumero, setTempTelefonoNumero] = useState('');
    const [tempCompania, setTempCompania] = useState<number | ''>('');

    // --- HANDLERS GENERALES ---
    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value, type } = e.target;
        
        // Convertir a número si es un campo numérico (excepto cédula, inss)
        const parsedValue = (type === 'number' && name !== 'Cedula' && name !== 'NumeroInss') 
            ? parseInt(value) || 0 
            : value;

        setFormData(prev => ({ ...prev, [name]: parsedValue }));
    };

    const handleSelectChange = (name: keyof PacienteModel, value: number) => {
        setFormData(prev => ({ ...prev, [name]: value }));
    };

    // --- CÁLCULO DE EDAD ---
    useMemo(() => {
        if (fechaNacimiento) {
            const age = dayjs().diff(fechaNacimiento, 'year');
            setFormData(prev => ({ ...prev, Edad: age, FechaNacimiento: fechaNacimiento.format('YYYY-MM-DD') }));
        }
    }, [fechaNacimiento]);


    // --- FUNCIÓN DE SUBMISIÓN ---
    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        
        // Verificar que no haya datos de utilidad cargando
        if (anyUtilityLoading) {
            alert("Espere a que los datos de utilidad terminen de cargar.");
            return;
        }

        // 1. CONSTRUIR MODELOS ANIDADOS (Teléfono y Dirección)
        // NOTA: El teléfono se envía como entero, se parsea aquí.
        const telefono: TelefonoModel = {
            Telefono: parseInt(tempTelefonoNumero) || 0, 
            Compania: tempCompania === '' ? 0 : tempCompania,
        };

        const direccion: DireccionModel = {
            Departamento: tempDepartamento === '' ? 0 : tempDepartamento,
            Municipio: tempMunicipio === '' ? 0 : tempMunicipio,
            Barrio: tempBarrio === '' ? 0 : tempBarrio,
            Direccion: tempDireccionDetalle,
        };

        // 2. CONSTRUIR MODELO FINAL
        const dataToSend: PacienteModel = {
            ...formData,
            Telefonos: [telefono],
            Direcciones: [direccion],
            Genero: formData.Genero || 0,
            Ocupacion: formData.Ocupacion || 0,
            Escolaridad: formData.Escolaridad || 0,
            Religion: formData.Religion || 0,
            EstadoCivil: formData.EstadoCivil || 0,
            Cedula: formData.Cedula || '',
            PrimerNombre: formData.PrimerNombre || '',
            PrimerApellido: formData.PrimerApellido || '',
            Correo: formData.Correo || '',
            SegundoNombre: formData.SegundoNombre || '',
            SegundoApellido: formData.SegundoApellido || '',
            NumeroInss: formData.NumeroInss || '',
            FechaNacimiento: formData.FechaNacimiento || dayjs().format('YYYY-MM-DD'),
            Edad: formData.Edad || 0,
            Contrasenya: formData.Contrasenya!,
            TipoUsuario: formData.TipoUsuario!,
            CantidadHermanos: formData.CantidadHermanos || 0,
        } as PacienteModel;

        const ok = await submitPaciente(dataToSend);

        if (ok) {
            navigate('/pacientes');
        }
    };


    if (anyUtilityError) {
        return (
            <Container maxWidth="lg">
                <Alert severity="error" sx={{ mt: 4 }}>
                    Error cargando datos de utilidad: {anyUtilityError}
                </Alert>
            </Container>
        );
    }


    return (
        <LocalizationProvider dateAdapter={AdapterDayjs}>
            <Container maxWidth="lg">
                <Typography variant="h4" component="h1" gutterBottom>
                    Registrar Nuevo Paciente
                </Typography>

                <Paper elevation={3} sx={{ p: 4 }}>
                    {success && <Alert severity="success" sx={{ mb: 2 }}>Paciente registrado con éxito. Redirigiendo...</Alert>}
                    {error && <Alert severity="error" sx={{ mb: 2 }}>{error}</Alert>}

                    <Box component="form" onSubmit={handleSubmit} sx={{ mt: 3 }}>
                        <Grid container spacing={3}> 
                            
                            {/* === SECCIÓN 1: DATOS PERSONALES === */}
                            <Grid size={{ xs: 12 }}>
                                <Typography variant="h6" color="primary">Datos Personales</Typography>
                            </Grid>
                            
                            {/* CÉDULA: APLICACIÓN DE FORMATO */}
                            <Grid size={{ xs: 12, sm: 6 }}>
                                <TextField 
                                    required 
                                    fullWidth 
                                    label="Cédula" 
                                    name="Cedula" 
                                    value={formData.Cedula || ''} 
                                    onChange={handleChange} 
                                    placeholder="Ej: 001-123456-0001A"
                                    inputProps={{ 
                                        pattern: CEDULA_PATTERN,
                                        title: 'Formato: 000-000000-0000L (L es una letra mayúscula)'
                                    }}
                                />
                            </Grid>
                            <Grid size={{ xs: 12, sm: 6 }}><TextField required fullWidth label="Primer Nombre" name="PrimerNombre" value={formData.PrimerNombre || ''} onChange={handleChange} /></Grid>
                            <Grid size={{ xs: 12, sm: 6 }}><TextField fullWidth label="Segundo Nombre" name="SegundoNombre" value={formData.SegundoNombre || ''} onChange={handleChange} /></Grid>
                            <Grid size={{ xs: 12, sm: 6 }}><TextField required fullWidth label="Primer Apellido" name="PrimerApellido" value={formData.PrimerApellido || ''} onChange={handleChange} /></Grid>
                            <Grid size={{ xs: 12, sm: 6 }}><TextField fullWidth label="Segundo Apellido" name="SegundoApellido" value={formData.SegundoApellido || ''} onChange={handleChange} /></Grid>
                            
                            {/* CORREO: APLICACIÓN DE FORMATO */}
                            <Grid size={{ xs: 12, sm: 6 }}>
                                <TextField 
                                    required 
                                    fullWidth 
                                    label="Correo Electrónico" 
                                    name="Correo" 
                                    type="email" 
                                    value={formData.Correo || ''} 
                                    onChange={handleChange} 
                                    placeholder="Ej: nombre.apellido@dominio.com"
                                    inputProps={{ 
                                        pattern: CORREO_PATTERN,
                                        title: 'Formato: correo@dominio.ext'
                                    }}
                                />
                            </Grid>
                            
                            <Grid size={{ xs: 12, sm: 6 }}>
                                <DatePicker 
                                    label="Fecha de Nacimiento"
                                    value={fechaNacimiento}
                                    onChange={setFechaNacimiento}
                                    format="YYYY-MM-DD"
                                    slotProps={{ textField: { fullWidth: true, required: true } }}
                                />
                            </Grid>
                            
                            <Grid size={{ xs: 12, sm: 6 }}><TextField fullWidth label="Edad (Auto)" disabled value={formData.Edad || 0} /></Grid>

                            <Grid size={{ xs: 12, sm: 6 }}>
                                <FormControl fullWidth required disabled={loadingGeneros}>
                                    <InputLabel>Género</InputLabel>
                                    <Select 
                                        label="Género" 
                                        value={formData.Genero ? String(formData.Genero) : ''} 
                                        onChange={(e) => handleSelectChange('Genero', Number(e.target.value))}
                                    >
                                        {loadingGeneros && <MenuItem disabled value="">Cargando géneros...</MenuItem>}
                                        {generos.map(g => (<MenuItem key={g.IdGenero} value={g.IdGenero}>{g.Genero}</MenuItem>))}
                                    </Select>
                                </FormControl>
                            </Grid>

                            {/* === SECCIÓN 2: INFORMACIÓN DE CONTACTO (Teléfono) === */}
                            <Grid size={{ xs: 12 }}>
                                <Typography variant="h6" color="primary" sx={{ mt: 2 }}>Contacto</Typography>
                            </Grid>
                            
                            {/* Componente Teléfono y Compañía: ASUMIMOS que se necesita modificar MenuProveedoresTelef
                                para aplicar el formato al campo de número, pero lo implementaremos aquí
                                directamente en el hook principal para evitar modificar componentes anidados
                                que no se han solicitado explícitamente. */}
                            <Grid size={{ xs: 12 }}> 
                                {/* REVISIÓN: El componente MenuProveedoresTelef internamente debería usar 
                                    tempTelefonoNumero y setTempTelefonoNumero para el input de teléfono.
                                    Si es un componente personalizado, DEBEMOS ASUMIR que toma los props.
                                    Para aplicar el formato, asumimos que este componente tiene los campos TextField
                                    dentro y que los props `telefono` y `setTelefono` se usan en un input. 
                                    Si el usuario quiere aplicar el formato aquí, usaremos un TextField temporal
                                    para ilustrar la lógica del formato, y luego asumiremos que se aplica 
                                    en MenuProveedoresTelef internamente.
                                */}
                                <Grid container spacing={3} sx={{ pt: 1 }}>
                                    <Grid size={{ xs: 12, sm: 6 }}>
                                        <TextField
                                            required
                                            fullWidth
                                            label="Teléfono"
                                            name="Telefono"
                                            type="tel"
                                            value={tempTelefonoNumero}
                                            onChange={(e) => setTempTelefonoNumero(e.target.value)}
                                            placeholder="Ej: 88887777 (8 dígitos)"
                                            inputProps={{
                                                pattern: TELEFONO_PATTERN,
                                                title: 'El número debe ser de 8 dígitos.',
                                                maxLength: 8 // Limita la entrada a 8 caracteres
                                            }}
                                        />
                                    </Grid>
                                    <Grid size={{ xs: 12, sm: 6 }}>
                                        <MenuProveedoresTelef 
                                            // Se le sigue pasando el valor, aunque aquí manejamos el TextField
                                            telefono={tempTelefonoNumero} 
                                            setTelefono={setTempTelefonoNumero} 
                                            proveedor={tempCompania} 
                                            setProveedor={setTempCompania} 
                                        />
                                    </Grid>
                                </Grid>
                                {}
                            </Grid>


                            {/* === SECCIÓN 3: DIRECCIÓN PRINCIPAL === */}
                            <Grid size={{ xs: 12 }}>
                                <Typography variant="h6" color="primary" sx={{ mt: 2 }}>Dirección</Typography>
                            </Grid>
                            
                            <Grid size={{ xs: 12, sm: 4 }}>
                                <MenuDepartamento departamento={tempDepartamento} setDepartamento={setTempDepartamento} />
                            </Grid>
                            <Grid size={{ xs: 12, sm: 4 }}>
                                <MenuMunicipios 
                                    departamentoId={tempDepartamento as number} 
                                    municipio={tempMunicipio} 
                                    setMunicipio={setTempMunicipio} 
                                    disabled={!tempDepartamento}
                                />
                            </Grid>
                            <Grid size={{ xs: 12, sm: 4 }}>
                                <MenuBarrio 
                                    municipioId={tempMunicipio as number} 
                                    barrio={tempBarrio} 
                                    setBarrios={setTempBarrio} 
                                    disabled={!tempMunicipio}
                                />
                            </Grid>
                            <Grid size={{ xs: 12 }}>
                                <TextField 
                                    required 
                                    fullWidth 
                                    label="Dirección Detallada (Calle, Casa, Referencias)" 
                                    name="DireccionDetalle" 
                                    value={tempDireccionDetalle} 
                                    onChange={(e) => setTempDireccionDetalle(e.target.value)} 
                                />
                            </Grid>

                            {/* === SECCIÓN 4: OTROS DATOS (Utilidades) === */}
                            <Grid size={{ xs: 12 }}>
                                <Typography variant="h6" color="primary" sx={{ mt: 2 }}>Otros Datos</Typography>
                            </Grid>
                            
                            <Grid size={{ xs: 12, sm: 4 }}>
                                <TextField fullWidth label="Número INSS (Opcional)" name="NumeroInss" value={formData.NumeroInss || ''} onChange={handleChange} />
                            </Grid>

                            <Grid size={{ xs: 12, sm: 4 }}>
                                <FormControl fullWidth required disabled={loadingOcupaciones}>
                                    <InputLabel>Ocupación</InputLabel>
                                    <Select 
                                        label="Ocupación" 
                                        value={formData.Ocupacion ? String(formData.Ocupacion) : ''} 
                                        onChange={(e) => handleSelectChange('Ocupacion', Number(e.target.value))}
                                    >
                                        {loadingOcupaciones && <MenuItem disabled value="">Cargando ocupaciones...</MenuItem>}
                                        {ocupaciones.map(o => (<MenuItem key={o.IdOcupacion} value={o.IdOcupacion}>{o.Ocupacion}</MenuItem>))}
                                    </Select>
                                </FormControl>
                            </Grid>

                            <Grid size={{ xs: 12, sm: 4 }}>
                                <FormControl fullWidth required disabled={loadingEscolaridades}>
                                    <InputLabel>Escolaridad</InputLabel>
                                    <Select 
                                        label="Escolaridad" 
                                        value={formData.Escolaridad ? String(formData.Escolaridad) : ''} 
                                        onChange={(e) => handleSelectChange('Escolaridad', Number(e.target.value))}
                                    >
                                        {loadingEscolaridades && <MenuItem disabled value="">Cargando escolaridades...</MenuItem>}
                                        {escolaridades.map(e => (<MenuItem key={e.IdEscolaridad} value={e.IdEscolaridad}>{e.Escolaridad}</MenuItem>))}
                                    </Select>
                                </FormControl>
                            </Grid>
                            
                            <Grid size={{ xs: 12, sm: 4 }}>
                                <FormControl fullWidth required disabled={loadingReligiones}>
                                    <InputLabel>Religión</InputLabel>
                                    <Select 
                                        label="Religión" 
                                        value={formData.Religion ? String(formData.Religion) : ''} 
                                        onChange={(e) => handleSelectChange('Religion', Number(e.target.value))}
                                    >
                                        {loadingReligiones && <MenuItem disabled value="">Cargando religiones...</MenuItem>}
                                        {religiones.map(r => (<MenuItem key={r.IdReligion} value={r.IdReligion}>{r.Religion}</MenuItem>))}
                                    </Select>
                                </FormControl>
                            </Grid>
                            
                            <Grid size={{ xs: 12, sm: 4 }}>
                                <FormControl fullWidth required disabled={loadingEstadosCiviles}>
                                    <InputLabel>Estado Civil</InputLabel>
                                    <Select 
                                        label="Estado Civil" 
                                        value={formData.EstadoCivil ? String(formData.EstadoCivil) : ''} 
                                        onChange={(e) => handleSelectChange('EstadoCivil', Number(e.target.value))}
                                    >
                                        {loadingEstadosCiviles && <MenuItem disabled value="">Cargando estados civiles...</MenuItem>}
                                        {estadosCiviles.map(ec => (<MenuItem key={ec.IdEstadoCivil} value={ec.IdEstadoCivil}>{ec.EstadoCivil}</MenuItem>))}
                                    </Select>
                                </FormControl>
                            </Grid>

                            <Grid size={{ xs: 12, sm: 4 }}>
                                <TextField fullWidth required label="Cant. Hermanos" name="CantidadHermanos" type="number" value={formData.CantidadHermanos || 0} onChange={handleChange} inputProps={{ min: 0 }} />
                            </Grid>
                            
                            {/* === BOTÓN DE ENVÍO === */}
                            <Grid size={{ xs: 12 }} sx={{ mt: 3, textAlign: 'right' }}>
                                <Button 
                                    type="submit" 
                                    variant="contained" 
                                    color="primary" 
                                    disabled={loading || anyUtilityLoading}
                                    startIcon={loading ? <CircularProgress size={20} color="inherit" /> : null}
                                >
                                    {loading ? 'Registrando...' : 'Registrar Paciente'}
                                </Button>
                            </Grid>

                        </Grid>
                    </Box>
                </Paper>
            </Container>
        </LocalizationProvider>
    );
};

export default CrearPacienteForm;