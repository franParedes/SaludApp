import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import { useGenero } from "../../../../hooks/useGenero";

type GeneroSelectProps = {
  genero: number | '';
  setGenero: (value: number | '') => void;
};

export default function MenuGenero({ genero, setGenero }: GeneroSelectProps) {
  const { generos, loading } = useGenero();

  const handleChange = (event: SelectChangeEvent) => {
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
            // convierte number a string para el Select
            value={genero === '' ? '' : genero.toString()}
            label="Género"
            onChange={handleChange}
          >
          {loading ? (
            <MenuItem disabled>Cargando...</MenuItem>
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
