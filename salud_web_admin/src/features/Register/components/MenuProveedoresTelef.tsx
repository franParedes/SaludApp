import { Box, FormControl, Grid, InputLabel, MenuItem, Select, TextField, type SelectChangeEvent } from "@mui/material";
import { useProveedores } from "../../../hooks/useProveedores";
import logoTigo from "../../../assets/logos/logoTigo.png";
import logoClaro from "../../../assets/logos/logoClaro.png";
import logoCootel from "../../../assets/logos/logoCootel.jpg";

type ProveedoresSelectProps = {
    proveedor: number | '';
    setProveedor: (value: number | '') => void;
    telefono: string;
    setTelefono: (value: string) => void;
};

export default function MenuProveedoresTelef({ proveedor, setProveedor, telefono, setTelefono }: ProveedoresSelectProps) {
    const { proveedores, loading } = useProveedores();

    const handleChange = (event: SelectChangeEvent) => {
        setProveedor(Number(event.target.value));
    };

    const logos: Record<string, string> = {
        Tigo: logoTigo,
        Claro: logoClaro,
        Cootel: logoCootel,
    };

    return (
        <Grid size={{ xs: 12 }}>
            <Grid container spacing={2}>
                <Grid size={{ xs: 12, sm: 6 }}>
                 <TextField
                    required
                    label="Teléfono"
                    type="tel"
                    fullWidth
                   value={telefono.length === 8 ? telefono.slice(0, 4) + "-" + telefono.slice(4) : telefono}
                    onChange={(e) => {
                       let input = e.target.value.replace(/\D/g, ""); // solo números
                        if (input.length > 8) input = input.slice(0, 8);
                        setTelefono(input); // aquí guardas limpio "88881234"
                    }}
                />
                </Grid>

                <Grid size={{ xs: 12, sm: 6 }}>
                    <FormControl fullWidth>
                        <InputLabel id="proveedor-label">Compañía</InputLabel>
                        <Select
                            required
                            labelId="proveedor-label"
                            label="Compañía"
                            value={proveedor === '' ? '' : proveedor.toString()}
                            onChange={handleChange}
                            renderValue={(selected: unknown) => {
                                const selectedProv = proveedores.find(
                                    (p) => p.IdProvTel === Number(selected)
                                );
                                return (
                                    <Box display="flex" alignItems="center">
                                        <img
                                            src={logos[selectedProv?.Proveedor || ""]}
                                            alt={selectedProv?.Proveedor}
                                            width={24}
                                            style={{ marginRight: 8 }}
                                        />
                                        {selectedProv?.Proveedor}
                                    </Box>
                                );
                            }}
                            >
                            {loading ? (
                                <MenuItem disabled>Cargando...</MenuItem>
                            ) : (
                                proveedores.map((pro) => (
                                    <MenuItem key={pro.IdProvTel} value={pro.IdProvTel}>
                                        <Box display="flex" alignItems="center">
                                            <img
                                                src={logos[pro.Proveedor]}
                                                alt={pro.Proveedor}
                                                width={24}
                                                style={{ marginRight: 8 }}
                                            />
                                            {pro.Proveedor}
                                        </Box>
                                    </MenuItem>
                                ))
                            )}
                        </Select>
                    </FormControl>
                </Grid>
            </Grid>
        </Grid>
    );
}
