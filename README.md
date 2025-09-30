# SaludApp

## Resumen
Este es un sistema que permite automatizar los procesos de registro, seguimiento de pacientes, programación de citas médicas, entre otras cosas, en los hospitales públicos de Nicaragua. Permite agilizar la atención, reducir aglomeraciones y mejorar la experiencia del paciente y la eficiencia hospitalaria.

El sistema está dividido en varias responsabilidades:

- **Backend:** Una Web API construida en .NET 8, basada en los principios de **Clean Architecture** y **Layered Architecture** para lograr un backend robusto. Incorpora logs para registrar cualquier error en el ordenador donde se ejecute, lo que facilita el mantenimiento y permite la escalabilidad del proyecto.
- **Aplicación móvil:** Desarrollada con Flutter y Dart, enfocada exclusivamente en el usuario.
- **Sistema web:** Creado con React, TypeScript, Vite, Tailwind CSS y Material UI, brindando al personal de salud una interfaz administrativa accesible desde las computadoras en cada centro de atención médica.

---


## Configuración entorno MySQL

#### Requisitos previos

- MySQL Server versión > 8.0 instalado.
- Un gestor de bases de datos como [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) o [DBeaver](https://dbeaver.io/).

#### Pasos para la base de datos

1. Ejecutar los scripts que están en la carpeta `Database/Modelado_BD`.
2. El primer script a ejecutar debe ser `Script_creación_bd.sql`.
---
Si necesitas ayuda adicional para continuar la configuración o para ejecutar el proyecto, no dudes en pedírmelo.

## Clonando el repositorio
1. Moverse a la carpeta donde desea alojar el proyecto y ejecutar:
```bash
  git clone https://github.com/franParedes/SaludApp.git
  cd SaludApp 
```

## Configurando entorno de .NET (backend)
### Requisitos previos
- **Tener instalado el SDK de .NET8**
- **Tener instalado Visual Studio 2022**
- **Ejecutar en S.O Compatible (Windows 10 en adelante)**

### Ejecutando el API
- **Abra Visual Studio 2022 como administrador**
- **Abra el proyecto (Archivo .sln) el cual se encuentra en la carpeta**
````bash
cd SaludApp/SaludAppBackend
````

- **En SaludAppBackend.API hay un archivo llamado appsettings.json, debe abrirlo y configurar el string de conexión**
````json
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
````

- Si no existe la ruta que corresponde a “LogPath” en appsettings.json debe crearla (sirve para guardar logs) o cambiar la ruta a una existente la cual contenga un archivo .log
- Ejecutar el API con F5 (Si es la primera vez que ejecuta un API de .NET este le pedirá que acepte un certificado, confíe y de click en “sí”, este certificado le da ciertos permisos al sdk de .NET8 para que no sea visto como virus)

## Configurando entorno WEB (para abrir web de administración)
### Guía de instalación de Node.js
### Requisitos
- Sistema operativo: Windows, macOS o Linux
- Acceso a internet para descargar el instalador

---

1. Ve al sitio oficial de Node.js:  
     [https://nodejs.org](https://nodejs.org)

2. Descarga la **versión LTS (Long Term Support)**, recomendada para la mayoría de usuarios.

3. Ejecuta el instalador y sigue los pasos:
   - Acepta la licencia.
   - Selecciona la carpeta de instalación.
   - Marca la opción de instalar **npm** (gestor de paquetes de Node.js).
   - Finaliza la instalación.

4. Verifica la instalación:
```bash
   node -v
   npm -v
```

5. Ejecuta el backend (SaludAppBackend) desde Visual Studio.

6. luego Abre tu enditor de codigo libre, en este caso visual studio code, luego dentro del editor abres la carpeta que esta en la ruta:
```bash
SaludApp/salud_web_admin
```

7. Instala las dependencias, en este caso utilizas el siguiente comando dentro de la terminal:
```bash
npm install
```

8. Ahora solo corres el servidor local utilizando el comando:
```bash
npm run dev
```

9. Por ultimo accede a la aplicacion en:
```bash
http://localhost:5173
```

## Configurando entorno móvil
### Rquisitos previos
Antes de comenzar asegurate de tener instalados los siguientes programas:
- [Flutter](https://docs.flutter.dev/get-started/install)  Última versión
- [Android Studio](https://developer.android.com/studio) (con un emulador configurado)  
- Tener el API en ejecución

### Configurar y ejecutar la app de flutter

Se deben seguir los siguientes pasos:

- Ejecutar el emulador de android 
- Abrir la carpeta del proyecto en vscode
- Abrir una terminal en la carpeta del proyecto de flutter y ejecutar:

```bash
flutter pub get
```
Activar las opciones de desarrollador en windowns:
- Ir a la cpnfiguración -> Sistema -> Para Programadores y habilitar la opción modo para desarrolladores

![Descripción de la imagen](https://github.com/franParedes/SaludApp/blob/main/salud_app_mobile/images/desarrollador.jpeg?raw=true)


y luego en la terminal ejecutar:

```bash
start ms-settings:developers
```

- Seleccionar el dispositivo emulado
- Ejecutar el proyecto con CTRL+F5
