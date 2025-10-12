// src/features/Register/components/RegisterForm.tsx

import { TextField, Grid } from '@mui/material';
import { useEffect, useState } from 'react';
// Imports de fechas
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';
import type { Dayjs } from 'dayjs';

// Imports de Selects (asume rutas correctas)
import RoleSelector from './RoleSelector'; 
import MenuGenero from './MenuGenero'; 
import MenuEspecialidades from './MenuEspecialidades';
import MenuDepartamento from './MenuDepartamento';
import MenuMunicipios from './MenuMunicipios';
import MenuBarrio from './MenuBarrio';
import MenuTurnosActual from './MenuTurnosActual';
import MenuCentrosMedicos from './MenuCentrosMedicos';
import MenuAreasMedicas from './MenuAreasMedicas';
import MenuUniversidad from './MenuUniversidades';
import MenuProveedoresTelef from './MenuProveedoresTelef'; 

// --- DEFINICIÓN DE IDS ---
const ID_MEDICO = 1; 
const ID_ADMIN = 2;
const ID_RECEPCIONISTA = 3;
const ID_REGISTRO = 4;

export default function RegisterForm({ setFormData }: { setFormData: Function }) {
    
    // --- ESTADOS COMUNES (UsuarioModel) ---
    const [cedula, setCedula] = useState("");
    const [primerNombre, setPrimerNombre] = useState("");
    const [segundoNombre, setSegundoNombre] = useState("");
    const [primerApellido, setPrimerApellido] = useState("");
    const [segundoApellido, setSegundoApellido] = useState("");
    const [correo, setCorreo] = useState("");
    const [genero, setGenero] = useState<number | ''>('');
    const [fechaNacimiento, setFechaNacimiento] = useState<Dayjs | null>(null);
    const [tipo, setTipo] = useState<number>(ID_MEDICO); // Estado maestro de rol

    // Estados de Contacto/Ubicación
    const [telefono, setTelefono] = useState(""); 
    const [proveedor, setProveedor] = useState<number | ''>('');
    const [departamentos, setDepartamentos] = useState<number | ''>('');
    const [municipio, setMunicipio] = useState<number | ''>('');
    const [barrio, setBarrios] = useState<number | ''>('');
    
    // --- ESTADOS CONDICIONALES (Compartidos entre roles) ---
    const [c_medico, setC_medico] = useState<number | ''>(''); // CentroActual 
    const [turno, setTurno] = useState<number | ''>(''); // TurnoActual 

    // --- ESTADOS EXCLUSIVOS DE MÉDICO ---
    const [codSanitario, setCodSanitario] = useState("");
    const [especialidad, setEspecialidad] = useState<number | ''>('');
    const [universidad, setUniversidad] = useState<number | ''>(''); 
    const [egresadoEl, setEgresadoEl] = useState<Dayjs | null>(null);
    const [experienciaAnios, setExperienciaAnios] = useState<number | ''>('');
    const [area, setArea] = useState<number | ''>(''); 

    // --- useEffect: Construye el objeto de datos para el componente padre (Payload dinámico) ---
    useEffect(() => {
        let payload: any = {
            // Campos de UsuarioModel
            cedula, primerNombre, segundoNombre, primerApellido, segundoApellido,
            correo, genero, tipo, 
            fechaNacimiento: fechaNacimiento ? fechaNacimiento.format("YYYY-MM-DD") : null,
            
            // Contacto/Dirección
            telefono, proveedor, departamentos, municipio, barrio,
        };

        // Lógica condicional para añadir campos específicos
        if (tipo === ID_MEDICO) {
            payload = {
                ...payload,
                codSanitario,
                especialidad,
                egresadoDe: universidad,
                egresadoEl: egresadoEl ? egresadoEl.format("YYYY-MM-DD") : null,
                experienciaAnyos: experienciaAnios,
                areaActual: area,
                centroActual: c_medico,
                turnoActual: turno,
            };
        } else if (tipo === ID_ADMIN) {
            payload = {
                ...payload,
                centroActual: c_medico,
            };
        } else if (tipo === ID_RECEPCIONISTA || tipo === ID_REGISTRO) {
            // Recepcionista y Registro tienen el mismo payload adicional
            payload = {
                ...payload,
                centroActual: c_medico,
                turnoActual: turno,
            };
        }

        setFormData(payload);
    }, [
        // Dependencias del useEffect
        cedula, primerNombre, segundoNombre, primerApellido, segundoApellido, correo, genero, fechaNacimiento, tipo,
        telefono, proveedor, departamentos, municipio, barrio,
        codSanitario, especialidad, universidad, egresadoEl, experienciaAnios, area, c_medico, turno, setFormData
    ]);

    // --- RENDERIZADO DEL FORMULARIO ---
    return (
    <>
        <Grid container spacing={2} >
            
            {/* --- 1. SELECTOR MAESTRO DE ROL --- */}
            <Grid size={{ xs: 12 }}>
                <RoleSelector tipo={tipo} setTipo={setTipo} /> 
            </Grid>
            
            {/* --- 2. CAMPOS COMUNES (TODOS LOS ROLES) --- */}
            
            {/* nombres */}
            <Grid size={{ xs: 12, sm: 6 }}>
                <TextField required label="Primer nombre" fullWidth value={primerNombre}
                    onChange={(e) => { setPrimerNombre(e.target.value); }}/>
            </Grid>
            <Grid size={{ xs: 12, sm: 6 }}>
                <TextField label="Segundo nombre" fullWidth value={segundoNombre}
                    onChange={(e) => { setSegundoNombre(e.target.value); }} />
            </Grid>
            
            {/* apellidos */}
            <Grid size={{ xs: 12, sm: 6 }}>
                <TextField required label="Primer apellido" fullWidth value={primerApellido}
                    onChange={(e) => { setPrimerApellido(e.target.value); }} />
            </Grid>
            <Grid size={{ xs: 12, sm: 6 }}>
                <TextField label="Segundo apellido" fullWidth value={segundoApellido}
                    onChange={(e) => { setSegundoApellido(e.target.value); }} />
            </Grid>

            {/* cedula y genero */}
            <Grid size={{ xs: 12, sm: 6 }}>
                <TextField required label="Cédula" fullWidth value={cedula}
                    onChange={(e) => { setCedula(e.target.value); }} />
            </Grid>
            <MenuGenero genero={genero} setGenero={setGenero}/> 
            
            {/* fecha de nacimiento */}
            <Grid size={{ xs: 12}}>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                <DemoContainer components={['DateField']}>
                    <DateField required label="Fecha de nacimiento" variant="outlined" fullWidth
                        value={fechaNacimiento}
                        onChange={(nuevoValor) => { setFechaNacimiento(nuevoValor); }}
                        slotProps={{ textField: { InputProps: { sx: { borderRadius: "3rem", "& fieldset": { borderColor: "#0088FF", }, } } } }}
                    />
                </DemoContainer>
                </LocalizationProvider>
            </Grid>
            
            {/* Ubicación (Dpto, Municipio, Barrio) - Corrección de props de ID */}
            <MenuDepartamento departamento={departamentos} setDepartamento={setDepartamentos}/>
            <MenuMunicipios departamentoId={departamentos === '' ? null : departamentos} municipio={municipio} setMunicipio={setMunicipio} disabled={!departamentos} />
            <MenuBarrio municipioId={municipio === '' ? null : municipio} barrio={barrio} setBarrios={setBarrios} disabled={!municipio} />
            
            {/* correo */}
            <Grid size={{ xs: 12, sm: 6 }}>
                <TextField required label="Correo" fullWidth value={correo}
                    onChange={(e) => { setCorreo(e.target.value); }} />
            </Grid>
            
            {/* Teléfono + Proveedor */}
            <MenuProveedoresTelef 
                telefono={telefono}
                setTelefono={setTelefono}
                proveedor={proveedor}
                setProveedor={setProveedor}
            />


            {/* --- 3. CAMPOS ESPECÍFICOS POR ROL --- */}

            {/* A. CAMPOS PARA ADMINISTRADOR, RECEPCIONISTA Y REGISTRO (Centro Actual) */}
            {(tipo === ID_ADMIN || tipo === ID_RECEPCIONISTA || tipo === ID_REGISTRO) && (
                <MenuCentrosMedicos c_medico={c_medico} setC_medico={setC_medico}/>
            )}

            {/* B. CAMPOS PARA RECEPCIONISTA Y REGISTRO (Turno Actual) */}
            {(tipo === ID_RECEPCIONISTA || tipo === ID_REGISTRO) && (
                <MenuTurnosActual turno={turno} setTurno={setTurno}/>
            )}
            
            {/* C. CAMPOS EXCLUSIVOS DE MÉDICO */}
            {tipo === ID_MEDICO && (
                <>
                    {/* Egresado de (Universidad) */}
                    <MenuUniversidad universidad={universidad} setUniversidad={setUniversidad}/>
                    
                    {/* Egresado el (DateField) */}
                    <Grid size={{ xs: 12, sm: 6 }}>
                        <LocalizationProvider dateAdapter={AdapterDayjs} >
                            <DemoContainer components={['DateField']} >
                                <DateField required label="Egresado el" variant="outlined" value={egresadoEl}
                                    onChange={(nuevoValor) => { setEgresadoEl(nuevoValor); }}
                                    slotProps={{ textField: { InputProps: { sx: { borderRadius: "3rem", "& fieldset": { borderColor: "#0088FF", }, } } } }}
                                />
                            </DemoContainer>
                        </LocalizationProvider>
                    </Grid>

                    {/* Años de Experiencia (TextField) */}
                    <Grid size={{ xs: 12, sm: 6 }}>
                        <TextField required label="Años de experiencia" fullWidth value={experienciaAnios}
                            type="number"
                            onChange={(e) => { setExperienciaAnios(Number(e.target.value)); }} />
                    </Grid>

                    {/* Centro de Trabajo (Área, Centro, Turno) - Nota: Centro y Turno se repiten por el bloque anterior, pero aquí incluimos Área */}
                    <MenuAreasMedicas area={area} setArea={setArea} />
                    <MenuCentrosMedicos c_medico={c_medico} setC_medico={setC_medico}/> 
                    <MenuTurnosActual turno={turno} setTurno={setTurno}/>

                    {/* Cod. Sanitario (TextField) */}
                    <Grid size={{ xs: 12, sm: 6 }}>
                        <TextField required label="Código sanitario" fullWidth value={codSanitario}
                            onChange={(e) => { setCodSanitario(e.target.value);  }} />
                    </Grid>

                    {/* Especialidad con Select */}
                    <MenuEspecialidades especialidad={especialidad} setEspecialidad={setEspecialidad}/> 
                </>
            )}

        </Grid>
    </>
    )
}