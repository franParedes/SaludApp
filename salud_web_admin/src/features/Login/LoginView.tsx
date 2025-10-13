// src/features/Login/LoginView.tsx

import { Button, Divider, CircularProgress, Snackbar, Alert as MuiAlert, TextField } from '@mui/material';
import { Link, useNavigate } from 'react-router-dom';
import { useState } from 'react';
import { useLogin } from '../../hooks/useLogin'; 

// Importación de assets desde la ruta global
import logo from '../../assets/logos/Logo.png'; 
import GoogleLogo from '../../assets/logos/GoogleIcon.png';


function LoginView() {
    const navigate = useNavigate();
    const { login, loading, error } = useLogin();

    // Estados para el formulario
    const [correo, setCorreo] = useState('');
    const [contrasenya, setContrasenya] = useState('');
    
    // Estados para el Snackbar
    const [openSnackbar, setOpenSnackbar] = useState(false);
    const [snackbarMessage, setSnackbarMessage] = useState("");
    const [snackbarSeverity, setSnackbarSeverity] = useState<"success" | "error">("error");

    const isFormValid = correo.length > 0 && contrasenya.length > 0;

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();

        if (!isFormValid) {
            setSnackbarMessage("Por favor, introduce tu correo y contraseña.");
            setSnackbarSeverity("error");
            setOpenSnackbar(true);
            return;
        }

        const success = await login(correo, contrasenya);

        if (success) {
            setSnackbarMessage("Inicio de sesión exitoso. Redirigiendo...");
            setSnackbarSeverity("success");
            setOpenSnackbar(true);
            
            setTimeout(() => {
                navigate('/home');
            }, 1500);

        } else {
            setSnackbarMessage(error || "credenciales invalidas!");
            setSnackbarSeverity("error");
            setOpenSnackbar(true);
        }
    };

    const handleCloseSnackbar = () => setOpenSnackbar(false);

    return (
        <>
            {/* Lado izquierdo: Bienvenida (Presentacional) */}
            <div className="bg-azul-claro min-h-full flex flex-col gap-4 justify-center items-center py-[7.5rem] md:w-2/5 text-white text-center">
                <h1 className='font-bold text-4xl md:text-5xl'>Bienvenido</h1>
                <p className="text-sm md:text-base px-7 md:px-15">
                    Introduce tus datos personales 
                    y comienza tu viaje con nosotros.
                </p>
                <img 
                    src={logo} 
                    alt="Logo de la aplicación"
                    className='py-7' 
                />
                <Button 
                    variant="outlined"
                    component={Link}
                    to="/auth/register"
                    sx={{paddingX: 5, paddingY: 1, borderColor: 'white', color: 'white', boxShadow: 3}}
                >
                    REGISTRARSE
                </Button>
            </div>
                
            {/* Lado derecho: Login (Formulario) */}
            <form 
                className="bg-stone-50 md:w-3/5 min-h-full flex flex-col gap-7 justify-center px-4 md:px-[7rem] items-center text-center"
                onSubmit={handleLogin} // Asignamos la función de manejo de envío
            >
                <h1 className="text-azul-claro font-bold text-4xl md:text-4xl text-center">
                    Iniciar sesión en <span className="block py-5"> PacienteApp </span>
                </h1>

                {/* Campos de texto integrados para simplificar el estado */}
                <TextField
                    label="Correo"
                    type="email"
                    variant="outlined"
                    fullWidth
                    required
                    value={correo}
                    onChange={(e) => setCorreo(e.target.value)}
                />
                <TextField
                    label="Contraseña"
                    type="password"
                    variant="outlined"
                    fullWidth
                    required
                    value={contrasenya}
                    onChange={(e) => setContrasenya(e.target.value)}
                />
                
                <Button 
                    variant="contained"
                    type="submit" // Cambiado de component={Link} a type="submit"
                    fullWidth 
                    sx={{ mt:1, paddingY: 1 }}
                    disabled={loading || !isFormValid} // Deshabilitar si está cargando o no es válido
                >
                    {loading ? <CircularProgress size={24} color="inherit" /> : 'ACCEDER'}
                </Button>

                <Divider sx={{my: 2, width: '100%' }}>
                    <span className="text-gray-500 text-sm">o inicia con</span>
                </Divider>

                <Button 
                    variant="outlined"
                    startIcon={
                        <img 
                            src={GoogleLogo} 
                            alt="Google logo" 
                            style={{ width: 30, height: 30 }} 
                        />
                    }
                    sx={{paddingX: 3, paddingY: 2, fontWeight: "bold", textTransform: "none", fontSize: 14}}
                >
                    INICIAR SESION CON GOOGLE
                </Button>
            </form>

            {/* Snackbar para notificaciones */}
            <Snackbar
                open={openSnackbar}
                autoHideDuration={4000}
                onClose={handleCloseSnackbar}
                anchorOrigin={{ vertical: "top", horizontal: "center" }}
            >
                <MuiAlert 
                    severity={snackbarSeverity} 
                    sx={{ width: "100%" }} 
                    onClose={handleCloseSnackbar}
                >
                    {snackbarMessage}
                </MuiAlert>
            </Snackbar>
        </>
    );
}

export default LoginView;