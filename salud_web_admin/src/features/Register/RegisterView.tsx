import { Button, CircularProgress, Snackbar, Alert as MuiAlert } from '@mui/material';
// RUTA ACTUALIZADA: El logo se mantiene en la carpeta 'assets'
import logo from '../../assets/logos/Logo.png';
import { Link } from 'react-router-dom';
// RUTA ACTUALIZADA: Textfields es ahora RegisterForm en la misma feature
import RegisterForm from './components/RegisterForm'; 
// RUTA ACTUALIZADA: Los hooks ahora se importan desde 'src/hooks'
// Asumimos que usaremos archivos de barril para simplificar: 'src/hooks' -> 'src/hooks'
import { useCrearMedico } from '../../hooks/useMedico';
import {type Medico} from '../../types/Medico'; // O bien, si usas la sintaxis de TS 5.x:
// import { useCrearMedico, type Medico } from '../../../hooks/useMedico';
import { useState } from 'react';

// Se mantiene el tipo FormData, aunque se recomienda moverlo a src/types/register.ts
interface FormData {
  primerNombre?: string;
  segundoNombre?: string;
  primerApellido?: string;
  segundoApellido?: string;
  cedula?: string;
  correo?: string;
  fechaNacimiento?: string;
  genero?: number | string;
  tipo?: number | string;
  codSanitario?: string;
  especialidad?: number | string;
  universidad?: number | string;
  egresadoEl?: string;
  experienciaAnios?: number | string; // Aseguramos que sea string si viene de input, aunque el estado interno del form lo maneje como number
  area?: number | string;
  c_medico?: number | string;
  turno?: number | string;
  telefono?: number | string;
  proveedor?: number | string;
}

function RegisterView() {
    // ASUMIMOS: useCrearMedico y Medico se exportan desde el archivo de barril 'src/hooks/index.ts'
    const { crearMedico, loading, error } = useCrearMedico();
    const [formData, setFormData] = useState<FormData>({});
    const [openSnackbar, setOpenSnackbar] = useState(false);
    const [snackbarMessage, setSnackbarMessage] = useState("");
    const [snackbarSeverity, setSnackbarSeverity] = useState<"success" | "error">("success");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    // Conversión de tipos de string a number para el payload de la API
    const medicoPayload: Medico = {
      nombre: formData.primerNombre || "",
      apellido: formData.primerApellido || "",
      // Conversiones a Number
      especialidad: Number(formData.especialidad) || 0,
      telefono: Number(formData.telefono) || 0,
      GeneralInfo: {
        Cedula: formData.cedula || "",
        PrimerNombre: formData.primerNombre || "",
        SegundoNombre: formData.segundoNombre || "",
        PrimerApellido: formData.primerApellido || "",
        SegundoApellido: formData.segundoApellido || "",
        Correo: formData.correo || "",
        Genero: Number(formData.genero) || 0,
        FechaNacimiento: formData.fechaNacimiento || "",
        TipoUsuario: Number(formData.tipo) || 0,
      },
      Cod_sanitario: formData.codSanitario || "",
      Especialidad: Number(formData.especialidad) || 0,
      EgresadoDe: Number(formData.universidad) || 0,
      EgresadoEl: formData.egresadoEl || "",
      Experiencia_anyos: Number(formData.experienciaAnios) || 0,
      Area_actual: Number(formData.area) || 0,
      Centro_actual: Number(formData.c_medico) || 0,
      Turno_actual: Number(formData.turno) || 0,
        Telefonos: [
        {
          Telefono: Number(formData.telefono) || 0,
          Compania: Number(formData.proveedor) || 0
        }
      ]
    };

    const result = await crearMedico(medicoPayload);
    if (result) {
      setSnackbarMessage("Médico creado con éxito");
      setSnackbarSeverity("success");
    } else {
      setSnackbarMessage(error || "Error al crear médico");
      setSnackbarSeverity("error");
    }
    setOpenSnackbar(true);
    console.log("medicoPayload:", medicoPayload);
  };

  return (
    <>
      {/* Lado izquierdo: Register */}
      <form
        className="bg-stone-50 md:w-3/5 max-h-full flex flex-col gap-2 justify-center px-2 md:px-[2.5rem] items-center text-center overflow-y-auto"
        onSubmit={handleSubmit}
      >
        <h1 className="text-azul-claro font-bold text-4xl md:text-4xl md:pt-10 text-center">
          Crear una cuenta en<span className="block py-5"> PacienteAppp </span>
        </h1>

        <div className="overflow-y-auto max-h-[70vh] w-full md:pb-10">
          {/* NOMBRE DE COMPONENTE ACTUALIZADO */}
          <RegisterForm setFormData={setFormData} /> 

          <Button
            variant="contained"
            type="submit"
            fullWidth
            sx={{ mt: 3, paddingY: 1 }}
            disabled={loading}
          >
            {loading ? <CircularProgress size={24} color="inherit" /> : "REGISTRARME"}
          </Button>
        </div>
      </form>

      {/* Lado derecho: Bienvenido */}
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
        {/* Snackbar */}
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