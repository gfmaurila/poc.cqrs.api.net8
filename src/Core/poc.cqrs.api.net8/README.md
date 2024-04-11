# Estrutura da API
- ASP.NET Core 8.0: Framework para desenvolvimento da Microsoft.
- AutoMapper: Biblioteca para realizar mapeamento entre objetos.
- Swagger UI: Documentação para a API.
- XUnit
- FluentValidator
- MongoDb
- MediatR
- Serilog
- RabbitMQ
- Kafka
- Docker & Docker Compose

# Arquitetura
- CQRS
- Event Sourcing
- Repository Pattern
- Resut Pattern
- Domain Events

# Documentação - Arquitetura
- Clean Architecture: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/Clean-Architecture
- API: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/API
- CQRS: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/CQRS

# Documentação APIs

## Poc.Gateway.API
- Auth: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/01-%E2%80%90-Poc.Core.API-%E2%80%90-Gateway-%E2%80%90-Auth
- Person ???
- Notification: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/01-%E2%80%90-Poc.Core.API-%E2%80%90-Gateway-%E2%80%90-Notification
- User: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/01-%E2%80%90-Poc.Core.API-%E2%80%90-Gateway-%E2%80%90-User
- Region: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/02-%E2%80%90-Poc.RH.API-%E2%80%90-Gateway-%E2%80%90-Region

## Poc.Core.API
- Person: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/Person
- Notification: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/Notification
- User: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/User

## Third Party Services
- SendGridEmail: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/Third-Party-Services-%E2%80%90-SendGridEmail
- Twilio: https://github.com/gfmaurila/poc.cqrs.api.net8/wiki/Third-Party-Services-%E2%80%90-Twilio


# Wiki
- Link: https://github.com/gfmaurila/poc.cqrs.api.net8.wiki.git



## Configuração e Instalação

### Clonando o Repositório
Clone o repositório usando: https://github.com/gfmaurila/poc.cqrs.api.net8

### Configurando o Docker e Docker Compose
docker-compose up --build
http://localhost:5078/swagger/index.html

### SQL Server - API-Core
- Add-Migration Inicial -Context EFSqlServerContext
- Update-Database -Context EFSqlServerContext

### MySQL - API-MKT
- Add-Migration Inicial -Context MySQLContext
- Update-Database -Context MySQLContext

### Oracle - API-Core
- ALTER USER hr ACCOUNT UNLOCK;
- ALTER USER hr IDENTIFIED BY oracle;

## Youtube
- Instalação do projeto: https://youtu.be/orCUfM44huc


## Autor

- Guilherme Figueiras Maurila

[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)


