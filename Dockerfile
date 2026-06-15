# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files for restore
COPY ["Zircon Server.sln", "./"]
COPY ["ServerCore/ServerCore.csproj", "ServerCore/"]
COPY ["ServerLibrary/ServerLibrary.csproj", "ServerLibrary/"]
COPY ["LibraryCore/LibraryCore.csproj", "LibraryCore/"]

# Restore dependencies
RUN dotnet restore "ServerCore/ServerCore.csproj"

# Copy all source code
COPY . .

# Build and publish
RUN dotnet publish "ServerCore/ServerCore.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /zircon

# Copy published output
COPY --from=build /app/publish .

# Create necessary directories
RUN mkdir -p datas Map

# Expose ports: Game=7000, UserCount=3000
EXPOSE 7000 3000

# Set entry point
ENTRYPOINT ["./ServerCore"]
