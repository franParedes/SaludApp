import { TextField, Button } from '@mui/material';
import { ThemeProvider } from '@mui/material/styles';
import theme from '../mui/App_MUI';

function Login() {

  return (
    <>
    <ThemeProvider theme={theme}>
      <div className="p-0 m-0 w-full min-h-screen flex justify-center items-center">
        <div className="w-4xl h-[40rem] flex rounded-[2rem] overflow-hidden shadow-xl/30">
          <div className="bg-azul-claro w-2/5 min-h-full flex flex-col gap-5 justify-center items-center">
            <h1 className='font-bold'>Bienvenido</h1>
            <Button variant="outlined">REGISTRARSE</Button>
       
      
          </div>
          <div className="bg-stone-50 w-3/5 min-h-full">

          </div>
        </div>
      </div>
      </ThemeProvider>
    </>
  );
}

export default Login
