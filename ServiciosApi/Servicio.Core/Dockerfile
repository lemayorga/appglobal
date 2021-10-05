 FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
 WORKDIR /app
 EXPOSE 80/tcp
 FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
 WORKDIR /src
 COPY ["servicio.core.csproj", ""]
 RUN dotnet restore "servicio.core.csproj"
 COPY . .
 WORKDIR "/src/."
 RUN dotnet build "servicio.core.csproj" -c Release -o /app/build
 FROM build AS publish
 RUN dotnet publish "servicio.core.csproj" -c Release -o /app/publish
 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app/publish .
 ENTRYPOINT ["dotnet", "servicio.core.dll"]