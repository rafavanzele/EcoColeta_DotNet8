# EcoColeta API

API REST desenvolvida em .NET 8 para gerenciamento de resíduos, pontos de coleta e coletas realizadas.
O projeto está alinhado ao tema ESG "Gestão de Resíduos e Reciclagem", promovendo o controle de resíduos, 
pontos de coleta e registros de coletas realizadas.

Projeto acadêmico desenvolvido para praticar conceitos de:

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Repository Pattern
- Service Layer
- Injeção de Dependência
- Data Annotations
- Tratamento Global de Exceções
- Swagger
- Insomnia
- Docker


## Funcionalidades:
- Tipo de Resíduo
Listar tipos de resíduos
Buscar tipo de residuo por ID
Cadastrar novo tipo
Atualizar tipo existente
Excluir tipo

- Ponto de Coleta
Listar pontos de coleta
Buscar ponto de coleta por ID
Cadastrar novo ponto
Atualizar ponto existente
Excluir ponto

- Coleta de Resíduos
Listar coletas
Buscar coleta por ID
Registrar coleta
Atualizar coleta
Excluir coleta

Listar tipos de resíduos (com paginação)
Listar pontos de coleta (com paginação)
Listar coletas (com paginação)

## Arquitetura:
O projeto segue uma arquitetura em camadas:

Controllers
    ↓
Services
    ↓
Repositories
    ↓
Entity Framework Core
    ↓
SQL Server


## Estrutura principal:
EcoColeta.Api
│
├── Controllers
├── Services
├── Repositories
├── Models
├── Data
├── Middlewares
├── Configurations
└── Migrations

## Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8
- SQL Server
- Azure SQL Database
- Azure App Service
- GitHub Actions
- Docker
- Docker Compose
- Docker Desktop
- Swagger / OpenAPI
- Insomnia
- xUnit
- Repository Pattern
- Service Layer
- Injeção de Dependência
- Data Annotations
- Middleware para tratamento global de exceções
- Basic Authentication
- Authorization para proteção de endpoints críticos
## Validações Implementadas:
- TipoResiduo
Nome obrigatório
Nome com máximo de 100 caracteres
- PontoColeta
Nome obrigatório
Localização obrigatória
Capacidade máxima maior que zero
Status obrigatório
- ColetaResiduo
Data obrigatória
Quantidade maior que zero
Ponto de coleta obrigatório
Tipo de resíduo obrigatório

## Tratamento Global de Exceções:
Foi implementado um Middleware global para tratamento de erros.
Exemplo de retorno 404
{
  "status": 404,
  "mensagem": "Tipo de resíduo com ID 999 não encontrado."
}
Exemplo de retorno 500
{
  "status": 500,
  "mensagem": "Ocorreu um erro interno no servidor."
}

## Testes
O projeto possui testes unitários utilizando xUnit para validação dos endpoints principais.
Foram implementados testes de integração para verificar o retorno HTTP Status Code 200 dos endpoints de listagem, 
conforme solicitado no enunciado da atividade.

## Documentação Swagger:
Ao executar a aplicação:

https://localhost:7068/swagger

A documentação interativa permite:
- Testar endpoints
- Visualizar modelos
- Validar respostas
- Simular erros


## Testes Realizados:
- Swagger
- CRUD completo
- Validações
- Erros 400
- Erros 404
- Insomnia
- GET
- POST
- PUT
- DELETE
- Testes de sucesso
- Testes de erro


## Pipeline CI/CD

O projeto utiliza GitHub Actions para automatizar o processo de integração e entrega contínua.

O pipeline de CI executa automaticamente a cada push ou pull request realizado na branch `main` e possui as seguintes etapas:

- Checkout do código-fonte.
- Configuração do ambiente .NET.
- Restauração das dependências da aplicação e dos testes.
- Inicialização de uma instância SQL Server para o ambiente de testes.
- Aplicação das migrations do Entity Framework Core.
- Build da aplicação em configuração Release.
- Execução automatizada dos testes com xUnit.

Além do pipeline de integração contínua, foram configurados workflows de deployment contínuo para os ambientes de staging e produção.

Os deployments são realizados automaticamente por meio do GitHub Actions para aplicações hospedadas no Azure App Service:

- **Staging:** `ecocoleta-api-staging`
- **Produção:** `ecocoleta-api`

Os dois ambientes utilizam o Azure SQL Database como banco de dados e possuem configurações independentes no Azure App Service.


## Containerização

A aplicação EcoColeta foi containerizada utilizando Docker, permitindo a criação de um ambiente padronizado e reproduzível para execução da API.

O projeto utiliza um Dockerfile multi-stage baseado nas imagens oficiais do .NET 8. O processo é dividido em etapas de build e publicação da aplicação, gerando ao final uma imagem contendo apenas os componentes necessários para sua execução.

Além da imagem da API, o projeto utiliza Docker Compose para orquestrar os serviços necessários ao ambiente local, permitindo a execução integrada da aplicação e do banco de dados SQL Server.

A configuração do Docker Compose utiliza:

- Serviço da API EcoColeta.
- Serviço do SQL Server.
- Variáveis de ambiente para configuração da aplicação e do banco de dados.
- Volume persistente para os dados do SQL Server.
- Rede Docker para comunicação entre os serviços.

### Dockerfile

O Dockerfile utiliza uma estratégia multi-stage build, separando as etapas de execução, compilação, publicação e imagem final da aplicação.

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EcoColeta.Api.csproj", "."]
RUN dotnet restore "./EcoColeta.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./EcoColeta.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EcoColeta.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcoColeta.Api.dll"]
```

## Como executar localmente com Docker

Para executar a aplicação e o banco de dados localmente utilizando Docker Compose:

1. Clone o repositório:

```bash
git clone https://github.com/rafavanzele/EcoColeta_DotNet8.git
```

2. Acesse a pasta do projeto:

```bash
cd EcoColeta_DotNet8
```

3. Crie o arquivo `.env` a partir do `.env.example` e defina uma senha forte para o SQL Server:

```env
SA_PASSWORD=SuaSenhaForteAqui
```

4. Execute os serviços com Docker Compose:

```bash
docker compose up --build -d
```

O Docker Compose realizará o build da API e iniciará os containers da aplicação e do SQL Server.

A API ficará disponível em:

```text
http://localhost:8080
```

Para encerrar os containers:

```bash
docker compose down
```

## Autor
- Rafael Vanzele Gomes
- Aluno de Análise e Desenvolvimento de Sistemas - FIAP

Repositório:
https://github.com/rafavanzele/EcoColeta_DotNet8
