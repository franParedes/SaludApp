// src/hooks/useUniversidades.ts

import { useEffect, useState } from "react";
import type { Universidad } from "../types/Universidad"; // Importación de tipo
import { fetchUniversidades } from "../services/utilitiesServices";

export function useUniversidades() {
  const [universidades, setUniversidades] = useState<Universidad[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadUniversidades = async () => {
      try {
        // Llama al servicio puro.
        const data = await fetchUniversidades();
        setUniversidades(data);
      } catch (err) {
        console.error("Fallo al cargar las universidades:", err);
      } finally {
        setLoading(false);
      }
    };

    loadUniversidades();
  }, []); // Carga solo al montar.

  return { universidades, loading };
}