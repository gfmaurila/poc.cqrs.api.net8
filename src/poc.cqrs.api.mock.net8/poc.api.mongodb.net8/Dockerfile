FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5073

ENV ASPNETCORE_URLS=http://+:5073
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/poc.cqrs.api.mock.net8

COPY src/poc.cqrs.api.mock.net8/poc.api.mongodb.net8/poc.api.mongodb.csproj .

RUN dotnet restore poc.api.mongodb.csproj

COPY . .

WORKDIR /src/poc.cqrs.api.mock.net8
RUN dotnet build src/poc.cqrs.api.mock.net8/poc.api.mongodb.net8/poc.api.mongodb.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish src/poc.cqrs.api.mock.net8/poc.api.mongodb.net8/poc.api.mongodb.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "poc.api.mongodb.dll"]