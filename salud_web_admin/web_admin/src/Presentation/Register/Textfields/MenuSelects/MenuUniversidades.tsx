import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import { useUniversidades } from "../../../../hooks/useUniversidades";

type UniversidadSelectProps = {
  universidad: number | '';
  setUniversidad: (value: number | '') => void;
};

export default function MenuUniversidad({ universidad, setUniversidad }: UniversidadSelectProps) {
  const { universidades, loading } = useUniversidades();

  const handleChange = (event: SelectChangeEvent) => {
    setUniversidad(Number(event.target.value));
  };

  return (
    <Grid size={{ xs: 12, sm: 6 }}>
      <FormControl fullWidth>
        <InputLabel id="Universidad-label">Egresado de</InputLabel>
        <Select
            required
            labelId="Universidad-label"
            id="Universidad-select"
            // convierte number a string para el Select
            value={universidad === '' ? '' : universidad.toString()}
            label="Egresado de"
            onChange={handleChange}
        >
          {loading ? (
            <MenuItem disabled>Cargando...</MenuItem>
          ) : (
            universidades.map((u) => (
              <MenuItem 
                key={u.IdUniversidad} 
                value={u.IdUniversidad.toString()}>
                {u.Universidad}
              </MenuItem>
            ))
          )}
        </Select>
      </FormControl>
    </Grid>
  );
}
