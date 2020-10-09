#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY ["SSO.API/SSO.API.csproj", "SSO.API/"]
COPY ["SSO/SSO.csproj", "SSO/"]
COPY ["SSO.Contract/SSO.Contract.csproj", "SSO.Contract/"]
COPY ["SSO.Repository/SSO.Repository.csproj", "SSO.Repository/"]
RUN dotnet restore "SSO.API/SSO.API.csproj"
COPY . .
WORKDIR "/src/SSO.API"
RUN dotnet build "SSO.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SSO.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSO.API.dll"]