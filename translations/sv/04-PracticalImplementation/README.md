<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:53:56+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sv"
}
-->
# Praktisk Implementering

Praktisk implementering är där kraften i Model Context Protocol (MCP) blir påtaglig. Även om det är viktigt att förstå teorin och arkitekturen bakom MCP, uppstår det verkliga värdet när du tillämpar dessa koncept för att bygga, testa och distribuera lösningar som löser verkliga problem. Detta kapitel överbryggar klyftan mellan konceptuell kunskap och praktisk utveckling, och vägleder dig genom processen att förverkliga MCP-baserade applikationer.

Oavsett om du utvecklar intelligenta assistenter, integrerar AI i affärsflöden eller bygger anpassade verktyg för databehandling, erbjuder MCP en flexibel grund. Dess språkoberoende design och officiella SDK:er för populära programmeringsspråk gör det tillgängligt för en bred utvecklarkrets. Genom att utnyttja dessa SDK:er kan du snabbt prototypa, iterera och skala dina lösningar över olika plattformar och miljöer.

I följande avsnitt hittar du praktiska exempel, kodexempel och distributionsstrategier som visar hur du implementerar MCP i C#, Java, TypeScript, JavaScript och Python. Du kommer också att lära dig hur du felsöker och testar dina MCP-servrar, hanterar API:er och distribuerar lösningar till molnet med Azure. Dessa praktiska resurser är utformade för att påskynda din inlärning och hjälpa dig att tryggt bygga robusta, produktionsklara MCP-applikationer.

## Översikt

Denna lektion fokuserar på praktiska aspekter av MCP-implementering i flera programmeringsspråk. Vi kommer att utforska hur man använder MCP SDK:er i C#, Java, TypeScript, JavaScript och Python för att bygga robusta applikationer, felsöka och testa MCP-servrar samt skapa återanvändbara resurser, prompts och verktyg.

## Lärandemål

I slutet av denna lektion kommer du att kunna:
- Implementera MCP-lösningar med officiella SDK:er i olika programmeringsspråk
- Felsöka och testa MCP-servrar systematiskt
- Skapa och använda serverfunktioner (Resources, Prompts och Tools)
- Designa effektiva MCP-arbetsflöden för komplexa uppgifter
- Optimera MCP-implementationer för prestanda och tillförlitlighet

## Officiella SDK-resurser

Model Context Protocol erbjuder officiella SDK:er för flera språk:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Arbeta med MCP SDK:er

Detta avsnitt ger praktiska exempel på hur man implementerar MCP i flera programmeringsspråk. Du hittar exempel i `samples`-katalogen organiserade efter språk.

### Tillgängliga exempel

Förrådet innehåller [exempelimplementationer](../../../04-PracticalImplementation/samples) i följande språk:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Varje exempel visar viktiga MCP-koncept och implementationsmönster för det specifika språket och ekosystemet.

## Kärnfunktioner för servern

MCP-servrar kan implementera vilken kombination som helst av dessa funktioner:

### Resources
Resources tillhandahåller kontext och data för användaren eller AI-modellen att använda:
- Dokumentarkiv
- Kunskapsbaser
- Strukturerade datakällor
- Filsystem

### Prompts
Prompts är mallbaserade meddelanden och arbetsflöden för användare:
- Fördefinierade konversationsmallar
- Guidad interaktionsmönster
- Specialiserade dialogstrukturer

### Tools
Tools är funktioner som AI-modellen kan utföra:
- Verktyg för databehandling
- Integrationer med externa API:er
- Beräkningsfunktioner
- Sökmöjligheter

## Exempelimplementationer: C#

Det officiella C# SDK-förrådet innehåller flera exempel som visar olika aspekter av MCP:

- **Basic MCP Client**: Enkelt exempel som visar hur man skapar en MCP-klient och anropar verktyg
- **Basic MCP Server**: Minimal serverimplementation med grundläggande verktygsregistrering
- **Advanced MCP Server**: Fullfjädrad server med verktygsregistrering, autentisering och felhantering
- **ASP.NET Integration**: Exempel som visar integration med ASP.NET Core
- **Tool Implementation Patterns**: Olika mönster för att implementera verktyg med varierande komplexitet

MCP C# SDK är i förhandsgranskning och API:er kan ändras. Vi kommer kontinuerligt att uppdatera denna blogg i takt med att SDK:n utvecklas.

### Viktiga funktioner 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Bygg din [första MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

För kompletta C# implementationsexempel, besök det [officiella C# SDK-exempelförrådet](https://github.com/modelcontextprotocol/csharp-sdk)

## Exempelimplementation: Java Implementation

Java SDK erbjuder robusta MCP-implementeringsalternativ med företagsklassade funktioner.

### Viktiga funktioner

- Integration med Spring Framework
- Stark typkontroll
- Stöd för reaktiv programmering
- Omfattande felhantering

För ett komplett Java-implementationsprov, se [Java sample](samples/java/containerapp/README.md) i samples-katalogen.

## Exempelimplementation: JavaScript Implementation

JavaScript SDK erbjuder ett lättviktigt och flexibelt tillvägagångssätt för MCP-implementering.

### Viktiga funktioner

- Stöd för Node.js och webbläsare
- Promise-baserat API
- Enkel integration med Express och andra ramverk
- WebSocket-stöd för streaming

För ett komplett JavaScript-implementationsprov, se [JavaScript sample](samples/javascript/README.md) i samples-katalogen.

