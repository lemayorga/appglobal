# appglobal
Aplicacion API global


dotnet ef migrations add InitDatabase --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c BDContext_Npgsql -o Migrations/Npgsql --verbose
dotnet ef database update --project Servicio.Datos/Servicio.Datos.csproj -s Servicio.Core -c BDContext_Npgsql --verbose