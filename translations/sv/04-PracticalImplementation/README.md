<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:53:17+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sv"
}
-->
# Praktisk Implementering

Praktisk implementering är där kraften i Model Context Protocol (MCP) blir påtaglig. Även om det är viktigt att förstå teorin och arkitekturen bakom MCP, kommer det verkliga värdet fram när du tillämpar dessa koncept för att bygga, testa och distribuera lösningar som löser verkliga problem. Detta kapitel överbryggar klyftan mellan konceptuell kunskap och praktisk utveckling, och guidar dig genom processen att ge liv åt MCP-baserade applikationer.

Oavsett om du utvecklar intelligenta assistenter, integrerar AI i affärsarbetsflöden eller bygger skräddarsydda verktyg för databehandling, erbjuder MCP en flexibel grund. Dess språkoberoende design och officiella SDK:er för populära programmeringsspråk gör det tillgängligt för en bred grupp av utvecklare. Genom att utnyttja dessa SDK:er kan du snabbt prototypa, iterera och skala dina lösningar över olika plattformar och miljöer.

I de följande avsnitten hittar du praktiska exempel, exempel på kod och distributionsstrategier som visar hur man implementerar MCP i C#, Java, TypeScript, JavaScript och Python. Du kommer också att lära dig hur man felsöker och testar dina MCP-servrar, hanterar API:er och distribuerar lösningar till molnet med Azure. Dessa praktiska resurser är utformade för att påskynda ditt lärande och hjälpa dig att tryggt bygga robusta, produktionsklara MCP-applikationer.

## Översikt

Denna lektion fokuserar på praktiska aspekter av MCP-implementering över flera programmeringsspråk. Vi kommer att utforska hur man använder MCP SDK:er i C#, Java, TypeScript, JavaScript och Python för att bygga robusta applikationer, felsöka och testa MCP-servrar och skapa återanvändbara resurser, uppmaningar och verktyg.

## Lärandemål

I slutet av denna lektion kommer du att kunna:
- Implementera MCP-lösningar med hjälp av officiella SDK:er i olika programmeringsspråk
- Systematiskt felsöka och testa MCP-servrar
- Skapa och använda serverfunktioner (Resurser, Uppmaningar och Verktyg)
- Designa effektiva MCP-arbetsflöden för komplexa uppgifter
- Optimera MCP-implementeringar för prestanda och tillförlitlighet

## Officiella SDK-resurser

Model Context Protocol erbjuder officiella SDK:er för flera språk:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Arbeta med MCP SDK:er

Detta avsnitt ger praktiska exempel på implementering av MCP över flera programmeringsspråk. Du kan hitta exempel på kod i `samples`-katalogen organiserad efter språk.

### Tillgängliga Exempel

Förrådet innehåller exempelimplementeringar på följande språk:

- C#
- Java
- TypeScript
- JavaScript
- Python

Varje exempel visar viktiga MCP-koncept och implementeringsmönster för det specifika språket och ekosystemet.

## Kärnserverfunktioner

MCP-servrar kan implementera vilken kombination som helst av dessa funktioner:

### Resurser
Resurser ger kontext och data för användaren eller AI-modellen att använda:
- Dokumentarkiv
- Kunskapsbaser
- Strukturerade datakällor
- Filsystem

### Uppmaningar
Uppmaningar är mallade meddelanden och arbetsflöden för användare:
- Fördefinierade samtalsmallar
- Vägledda interaktionsmönster
- Specialiserade dialogstrukturer

### Verktyg
Verktyg är funktioner för AI-modellen att utföra:
- Databehandlingsverktyg
- Externa API-integrationer
- Beräkningsmöjligheter
- Sökfunktionalitet

## Exempelimplementeringar: C#

Det officiella C# SDK-förrådet innehåller flera exempelimplementeringar som demonstrerar olika aspekter av MCP:

- **Grundläggande MCP-klient**: Enkelt exempel som visar hur man skapar en MCP-klient och anropar verktyg
- **Grundläggande MCP-server**: Minimal serverimplementering med grundläggande verktygsregistrering
- **Avancerad MCP-server**: Fullt utrustad server med verktygsregistrering, autentisering och felhantering
- **ASP.NET-integration**: Exempel som visar integration med ASP.NET Core
- **Verktygsimplementeringsmönster**: Olika mönster för att implementera verktyg med olika komplexitetsnivåer

MCP C# SDK är i förhandsvisning och API:er kan förändras. Vi kommer kontinuerligt att uppdatera denna blogg när SDK:n utvecklas.

### Nyckelfunktioner 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Bygga din [första MCP-server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

För kompletta C#-implementeringsexempel, besök det [officiella C# SDK-exempelförrådet](https://github.com/modelcontextprotocol/csharp-sdk)

## Exempelimplementering: Java-implementering

Java SDK erbjuder robusta MCP-implementeringsalternativ med företagsklassade funktioner.

### Nyckelfunktioner

- Integration med Spring Framework
- Stark typ säkerhet
- Stöd för reaktiv programmering
- Omfattande felhantering

För ett komplett Java-implementeringsexempel, se [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) i exempelkatalogen.

## Exempelimplementering: JavaScript-implementering

JavaScript SDK erbjuder ett lätt och flexibelt tillvägagångssätt för MCP-implementering.

### Nyckelfunktioner