## Exempelimplementation: Python Implementation

Python SDK erbjuder ett Pythoniskt tillvägagångssätt för MCP-implementering med utmärkta integrationer för ML-ramverk.

### Viktiga funktioner

- Async/await-stöd med asyncio
- Integration med Flask och FastAPI
- Enkel verktygsregistrering
- Naturlig integration med populära ML-bibliotek

För ett komplett Python-implementationsprov, se [Python sample](samples/python/README.md) i samples-katalogen.

## API-hantering

Azure API Management är en utmärkt lösning för hur vi kan säkra MCP-servrar. Idén är att placera en Azure API Management-instans framför din MCP-server och låta den hantera funktioner som du sannolikt vill ha, såsom:

- begränsning av anropstakt
- tokenhantering
- övervakning
- lastbalansering
- säkerhet

### Azure-exempel

Här är ett Azure-exempel som gör just detta, dvs [skapar en MCP-server och säkrar den med Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Se hur auktoriseringsflödet sker i bilden nedan:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

I bilden ovan sker följande:

- Autentisering/Auktorisering sker via Microsoft Entra.
- Azure API Management fungerar som en gateway och använder policies för att styra och hantera trafiken.
- Azure Monitor loggar alla förfrågningar för vidare analys.

#### Auktoriseringsflöde

Låt oss titta närmare på auktoriseringsflödet:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP auktoriseringsspecifikation

Läs mer om [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Distribuera Remote MCP Server till Azure

Låt oss se om vi kan distribuera exemplet vi nämnde tidigare:

1. Klona repot

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrera `Microsoft.App` resource provider.
    * Om du använder Azure CLI, kör `az provider register --namespace Microsoft.App --wait`.
    * Om du använder Azure PowerShell, kör `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Kör sedan `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` efter en stund för att kontrollera om registreringen är klar.

2. Kör detta [azd](https://aka.ms/azd)-kommando för att provisionera API Management-tjänsten, function app (med kod) och alla andra nödvändiga Azure-resurser

    ```shell
    azd up
    ```

    Detta kommando bör distribuera alla molnresurser på Azure

### Testa din server med MCP Inspector

1. I ett **nytt terminalfönster**, installera och kör MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Du bör se ett gränssnitt som liknar:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sv.png) 

1. CTRL-klicka för att ladda MCP Inspector webbappen från den URL som visas av appen (t.ex. http://127.0.0.1:6274/#resources)
1. Ställ in transporttypen till `SSE`
1. Ange URL:en till din körande API Management SSE-endpoint som visas efter `azd up` och **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lista verktyg**. Klicka på ett verktyg och **Run Tool**.  

Om alla steg fungerat bör du nu vara ansluten till MCP-servern och ha kunnat anropa ett verktyg.

## MCP-servrar för Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Denna uppsättning förråd är en snabbstartsmall för att bygga och distribuera anpassade fjärr-MCP-servrar (Model Context Protocol) med Azure Functions i Python, C# .NET eller Node/TypeScript.

Exemplen erbjuder en komplett lösning som låter utvecklare:

- Bygga och köra lokalt: Utveckla och felsöka en MCP-server på en lokal maskin
- Distribuera till Azure: Enkel distribution till molnet med ett enkelt azd up-kommando
- Ansluta från klienter: Anslut till MCP-servern från olika klienter, inklusive VS Codes Copilot agent-läge och MCP Inspector-verktyget

### Viktiga funktioner:

- Säkerhet från början: MCP-servern är säkrad med nycklar och HTTPS
- Autentiseringsalternativ: Stöd för OAuth med inbyggd autentisering och/eller API Management
- Nätverksisolering: Möjliggör nätverksisolering med Azure Virtual Networks (VNET)
- Serverlös arkitektur: Utnyttjar Azure Functions för skalbar, händelsestyrd exekvering
- Lokal utveckling: Omfattande stöd för lokal utveckling och felsökning
- Enkel distribution: Strömlinjeformad distributionsprocess till Azure

Förrådet innehåller alla nödvändiga konfigurationsfiler, källkod och infrastrukturbeskrivningar för att snabbt komma igång med en produktionsklar MCP-serverimplementation.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Exempelimplementation av MCP med Azure Functions i Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Exempelimplementation av MCP med Azure Functions i C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Exempelimplementation av MCP med Azure Functions i Node/TypeScript.

## Viktiga insikter

- MCP SDK:er erbjuder språksspecifika verktyg för att implementera robusta MCP-lösningar
- Felsöknings- och testprocessen är avgörande för pålitliga MCP-applikationer
- Återanvändbara promptmallar möjliggör konsekventa AI-interaktioner
- Väl utformade arbetsflöden kan orkestrera komplexa uppgifter med flera verktyg
- Implementering av MCP-lösningar kräver hänsyn till säkerhet, prestanda och felhantering

## Övning

Designa ett praktiskt MCP-arbetsflöde som löser ett verkligt problem inom ditt område:

1. Identifiera 3-4 verktyg som skulle vara användbara för att lösa detta problem
2. Skapa ett arbetsflödesdiagram som visar hur dessa verktyg samverkar
3. Implementera en grundläggande version av ett av verktygen med ditt föredragna språk
4. Skapa en promptmall som hjälper modellen att effektivt använda ditt verktyg

## Ytterligare resurser


---

Nästa: [Avancerade ämnen](../05-AdvancedTopics/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår till följd av användningen av denna översättning.