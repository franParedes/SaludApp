// src/hooks/useTurnos.ts

import { useEffect, useState } from "react";
import type { Turno } from "../types/Turno"; // Importación de tipo
import { fetchTurnos } from "../services/utilitiesServices";

export function useTurnos() {
  const [turnos, setTurnos] = useState<Turno[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadTurnos = async () => {
      try {
        const data = await fetchTurnos();
        setTurnos(data);
      } catch (err) {
        console.error("Fallo al cargar los turnos:", err);
      } finally {
        setLoading(false);
      }
    };

    loadTurnos();
  }, []); // Carga solo al montar.

  return { turnos, loading };
}