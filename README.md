# Introdução ao Projeto de Simulação de Desenvolvimento de Sistemas

Este projeto foi desenvolvido com o objetivo de simular um ambiente de desenvolvimento de sistemas que envolve a integração e manutenção de múltiplas APIs, cada uma com diferentes comportamentos, bancos de dados, mensagerias, arquiteturas e consumo de APIs. A simulação é destinada a profissionais que desejam treinar e se preparar para a manutenção de projetos de grande porte no mercado de trabalho.

# Componentes do Projeto

# 1. NuGet Package: poc.core.net8
O pacote poc.core.net8 foi criado para ser reutilizado por todas as APIs do projeto, fornecendo uma base comum e facilitando a integração entre os diferentes serviços.

# 2. API: poc.cqrs.api.core.sqlserver.ef.net8
Esta API centraliza o cadastro de usuários de diversos setores, utilizando o Entity Framework e o SQL Server como banco de dados. Ela é essencial para gerenciar informações de usuários de maneira eficiente e segura.

# 3. API: poc.cqrs.api.rh.oracle.dapper.net8
Responsável pelo cadastro de funcionários do sistema, esta API utiliza o Dapper e o Oracle como banco de dados. Ela é projetada para lidar com grandes volumes de dados de funcionários, garantindo rapidez e eficiência nas operações.

# 4. API: poc.cqrs.api.mkt.mysql.ef.net8
Focada no envio de emails de propaganda, esta API utiliza o Entity Framework e o MySQL como banco de dados. Ela é crucial para as operações de marketing, permitindo o envio automatizado de campanhas publicitárias.

# 5. API: poc.cqrs.api.mock.net8

Estas são APIs mínimas criadas para simular o consumo de APIs e a postagem de envio de emails usando mensagerias como Kafka e RabbitMQ. Elas são fundamentais para testar e garantir a robustez do sistema em ambientes de produção.

# Objetivo do Projeto

O principal objetivo deste projeto é proporcionar um ambiente de simulação que permita aos profissionais treinar e entender como seria a manutenção e desenvolvimento de um grande projeto no mercado de trabalho. Através da utilização de diferentes tecnologias e práticas de mercado, os usuários poderão adquirir experiência prática e desenvolver habilidades essenciais para a gestão e integração de sistemas complexos.

Este projeto é uma excelente oportunidade para se familiarizar com diversas tecnologias, arquiteturas e práticas de integração de sistemas, preparando os profissionais para os desafios reais do mercado de desenvolvimento de software.


## Projeto

- [Estrutura da API](#visão-geral)
- [Arquitetura](#tecnologias-utilizadas)
- [Descrição das APIs](#uso)
- [Instalação](#instalação)
- [poc.cqrs.api.gateway.net8](#requisitos)



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

# Descrição das APIs

## poc.cqrs.api.gateway.net8
- Responsável por integrar diversas APIs, incluindo autenticação, gestão de funcionários e envio de e-mails em massa. Facilita a comunicação entre as seguintes APIs:
- poc.cqrs.api.core.sqlserver.ef.net8: Autenticação e controle de acesso.
- poc.cqrs.api.rh.oracle.dapper.net8: Armazenamento de dados de funcionários.
- poc.cqrs.api.mkt.mysql.ef.net8: Gestão de campanhas de email marketing.
- poc.cqrs.api.mock.net8: Simulação de envios de email e mensagens.
- docker-compose up --build
- http://localhost:5078/swagger/index.html
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/4a8dd47a-728d-4e22-8583-b66664f6615e)


## poc.cqrs.api.core.sqlserver.ef.net8
- API de autenticação para outros serviços. Gerencia tokens e controla o acesso com base nos papéis dos usuários.
- docker-compose up --build
- http://localhost:5075/swagger/index.html
- SQL Server
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/f8d7de83-0bb6-4fdf-a462-5d92c01c32ed)


## poc.cqrs.api.rh.oracle.dapper.net8
- Gerencia informações de pessoal e departamentos. Inclui operações administrativas no banco Oracle
- docker-compose up --build
- http://localhost:5076/swagger/index.html
- ALTER USER hr ACCOUNT UNLOCK;
- ALTER USER hr IDENTIFIED BY oracle;
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/f8d7de83-0bb6-4fdf-a462-5d92c01c32ed)

## poc.cqrs.api.mkt.mysql.ef.net8
- API para gerenciamento de campanhas de email marketing.
- docker-compose up --build
- http://localhost:5077/swagger/index.html
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/f8d7de83-0bb6-4fdf-a462-5d92c01c32ed)

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

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)

📧 Email: gfmaurila@gmail.com


