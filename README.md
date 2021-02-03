# produtos-categorias

Aplicação para cadastro de produtos e categorias.

É um app demo para mostrar um exemplo funcional de frontend em vuejs/quasart e backend em APS.NET Core e mysql.

### pre-requisitos

* nodejs v14.15.3
* quasar v1.15.1
* mysql Ver 8.0.23
* dotnet Core 5.0
* visual studio 2019

### Instalação local

Baixar o projeto
```shell
$ git clone https://github.com/cnlenzc/produtos-categorias.git
````

Instalar dependencias
* instalar nodejs conforme definido em https://nodejs.org/
* instalar gerenciador de packotes yarn
```shell
$ npm install --global yarn 
````
* instalar quasar cli
```shell
$ yarn global add @quasar/cli 
````
* instalar Visual Studio 2019 Community conforme https://visualstudio.microsoft.com/
* instalar o servidor mysql conforme https://dev.mysql.com/doc/refman/8.0/en/installing.html

Criar database e user em mysql
```
database name: produto_categoria
user: carlos
password: 123
privileges: *
```

Rodar scripts sql para criação de tabelas e FK
```
/produtos-categorias/sql/table/categoria.sql
/produtos-categorias/sql/table/produto.sql
/produtos-categorias/sql/FK/produto.sql
```

Instalar pacotes do front-end
```shell
$ cd produtos-categorias/src-front
$ yarn
```

### Iniciar serviços

Iniciar back-end
```shell
$ cd produtos-categorias/src-back/api
$ dotnet run
```

Iniciar front-end
```shell
$ cd produtos-categorias/src-front
$ quasar dev
```

### Utilizar pelo browser

Interface swagger para teste da API Rest
https://localhost:41623/swagger/index.html

App final (SPA) acessando o back-end
http://localhost:8090/

## Autor

**Carlos Neves Lenz Cesar**

## Licença

MIT License
