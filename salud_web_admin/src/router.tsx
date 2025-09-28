import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginView from "./Presentation/Login/LoginView";
import RegisterView from "./Presentation/Register/RegisterView";
import AuthLayout from "./Presentation/Layout/AuthLayout";
import Landing_Page from "./Presentation/Landing_Page/LandingView";
import Dashboard from "./Presentation/Dashboard/DashboardView";

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