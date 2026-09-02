
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY . .


RUN dotnet restore HelloTeam.sln


RUN dotnet publish src/HelloTeam.Api/HelloTeam.Api.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=11130
EXPOSE 11130

ENTRYPOINT ["dotnet", "HelloTeam.Api.dll"]