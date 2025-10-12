// src/features/Register/components/RegisterForm.tsx

import { TextField, Grid } from '@mui/material';
import { useEffect, useState } from 'react';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';
import type { Dayjs } from 'dayjs';

// Rutas de importación ajustadas para que sean relativas a la nueva ubicación del archivo
// Asumiendo que los Menus Selects se movieron todos a 'features/Register/components/'
import MenuGenero from './MenuGenero';
import MenuEspecialidades from './MenuEspecialidades';
import MenuDepartamento from './MenuDepartamento';
import MenuMunicipios from './MenuMunicipios';
import MenuBarrio from './MenuBarrio';
import MenuTipoUsuario from './MenuTipoUsuario';
import MenuTurnosActual from './MenuTurnosActual';
import MenuCentrosMedicos from './MenuCentrosMedicos';
import MenuAreasMedicas from './MenuAreasMedicas';
import MenuUniversidad from './MenuUniversidades';
import MenuProveedoresTelef from './MenuProveedoresTelef';

export default function RegisterForm({ setFormData }: { setFormData: Function }) {
    // ... Declaración de estados ...
    const [primerNombre, setPrimerNombre] = useState("");
    const [segundoNombre, setSegundoNombre] = useState("");
    const [primerApellido, setPrimerApellido] = useState("");
    const [segundoApellido, setSegundoApellido] = useState("");
    const [cedula, setCedula] = useState("");
    const [correo, setCorreo] = useState("");
    const [fechaNacimiento, setFechaNacimiento] = useState<Dayjs | null>(null);
    const [codSanitario, setCodSanitario] = useState("");
    const [egresadoEl, setEgresadoEl] = useState<Dayjs | null>(null);
    const [telefono, setTelefono] = useState(""); 
    const [experienciaAnios, setExperienciaAnios] = useState<number | ''>('');
    const [genero, setGenero] = useState<number | ''>('');
    const [especialidad, setEspecialidad] = useState<number | ''>('');
    const [departamentos, setDepartamentos] = useState<number | ''>('');
    const [municipio, setMunicipio] = useState<number | ''>('');
    const [barrio, setBarrios] = useState<number | ''>('');
    const [tipo, setTipo] = useState<number | ''>('');
    const [turno, setTurno] = useState<number | ''>('');
    const [c_medico, setC_medico] = useState<number | ''>('');
    const [area, setArea] = useState<number | ''>('');
    // CORRECCIÓN DE TIPESCRIPT: Cambiamos 'setuniversidad' a 'setUniversidad' por convención
    const [universidad, setUniversidad] = useState<number | ''>(''); 
    const [proveedor, setProveedor] = useState<number | ''>('');

    useEffect(() => {
        setFormData({
            primerNombre,
            segundoNombre,
            primerApellido,
            segundoApellido,
            cedula,
            correo,
            fechaNacimiento: fechaNacimiento ? fechaNacimiento.format("YYYY-MM-DD") : "",
            genero,
            tipo,
            codSanitario,
            especialidad,
            universidad,
            egresadoEl: egresadoEl ? egresadoEl.format("YYYY-MM-DD") : "",
            experienciaAnios,
            area,
            c_medico,
            turno,
            telefono,
            proveedor,
        });
    }, [
        primerNombre, segundoNombre, primerApellido, segundoApellido,
        cedula, correo, fechaNacimiento, genero, tipo,
        codSanitario, especialidad, universidad, egresadoEl,
        experienciaAnios, area, c_medico, turno,
        telefono, proveedor
    ]);

    return (
    <>
      <Grid container spacing={2} >
        
        {/* nombres */}
        <Grid size={{ xs: 12, sm: 6 }}>
        <TextField 
            required
            label="Primer nombre" 
            fullWidth 
            value={primerNombre}
            onChange={(e) => {
            setPrimerNombre(e.target.value); }}/>
        </Grid>

        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            required
            label="Segundo nombre" 
            fullWidth 
            value={segundoNombre}
            onChange={(e) => {
            setSegundoNombre(e.target.value); }} />
        </Grid>
        
        {/* apellidos */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField
            required 
            label="Primer apellido" 
            fullWidth 
            value={primerApellido}
            onChange={(e) => {
            setPrimerApellido(e.target.value); }} />
        </Grid>
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            required
            label="Segundo apellido" 
            fullWidth 
            value={segundoApellido}
            onChange={(e) => {
            setSegundoApellido(e.target.value); }} />
        </Grid>

        {/* cedula y genero */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            required
            label="Cédula" 
            fullWidth 
            value={cedula}
            onChange={(e) => {
            setCedula(e.target.value); }} />
        </Grid>

        <MenuGenero 
          genero={genero} 
          setGenero={setGenero}/>

        {/* fecha de nacimiento */}
        <Grid size={{ xs: 12}}>
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DemoContainer components={['DateField']}>
              <DateField
                required
                label="Fecha de nacimiento"
                variant="outlined"
                fullWidth
                value={fechaNacimiento}
                onChange={(nuevoValor) => {
                  setFechaNacimiento(nuevoValor);
                }}
                slotProps={{
                  textField: {
                    InputProps: {
                      sx: {
                        borderRadius: "3rem",
                        "& fieldset": {
                          borderColor: "#0088FF",
                        },
                      }
                    }
                  }
                }}
              />
            </DemoContainer>
          </LocalizationProvider>
        </Grid>

        {/* departamento */}
        <MenuDepartamento 
          departamento={departamentos} 
          setDepartamento={setDepartamentos}/>

        {/* municipio y barrios */}
        <MenuMunicipios 
          departamentoId={departamentos === '' ? null : departamentos} 
          municipio={municipio} 
          setMunicipio={setMunicipio} 
          disabled={!departamentos} />
        
        <MenuBarrio 
          municipioId={municipio === '' ? null : municipio} 
          barrio={barrio} 
          setBarrios={setBarrios} 
          disabled={!municipio}
        />

        {/* correo y tipo usuario */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            required
            label="Correo" 
            fullWidth 
            value={correo}
            onChange={(e) => {
            setCorreo(e.target.value); }} />
        </Grid>
        
        <MenuTipoUsuario 
          tipo={tipo}
          setTipo={setTipo} />

        {/* mas campos... */}
        {/* Egresado de */}
        <MenuUniversidad 
          universidad={universidad}
          setUniversidad={setUniversidad}/>
        
        <Grid size={{ xs: 12, sm: 6 }}>
            <LocalizationProvider dateAdapter={AdapterDayjs} >
              <DemoContainer components={['DateField']} >
                <DateField 
                  label="Egresado el" 
                  variant="outlined"
                  value={egresadoEl}
                  onChange={(nuevoValor) => {
                    setEgresadoEl(nuevoValor);
                  }}
                  slotProps={{
                    textField: {
                      InputProps: {
                        sx: {
                          borderRadius: "3rem",
                          "& fieldset": {
                            borderColor: "#0088FF",
                          },
                        }
                      }
                    }
                  }}
                  />
              </DemoContainer>
            </LocalizationProvider>
        </Grid>

        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            required
            label="Años de experiencia" 
            fullWidth 
            value={experienciaAnios}
            onChange={(e) => {
            setExperienciaAnios(Number(e.target.value)); }} />
        </Grid>

        <MenuAreasMedicas 
          area={area}
          setArea={setArea} />

        <MenuCentrosMedicos 
          c_medico={c_medico}
          setC_medico={setC_medico}/> 

        <MenuTurnosActual 
          turno={turno}
          setTurno={setTurno}/>

        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            required
            label="Código sanitario" 
            fullWidth 
            value={codSanitario}
            onChange={(e) => {
            setCodSanitario(e.target.value);  }} />
        </Grid>

        {/* Especialidad con Select */}
        <MenuEspecialidades 
          especialidad={especialidad} 
          setEspecialidad={setEspecialidad}/> 

        {/* Teléfono + Compañía */}
        <MenuProveedoresTelef 
          telefono={telefono}
          setTelefono={setTelefono}
          proveedor={proveedor}
          setProveedor={setProveedor}
         />
      </Grid>
    </>
    )
}