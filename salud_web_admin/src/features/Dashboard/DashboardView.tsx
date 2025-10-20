// Dashboard.tsx

import React from 'react';
import "dayjs/locale/es"; // Mantener este import si es necesario para Calendar
import CardItem from "./components/CardItem";
import Calendar from "./components/Calendar";

// Imports de imágenes (asumimos que los paths son correctos)
import Imageconsulta from "../../assets/images/icono_consulta.png"
import ImnageEspera from "../../assets/images/icono_espera.png"
import ImageFinalizado from "../../assets/images/icono_finalizado.png"
import IconoCancelado from "../../assets/images/icono_cancelados.png"
import Icono_emergencia from "../../assets/images/icono_emergencia.png"
import IconoPersonal from "../../assets/images/icono_personal.png"
import IconoPacientes from "../../assets/images/icono_pacientes.png"
import IconoFarmacia from "../../assets/images/icono_medicamentos.png"

// No necesita props, por lo que usamos React.FC<object> o simplemente React.FC
const Dashboard: React.FC = () => {
  return (
    // NOTA: El p-5 (padding) del contenedor principal se movió a los divs internos
    <> 
      {/* SECCIÓN PRINCIPAL: CALENDARIO Y CARDS */}
      {/* Esto se renderizará dentro de la etiqueta <main> del MarcoPrincipal */}
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
          <CardItem titulo="Cancelados" color="text-red-500"  imagen={IconoCancelado} />
          <CardItem titulo="Emergencia" color="text-red-600" imagen={Icono_emergencia} />
          <CardItem titulo="Gestión de personal" color="text-blue-500"  imagen={IconoPersonal} />
          <CardItem titulo="Gestiones de pacientes" color="text-blue-500" imagen={IconoPacientes} />
          <CardItem titulo="Farmacia" color="text-blue-500" imagen={IconoFarmacia} />
        </div>
      </div>

      {/* SECCIÓN INFERIOR: AGENDA Y ESTADÍSTICAS */}
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
    </>
  );
};

export default Dashboard;