FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["src/Finances.API/Finances.API.csproj", "src/Finances.API/"]
RUN dotnet restore "src/Finances.API/Finances.API.csproj"
COPY . .
WORKDIR "/src/src/Finances.API"
RUN dotnet build "Finances.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Finances.API.csproj" -c Release -o /app/publish

FROM base AS final

RUN apk --no-cache add tzdata
ENV TZ=America/Sao_Paulo

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finances.API.dll"]