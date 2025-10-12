// src/hooks/useEspecialidades.ts

import { useEffect, useState } from "react";
import type { Especialidad } from "../types/Especialidad"; // Importación de tipo
import { fetchEspecialidades } from "../services/utilitiesServices";

export default function useEspecialidades() {
  // Ajuste: Nombre de la variable de estado a 'especialidades' (minúscula)
  const [especialidades, setEspecialidades] = useState<Especialidad[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadEspecialidades = async () => {
      try {
        // Llama al servicio puro.
        const data = await fetchEspecialidades();
        setEspecialidades(data);
      } catch (err) {
        console.error("Fallo al cargar las especialidades:", err);
      } finally {
        setLoading(false);
      }
    };

    loadEspecialidades();
  }, []); // Carga solo al montar.

  // Retornamos la variable con el nombre corregido.
  return { especialidades, loading };
}