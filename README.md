# Web App - Crud Clientes
![Gif](readme-files/project.gif?raw=true "Gif") 

# Configurações #

Tecnologias utilizadas:

    - API em .Net Core 5;
    - Web App em Angular 13 com Angular Material;
    - ORM Entity Framework Core 5 com BD Sql Server criado por Migrations.

1 - Antes de começar a configuração, é necessário ter os seguintes componentes instalados na máquina:

    - Node.js;
    - .Net Core 5 SDK;
    - Angular CLI (comando cmd "npm install -g @angular/cli")

2 - Criação da base Sql Server - Abrir a solution \ClientesAPI\ClientesAPI.sln no Visual Studio, verificar a connectionString na classe Clientes.Infra.Data/Contexto/SQlServerContextoFactory (apontar para a base de dados local), setar o projeto Clientes.Infra.Data como Inicial, abrir o "Package Manager Console" e executar o seguinte comando:

        update-database

3 - Após isso, no Visual Studio setar o Projeto Clientes.App como Inicial e clicar em Startup Debug para iniciar a API.        

4 - Para o front end, abrir a pasta \web-clientes-app no VSCode e no terminal, executar os seguintes comandos para baixar os componentes da pasta node_modules e compilar o app, respectivamente:

        npm install
        ng serve

5 - Acessar o link do app:

        http://localhost:4200/

6 - Pronto, projeto rodando!
