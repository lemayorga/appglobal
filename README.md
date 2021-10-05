## API Base

Aplicación APi con net5 ,permitiendo conexion a MSSQL o Postgresql

### Estrcutura de carpetas
- [x] ServiciosApi
  - [ ] docker-compose.yml
  - [x]  Servicio.Entidad
      - [ ] Models
      - [ ] Dtos
      - [ ] Helpers
  - [x] Servicio.Datos
      - [ ] Context
      - [x] Migrations
          - [ ] Npgsql
          - [ ] Sql
      - [ ] Seeds
  - [x] Servicio.Logica
      - [ ] Interfaces
      - [ ] Services
  - [x] Servicio.Core
      - [x] Config
      - [x] Controllers
- [ ] FrontBase

### Herramientas Backend
- Web API. net core 3.1 ;
- Entity framework Core 3.1

### Comandos de migracion

- ##### PostgreSQL:

Nueva migracion
> dotnet ef migrations add Inicial --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c ApplicationDbContext  -o Migrations/Npgsql --verbose

- ##### SQL Server:

Nueva migracion
> dotnet ef migrations add Inicial --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c ApplicationDbContext  -o Migrations/SQL --verbose

Actualizar base de datos
> dotnet ef database update --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c ApplicationDbContext --verbose



- ### Instalar entity framework 
> dotnet tool install --global dotnet-ef

- ### Levantar el docker-compuse.yml
> docker-compose up -d
> docker ps -a  ## ver mis contenedores