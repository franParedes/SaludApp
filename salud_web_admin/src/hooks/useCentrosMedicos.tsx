import { useEffect, useState } from "react";

export type CentroMedico = {
  IdCentro: number;
  Centro: string;
};

export function useCentrosMedicos() {
  const [centro, setCentro] = useState<CentroMedico[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchCentroMedico = async () => {
      try {
        const respuesta = await fetch(
          "https://localhost:7239/api/Utilities/ObtenerCentrosMedicos"
        );
        const data = await respuesta.json();
        setCentro(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchCentroMedico();
  }, []);

  return { centro, loading };
}
