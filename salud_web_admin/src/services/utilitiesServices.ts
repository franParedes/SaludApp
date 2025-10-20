// src/services/utilitiesService.ts

import type { Area } from '../types/Area';
import type { Barrio } from '../types/Barrios';
import type { CentroMedico } from '../types/CentroMedico';
import type { Departamento } from '../types/Departamento';
import type { Especialidad } from '../types/Especialidad';
import type { Genero } from '../types/Genero';
import type { Municipio } from '../types/Municipio';
import type { Proveedor } from '../types/Proveedor';
import type { Turno } from '../types/Turno';
import type { Universidad } from '../types/Universidad';
import type { TipoUsuario } from '../types/TipoUsuario';
import type { TipoCita } from '../types/CitaTypes';
import type { Ocupacion } from '../types/Ocupacion';
import type { Escolaridad } from '../types/Escolaridad';
import type { Religion } from '../types/Religion';
import type { EstadoCivil } from '../types/EstadoCivil';

const BASE_URL = "https://localhost:7239/api/Utilities";

export async function fetchAreasMedicas(): Promise<Area[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerAreasMedicas`);

        if (!response.ok) {
            throw new Error(`Error en la respuesta de la red: ${response.statusText}`);
        }

        const data: Area[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo al obtener áreas médicas:", error);
        // Propagamos el error para que el hook que lo use pueda manejarlo
        throw error;
    }
}


export async function fetchBarrios(municipioId: number): Promise<Barrio[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerBarrios/${municipioId}`);

        if (!response.ok) {
            // Usamos el mensaje del cuerpo si está disponible, o un mensaje genérico.
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener barrios'}`);
        }

        const data: Barrio[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de barrios:", error);
        throw error;
    }
}

export async function fetchCentrosMedicos(): Promise<CentroMedico[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerCentrosMedicos`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener centros médicos'}`);
        }

        const data: CentroMedico[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de centros médicos:", error);
        throw error;
    }
}

export async function fetchDepartamentos(): Promise<Departamento[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerDepartamentos`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener departamentos'}`);
        }

        const data: Departamento[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de departamentos:", error);
        throw error;
    }
}

export async function fetchEspecialidades(): Promise<Especialidad[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerEspecialidadesMedicas`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener especialidades'}`);
        }

        const data: Especialidad[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de especialidades:", error);
        throw error;
    }
}
export async function fetchGeneros(): Promise<Genero[]> {
    try {
        // Usa la constante BASE_URL definida en el archivo.
        const response = await fetch(`${BASE_URL}/ObtenerGeneros`);

        if (!response.ok) {
            const errorText = await response.text();
            // Lanza un error detallado si la respuesta HTTP no es exitosa.
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener géneros'}`);
        }

        const data: Genero[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de géneros:", error);
        // Propaga el error para que sea manejado por el hook/componente.
        throw error;
    }
}
export async function fetchMunicipios(departamentoId: number): Promise<Municipio[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerMunicipios/${departamentoId}`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener municipios'}`);
        }

        const data: Municipio[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de municipios:", error);
        throw error;
    }
}
export async function fetchProveedores(): Promise<Proveedor[]> {  
  try {
    const response = await fetch(`${BASE_URL}/ObtenerProveedoresTelefonicos`);

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener proveedores'}`);
    }

    const data: Proveedor[] = await response.json();
    return data;
  } catch (error) {
    console.error("Fallo en la petición de proveedores:", error);
    throw error;
  }
}
export async function fetchTurnos(): Promise<Turno[]> {
  try {
    const response = await fetch(`${BASE_URL}/ObtenerTurnosMedicos`);

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener turnos médicos'}`);
    }

    const data: Turno[] = await response.json();
    return data;
  } catch (error) {
    console.error("Fallo en la petición de turnos médicos:", error);
    throw error;
  }
}
export async function fetchUniversidades(): Promise<Universidad[]> {
  try {
    const response = await fetch(`${BASE_URL}/ObtenerUniversidades`);

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener universidades'}`);
    }

    const data: Universidad[] = await response.json();
    return data;
  } catch (error) {
    console.error("Fallo en la petición de universidades:", error);
    throw error;
  }
}
export async function fetchTiposUsuarios(): Promise<TipoUsuario[]> {  
  try {
    const response = await fetch(`${BASE_URL}/ObtenerTipoDeUsuario`);

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener tipos de usuario'}`);
    }

    const data: TipoUsuario[] = await response.json();
    return data;
  } catch (error) {
    console.error("Fallo en la petición de tipos de usuario:", error);
    throw error;
  }
}
  export const fetchTiposCita = async (): Promise<TipoCita[]> => {
    const url = `${BASE_URL}/ObtenerTipoDeCita`;
    
    try {
        const response = await fetch(url, { method: 'GET' });

        if (!response.ok) {
            throw new Error(`Error al obtener tipos de cita: ${response.statusText}`);
        }

        const data: TipoCita[] = await response.json();
        return data;

    } catch (error) {
        console.error("Error en fetchTiposCita:", error);
        throw error;
    }
  };
  export async function fetchOcupaciones(): Promise<Ocupacion[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerOcupacionesDePacientes`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener ocupaciones'}`);
        }

        const data: Ocupacion[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de ocupaciones:", error);
        throw error;
    }
}
export async function fetchEscolaridades(): Promise<Escolaridad[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerEscolaridad`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener escolaridades'}`);
        }

        const data: Escolaridad[] = await response.json();
        // Nota: Si el backend devuelve "IdEscolaridad" y "Escolaridad" con mayúsculas iniciales,
        // esto coincide con el tipo definido.
        return data;
    } catch (error) {
        console.error("Fallo en la petición de escolaridades:", error);
        throw error;
    }
}
export async function fetchReligiones(): Promise<Religion[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerReligiones`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener religiones'}`);
        }

        const data: Religion[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de religiones:", error);
        throw error;
    }
}
export async function fetchEstadosCiviles(): Promise<EstadoCivil[]> {
    try {
        const response = await fetch(`${BASE_URL}/ObtenerEstadosCiviles`);

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error ${response.status}: ${errorText || 'Error al obtener estados civiles'}`);
        }

        const data: EstadoCivil[] = await response.json();
        return data;
    } catch (error) {
        console.error("Fallo en la petición de estados civiles:", error);
        throw error;
    }
}