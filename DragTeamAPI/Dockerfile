FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["DragTeamAPI/DragTeamAPI.csproj", "DragTeamAPI/"]
RUN dotnet restore "./DragTeamAPI/DragTeamAPI.csproj"

COPY . .

RUN dotnet build "./DragTeamAPI/DragTeamAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "./DragTeamAPI/DragTeamAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagem final
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "DragTeamAPI.dll"]