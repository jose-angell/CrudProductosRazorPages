<h1>  Proyecto dotnet de un CRUD de productos utilizando ASP.net core razor pages</h1>
<br/>

![screenshot](/screenshot_Index.png)

## Visión general
Este proyecto es un ejemplo basico de como crear una aplicacion web ASP.net core con paginas Razor, la aplicacion consta de una pagina principal que muestra un listado de productos utilizando una tabla, y 
que permite realizar las acciones de Crear (Create), leer (Read), Editar (Update) y eliminar (Delete) de forma sencilla, utilizando sintaxis de razor y EF para crear las funcionalizades e interactuar con 
la base de datos.

## Construido con 
- C# dotnet 9.0
- Visual Studio
- Sql Server
- Entity Framework
- Bootstrap

## Guia de inicio desde cero y configuracoin inicial.
1. Utilizando la plantilla de VS de Aplicacion web de ASP.NET Core, en este caso se uso .NET 9
2. Se deben instalar las dependencias necesarias para poder interactuar con la base de datos, 
    - Microsoft.EntityFrameworkCore.SqlServer (esto varia segun la DB utilizada)
    - Microsoft.EntityFrameworkCore.Tools
3. En appseting.json se coloca la cadena de conexion a la Base de Datos
    - `"ConnectionStrings": { "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB; DataBase=CrudProductosRazorDB; Trusted_Connection=True; MultipleActiveResultSets=true"}`
4. Dentro de la carpeta "Data" crear la clase "ApplicationDbContext" esta clase hereda de DbContext y se inicializa el contructor, el cual recibe el parametro 'options'  de tipo DbContextOptions<ApplicationDbContext> y al mismo tiempo hereda de base(ooptions)
5. En Program.cs se configura la injeccion de la cadena de conexion, colocando la clase ApplicationDbContext que se creo antes
6. Apartir de este punto ya se puede crear las entidades o modelos que se necersitan (en la carpeta modelos o models para mayor organizacion)
7. Todos los modelos se agregan en la clase ApplicationDbContext utilizando `DbSet<Modelo> {get; set:}`
    - `DbSet` crea la instancia de la entidad en la base de datos en la aplicacdion y permite interactuar con la misma.
8. Se Crea la migracion
    - add-migration NombreDeLaMigracion -> se generan los archivos de migracion y se permite examinar la estructura de las entidades
    - update-database -> se actualiza la base de datos
9. Crear las paginas y usar los modelos
