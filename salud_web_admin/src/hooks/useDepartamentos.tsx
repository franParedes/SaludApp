// src/hooks/useDepartamentos.ts

import { useEffect, useState } from "react";
import type { Departamento } from "../types/Departamento"; // Importación de tipo
import { fetchDepartamentos } from "../services/utilitiesServices";

export default function useDepartamentos() {
  // Ajuste: Nombre de la variable de estado a 'departamentos' (plural y minúscula)
  const [departamentos, setDepartamentos] = useState<Departamento[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadDepartamentos = async () => {
      try {
        // Llama al servicio puro.
        const data = await fetchDepartamentos();
        setDepartamentos(data);
      } catch (err) {
        console.error("Fallo al cargar los departamentos:", err);
      } finally {
        setLoading(false);
      }
    };

    loadDepartamentos();
  }, []); // Array de dependencias vacío para cargar solo al montar.

  // Ajuste: Retornamos la variable con el nombre corregido.
  return { departamentos, loading };
}