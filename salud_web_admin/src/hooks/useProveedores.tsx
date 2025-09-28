import { useEffect, useState } from "react";

export type Proveedores = {
  IdProvTel: number;
  Proveedor: string;
};

export function useProveedores() {
  const [proveedores, setProveedores] = useState<Proveedores[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchProveedores = async () => {
      try {
        const respuesta = await fetch(
          "https://localhost:7239/api/Utilities/ObtenerProveedoresTelefonicos"
        );
        const data = await respuesta.json();
        setProveedores(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchProveedores();
  }, []);

  return { proveedores, loading };
}
