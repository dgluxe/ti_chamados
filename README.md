# Sistema de Chamados (Console) com PostgreSQL + Docker (C# / .NET)
Este projeto é um sistema simples de chamados feito em C# (Console App) que permite criar, listar e fechar chamados, utilizando PostgreSQL como banco de dados.

O desenvolvimento foi iniciado no Windows e, posteriormente, o ambiente foi migrado para Linux como parte do processo de aprendizado. A integração com o banco de dados foi realizada no Linux utilizando Docker para subir o PostgreSQL em container. Esse processo fez parte do objetivo de aprender a trabalhar em ambientes diferentes e mais próximos da realidade de servidores e ambientes de produção.

## Funcionalidades

1 Criar chamados  
2 Listar chamados  
3 Fechar chamados  

Os dados são persistidos no PostgreSQL, então permanecem salvos mesmo após encerrar o programa.

## Tecnologias utilizadas

C# / .NET  
PostgreSQL  
Docker  
Npgsql (driver PostgreSQL para .NET)  
DBeaver (cliente gráfico para visualizar o banco)

## Objetivo do projeto

Este projeto foi desenvolvido com foco em aprendizado prático de:

Integração de aplicações .NET com banco de dados relacional  
Uso de Docker para provisionar serviços (PostgreSQL)  
Execução de aplicações em ambiente Linux  
Organização básica de camadas (aplicação → acesso a dados → banco)  
Versionamento de código com Git e GitHub

## Pré-requisitos

.NET SDK instalado  
Docker instalado e em execução  

Verificar .NET:
```bash
dotnet --info
