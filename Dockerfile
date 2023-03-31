FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY ./*.sln ./
COPY ./src/Application/Application.csproj ./src/Application/
COPY ./src/Domain/Domain.csproj ./src/Domain/
COPY ./src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/
COPY ./src/WebUI/WebUI.csproj ./src/WebUI/
COPY ./tests/Application.IntegrationTests/Application.IntegrationTests.csproj ./tests/Application.IntegrationTests/
RUN dotnet restore

COPY ./src/ ./src/
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebUI.dll"]
