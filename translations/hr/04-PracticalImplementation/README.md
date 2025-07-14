<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T23:00:40+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hr"
}
-->
# Praktična implementacija

Praktična implementacija je mjesto gdje snaga Model Context Protocola (MCP) postaje opipljiva. Iako je važno razumjeti teoriju i arhitekturu MCP-a, prava vrijednost dolazi kada ove koncepte primijenite za izgradnju, testiranje i implementaciju rješenja koja rješavaju stvarne probleme. Ova poglavlja premošćuju jaz između konceptualnog znanja i praktičnog razvoja, vodeći vas kroz proces oživljavanja aplikacija temeljenih na MCP-u.

Bilo da razvijate inteligentne asistente, integrirate AI u poslovne tokove rada ili gradite prilagođene alate za obradu podataka, MCP pruža fleksibilnu osnovu. Njegov dizajn neovisan o jeziku i službeni SDK-ovi za popularne programske jezike čine ga dostupnim širokom spektru programera. Korištenjem ovih SDK-ova možete brzo napraviti prototip, iterirati i skalirati svoja rješenja na različitim platformama i okruženjima.

U sljedećim odjeljcima pronaći ćete praktične primjere, uzorke koda i strategije implementacije koje pokazuju kako primijeniti MCP u C#, Javi, TypeScriptu, JavaScriptu i Pythonu. Također ćete naučiti kako otklanjati pogreške i testirati MCP servere, upravljati API-jima i implementirati rješenja u oblaku koristeći Azure. Ovi praktični resursi osmišljeni su da ubrzaju vaše učenje i pomognu vam samouvjereno graditi robusne, spremne za produkciju MCP aplikacije.

## Pregled

Ova lekcija fokusira se na praktične aspekte implementacije MCP-a u više programskih jezika. Istražit ćemo kako koristiti MCP SDK-ove u C#, Javi, TypeScriptu, JavaScriptu i Pythonu za izgradnju robusnih aplikacija, otklanjanje pogrešaka i testiranje MCP servera te kreiranje ponovljivih resursa, promptova i alata.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:
- Implementirati MCP rješenja koristeći službene SDK-ove u različitim programskim jezicima
- Sustavno otklanjati pogreške i testirati MCP servere
- Kreirati i koristiti značajke servera (Resurse, Prompte i Alate)
- Dizajnirati učinkovite MCP tokove rada za složene zadatke
- Optimizirati MCP implementacije za performanse i pouzdanost

## Službeni SDK resursi

Model Context Protocol nudi službene SDK-ove za više jezika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Rad s MCP SDK-ovima

Ovaj odjeljak pruža praktične primjere implementacije MCP-a u više programskih jezika. Uzorke koda možete pronaći u direktoriju `samples` organiziranom po jezicima.

### Dostupni uzorci

Repozitorij uključuje [primjere implementacija](../../../04-PracticalImplementation/samples) na sljedećim jezicima:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Svaki primjer demonstrira ključne MCP koncepte i obrasce implementacije za taj specifični jezik i ekosustav.

## Osnovne značajke servera

MCP serveri mogu implementirati bilo koju kombinaciju ovih značajki:

### Resursi
Resursi pružaju kontekst i podatke koje korisnik ili AI model mogu koristiti:
- Spremišta dokumenata
- Baze znanja
- Strukturirani izvori podataka
- Datotečni sustavi

### Prompti
Prompti su predlošci poruka i tokova rada za korisnike:
- Unaprijed definirani predlošci razgovora
- Vođeni obrasci interakcije
- Specijalizirane strukture dijaloga

### Alati
Alati su funkcije koje AI model može izvršavati:
- Alati za obradu podataka
- Integracije s vanjskim API-jima
- Računalne mogućnosti
- Funkcionalnost pretraživanja

## Primjeri implementacije: C#

Službeni C# SDK repozitorij sadrži nekoliko primjera implementacija koje pokazuju različite aspekte MCP-a:

