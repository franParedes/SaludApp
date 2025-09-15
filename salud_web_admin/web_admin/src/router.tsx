import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginView from "./Presentation/Login/LoginView";
import RegisterView from "./Presentation/Register/RegisterView";
import AuthLayout from "./Presentation/Layout/AuthLayout";

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<AuthLayout />}>
          <Route path="/auth/login" element={<LoginView />} />
          <Route path="/auth/register" element={<RegisterView />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}