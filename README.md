# To do List :pencil:
O projeto consiste em duas branches:
* frontend - Website desenvolvido em AngularJS
* backend - Backend em C# .NET Core, utilizando SQL Server como banco de dados

Projeto feito em inglês

## 💻 Pré-requisitos
É necessário possuir:
* Node
* Visual Studio
* Sql Server
* Angular CLI

## :electric_plug: Executando com Node, Visual studio e SQL Server
Passos necessários para rodar o projeto:

# Backend
1- Modificar `connection string` do SQL Server no `app.settings.json` do projeto `backend` de acordo com seu servidor <br>

2- Para Preparar estrutura de tabelas do banco de dados temos 2 opções diferentes, já que foi utilizado Entity Framework para a construção da camada de acesso a dados: 
  - Executar migration através do Entity Framework:
    - A migration já está criada na branch do projeto, é necessário apenas aplicá-la com o comando no console do `Gerenciador de Pacotes` do VS,
      caso ocorra algum erro na execução do comando use como referência a documentação em https://learn.microsoft.com/en-us/ef/core/cli/powershell
      (O projeto padrão do console deve ser o `ToDoList.Infrastructure`). O comando é:
      ```
        update-database
      ```
    - Executar script `setupDatabase.sql` localizado na pasta raiz da branch `backend`. 

3- A API pode ser inicializada normalmente com o projeto de incialização `ToDoList.API`

# Frontend
1- Instalar dependências do projeto com o comando:
```
npm install
```

2- Confirmar que a URL da API definida no arquivo `environment.ts` (caminho 'src\environments\environment.ts') está correta. <br>

3- Iniciar o projeto com o comando
  ```
  ng serve
  ```
