# Zoobitat
Crear una base de datos en MySQL:

Abre MySQL Workbench y conecta con tu servidor MySQL.
Haz clic en el botón "Create a new schema" (Crear un nuevo esquema) y asigna un nombre a tu base de datos(pueden Utilizar ZooBitaDb).


Abre tu proyecto de .NET en Visual Studio.
Abre el archivo de configuración de la aplicación (appsettings.json).
Agrega la sección "ConnectionStrings" y define la cadena de conexión de MySQL. Asegúrate de incluir el nombre de la base de datos que acabas de crear, así como el nombre de usuario y la contraseña para acceder a la base de datos.

{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=nombre_de_la_base_de_datos(ZooBitatdb);user=nombre_de_usuario;password=contraseña"
  }
}

Crear una migración con .NET:

Abre la consola del administrador de paquetes en Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
Asegúrate de seleccionar el proyecto que contiene tu base de datos.
Ejecuta el comando "Add-Migration nombre_de_la_migracion" para crear una nueva migración.

Esto generará un archivo de migración que contiene el código necesario para actualizar la base de datos con las nuevas tablas y campos.
Ejecutar la migración con .NET:

Abre la consola del administrador de paquetes de nuevo y ejecuta el comando "Update-Database" para aplicar la migración a la base de datos.
Esto aplicará la migración a la base de datos y actualizará la estructura de la misma.
