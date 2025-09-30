# Salud App Mobile

Servicio de aplicación móvil para SaludApp, donde los pacientes podran gestionar sus citas, ver su historial médico y tendran un recordatorio de sus medicamentos.
Esta app consume una API elaborada en .NET que cuenta con acceso a MySQL.

## Rquisitos previos

Antes de comenzar asegurate de tener instalados los siguientes programas:
- [Flutter](https://docs.flutter.dev/get-started/install)  Última versión
- [Android Studio](https://developer.android.com/studio) (con un emulador configurado)  
- [Visual Studio Code](https://code.visualstudio.com/)  
- [Visual Studio](https://visualstudio.microsoft.com/) (con soporte para **ASP.NET Core**)  
- [MySQL](https://dev.mysql.com/downloads/)  
- Un **gestor de base de datos MySQL** como [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) o [DBeaver](https://dbeaver.io/)

---

## ¿Cómo ejecutar el proyecto en un entorno local?

### Clonar el repositorio
```bash
git clone https://github.com/franParedes/SaludApp.git
cd SaludApp 
```

### Configurar la base de datos

Abre tu gestor de base de datos de preferencia y navega a la carpeta /Database/Modelado_BD donde encontraras los scritps necesarios para generar la base de datos, funciones y procedimientos almacenados necesarios para el buen funcionamiento del API

### Configura el API en Visual Studio .NET

Abre el proyecto SaludAppBackend.sln en visual estudio, navega a la carpeta para encontrarlo

```bash
cd SaludApp/SaludAppBackend
```

y abrir el proyecto, luego de eso, Configurar la cadena de conexión a MySQL en appsettings.json


```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=db_saludapp;Uid=root;Pwd=[Aqui va tu contraseña]"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "LogPath": "C:\\LogsSaludApp\\LogSaludApp.log",
  "LogLevelMin": "Information"
}

```

Ejecuta el programa con F5

### Configurar y ejecutar la app de flutter

Se deben seguir los siguientes pasos:

- Ejecutar el emulador de android 
- Abrir la carpeta del proyecto en vscode
- Abrir una terminal en la carpeta del proyecto de flutter y ejecutar:

```bash
flutter pub get

```
Activar las opciones de desarrollador en windowns:
-
Ir a la cpnfiguración -> Sistema -> Para Programadores y habilitar la opción modo para desarrolladores

![Descripción de la imagen](https://github.com/franParedes/SaludApp/blob/main/salud_app_mobile/images/desarrollador.jpeg?raw=true)



y luego en la terminal ejecutar:

```bash
start ms-settings:developers

```


- Seleccionar el dispositivo emulado
- Ejecutar el proyecto con CTRL+F5





