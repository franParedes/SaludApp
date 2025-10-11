// src/features/Register/components/MenuCentrosMedicos.tsx

import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
// La ruta se ajusta para anticipar el archivo de barril en src/hooks/index.ts
import { useCentrosMedicos } from "../../../hooks/useCentrosMedicos"; 

type CentroMedicoSelectProps = {
    c_medico: number | '';
    setC_medico: (value: number | '') => void;
};

export default function MenuCentrosMedicos({ c_medico, setC_medico }: CentroMedicoSelectProps) {
    const { centros, loading } = useCentrosMedicos();

    const handleChange = (event: SelectChangeEvent) => {
        // Convierte el valor a número antes de pasarlo al estado del componente padre
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
                    // Mantiene el valor como string para el Select de MUI
                    value={c_medico === '' ? '' : c_medico.toString()}
                    label="Centro actual"
                    onChange={handleChange}
                    disabled={loading} // Deshabilitar mientras carga
                >
                    {loading ? (
                        <MenuItem disabled value="">Cargando...</MenuItem>
                    ) : (
                        centros.map((cm) => (
                            <MenuItem 
                                key={cm.IdCentro} 
                                value={cm.IdCentro.toString()}
                            >
                                {cm.Centro}
                            </MenuItem>
                        ))
                    )}
                </Select>
            </FormControl>
        </Grid>
    );
}