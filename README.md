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

## Tecnologias Utilizadas:
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Swagger/OpenAPI
- Insomnia
- Docker Desktop
- Middleware para Tratamento Global de Exceções
- Service Layer
- Injeção de dependência
- Data Annotations para validação de modelos
- xUnit
- Basic Authentication
- Authorization com proteção de endpoints críticos

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


## Docker:
Imagem criada com sucesso utilizando Docker Desktop.

- Build da imagem:
docker build -t ecocoleta-api .

- Execução do container:
docker run -d -p 8080:8080 --name ecocoleta-container ecocoleta-api

## *Observação:
O projeto utiliza:
- (localdb)\MSSQLLocalDB
O LocalDB está disponível apenas no ambiente Windows local.
Para execução completa em Docker é necessário utilizar uma instância SQL Server acessível pelo container.

## Como Executar o Projeto:
- Clonar repositório:
git clone https://github.com/rafavanzele/EcoColeta_DotNet8.git
- Entrar na pasta:
cd EcoColeta_DotNet8
- Restaurar dependências:
dotnet restore
- Executar aplicação:
dotnet run


## Autor
- Rafael Vanzele Gomes
- Aluno de Análise e Desenvolvimento de Sistemas - FIAP

Repositório:
https://github.com/rafavanzele/EcoColeta_DotNet8