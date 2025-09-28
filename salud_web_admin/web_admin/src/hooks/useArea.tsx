import { useEffect, useState } from "react";

export type Area = {
  IdArea: number;
  Area: string;
};

export function useAreas() {
  const [areas, setAreas] = useState<Area[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchAreasMedicas = async () => {
      try {
        const respuesta = await fetch(
          "https://localhost:7239/api/Utilities/ObtenerAreasMedicas"
        );
        const data = await respuesta.json();
        setAreas(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchAreasMedicas();
  }, []);

  return { areas, loading };
}
