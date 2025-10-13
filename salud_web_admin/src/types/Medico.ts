import type { UsuarioModel} from './UsuarioModel'; 
// NOTA: Asegúrate de que DireccionModel y TelefonoModel ya no se exporten
// o se definan en este archivo, sino que se importen desde UsuarioModel.ts.


// Tipo Medico, extiende de UsuarioModel y añade campos específicos.
export type Medico = UsuarioModel & {
    // --- CAMPOS EXCLUSIVOS DE MedicoModel ---
    Cod_sanitario: string;
    Especialidad: number;
    EgresadoDe: number | null; // Tipos flexibles
    EgresadoEl: string | null; // Formato YYYY-MM-DD
    Experiencia_anyos: number | null;
    Area_actual: number | null;
    Centro_actual: number | null;
    Turno_actual: number | null;
    
    nombre?: string;
    apellido?: string;
    telefono?: number;
};