# ===========================
# BUILD STAGE
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
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

# Kopiowanie reszty plików
COPY . .

WORKDIR "/src/src/Bootstraper/Calcis.Bootstraper"
RUN dotnet build "Calcis.Bootstraper.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/build \
    /p:DebugType=portable \
    /p:DebugSymbols=true

# ===========================
# PUBLISH STAGE
# ===========================
FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "Calcis.Bootstraper.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false \
    /p:DebugType=portable \
    /p:DebugSymbols=true \
    /p:PublishReadyToRun=false

# ===========================
# FINAL STAGE (RUNTIME)
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

# Kopiujemy aplikacjê i PDB
COPY --from=publish /app/publish ./
# Jeœli chcesz, mo¿esz te¿ trzymaæ PDB w osobnym folderze
# COPY --from=publish /app/publish/*.pdb ./  

HEALTHCHECK --interval=30s --timeout=10s CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "Calcis.Bootstraper.dll"]
