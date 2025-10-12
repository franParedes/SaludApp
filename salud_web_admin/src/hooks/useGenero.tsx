// src/hooks/useGenero.ts (Sin cambios, ya que solo llama al servicio)

import { useEffect, useState } from "react";
import type { Genero } from "../types/Genero"; 
import { fetchGeneros } from "../services/utilitiesServices";

export function useGenero() {
  const [generos, setGeneros] = useState<Genero[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadGeneros = async () => {
      try {
        const data = await fetchGeneros();
        setGeneros(data);
      } catch (err) {
        console.error("Fallo al cargar los géneros:", err);
      } finally {
        setLoading(false);
      }
    };

    loadGeneros();
  }, []);

  return { generos, loading };
}