// src/features/Register/components/MenuGenero.tsx

import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
// La ruta se ajusta para anticipar el archivo de barril en src/hooks/index.ts
import { useGenero } from "../../../hooks/useGenero"; 

type GeneroSelectProps = {
  genero: number | '';
  setGenero: (value: number | '') => void;
};

export default function MenuGenero({ genero, setGenero }: GeneroSelectProps) {
  const { generos, loading } = useGenero();

  const handleChange = (event: SelectChangeEvent) => {
    // Convierte el valor a número antes de pasarlo al estado del componente padre
    setGenero(Number(event.target.value));
  };

  return (
    <Grid size={{ xs: 12, sm: 6 }}>
      <FormControl fullWidth>
        <InputLabel id="Genero-label">Género</InputLabel>
        <Select
          required
          labelId="Genero-label"
          id="genero-select"
          // Mantiene el valor como string para el Select de MUI
          value={genero === '' ? '' : genero.toString()}
          label="Género"
          onChange={handleChange}
          disabled={loading} // Deshabilitar mientras carga
        >
          {loading ? (
            <MenuItem disabled value="">Cargando...</MenuItem>
          ) : (
            generos.map((g) => (
              <MenuItem 
                key={g.IdGenero} 
                value={g.IdGenero.toString()}>
                {g.Genero}
              </MenuItem>
            ))
          )}
        </Select>
      </FormControl>
    </Grid>
  );
}