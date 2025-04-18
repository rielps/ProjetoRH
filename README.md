# ProjetoRH1

Sistema web simples para gerenciamento de pessoas e cálculo de salários, desenvolvido com **ASP.NET Web Forms** e **PostgreSQL**.

## 💡 Funcionalidades

- Cadastro de pessoas com nome, cidade, email e cargo
- Edição e exclusão de registros de pessoas
- Cálculo de salários com base no cargo
- Exibição das informações em GridView
- Interface simples com Bootstrap
- Integração com banco de dados PostgreSQL

## 🛠️ Tecnologias Utilizadas

- ASP.NET Web Forms (C#)
- ADO.NET para conexão com banco de dados
- PostgreSQL
- Bootstrap 5 para o front-end
- Npgsql (driver .NET para PostgreSQL)

## Como Rodar o Projeto

1. Clone este repositório para o seu ambiente local.
2. Abra o projeto no Visual Studio.
3. Abra o arquivo `Web.config` e configure a string de conexão do banco de dados.
4. Execute o projeto para visualizar a aplicação.

## Como Importar o Banco de Dados

Para importar o banco de dados no seu ambiente local, siga os passos abaixo:

1. Navegue até a pasta `banco` do projeto.
2. Abra o terminal ou o pgAdmin.

### Usando o terminal:
- Execute o comando abaixo no terminal para importar o arquivo `.sql` para o seu banco de dados PostgreSQL:
  ```bash
  psql -U postgres -d postgres -f banco/projeto_rh.sql
