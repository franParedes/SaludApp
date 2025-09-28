import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DateCalendar } from "@mui/x-date-pickers/DateCalendar";

export default function Calendar() {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs} adapterLocale="es">
        <DateCalendar 
            slotProps={{
                day: {
                sx: {
                    color: '#0088FF', // días normales
                   // día seleccionado
                    '&.MuiPickersDay-today': { color: '#0088FF', fontWeight: 'bold' }, // hoy
                },
                },
                switchViewButton: {
                sx: { color: '#0088FF' }, // botón cambiar vista
                },
                leftArrowIcon: {
                sx: { color: '#0088FF' }, // flecha izquierda
                },
                rightArrowIcon: {
                sx: { color: '#0088FF' }, // flecha derecha
                },
            }}
            sx={{
                color: "#0088FF",
                
                '& .MuiTypography-root': { color: '#0088FF', fontWeight: 'bold' }, // Dias de la semana
            }}
        />
    </LocalizationProvider>
  )
}
