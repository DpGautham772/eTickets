# Use the official .NET image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["eTickets.csproj", "./"]
RUN dotnet restore "./eTickets.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "eTickets.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eTickets.csproj" -c Release -o /app/publish

# Final stage, build the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eTickets.dll"]
