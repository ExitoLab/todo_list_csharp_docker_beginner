# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["TodoListAPI/TodoListAPI.csproj", "./"]
RUN dotnet restore "./TodoListAPI.csproj"
COPY TodoListAPI/. .
RUN dotnet build "TodoListAPI.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "TodoListAPI.csproj" -c Release -o /app/publish

# Final image for running
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5267
ENTRYPOINT ["dotnet", "TodoListAPI.dll"]
