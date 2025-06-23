# syntax=docker/dockerfile:1

# Build stage
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /source

# Copy solution and project files first for restore caching
COPY Capstone.HPTY.sln .
COPY Capstone.SRHP.API/*.csproj ./Capstone.SRHP.API/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source code
COPY Capstone.SRHP.API/. ./Capstone.SRHP.API/

# Build and publish
RUN dotnet publish Capstone.SRHP.API/Capstone.HPTY.API.csproj -c Release -o /app

################################################################################
# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

WORKDIR /app

# Install globalization support
RUN apk add --no-cache tzdata icu-data-full icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Copy published output
COPY --from=build /app .

# Run as non-root user
USER $APP_UID

# Entry point
ENTRYPOINT ["dotnet", "Capstone.HPTY.API.dll"]
