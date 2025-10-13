import { Button, CircularProgress, Snackbar, Alert as MuiAlert } from '@mui/material';
import logo from '../../assets/logos/Logo.png';
import { Link, useNavigate } from 'react-router-dom';
import RegisterForm from './components/RegisterForm';
import PasswordFields from './components/PasswordFields';
import { useCrearMedico } from '../../hooks/useMedico';
import { useCrearAdministrador } from '../../hooks/useAdministrador'; 
import { useCrearUsuarioRegistro } from '../../hooks/useUsuarioRegistro';
import { useCrearRecepcionista } from '../../hooks/useRecepcionista'; 
import { type Recepcionista } from '../../types/Recepcionista';
import { type Medico } from '../../types/Medico';
import { type Administrador } from '../../types/Administrador';
import { type UsuarioRegistro } from '../../types/UsuarioRegistro';
import { type UsuarioModel, type DireccionModel, type TelefonoModel } from '../../types/UsuarioModel';
import { useState } from 'react';


const ID_MEDICO = 1;
const ID_ADMIN = 2;
const ID_RECEPCIONISTA = 3;
const ID_REGISTRO = 4;

interface FormData {
    primerNombre?: string;
    segundoNombre?: string;
    primerApellido?: string;
    segundoApellido?: string;
    cedula?: string;
    correo?: string;
    fechaNacimiento?: string;
    genero?: number | string | null;
    tipo?: number | string | null;
    codSanitario?: string | null;
    especialidad?: number | string | null;
    universidad?: number | string | null;
    egresadoEl?: string | null;
    experienciaAnios?: number | string | null;
    area?: number | string | null;
    c_medico?: number | string | null;
    turno?: number | string | null;
    telefono?: number | string | null;
    proveedor?: number | string | null;
    departamentos?: number | string | null;
    municipio?: number | string | null;
    barrio?: number | string | null;
    direccionFisica?: string | null;
}

// --- FUNCIONES AUXILIARES CRÍTICAS PARA MANEJO DE NULLS (SE MANTIENEN IGUAL) ---
const normalizeValue = (value: any): string | number | null => {
    if (value === null || value === undefined || value === "") {
        return null;
    }
    if (typeof value === 'string' && value.trim() === '0') return 0;
    return value;
};

const getNullableNumber = (value: any): number | null => {
    const normalized = normalizeValue(value);
    if (normalized === null) return null;

    const num = Number(normalized);

    if (isNaN(num) || num === 0) {
        return null;
    }

    return num;
};
// -----------------------------------------------------------

