FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /source

COPY *.csproj .
RUN dotnet restore
COPY . .

RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Capstone.HPTY.API.dll"]
