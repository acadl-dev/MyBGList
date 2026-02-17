# 🎯 MyBGList API – Estudos com ASP.NET Core

Projeto desenvolvido como parte dos meus estudos do livro  
**_Building Web APIs with ASP.NET Core_**, de Valerio De Sanctis.

O objetivo deste repositório é consolidar conhecimentos práticos em construção de APIs RESTful utilizando ASP.NET Core, aplicando boas práticas de arquitetura, segurança e versionamento.

---

## 📚 Sobre o Projeto

O **MyBGList** é uma Web API para gerenciamento de board games, permitindo:

- 📌 Cadastro de jogos
- 🎲 Gerenciamento de gêneros
- 🏢 Gerenciamento de publishers
- 🔎 Filtros, paginação e ordenação server-side
- 🔐 Autenticação e autorização com JWT
- 📄 Documentação automática com Swagger (OpenAPI)

O projeto foi construído seguindo uma abordagem incremental, aplicando conceitos modernos de desenvolvimento backend.

---

## 🧠 Conceitos e Tecnologias Aplicadas

Durante o desenvolvimento, foram aplicados:

### 🔹 Arquitetura & Boas Práticas

- Arquitetura em camadas
- Padrão Repository
- DTOs e ViewModels
- Separação de responsabilidades (SRP)
- Dependency Injection
- Logging estruturado
- Versionamento de API
- Tratamento global de exceções

### 🔹 Banco de Dados

- Entity Framework Core (Code-First)
- Migrations
- Relacionamentos (1:N, N:N)
- Consultas otimizadas com LINQ
- Paginação, ordenação e filtros dinâmicos

### 🔹 Segurança

- Autenticação com JWT
- Role-based authorization
- Proteção de endpoints
- Configuração de Identity

### 🔹 Documentação

- Swagger / OpenAPI
- Validação de dados

---

## 🛠️ Stack Utilizada

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT
- Swagger (OpenAPI)

---

## 🚀 Como Executar o Projeto

```bash
# Clonar o repositório
git clone https://github.com/seu-usuario/mybglist-api.git

# Entrar na pasta do projeto
cd mybglist-api

# Restaurar dependências
dotnet restore

# Aplicar migrations
dotnet ef database update

# Executar a aplicação
dotnet run
