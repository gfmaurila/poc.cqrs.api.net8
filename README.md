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
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/0a014186-c661-4e09-b913-ab107b954aaa)
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/691cd9ff-a2aa-43b6-8779-60e8576df346)
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/805a243a-0e42-4da3-84e3-9c8a47f2822c)
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/e16b3ba3-fdea-4cea-8dcd-5f7568ea2c87)
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/ff9079a2-9ebb-4492-a2eb-14ea53b4e8cd)


# CQRS - Pattern
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/aab9aefa-6819-456b-94af-237686a6949e)
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/3e088ec5-5f08-4fdc-a11c-935cd3f394de)
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/9d1d947f-7a0b-4cad-828b-95dee1e8625e)
![image](https://github.com/gfmaurila/poc.cqrs.api.net8/assets/5544035/4ded984b-273c-45c6-93dd-9eb5acb2a349)



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


