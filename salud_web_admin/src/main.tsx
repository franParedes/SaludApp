import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import Router from './router'
// 1. Importar el proveedor de autenticación
import { AuthProvider } from './context/AuthContext'; 


createRoot(document.getElementById('root')!).render(
  <StrictMode>
    {/* 2. Envolver el Router con el AuthProvider */}
    <AuthProvider>
      <Router />
    </AuthProvider>
  </StrictMode>,
)