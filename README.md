# Sistema de Chamados (Console)
Stack: C# .NET | PostgreSQL | Docker | Linux

Este projeto consiste em um sistema de gerenciamento de chamados via console, desenvolvido para integração de aplicações .NET com bancos de dados relacionais. O desenvolvimento destaca a migração de ambiente do Windows para o Linux, utilizando Docker para o provisionamento do banco de dados.

## Tecnologias e Ferramentas

* Linguagem: C# (.NET SDK)
* Banco de Dados: PostgreSQL 16
* Ambiente: Linux com Docker
* Driver de Conexão: Npgsql
* Interface: Console Application

## Funcionalidades

* Criar Chamados: Registro de título e descrição.
* Listar Chamados: Consulta de todos os registros no banco.
* Fechar Chamados: Atualização do status de abertura do chamado.
* Persistência: Dados armazenados de forma persistente via PostgreSQL.

## Configuracao do Ambiente

### 1. Subir o Banco de Dados (Docker)
Execute o comando abaixo no terminal para criar o container do banco:

```bash
sudo docker run --name pg-chamados \
  -e POSTGRES_PASSWORD=1234 \
  -e POSTGRES_DB=chamadosdb \
  -p 5432:5432 \
  -d postgres:16
2. Criar a Tabela no PostgreSQL
Acesse o terminal do banco de dados:

Bash
sudo docker exec -it pg-chamados psql -U postgres -d chamadosdb
Dentro do prompt do psql, execute o comando SQL abaixo:

SQL
CREATE TABLE chamados (
  id SERIAL PRIMARY KEY,
  titulo TEXT NOT NULL,
  descricao TEXT,
  estar_aberto BOOLEAN NOT NULL DEFAULT TRUE,
  criado_em TIMESTAMP NOT NULL DEFAULT NOW()
);
(Para sair do psql, digite \q e pressione Enter)

3. Executar a Aplicacao
Na pasta raiz do projeto, execute o comando:

Bash
dotnet run
Informacoes de Conexao
Host: localhost

Porta: 5432

Database: chamadosdb

Usuario: postgres

Senha: 1234

Aprendizados Adquiridos
Implementação de operações CRUD em C# com PostgreSQL.

Gerenciamento de containers Docker para serviços de backend.

Operação e configuração de ambiente de desenvolvimento em Linux.

Estruturação de camadas básicas de acesso a dados.

Proximos Passos
Migração para Web API com ASP.NET Core.

Implementação de ORM com Entity Framework Core.

Adição de regras de validação de dados
