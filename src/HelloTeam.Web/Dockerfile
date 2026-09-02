FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore ./src/HelloTeam.Web/HelloTeam.Web.csproj
RUN dotnet publish ./src/HelloTeam.Web/HelloTeam.Web.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:52369

EXPOSE 52369

ENTRYPOINT ["dotnet", "HelloTeam.Web.dll"]