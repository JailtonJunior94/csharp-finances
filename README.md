Cliente Incidentes: Componente responsável de obter os eventos de tag, lista pap, passagens recusadas e atualização mensageria

## Tecnologias:
- C#
- .Net Core 3.1
- Azure Functions
- SQL Server
- Sonarqube
  
## Testes de Unidade
- Na pasta raiz, executar: 
``` 
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:Exclude="[xunit*]*"
```
- Instalar global o package Report Generator
``` 
dotnet tool install -g dotnet-reportgenerator-globaltool
```
- Para gerar o HTML de cobertura:  
```
reportgenerator "-reports:test/*/*.opencover.xml" "-targetdir:test/Cliente.Incidentes.Tests/Coverage"
```
## Sonarqube
- Instalar global o package dotnet-sonarscanner
```
dotnet tool install --global dotnet-sonarscanner --version 4.8.0
```
- Na pasta raiz, executar depois de ter executado os testes unitários (TDD): 
- Primeiro comando a executar: 
```
dotnet build-server shutdown
```
- Segundo comando a executar: 
```
dotnet-sonarscanner begin /k:"Cliente.Incidentes" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="73b449d8bafee501ece8ede18a17a96ea045f858" /d:sonar.cs.opencover.reportsPaths=test/Cliente.Incidentes.Tests/Coverage/coverage.opencover.xml /d:sonar.coverage.exclusions="**Test*.cs, src/Cliente.Incidentes.API/**.cs"
```
- Terceiro comando a executar: 
```
dotnet build Cliente.Incidentes.sln
```
- Último comando a executar: 
```
dotnet-sonarscanner end /d:sonar.login="73b449d8bafee501ece8ede18a17a96ea045f858"
```
