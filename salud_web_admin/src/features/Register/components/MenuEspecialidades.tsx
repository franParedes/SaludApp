// src/features/Register/components/MenuEspecialidades.tsx

import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
// La ruta se ajusta para anticipar el archivo de barril en src/hooks/index.ts
import useEspecialidades from "../../../hooks/useEspecialidades"; 

type EspecialidadSelectProps = {
    especialidad: number | ''; // Se usa 'especialidad' en lowerCamelCase
    setEspecialidad: (value: number | '') => void;
};

// Se ajusta la destructuración de props para usar 'especialidad' en lowerCamelCase
export default function MenuEspecialidades({ especialidad, setEspecialidad }: EspecialidadSelectProps) {
    // Se usa 'especialidades' en lowerCamelCase para la destructuración, asumiendo que el hook se ajustó.
    const { especialidades, loading } = useEspecialidades(); 
    
    const handleChange = (event: SelectChangeEvent) => {
        // Convierte el valor a número antes de pasarlo al estado del componente padre
        setEspecialidad(Number(event.target.value));
    };

    return (
        <Grid size={13}> {/* Nota: Grid usa prop 'item' y tamaños 'xs', 'sm', etc., no 'size' */}
            <FormControl fullWidth>
                <InputLabel id="Especialidad-label">Especialidades</InputLabel>
                <Select
                    required
                    labelId="Especialidad-label"
                    id="Especialidad-select"
                    // Mantiene el valor como string para el Select de MUI
                    value={especialidad === '' ? '' : especialidad.toString()}
                    label="Especialidades"
                    onChange={handleChange}
                    disabled={loading} // Deshabilitar mientras carga
                >
                    {loading ? (
                        <MenuItem disabled value="">Cargando...</MenuItem>
                    ) : (
                        especialidades.map((e) => (
                            <MenuItem 
                                key={e.IdEspecialidad} 
                                value={e.IdEspecialidad.toString()}
                            >
                                {e.Especialidad}
                            </MenuItem>
                        ))
                    )}
                </Select>
            </FormControl>
        </Grid>
    );
}