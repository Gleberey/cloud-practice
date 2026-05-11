FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ListingService/ListingService.csproj ListingService/
RUN dotnet restore ListingService/ListingService.csproj

COPY ListingService/ ListingService/
WORKDIR /src/ListingService
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ListingService.dll"]