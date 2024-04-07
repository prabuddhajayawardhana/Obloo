#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN apt-get update
RUN apt-get install curl
RUN curl -sL https://deb.nodesource.com/setup_20.x | bash
RUN apt-get -y install nodejs
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Obloo.Api/obloo.api.client/nuget.config", "src/Obloo.Api/obloo.api.client/"]
COPY ["src/Obloo.Api/Obloo.Api.Server/Obloo.Api.Server.csproj", "src/Obloo.Api/Obloo.Api.Server/"]
COPY ["src/Obloo.Application/Obloo.Application.csproj", "src/Obloo.Application/"]
COPY ["src/Obloo.Domain/Obloo.Domain.csproj", "src/Obloo.Domain/"]
COPY ["src/Obloo.Infrastructure/Obloo.Infrastructure.csproj", "src/Obloo.Infrastructure/"]
COPY ["src/Obloo.Presentation/Obloo.Presentation.csproj", "src/Obloo.Presentation/"]
COPY ["src/Obloo.Api/obloo.api.client/obloo.api.client.esproj", "src/Obloo.Api/obloo.api.client/"]
RUN dotnet restore "./src/Obloo.Api/Obloo.Api.Server/Obloo.Api.Server.csproj"
COPY . .
WORKDIR "/src/src/Obloo.Api/Obloo.Api.Server"
RUN dotnet build "./Obloo.Api.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Generate and trust the developer certificate
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Obloo.Api.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Obloo.Api.Server.dll"]