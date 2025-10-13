import type { UsuarioModel } from './UsuarioModel';

export type UsuarioRegistro = UsuarioModel & {
    CentroActual: number | null;
    TurnoActual: number | null;
};