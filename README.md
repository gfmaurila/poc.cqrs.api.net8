# Introdução ao Projeto de Simulação de Desenvolvimento de Sistemas

Este projeto foi desenvolvido com o objetivo de simular um ambiente de desenvolvimento de sistemas que envolve a integração e manutenção de múltiplas APIs, cada uma com diferentes comportamentos, bancos de dados, mensagerias, arquiteturas e consumo de APIs. A simulação é destinada a profissionais que desejam treinar e se preparar para a manutenção de projetos de grande porte no mercado de trabalho.

## Objetivo do Projeto

O principal objetivo deste projeto é proporcionar um ambiente de simulação que permita aos profissionais treinar e entender como seria a manutenção e desenvolvimento de um grande projeto no mercado de trabalho. Através da utilização de diferentes tecnologias e práticas de mercado, os usuários poderão adquirir experiência prática e desenvolver habilidades essenciais para a gestão e integração de sistemas complexos.

Este projeto é uma excelente oportunidade para se familiarizar com diversas tecnologias, arquiteturas e práticas de integração de sistemas, preparando os profissionais para os desafios reais do mercado de desenvolvimento de software.


## Projeto - Backend - Frontend

- [Estrutura da API](#Estrutura-da-API)
- [Arquitetura](#Arquitetura)
- [Descrição das APIs](#Descrição-das-APIs)
- [Instalação](#Instalação)
- [Observação](#Observação)
- [Documentação](#Documentação)
- [Histórico de Alterações](#Histórico-de-Alterações)

## Estrutura da API
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

## Arquitetura
- CQRS
- Event Sourcing
- Repository Pattern
- Resut Pattern
- Domain Events

## Frontend
- React

## Descrição das APIs

### poc.cqrs.api.gateway.net8
- Responsável por integrar diversas APIs, incluindo autenticação, gestão de funcionários e envio de e-mails em massa. Facilita a comunicação entre as seguintes APIs:
- poc.cqrs.api.core.sqlserver.ef.net8: Autenticação e controle de acesso.
- poc.cqrs.api.rh.oracle.dapper.net8: Armazenamento de dados de funcionários.
- poc.cqrs.api.mkt.mysql.ef.net8: Gestão de campanhas de email marketing.
- poc.cqrs.api.mock.net8: Simulação de envios de email e mensagens.

### poc.cqrs.api.core.sqlserver.ef.net8
- API de autenticação para outros serviços. Gerencia tokens e controla o acesso com base nos papéis dos usuários.

### poc.cqrs.api.rh.oracle.dapper.net8
- Gerencia informações de pessoal e departamentos. Inclui operações administrativas no banco Oracle

### poc.cqrs.api.mkt.mysql.ef.net8
- API para gerenciamento de campanhas de email marketing.

### poc.cqrs.api.mock.net8
- Simula a funcionalidade de serviços de email e mensagens, como SendGridEmail e Twilio.

### NuGet Package:
- Biblioteca central que fornece classes e métodos utilizados por todos os projetos.


## Instalação:

Este guia fornecerá as instruções necessárias para a instalação e configuração do projeto de simulação de desenvolvimento de sistemas. Este projeto inclui múltiplas APIs, diferentes bancos de dados, mensagerias e componentes reutilizáveis, projetados para treinar profissionais na manutenção de grandes projetos de software. Siga as etapas abaixo para configurar o ambiente de desenvolvimento e começar a utilizar o projeto.

1. Clone:
    ```bash
    git clone https://github.com/gfmaurila/poc.cqrs.api.net8.git
    ```

2. Frontend - React:
    ```bash
    cd C:\Work\poc.cqrs.api.net8\front-end\poc.admin.react
    npm install
    yarn install
    npm start
    yarn start
    Acesso: http://localhost/ - Falta iniciar o projeto
    ```

3. Rodando a aplicação inteira:
    ```bash
    cd C:\Work\poc.cqrs.api.net8 
    docker-compose up --build
    
    Acesso Backend: http://localhost:5078/swagger/index.html
    Acesso Front: http://localhost/ - Falta iniciar o projeto

    ``` 

4. Rodando apenas poc.cqrs.api.core.sqlserver.ef.net8:
    ```bash
    cd C:\Work\poc.cqrs.api.net8\backend\poc.cqrs.api.core.sqlserver.ef.net8 
    Renomeie o arquivo C:\Work\poc.cqrs.api.net8\backend\poc.cqrs.api.core.sqlserver.ef.net8\src\01-Presentation\Poc.RH.API\Dockerfile-bkp para Dockerfile
    docker-compose up --build
    http://localhost:5075/swagger/index.html
    SQL Server
    ```

5. Rodando apenas poc.cqrs.api.rh.oracle.dapper.net8:
    ```bash
    cd C:\Work\poc.cqrs.api.net8\backend\poc.cqrs.api.rh.oracle.dapper.net8
    Renomeie o arquivo C:\Work\poc.cqrs.api.net8\backend\poc.cqrs.api.rh.oracle.dapper.net8\src\01-Presentation\Poc.RH.API\Dockerfile-bkp para Dockerfile
    docker-compose up --build
    http://localhost:5076/swagger/index.html
    Oracle

    SQL: ALTER USER hr ACCOUNT UNLOCK
         ALTER USER hr IDENTIFIED BY oracle
    ```

6. Rodando apenas poc.cqrs.api.mkt.mysql.ef.net8:
    ```bash
    cd C:\Work\poc.cqrs.api.net8\backend\poc.cqrs.api.mkt.mysql.ef.net8
    Renomeie o arquivo C:\Work\poc.cqrs.api.net8\backend\poc.cqrs.api.mkt.mysql.ef.net8\src\01-Presentation\Poc.RH.API\Dockerfile-bkp para Dockerfile
    docker-compose up --build
    http://localhost:5077/swagger/index.html
    MySQL
    ``` 

## Observação:

Para rodar todas as APIs juntas com SQL Server, Oracle, MySQL, Kafka, RabbitMQ, Redis, e MongoDB, você precisa de no mínimo 40GB de memória.

## Documentação:

Segue a pasta da documentação do projeto:

CD C:\Work\poc.cqrs.api.net8\doc\Doc

1. arquitetura.drawio
2. GitFlow.drawio
3. Poc.Core.API.drawio
4. Poc.MKT.API.drawio
5. Projeto de Sistema de RH.pdf

## Histórico de Alterações


<table style="word-break: break-all; white-space:pre-line; font-size:10pt;">
 <TR style="background:#1F4E79;color:White;">
  <TD>Data</TD>
  <TD>Desenvolvedor</TD>
  <TD>Descrição da alteração</TD>
  <TD>US-Não definida</TD>
 </TR>
 <TR style="background:white; color:black">
  <TD> 15/01/2024 </TD>
  <TD> Guilherme Figueiras Maurila </TD>
  <TD> Criação da documentação </TD>
  <TD> #0000 </TD> 
 </TR> 
</table>

## Índice Backend

- [API de Cadastros](#API-de-Cadastros)
- [API RH](#API-RH)
- [API E-mail Marketing](#API-E-mail-Marketing)


## API de Cadastros

### 1 - Comportamento Esperado - /api/v1/User
- Comportamento Esperado

1. Inserção em SQL Server: Este ponto indica que os dados devem ser persistidos em um banco de dados SQL Server, garantindo que as operações de inserção sejam feitas corretamente na base de dados específica.

2. Métodos Get e GetById:
    - Consulta e Cache: Quando os métodos Get (para buscar todos os dados) e GetById (para buscar dados por um identificador específico) são chamados, a primeira tentativa é verificar se os dados já estão em cache.
    - Evento de Domínio: Se os dados não estiverem em cache, um evento de domínio é acionado para buscar os dados da base de dados.
    - Armazenamento em Cache: Após a recuperação, os dados são armazenados em cache para otimizar futuras consultas. Este cache é configurado para manter os dados armazenados por duas horas, após as quais, se necessário, os dados serão buscados novamente e rearmazenados em cache.



### 1.1 - GET
    ```
    curl -X 'GET' \
    'https://localhost:44375/api/v1/User' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M'
    ```


### 1.2 - GET BY ID
    ```
    curl -X 'GET' \
    'https://localhost:44375/api/v1/User/2e4ad093-5908-45a8-8e94-ae1b2a6101d5' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M'
    ```

### 1.3 - Post - Create
    ```
    curl --location --request POST 'https://localhost:44375/api/v1/User' \
    --header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYTEwQGdtYWlsLmNvbSIsImlkIjoiYzdhMTE1MGYtYmNmMC00M2EzLTkxNzctODcwNmViNGVkMDQzIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVVNFUiIsImV4cCI6MTcxMTcxNTIxOCwiaXNzIjoiSnd0QXBpQXV0aCIsImF1ZCI6Ikp3dEFwaUF1dGgifQ.XYOFdEcMxlCzXHat7FEa-6intyItzjFswe_z87eaAwU' \
    --header 'Content-Type: application/json' \
    --data-raw '{
    "firstName": "Guilherme",
    "lastName": "Figueiras Maurila",
    "gender": 1,
    "notification": 1,
    "dateOfBirth": "1986-03-18",
    "email": "gfmaurila16@gmail.com",
    "phone": "519985623365",
    "password": "@****",
    "confirmpassword": "@*****",
    "roleUserAuth": [
        "USER"
    ]
    }'
    ```

### 1.5 - PUT - Update Password

- Este endpoint é usado exclusivamente para alterar a senha de um usuário existente.

    ```
    curl -X 'PUT' \
    'https://localhost:44375/api/v1/User/updatepassword' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "password": "******",
    "confirmpassword": "******"
    }'
    ```

### 1.6 - PUT - Update Email

- Este endpoint é usado exclusivamente para alterar o endereço de email de um usuário existente.

    ```
    curl -X 'PUT' \
    'https://localhost:44375/api/v1/User/updateemail' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "email": "user@example.com"
    }'
    ```

### 1.7 - PUT - Update Role

- Este endpoint é usado exclusivamente para alterar as permissões de um usuário existente.

    ```
    curl -X 'PUT' \
    'https://localhost:44375/api/v1/User/updaterole' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "roleUserAuth": [
        "string"
    ]
    }'
    ```

### 2 - Comportamento Esperado - /api/v1/Auth
- Comportamento Esperado

### 2.1 - POST

- Este endpoint autentica um usuário. É utilizado para verificar as credenciais de um usuário e retornar um token de autenticação caso as credenciais estejam corretas. Esse token é usado para acessar endpoints protegidos na aplicação.

    ```
    curl -X 'POST' \
    'https://localhost:44375/api/v1/Auth/login' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "email": "user@example.com",
    "password": "string"
    }'
    ```

### 2.2 - POST

- Este endpoint é usado para iniciar o processo de reset de senha de um usuário. Ao enviar uma solicitação de reset de senha, uma série de ações são desencadeadas para enviar um whatsapp com um link de redefinição de senha.

    - Envio da Solicitação: O usuário envia uma solicitação de reset de senha fornecendo o email associado à sua conta.
    - Publicação em Tópico RabbitMQ: Um evento é publicado em um tópico RabbitMQ para processar a solicitação de reset de senha.
    - Simulação do Envio de whatsapp: Um mock é utilizado para simular o envio de um whatsapp via API externa (Twilio). Este mock armazena as informações no banco de dados.
    - Armazenamento em Cache Redis: O banco de dados em cache Redis é utilizado para simular o recebimento do whatsapp, onde é gerado um link com um token de duração de duas horas.
    - Ação do Usuário: O usuário deve clicar no link recebido no whatsapp para redefinir sua senha. O link contém um token válido por duas horas.


    ```
    curl -X 'POST' \
    'https://localhost:44375/api/v1/Auth/resetpassword' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "email": "user@example.com"
    }'
    ```

### 2.3 - POST

- Este endpoint é utilizado para redefinir a senha de um usuário. Após o usuário receber um whatsapp de redefinição de senha com um link contendo um token, ele pode usar este endpoint para criar uma nova senha

    - Recebimento do Email de Redefinição: O usuário recebe um whatsapp com um link de redefinição de senha contendo um token válido por duas horas.
    - Envio da Solicitação de Redefinição: O usuário acessa o link, insere a nova senha e envia a solicitação junto com o token.

    ```
    curl -X 'POST' \
    'https://localhost:44375/api/v1/Auth/newpassword' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "password": "string",
    "confirmPassword": "string",
    "token": "string"
    }'
    ```

### 3 - Comportamento Esperado - /api/v1/Notification
- Comportamento Esperado

### 3.1 - POST - SMS

- Este endpoint é utilizado para testar o envio de mensagens via WhatsApp e SMS utilizando o serviço Twilio. Ele serve para verificar se a integração com o Twilio está funcionando corretamente e se as mensagens estão sendo enviadas conforme esperado.

- API: https://www.twilio.com

    ```
    curl -X 'POST' \
    'https://localhost:44375/api/v1/Notification/WhatsApp' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "notificationType": 0,
    "id": 0,
    "from": "string",
    "body": "string",
    "to": "string"
    }'
    ```

### 3.2 - POST - WhatsApp

    ```
    curl -X 'POST' \
    'https://localhost:44375/api/v1/Notification/WhatsApp' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "notificationType": 2,
    "id": 0,
    "from": "string",
    "body": "string",
    "to": "string"
    }'
    ```

### 3.3 - POST - E-mail

- API também suporta o envio de emails através do SendGrid.
- API: https://app.sendgrid.com/guide

    ```
    curl -X 'POST' \
    'https://localhost:44375/api/v1/Notification/Email' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjgwMjA3LCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.XQX5mkAxlMo8R29MOvuSiPEmRY29ANHz-OdwlL9-R1M' \
    -H 'Content-Type: application/json' \
    -d '{
    "notificationType": 0,
    "from": "string",
    "subject": "string",
    "htmlContent": "string",
    "to": "string",
    "name": "string"
    }'
    ```





## API RH

### 1 - Comportamento Esperado - /api/v1/Region
- Comportamento Esperado

1. Inserção em Oracle: Este ponto indica que os dados devem ser persistidos em um banco de dados Oracle, garantindo que as operações de inserção sejam feitas corretamente na base de dados específica.

2. Métodos Get e GetById:
    - Consulta e Cache: Quando os métodos Get (para buscar todos os dados) e GetById (para buscar dados por um identificador específico) são chamados, a primeira tentativa é verificar se os dados já estão em cache.
    - Evento de Domínio: Se os dados não estiverem em cache, um evento de domínio é acionado para buscar os dados da base de dados.
    - Armazenamento em Cache: Após a recuperação, os dados são armazenados em cache para otimizar futuras consultas. Este cache é configurado para manter os dados armazenados por duas horas, após as quais, se necessário, os dados serão buscados novamente e rearmazenados em cache.



### 1.1 - GET
    ```
    curl -X 'GET' \
    'https://localhost:44376/api/v1/Region' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk'
    ```

### 1.2 - GET BY ID
    ```
    curl -X 'GET' \
    'https://localhost:44376/api/v1/Region/5' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk'
    ```

### 1.3 - POST
    ```
    curl -X 'POST' \
    'https://localhost:44376/api/v1/Region' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk' \
    -H 'Content-Type: application/json' \
    -d '{
    "regionName": "string"
    }'
    ```

### 1.4 - PUT
    ```
    curl -X 'PUT' \
    'https://localhost:44376/api/v1/Region' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk' \
    -H 'Content-Type: application/json' \
    -d '{
    "regionId": 0,
    "regionName": "string"
    }'
    ```

### 1.5 - DELETE
    ```
    curl -X 'DELETE' \
    'https://localhost:44376/api/v1/Region/1' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk'
    ```



## API E-mail Marketing

### 1 - Comportamento Esperado - /api/v1/Post
- Comportamento Esperado

1. Inserção em MySQL: Este ponto indica que os dados devem ser persistidos em um banco de dados MySQL, garantindo que as operações de inserção sejam feitas corretamente na base de dados específica.

2. Métodos Get e GetById:
    - Consulta e Cache: Quando os métodos Get (para buscar todos os dados) e GetById (para buscar dados por um identificador específico) são chamados, a primeira tentativa é verificar se os dados já estão em cache.
    - Evento de Domínio: Se os dados não estiverem em cache, um evento de domínio é acionado para buscar os dados da base de dados.
    - Armazenamento em Cache: Após a recuperação, os dados são armazenados em cache para otimizar futuras consultas. Este cache é configurado para manter os dados armazenados por duas horas, após as quais, se necessário, os dados serão buscados novamente e rearmazenados em cache.



### 1.1 - GET
    ```
    curl -X 'GET' \
    'https://localhost:44377/api/v1/Post' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk'
    ```

### 1.2 - GET BY ID
    ```
    curl -X 'GET' \
    'https://localhost:44377/api/v1/Post/0a5fb604-19f5-42cf-9171-ec28b3d5ca6a' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk'
    ```

### 1.3 - POST
    ```
    curl -X 'POST' \
    'https://localhost:44377/api/v1/Post' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk' \
    -H 'Content-Type: application/json' \
    -d '{
    "title": "string",
    "content": "string"
    }'
    ```

### 1.4 - PUT
    ```
    curl -X 'PUT' \
    'https://localhost:44377/api/v1/Post' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk' \
    -H 'Content-Type: application/json' \
    -d '{
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "title": "string",
    "content": "string"
    }'
    ```

### 1.5 - DELETE
    ```
    curl -X 'DELETE' \
    'https://localhost:44377/api/v1/Post/3fa85f64-5717-4562-b3fc-2c963f66afa6' \
    -H 'accept: application/json' \
    -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6ImdmbWF1cmlsYUBnbWFpbC5jb20iLCJpZCI6IjhhOGNhY2JlLTI2NDUtNDA5MC1hYzgwLTQwNTAyMTRkNGRlOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJVU0VSIiwiQ1JFQVRFX1VTRVIiLCJVUERBVEVfVVNFUiIsIkRFTEVURV9VU0VSIiwiR0VUX1VTRVIiLCJHRVRfQllfSURfVVNFUiIsIk5PVElGSUNBVElPTiIsIkNSRUFURV9OT1RJRklDQVRJT04iLCJERUxFVEVfTk9USUZJQ0FUSU9OIiwiR0VUX05PVElGSUNBVElPTiIsIlJFR0lPTiIsIkNPVU5UUkkiLCJERVBBUlRNRU5UIiwiRU1QTE9ZRUUiLCJKT0IiLCJKT0JfSElTVE9SWSIsIkxPQ0FUSU9OIiwiTUtUX1BPU1QiXSwiZXhwIjoxNzIxMjg3MTEzLCJpc3MiOiJKd3RBcGlBdXRoIiwiYXVkIjoiSnd0QXBpQXV0aCJ9.xSDTsJaNW69Em-GOUZ-e-PE8xinNAWnE3NkIAYjs7mk'
    ```



## Youtube
- ......

## Autor

- Guilherme Figueiras Maurila

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)

📧 Email: gfmaurila@gmail.com


