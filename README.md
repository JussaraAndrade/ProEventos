## Criar projeto ASP .NET Core 5:

1. Instalar versão do dotnet via comando:
  ```sh
dotnet new globaljson --sdk-version 3.1.102 (Exemplo versão 3)
 ```

2. Criar o template (ASP.NET Core Webapi):
```sh
dotnet new webapi -n ProEventos.API
* -n; significa o nome do projeto
```

3. Execução do projeto:
```sh
* 1° Entrar no arquivo - cd ProEventos.API
* 2° Digitar o comando - dotnet watch run (Abre a página automaticamente do Swagger)
```

4. Comando de criar o arquivo .gitignore:
```sh
dotnet new gitignore
```
## Instalação ferramenta EF - Entity Framework 5

1. Instalar Entity Framework:
```sh
dotnet tool install --global dotnet-ef
```
* ProEventos; instalar na pasta principal do projeto

2. Verificar versão do EF
```sh
dotnet tool list --global
```

## Adicionar referência do projeto
* Entity Framework Core 
* Entity Framework Core Design
* Entity Framework Core Tools
* Entity Framework Core Sqlite

Obs: baixar a versão 5 conforme o projeto foi criado, se for maior que 5 a versão irá retornar mensagem de erro alegado que a versão é incompatível.

## Migrations & Database

1. Listar Migrations:
```sh
dotnet ef migrations list
```
Obs: rodar o comando dentro do arquivo ProEventos.API

2. Adicionar arquivo Migrations:
```sh
dotnet ef migrations add Initial -o Data/Migrations
```

3. Remover arquivo Migrations:
```sh
dotnet ef migrations remove
```
4. Alterar Database:
```sh
dotnet ef database update
```

## Angular 

1. Criar projeto:
```sh
ng new ProEventos-App
```
2. Gerar componentes:
```sh
ng generate component eventos
ou
ng g c eventos
```
3. Rodar o projeto
```sh
ng serve -o
```
Obs: Tem que está dentro da pasta principal do projeto. Ex: Front/ProEventos-App

## Frameworks

1. Font Awesome:
```sh
npm install --save @fortawesome/fontawesome-free
```
2. Bootstrap versão 5:
```sh
npm install bootstrap@5 --save
```
3. Ngx-Bootstrap:
```sh
ng add ngx-bootstrap@6.2.0
```
