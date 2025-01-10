# InfoDengue WebAPI

InfoDengue é uma aplicação web API construída em .NET 8 que fornece um sistema de cadastro, consulta e monitoramento de casos de dengue. A API permite o gerenciamento e análise de dados relacionados a surtos e casos registrados.

## Funcionalidades

- **Cadastro de Casos de Dengue**: Registro de novos casos, com informações como localização, data de registro, e gravidade.
- **Consulta de Casos**: API para consultar casos de dengue registrados por parâmetros como data, localização e gravidade.
- **Relatórios**: Geração de relatórios sobre a evolução dos casos de dengue.
- **Segurança**: Autenticação com JWT para garantir que apenas usuários autorizados possam acessar os dados.

## Tecnologias Utilizadas

- **Backend**: .NET 8, ASP.NET Core Web API, Entity Framework Core
- **Banco de Dados**: MSSQL Server ou qualquer banco de dados compatível com Entity Framework
- **Autenticação**: JWT (JSON Web Tokens)

## Estrutura do Projeto

- **Controllers**: Contém a lógica para expor os endpoints da API.
- **Models**: Contém os modelos de dados, como `CasoDengue`, que representam os casos de dengue.
- **Services**: Contém a lógica de negócios.
- **Data**: Contém o contexto do banco de dados e as migrações.

## Instruções de Instalação

### Pré-requisitos

- .NET SDK 8 ou superior
- MSSQL Server (ou qualquer banco de dados compatível com Entity Framework)
- Visual Studio ou Visual Studio Code

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu_usuario/InfoDengue.git

2. Navegue até a pasta do projeto:

cd InfoDengue

3. Restaure as dependências:

dotnet restore

4. Gere a migração e atualize o banco de dados:

dotnet ef migrations add InitialCreate --context DataContext
dotnet ef database update --context DataContext

5. Execute o projeto:

dotnet run

6. Acesse a aplicação no navegador ou utilize uma ferramenta como o Postman para testar os endpoints da API:

Copiar código](http://localhost:5000/api/casos)

Endpoints da API
GET /api/casos: Obtém todos os casos de dengue.
GET /api/casos/{id}: Obtém um caso específico de dengue pelo ID.
POST /api/casos: Registra um novo caso de dengue.
PUT /api/casos/{id}: Atualiza um caso de dengue.
DELETE /api/casos/{id}: Exclui um caso de dengue.
