import { BrowserRouter, Routes, Route } from "react-router-dom";
import PublicRouteGuard from "./utils/PublicRouteGuard"; 
// 1. Importar el nuevo componente
import PrivateRouteGuard from "./utils/PrivateRouteGuard"; 
// Rutas
import LoginView from "./features/Login/LoginView";
import RegisterView from "./features/Register/RegisterView";
import AuthLayout from "./layout/AuthLayout";
import Landing_Page from "./pages/LandingPage";
import Dashboard from "./features/Dashboard/DashboardView";

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Landing_Page />} index />
        
        {/* 🚀 CAMBIO CLAVE: Rutas Protegidas (Solo si hay sesión) */}
        <Route element={<PrivateRouteGuard />}>
          <Route path="/home" element={<Dashboard />} />
          {/* Puedes añadir más rutas que requieran autenticación aquí */}
        </Route>

        {/* Rutas Públicas Protegidas (Solo si NO hay sesión) */}
        <Route element={<PublicRouteGuard />}>
          <Route element={<AuthLayout />}>
             <Route path="/auth/login" element={<LoginView />} />
             <Route path="/auth/register" element={<RegisterView />} />
          </Route>
        </Route>
        
      </Routes>
    </BrowserRouter>
  );
}