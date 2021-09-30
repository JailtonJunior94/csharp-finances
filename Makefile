build:
	dotnet clean
	dotnet restore
	dotnet build

unit-test:
	dotnet test test/Finances.Tests/Finances.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=Coverage/ 
	reportgenerator "-reports:C:\Git\csharp-finances\test\Finances.Tests\Coverage\coverage.opencover.xml" "-targetdir:C:\Git\csharp-finances\test\Finances.Tests\Coverage"

start:
	docker-compose up --build -d

stop:
	docker-compose down