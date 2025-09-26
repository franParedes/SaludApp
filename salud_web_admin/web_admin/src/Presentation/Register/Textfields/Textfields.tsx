import { TextField, Grid } from '@mui/material';
import { useState } from 'react';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';
import MenuGenero from './MenuSelects/MenuGenero';
import MenuEspecialidades from './MenuSelects/MenuEspecialidades';
import MenuDepartamento from './MenuSelects/MenuDepartamento';
import MenuMunicipios from './MenuSelects/MenuMunicipios';

export default function Textfields() {
   // guardamos el IdGenero como number o vacío
  const [genero, setGenero] = useState<number | ''>('');

  // estado para la entrada de especialidades, guardamos el IdEspecialidad como number o vacio
  const [Especialidades, setEspecialidad] = useState<number | ''>('');

  // estado para la entrada de departamentos, guardamos el IdDepartamento como number o vacio
  const [departamentos, setDepartamentos] = useState<number | ''>('');

  // estado para la entrada de Municipios, dependiente del departamento seleccionado el cual guardamos el IdMunicipio como number o vacio
  const [municipio, setMunicipio] = useState<number | ''>('');

  return (
    <>
     <Grid container spacing={2} >
        
        {/* nombres */}
        <Grid size={{ xs: 12, sm: 6 }}>
        <TextField 
            label="Primer nombre" 
            fullWidth />
        </Grid>
        <Grid size={{ xs: 12, sm: 6 }}>
        <TextField 
            label="Segundo nombre" 
            fullWidth />
        </Grid>
        
        {/* apellidos */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Primer apellido" 
            fullWidth />
        </Grid>
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Segundo apellido" 
            fullWidth />
        </Grid>

        {/* cedula y genero */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Cédula" 
            fullWidth />
        </Grid>

        <MenuGenero 
          genero={genero} 
          setGenero={setGenero}/>

        {/* fecha de nacimiento */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <LocalizationProvider dateAdapter={AdapterDayjs} >
            <DemoContainer components={['DateField']} >
              <DateField 
                label="Fecha de nacimiento" 
                variant="outlined"
                slotProps={{
                  textField: {
                    color: "primary"
                  }
                }}
                />
            </DemoContainer>
          </LocalizationProvider>
        </Grid>

        {/* direccion  */}
        <Grid size={12}>
          <TextField 
            label="Dirección" 
            fullWidth />
        </Grid>

        {/* departamento */}
        <MenuDepartamento 
          departamentos={departamentos} 
          setDepartamentos={setDepartamentos}/>

        {/* municipio y barrios */}
         <MenuMunicipios 
            departamentoId={departamentos === '' ? null : departamentos} 
            municipio={municipio} 
            setMunicipio={setMunicipio} 
          />
          <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Barrio" 
            fullWidth />
        </Grid>

        {/* correo y tipo usuario */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Correo" 
            fullWidth />
        </Grid>
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Tipo de usuario" 
            fullWidth />
        </Grid>

        {/* mas campos... */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Egresado de" 
            fullWidth />
        </Grid>
        
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Egresado el" 
            fullWidth />
        </Grid>

        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Años de experiencia" 
            fullWidth />
        </Grid>
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Área actual" 
            fullWidth />
        </Grid>

        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Centro actual" 
            fullWidth />
        </Grid>
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Turno actual" 
            fullWidth />
        </Grid>

        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Código sanitario" 
            fullWidth />
        </Grid>
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField
            label="Teléfono"
            type="tel"
            fullWidth
          />
        </Grid>
        {/* Especialidad con Select */}
        <MenuEspecialidades 
          especialidad={Especialidades} 
          setEspecialidad={setEspecialidad}/>        
      </Grid>
      </>
    )
}


