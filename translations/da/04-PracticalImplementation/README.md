<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:53:55+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "da"
}
-->
# Praktisk Implementering

Praktisk implementering er der, hvor kraften i Model Context Protocol (MCP) bliver håndgribelig. Mens det er vigtigt at forstå teorien og arkitekturen bag MCP, opstår den virkelige værdi, når du anvender disse koncepter til at bygge, teste og implementere løsninger, der løser virkelige problemer. Dette kapitel bygger bro mellem konceptuel viden og praktisk udvikling og guider dig gennem processen med at bringe MCP-baserede applikationer til live.

Uanset om du udvikler intelligente assistenter, integrerer AI i forretningsprocesser eller bygger skræddersyede værktøjer til databehandling, giver MCP en fleksibel grundlag. Dets sprogagnostiske design og officielle SDK'er til populære programmeringssprog gør det tilgængeligt for en bred vifte af udviklere. Ved at udnytte disse SDK'er kan du hurtigt prototype, iterere og skalere dine løsninger på tværs af forskellige platforme og miljøer.

I de følgende afsnit finder du praktiske eksempler, prøvekode og implementeringsstrategier, der viser, hvordan man implementerer MCP i C#, Java, TypeScript, JavaScript og Python. Du vil også lære, hvordan man debugger og tester dine MCP-servere, administrerer API'er og implementerer løsninger i skyen ved hjælp af Azure. Disse praktiske ressourcer er designet til at fremskynde din læring og hjælpe dig med selvtillid til at bygge robuste, produktionsklare MCP-applikationer.

## Oversigt

Denne lektion fokuserer på de praktiske aspekter af MCP-implementering på tværs af flere programmeringssprog. Vi vil udforske, hvordan man bruger MCP SDK'er i C#, Java, TypeScript, JavaScript og Python til at bygge robuste applikationer, debugge og teste MCP-servere og skabe genanvendelige ressourcer, prompts og værktøjer.

## Læringsmål

Ved slutningen af denne lektion vil du være i stand til at:
- Implementere MCP-løsninger ved hjælp af officielle SDK'er i forskellige programmeringssprog
- Systematisk debugge og teste MCP-servere
- Oprette og bruge serverfunktioner (Ressourcer, Prompts og Værktøjer)
- Designe effektive MCP-arbejdsgange til komplekse opgaver
- Optimere MCP-implementeringer for ydeevne og pålidelighed

## Officielle SDK-ressourcer

Model Context Protocol tilbyder officielle SDK'er til flere sprog:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Arbejde med MCP SDK'er

Dette afsnit giver praktiske eksempler på implementering af MCP på tværs af flere programmeringssprog. Du kan finde prøvekode i `samples`-biblioteket organiseret efter sprog.

### Tilgængelige Eksempler

Repositoryet inkluderer prøveimplementeringer i følgende sprog:

- C#
- Java
- TypeScript
- JavaScript
- Python

Hvert eksempel demonstrerer centrale MCP-koncepter og implementeringsmønstre for det specifikke sprog og økosystem.

## Kerne Server Funktioner

MCP-servere kan implementere en hvilken som helst kombination af disse funktioner:

### Ressourcer
Ressourcer giver kontekst og data til brugeren eller AI-modellen:
- Dokumentarkiver
- Vidensbaser
- Strukturerede datakilder
- Filsystemer

### Prompts
Prompts er skabelonmeddelelser og arbejdsgange for brugere:
- Foruddefinerede samtaleskabeloner
- Guidede interaktionsmønstre
- Specialiserede dialogstrukturer

### Værktøjer
Værktøjer er funktioner, som AI-modellen skal udføre:
- Databehandlingsværktøjer
- Eksterne API-integrationer
- Beregningskapaciteter
- Søgefunktionalitet

## Eksempel Implementeringer: C#

Det officielle C# SDK-repository indeholder flere eksempelimplementeringer, der demonstrerer forskellige aspekter af MCP:

- **Basic MCP Client**: Simpelt eksempel, der viser, hvordan man opretter en MCP-klient og kalder værktøjer
- **Basic MCP Server**: Minimal serverimplementering med grundlæggende værktøjsregistrering
- **Advanced MCP Server**: Fuldt udstyret server med værktøjsregistrering, autentifikation og fejlbehandling
- **ASP.NET Integration**: Eksempler, der demonstrerer integration med ASP.NET Core
- **Tool Implementation Patterns**: Forskellige mønstre til implementering af værktøjer med forskellige kompleksitetsniveauer

MCP C# SDK er i preview, og API'er kan ændre sig. Vi vil løbende opdatere denne blog, efterhånden som SDK'en udvikler sig.

### Nøglefunktioner 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Byg din [første MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

For komplette C# implementeringseksempler, besøg [det officielle C# SDK prøveimplementeringsrepository](https://github.com/modelcontextprotocol/csharp-sdk)

## Eksempel Implementering: Java Implementering

Java SDK tilbyder robuste MCP implementeringsmuligheder med funktioner i virksomhedsklasse.

### Nøglefunktioner

- Integration med Spring Framework
- Stærk typesikkerhed
- Understøttelse af reaktiv programmering
- Omfattende fejlbehandling

For et komplet Java implementeringseksempel, se [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) i prøvemappen.

## Eksempel Implementering: JavaScript Implementering

JavaScript SDK giver en let og fleksibel tilgang til MCP implementering.

### Nøglefunktioner

