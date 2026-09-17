<div align="center">🏁 DragTeamAPI

REST API para gerenciamento de equipes de Drag Racing

<p>
  <strong>C# • .NET 8 • ASP.NET Core • Entity Framework Core • PostgreSQL • Docker</strong>
</p><p>
  <a href="#-sobre-o-projeto">Sobre</a> •
  <a href="#-tecnologias">Tecnologias</a> •
  <a href="#-arquitetura">Arquitetura</a> •
  <a href="#-funcionalidades">Funcionalidades</a> •
  <a href="#-como-executar">Como executar</a> •
  <a href="#-api-em-produção">Produção</a>
</p></div>---

🏎️ Sobre o projeto

A DragTeamAPI é uma REST API desenvolvida para gerenciamento de informações relacionadas a equipes de Drag Racing, permitindo cadastrar e consultar equipes, pilotos, mecânicos e carros.

O projeto foi desenvolvido com foco em backend utilizando C# e .NET, aplicando conceitos de arquitetura em camadas, persistência de dados com Entity Framework Core, relacionamentos entre entidades, DTOs, injeção de dependência e autenticação.

Além do desenvolvimento da API, o projeto também passou por um processo de preparação para produção, incluindo Docker, PostgreSQL, migrations e deploy em ambiente cloud através do Render.

«🏁 Código. Engenharia. Velocidade.»

---

🎯 Objetivos

O projeto tem como principais objetivos:

- Praticar desenvolvimento de APIs REST com ASP.NET Core;
- Aplicar conceitos de orientação a objetos com C#;
- Trabalhar com Entity Framework Core;
- Implementar persistência de dados utilizando PostgreSQL;
- Trabalhar com relacionamentos entre entidades;
- Utilizar DTOs para comunicação entre API e cliente;
- Aplicar Dependency Injection;
- Trabalhar com migrations;
- Utilizar Docker para ambiente de desenvolvimento;
- Aprender conceitos relacionados a deploy e produção;
- Diagnosticar problemas de configuração e banco de dados em ambiente cloud.

---

🛠️ Tecnologias

<div align="center"><table>
<tr>
<td align="center" width="150">
<strong>Backend</strong>
</td>
<td align="center" width="150">
<strong>Database</strong>
</td>
<td align="center" width="150">
<strong>DevOps</strong>
</td>
</tr><tr>
<td align="center">C#<br>
.NET 8<br>
ASP.NET Core<br>
Entity Framework Core

</td><td align="center">PostgreSQL<br>
Npgsql<br>
EF Core Migrations

</td><td align="center">Docker<br>
Docker Compose<br>
Render<br>
Git/GitHub

</td>
</tr>
</table></div>---

🧩 Arquitetura

O projeto utiliza uma arquitetura organizada em camadas, separando responsabilidades entre os principais componentes da aplicação.

DragTeamAPI
│
├── Controllers
│   └── Responsáveis pelos endpoints HTTP
│
├── Services
│   └── Regras e lógica da aplicação
│
├── Repository
│   └── Acesso e persistência dos dados
│
├── Models
│   └── Entidades do domínio
│
├── DTOs
│   └── Objetos utilizados na comunicação da API
│
├── Data
│   └── DbContext e configuração do Entity Framework
│
├── Migrations
│   └── Versionamento do banco de dados
│
└── Program.cs
    └── Configuração da aplicação e Dependency Injection

Fluxo da aplicação

HTTP Request
     │
     ▼
Controller
     │
     ▼
Service
     │
     ▼
Repository
     │
     ▼
Entity Framework Core
     │
     ▼
PostgreSQL

---

🏁 Modelo de domínio

A API trabalha atualmente com quatro entidades principais:

              ┌─────────────┐
              │    Team     │
              └──────┬──────┘
                     │
          ┌──────────┼──────────┐
          │          │          │
          ▼          ▼          ▼
      Drivers      Cars     Mechanics

Team

Representa uma equipe de Drag Racing.

Principais propriedades:

- "Id"
- "Name"
- "City"

Driver

Representa um piloto associado a uma equipe.

Principais propriedades:

- "Id"
- "Name"
- "Nickname"
- "TeamId"

Car

Representa um carro pertencente a uma equipe.

Principais propriedades:

- "Id"
- "Name"
- "Model"
- "Engine"
- "Horsepower"
- "QualifyingTime"
- "TeamId"

Mechanic

Representa um mecânico associado a uma equipe.

Principais propriedades:

- "Id"
- "Name"
- "Specialty"
- "TeamId"

---

🚀 Funcionalidades

👥 Teams

- Criar equipes;
- Consultar equipes;
- Atualizar equipes;
- Remover equipes;
- Associar pilotos, carros e mecânicos às equipes.

🧑‍🔧 Mechanics

- Cadastro de mecânicos;
- Consulta de mecânicos;
- Associação com equipes;
- Especialidade profissional.

🏎️ Cars

- Cadastro de carros;
- Informações de motor;
- Potência;
- Tempo de classificação;
- Associação com equipes.

🏁 Drivers

- Cadastro de pilotos;
- Nome e apelido;
- Associação com equipes.

---

📡 API

A API disponibiliza endpoints REST para gerenciamento dos recursos.

