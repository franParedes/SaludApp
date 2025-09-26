import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import useMunicipios, { type Municipio } from "../../../../hooks/useMunicipios";

type MunicipioSelectProps = {
  departamentoId: number | null;
  municipio: number | '';
  setMunicipio: (value: number | '') => void;
};

export default function MenuMunicipios({ departamentoId, municipio, setMunicipio }: MunicipioSelectProps) {
  const { municipios, loading } = useMunicipios(departamentoId);

  const handleChange = (event: SelectChangeEvent) => {
    setMunicipio(Number(event.target.value));
  };

  return (
    <Grid size={{ xs: 12, sm: 6 }}>
      <FormControl fullWidth>
        <InputLabel id="Municipio-label">Municipio</InputLabel>
        <Select
          labelId="Municipio-label"
          id="Municipio-select"
          value={municipio === '' ? '' : municipio.toString()}
          onChange={handleChange}
        >
          {loading ? (
            <MenuItem disabled>Cargando...</MenuItem>
          ) : (
            municipios.map((m: Municipio) => (
              <MenuItem key={m.IdMunicipio} value={m.IdMunicipio.toString()}>
                {m.Municipio}
              </MenuItem>
            ))
          )}
        </Select>
      </FormControl>
    </Grid>
  );
}