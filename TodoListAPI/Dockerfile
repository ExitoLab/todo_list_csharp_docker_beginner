# Base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["TodoListAPI.csproj", "./"]
RUN dotnet restore "./TodoListAPI.csproj"
COPY . .
RUN dotnet build "TodoListAPI.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "TodoListAPI.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApi.dll"]
