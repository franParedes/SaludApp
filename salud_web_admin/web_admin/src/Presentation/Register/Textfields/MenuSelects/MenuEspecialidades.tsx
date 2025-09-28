import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import useEspecialidades from "../../../../hooks/useEspecialidades";

type EspecialidadSelectProps = {
  Especialidad: number | '';
  setEspecialidad: (value: number | '') => void;
};

export default function MenuEspecialidades({ Especialidad, setEspecialidad }: EspecialidadSelectProps) {
    const { Especialidades, loading } = useEspecialidades();
    
    const handleChange = (event: SelectChangeEvent) => {
        setEspecialidad(Number(event.target.value));
    };

    return (
        <Grid size={13}>
            <FormControl fullWidth>
            <InputLabel id="Especialidad-label">Especialidades</InputLabel>
            <Select
                required
                labelId="Especialidad-label"
                id="demo-simple-select"
                // convierte number a string para el Select
                value={Especialidad === '' ? '' : Especialidad.toString()}
                label="Especialidades"
                onChange={handleChange}
            >
               {loading ? (
                    <MenuItem disabled>Cargando...</MenuItem>
                ) : (
                    Especialidades.map((e) => (
                    <MenuItem 
                        key={e.IdEspecialidad} 
                        value={e.IdEspecialidad.toString()}>
                        {e.Especialidad}
                    </MenuItem>
                    ))
                )}
            </Select>
            </FormControl>
        </Grid>
    )
}
