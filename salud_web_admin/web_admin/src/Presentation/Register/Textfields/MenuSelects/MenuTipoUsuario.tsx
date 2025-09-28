import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import { useUsuario } from "../../../../hooks/useUsuario";

type TipoSelectProps = {
  tipo: number | '';
  setTipo: (value: number | '') => void;
};

export default function MenuTipoUsuario({ tipo, setTipo }: TipoSelectProps) {
  const { tipos, loading } = useUsuario();

  const handleChange = (event: SelectChangeEvent) => {
    setTipo(Number(event.target.value));
  };

  return (
    <Grid size={{ xs: 12, sm: 6 }}>
      <FormControl fullWidth>
        <InputLabel id="Tipo-label">Tipo de usuario</InputLabel>
        <Select
            required
            labelId="Tipo-label"
            id="Tipo-select"
            // convierte number a string para el Select
            value={tipo === '' ? '' : tipo.toString()}
            label="Tipo de usuario"
            onChange={handleChange}
        >
          {loading ? (
            <MenuItem disabled>Cargando...</MenuItem>
          ) : (
            tipos.map((t) => (
              <MenuItem 
                key={t.IdTipoUsuario} 
                value={t.IdTipoUsuario.toString()}>
                {t.TipoUsuario}
              </MenuItem>
            ))
          )}
        </Select>
      </FormControl>
    </Grid>
  );
}
