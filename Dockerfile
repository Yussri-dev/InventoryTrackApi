# 1️⃣ Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# 2️⃣ Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only the solution and the InventoryTrackApi project file
COPY ["InventoryTrackApi.sln", "./"]
COPY ["/InventoryTrackApi.csproj", "InventoryTrackApi/"]

# Restore dependencies for the InventoryTrackApi project
WORKDIR "/src/InventoryTrackApi"
RUN dotnet restore

# Copy the entire source code (only InventoryTrackApi related files)
COPY . .

# Build and publish the InventoryTrackApi project
RUN dotnet publish InventoryTrackApi.csproj -c Release -o /app/out  

# 3️⃣ Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the build output from the 'build' image to the final image
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "InventoryTrackApi.dll"]
