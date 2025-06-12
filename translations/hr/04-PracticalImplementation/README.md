<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:30:11+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hr"
}
-->
# Praktična Implementacija

Praktična implementacija je trenutak kada snaga Model Context Protocola (MCP) postaje opipljiva. Iako je važno razumjeti teoriju i arhitekturu MCP-a, prava vrijednost dolazi kada primijenite ove koncepte za izgradnju, testiranje i implementaciju rješenja koja rješavaju stvarne probleme. Ova poglavlja povezuju teorijsko znanje s praktičnim razvojem, vodeći vas kroz proces oživljavanja aplikacija temeljenih na MCP-u.

Bilo da razvijate inteligentne asistente, integrirate AI u poslovne tokove rada ili gradite prilagođene alate za obradu podataka, MCP pruža fleksibilnu osnovu. Njegov dizajn neovisan o jeziku i službeni SDK-ovi za popularne programske jezike čine ga dostupnim širokom krugu programera. Korištenjem ovih SDK-ova možete brzo izrađivati prototipove, iterirati i skalirati svoja rješenja na različitim platformama i okruženjima.

U sljedećim odjeljcima pronaći ćete praktične primjere, uzorke koda i strategije implementacije koje pokazuju kako primijeniti MCP u C#, Java, TypeScript, JavaScript i Pythonu. Također ćete naučiti kako debugirati i testirati svoje MCP servere, upravljati API-jima i implementirati rješenja u oblak koristeći Azure. Ovi praktični resursi osmišljeni su da ubrzaju vaše učenje i pomognu vam da samouvjereno gradite robusne, produkcijski spremne MCP aplikacije.

## Pregled

Ova lekcija fokusira se na praktične aspekte implementacije MCP-a u više programskih jezika. Istražit ćemo kako koristiti MCP SDK-ove u C#, Java, TypeScript, JavaScript i Pythonu za izgradnju robusnih aplikacija, debugiranje i testiranje MCP servera te kreiranje ponovo iskoristivih resursa, promptova i alata.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:
- Implementirati MCP rješenja koristeći službene SDK-ove u različitim programskim jezicima
- Sistematski debugirati i testirati MCP servere
- Kreirati i koristiti funkcije servera (Resurse, Prompte i Alate)
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

Ovaj odjeljak pruža praktične primjere implementacije MCP-a u više programskih jezika. Uzorci koda nalaze se u direktoriju `samples` organiziranom po jeziku.

### Dostupni uzorci

Repozitorij uključuje primjere implementacije na sljedećim jezicima:

- C#
- Java
- TypeScript
- JavaScript
- Python

Svaki primjer demonstrira ključne MCP koncepte i obrasce implementacije za taj specifični jezik i ekosustav.

## Osnovne značajke servera

MCP serveri mogu implementirati bilo koju kombinaciju ovih značajki:

### Resursi
Resursi pružaju kontekst i podatke za korisnika ili AI model:
- Repozitoriji dokumenata
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
- Funkcionalnosti pretraživanja

## Primjeri implementacije: C#

Službeni C# SDK repozitorij sadrži nekoliko primjera implementacije koji pokazuju različite aspekte MCP-a:

- **Basic MCP Client**: Jednostavan primjer kako stvoriti MCP klijenta i pozvati alate
- **Basic MCP Server**: Minimalna implementacija servera s osnovnom registracijom alata
- **Advanced MCP Server**: Server s punim značajkama, uključujući registraciju alata, autentikaciju i upravljanje greškama
- **ASP.NET Integracija**: Primjeri integracije s ASP.NET Core
- **Obrasci implementacije alata**: Razni obrasci za implementaciju alata različitih razina složenosti

MCP C# SDK je u preview fazi i API-ji se mogu mijenjati. Ovaj blog ćemo kontinuirano ažurirati kako SDK bude evoluirao.

### Ključne značajke 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Izgradnja vašeg [prvog MCP servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za potpune primjere implementacije u C#, posjetite [službeni repozitorij C# SDK primjera](https://github.com/modelcontextprotocol/csharp-sdk)

## Primjer implementacije: Java

Java SDK nudi robusne mogućnosti implementacije MCP-a s enterprise razinom značajki.

### Ključne značajke

- Integracija sa Spring Frameworkom
- Snažna tipna sigurnost
- Podrška za reaktivno programiranje
- Sveobuhvatno upravljanje greškama

Za potpuni primjer implementacije u Javi, pogledajte [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) u direktoriju uzoraka.

## Primjer implementacije: JavaScript

JavaScript SDK pruža lagan i fleksibilan pristup implementaciji MCP-a.

### Ključne značajke

- Podrška za Node.js i preglednike
- Promise-based API
- Jednostavna integracija s Express i drugim frameworkima
- Podrška za WebSocket za streaming

Za potpuni primjer implementacije u JavaScriptu, pogledajte [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) u direktoriju uzoraka.

## Primjer implementacije: Python

Python SDK nudi pythonovski pristup implementaciji MCP-a s izvrsnom integracijom ML frameworka.

### Ključne značajke

- Podrška za async/await s asyncio
- Integracija s Flask i FastAPI
- Jednostavna registracija alata
- Izvorna integracija s popularnim ML bibliotekama

