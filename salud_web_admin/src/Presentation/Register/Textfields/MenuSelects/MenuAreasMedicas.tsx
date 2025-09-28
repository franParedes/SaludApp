import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import { useAreas } from "../../../../hooks/useArea";

type AreasSelectProps = {
  area: number | '';
  setArea: (value: number | '') => void;
};

export default function MenuAreasMedicas({ area, setArea }: AreasSelectProps) {
  const { areas, loading } = useAreas();

  const handleChange = (event: SelectChangeEvent) => {
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
          // convierte number a string para el Select
          value={area === '' ? '' : area.toString()}
          label="Area actual"
          onChange={handleChange}
        >
          {loading ? (
            <MenuItem disabled>Cargando...</MenuItem>
          ) : (
            areas.map((a) => (
              <MenuItem 
                key={a.IdArea} 
                value={a.IdArea.toString()}>
                {a.Area}
              </MenuItem>
            ))
          )}
        </Select>
      </FormControl>
    </Grid>
  );
}
