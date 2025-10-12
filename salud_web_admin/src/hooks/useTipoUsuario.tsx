// src/hooks/useUsuario.ts

import { useEffect, useState } from "react";
import type { TipoUsuario } from "../types/TipoUsuario"; // Importación de tipo
import { fetchTiposUsuarios } from "../services/utilitiesServices";

export function useTipoUsuario() {
  const [tipos, setTipos] = useState<TipoUsuario[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadTiposUsuarios = async () => {
      try {
        // Llama al servicio puro.
        const data = await fetchTiposUsuarios();
        setTipos(data);
      } catch (err) {
        console.error("Fallo al cargar los tipos de usuario:", err);
      } finally {
        setLoading(false);
      }
    };

    loadTiposUsuarios();
  }, []); // Carga solo al montar.

  return { tipos, loading };
}