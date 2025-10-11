import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DateCalendar } from "@mui/x-date-pickers/DateCalendar";
import 'dayjs/locale/es'; 

export default function Calendar() {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs} adapterLocale="es">
      <DateCalendar 
        sx={{
          // Tamaño del 90%
          width: '91%', 
          
          color: "#0088FF",
          '& .MuiTypography-root': { color: '#0088FF', fontWeight: 'bold' },
          '& .MuiDateCalendar-root': {
            width: '100%',
          },
          
          // CORRECCIÓN CLAVE 1: Asegura la distribución equitativa de las celdas
          '& .MuiDayCalendar-weekContainer': {
            // Forzar a flexbox para asegurar el espaciado
            display: 'flex', 
            width: '100%',
            justifyContent: 'space-between',
          },

          // CORRECCIÓN CLAVE 2: Asegura que cada día tome su parte de la semana
          '& .MuiPickersDay-dayWithMargin': {
            // Esto evita que el domingo se colapse
            flex: 1, 
            // Mantiene el círculo de selección con forma cuadrada
            aspectRatio: '1/1', 
            maxWidth: '14.28%', // 100% / 7 días
          },

          // Asegura que los encabezados de los días (Lu, Ma, Mi...) también se distribuyan
          '& .MuiDayCalendar-weekDayLabel': {
            flex: 1,
            maxWidth: '14.28%',
          }
        }}

        slotProps={{
          calendarHeader: { sx: { justifyContent: 'space-between', padding: '0 1rem' } }, 
          day: {
            sx: {
              color: '#0088FF', 
              '&.MuiPickersDay-today': { color: '#0088FF', fontWeight: 'bold' }, 
              '&.Mui-selected': { backgroundColor: '#0088FF', color: '#fff' }
            },
          },
          switchViewButton: { sx: { color: '#0088FF' } },
          leftArrowIcon: { sx: { color: '#0088FF' } },
          rightArrowIcon: { sx: { color: '#0088FF' } },
        }}
      />
    </LocalizationProvider>
  )
}