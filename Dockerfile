FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ENV DBIP http://localhost:8080
ENV ISRUNIP false
ENV POT 80

EXPOSE ${POT}

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SiteClients.csproj", "."]
RUN dotnet restore "./SiteClients.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SiteClients.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SiteClients.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SiteClients.dll"]