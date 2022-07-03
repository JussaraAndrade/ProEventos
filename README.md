## Anotações:

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
