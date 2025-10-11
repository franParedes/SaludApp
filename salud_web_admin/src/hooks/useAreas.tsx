// src/hooks/useAreas.ts

import { useEffect, useState } from "react";
import { fetchAreasMedicas } from "../services/utilitiesServices";
import type { Area } from "../types/Area";

export function useAreas() {
  const [areas, setAreas] = useState<Area[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadAreas = async () => {
      try {
        const data = await fetchAreasMedicas();
        setAreas(data);
      } catch (err) {
        console.error("Fallo al cargar las áreas:", err);
      } finally {
        setLoading(false);
      }
    };

    loadAreas();
  }, []);

  return { areas, loading };
}