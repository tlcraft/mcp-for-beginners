<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:54:25+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "no"
}
-->
# Praktisk implementering

Praktisk implementering er der, hvor styrken af Model Context Protocol (MCP) bliver håndgribelig. Selvom det er vigtigt at forstå teorien og arkitekturen bag MCP, er den virkelige værdi, når du anvender disse koncepter til at bygge, teste og implementere løsninger, der løser reelle problemer. Dette kapitel bygger bro mellem konceptuel viden og praktisk udvikling og guider dig gennem processen med at bringe MCP-baserede applikationer til live.

Uanset om du udvikler intelligente assistenter, integrerer AI i forretningsprocesser, eller bygger skræddersyede værktøjer til databehandling, giver MCP en fleksibel grundstruktur. Dets sprogagnostiske design og officielle SDK'er for populære programmeringssprog gør det tilgængeligt for en bred vifte af udviklere. Ved at udnytte disse SDK'er kan du hurtigt prototype, iterere og skalere dine løsninger på tværs af forskellige platforme og miljøer.

I de følgende afsnit finder du praktiske eksempler, eksempelkode og implementeringsstrategier, der demonstrerer, hvordan man implementerer MCP i C#, Java, TypeScript, JavaScript og Python. Du vil også lære, hvordan man debugger og tester dine MCP-servere, administrerer API'er, og implementerer løsninger til skyen ved hjælp af Azure. Disse praktiske ressourcer er designet til at accelerere din læring og hjælpe dig med at bygge robuste, produktionsklare MCP-applikationer med selvtillid.

## Oversigt

Denne lektion fokuserer på praktiske aspekter af MCP-implementering på tværs af flere programmeringssprog. Vi vil udforske, hvordan man bruger MCP SDK'er i C#, Java, TypeScript, JavaScript og Python til at bygge robuste applikationer, debugge og teste MCP-servere og skabe genanvendelige ressourcer, prompts og værktøjer.

## Læringsmål

Ved slutningen af denne lektion vil du være i stand til at:
- Implementere MCP-løsninger ved hjælp af officielle SDK'er i forskellige programmeringssprog
- Debugge og teste MCP-servere systematisk
- Oprette og bruge serverfunktioner (Ressourcer, Prompts og Værktøjer)
- Designe effektive MCP-arbejdsgange til komplekse opgaver
- Optimere MCP-implementeringer for ydeevne og pålidelighed

## Officielle SDK-ressourcer

Model Context Protocol tilbyder officielle SDK'er for flere sprog:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Arbejde med MCP SDK'er

Dette afsnit giver praktiske eksempler på implementering af MCP på tværs af flere programmeringssprog. Du kan finde eksempelkode i `samples`-mappen organiseret efter sprog.

### Tilgængelige eksempler

Repositoryet inkluderer eksempelimplementeringer i følgende sprog:

- C#
- Java
- TypeScript
- JavaScript
- Python

Hvert eksempel demonstrerer vigtige MCP-koncepter og implementeringsmønstre for det specifikke sprog og økosystem.

## Kerne serverfunktioner

MCP-servere kan implementere enhver kombination af disse funktioner:

### Ressourcer
Ressourcer leverer kontekst og data til brugeren eller AI-modellen:
- Dokumentlagre
- Vidensbaser
- Strukturerede datakilder
- Filsystemer

### Prompts
Prompts er skabelonmeddelelser og arbejdsgange til brugere:
- Foruddefinerede samtaleskabeloner
- Guidede interaktionsmønstre
- Specialiserede dialogstrukturer

### Værktøjer
Værktøjer er funktioner, som AI-modellen kan udføre:
- Databehandlingsværktøjer
- Eksterne API-integrationer
- Beregningsmuligheder
- Søgefunktionalitet

## Eksempelimplementeringer: C#

Det officielle C# SDK-repository indeholder flere eksempelimplementeringer, der demonstrerer forskellige aspekter af MCP:

- **Basisk MCP-klient**: Simpelt eksempel, der viser, hvordan man opretter en MCP-klient og kalder værktøjer
- **Basisk MCP-server**: Minimal serverimplementering med grundlæggende værktøjsregistrering
- **Avanceret MCP-server**: Fuldt udstyret server med værktøjsregistrering, autentifikation og fejlhåndtering
- **ASP.NET Integration**: Eksempler, der viser integration med ASP.NET Core
- **Værktøjsimplementeringsmønstre**: Forskellige mønstre til implementering af værktøjer med forskellige kompleksitetsniveauer

MCP C# SDK er i preview, og API'er kan ændre sig. Vi vil løbende opdatere denne blog, efterhånden som SDK'en udvikler sig.

