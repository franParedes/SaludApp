import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import useDepartamentos from "../../../../hooks/useDepartamentos";

type DepartamentoSelectProps = {
  departamentos: number | '';
  setDepartamentos: (value: number | '') => void;
};

export default function MenuDepartamento({departamentos, setDepartamentos} : DepartamentoSelectProps) {
    const { Departamento, loading } = useDepartamentos();

    const handleChange = (event: SelectChangeEvent) => {
        setDepartamentos(Number(event.target.value));
    };

    return (
        <Grid size={{ xs: 12 }}>
        <FormControl fullWidth>
            <InputLabel id="Departamento-label">Departamento</InputLabel>
            <Select
                required
                labelId="Departamento-label"
                id="Departamento-select"
                // convierte number a string para el Select
                value={departamentos === '' ? '' : departamentos.toString()}
                label="Departamento"
                onChange={handleChange}
            >
            {loading ? (
                <MenuItem disabled>Cargando...</MenuItem>
            ) : (
                Departamento.map((d) => (
                <MenuItem 
                    key={d.IdDepartamento} 
                    value={d.IdDepartamento.toString()}>
                    {d.Departamento}
                </MenuItem>
                ))
            )}
            </Select>
        </FormControl>
        </Grid>
    );
}
