FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5074

ENV ASPNETCORE_URLS=http://+:5074
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/poc.cqrs.api.mock.net8

# Copia o arquivo .csproj para o diretorio de trabalho atual no container
COPY src/poc.cqrs.api.mock.net8/poc.api.redis.net8/poc.api.redis.csproj .

# Restaura as dependencias do projeto
RUN dotnet restore poc.api.redis.csproj

# Copia o restante dos arquivos do projeto para o container
COPY . .

# Define o diretorio de trabalho e constroi o projeto
WORKDIR /src/poc.cqrs.api.mock.net8
RUN dotnet build src/poc.cqrs.api.mock.net8/poc.api.redis.net8/poc.api.redis.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish src/poc.cqrs.api.mock.net8/poc.api.redis.net8/poc.api.redis.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "poc.api.redis.dll"]