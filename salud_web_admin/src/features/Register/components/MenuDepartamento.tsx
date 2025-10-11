// src/features/Register/components/MenuDepartamento.tsx

import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
// La ruta se ajusta para anticipar el archivo de barril en src/hooks/index.ts
import useDepartamentos from "../../../hooks/useDepartamentos"; 

type DepartamentoSelectProps = {
    // Es mejor nombrar la prop en singular si representa el valor seleccionado
    departamento: number | '';
    setDepartamento: (value: number | '') => void;
};

// Se ajusta la destructuración de props para usar 'departamento' en singular
export default function MenuDepartamento({departamento, setDepartamento} : DepartamentoSelectProps) {
    const { departamentos, loading } = useDepartamentos(); // Nota: 'Departamento' debería ser 'departamentos' para consistencia con el hook.

    const handleChange = (event: SelectChangeEvent) => {
        // Convierte el valor a número antes de pasarlo al estado del componente padre
        setDepartamento(Number(event.target.value));
    };

    return (
        <Grid size={{ xs: 12 }}>
            <FormControl fullWidth>
                <InputLabel id="Departamento-label">Departamento</InputLabel>
                <Select
                    required
                    labelId="Departamento-label"
                    id="Departamento-select"
                    // Mantiene el valor como string para el Select de MUI
                    value={departamento === '' ? '' : departamento.toString()}
                    label="Departamento"
                    onChange={handleChange}
                    disabled={loading}
                >
                    {loading ? (
                        <MenuItem disabled value="">Cargando...</MenuItem>
                    ) : (
                        departamentos.map((d) => (
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