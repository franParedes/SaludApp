import { ThemeProvider } from '@mui/material/styles';
import theme from '../../mui_global/App_MUI';
import { Outlet } from "react-router-dom"

export default function AuthLayout() {
  return (
    <>
    {/* ThemeProvider para gestionar los estilos de los componentes de MUI (Material Design)*/}
        <ThemeProvider theme={theme}>
        <div className="w-full min-h-screen flex justify-center items-center">
            <div className="flex w-full max-w-4xl h-auto rounded-4xl overflow-hidden shadow-xl/30">
            {/* Plantilla de nuestras pages */}
            {/* Anclaje entre las demas rutas */}
                <Outlet /> 
            </div>
        </div>
        </ThemeProvider>
    </>
  )
}
