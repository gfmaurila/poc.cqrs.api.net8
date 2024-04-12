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

# Raiz do projeto

## Clone o projeto usando o seguinte comando: 
- https://github.com/gfmaurila/poc.cqrs.api.net8
    - cd poc.cqrs.api.net8 > cd src
        - git clone https://github.com/gfmaurila/poc.cqrs.api.gateway.net8.git
        - git clone https://github.com/gfmaurila/poc.cqrs.api.core.sqlserver.ef.net8.git
        - git clone https://github.com/gfmaurila/poc.cqrs.api.rh.oracle.dapper.net8.git
        - git clone https://github.com/gfmaurila/poc.cqrs.api.mkt.mysql.ef.net8.git
        - git clone https://github.com/gfmaurila/poc.cqrs.api.mock.net8.git
    

# Descrição das APIs

## poc.cqrs.api.gateway.net8
- Responsável por integrar diversas APIs, incluindo autenticação, gestão de funcionários e envio de e-mails em massa. Facilita a comunicação entre as seguintes APIs:
- poc.cqrs.api.core.sqlserver.ef.net8: Autenticação e controle de acesso.
- poc.cqrs.api.rh.oracle.dapper.net8: Armazenamento de dados de funcionários.
- poc.cqrs.api.mkt.mysql.ef.net8: Gestão de campanhas de email marketing.
- poc.cqrs.api.mock.net8: Simulação de envios de email e mensagens.
- docker-compose up --build
- http://localhost:5078/swagger/index.html

## poc.cqrs.api.core.sqlserver.ef.net8
- API de autenticação para outros serviços. Gerencia tokens e controla o acesso com base nos papéis dos usuários.
- docker-compose up --build
- http://localhost:5075/swagger/index.html
- SQL Server

## poc.cqrs.api.rh.oracle.dapper.net8
- Gerencia informações de pessoal e departamentos. Inclui operações administrativas no banco Oracle
- docker-compose up --build
- http://localhost:5076/swagger/index.html
- ALTER USER hr ACCOUNT UNLOCK;
- ALTER USER hr IDENTIFIED BY oracle;

## poc.cqrs.api.mkt.mysql.ef.net8
- API para gerenciamento de campanhas de email marketing.
- docker-compose up --build
- http://localhost:5077/swagger/index.html

## poc.cqrs.api.mock.net8
- Simula a funcionalidade de serviços de email e mensagens, como SendGridEmail e Twilio.
- http://localhost:5254/swagger/index.html

## NuGet Package: https://github.com/gfmaurila/poc.api.net8
- Biblioteca central que fornece classes e métodos utilizados por todos os projetos.
- Install-Package poc.core.api.net8 --version 1.0.0
- https://www.nuget.org/packages/poc.core.api.net8

## Youtube
- ......

## Autor

- Guilherme Figueiras Maurila

[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)


