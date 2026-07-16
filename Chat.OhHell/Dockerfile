# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Chat.OhHell.csproj ./
RUN dotnet restore Chat.OhHell.csproj

COPY . ./
RUN dotnet publish Chat.OhHell.csproj \
    --configuration Release \
    --output /app/publish \
    --no-restore \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production \
    ASPNETCORE_FORWARDEDHEADERS_ENABLED=true \
    PORT=10000

COPY --from=build --chown=$APP_UID:$APP_UID /app/publish ./

USER $APP_UID
EXPOSE 10000

# Render fornece PORT em runtime. O fallback permite executar a imagem localmente.
CMD ["/bin/sh", "-c", "exec dotnet Chat.OhHell.dll --urls http://0.0.0.0:${PORT:-10000}"]
