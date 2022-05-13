#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Infra/Infra.API/Infra.API.csproj", "Services/Infra/Infra.API/"]
RUN dotnet restore "Services/Infra/Infra.API/Infra.API.csproj"
COPY . .
WORKDIR "/src/Services/Infra/Infra.API"
RUN dotnet build "Infra.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Infra.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Infra.API.dll"]




