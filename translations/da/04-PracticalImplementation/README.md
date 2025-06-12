<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:17:02+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "da"
}
-->
# Praktisk implementering

Praktisk implementering er, hvor kraften i Model Context Protocol (MCP) bliver håndgribelig. Selvom det er vigtigt at forstå teorien og arkitekturen bag MCP, opstår den reelle værdi, når du anvender disse koncepter til at bygge, teste og implementere løsninger, der løser virkelige problemer. Dette kapitel bygger bro mellem konceptuel viden og praktisk udvikling og guider dig gennem processen med at bringe MCP-baserede applikationer til live.

Uanset om du udvikler intelligente assistenter, integrerer AI i forretningsprocesser eller bygger specialværktøjer til databehandling, giver MCP en fleksibel base. Dets sproguafhængige design og officielle SDK'er til populære programmeringssprog gør det tilgængeligt for mange udviklere. Ved at udnytte disse SDK'er kan du hurtigt prototype, iterere og skalere dine løsninger på tværs af forskellige platforme og miljøer.

I de følgende afsnit finder du praktiske eksempler, kodeeksempler og implementeringsstrategier, der viser, hvordan man implementerer MCP i C#, Java, TypeScript, JavaScript og Python. Du lærer også, hvordan du debugger og tester dine MCP-servere, håndterer API'er og implementerer løsninger i skyen ved hjælp af Azure. Disse praktiske ressourcer er designet til at fremskynde din læring og hjælpe dig med selvsikkert at bygge robuste, produktionsklare MCP-applikationer.

## Oversigt

Denne lektion fokuserer på praktiske aspekter af MCP-implementering på tværs af flere programmeringssprog. Vi vil undersøge, hvordan man bruger MCP SDK'er i C#, Java, TypeScript, JavaScript og Python til at bygge robuste applikationer, debugge og teste MCP-servere samt skabe genanvendelige ressourcer, prompts og værktøjer.

## Læringsmål

Ved slutningen af denne lektion vil du kunne:
- Implementere MCP-løsninger ved hjælp af officielle SDK'er i forskellige programmeringssprog
- Debugge og teste MCP-servere systematisk
- Oprette og bruge serverfunktioner (Resources, Prompts og Tools)
- Designe effektive MCP-workflows til komplekse opgaver
- Optimere MCP-implementeringer for ydeevne og pålidelighed

## Officielle SDK-ressourcer

Model Context Protocol tilbyder officielle SDK'er til flere sprog:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Arbejde med MCP SDK'er

Dette afsnit giver praktiske eksempler på implementering af MCP på tværs af flere programmeringssprog. Du kan finde eksempel-kode i `samples`-mappen organiseret efter sprog.

### Tilgængelige eksempler

Repositoryet indeholder eksempelimplementeringer i følgende sprog:

- C#
- Java
- TypeScript
- JavaScript
- Python

Hvert eksempel demonstrerer centrale MCP-koncepter og implementeringsmønstre for det specifikke sprog og økosystem.

## Centrale serverfunktioner

MCP-servere kan implementere enhver kombination af disse funktioner:

### Resources  
Resources leverer kontekst og data til brugeren eller AI-modellen:  
- Dokumentarkiver  
- Vidensbaser  
- Strukturerede datakilder  
- Filsystemer  

### Prompts  
Prompts er skabeloner til beskeder og workflows for brugere:  
- Foruddefinerede samtaleskabeloner  
- Guidede interaktionsmønstre  
- Specialiserede dialogstrukturer  

### Tools  
Tools er funktioner, som AI-modellen kan udføre:  
- Data-behandlingsværktøjer  
- Integrationer med eksterne API'er  
- Beregningsfunktioner  
- Søgefunktionalitet  

## Eksempelimplementeringer: C#

Det officielle C# SDK-repository indeholder flere eksempelimplementeringer, der viser forskellige aspekter af MCP:

- **Basic MCP Client**: Simpelt eksempel, der viser, hvordan man opretter en MCP-klient og kalder værktøjer  
- **Basic MCP Server**: Minimal serverimplementering med grundlæggende værktøjsregistrering  
- **Advanced MCP Server**: Fuldt udstyret server med værktøjsregistrering, autentificering og fejlbehandling  
- **ASP.NET Integration**: Eksempler, der demonstrerer integration med ASP.NET Core  
- **Tool Implementation Patterns**: Forskellige mønstre til implementering af værktøjer med varierende kompleksitet  

MCP C# SDK er i preview, og API'er kan ændre sig. Vi opdaterer løbende denne blog, efterhånden som SDK'en udvikler sig.

### Nøglefunktioner  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  

- Byg din [første MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).  

For komplette C#-implementeringseksempler, besøg det [officielle C# SDK-eksempelsrepository](https://github.com/modelcontextprotocol/csharp-sdk)

## Eksempelimplementering: Java

Java SDK tilbyder robuste MCP-implementeringsmuligheder med enterprise-funktioner.

### Nøglefunktioner

- Integration med Spring Framework  
- Stærk typesikkerhed  
- Support for reaktiv programmering  
- Omfattende fejlbehandling  

For et komplet Java-implementeringseksempel, se [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) i samples-mappen.

