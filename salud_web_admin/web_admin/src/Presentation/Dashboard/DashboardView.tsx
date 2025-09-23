import { AppBar, Toolbar, IconButton, Typography, Button } from "@mui/material";
import "dayjs/locale/es";
import MenuIcon from "@mui/icons-material/Menu";
import CardItem from "./CardItem/useCart";
import Calendar from "./CalendarItem/Calendar";

function Dashboard() {
  return (
    <div className="min-h-screen w-full bg-gray-50 flex flex-col">
      {/* NAVBAR */}
      <AppBar position="static" sx={{ backgroundColor: "#0088FF" }}>
        <Toolbar className="flex justify-between">
          <div className="flex items-center gap-2">
            <IconButton size="large" edge="start" color="inherit">
              <MenuIcon />
            </IconButton>
            <Typography variant="h6" sx={{ fontWeight: "bold" }}>
              SaludApp
            </Typography>
          </div>
          <div className="flex gap-4">
            <Button color="inherit">Inicio</Button>
            <Button color="inherit">Citas</Button>
            <Button color="inherit">Historial</Button>
            <Button color="inherit">Perfil</Button>
          </div>
        </Toolbar>
      </AppBar>

      {/* MAIN CONTENT */}
      <div className="flex-1 p-6 grid grid-cols-1 md:grid-cols-4 gap-6">
        {/* CALENDARIO */}
        <div className="bg-white rounded-xl shadow-md p-4 md:col-span-1">
          <Calendar/>
        </div>

        {/* CARDS DE ESTADO */}
        <div className="md:col-span-3 grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-4 gap-4">
          <CardItem titulo="En espera" color="text-yellow-500" icon="⏳" />
          <CardItem titulo="En consulta" color="text-blue-500" icon="💬" />
          <CardItem titulo="Finalizado" color="text-green-500" icon="✅" />
          <CardItem titulo="Cancelados" color="text-red-500" icon="❌" />
          <CardItem titulo="Emergencia" color="text-red-600" icon="⚠️" />
          <CardItem titulo="Gestión de personal" color="text-blue-500" icon="👩‍⚕️" />
          <CardItem titulo="Gestiones de pacientes" color="text-blue-500" icon="📋" />
          <CardItem titulo="Farmacia" color="text-blue-500" icon="💊" />
        </div>
      </div>

      {/* AGENDA Y ESTADÍSTICAS */}
      <div className="p-6 grid grid-cols-1 md:grid-cols-2 gap-6">
        <div className="bg-white shadow-md rounded-xl text-[#0088FF] p-4">
          <h2 className="text-xl font-bold mb-3">Agenda del día</h2>
          <div className="h-32 bg-gray-100 rounded-lg" />
        </div>
        <div className="bg-white shadow-md rounded-xl text-[#0088FF] p-4">
          <h2 className="text-xl font-bold mb-3">Estadísticas</h2>
          <div className="h-32 bg-gray-100 rounded-lg" />
        </div>
      </div>
    </div>
  );
}

export default Dashboard;
