# ==============================================================================
# Stage 1: Build Stage
# ==============================================================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the exact project file and restore its dependencies
COPY ["SaisonManager.net.csproj", "./"]
RUN dotnet restore "SaisonManager.net.csproj"

# Copy the rest of the source files and build
COPY . .
RUN dotnet build "SaisonManager.net.csproj" -c Release -o /app/build

# ==============================================================================
# Stage 2: Publish Stage
# ==============================================================================
FROM build AS publish
RUN dotnet publish "SaisonManager.net.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ==============================================================================
# Stage 3: Runtime Stage
# ==============================================================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copy the lightweight runtime-ready binaries
COPY --from=publish /app/publish .

# Render pushes its custom port via the PORT environment variable.
# ASPNETCORE_HTTP_PORTS handles binding smoothly without extra code.
ENV ASPNETCORE_HTTP_PORTS=8080

# Expose port 8080 (Matches the default fallback port)
EXPOSE 8080

# Execute the application targeting your exact compiled assembly DLL
ENTRYPOINT ["dotnet", "SaisonManager.net.dll"]