# ===========================
# BUILD STAGE
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Kopiowanie plików csproj (dla cache)
COPY ["src/Bootstraper/Calcis.Bootstraper/Calcis.Bootstraper.csproj", "src/Bootstraper/Calcis.Bootstraper/"]
COPY ["src/Modules/Base/Calcis.Modules.Base.Api/Calcis.Modules.Base.Api.csproj", "src/Modules/Base/Calcis.Modules.Base.Api/"]
COPY ["src/Shared/Calcis.Shared.Abstractions/Calcis.Shared.Abstractions.csproj", "src/Shared/Calcis.Shared.Abstractions/"]
COPY ["src/Shared/Calcis.Shared.Infrastructure/Calcis.Shared.Infrastructure.csproj", "src/Shared/Calcis.Shared.Infrastructure/"]
COPY ["src/Modules/Base/Calcis.Modules.Base.Application/Calcis.Modules.Base.Application.csproj", "src/Modules/Base/Calcis.Modules.Base.Application/"]
COPY ["src/Modules/Base/Calcis.Modules.Base.Core/Calcis.Modules.Base.Core.csproj", "src/Modules/Base/Calcis.Modules.Base.Core/"]
COPY ["src/Modules/Base/Calcis.Modules.Base.Infrastructure/Calcis.Modules.Base.Infrastructure.csproj", "src/Modules/Base/Calcis.Modules.Base.Infrastructure/"]

RUN dotnet restore "src/Bootstraper/Calcis.Bootstraper/Calcis.Bootstraper.csproj"

# Kopiowanie pozosta³ych plików
COPY . .
WORKDIR "/src/src/Bootstraper/Calcis.Bootstraper"
RUN dotnet build "Calcis.Bootstraper.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ===========================
# PUBLISH STAGE
# ===========================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Calcis.Bootstraper.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ===========================
# FINAL STAGE (RUNTIME)
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

COPY --from=publish /app/publish .

HEALTHCHECK --interval=30s --timeout=10s CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "Calcis.Bootstraper.dll"]
