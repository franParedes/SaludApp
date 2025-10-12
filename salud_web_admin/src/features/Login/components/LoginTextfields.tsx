// src/features/Login/components/LoginTextfields.tsx

import { TextField } from "@mui/material";

export default function LoginTextfields() {
  return (
    <>
      {/* Caja de texto del username */}
      <TextField 
        id="outlined-username" 
        label="Usuario" 
        variant="outlined" 
        fullWidth 
      />

      {/* Caja de texto del password */}
      <TextField 
        id="outlined-password" 
        label="Contraseña" 
        variant="outlined" 
        type='password' 
        fullWidth
      />
    </>
  )
}