### Nøglefunktioner
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Byg din [første MCP-server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

For komplette C#-implementeringseksempler, besøg det [officielle C# SDK-eksempler repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Eksempelimplementering: Java-implementering

Java SDK tilbyder robuste MCP-implementeringsmuligheder med enterprise-grade funktioner.

### Nøglefunktioner

- Spring Framework-integration
- Stærk typesikkerhed
- Understøttelse af reaktiv programmering
- Omfattende fejlhåndtering

For et komplet Java-implementeringseksempel, se [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) i eksempelmappen.

## Eksempelimplementering: JavaScript-implementering

JavaScript SDK giver en let og fleksibel tilgang til MCP-implementering.

### Nøglefunktioner

- Understøttelse af Node.js og browser
- Promise-baseret API
- Nem integration med Express og andre frameworks
- WebSocket-understøttelse til streaming

For et komplet JavaScript-implementeringseksempel, se [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) i eksempelmappen.

## Eksempelimplementering: Python-implementering

Python SDK tilbyder en Pythonisk tilgang til MCP-implementering med fremragende ML-framework-integrationer.

### Nøglefunktioner

- Async/await-understøttelse med asyncio
- Flask og FastAPI-integration
- Enkel værktøjsregistrering
- Naturlig integration med populære ML-biblioteker

For et komplet Python-implementeringseksempel, se [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) i eksempelmappen.

## API-styring

Azure API Management er en fremragende løsning til, hvordan vi kan sikre MCP-servere. Ideen er at placere en Azure API Management-instans foran din MCP-server og lade den håndtere funktioner, du sandsynligvis vil have, såsom:

- hastighedsbegrænsning
- tokenstyring
- overvågning
- belastningsbalancering
- sikkerhed

### Azure-eksempel

Her er et Azure-eksempel, der gør præcis det, dvs. [opretter en MCP-server og sikrer den med Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Se hvordan autorisationsflowet sker i nedenstående billede:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

I det foregående billede sker følgende:

- Autentifikation/autorisation finder sted ved hjælp af Microsoft Entra.
- Azure API Management fungerer som en gateway og bruger politikker til at dirigere og administrere trafik.
- Azure Monitor logger alle anmodninger til yderligere analyse.

#### Autorisationsflow

Lad os se nærmere på autorisationsflowet:

![Sekvensdiagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP-autorisation specifikation

Lær mere om [MCP-autorisation specifikationen](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementer Remote MCP Server til Azure

Lad os se, om vi kan implementere det eksempel, vi nævnte tidligere:

1. Klon repoen

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrer `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` efter noget tid for at kontrollere, om registreringen er fuldført.

2. Kør denne [azd](https://aka.ms/azd) kommando for at klargøre API-styringstjenesten, funktionsappen (med kode) og alle andre nødvendige Azure-ressourcer

    ```shell
    azd up
    ```

    Denne kommando bør implementere alle cloud-ressourcer på Azure

### Test din server med MCP Inspector

1. I et **nyt terminalvindue**, installer og kør MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Du bør se en grænseflade, der ligner:

    ![Forbind til Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.no.png)

1. CTRL klik for at indlæse MCP Inspector-webappen fra URL'en vist af appen (f.eks. http://127.0.0.1:6274/#resources)
1. Sæt transporttypen til `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` og **Forbind**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Værktøjer**. Klik på et værktøj og **Kør Værktøj**.

Hvis alle trin har fungeret, bør du nu være forbundet til MCP-serveren, og du har været i stand til at kalde et værktøj.

## MCP-servere til Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Dette sæt af repositories er en quickstart-skabelon til at bygge og implementere brugerdefinerede remote MCP (Model Context Protocol) servere ved hjælp af Azure Functions med Python, C# .NET eller Node/TypeScript.

Eksemplerne giver en komplet løsning, der giver udviklere mulighed for at:

- Bygge og køre lokalt: Udvikle og debugge en MCP-server på en lokal maskine
- Implementere til Azure: Let implementere til skyen med en simpel azd up-kommando
- Forbinde fra klienter: Forbinde til MCP-serveren fra forskellige klienter inklusive VS Code's Copilot agent-tilstand og MCP Inspector værktøjet

### Nøglefunktioner:

- Sikkerhed ved design: MCP-serveren er sikret ved hjælp af nøgler og HTTPS
- Autentifikationsmuligheder: Understøtter OAuth ved hjælp af indbygget autentifikation og/eller API Management
- Netværksisolering: Tillader netværksisolering ved hjælp af Azure Virtual Networks (VNET)
- Serverløs arkitektur: Udnytter Azure Functions til skalerbar, hændelsesdrevet udførelse
- Lokal udvikling: Omfattende lokal udvikling og debug-understøttelse
- Enkel implementering: Strømlinet implementeringsproces til Azure

Repositoryet inkluderer alle nødvendige konfigurationsfiler, kildekode og infrastrukturdefinitioner til hurtigt at komme i gang med en produktionsklar MCP-serverimplementering.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Eksempelimplementering af MCP ved hjælp af Azure Functions med Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Eksempelimplementering af MCP ved hjælp af Azure Functions med C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Eksempelimplementering af MCP ved hjælp af Azure Functions med Node/TypeScript.

## Vigtige pointer

- MCP SDK'er giver sprog-specifikke værktøjer til at implementere robuste MCP-løsninger
- Debugging og testprocessen er kritisk for pålidelige MCP-applikationer
- Genanvendelige promptskabeloner muliggør konsistente AI-interaktioner
- Veludformede arbejdsgange kan orkestrere komplekse opgaver ved hjælp af flere værktøjer
- Implementering af MCP-løsninger kræver overvejelse af sikkerhed, ydeevne og fejlhåndtering

## Øvelse

Design en praktisk MCP-arbejdsgang, der adresserer et reelt problem i dit domæne:

1. Identificer 3-4 værktøjer, der ville være nyttige til at løse dette problem
2. Opret et arbejdsgangsdiagram, der viser, hvordan disse værktøjer interagerer
3. Implementer en grundlæggende version af et af værktøjerne ved hjælp af dit foretrukne sprog
4. Opret en promptskabelon, der ville hjælpe modellen med effektivt at bruge dit værktøj

## Yderligere ressourcer

---

Næste: [Avancerede emner](../05-AdvancedTopics/README.md)

I'm sorry, I need clarification on what you mean by "no." Could you please specify the language you would like the text translated into?