- Stöd för Node.js och webbläsare
- Promise-baserad API
- Enkel integration med Express och andra ramverk
- WebSocket-stöd för strömning

För ett komplett JavaScript-implementeringsexempel, se [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) i exempelkatalogen.

## Exempelimplementering: Python-implementering

Python SDK erbjuder ett Pythoniskt tillvägagångssätt för MCP-implementering med utmärkta ML-ramverksintegrationer.

### Nyckelfunktioner

- Async/await-stöd med asyncio
- Integration med Flask och FastAPI
- Enkel verktygsregistrering
- Inbyggd integration med populära ML-bibliotek

För ett komplett Python-implementeringsexempel, se [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) i exempelkatalogen.

## API-hantering 

Azure API Management är ett bra svar på hur vi kan säkra MCP-servrar. Idén är att placera en Azure API Management-instans framför din MCP-server och låta den hantera funktioner som du troligen vill ha som:

- hastighetsbegränsning
- tokenhantering
- övervakning
- lastbalansering
- säkerhet

### Azure-exempel

Här är ett Azure-exempel som gör exakt det, dvs [skapa en MCP-server och säkra den med Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Se hur auktoriseringsflödet sker i bilden nedan:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

I föregående bild sker följande:

- Autentisering/Auktorisering sker med Microsoft Entra.
- Azure API Management fungerar som en gateway och använder policies för att styra och hantera trafik.
- Azure Monitor loggar alla förfrågningar för vidare analys.

#### Auktoriseringsflöde

Låt oss titta på auktoriseringsflödet mer i detalj:

![Sekvensdiagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP auktoriseringsspecifikation

Lär dig mer om [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Distribuera fjärr-MCP-server till Azure

Låt oss se om vi kan distribuera det exempel vi nämnde tidigare:

1. Klona repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrera `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` efter en stund för att kontrollera om registreringen är klar.

2. Kör detta [azd](https://aka.ms/azd) kommando för att tillhandahålla api-hanteringstjänsten, funktionsappen (med kod) och alla andra nödvändiga Azure-resurser

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

    ![Anslut till Node-inspektör](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.sv.png)

1. CTRL-klicka för att ladda MCP Inspector-webbappen från URL:en som visas av appen (t.ex. http://127.0.0.1:6274/#resources)
1. Ställ in transporttypen till `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` och **Anslut**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lista Verktyg**. Klicka på ett verktyg och **Kör Verktyg**.  

Om alla steg har fungerat bör du nu vara ansluten till MCP-servern och du har kunnat anropa ett verktyg.

## MCP-servrar för Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Denna uppsättning av förråd är en snabbstartsmall för att bygga och distribuera anpassade fjärr-MCP (Model Context Protocol) servrar med hjälp av Azure Functions med Python, C# .NET eller Node/TypeScript. 

Exemplen ger en komplett lösning som gör det möjligt för utvecklare att:

- Bygga och köra lokalt: Utveckla och felsöka en MCP-server på en lokal maskin
- Distribuera till Azure: Enkelt distribuera till molnet med ett enkelt azd up-kommando
- Ansluta från klienter: Ansluta till MCP-servern från olika klienter inklusive VS Codes Copilot-agentläge och MCP Inspector-verktyget

### Nyckelfunktioner:

- Säkerhet från början: MCP-servern är säkrad med hjälp av nycklar och HTTPS
- Autentiseringsalternativ: Stödjer OAuth med inbyggd autentisering och/eller API Management
- Nätverksisolering: Tillåter nätverksisolering med hjälp av Azure Virtual Networks (VNET)
- Serverlös arkitektur: Utnyttjar Azure Functions för skalbar, händelsedriven körning
- Lokal utveckling: Omfattande stöd för lokal utveckling och felsökning
- Enkel distribution: Strömlinjeformad distributionsprocess till Azure

Förrådet inkluderar alla nödvändiga konfigurationsfiler, källkod och infrastrukturdefinitioner för att snabbt komma igång med en produktionsklar MCP-serverimplementering.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Exempelimplementering av MCP med hjälp av Azure Functions med Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Exempelimplementering av MCP med hjälp av Azure Functions med C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Exempelimplementering av MCP med hjälp av Azure Functions med Node/TypeScript.

## Viktiga insikter

- MCP SDK:er ger språk-specifika verktyg för att implementera robusta MCP-lösningar
- Felsöknings- och testprocessen är avgörande för tillförlitliga MCP-applikationer
- Återanvändbara uppmaningsmallar möjliggör konsekventa AI-interaktioner
- Välutformade arbetsflöden kan orkestrera komplexa uppgifter med hjälp av flera verktyg
- Implementering av MCP-lösningar kräver övervägande av säkerhet, prestanda och felhantering

## Övning

Designa ett praktiskt MCP-arbetsflöde som adresserar ett verkligt problem inom ditt område:

1. Identifiera 3-4 verktyg som skulle vara användbara för att lösa detta problem
2. Skapa ett arbetsflödesdiagram som visar hur dessa verktyg interagerar
3. Implementera en grundläggande version av ett av verktygen med ditt föredragna språk
4. Skapa en uppmaningsmall som skulle hjälpa modellen att effektivt använda ditt verktyg

## Ytterligare resurser

---

Nästa: [Avancerade ämnen](../05-AdvancedTopics/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Vi strävar efter noggrannhet, men var medveten om att automatiska översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.