import { BrowserRouter, Routes, Route } from "react-router-dom";
// Rutas actualizadas a la carpeta 'features'
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
        <Route path="/home" element={<Dashboard />} />

        <Route element={<AuthLayout />}>
          <Route path="/auth/login" element={<LoginView />} />
          <Route path="/auth/register" element={<RegisterView />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}