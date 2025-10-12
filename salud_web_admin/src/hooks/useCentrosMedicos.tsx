// src/hooks/useCentrosMedicos.ts

import { useEffect, useState } from "react";
import type { CentroMedico } from "../types/CentroMedico"; // Importación de tipo
import { fetchCentrosMedicos } from "../services/utilitiesServices";

export function useCentrosMedicos() {
  const [centros, setCentros] = useState<CentroMedico[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadCentrosMedicos = async () => {
      try {
        // Llama al servicio puro, desacoplando la lógica de red.
        const data = await fetchCentrosMedicos();
        setCentros(data);
      } catch (err) {
        console.error("Fallo al cargar los centros médicos:", err);
      } finally {
        setLoading(false);
      }
    };

    loadCentrosMedicos();
  }, []); // El array vacío asegura que se ejecute solo al montar.

  // Nota: Cambié el nombre de la variable de retorno de 'centro' a 'centros' 
  // para reflejar que es una lista (array) y evitar confusión.
  return { centros, loading };
}