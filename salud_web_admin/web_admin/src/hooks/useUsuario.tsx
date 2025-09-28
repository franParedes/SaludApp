import { useEffect, useState } from "react";

export type TipoUsuario = {
  IdTipoUsuario: number;
  TipoUsuario: string;
};

export function useUsuario() {
  const [tipos, setTipos] = useState<TipoUsuario[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchTiposUsuarios = async () => {
      try {
        const respuesta = await fetch(
          "https://localhost:7239/api/Utilities/ObtenerTipoDeUsuario"
        );
        const data = await respuesta.json();
        setTipos(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchTiposUsuarios();
  }, []);

  return { tipos, loading };
}