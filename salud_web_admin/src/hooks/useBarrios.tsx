import { useEffect, useState } from "react";

export type Barrio = {
  IdBarrio: number;
  Barrio: string;
};

export default function useBarrios(municipioId: number | null) {
  const [barrios, setBarrios] = useState<Barrio[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchBarrios = async () => {
      if (!municipioId) return; // No hacer fetch si no hay id
      setLoading(true);
      try {
        const respuesta = await fetch(
          `https://localhost:7239/api/Utilities/ObtenerBarrios/${municipioId}`
        );
        if (!respuesta.ok) throw new Error("Error al obtener municipios");
        const data = await respuesta.json();
        setBarrios(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchBarrios();
  }, [municipioId]);

  return { barrios, loading };
}
