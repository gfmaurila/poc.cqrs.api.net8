FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5078

ENV ASPNETCORE_URLS=http://+:5078
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/01-Presentation

# Copia o arquivo .csproj para o diretorio de trabalho atual no container
COPY src/01-Presentation/Poc.Gateway.API/Poc.Gateway.API.csproj .

# Restaura as dependencias do projeto
RUN dotnet restore Poc.Gateway.API.csproj

# Copia o restante dos arquivos do projeto para o container
COPY . .

# Define o diretorio de trabalho e constroi o projeto
WORKDIR /src/01-Presentation
RUN dotnet build src/01-Presentation/Poc.Gateway.API/Poc.Gateway.API.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish src/01-Presentation/Poc.Gateway.API/Poc.Gateway.API.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.Gateway.API.dll"]
