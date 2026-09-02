
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY HelloTeam.sln ./
COPY src/HelloTeam.Api/HelloTeam.Api.csproj src/HelloTeam.Api/
COPY src/HelloTeam.Web/HelloTeam.Web.csproj src/HelloTeam.Web/
COPY tests/HelloTeam.Api.Tests/HelloTeam.Api.Tests.csproj tests/HelloTeam.Api.Tests/


RUN dotnet restore HelloTeam.sln


COPY . .


RUN dotnet publish src/HelloTeam.Api/HelloTeam.Api.csproj -c Release -o /out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 11130
ENTRYPOINT ["dotnet", "HelloTeam.Api.dll"]