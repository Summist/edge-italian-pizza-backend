FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Directory.Packages.props .
COPY *.slnx .

COPY src/BuildingBlocks/EdgeItalianPizza.BuildingBlocks/*.csproj BuildingBlocks/EdgeItalianPizza.BuildingBlocks/
COPY src/Infrastructure/EdgeItalianPizza.Infrastructure/*.csproj Infrastructure/EdgeItalianPizza.Infrastructure/
COPY src/Modules/Locations/EdgeItalianPizza.Modules.Locations.ApplicationCore/*.csproj Modules/Locations/EdgeItalianPizza.Modules.Locations.ApplicationCore/
COPY src/Modules/Locations/EdgeItalianPizza.Modules.Locations.Persistence.MongoDb/*.csproj Modules/Locations/EdgeItalianPizza.Modules.Locations.Persistence.MongoDb/
COPY src/Modules/Catalog/EdgeItalianPizza.Modules.Catalog.Domain/*.csproj Modules/Catalog/EdgeItalianPizza.Modules.Catalog.Domain/
COPY src/Modules/Users/EdgeItalianPizza.Modules.Users.Domain/*.csproj Modules/Users/EdgeItalianPizza.Modules.Users.Domain/
COPY src/Modules/Inventory/EdgeItalianPizza.Modules.Inventory.Domain/*.csproj Modules/Inventory/EdgeItalianPizza.Modules.Inventory.Domain/
COPY src/Modules/Basket/EdgeItalianPizza.Modules.Basket.Domain/*.csproj Modules/Basket/EdgeItalianPizza.Modules.Basket.Domain/

RUN dotnet restore

COPY src/BuildingBlocks/EdgeItalianPizza.BuildingBlocks/ BuildingBlocks/EdgeItalianPizza.BuildingBlocks/
COPY src/Infrastructure/EdgeItalianPizza.Infrastructure/ Infrastructure/EdgeItalianPizza.Infrastructure/
COPY src/Modules/Locations/EdgeItalianPizza.Modules.Locations.ApplicationCore/ Modules/Locations/EdgeItalianPizza.Modules.Locations.ApplicationCore/
COPY src/Modules/Locations/EdgeItalianPizza.Modules.Locations.Persistence.MongoDb/ Modules/Locations/EdgeItalianPizza.Modules.Locations.Persistence.MongoDb/
COPY src/Modules/Catalog/EdgeItalianPizza.Modules.Catalog.Domain/ Modules/Catalog/EdgeItalianPizza.Modules.Catalog.Domain/
COPY src/Modules/Users/EdgeItalianPizza.Modules.Users.Domain/ Modules/Users/EdgeItalianPizza.Modules.Users.Domain/
COPY src/Modules/Inventory/EdgeItalianPizza.Modules.Inventory.Domain/ Modules/Inventory/EdgeItalianPizza.Modules.Inventory.Domain/
COPY src/Modules/Basket/EdgeItalianPizza.Modules.Basket.Domain/ Modules/Basket/EdgeItalianPizza.Modules.Basket.Domain/

RUN dotnet publish src/Modules/Locations/EdgeItalianPizza.Modules.Locations.Persistence.MongoDb -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "EdgeItalianPizza.Modules.Locations.Persistence.MongoDb.dll"]
