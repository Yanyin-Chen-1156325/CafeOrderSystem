# syntax=docker/dockerfile:1

ARG DOTNET_VERSION=10.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

# Copy csproj first for better layer caching
COPY CafeOrderSystem.Api/CafeOrderSystem.Api.csproj CafeOrderSystem.Api/
RUN dotnet restore CafeOrderSystem.Api/CafeOrderSystem.Api.csproj

# Copy the rest of the source
COPY . .

RUN dotnet publish CafeOrderSystem.Api/CafeOrderSystem.Api.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS final
WORKDIR /app

# Kestrel in containers: listen on HTTP
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Persist SQLite under /app/data (mount a volume here in docker-compose / VM)
RUN mkdir -p /app/data
ENV ConnectionStrings__DefaultConnection="Data Source=/app/data/cafeordersystem.db"

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CafeOrderSystem.Api.dll"]
