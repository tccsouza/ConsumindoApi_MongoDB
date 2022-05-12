# Projeto ConsumindoApi_MongoDB
ConsumindoApi_MongoDB é um projeto do tipo console application que visa consumir a api The Cats e persistir os dados em uma base noSQL(MongoDB).
Foi esboçado uma arquitetura MVC, porem a parte da view não foi levada muito em consideração devido ao tipo do projeto.

## Recursos Utilizados:
- Visual Studio Community 2022
- MongoDB Community 5.0.8
- MongoDB Compass

## Subindo o ambiente:
Vamos inicializar manualmente o serviço da base de dados, para isso vamos criar uma pasta chamada `db_MongoDB` na raiz do drive C:.
Em seguida abra um prompt de comando no seu Windows e posicione-se na pasta onde o MongoDB foi instalado `(C:\Program Files\MongoDB\Server\5.0\bin)` e digite o seguinte comando para iniciar o serviço  manualmente:
```sh
mongod.exe --dbpath c:\db_MongoDB.
```
Em seguida vamos referenciar o Driver C# para o mongoDB utilizado na nossa aplicação, no menu `Tools`  clique em `Nuget Package Manager` e a seguir em `Manage Nuget Packages for Solution`;
Realize a busca por `MongoDB.Driver` e em seguida clique com o botão install, pacote responsavel por gerenciar o acesso ao banco de maneira mais eficiente.
O mesmo deverá ser feito para o pacote `Microsoft.AspNetCore.WebUtilities`, que será responsável por montar as querys de busca na api.
E por final para poder acessar a API vamos precisar referenciar o pacote `Microsoft.AspNet.WebApi.Client` em nosso projeto Console.

Por fim só executar o projeto.
