# Proyecto API en .NET - Arquitectura en Capas

Este proyecto es una API construida sobre .NET siguiendo una arquitectura en capas. La estructura tiene como objetivo mejorar la organización, mantener la separación de responsabilidades y facilitar el mantenimiento y escalabilidad.

---

## Estructura del Proyecto

El proyecto está dividido en varios proyectos o capas con responsabilidades claras:

### 1. `.API` - Controladores  
Contiene los **controladores Web API** que exponen las rutas y endpoints REST. Se encarga de recibir las solicitudes HTTP, manejar la validación básica y devolver las respuestas adecuadas.

### 2. `.Models` - Modelos  
Define las **entidades del dominio** o los modelos que se utilizan en todo el proyecto. Estos representan la estructura de los datos que se manejan, tanto para la persistencia como para la transmisión.

### 3. `.Data` - Acceso a Base de Datos  
Contiene la lógica para la interacción con la base de datos. Aquí se encuentran los repositorios, el contexto de base de datos, y cualquier consulta o comando relacionado.

### 4. `.Services` - Servicios  
Incluye la lógica de negocio que no corresponde directamente al acceso a datos ni a la presentación. Aquí van los servicios externos, como envío de correos electrónicos, integración con APIs de terceros o cualquier lógica de aplicación.
Aun no se crea este proyecto pero a futuro probablemente si lo lleguemos a ocupar
---

## Arquitectura en Capas

