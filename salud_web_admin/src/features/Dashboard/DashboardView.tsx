import { AppBar, Toolbar, IconButton, Typography, Button } from "@mui/material";
import "dayjs/locale/es";
import MenuIcon from "@mui/icons-material/Menu";
import CardItem from "./components/CardItem";
import Calendar from "./components/Calendar";
// Importar el nuevo componente
import { UserMenu } from "./components/UserMenu"; 
// ... (Otros imports de imágenes) ...
import Imageconsulta from "../../assets/images/icono_consulta.png"
import ImnageEspera from "../../assets/images/icono_espera.png"
import ImageFinalizado from "../../assets/images/icono_finalizado.png"
import IconoCancelado from "../../assets/images/icono_cancelados.png"
import Icono_emergencia from "../../assets/images/icono_emergencia.png"
import IconoPersonal from "../../assets/images/icono_personal.png"
import IconoPacientes from "../../assets/images/icono_pacientes.png"
import IconoFarmacia from "../../assets/images/icono_medicamentos.png"

function Dashboard() {
  return (
    <div className="min-h-screen w-full bg-gray-50 flex flex-col p-5">
      {/* NAVBAR */}
      <AppBar position="static" sx={{ backgroundColor: "#0088FF", borderRadius: 2 }}>
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
            
            {/* 👈 REEMPLAZO DEL BOTÓN PERFIL POR EL MENÚ FLOTANTE */}
            <UserMenu /> 
            {/* ---------------------------------------------------- */}
            
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
          <CardItem titulo="En espera" color="text-yellow-500" imagen={ImnageEspera} />
          <CardItem titulo="En consulta" color="text-blue-500" imagen={Imageconsulta} />
          <CardItem titulo="Finalizado" color="text-green-500" imagen={ImageFinalizado} />
          <CardItem titulo="Cancelados" color="text-red-500"  imagen={IconoCancelado} />
          <CardItem titulo="Emergencia" color="text-red-600" imagen={Icono_emergencia} />
          <CardItem titulo="Gestión de personal" color="text-blue-500"  imagen={IconoPersonal} />
          <CardItem titulo="Gestiones de pacientes" color="text-blue-500" imagen={IconoPacientes} />
          <CardItem titulo="Farmacia" color="text-blue-500" imagen={IconoFarmacia} />
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