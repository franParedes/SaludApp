# SaluddApp - Web Admin

## Descripción

SaludApp Web Admin es un panel de administración para gestionar citas médicas, registros de pacientes y otros datos relacionados con la gestión de una clínica u hospital. 🏥

El frontend está desarrollado en **React con TypeScript**, utilizando **Vite** como bundler, **Tailwind CSS** para estilos y **Material UI (MUI)** para componentes.
Consume **APIs desarrolladas en C\# con Swagger**, lo que permite una integración fácil y documentada con el backend.

## Tecnologías

  - **Frontend:** React, TypeScript, Vite, Tailwind CSS, Material UI (MUI)
  - **Backend:** C\# ASP.NET Core Web API, Swagger
  - **Comunicación:** Fetch para consumir API's
  - **Sistema Gestor de Base de datos:** MySQL WorkBench

-----

## 🏗️ Arquitectura del Frontend: Estructura Basada en Características (*Feature-Based*)

Para garantizar la escalabilidad y un alto nivel de **cohesión** (código relacionado junto) y **bajo acoplamiento** (mínimas dependencias), el proyecto utiliza una arquitectura basada en características.

La estructura interna del directorio `src/` se organiza por funcionalidad en lugar de por tipo de archivo, permitiendo que cada módulo sea autocontenido.

### Estructura del Directorio `src/`

| Directorio | Propósito | Principio Aplicado |
| :--- | :--- | :--- |
| **`src/features`** | **Núcleo de la aplicación.** Contiene la lógica y la UI de cada funcionalidad principal (ej.`Pacientes`, `Usuarios`). Cada subdirectorio es un módulo completo. | **Cohesión:** Todo el código (estado, *hooks*, API, componentes) de una característica reside aquí. |
| **`src/components`** | Componentes UI genéricos, reutilizables en *toda* la aplicación (ej., `Button`, `Modal`, `LoadingSpinner`). No tienen lógica de negocio. | **Reutilización y Presentación:** Componentes puramente presentacionales. |
| **`src/hooks`** | **Custom Hooks** que son **transversales** a múltiples *features* (ej., `useLocalStorage`, `useDebounce`). Los *hooks* específicos de una característica residen dentro de esa `feature`. | **Lógica Común:** Abstracción de lógica de React compartida. |
| **`src/services`** | Capa de **Acceso a Datos**. Contiene funciones puras para hacer las peticiones `fetch` a las APIs del backend. Desacopla la lógica de red de los *hooks* y componentes. | **Separación de Responsabilidades (SRP):** El *hook* llama al servicio, el servicio llama a la API. |
| **`src/pages`** | Componentes de alto nivel que actúan como **puntos de montaje** para el Router (ej., `DashboardPage`, `CitasPage`). Su rol es ensamblar los `features`. | **Ensamblaje:** Conecta el *router* con la UI de los *features*. |
| **`src/types`** | Definiciones de tipos (`type` e `interface`) globales de TypeScript (ej., `Area.ts`, `APIResponse.ts`). | **Verificación Estática:** Contratos de datos globales. |

### Lógica de Comunicación con la API

Se implementa una clara separación de la lógica en tres capas:

1.  **Capa de Servicios (`src/services`):** Contiene la función `fetch` pura, encargada de construir la URL, enviar la petición HTTP y manejar errores de red.
2.  **Capa de Hooks (`src/hooks` o `src/features/[nombre]/hooks`):** Utiliza `useEffect` y `useState` para llamar a la función del servicio y gestionar el ciclo de vida del estado de carga (`loading`) y el resultado (`data`).
3.  **Capa de Presentación (`src/components` o `src/features/[nombre]/components`):** Solo consume los datos y el estado de los *hooks* para renderizar la interfaz.

-----

# Guía de Instalación de Node.js

## Requisitos

  - Sistema operativo: Windows, macOS o Linux
  - Acceso a internet para descargar el instalador

-----

## Instalación en Windows y macOS

1.  Ve al sitio oficial de Node.js:
    [https://nodejs.org](https://nodejs.org)

2.  Descarga la **versión LTS (Long Term Support)**, recomendada para la mayoría de usuarios.

3.  Ejecuta el instalador y sigue los pasos:

      - Acepta la licencia.
      - Selecciona la carpeta de instalación.
      - Marca la opción de instalar **npm** (gestor de paquetes de Node.js).
      - Finaliza la instalación.

4.  Verifica la instalación:

    ```bash
    node -v
    npm -v
    ```

## Instalación del Proyecto

1.  Clonar el repositorio:

<!-- end list -->

```bash
   git clone https://github.com/franParedes/SaludApp.git
   cd SaludApp
```

## Configurar la base de datos

1.  Abre tu gestor de base de datos preferido (por ejemplo, MySQL Workbench).

2.  Dirígete a la carpeta:

<!-- end list -->

```bash
   /Database/Modelado_BD
```

3.  Ejecuta los scripts allí presentes para construir la base de datos y sus procedimientos necesarios.

## Configurar Swagger para Visual Studio .NET

1.  Tienes que abrir el proyecto de **SaludAppBackend.sln** en Visual Studio (puede ser el 2019 o 2022). Navega a la carpeta para encontrarlo:

<!-- end list -->

```bash
   cd SaludApp/SaludAppBackend
```

2.  Abres el proyecto y luego configuras la cadena de conexión a MySQL en `appsettings.json`:

<!-- end list -->

```json
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

3.  Y por último ejecutas el programa con **F5**.

## Uso

1.  Ejecuta el backend (`SaludAppBackend`) desde Visual Studio.

2.  Luego Abre tu editor de código libre (en este caso Visual Studio Code). Luego dentro del editor abres la carpeta que está en la ruta:

<!-- end list -->

```bash
   SaludApp/salud_web_admin
```

3.  Instala las dependencias, utilizando el siguiente comando dentro de la terminal:

<!-- end list -->

```bash
   npm install
```

4.  Ahora solo corres el servidor local utilizando el comando:

<!-- end list -->

```bash
   npm run dev
```

5.  Por último accede a la aplicación en:

<!-- end list -->

```bash
   http://localhost:5173
```

## Licencia

**Este proyecto está bajo la Licencia MIT © 2025**