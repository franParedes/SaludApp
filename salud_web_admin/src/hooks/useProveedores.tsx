// src/hooks/useProveedores.ts

import { useEffect, useState } from "react";
import type { Proveedor } from "../types/Proveedor"; // Importación de tipo
import { fetchProveedores } from "../services/utilitiesServices";

export function useProveedores() {
  const [proveedores, setProveedores] = useState<Proveedor[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadProveedores = async () => {
      try {
        // Llama al servicio puro.
        const data = await fetchProveedores();
        setProveedores(data);
      } catch (err) {
        console.error("Fallo al cargar los proveedores:", err);
      } finally {
        setLoading(false);
      }
    };

    loadProveedores();
  }, []); // Carga solo al montar.

  return { proveedores, loading };
}