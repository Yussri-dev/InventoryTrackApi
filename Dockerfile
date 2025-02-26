# Use the .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy and restore only the API project
COPY InventoryTrackApi.csproj ./
RUN dotnet restore InventoryTrackApi.csproj

# Copy everything else and publish
COPY . ./
RUN dotnet publish InventoryTrackApi.csproj -c Release -o out

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "InventoryTrackApi.dll"]
