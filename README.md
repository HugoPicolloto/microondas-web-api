# MicroondasWeb 

Sistema de simulação de micro-ondas desenvolvido em ASP.NET Core MVC com autenticação JWT, programas de aquecimento customizados e integração via Web API.

---

## Tecnologias utilizadas

- C#
- ASP.NET Core MVC
- ASP.NET Core Web API
- JWT Bearer Authentication
- HTML5
- CSS3
- JavaScript 
- LocalStorage
- Repository Pattern
- Exception Middleware

---

## Funcionalidades

- Aquecimento manual
- Controle de potência
- Pausar e cancelar aquecimento
- Programas pré-definidos
- Cadastro de programas personalizados
- Exclusão de programas personalizados
- Autenticação JWT Bearer Token 
- Controle de sessão autenticada com criptografia padrão SHA1 (256 bits)
- Tratamento global de exceptions
- Respostas padronizadas da API
- Status visual de autenticação da API
- Expiração automática do token ( 2horas )
- Seed para inicialização de dados dos programas definidos (gravados em JSON).

---

## Estrutura do Projeto

Domain
Application
Infrastructure
Web/Api - Controllers
Data
Views ( Razor )

-- Projeto que busca trazer conceitos de arquitetura limpa, e classes com suas responsabilidades unicas.

# Nugget
Pacote Nugget Instalado - Microsoft.AspNetCore.Authentication.JwtBearer
Versão: 8.0.26


## Como executar

1. Clone o projeto

bash
git clone URL
Abra no Visual Studio
Execute:
dotnet run
Acesse:
https://localhost:7059

## Usário para authenticação

Padrão

-Usuário: admin
-Senha: 123

This is a challenge by Coodesh