- **Osnovni MCP klijent**: Jednostavan primjer kako kreirati MCP klijenta i pozivati alate
- **Osnovni MCP server**: Minimalna implementacija servera s osnovnom registracijom alata
- **Napredni MCP server**: Server s punim značajkama, uključujući registraciju alata, autentifikaciju i rukovanje pogreškama
- **Integracija s ASP.NET**: Primjeri integracije s ASP.NET Core
- **Obrasci implementacije alata**: Razni obrasci za implementaciju alata različitih razina složenosti

MCP C# SDK je u preview fazi i API-ji se mogu mijenjati. Ovaj blog ćemo kontinuirano ažurirati kako SDK bude napredovao.

### Ključne značajke
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Izgradnja vašeg [prvog MCP servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za potpune primjere implementacije u C#, posjetite [službeni repozitorij C# SDK primjera](https://github.com/modelcontextprotocol/csharp-sdk)

## Primjer implementacije: Java implementacija

Java SDK nudi robusne opcije implementacije MCP-a s enterprise značajkama.

### Ključne značajke

- Integracija sa Spring Frameworkom
- Snažna tipizacija
- Podrška za reaktivno programiranje
- Sveobuhvatno rukovanje pogreškama

Za potpuni primjer implementacije u Javi, pogledajte [Java primjer](samples/java/containerapp/README.md) u direktoriju uzoraka.

## Primjer implementacije: JavaScript implementacija

JavaScript SDK pruža lagan i fleksibilan pristup implementaciji MCP-a.

### Ključne značajke

- Podrška za Node.js i preglednike
- API baziran na Promise-ima
- Jednostavna integracija s Expressom i drugim frameworkima
- Podrška za WebSocket za streaming

Za potpuni primjer implementacije u JavaScriptu, pogledajte [JavaScript primjer](samples/javascript/README.md) u direktoriju uzoraka.

## Primjer implementacije: Python implementacija

Python SDK nudi pitoničan pristup implementaciji MCP-a s izvrsnim integracijama za ML frameworke.

### Ključne značajke

- Podrška za async/await s asyncio
- Integracija s Flaskom i FastAPI-jem
- Jednostavna registracija alata
- Izvorna integracija s popularnim ML bibliotekama

Za potpuni primjer implementacije u Pythonu, pogledajte [Python primjer](samples/python/README.md) u direktoriju uzoraka.

## Upravljanje API-jem

Azure API Management je izvrsno rješenje za osiguranje MCP servera. Ideja je postaviti Azure API Management instancu ispred vašeg MCP servera i dopustiti joj da upravlja značajkama koje ćete vjerojatno htjeti, kao što su:

- ograničavanje brzine (rate limiting)
- upravljanje tokenima
- nadzor
- balansiranje opterećenja
- sigurnost

### Azure primjer

Evo Azure primjera koji radi upravo to, tj. [kreira MCP server i osigurava ga Azure API Managementom](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pogledajte kako autorizacijski tijek izgleda na slici ispod:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na prethodnoj slici događa se sljedeće:

- Autentikacija/Autorizacija se odvija pomoću Microsoft Entra.
- Azure API Management djeluje kao gateway i koristi politike za usmjeravanje i upravljanje prometom.
- Azure Monitor bilježi sve zahtjeve za daljnju analizu.

#### Tijek autorizacije

Pogledajmo tijek autorizacije detaljnije:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP specifikacija autorizacije

Saznajte više o [MCP specifikaciji autorizacije](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementacija udaljenog MCP servera na Azure

Pogledajmo možemo li implementirati ranije spomenuti primjer:

1. Klonirajte repozitorij

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrirajte `Microsoft.App` resource providera.
    * Ako koristite Azure CLI, pokrenite `az provider register --namespace Microsoft.App --wait`.
    * Ako koristite Azure PowerShell, pokrenite `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Nakon nekog vremena provjerite status registracije naredbom `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`.

2. Pokrenite ovu [azd](https://aka.ms/azd) naredbu za provisioniranje API Management servisa, funkcijske aplikacije (s kodom) i svih ostalih potrebnih Azure resursa

    ```shell
    azd up
    ```

    Ova naredba bi trebala implementirati sve cloud resurse na Azureu

### Testiranje vašeg servera s MCP Inspectorom

1. U **novom terminal prozoru**, instalirajte i pokrenite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Trebali biste vidjeti sučelje slično ovom:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hr.png) 

1. CTRL klikom otvorite MCP Inspector web aplikaciju s URL-a koji aplikacija prikazuje (npr. http://127.0.0.1:6274/#resources)
1. Postavite tip transporta na `SSE`
1. Postavite URL na vaš aktivni API Management SSE endpoint prikazan nakon `azd up` i **Povežite se**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Popis alata**. Kliknite na alat i **Pokrenite alat**.  

Ako su svi koraci prošli uspješno, sada ste povezani s MCP serverom i uspjeli ste pozvati alat.

## MCP serveri za Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ovaj skup repozitorija je predložak za brzo pokretanje za izgradnju i implementaciju prilagođenih udaljenih MCP (Model Context Protocol) servera koristeći Azure Functions s Python, C# .NET ili Node/TypeScript.

Primjeri pružaju kompletno rješenje koje omogućuje programerima da:

- Izgrade i pokrenu lokalno: razvijaju i otklanjaju pogreške MCP servera na lokalnom računalu
- Implementiraju na Azure: jednostavno implementiraju u oblak s jednom azd up naredbom
- Povežu se s klijentima: povezuju se s MCP serverom iz različitih klijenata uključujući VS Code-ov Copilot agent mod i MCP Inspector alat

### Ključne značajke:

- Sigurnost po dizajnu: MCP server je osiguran pomoću ključeva i HTTPS-a
- Opcije autentifikacije: podržava OAuth koristeći ugrađenu autentifikaciju i/ili API Management
- Izolacija mreže: omogućuje mrežnu izolaciju koristeći Azure Virtual Networks (VNET)
- Serverless arhitektura: koristi Azure Functions za skalabilno, događajno vođeno izvršavanje
- Lokalni razvoj: sveobuhvatna podrška za lokalni razvoj i otklanjanje pogrešaka
- Jednostavna implementacija: pojednostavljen proces implementacije na Azure

Repozitorij uključuje sve potrebne konfiguracijske datoteke, izvorni kod i definicije infrastrukture za brzo započinjanje s produkcijski spremnom MCP server implementacijom.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Primjer implementacije MCP-a koristeći Azure Functions s Pythonom

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Primjer implementacije MCP-a koristeći Azure Functions s C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Primjer implementacije MCP-a koristeći Azure Functions s Node/TypeScript.

## Ključne spoznaje

- MCP SDK-ovi pružaju jezično specifične alate za implementaciju robusnih MCP rješenja
- Proces otklanjanja pogrešaka i testiranja je ključan za pouzdane MCP aplikacije
- Ponovljivi predlošci promptova omogućuju dosljedne AI interakcije
- Dobro dizajnirani tokovi rada mogu orkestrirati složene zadatke koristeći više alata
- Implementacija MCP rješenja zahtijeva razmatranje sigurnosti, performansi i rukovanja pogreškama

## Vježba

Dizajnirajte praktični MCP tok rada koji rješava stvarni problem u vašem području:

1. Identificirajte 3-4 alata koji bi bili korisni za rješavanje tog problema
2. Izradite dijagram toka rada koji prikazuje kako ti alati međusobno djeluju
3. Implementirajte osnovnu verziju jednog od alata koristeći vaš omiljeni jezik
4. Kreirajte predložak prompta koji će pomoći modelu da učinkovito koristi vaš alat

## Dodatni resursi


---

Sljedeće: [Napredne teme](../05-AdvancedTopics/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.