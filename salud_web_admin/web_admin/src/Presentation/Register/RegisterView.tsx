import {  Button } from '@mui/material';
import logo from '../../assets/logos/Logo.png'
import { Link } from 'react-router-dom';
import Textfields from './Textfields/Textfields';

function RegisterView() {
  return (
    <> 
    {/* Lado izquierdo: Register */}
      <form 
          className="bg-stone-50 md:w-3/5 max-h-full flex flex-col gap-2
            justify-center px-2 md:px-[2.5rem] items-center text-center overflow-y-auto">
        <h1 className="text-azul-claro font-bold text-4xl md:text-4xl md:pt-10 text-center">
          Crear una cuenta en<span className="block py-5"> PacienteAppp </span>
        </h1>  
        <div className="overflow-y-auto max-h-[70vh] w-full md:pb-10">
          <Textfields />
        </div>
      </form>
    {/* Lado derecho: Bienvenido */}
      <div className="bg-azul-claro min-h-full flex flex-col gap-4 justify-center items-center py-[7.5rem] md:w-2/5 text-white text-center">
        <h1 className='font-bold text-4xl md:text-5xl'>Bienvenido</h1>
        <p className="text-sm md:text-base px-7 md:px-15">
          Para mantenerse conectado con 
          nosotros, inicie sesión con 
          su información personal.
        </p>
        <img 
          src={logo} 
          alt="Logo de la aplicación"
          className='py-7' 
        />
        <Button 
          variant="outlined"
          component={Link}
          to="/auth/login"
          sx={{paddingX: 10, paddingY: 1, borderColor: 'white', color: 'white', boxShadow: 3}}
        >
          LOGIN
        </Button>
      </div>
    </>
  )
}

export default RegisterView
