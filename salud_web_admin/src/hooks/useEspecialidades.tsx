import { useEffect, useState } from "react";

export type Especialidad = {
  IdEspecialidad: number;
  Especialidad: string;
};

export default function useEspecialidades() {
  const [Especialidades, setEspecialidad] = useState<Especialidad[]>([]);
    const [loading, setLoading] = useState(true);
  
    useEffect(() => {
      const fetchEspecialidades = async () => {
        try {
          const respuesta = await fetch(
            "https://localhost:7239/api/Utilities/ObtenerEspecialidadesMedicas"
          );
          const data = await respuesta.json();
          setEspecialidad(data);
        } catch (err) {
          console.error(err);
        } finally {
          setLoading(false);
        }
      };
  
      fetchEspecialidades();
    }, []);
  
    return { Especialidades, loading };
}