- Understøttelse af Node.js og browser
- Promise-baseret API
- Nem integration med Express og andre frameworks
- WebSocket support til streaming

For et komplet JavaScript implementeringseksempel, se [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) i prøvemappen.

## Eksempel Implementering: Python Implementering

Python SDK tilbyder en Pythonisk tilgang til MCP implementering med fremragende ML framework integrationer.

### Nøglefunktioner

- Async/await support med asyncio
- Integration med Flask og FastAPI
- Enkel værktøjsregistrering
- Indbygget integration med populære ML biblioteker

For et komplet Python implementeringseksempel, se [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) i prøvemappen.

## API-styring 

Azure API Management er en fremragende løsning til, hvordan vi kan sikre MCP-servere. Ideen er at placere en Azure API Management instans foran din MCP-server og lade den håndtere funktioner, du sandsynligvis vil have som:

- hastighedsbegrænsning
- tokenstyring
- overvågning
- belastningsbalancering
- sikkerhed

### Azure Eksempel

Her er et Azure Eksempel, der gør netop det, nemlig [oprette en MCP-server og sikre den med Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Se, hvordan autorisationsflowet sker i nedenstående billede:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

I det foregående billede sker følgende:

- Autentifikation/Autorisation sker ved hjælp af Microsoft Entra.
- Azure API Management fungerer som en gateway og bruger politikker til at dirigere og administrere trafik.
- Azure Monitor logger alle anmodninger til yderligere analyse.

#### Autorisationsflow

Lad os se nærmere på autorisationsflowet:

![Sekvensdiagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP autorisationsspecifikation

Lær mere om [MCP Autorisationsspecifikation](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementer Fjern MCP Server til Azure

Lad os se, om vi kan implementere det eksempel, vi nævnte tidligere:

1. Klon repoen

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrer `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` efter noget tid for at tjekke, om registreringen er fuldført.

2. Kør denne [azd](https://aka.ms/azd) kommando for at klargøre api management-tjenesten, funktionsappen (med kode) og alle andre nødvendige Azure ressourcer

    ```shell
    azd up
    ```

    Denne kommando bør implementere alle cloud ressourcer på Azure

### Test din server med MCP Inspector

1. I et **nyt terminalvindue**, installer og kør MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Du burde se en grænseflade, der ligner:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.da.png)

1. CTRL klik for at indlæse MCP Inspector web app fra URL'en vist af appen (f.eks. http://127.0.0.1:6274/#resources)
1. Indstil transporttypen til `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` og **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. Klik på et værktøj og **Run Tool**.  

Hvis alle trin har fungeret, burde du nu være forbundet til MCP-serveren, og du har været i stand til at kalde et værktøj.

## MCP servere til Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Dette sæt af repositories er quickstart templates til at bygge og implementere tilpassede fjern MCP (Model Context Protocol) servere ved hjælp af Azure Functions med Python, C# .NET eller Node/TypeScript. 

Prøverne giver en komplet løsning, der gør det muligt for udviklere at:

- Bygge og køre lokalt: Udvikle og debugge en MCP-server på en lokal maskine
- Implementere til Azure: Nem implementering til skyen med en simpel azd up kommando
- Forbind fra klienter: Forbind til MCP-serveren fra forskellige klienter, inklusive VS Code's Copilot agent mode og MCP Inspector værktøjet

### Nøglefunktioner:

- Sikkerhed som design: MCP-serveren er sikret ved hjælp af nøgler og HTTPS
- Autentifikationsmuligheder: Understøtter OAuth ved hjælp af indbygget auth og/eller API Management
- Netværksisolering: Tillader netværksisolering ved hjælp af Azure Virtual Networks (VNET)
- Serverløs arkitektur: Udnytter Azure Functions til skalerbar, hændelsesdrevet udførelse
- Lokal udvikling: Omfattende lokal udvikling og debug support
- Enkel implementering: Strømlinet implementeringsproces til Azure

Repositoryet inkluderer alle nødvendige konfigurationsfiler, kildekode og infrastrukturbeskrivelser til hurtigt at komme i gang med en produktionsklar MCP-serverimplementering.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Eksempelimplementering af MCP ved hjælp af Azure Functions med Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Eksempelimplementering af MCP ved hjælp af Azure Functions med C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Eksempelimplementering af MCP ved hjælp af Azure Functions med Node/TypeScript.

## Nøglepunkter

- MCP SDK'er giver sprog-specifikke værktøjer til implementering af robuste MCP-løsninger
- Debugging og testprocessen er kritisk for pålidelige MCP-applikationer
- Genanvendelige promptskabeloner muliggør konsistente AI-interaktioner
- Veludformede arbejdsgange kan orkestrere komplekse opgaver ved hjælp af flere værktøjer
- Implementering af MCP-løsninger kræver overvejelse af sikkerhed, ydeevne og fejlbehandling

## Øvelse

Design en praktisk MCP-arbejdsgang, der adresserer et virkeligt problem i dit domæne:

1. Identificer 3-4 værktøjer, der ville være nyttige til at løse dette problem
2. Opret et arbejdsgangsdiagram, der viser, hvordan disse værktøjer interagerer
3. Implementer en grundlæggende version af et af værktøjerne ved hjælp af dit foretrukne sprog
4. Opret en promptskabelon, der ville hjælpe modellen med effektivt at bruge dit værktøj

## Yderligere Ressourcer

---

Næste: [Avancerede Emner](../05-AdvancedTopics/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der måtte opstå ved brug af denne oversættelse.