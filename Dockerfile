#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG DEPLOY_SECRET_OAUTH
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["metrack.Api/metrack.Api.csproj", "metrack.Api/"]
RUN dotnet restore "./metrack.Api/metrack.Api.csproj"
COPY . .
WORKDIR "/src/metrack.Api"
RUN dotnet build "./metrack.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./metrack.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt update
RUN apt install curl -y
RUN curl https://storage.yandexcloud.net/yandexcloud-yc/install.sh | bash -s -- -a
RUN /root/yandex-cloud/bin/yc config set token $DEPLOY_SECRET_OAUTH

ENTRYPOINT ["dotnet", "metrack.Api.dll"]