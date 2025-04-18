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


  ## 🤖 Como utilizei a Inteligência Artificial no projeto

Durante o desenvolvimento deste projeto, utilizei a inteligência artificial como uma **ferramenta de apoio e aprendizado**. Em diversos momentos, ela me ajudou a entender melhor os erros, organizar o código, aplicar boas práticas e até melhorar o visual da aplicação com sugestões de CSS e layout mais moderno.

Importante destacar que a IA **não fez o projeto por mim**. Todo o sistema foi desenvolvido por mim, com base no que aprendi, mas com o apoio da IA para esclarecer dúvidas, dar ideias e acelerar o processo de desenvolvimento.

### Exemplos de como a IA me ajudou:

- Explicações sobre mensagens de erro e como resolvê-las;
- Sugestões de melhorias no visual com CSS moderno (tema escuro, responsividade, etc.);
- Apoio na estruturação do código backend em C# e ASP.NET Web Forms;
- Dicas para conectar e interagir corretamente com o banco de dados PostgreSQL;
- Orientações para a preparação da entrega, como README, script SQL e vídeo explicativo.

Ao utilizar a IA dessa forma, consegui aprender mais, resolver problemas com mais autonomia e manter o foco na lógica e na construção do projeto como um todo.

Essa experiência me mostrou como a inteligência artificial pode ser uma grande aliada no processo de desenvolvimento — não substituindo o programador, mas ajudando a evoluir com mais segurança e clareza.

