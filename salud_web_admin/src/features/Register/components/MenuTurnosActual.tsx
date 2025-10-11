import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import { useTurnos } from "../../../hooks/useTurnos";

type TurnoSelectProps = {
  turno: number | '';
  setTurno: (value: number | '') => void;
};

export default function MenuTurnosActual({ turno, setTurno }: TurnoSelectProps) {
  const { turnos, loading } = useTurnos();

  const handleChange = (event: SelectChangeEvent) => {
    setTurno(Number(event.target.value));
  };

  return (
    <Grid size={{ xs: 12, sm: 6 }}>
      <FormControl fullWidth>
        <InputLabel id="Turno-label">Turno actual</InputLabel>
        <Select
          required
          labelId="Turno-label"
          id="Turno-select"
          // convierte number a string para el Select
          value={turno === '' ? '' : turno.toString()}
          label="Turno actual"
          onChange={handleChange}
        >
          {loading ? (
            <MenuItem disabled>Cargando...</MenuItem>
          ) : (
            turnos.map((tu) => (
              <MenuItem 
                key={tu.IdTurno} 
                value={tu.IdTurno.toString()}>
                {tu.Turno}
              </MenuItem>
            ))
          )}
        </Select>
      </FormControl>
    </Grid>
  );
}
