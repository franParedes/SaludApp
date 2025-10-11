// src/features/Register/components/MenuAreasMedicas.tsx

import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";

// La ruta se ajusta para anticipar el archivo de barril en src/hooks/index.ts
// Temporalmente, se ajusta a la ruta directa hasta que se cree el barril.
import { useAreas } from "../../../hooks/useAreas"; 

type AreasSelectProps = {
  area: number | '';
  setArea: (value: number | '') => void;
};

export default function MenuAreasMedicas({ area, setArea }: AreasSelectProps) {
  const { areas, loading } = useAreas();

  const handleChange = (event: SelectChangeEvent) => {
    // Convierte el valor a número antes de pasarlo al estado del componente padre
    setArea(Number(event.target.value));
  };

  return (
    <Grid size={{ xs: 12, sm: 6 }}>
      <FormControl fullWidth>
        <InputLabel id="Area-label">Area actual</InputLabel>
        <Select
          required
          labelId="Area-label"
          id="genero-select"
          // Mantiene el valor como string para el Select de MUI
          value={area === '' ? '' : area.toString()}
          label="Area actual"
          onChange={handleChange}
        >
          {loading ? (
            <MenuItem disabled value="">Cargando...</MenuItem>
          ) : (
            areas.map((a) => (
              <MenuItem 
                key={a.IdArea} 
                value={a.IdArea.toString()}
              >
                {a.Area}
              </MenuItem>
            ))
          )}
        </Select>
      </FormControl>
    </Grid>
  );
}