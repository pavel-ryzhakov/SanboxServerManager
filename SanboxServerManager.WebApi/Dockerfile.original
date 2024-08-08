#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SanboxServerManager.WebApi/SanboxServerManager.WebApi.csproj", "webapi/"]
COPY ["SanboxServerManager.Application/SanboxServerManager.Application.csproj", "SanboxServerManager.Application/"]
COPY ["SanboxServerManager.Core/SanboxServerManager.Core.csproj", "SanboxServerManager.Core/"]
COPY ["SanboxServerManager.Infrastructure/SanboxServerManager.Infrastructure.csproj", "SanboxServerManager.Infrastructure/"]
RUN dotnet restore "./SanboxServerManager.WebApi/SanboxServerManager.WebApi.csproj"
COPY . .
WORKDIR "/src/SanboxServerManager.WebApi"
RUN dotnet build "./SanboxServerManager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SanboxServerManager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SanboxServerManager.WebApi.dll"]
