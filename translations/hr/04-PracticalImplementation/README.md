<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:36:32+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hr"
}
-->
# Praktična implementacija

Praktična implementacija je mjesto gdje snaga Model Context Protocola (MCP) postaje opipljiva. Iako je važno razumjeti teoriju i arhitekturu iza MCP-a, prava vrijednost dolazi kada primijenite ove koncepte za izgradnju, testiranje i implementaciju rješenja koja rješavaju stvarne probleme. Ovo poglavlje premošćuje jaz između konceptualnog znanja i praktičnog razvoja, vodeći vas kroz proces oživljavanja aplikacija baziranih na MCP-u.

Bilo da razvijate inteligentne asistente, integrirate AI u poslovne tokove rada ili gradite prilagođene alate za obradu podataka, MCP pruža fleksibilnu osnovu. Njegov dizajn neovisan o programskom jeziku i službeni SDK-ovi za popularne programske jezike čine ga dostupnim širokom krugu developera. Iskorištavanjem ovih SDK-ova možete brzo prototipirati, iterirati i skalirati svoja rješenja na različitim platformama i okruženjima.

U sljedećim odjeljcima pronaći ćete praktične primjere, uzorke koda i strategije implementacije koje pokazuju kako primijeniti MCP u C#, Javi, TypeScriptu, JavaScriptu i Pythonu. Također ćete naučiti kako otklanjati pogreške i testirati svoje MCP servere, upravljati API-jima i implementirati rješenja u oblak koristeći Azure. Ovi praktični resursi dizajnirani su da ubrzaju vaše učenje i pomognu vam da s povjerenjem izgradite robusne, proizvodno spremne MCP aplikacije.

## Pregled

Ova lekcija fokusira se na praktične aspekte implementacije MCP-a u više programskih jezika. Istražit ćemo kako koristiti MCP SDK-ove u C#, Javi, TypeScriptu, JavaScriptu i Pythonu za izgradnju robusnih aplikacija, otklanjanje pogrešaka i testiranje MCP servera, te kreiranje ponovo iskoristivih resursa, promptova i alata.

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

Ovaj odjeljak pruža praktične primjere implementacije MCP-a u više programskih jezika. Uzorci koda nalaze se u direktoriju `samples` organiziranom po jezicima.

### Dostupni uzorci

Repozitorij uključuje [primjere implementacija](../../../04-PracticalImplementation/samples) na sljedećim jezicima:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Svaki primjer demonstrira ključne koncepte MCP-a i obrasce implementacije za taj specifični jezik i ekosustav.

## Osnovne značajke servera

MCP serveri mogu implementirati bilo koju kombinaciju ovih značajki:

### Resursi
Resursi pružaju kontekst i podatke koje korisnik ili AI model može koristiti:
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
- Računske mogućnosti
- Funkcionalnost pretraživanja

## Primjeri implementacija: C#

Službeni C# SDK repozitorij sadrži nekoliko primjera implementacija koji pokazuju različite aspekte MCP-a:

- **Osnovni MCP klijent**: Jednostavan primjer koji pokazuje kako kreirati MCP klijenta i pozivati alate
- **Osnovni MCP server**: Minimalna implementacija servera s osnovnom registracijom alata
- **Napredni MCP server**: Server s punim značajkama, uključujući registraciju alata, autentifikaciju i upravljanje greškama
- **Integracija s ASP.NET-om**: Primjeri integracije s ASP.NET Core
- **Obrasci implementacije alata**: Razni obrasci za implementaciju alata različitih razina složenosti

MCP C# SDK je u preview fazi i API-ji se mogu mijenjati. Ovaj blog ćemo kontinuirano ažurirati kako SDK bude evoluirao.

### Ključne značajke 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Izgradnja vašeg [prvog MCP servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za potpune C# primjere implementacije, posjetite [službeni repozitorij C# SDK primjera](https://github.com/modelcontextprotocol/csharp-sdk)

## Primjer implementacije: Java

Java SDK nudi robusne opcije implementacije MCP-a s enterprise značajkama.

### Ključne značajke

- Integracija sa Spring Frameworkom
- Snažna tipna sigurnost
- Podrška za reaktivno programiranje
- Sveobuhvatno upravljanje greškama

Za kompletan primjer implementacije u Javi, pogledajte [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) u direktoriju s primjerima.

## Primjer implementacije: JavaScript

JavaScript SDK pruža lagan i fleksibilan pristup implementaciji MCP-a.

### Ključne značajke

- Podrška za Node.js i preglednike
- API baziran na Promise-ima
- Jednostavna integracija s Expressom i drugim frameworkima
- Podrška za WebSocket za streaming

Za kompletan primjer implementacije u JavaScriptu, pogledajte [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) u direktoriju s primjerima.

## Primjer implementacije: Python

Python SDK nudi pythonistički pristup implementaciji MCP-a s izvrsnom integracijom ML frameworka.

### Ključne značajke

- Podrška za async/await s asyncio
- Integracija s Flask i FastAPI
- Jednostavna registracija alata
- Nativna integracija s popularnim ML bibliotekama

