import { createTheme, type Theme } from '@mui/material/styles';

const theme: Theme = createTheme({
  palette: {
    primary: {
      main: '#bg-azul-claro',
    },
  },
  
  components: {
    MuiTextField: {
        styleOverrides: {
        root: {
          borderRadius: '40px',
         
        },
      },
    },
    MuiOutlinedInput: {
    styleOverrides: {
      root: {
        borderRadius: '40rem', // redondeo extremo
      },
    },
  },
    MuiButton: {
        styleOverrides: {
        root: {
            borderRadius: '30',
            textTransform: 'none', 
        },
      },
    },
  },
});

export default theme;