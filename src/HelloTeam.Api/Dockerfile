# BUILD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy everything
COPY . .

# restore FULL solution (important)
RUN dotnet restore HelloTeam.slnx

# publish API only
RUN dotnet publish src/HelloTeam.Api/HelloTeam.Api.csproj -c Release -o /app/publish

# RUNTIME
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=11130
EXPOSE 11130

ENTRYPOINT ["dotnet", "HelloTeam.Api.dll"]