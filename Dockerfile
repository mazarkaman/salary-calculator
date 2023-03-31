FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY ./*.sln ./
COPY ./OvertimePolicies/*.sln ./OvertimePolicies/
COPY ./src/Application/Application.csproj ./src/Application/
COPY ./src/Domain/Domain.csproj ./src/Domain/
COPY ./src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/
COPY ./src/WebUI/WebUI.csproj ./src/WebUI/
COPY ./OvertimePolicies/OvertimePolicies.csproj ./OvertimePolicies/
COPY ./tests/Application.IntegrationTests/Application.IntegrationTests.csproj ./tests/Application.IntegrationTests/
RUN dotnet restore

COPY ./ ./
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "WebUI.dll"]