function RegisterView() {
    const navigate = useNavigate();
    
    // Inicialización de Hooks
    const { crearMedico, loading: loadingMedico, error: errorMedico } = useCrearMedico();
    const { crearAdministrador, loading: loadingAdmin, error: errorAdmin } = useCrearAdministrador();
    const { crearUsuarioRegistro, loading: loadingRegistro, error: errorRegistro } = useCrearUsuarioRegistro();
    const { crearRecepcionista, loading: loadingRecepcionista, error: errorRecepcionista } = useCrearRecepcionista(); // 👈 NUEVO HOOK

    // Consolidar estado de carga y error
    const loading = loadingMedico || loadingAdmin || loadingRegistro || loadingRecepcionista; // 👈 INCLUIR Recepcionista
    const error = errorMedico || errorAdmin || errorRegistro || errorRecepcionista; // 👈 INCLUIR Recepcionista
    
    const [formData, setFormData] = useState<FormData>({});
    const [passwordData, setPasswordData] = useState({ contrasenya: '', confirmarContrasenya: '' });
    const [openSnackbar, setOpenSnackbar] = useState(false);
    const [snackbarMessage, setSnackbarMessage] = useState("");
    const [snackbarSeverity, setSnackbarSeverity] = useState<"success" | "error">("success");

    const isFormValid = (): boolean => {
        const tipo = Number(formData.tipo);

        if (!passwordData.contrasenya || passwordData.contrasenya.length < 6) return false;
        if (passwordData.contrasenya !== passwordData.confirmarContrasenya) return false;
        if (!formData.cedula || !formData.primerNombre || !formData.primerApellido || !formData.correo) return false;
        if (!tipo) return false; // El tipo de usuario es requerido

        // Validación específica para MÉDICOS (Tipo 1)
        if (tipo === ID_MEDICO) {
             if (!formData.codSanitario || !formData.especialidad) return false;
        }
        
        // Validación específica para ADMINISTRADOR (Tipo 2)
        if (tipo === ID_ADMIN) {
             if (!formData.c_medico) return false; // El Centro Médico es requerido para el Admin
        }
        
        // VALIDACIÓN ESPECÍFICA PARA RECEPCIONISTA (Tipo 3)
        if (tipo === ID_RECEPCIONISTA) {
             if (!formData.c_medico || !formData.turno) return false; // Centro y Turno requeridos
        }
        
        // VALIDACIÓN ESPECÍFICA PARA PERSONAL DE REGISTRO (Tipo 4)
        if (tipo === ID_REGISTRO) {
             if (!formData.c_medico || !formData.turno) return false; // Centro y Turno requeridos
        }
        
        return true;
    };

    /**
     * Construye el payload base (campos de UsuarioModel) a partir de FormData.
     */
     const buildBasePayload = (): UsuarioModel => {
        
        const telefonoPayload: TelefonoModel[] = [];
        const telefonoNum = getNullableNumber(formData.telefono);
        const proveedorNum = getNullableNumber(formData.proveedor);

        if (telefonoNum !== null && proveedorNum !== null) {
            telefonoPayload.push({
                Telefono: telefonoNum,
                Compania: proveedorNum,
            } as TelefonoModel);
        }
        
        const direccionesPayload: DireccionModel[] = [];
        const dpto = getNullableNumber(formData.departamentos);
        const municipio = getNullableNumber(formData.municipio);
        const barrio = getNullableNumber(formData.barrio);
        
        const direccion = normalizeValue(formData.direccionFisica) as string || "Dirección de Residencia"; 

        if (dpto !== null && municipio !== null && barrio !== null) {
             direccionesPayload.push({
                Departamento: dpto,
                Municipio: municipio,
                Barrio: barrio,
                Direccion: direccion, 
             } as DireccionModel);
        }

        return {
            Cedula: formData.cedula || "",
            PrimerNombre: normalizeValue(formData.primerNombre) as string || null,
            SegundoNombre: normalizeValue(formData.segundoNombre) as string || null,
            PrimerApellido: formData.primerApellido || "",
            SegundoApellido: normalizeValue(formData.segundoApellido) as string || null,
            Correo: formData.correo || "",
            Contrasenya: passwordData.contrasenya,
            Genero: getNullableNumber(formData.genero) || 0,
            FechaNacimiento: normalizeValue(formData.fechaNacimiento) as string || "",
            TipoUsuario: getNullableNumber(formData.tipo) || 0,

            Telefonos: telefonoPayload,
            Direcciones: direccionesPayload,
        } as UsuarioModel;
    };


    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        if (!isFormValid()) {
            setSnackbarMessage("Por favor, complete todos los campos requeridos y revise la contraseña.");
            setSnackbarSeverity("error");
            setOpenSnackbar(true);
            return;
        }
        
        const tipo = Number(formData.tipo);
        let result = false;
        
        const basePayload = buildBasePayload();

        try {
            if (tipo === ID_MEDICO) {
                // 1. Lógica para MÉDICO
                const medicoPayload: Medico = {
                    ...basePayload,
                    Cod_sanitario: normalizeValue(formData.codSanitario) as string || "",
                    Especialidad: getNullableNumber(formData.especialidad) || 0, 
                    EgresadoDe: getNullableNumber(formData.universidad),
                    Experiencia_anyos: getNullableNumber(formData.experienciaAnios),
                    Area_actual: getNullableNumber(formData.area),
                    Centro_actual: getNullableNumber(formData.c_medico),
                    Turno_actual: getNullableNumber(formData.turno),
                    EgresadoEl: normalizeValue(formData.egresadoEl) as string || null,
                } as Medico;

                result = await crearMedico(medicoPayload);

            } else if (tipo === ID_ADMIN) {
                // 2. Lógica para ADMINISTRADOR
                const adminPayload: Administrador = {
                    ...basePayload,
                    Centro_actual: getNullableNumber(formData.c_medico) || null,
                } as Administrador;

                result = await crearAdministrador(adminPayload);

            } else if (tipo === ID_RECEPCIONISTA) { 
                // 3. PAYLOAD Y LLAMADA PARA RECEPCIONISTA
                const recepcionistaPayload: Recepcionista = {
                    ...basePayload,
                    // Usamos el tipo Recepcionista que contiene CentroActual y TurnoActual
                    CentroActual: getNullableNumber(formData.c_medico) || null,
                    TurnoActual: getNullableNumber(formData.turno) || null,
                } as Recepcionista;

                result = await crearRecepcionista(recepcionistaPayload);
            
            } else if (tipo === ID_REGISTRO) {
                // 4. Lógica para PERSONAL DE REGISTRO
                const registroPayload: UsuarioRegistro = {
                    ...basePayload,
                    CentroActual: getNullableNumber(formData.c_medico) || null,
                    TurnoActual: getNullableNumber(formData.turno) || null,
                } as UsuarioRegistro;

                result = await crearUsuarioRegistro(registroPayload); 

            } else {
                setSnackbarMessage(`Tipo de usuario (ID ${tipo}) no implementado para registro.`);
                setSnackbarSeverity("error");
                setOpenSnackbar(true);
                return;
            }
        } catch (err: any) {
            result = false; 
        }

        // --- MANEJO DE RESULTADO ---
        if (result) {
            setSnackbarMessage("Usuario creado con éxito");
            setSnackbarSeverity("success");
            setOpenSnackbar(true);

            setTimeout(() => {
                navigate('/auth/login');
            }, 3000);
        } else {
            setSnackbarMessage(error || "Error al crear usuario. Revisa la consola para más detalles.");
            setSnackbarSeverity("error");
            setOpenSnackbar(true);
        }
    };

    return (
        <>
            <form
                className="bg-stone-50 md:w-3/5 max-h-full flex flex-col gap-2 justify-center px-2 md:px-[2.5rem] items-center text-center overflow-y-auto"
                onSubmit={handleSubmit}
            >
                <h1 className="text-azul-claro font-bold text-4xl md:text-4xl md:pt-10 text-center">
                    Crear una cuenta en<span className="block py-5"> PacienteApp </span>
                </h1>

                <div className="overflow-y-auto max-h-[70vh] w-full md:pb-10">
                    <RegisterForm setFormData={setFormData} />
                    <PasswordFields setPasswordData={setPasswordData} />

                    <Button
                        variant="contained"
                        type="submit"
                        fullWidth
                        sx={{ mt: 3, paddingY: 1 }}
                        disabled={loading || !isFormValid()}
                    >
                        {loading ? <CircularProgress size={24} color="inherit" /> : "REGISTRARME"}
                    </Button>
                </div>
            </form>

            <div className="bg-azul-claro min-h-full flex flex-col gap-4 justify-center items-center py-[7.5rem] md:w-2/5 text-white text-center">
                <h1 className="font-bold text-4xl md:text-5xl">Bienvenido</h1>
                <p className="text-sm md:text-base px-7 md:px-15">
                    Para mantenerse conectado con nosotros, inicie sesión con su información personal.
                </p>
                <img src={logo} alt="Logo de la aplicación" className="py-7" />
                <Button
                    variant="outlined"
                    component={Link}
                    to="/auth/login"
                    sx={{ paddingX: 10, paddingY: 1, borderColor: 'white', color: 'white', boxShadow: 3 }}
                >
                    LOGIN
                </Button>
                <Snackbar
                    open={openSnackbar}
                    autoHideDuration={4000}
                    onClose={() => setOpenSnackbar(false)}
                    anchorOrigin={{ vertical: "top", horizontal: "center" }}
                >
                    <MuiAlert severity={snackbarSeverity} sx={{ width: "100%" }} onClose={() => setOpenSnackbar(false)}>
                        {snackbarMessage}
                    </MuiAlert>
                </Snackbar>
            </div>
        </>
    );
}

export default RegisterView;