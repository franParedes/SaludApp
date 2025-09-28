# SaluddApp - Web Admin

## Descripcion
SaludApp Web Admin es un panel de administración para gestionar citas médicas, registros de pacientes y otros datos relacionados con la gestión de una clínica u hospital.  
El frontend está desarrollado en **React con TypeScript**, utilizando **Vite** como bundler, **Tailwind CSS** para estilos y **Material UI (MUI)** para componentes.  
Consume **APIs desarrolladas en C# con Swagger**, lo que permite una integración fácil y documentada con el backend.

## Tecnologías
- **Frontend:** React, TypeScript, Vite, Tailwind CSS, Material UI (MUI)  
- **Backend:** C# ASP.NET Core Web API, Swagger  
- **Comunicación:** Fetch para consumir API's
- **Sistema Gestor de Base de datos:** MySQL WorkBench

## Instalación
1. Clonar el repositorio:
```bash
  git clone https://github.com/franParedes/SaludApp.git
  cd SaludApp 
```
## Configurar la base de datos

1. Abre tu gestor de base de datos preferido (por ejemplo, MySQL Workbench).

2. Dirígete a la carpeta:
```bash
  /Database/Modelado_BD
```
3. Ejecuta los scripts allí presentes para construir la base de datos y sus procedimientos necesarios.

## Configurar Swagger para Visual Studio .NET
1. Tienes que abrir el proyecto de SaludAppBackend.sln en visual studio (puede ser el 2019 o 2022), navega a la carpeta para encontrarlo
```bash
  cd SaludApp/SaludAppBackend
```
2. Abres el proyecto y luego configuras la cadena de conexion a MySQL en appsettings.json
```bash
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;Database=db_saludapp;Uid=root;Pwd=[TuContraseña]"
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
3. Y por ultimo ejecutas el programa con f5

## Uso
1. Ejecuta el backend (SaludAppBackend) desde Visual Studio.

2. luego Abre tu enditor de codigo libre, en este caso visual studio code, luego dentro del editor abres la carpeta que esta en la ruta:
```bash
  SaludApp/salud_web_admin
```
3. Instala las dependencias, en este caso utilizas el siguiente comando dentro de la terminal:
```bash
  npm install
```
4. Ahora solo corres el servidor local utilizando el comando:
```bash
  npm run dev
```
5. Por ultimo accede a la aplicacion en:
```bash
  http://localhost:5173
```
## Licencia

**Este proyecto está bajo la Licencia MIT © 2025**