Za potpuni primjer implementacije u Pythonu, pogledajte [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) u direktoriju uzoraka.

## Upravljanje API-jem

Azure API Management je izvrsno rješenje za osiguranje MCP servera. Ideja je postaviti Azure API Management instancu ispred vašeg MCP servera i dopustiti mu da upravlja značajkama koje će vam vjerojatno trebati, poput:

- ograničenja brzine (rate limiting)
- upravljanja tokenima
- nadzora
- balansiranja opterećenja
- sigurnosti

### Azure primjer

Evo Azure primjera koji radi upravo to, tj. [kreira MCP Server i osigurava ga s Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pogledajte kako autorizacijski tok izgleda na slici ispod:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na prethodnoj slici događa se sljedeće:

- Autentikacija/Autorizacija se odvija korištenjem Microsoft Entra.
- Azure API Management djeluje kao gateway i koristi politike za usmjeravanje i upravljanje prometom.
- Azure Monitor bilježi sve zahtjeve za daljnju analizu.

#### Autorizacijski tok

Pogledajmo autorizacijski tok detaljnije:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP autorizacijska specifikacija

Saznajte više o [MCP Authorization specifikaciji](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementacija Remote MCP Servera na Azure

Pogledajmo možemo li implementirati ranije spomenuti primjer:

1. Klonirajte repozitorij

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registrirajte `Microsoft.App` pomoću naredbe ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run ` ili `. Then run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `. Nakon nekog vremena provjerite status registracije s `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`.

3. Pokrenite ovu [azd](https://aka.ms/azd) naredbu za provisioniranje API management servisa, funkcijske aplikacije (s kodom) i svih ostalih potrebnih Azure resursa

    ```shell
    azd up
    ```

    Ova naredba bi trebala implementirati sve cloud resurse na Azureu.

### Testiranje servera s MCP Inspectorom

1. U **novom terminalu** instalirajte i pokrenite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Trebali biste vidjeti sučelje slično ovome:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hr.png) 

2. CTRL klikom otvorite MCP Inspector web aplikaciju s URL-a koji aplikacija prikazuje (npr. http://127.0.0.1:6274/#resources)
3. Postavite tip transporta na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` i **Povežite se**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Popis alata**. Kliknite na alat i **Pokrenite alat**.

Ako su svi koraci prošli uspješno, sada ste povezani s MCP serverom i uspjeli ste pozvati alat.

## MCP serveri za Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ovaj skup repozitorija je predložak za brzi početak za izgradnju i implementaciju prilagođenih remote MCP (Model Context Protocol) servera koristeći Azure Functions s Python, C# .NET ili Node/TypeScript.

Primjeri pružaju kompletno rješenje koje programerima omogućuje:

- Izgradnju i lokalno pokretanje: razvoj i debugiranje MCP servera na lokalnom računalu
- Implementaciju u Azure: jednostavna implementacija u oblak s jednom azd up naredbom
- Povezivanje s klijentima: povezivanje s MCP serverom iz različitih klijenata, uključujući VS Code-ov Copilot agent mod i MCP Inspector alat

### Ključne značajke:

- Sigurnost po dizajnu: MCP server je zaštićen ključevima i HTTPS-om
- Opcije autentikacije: podržava OAuth koristeći ugrađenu autentikaciju i/ili API Management
- Izolacija mreže: omogućuje mrežnu izolaciju koristeći Azure Virtual Networks (VNET)
- Serverless arhitektura: koristi Azure Functions za skalabilno, događajno upravljano izvršavanje
- Lokalni razvoj: sveobuhvatna podrška za lokalni razvoj i debugiranje
- Jednostavna implementacija: pojednostavljeni proces implementacije u Azure

Repozitorij uključuje sve potrebne konfiguracijske datoteke, izvorni kod i definicije infrastrukture za brz početak s produkcijski spremnom MCP server implementacijom.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Primjer implementacije MCP-a koristeći Azure Functions s Python-om

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Primjer implementacije MCP-a koristeći Azure Functions s C# .NET-om

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Primjer implementacije MCP-a koristeći Azure Functions s Node/TypeScript-om.

## Ključne spoznaje

- MCP SDK-ovi pružaju jezično specifične alate za implementaciju robusnih MCP rješenja
- Proces debugiranja i testiranja ključan je za pouzdane MCP aplikacije
- Ponovno upotrebljivi predlošci promptova omogućuju dosljedne AI interakcije
- Dobro dizajnirani tokovi rada mogu orkestrirati složene zadatke koristeći više alata
- Implementacija MCP rješenja zahtijeva razmatranje sigurnosti, performansi i upravljanja greškama

## Vježba

Dizajnirajte praktični MCP tok rada koji rješava stvarni problem u vašem području:

1. Identificirajte 3-4 alata koji bi bili korisni za rješavanje tog problema
2. Kreirajte dijagram toka rada koji pokazuje kako ti alati međusobno djeluju
3. Implementirajte osnovnu verziju jednog od alata koristeći željeni programski jezik
4. Kreirajte predložak prompta koji bi modelu pomogao da učinkovito koristi vaš alat

## Dodatni resursi


---

Sljedeće: [Napredne teme](../05-AdvancedTopics/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.