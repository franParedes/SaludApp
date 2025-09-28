import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import { useCentrosMedicos } from "../../../../hooks/useCentrosMedicos";

type CentroMedicoSelectProps = {
    c_medico: number | '';
    setC_medico: (value: number | '') => void;
};

export default function MenuCentrosMedicos({ c_medico, setC_medico }: CentroMedicoSelectProps) {
    const { centro, loading } = useCentrosMedicos();

    const handleChange = (event: SelectChangeEvent) => {
        setC_medico(Number(event.target.value));
    };

    return (
        <Grid size={{ xs: 12, sm: 6 }}>
        <FormControl fullWidth>
            <InputLabel id="CentroM-label">Centro actual</InputLabel>
            <Select
                required
                labelId="CentroM-label"
                id="CentroM-select"
                // convierte number a string para el Select
                value={c_medico === '' ? '' : c_medico.toString()}
                label="Centro actual"
                onChange={handleChange}
            >
            {loading ? (
                <MenuItem disabled>Cargando...</MenuItem>
            ) : (
                centro.map((cm) => (
                <MenuItem 
                    key={cm.IdCentro} 
                    value={cm.IdCentro.toString()}>
                    {cm.Centro}
                </MenuItem>
                ))
            )}
            </Select>
        </FormControl>
        </Grid>
    );
}
