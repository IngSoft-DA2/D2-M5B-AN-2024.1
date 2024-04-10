# Utilizar la imagen base de .NET Core SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

# Establecer el directorio de trabajo dentro del contenedor
WORKDIR /source

# Copiar los archivos del proyecto al contenedor
COPY . .
# Restaurar las dependencias y compilar la aplicación
RUN dotnet restore "starwars.WebApi/starwars.WebApi.csproj" --disable-parallel
RUN dotnet publish "starwars.WebApi/starwars.WebApi.csproj" -c release -o /app --no-restore


# Etapa de producción
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
# Copiar los archivos publicados de la etapa anterior
COPY --from=build /app ./

EXPOSE 5222

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "starwars.WebApi.dll"]