Exemplo:

POST /Team

Exemplo de payload:

{
  "name": "Night Rider Garage",
  "city": "Itatiba"
}

Resposta:

{
  "id": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "name": "Night Rider Garage",
  "city": "Itatiba",
  "mechanics": [],
  "drivers": [],
  "cars": []
}

---

🗄️ Banco de dados

O projeto utiliza PostgreSQL como banco de dados relacional.

O Entity Framework Core é responsável pelo mapeamento objeto-relacional e gerenciamento das migrations.

Principais tabelas

Teams
Drivers
Cars
Mechanics
__EFMigrationsHistory

Relacionamentos

Teams
  │
  ├── 1:N ── Drivers
  │
  ├── 1:N ── Cars
  │
  └── 1:N ── Mechanics

---

🔄 Migrations

O banco é versionado através do Entity Framework Core Migrations.

Para visualizar as migrations:

dotnet ef migrations list

Para criar uma nova migration:

dotnet ef migrations add NomeDaMigration

Para aplicar as migrations:

dotnet ef database update

---

🐳 Docker

O projeto utiliza Docker para facilitar a configuração do ambiente de desenvolvimento.

Subir os containers

docker compose up -d

Verificar os containers

docker ps

Parar os containers

docker compose down

---

⚙️ Configuração

A connection string do PostgreSQL não é armazenada diretamente no código-fonte.

Em desenvolvimento, pode ser configurada utilizando User Secrets.

Exemplo:

dotnet user-secrets set "ConnectionStrings:PostgresConnection" "Host=localhost;Port=5432;Database=DragTeamDB;Username=postgres;Password=sua_senha"

Em produção, a connection string é configurada através das variáveis de ambiente do serviço de hospedagem.

«🔐 Dados sensíveis, como senhas e connection strings de produção, não devem ser versionados no GitHub.»

---

▶️ Como executar

Pré-requisitos

Antes de executar o projeto, certifique-se de possuir:

- ".NET 8 SDK" (https://dotnet.microsoft.com/)
- PostgreSQL
- Docker Desktop
- Git

1. Clone o repositório

git clone https://github.com/Bru-Fasani/DragTeamAPI.git

Entre na pasta:

cd DragTeamAPI

2. Configure a connection string

Configure o PostgreSQL utilizando User Secrets ou variáveis de ambiente.

3. Execute as migrations

dotnet ef database update

4. Execute a aplicação

dotnet run

5. Acesse o Swagger

Com a aplicação em execução, abra a URL indicada no terminal para acessar a documentação interativa da API.

---

☁️ Deploy

A aplicação está preparada para execução em ambiente de produção utilizando:

GitHub
   │
   ▼
Render
   │
   ├── DragTeamAPI
   │
   └── PostgreSQL

Durante o processo de deploy, foi realizada a migração do banco originalmente utilizado no projeto para PostgreSQL, além da configuração das migrations no banco de produção.

---

🧪 Testes

A API pode ser testada através do Swagger, permitindo executar requisições diretamente pela interface da documentação.

Também fazem parte dos estudos do projeto conceitos relacionados a testes automatizados utilizando:

- xUnit
- Testes unitários
- Testes de serviços
- Testes de endpoints

---

📚 Principais aprendizados

Este projeto foi desenvolvido também como uma forma de aprofundar conhecimentos em desenvolvimento backend.

Entre os principais aprendizados estão:

- Desenvolvimento de APIs REST;
- C# e ASP.NET Core;
- Entity Framework Core;
- PostgreSQL;
- Modelagem de dados relacionais;
- Migrations;
- Dependency Injection;
- Repository Pattern;
- DTOs;
- Docker;
- Variáveis de ambiente;
- User Secrets;
- Deploy em cloud;
- Diagnóstico de erros em produção;
- Integração entre aplicação, banco de dados e infraestrutura.

Um dos desafios encontrados durante o deploy foi o erro:

relation "Teams" does not exist

A API conseguia se conectar ao PostgreSQL, porém as migrations ainda não haviam sido aplicadas ao banco de produção.

A investigação através dos logs e do Entity Framework Core permitiu identificar que as migrations estavam pendentes e aplicar o schema corretamente.

---

📈 Próximos passos

Algumas melhorias planejadas para o projeto:

- [ ] Implementar autenticação e autorização com JWT;
- [ ] Adicionar validações mais robustas;
- [ ] Implementar testes unitários;
- [ ] Implementar testes de integração;
- [ ] Melhorar tratamento global de exceções;
- [ ] Adicionar logging estruturado;
- [ ] Implementar paginação;
- [ ] Adicionar filtros e ordenação;
- [ ] Criar documentação mais completa dos endpoints;
- [ ] Implementar CI/CD;
- [ ] Melhorar observabilidade da aplicação.

---

👩‍💻 Autora

<div align="center">Bruna Fasani

Desenvolvedora Backend em formação, com foco em C#, .NET e desenvolvimento de APIs.

<br><a href="https://github.com/Bru-Fasani">
  <img src="https://img.shields.io/badge/GitHub-Bru--Fasani-181717?style=for-the-badge&logo=github" />
</a></div>---

<div align="center">🏁 DragTeamAPI

Código. Engenharia. Velocidade.

</div>