# Mimisbrunnr Backend
## Opstarten
1. Maak een `appsettings.Development.json`-bestand aan in de root van het server project met volgende inhoud:
```env
{
  "ConnectionStrings": {
    "DatabaseConnection": "Server=localhost;Port=3306;Database=DbName;User=DbUser;Password=DbPassword;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

2. Navigeer in een terminal window naar het \src\Mimisbrunnr.Server project.
3. Start de applicatie met `dotnet run`

## Vereisten
- .NET 9 SDK