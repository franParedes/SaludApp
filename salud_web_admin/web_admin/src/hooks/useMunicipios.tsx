import { useEffect, useState } from "react";

export type Municipio = {
  IdMunicipio: number;
  Municipio: string;
};

export default function useMunicipios(departamentoId: number | null) {
  const [municipios, setMunicipios] = useState<Municipio[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchMunicipios = async () => {
      if (!departamentoId) return; // No hacer fetch si no hay id
      setLoading(true);
      try {
        const respuesta = await fetch(
          `https://localhost:7239/api/Utilities/ObtenerMunicipios/${departamentoId}`
        );
        if (!respuesta.ok) throw new Error("Error al obtener municipios");
        const data = await respuesta.json();
        setMunicipios(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchMunicipios();
  }, [departamentoId]);

  return { municipios, loading };
}
