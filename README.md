## API Base

### Estrcutura de carpetas
- [x] ServiciosApi
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
      - [ ] Controllers
- [ ] FrontBase

### Herramientas Backend
- Web API. net core 3.1 ;
- Entity framework Core 3.1

### Comandos de migracion

- ##### PostgreSQL:

Nueva migracion
> dotnet ef migrations add {nombre} --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c BDContext_Npgsql -o Migrations/Npgsql --verbose
> dotnet ef migrations add Inicial --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c ApplicationDbContext  -o Migrations/Npgsql --verbose

Actualizar base de datos
>dotnet ef database update --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c BDContext_Npgsql --verbose

- ##### SQL Server:

Nueva migracion
> dotnet ef migrations add {nombre} --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c BDContext_Sql -o Migrations/SQL --verbose
> dotnet ef migrations add Inicial --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c ApplicationDbContext  -o Migrations/SQL --verbose

Actualizar base de datos
>dotnet ef database update --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c BDContext_Sql --verbose

>dotnet ef database update --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c ApplicationDbContext --verbose