Za kompletan primjer implementacije u Pythonu, pogledajte [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) u direktoriju s primjerima.

## Upravljanje API-jem

Azure API Management je izvrsno rješenje za osiguranje MCP servera. Ideja je postaviti Azure API Management instancu ispred vašeg MCP servera i dopustiti mu da upravlja značajkama koje ćete vjerojatno htjeti, kao što su:

- ograničavanje brzine (rate limiting)
- upravljanje tokenima
- nadzor
- balansiranje opterećenja
- sigurnost

### Azure primjer

Evo Azure primjera koji radi upravo to, tj. [kreira MCP server i osigurava ga pomoću Azure API Managementa](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pogledajte kako autorizacijski tok izgleda na slici ispod:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na prethodnoj slici događa se sljedeće:

- Autentifikacija/Autorizacija odvija se pomoću Microsoft Entra.
- Azure API Management djeluje kao gateway i koristi politike za usmjeravanje i upravljanje prometom.
- Azure Monitor bilježi sve zahtjeve za daljnju analizu.

#### Tok autorizacije

Pogledajmo autorizacijski tok detaljnije:

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

1. Registrirajte `Microsoft.App` pomoću:

    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `

   Nakon nekog vremena provjerite je li registracija dovršena s:

    `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

2. Pokrenite ovu [azd](https://aka.ms/azd) naredbu za provisioning API Management servisa, funkcijske aplikacije (s kodom) i svih ostalih potrebnih Azure resursa

    ```shell
    azd up
    ```

    Ova naredba bi trebala implementirati sve oblačne resurse na Azureu

### Testiranje vašeg servera s MCP Inspectorom

1. U **novom terminal prozoru**, instalirajte i pokrenite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Trebali biste vidjeti sučelje slično:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hr.png) 

1. CTRL klikom otvorite MCP Inspector web aplikaciju s URL-a prikazanog u aplikaciji (npr. http://127.0.0.1:6274/#resources)
1. Postavite tip transporta na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` i **Povežite se**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Popis alata**. Kliknite na alat i **Pokreni alat**.  

Ako su svi koraci prošli uspješno, sada ste povezani na MCP server i uspjeli ste pozvati alat.

## MCP serveri za Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ovaj skup repozitorija je brzi početni predložak za izgradnju i implementaciju prilagođenih udaljenih MCP (Model Context Protocol) servera koristeći Azure Functions s Pythonom, C# .NET ili Node/TypeScriptom.

Primjeri pružaju kompletno rješenje koje developerima omogućuje:

- Izgradnju i lokalno pokretanje: razvoj i otklanjanje pogrešaka MCP servera na lokalnom računalu
- Implementaciju na Azure: jednostavnu implementaciju u oblak s jednom azd up naredbom
- Povezivanje s klijentima: povezivanje s MCP serverom s raznih klijenata uključujući VS Code-ov Copilot agent mode i MCP Inspector alat

### Ključne značajke:

- Sigurnost po dizajnu: MCP server je osiguran pomoću ključeva i HTTPS-a
- Opcije autentifikacije: podržava OAuth koristeći ugrađenu autentifikaciju i/ili API Management
- Izolacija mreže: omogućuje izolaciju mreže koristeći Azure Virtual Networks (VNET)
- Serverless arhitektura: koristi Azure Functions za skalabilno, događajima vođeno izvršavanje
- Lokalni razvoj: sveobuhvatna podrška za lokalni razvoj i otklanjanje pogrešaka
- Jednostavna implementacija: pojednostavljeni proces implementacije na Azure

Repozitorij uključuje sve potrebne konfiguracijske datoteke, izvorni kod i definicije infrastrukture za brzo započinjanje s proizvodno spremnom MCP server implementacijom.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Primjer implementacije MCP-a koristeći Azure Functions s Pythonom

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Primjer implementacije MCP-a koristeći Azure Functions s C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Primjer implementacije MCP-a koristeći Azure Functions s Node/TypeScriptom.

## Ključne spoznaje

- MCP SDK-ovi pružaju jezično specifične alate za implementaciju robusnih MCP rješenja
- Proces otklanjanja pogrešaka i testiranja je ključan za pouzdane MCP aplikacije
- Ponovno iskoristivi predlošci promptova omogućuju dosljedne AI interakcije
- Dobro dizajnirani tokovi rada mogu orkestrirati složene zadatke koristeći više alata
- Implementacija MCP rješenja zahtijeva razmatranje sigurnosti, performansi i upravljanja greškama

## Vježba

Dizajnirajte praktičan MCP tok rada koji rješava stvarni problem u vašem području:

1. Identificirajte 3-4 alata koji bi bili korisni za rješavanje tog problema
2. Kreirajte dijagram toka rada koji prikazuje kako ti alati međusobno djeluju
3. Implementirajte osnovnu verziju jednog od alata koristeći željeni programski jezik
4. Kreirajte predložak prompta koji će pomoći modelu da učinkovito koristi vaš alat

## Dodatni resursi


---

Sljedeće: [Napredne teme](../05-AdvancedTopics/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.