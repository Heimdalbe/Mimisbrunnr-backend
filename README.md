# Mimisbrunnr Backend

ASP.NET Core API voor de Heimdal-website. De frontend staat in [Mimisbrunnr-frontend](https://github.com/Heimdalbe/Mimisbrunnr-frontend).

## Lokaal opstarten

Benodigd: **.NET 9 SDK** (inclusief ASP.NET Core runtime), **MariaDB/MySQL** en optioneel **Docker Compose** voor de lokale database. Node.js is alleen nodig voor de frontend.

Voer deze stappen uit vanaf de root van deze repository:

1. Start een aparte lokale database. Met Docker (de Docker-service moet draaien):

   ```sh
   docker compose -f compose.local.yml up -d --wait
   ```

   De database luistert alleen lokaal op poort `33306` en bewaart gegevens in een Docker-volume. De wachtwoorden in dit bestand zijn uitsluitend voor lokale ontwikkeling.

2. Stel de verbinding en frontend-URL in via .NET user secrets:

   ```sh
   dotnet user-secrets set "ConnectionStrings:DatabaseConnection" "Server=127.0.0.1;Port=33306;Database=mimisbrunnr_local;User=mimis_local;Password=LocalOnly-Mimis-2026;" --project src/Mimisbrunnr.Server
   dotnet user-secrets set "Frontend:Origin" "http://localhost:5173" --project src/Mimisbrunnr.Server
   ```

   Heb je al een lokale database, gebruik dan de bijbehorende host, poort, databasenaam en inloggegevens. Kies een **nieuwe, lege ontwikkelingsdatabase**. De server voert migraties uit bij het starten. Een oude database die met `EnsureCreated` is gemaakt, kan tabellen zonder migratiegeschiedenis bevatten; gebruik daarvoor een nieuwe database of laat de bestaande migratiegeschiedenis zorgvuldig herstellen.

   User secrets en omgevingsvariabelen overschrijven de bestaande `appsettings.Development.json` in het serverproject. Het gelijknamige bestand in de repository-root wordt niet door dit project geladen. Bewaar echte wachtwoorden buiten Git.

3. Configureer het lokale HTTPS-certificaat:

   ```sh
   dotnet dev-certs https --trust
   ```

   Als je browser het certificaat niet vertrouwt, open eerst `https://localhost:5001/swagger` en vertrouw het lokale ontwikkelingscertificaat voordat je inlogt op de frontend.

4. Start de API:

   ```sh
   dotnet run --project src/Mimisbrunnr.Server --launch-profile https
   ```

   API: `https://localhost:5001/api`. Swagger: `https://localhost:5001/swagger`.

5. Start de frontend volgens haar README en open **http://localhost:5173**. Gebruik `localhost` aan beide kanten; `127.0.0.1` als browser-URL heeft een andere origin en past niet bij deze CORS-configuratie.

## Lokale testaccounts

In `Development` worden demoaccounts en voorbeeldgegevens aangemaakt als er nog geen Identity-gebruikers zijn. De database wordt bij het starten **niet verwijderd**; aanpassingen blijven na een herstart bestaan. Gebruik deze opstartmodus uitsluitend met een aparte lokale database.

| Account | Wachtwoord | Doel |
| --- | --- | --- |
| `praeses@heimdal.be` | `A1b2C3!` | Beheerder (`Hmdl`, `Commilitones`) |
| `quaestor@heimdal.be` | `A1b2C3!` | Gewoon lid (`Commilitones`) |
| `media@heimdal.be` | `A1b2C3!` | Media-/eventbeheer |

Dit zijn bestaande **ontwikkelingsaccounts**, geen inloggegevens voor de live website. Voor testen op een gedeelde testomgeving is een bestaand account met de rol `Hmdl` nodig, plus een apart account waarvan de rollen gewijzigd mogen worden. Imgur-configuratie is niet nodig om accountrollen te testen; afbeeldinguploads hebben die wel nodig.

## Accountrollen beheren

Een `Hmdl`-beheerder gaat naar **Admin → Accounts → Rollen beheren**. Daar kan die bestaande rollen toevoegen of verwijderen, ook meerdere tegelijk. Accountrollen zijn Identity-toegangsrechten; praesidiumfuncties onder `/api/praesidium` zijn een ander onderdeel.

| Methode | URL | Resultaat |
| --- | --- | --- |
| GET | `/api/identity/roles` | Beschikbare rollen als `{ key: roleId, value: roleName }` |
| GET | `/api/accounts/{id}/roles` | `{ id, roles, isCurrentUser }` |
| PUT | `/api/accounts/{id}/roles` | Vervangt de rollen; body: `{ "roles": ["Commilitones", "EventEditor"] }` |

Alle drie vereisen `Hmdl`. Nieuwe endpoints gebruiken dezelfde Ardalis Result-wrapper als de rest van de API; de gegevens staan in `value`. Een lege lijst verwijdert alle rollen van een ander account. `null`, ontbrekende lijsten, lege namen en onbekende rollen worden afgewezen. Namen worden naar bestaande rolnamen genormaliseerd; duplicaten worden verwijderd. De beheerder kan de eigen `Hmdl`-rol niet verwijderen. Een Identity-concurrencyfout geeft `409`; toevoegingen en verwijderingen staan in één transactie.

Identity controleert en vernieuwt cookieclaims bij elk geauthenticeerd verzoek. Toegekende of verwijderde rechten gelden vanaf het volgende verzoek, ook voor bestaande sessies. Dit kost extra Identity-databasequeries per geauthenticeerd verzoek. De frontend van een andere gebruiker ziet gewijzigde navigatierechten na vernieuwen van de pagina; de server handhaaft de nieuwe rechten al direct.

## Controle en tests

```sh
dotnet build Mimisbrunnr-backend.sln
dotnet test Mimisbrunnr-backend.sln
```

De roltests gebruiken een tijdelijke SQLite-database en hebben geen MariaDB, adminlogin of externe dienst nodig. Ze controleren toevoegingen/verwijderingen, lege lijsten, normalisatie, onbekende rollen, toegang, ontbrekende accounts, eigen beheerdersrechten en rollback bij Identity-concurrencyfouten.

Handmatige integratiecontrole: log in als beheerder, geef `quaestor@heimdal.be` een editorrol, sla op en vernieuw de rollenpagina. Controleer in een aparte browser/sessie dat het lid die rechten krijgt. Verwijder de rol opnieuw en controleer dat toegang direct wordt geweigerd. Controleer ook dat een gewoon lid geen accountrollen kan beheren en dat eigen `Hmdl` niet verwijderd kan worden.

## Projectstructuur

- `src/Mimisbrunnr.Server`: endpoints, authenticatie, configuratie en API-host.
- `src/Mimisbrunnr.Services`: applicatielogica, waaronder `Accounts/AccountRoleService.cs`.
- `src/Mimisbrunnr.Shared`: verzoeken, antwoorden, validatie en servicecontracten.
- `src/Mimisbrunnr.Persistence`: Entity Framework, Identity-tabellen, migraties en ontwikkelingsdata.
- `src/Mimisbrunnr.Domain`: domeinmodellen.
- `tests/Mimisbrunnr.Tests`: regressietests voor accountrollen.

Werk vanaf `main` op een aparte branch. Het bestaande deployproces gebruikt `prod`; een featurebranch publiceren deployt de website niet.
