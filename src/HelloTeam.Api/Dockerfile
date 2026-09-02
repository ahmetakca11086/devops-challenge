FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY . .


RUN dotnet restore HelloTeam.sln


RUN dotnet publish src/HelloTeam.Api/HelloTeam.Api.csproj -c Release -o /out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 11130
ENTRYPOINT ["dotnet", "HelloTeam.Api.dll"]