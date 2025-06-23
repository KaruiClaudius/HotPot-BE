# syntax=docker/dockerfile:1

# Build stage
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /source

# Copy solution and all project files
COPY . .

# Move to the Capstone directory
WORKDIR /source/Capstone

# Restore dependencies for the solution
RUN dotnet restore Capstone.HPTY.sln

# Build and publish API project
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
RUN adduser -u 1000 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

# Entry point
ENTRYPOINT ["dotnet", "Capstone.HPTY.API.dll"]
