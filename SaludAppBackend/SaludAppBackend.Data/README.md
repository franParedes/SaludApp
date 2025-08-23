# Proceso de scaffolding (mappear la base de datos en el proyecto)
Ya que estamos usando el enfoque database first necesitamos usar el comando scaffolding de EntityFramework Core,

Este proceso leerá el esquema de la base de datos y generará automáticamente las clases de entidad (los modelos que representan las tablas) 
y configurará el AppDbContext para que las conozca.

## Instalación de la herramienta global
Si no tiene instalado EF Core no van a poder ejecutar comandos, en ese caso deben ejecutar el comando
``` powerhell
dotnet tool install --global dotnet-ef --version 8.0.19
```
## Comando scaffolding y su explicación
Deben posicionarse en la carpeta que contiene el archivo .sln (la solución) y luego ejecutar
``` powerhell
dotnet ef dbcontext scaffold "Tu_Cadena_De_Conexión" Pomelo.EntityFrameworkCore.MySql --project SaludAppBackend.Data -o Models -c AppDbContext --no-onconfiguring -f
```
### Desglose del Comando:
> **dotnet ef dbcontext scaffold**: Es el comando base para generar el código desde la base de datos.

> **"Tu_Cadena_De_Conexión"**: Aquí va la misma cadena de conexión que está en appsettings.json. ¡Asegúrense de ponerla entre 
	comillas y cambiarle el puerto si se requiere, yo lo uso en 3307!
	
> **Pomelo.EntityFrameworkCore.MySql**: El proveedor de base de datos que estás usando.

> **--project SaludAppBackend.Data**: ¡Muy importante! Le dice a la herramienta que el proyecto de destino 
	(donde se deben instalar los paquetes y generar los archivos) es .Data.
	
> **-o Models**: La opción -o (o --output-dir) especifica la carpeta de salida para las clases de entidad (los modelos). 
	Por convención, se suele usar "Models". Esto creará la carpeta Models dentro del proyecto .Data.
	
> **-c AppDbContext**: La opción -c (o --context) le dice el nombre que debe tener la clase del DbContext. 
	Como ya hay una llamada AppDbContext, esto hará que el comando la modifique para agregarle las tablas (DbSet).
	
> **--no-onconfiguring**: Esta es una excelente práctica y es justo lo que se necesita. Evita que la cadena de conexión se escriba 
	directamente en el método OnConfiguring del AppDbContext. Esto es correcto porque ya se está inyectando la configuración 
	desde el proyecto .API, lo cual es más seguro y flexible.
	
> **-f**: La opción -f (o --force) sobrescribe los archivos existentes. Es útil si se necesita regenerar los modelos después de un 
	cambio en la base de datos.