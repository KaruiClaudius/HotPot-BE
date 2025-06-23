# syntax=docker/dockerfile:1

# Use the official .NET SDK image for building the app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

# Set working directory and copy only the csproj file first (for caching)
WORKDIR /source/Capstone.SRHP.API

COPY Capstone.SRHP.API/*.csproj .

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application code
COPY Capstone.SRHP.API/. .

# Build and publish the app
RUN dotnet publish -c Release -o /app

################################################################################
# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

WORKDIR /app

# Install globalization dependencies
RUN apk add --no-cache tzdata icu-data-full icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Copy published output from the build stage
COPY --from=build /app .
# Run as non-root user
USER $APP_UID

# Start the app
ENTRYPOINT ["dotnet", "Capstone.HPTY.API.dll"]
