FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY DisputeService/DisputeService.csproj DisputeService/
RUN dotnet restore DisputeService/DisputeService.csproj

COPY DisputeService/ DisputeService/
WORKDIR /src/DisputeService
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "DisputeService.dll"]