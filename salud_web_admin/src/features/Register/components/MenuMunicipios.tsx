//src\Presentation\Register\Textfields\MenuSelects\MenuMunicipios.tsx
import { FormControl, Grid, InputLabel, MenuItem, Select, type SelectChangeEvent } from "@mui/material";
import useMunicipios from "../../../hooks/useMunicipios";
import type { Municipio } from "../../../types/Municipio";

type MunicipioSelectProps = {
    departamentoId: number | null;
    municipio: number | '';
    setMunicipio: (value: number | '') => void;
    disabled?: boolean;
};

export default function MenuMunicipios({ departamentoId, municipio, setMunicipio,  disabled = false }: MunicipioSelectProps) {
    const { municipios, loading } = useMunicipios(departamentoId);

    const handleChange = (event: SelectChangeEvent) => {
        setMunicipio(Number(event.target.value));
    };

    return (
        <Grid size={{ xs: 12, sm: 6 }}>
        <FormControl fullWidth>
            <InputLabel id="Municipio-label">Municipio</InputLabel>
            <Select
                required
                labelId="Municipio-label"
                id="Municipio-select"
                value={municipio === '' ? '' : municipio.toString()}
                label="Municipio"
                onChange={handleChange}
                disabled={disabled}
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