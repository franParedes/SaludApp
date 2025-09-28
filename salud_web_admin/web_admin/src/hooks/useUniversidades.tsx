import { useEffect, useState } from "react";

export type Universidad = {
  IdUniversidad: number;
  Universidad: string;
};

export function useUniversidades() {
  const [universidades, setUniversidades] = useState<Universidad[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchUniversidades = async () => {
      try {
        const respuesta = await fetch(
          "https://localhost:7239/api/Utilities/ObtenerUniversidades"
        );
        const data = await respuesta.json();
        setUniversidades(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchUniversidades();
  }, []);

  return { universidades, loading };
}
