FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5074

ENV ASPNETCORE_URLS=http://+:5074
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/07-Mock

# Copia o arquivo .csproj para o diretorio de trabalho atual no container
COPY src/07-Mock/poc.api.redis.net8/poc.api.redis.csproj .

# Restaura as dependencias do projeto
RUN dotnet restore poc.api.redis.csproj

# Copia o restante dos arquivos do projeto para o container
COPY . .

# Define o diretorio de trabalho e constroi o projeto
WORKDIR /src/07-Mock
RUN dotnet build src/07-Mock/poc.api.redis.net8/poc.api.redis.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish src/07-Mock/poc.api.redis.net8/poc.api.redis.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "poc.api.redis.dll"]