import { useState } from "react";

export type Medico = {
    nombre: string;
    apellido: string;
    especialidad: number;
    telefono: number;
    GeneralInfo: {
        Cedula: string;
        PrimerNombre: string;
        SegundoNombre: string;
        PrimerApellido: string;
        SegundoApellido: string;
        Correo: string;
        Genero: number;
        FechaNacimiento: string; // YYYY-MM-DD
        TipoUsuario: number;
    };
    Cod_sanitario: string;
    Especialidad: number;
    EgresadoDe: number;
    EgresadoEl: string; // YYYY-MM-DD
    Experiencia_anyos: number;
    Area_actual: number;
    Centro_actual: number;
    Turno_actual: number;
    Telefonos: { Telefono: number; Compania: number }[];
};

export function useCrearMedico() {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [respuesta, setRespuesta] = useState<any>(null);

    const crearMedico = async (medicoData: Medico) => {
        setLoading(true);
        setError(null);

        try {
        const res = await fetch("https://localhost:7239/api/Medicos/CrearMedico", {
            method: "POST",
            headers: {
            "Content-Type": "application/json"
            },
            body: JSON.stringify(medicoData)
        });

        if (!res.ok) {
            throw new Error("Error creando médico");
        }

        const data = await res.json();
        setRespuesta(data);
        return data;
        } catch (err: any) {
        setError(err.message || "Error desconocido");
        } finally {
        setLoading(false);
        }
    };

    return { crearMedico, loading, error, respuesta };
}
