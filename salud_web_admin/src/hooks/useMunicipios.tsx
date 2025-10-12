// src/hooks/useMunicipios.ts

import { useEffect, useState } from "react";
import type { Municipio } from "../types/Municipio"; // Type import
import { fetchMunicipios } from "../services/utilitiesServices";

export default function useMunicipios(departamentoId: number | null) {
  const [municipios, setMunicipios] = useState<Municipio[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const loadMunicipios = async () => {
      // Exit and clear state if the dependency is null
      if (departamentoId === null) {
        setMunicipios([]);
        return;
      }
      
      setLoading(true);
      try {
        // Calls the pure service function, decoupling API logic
        const data = await fetchMunicipios(departamentoId);
        setMunicipios(data);
      } catch (err) {
        console.error("Failed to load municipalities:", err);
        // Optionally set an error state here
      } finally {
        setLoading(false);
      }
    };

    loadMunicipios();
  }, [departamentoId]); // Dependency array ensures hook re-runs when departmentId changes

  return { municipios, loading };
}