// src/features/Register/components/MenuBarrio.tsx

import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
// La ruta se ajusta para anticipar el archivo de barril en src/hooks/index.ts
import useBarrios from "../../../hooks/useBarrios"; 

type BarrioSelectProps = {
    municipioId: number | null;
    barrio: number | '';
    setBarrios: (value: number | '') => void;
    disabled?: boolean;
};

export default function MenuBarrio({municipioId, barrio, setBarrios, disabled = false} : BarrioSelectProps) {
    const { barrios, loading } = useBarrios(municipioId);

    const handleChange = (event: SelectChangeEvent) => {
        // Convierte el valor a número antes de pasarlo al estado del componente padre
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
                    // Mantiene el valor como string para el Select de MUI
                    value={barrio === '' ? '' : barrio.toString()}
                    label="Barrio"
                    onChange={handleChange}
                    disabled={disabled || loading} // Deshabilitar si está cargando
                >
                    {/* Opción por defecto o de carga */}
                    {loading && <MenuItem disabled value="">Cargando...</MenuItem>}
                    
                    {/* Renderiza los barrios si no está cargando */}
                    {!loading && barrios.map((b) => (
                        <MenuItem 
                            key={b.IdBarrio} 
                            value={b.IdBarrio.toString()}>
                            {b.Barrio}
                        </MenuItem>
                    ))}
                    
                    {/* Si no hay barrios y no está cargando, mostrar mensaje */}
                    {!loading && barrios.length === 0 && municipioId !== null && (
                        <MenuItem disabled>No hay barrios para el municipio seleccionado</MenuItem>
                    )}
                </Select>
            </FormControl>
        </Grid>
    );
}