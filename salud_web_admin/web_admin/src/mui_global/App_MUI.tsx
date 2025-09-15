import { createTheme, type Theme } from '@mui/material/styles';

// Reglas globales de estilos a los components
const theme: Theme = createTheme({
  palette: {
    primary: {
      main: '#0088FF',
    },
  },
  
  components: {
    MuiTextField: {
        styleOverrides: {
        root: {
          "& label": {
            color: "#0088FF", 
          },
          "& label.Mui-focused": {
            color: "#0088FF",
          },
       
          borderRadius: '3rem'
        },
      },
    },
    MuiOutlinedInput: {
    styleOverrides: {
      root: {
        "& fieldset": {
          borderColor: "#0088FF", 
        },
        "&:hover fieldset": {
          borderColor: "#0088FF"
        },
        borderRadius: '3rem'
      },
    },
  },
    MuiButton: {
        styleOverrides: {
        root: {
            borderRadius: '2.5rem',
            textTransform: 'none', 
        },
      },
    },
  },
});

export default theme;