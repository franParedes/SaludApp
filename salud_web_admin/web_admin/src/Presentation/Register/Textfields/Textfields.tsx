import {  InputLabel, MenuItem, TextField, Grid, FormControl } from '@mui/material';
import { useState } from 'react';
import Select, { type SelectChangeEvent } from '@mui/material/Select';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';

export default function Textfields() {
  // estado para la entrada del DateTextField

    // estado para la entrada de especialidades
  const [Especialidades, setEspecialidad] = useState('');


  const handleChange = (event: SelectChangeEvent) => {
    setEspecialidad(event.target.value as string);
  };

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
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Género" 
            fullWidth />
        </Grid>

        {/* fecha de nacimiento */}
        <Grid size={{ xs: 12, sm: 6 }}>
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DemoContainer components={['DateField']}>
              <DateField 
                label="Fecha de nacimiento" 
                variant="outlined"
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

        {/* barrio y municipio*/}
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Barrio" 
            fullWidth />
        </Grid>
        <Grid size={{ xs: 12, sm: 6 }}>
          <TextField 
            label="Municipio" 
            fullWidth />
        </Grid>

        {/* departamento */}
        <Grid size={12}>
          <TextField 
            label="Departamento" 
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
        <Grid size={13}>
          <FormControl fullWidth>
            <InputLabel id="Especialidad-label">Especialidades</InputLabel>
            <Select
              labelId="Especialidad-label"
              id="demo-simple-select"
              value={Especialidades}
              label="Especialidades"
              onChange={handleChange}
            >
              <MenuItem value="">
                <em>Seleccione una especialidad</em>
              </MenuItem>
              <MenuItem value="medicina_general">Medicina General</MenuItem>
              <MenuItem value="pediatria">Pediatría</MenuItem>
              <MenuItem value="ginecologia">Ginecología</MenuItem>
            </Select>
          </FormControl>
        </Grid>
      </Grid>
      </>
    )
}


