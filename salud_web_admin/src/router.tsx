// Router.tsx (Versión Final con CitasPage)

import { BrowserRouter, Routes, Route } from "react-router-dom";
import PublicRouteGuard from "./utils/PublicRouteGuard";
import PrivateRouteGuard from "./utils/PrivateRouteGuard";
// Rutas
import LoginView from "./features/Login/LoginView";
import RegisterView from "./features/Register/RegisterView";
import AuthLayout from "./layout/AuthLayout";
import Landing_Page from "./pages/LandingPage";
import Dashboard from "./features/Dashboard/DashboardView";

// 1. ⚠️ Corregir Import: Usaremos 'MarcoPrincipal' si así se llama tu archivo de layout.
// El import original en el código que pegaste es 'MenuPrincipal', si el archivo es 'MarcoPrincipal.tsx', debe coincidir.
import MarcoPrincipal from "./layout/MarcoPrincipal";
// ^^^ ASUMIENDO que tu archivo se llama 'MarcoPrincipal.tsx' y está en el path './layout/'

// 2. 🚀 Importar la nueva vista de Citas
import CitasPage from "./features/Citas/CitasPage";
import PacientesListView from "./features/Pacientes/PacientesListView";
import CrearPacienteForm from "./features/Pacientes/CrearPacienteForm";

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Landing_Page />} index />

        {/* Rutas Protegidas Anidadas */}
        <Route element={<PrivateRouteGuard />}>
          <Route element={<MarcoPrincipal />}>

            <Route path="/home" element={<Dashboard />} />
            <Route path="/citas" element={<CitasPage />} />

            {/* GESTIÓN DE PACIENTES */}
            <Route path="/pacientes" element={<PacientesListView />} />
            <Route path="/pacientes/nuevo" element={<CrearPacienteForm />} /> {/* 🚀 NUEVA RUTA */}

          </Route>
        </Route>

        {/* Rutas Públicas Protegidas (No cambian) */}
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