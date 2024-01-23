#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Teamsec_Case.API/Teamsec_Case.API.csproj", "Teamsec_Case.API/"]
COPY ["Teamsec_Case.Persistence/Teamsec_Case.Persistence.csproj", "Teamsec_Case.Persistence/"]
COPY ["Teamsec_Case.Domain/Teamsec_Case.Domain.csproj", "Teamsec_Case.Domain/"]
COPY ["Teamsec_Case.Core/Teamsec_Case.Core.csproj", "Teamsec_Case.Core/"]
COPY ["Teamsec_Case.Application/Teamsec_Case.Application.csproj", "Teamsec_Case.Application/"]
COPY ["Teamsec_Case.Infrastructure/Teamsec_Case.Infrastructure.csproj", "Teamsec_Case.Infrastructure/"]
RUN dotnet restore "Teamsec_Case.API/Teamsec_Case.API.csproj"
COPY . .
WORKDIR "/src/Teamsec_Case.API"
RUN dotnet build "Teamsec_Case.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teamsec_Case.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teamsec_Case.API.dll"]