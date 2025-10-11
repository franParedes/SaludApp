// src/layout/AuthLayout.tsx

import { ThemeProvider } from '@mui/material/styles';
import theme from '../mui_global/theme'; // La ruta se ajusta al nuevo directorio de configuración
import { Outlet } from "react-router-dom"

export default function AuthLayout() {
  return (
    <>
      {/* ThemeProvider para gestionar los estilos de los componentes de MUI */}
      <ThemeProvider theme={theme}>
        <div className="w-full min-h-screen flex justify-center items-center">
          <div className="flex w-full max-w-4xl h-auto rounded-4xl overflow-hidden shadow-xl/30">
            {/* El componente Outlet renderiza la ruta secundaria que coincida (ej: LoginPage) */}
            <Outlet /> 
          </div>
        </div>
      </ThemeProvider>
    </>
  )
}