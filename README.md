# AuvoResolucao

## Banco de Dados
### Existem duas opções
1. Banco de Dados Sqlserver 2017 no docker
2. Banco de Dados Local

### 1 Docker
```
docker pull microsoft/mssql-server-windows-developer:2017-latest  // <- baixa a imagem so sqlserver

docker run -d -p 11433:1433 --name sqlerver2017 -e sa_password=Senha$senha -e ACCEPT_EULA=Y microsoft/mssql-server-windows-developer:2017-latest //<- inicia

docker inspect --format '{{.NetworkSettings.Networks.nat.IPAddress}}' sqlserver2017 //<-mostrara o ip do container
```

 Use o ip, porta, userid, senha e nome do banco para se conectar com sua conection string ex:
      Server=0.0.0.0,1433;Database=NomeDoBanco;User Id=NomeDoUsuario;Password=Senha;
 
___

### 2 Banco de Dados Local
1. Execute o script em uma consulta Create database.sql
2. Depois de criar o banco execute Create tables.sql

-obs: Pelo script estar configurado com os logs em diretórios padrão do linux recomendo a primeira escolha

___

## Criação do Aplicativo
Supondo que já tenha o ambiente .netframework 4.6.1 configurado execute os comandos abaixo

//RODAR APLICACAO

dotnet run

//RODAR APLICACAO NO DIRETORIO ANTERIOR

dotnet run -o Auvo.ClimaTempo.WebApp

Caso não execute, você deve configurar o target framework.
___
## Instalações de pacotes
1.	Package Manager
. Install-Package Select2.js -Version 4.0.3
. Install-Package EntityFramework -Version 6.4.4
. Install-Package jQuery -Version 3.6.0
. Install-Package bootstrap -Version 3.4.1

2.	Dotnet cli
. dotnet add package EntityFramework --version 6.4.4
. dotnet add package Select2.js --version 4.0.3
. dotnet add package jQuery --version 3.6.0
. dotnet add package bootstrap --version 3.4.1

se ainda nao ocorre a execuçao use as a pasta bin/publish



![esolhendo-cidade](https://user-images.githubusercontent.com/66702896/161818700-a282eca0-3256-4b0f-a503-d148b3662375.gif)



Att. Fabiano G. D. Bortolussi
