import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import useBarrios from "../../../../hooks/useBarrios";

type BarrioSelectProps = {
    municipioId: number | null;
    barrio: number | '';
    setBarrios: (value: number | '') => void;
    disabled?: boolean;
};

export default function MenuBarrio({municipioId, barrio, setBarrios, disabled = false} : BarrioSelectProps) {
    const { barrios, loading } = useBarrios(municipioId);

    const handleChange = (event: SelectChangeEvent) => {
        setBarrios(Number(event.target.value));
    };

    return (
        <Grid size={{ xs: 12, sm: 6 }}>
        <FormControl fullWidth>
            <InputLabel id="Barrio-label">Barrio</InputLabel>
            <Select
                required
                labelId="Barrio-label"
                id="Barrio-select"
                // convierte number a string para el Select
                value={barrio === '' ? '' : barrio.toString()}
                label="Barrio"
                onChange={handleChange}
                disabled={disabled}
            >
            {loading ? (
                <MenuItem disabled>Cargando...</MenuItem>
            ) : (
                barrios.map((b) => (
                <MenuItem 
                    key={b.IdBarrio} 
                    value={b.IdBarrio.toString()}>
                    {b.Barrio}
                </MenuItem>
                ))
            )}
            </Select>
        </FormControl>
        </Grid>
    );
}
