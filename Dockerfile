# Build the backend app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o out

# Create a final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 7166
ENTRYPOINT ["dotnet", "PropertyScraper.dll"]
