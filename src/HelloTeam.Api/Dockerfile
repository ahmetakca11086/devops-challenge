FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything from repo root
COPY . .

# 🔍 DEBUG (this is key)
RUN ls -la
RUN ls -la src
RUN ls -la tests

# Restore using absolute path
RUN dotnet restore ./HelloTeam.sln

# Publish API
RUN dotnet publish ./src/HelloTeam.Api/HelloTeam.Api.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 11130
ENTRYPOINT ["dotnet", "HelloTeam.Api.dll"]