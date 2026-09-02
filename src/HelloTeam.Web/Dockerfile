# ============================================
# Build stage
# ============================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY HelloTeam.Web.csproj .
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
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime

WORKDIR /app

# Non-root user
RUN adduser --disabled-password --uid 1001 appuser

EXPOSE 52369

COPY --from=build /app/publish .

USER appuser

ENTRYPOINT ["dotnet", "HelloTeam.Web.dll"]