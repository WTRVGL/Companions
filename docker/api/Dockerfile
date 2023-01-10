FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7048

ENV ASPNETCORE_URLS=http://+:7048

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY api/Companions.API/Companions.API.csproj .

COPY . .
WORKDIR "/src/api/Companions.API"
RUN dotnet build "Companions.API" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Companions.API" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Companions.API.dll"]