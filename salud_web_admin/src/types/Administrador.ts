import type { UsuarioModel } from './UsuarioModel';

/**
 * Tipo Administrador. Hereda de UsuarioModel y añade Centro_actual.
 * El campo TipoUsuario dentro de UsuarioModel debe ser 2 (ID_ADMIN).
 */
export type Administrador = UsuarioModel & {
    // --- CAMPO ESPECÍFICO DE Administrador ---
    Centro_actual: number | null; // Corresponde a c_medico en RegisterForm
};