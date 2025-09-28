import { useEffect, useState } from "react";

export type Genero = {
  IdGenero: number;
  Genero: string;
};

export function useGenero() {
  const [generos, setGeneros] = useState<Genero[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchGeneros = async () => {
      try {
        const respuesta = await fetch(
          "https://localhost:7239/api/Utilities/ObtenerGeneros"
        );
        const data = await respuesta.json();
        setGeneros(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchGeneros();
  }, []);

  return { generos, loading };
}