## Eksempelimplementering: JavaScript

JavaScript SDK giver en let og fleksibel tilgang til MCP-implementering.

### Nøglefunktioner

- Understøttelse af Node.js og browsere  
- Promise-baseret API  
- Nem integration med Express og andre frameworks  
- WebSocket-understøttelse til streaming  

For et komplet JavaScript-implementeringseksempel, se [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) i samples-mappen.

## Eksempelimplementering: Python

Python SDK tilbyder en Python-venlig tilgang til MCP-implementering med fremragende integrationer til ML-frameworks.

### Nøglefunktioner

- Async/await support med asyncio  
- Integration med Flask og FastAPI  
- Enkel værktøjsregistrering  
- Naturlig integration med populære ML-biblioteker  

For et komplet Python-implementeringseksempel, se [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) i samples-mappen.

## API-styring

Azure API Management er en god løsning til at sikre MCP-servere. Ideen er at placere en Azure API Management-instans foran din MCP-server og lade den håndtere funktioner, du sandsynligvis vil have som:

- ratebegrænsning  
- tokenstyring  
- overvågning  
- load balancing  
- sikkerhed  

### Azure-eksempel

Her er et Azure-eksempel, der gør præcis dette, dvs. [opretter en MCP-server og sikrer den med Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Se hvordan autorisationsflowet foregår i nedenstående billede:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

I det foregående billede sker følgende:

- Autentificering/autorisation sker via Microsoft Entra.  
- Azure API Management fungerer som en gateway og bruger politikker til at dirigere og styre trafik.  
- Azure Monitor logger alle forespørgsler til yderligere analyse.  

#### Autorisationsflow

Lad os se nærmere på autorisationsflowet:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP autorisationsspecifikation

Læs mere om [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Deploy Remote MCP Server til Azure

Lad os se, om vi kan implementere det tidligere nævnte eksempel:

1. Klon repoet

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registrer `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` og vent lidt, før du tjekker, om registreringen er fuldført.

3. Kør denne [azd](https://aka.ms/azd) kommando for at provisionere API Management-tjenesten, funktion app (med kode) og alle andre nødvendige Azure-ressourcer

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

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.da.png) 

2. CTRL-klik for at åbne MCP Inspector webappen fra den URL, appen viser (f.eks. http://127.0.0.1:6274/#resources)  
3. Sæt transporttypen til `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` og **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. Klik på et værktøj og **Run Tool**.

Hvis alle trin er gennemført korrekt, er du nu forbundet til MCP-serveren og har kunnet kalde et værktøj.

## MCP-servere til Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Dette sæt af repositories er hurtigstartskabeloner til at bygge og implementere tilpassede remote MCP (Model Context Protocol) servere ved hjælp af Azure Functions med Python, C# .NET eller Node/TypeScript.

Samples leverer en komplet løsning, der gør det muligt for udviklere at:

- Bygge og køre lokalt: Udvikle og debugge en MCP-server på en lokal maskine  
- Implementere til Azure: Nem implementering i skyen med en simpel azd up-kommando  
- Forbinde fra klienter: Forbinde til MCP-serveren fra forskellige klienter, herunder VS Codes Copilot agent mode og MCP Inspector værktøjet  

### Nøglefunktioner:

- Sikkerhed fra starten: MCP-serveren sikres med nøgler og HTTPS  
- Autentificeringsmuligheder: Understøtter OAuth med indbygget auth og/eller API Management  
- Netværksisolation: Muliggør netværksisolation ved hjælp af Azure Virtual Networks (VNET)  
- Serverløs arkitektur: Udnytter Azure Functions til skalerbar, hændelsesdrevet eksekvering  
- Lokal udvikling: Omfattende lokal udviklings- og debugstøtte  
- Enkel implementering: Strømlinet implementeringsproces til Azure  

Repositoryet indeholder alle nødvendige konfigurationsfiler, kildekode og infrastrukturdefinitioner for hurtigt at komme i gang med en produktionsklar MCP-serverimplementering.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Eksempelimplementering af MCP med Azure Functions og Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Eksempelimplementering af MCP med Azure Functions og C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Eksempelimplementering af MCP med Azure Functions og Node/TypeScript.

## Vigtigste pointer

- MCP SDK'er leverer sprog-specifikke værktøjer til at implementere robuste MCP-løsninger  
- Debugging og test er afgørende for pålidelige MCP-applikationer  
- Genanvendelige promptskabeloner muliggør konsistente AI-interaktioner  
- Veludformede workflows kan orkestrere komplekse opgaver med flere værktøjer  
- Implementering af MCP-løsninger kræver fokus på sikkerhed, ydeevne og fejlbehandling  

## Øvelse

Design et praktisk MCP-workflow, der løser et virkeligt problem inden for dit område:

1. Identificer 3-4 værktøjer, der ville være nyttige til at løse dette problem  
2. Lav et workflow-diagram, der viser, hvordan disse værktøjer interagerer  
3. Implementer en grundlæggende version af et af værktøjerne i dit foretrukne sprog  
4. Opret en promptskabelon, der hjælper modellen med effektivt at bruge dit værktøj  

## Yderligere ressourcer


---

Næste: [Avancerede emner](../05-AdvancedTopics/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.