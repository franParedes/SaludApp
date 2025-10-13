import type { UsuarioModel } from './UsuarioModel';

export type Recepcionista = UsuarioModel & {
    CentroActual: number | null;
    TurnoActual: number | null;
};