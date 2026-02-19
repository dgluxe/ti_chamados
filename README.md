# Sistema de Chamados (Console) com PostgreSQL + Docker (C# / .NET)

Este projeto é um sistema simples de chamados desenvolvido em C# (Console App) que permite criar, listar e fechar chamados, utilizando PostgreSQL como banco de dados.

O projeto foi iniciado no Windows e, posteriormente, migrado para Linux como parte do processo de aprendizado. A integração com o banco de dados foi realizada no Linux utilizando Docker para subir o PostgreSQL em container, simulando um ambiente mais próximo da realidade de servidores.

## Funcionalidades

1. Criar chamados  
2. Listar chamados  
3. Fechar chamados  

Os dados são persistidos no PostgreSQL, ou seja, permanecem salvos mesmo após encerrar o programa.

## Tecnologias

- C# / .NET  
- PostgreSQL  
- Docker  
- Npgsql (driver PostgreSQL para .NET)  
- DBeaver (opcional, para visualização do banco)

## Pré-requisitos

- .NET SDK instalado  
- Docker instalado e em execução  

Verificar se o .NET está instalado:
```bash
dotnet --info

Verificar se o Docker está instalado:

docker --version

Testar se o Docker está funcionando:

sudo docker run hello-world
Subindo o PostgreSQL com Docker

Crie e inicie o container do PostgreSQL com o comando abaixo:

sudo docker run --name pg-chamados \
  -e POSTGRES_PASSWORD=1234 \
  -e POSTGRES_DB=chamadosdb \
  -p 5432:5432 \
  -d postgres:16

O que esse comando faz:

Cria um container chamado pg-chamados

Define a senha do usuário postgres como 1234

Cria automaticamente o banco chamadosdb

Mapeia a porta 5432 do container para a porta 5432 da sua máquina

Verificar se o container está rodando:

sudo docker ps

Parar o container:

sudo docker stop pg-chamados

Iniciar novamente:

sudo docker start pg-chamados
Criando a tabela no banco

Entre no PostgreSQL dentro do container:

sudo docker exec -it pg-chamados psql -U postgres -d chamadosdb

Crie a tabela:

CREATE TABLE chamados (
  id SERIAL PRIMARY KEY,
  titulo TEXT NOT NULL,
  descricao TEXT,
  estar_aberto BOOLEAN NOT NULL DEFAULT TRUE,
  criado_em TIMESTAMP NOT NULL DEFAULT NOW()
);

Sair do PostgreSQL:

\q
Rodando o projeto

Entre na pasta do projeto (onde está o arquivo .csproj) e execute:

dotnet run

O menu aparecerá no terminal para você usar o sistema.

String de conexão com o banco

O projeto utiliza a seguinte string de conexão no código:

Host=localhost;Port=5432;Username=postgres;Password=1234;Database=chamadosdb

Isso funciona porque o PostgreSQL foi exposto na porta 5432 da sua máquina.

Visualizando os dados (opcional)

Você pode visualizar os dados do banco de três formas:

Pelo próprio sistema no terminal

Pelo terminal do PostgreSQL (psql)

Por ferramentas gráficas como DBeaver ou pgAdmin

Configuração no DBeaver:

Host: localhost

Port: 5432

Database: chamadosdb

Username: postgres

Password: 1234

Exemplos de consultas SQL úteis

Listar todos os chamados:

SELECT * FROM chamados ORDER BY id;

Listar apenas chamados abertos:

SELECT * FROM chamados WHERE estar_aberto = true ORDER BY id;

Fechar um chamado manualmente:

UPDATE chamados SET estar_aberto = false WHERE id = 1;

Apagar um chamado:

DELETE FROM chamados WHERE id = 1;

Limpar a tabela e resetar os IDs:

TRUNCATE TABLE chamados RESTART IDENTITY;
Observações

Este projeto foi desenvolvido com foco em aprendizado.
A migração de ambiente Windows para Linux e o uso de Docker fizeram parte do processo de evolução técnica.

Próximos passos

Criar uma Web API para expor os chamados via HTTP

Adicionar validações de regras de negócio

Organizar melhor a arquitetura do projeto

Implementar autenticação básica
