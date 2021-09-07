start:
	docker-compose up --build -d

unit-test:
	dotnet test test/Finances.Tests/Finances.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=Coverage/ 
	reportgenerator "-reports:C:\Git\finance-api\test\Finances.Tests\Coverage\coverage.opencover.xml" "-targetdir:C:\Git\finance-api\test\Finances.Tests\Coverage"
