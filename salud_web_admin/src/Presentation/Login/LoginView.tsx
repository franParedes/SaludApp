import {  Button, Divider } from '@mui/material';
import logo from '../../assets/logos/Logo.png'
import GoogleLogo from '../../assets/logos/GoogleIcon.png'
import { Link } from 'react-router-dom';
import Textfields from './Textfields/Textfields';


function LoginView() {

  return (
    <>
      {/* Lado izquierdo: Bienvenida */}
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
        {/* Lado derecho: Login */}
      <form 
        className="bg-stone-50 md:w-3/5 min-h-full flex flex-col gap-7 justify-center px-4 md:px-[7rem] items-center text-center"
      >
        <h1 className="text-azul-claro font-bold text-4xl md:text-4xl text-center">
          Iniciar sesión en <span className="block py-5"> PacienteAppp </span>
        </h1>

        <Textfields />

        <Button 
          variant="contained"
          component={Link}
          to="/home"
          fullWidth 
          sx={{ mt:1, paddingY: 1 }}
        >
          Login
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
    </>
  );
}

export default LoginView
