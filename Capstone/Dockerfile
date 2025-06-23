# syntax=docker/dockerfile:1

# Build stage
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

# Copy solution file first
COPY Capstone.HPTY.sln ./

# Copy project file
COPY Capstone.SRHP.API/Capstone.HPTY.API.csproj ./Capstone.SRHP.API/

# Restore dependencies
RUN dotnet restore "Capstone.SRHP.API/Capstone.HPTY.API.csproj"

# Copy remaining source code
COPY Capstone.SRHP.API/ ./Capstone.SRHP.API/

# Publish the project
WORKDIR /src/Capstone.SRHP.API
RUN dotnet publish -c Release -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app

# Install dependencies
RUN apk add --no-cache tzdata icu-data-full icu-libs

# Configure environment
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    DOTNET_RUNNING_IN_CONTAINER=true \
    ASPNETCORE_URLS=http://+:8080 \
    TZ=Asia/Ho_Chi_Minh

# Copy published output
COPY --from=build /app/publish .

# Entrypoint - matches actual DLL name
ENTRYPOINT ["dotnet", "Capstone.HPTY.API.dll"]
