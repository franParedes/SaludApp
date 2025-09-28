import { useEffect, useState } from "react";

export type Turno = {
  IdTurno: number;
  Turno: string;
};

export function useTurnos() {
  const [turnos, setTurnos] = useState<Turno[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchTurnos = async () => {
      try {
        const respuesta = await fetch(
          "https://localhost:7239/api/Utilities/ObtenerTurnosMedicos"
        );
        const data = await respuesta.json();
        setTurnos(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchTurnos();
  }, []);

  return { turnos, loading };
}
