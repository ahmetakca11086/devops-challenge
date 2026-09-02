# ============================================
# Build stage
# ============================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY HelloTeam.Api.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish \
    -c Release \
    -o /app/publish \
    --no-restore \
    --no-self-contained


# ============================================
# Runtime stage
# ============================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=11130

EXPOSE 11130

COPY --from=build /app/publish .

# Run the application as a non-root user.
USER $APP_UID

ENTRYPOINT ["dotnet", "HelloTeam.Api.dll"]
