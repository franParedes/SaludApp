// src/hooks/useBarrios.ts

import { useEffect, useState } from "react";
import type { Barrio } from "../types/Barrios"; // Importación de tipo
import { fetchBarrios } from "../services/utilitiesServices";

export default function useBarrios(municipioId: number | null) {
  const [barrios, setBarrios] = useState<Barrio[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const loadBarrios = async () => {
      // 1. Lógica de Salida: Si no hay ID, limpiamos el estado y salimos.
      if (!municipioId) {
        setBarrios([]);
        return;
      }
      
      // 2. Lógica de Carga
      setLoading(true);
      try {
        // Llama al servicio, el hook solo gestiona el estado
        const data = await fetchBarrios(municipioId);
        setBarrios(data);
      } catch (err) {
        console.error("Fallo al cargar los barrios:", err);
        // Opcional: podrías setBarrios([]) aquí si el fetch falla
      } finally {
        setLoading(false);
      }
    };

    loadBarrios();
  }, [municipioId]); // Dependencia clave: se ejecuta cada vez que cambia municipioId

  return { barrios, loading };
}