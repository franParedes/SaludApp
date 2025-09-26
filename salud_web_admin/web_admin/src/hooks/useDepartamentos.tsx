import { useEffect, useState } from "react";

export type Departamentos = {
  IdDepartamento: number;
  Departamento: string;
};

export default function useDepartamentos() {
  const [Departamento, setDepartamento] = useState<Departamentos[]>([]);
    const [loading, setLoading] = useState(true);
  
    useEffect(() => {
      const fetchGeneros = async () => {
        try {
          const respuesta = await fetch(
            "https://localhost:7239/api/Utilities/ObtenerDepartamentos"
          );
          const data = await respuesta.json();
          setDepartamento(data);
        } catch (err) {
          console.error(err);
        } finally {
          setLoading(false);
        }
      };
  
      fetchGeneros();
    }, []);
  
    return { Departamento, loading };
}

