<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5331ffd328a54b90f76706c52b673e27",
  "translation_date": "2025-05-17T08:38:54+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sv"
}
-->
# Komma igång med MCP

Välkommen till dina första steg med Model Context Protocol (MCP)! Oavsett om du är ny på MCP eller vill fördjupa din förståelse, kommer den här guiden att leda dig genom den grundläggande installationen och utvecklingsprocessen. Du kommer att upptäcka hur MCP möjliggör sömlös integration mellan AI-modeller och applikationer, och lära dig hur du snabbt får din miljö redo för att bygga och testa MCP-drivna lösningar.

> TLDR; Om du bygger AI-appar vet du att du kan lägga till verktyg och andra resurser till din LLM (large language model) för att göra LLM mer kunnig. Men om du placerar dessa verktyg och resurser på en server kan appen och serverns kapabiliteter användas av vilken klient som helst med/utan en LLM.

## Översikt

Denna lektion ger praktisk vägledning om hur man sätter upp MCP-miljöer och bygger dina första MCP-applikationer. Du kommer att lära dig hur man sätter upp nödvändiga verktyg och ramverk, bygger grundläggande MCP-servrar, skapar värdapplikationer och testar dina implementationer.

Model Context Protocol (MCP) är ett öppet protokoll som standardiserar hur applikationer tillhandahåller kontext till LLMs. Tänk på MCP som en USB-C-port för AI-applikationer - det ger ett standardiserat sätt att koppla AI-modeller till olika datakällor och verktyg.

## Lärandemål

I slutet av denna lektion kommer du att kunna:

- Sätta upp utvecklingsmiljöer för MCP i C#, Java, Python, TypeScript och JavaScript
- Bygga och distribuera grundläggande MCP-servrar med anpassade funktioner (resurser, uppmaningar och verktyg)
- Skapa värdapplikationer som ansluter till MCP-servrar
- Testa och felsöka MCP-implementationer

## Sätta upp din MCP-miljö

Innan du börjar arbeta med MCP är det viktigt att förbereda din utvecklingsmiljö och förstå det grundläggande arbetsflödet. Denna sektion kommer att guida dig genom de inledande stegen för att säkerställa en smidig start med MCP.

### Förutsättningar

Innan du dyker in i MCP-utveckling, se till att du har:

- **Utvecklingsmiljö**: För ditt valda språk (C#, Java, Python, TypeScript eller JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm eller någon modern kodredigerare
- **Paketshanterare**: NuGet, Maven/Gradle, pip eller npm/yarn
- **API-nycklar**: För eventuella AI-tjänster du planerar att använda i dina värdapplikationer

## Grundläggande MCP-serverstruktur

En MCP-server inkluderar vanligtvis:

- **Serverkonfiguration**: Ställ in port, autentisering och andra inställningar
- **Resurser**: Data och kontext som görs tillgänglig för LLMs
- **Verktyg**: Funktionalitet som modeller kan anropa
- **Uppmaningar**: Mallar för att generera eller strukturera text

Här är ett förenklat exempel i TypeScript:

```typescript
import { Server, Tool, Resource } from "@modelcontextprotocol/typescript-server-sdk";

// Create a new MCP server
const server = new Server({
  port: 3000,
  name: "Example MCP Server",
  version: "1.0.0"
});

// Register a tool
server.registerTool({
  name: "calculator",
  description: "Performs basic calculations",
  parameters: {
    expression: {
      type: "string",
      description: "The math expression to evaluate"
    }
  },
  handler: async (params) => {
    const result = eval(params.expression);
    return { result };
  }
});

// Start the server
server.start();
```

I den föregående koden:

- Importerar vi de nödvändiga klasserna från MCP TypeScript SDK.
- Skapar och konfigurerar vi en ny MCP-serverinstans.
- Registrerar vi ett anpassat verktyg (`calculator`) med en hanteringsfunktion.
- Startar vi servern för att lyssna på inkommande MCP-förfrågningar.

## Testning och Felsökning

Innan du börjar testa din MCP-server är det viktigt att förstå de tillgängliga verktygen och bästa praxis för felsökning. Effektiv testning säkerställer att din server beter sig som förväntat och hjälper dig snabbt identifiera och lösa problem. Följande sektion beskriver rekommenderade metoder för att validera din MCP-implementation.

MCP tillhandahåller verktyg för att hjälpa dig testa och felsöka dina servrar:

- **Inspector tool**, detta grafiska gränssnitt låter dig ansluta till din server och testa dina verktyg, uppmaningar och resurser.
- **curl**, du kan också ansluta till din server med ett kommandoradsverktyg som curl eller andra klienter som kan skapa och köra HTTP-kommandon.

### Använda MCP Inspector

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) är ett visuellt testverktyg som hjälper dig:

1. **Upptäck serverkapabiliteter**: Upptäck automatiskt tillgängliga resurser, verktyg och uppmaningar
2. **Testa verktygsutförande**: Prova olika parametrar och se svar i realtid
3. **Visa servermetadata**: Undersök serverinformation, scheman och konfigurationer

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

När du kör ovanstående kommandon kommer MCP Inspector att starta ett lokalt webbgränssnitt i din webbläsare. Du kan förvänta dig att se en instrumentpanel som visar dina registrerade MCP-servrar, deras tillgängliga verktyg, resurser och uppmaningar. Gränssnittet låter dig interaktivt testa verktygsutförande, inspektera servermetadata och visa realtidsvar, vilket gör det enklare att validera och felsöka dina MCP-serverimplementationer.

Här är en skärmbild av hur det kan se ut:

![](../../../../translated_images/connected.b61e5263011747a56970cf2f8565eb60b9702918d0525ecff66a6d1a93626758.sv.png)

## Vanliga installationsproblem och lösningar

| Problem | Möjlig lösning |
|---------|----------------|
| Anslutning nekad | Kontrollera om servern körs och porten är korrekt |
| Verktygsutförandefel | Granska parametervalidering och felhantering |
| Autentiseringsfel | Kontrollera API-nycklar och behörigheter |
| Schematvalideringsfel | Säkerställ att parametrar matchar det definierade schemat |
| Servern startar inte | Kontrollera portkonflikter eller saknade beroenden |
| CORS-fel | Konfigurera korrekta CORS-rubriker för cross-origin-förfrågningar |
| Autentiseringsproblem | Verifiera token giltighet och behörigheter |

## Lokal utveckling

För lokal utveckling och testning kan du köra MCP-servrar direkt på din maskin:

1. **Starta serverprocessen**: Kör din MCP-serverapplikation
2. **Konfigurera nätverk**: Se till att servern är tillgänglig på den förväntade porten
3. **Anslut klienter**: Använd lokala anslutnings-URL:er som `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## Bygga din första MCP-server

Vi har täckt [Kärnkoncept](/01-CoreConcepts/README.md) i en tidigare lektion, nu är det dags att använda den kunskapen.

### Vad en server kan göra

Innan vi börjar skriva kod, låt oss bara påminna oss om vad en server kan göra:

En MCP-server kan till exempel:

- Åtkomst till lokala filer och databaser
- Ansluta till fjärr-API:er
- Utföra beräkningar
- Integrera med andra verktyg och tjänster
- Tillhandahålla ett användargränssnitt för interaktion

Bra, nu när vi vet vad vi kan göra med den, låt oss börja koda.

## Övning: Skapa en server

För att skapa en server behöver du följa dessa steg:

- Installera MCP SDK.
- Skapa ett projekt och sätt upp projektstrukturen.
- Skriv serverkoden.
- Testa servern.

### -1- Installera SDK

Detta skiljer sig lite beroende på ditt valda runtime, så välj en av runtime-alternativen nedan:

Generativ AI kan generera text, bilder och till och med kod.
Du är tränad på data upp till oktober 2023.

### -2- Skapa projekt

Nu när du har installerat ditt SDK, låt oss skapa ett projekt:

### -3- Skapa projektfiler

### -4- Skapa serverkod

### -5- Lägg till ett verktyg och en resurs

Lägg till ett verktyg och en resurs genom att lägga till följande kod:

### -6- Slutlig kod

Låt oss lägga till den sista koden vi behöver så att servern kan starta:

### -7- Testa servern

Starta servern med följande kommando:

### -8- Kör med hjälp av inspektören

Inspektören är ett utmärkt verktyg som kan starta upp din server och låter dig interagera med den så att du kan testa att den fungerar. Låt oss starta den:

> [!NOTE]
> det kan se annorlunda ut i "kommandofältet" eftersom det innehåller kommandot för att köra en server med din specifika runtime

Du bör se följande användargränssnitt:

![Connect](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.sv.png)

1. Anslut till servern genom att välja Anslut-knappen 
   När du ansluter till servern bör du nu se följande:

   ![Connected](../../../../translated_images/connected.b61e5263011747a56970cf2f8565eb60b9702918d0525ecff66a6d1a93626758.sv.png)

1. Välj "Tools" och "listTools", du bör se "Add" dyka upp, välj "Add" och fyll i parametervärdena.

   Du bör se följande svar, dvs ett resultat från "add"-verktyget:

   ![Result of running add](../../../../translated_images/ran-tool.6756b7433b1ea47ad8916aeb0ac050a48ecd9b0b29c6c3046f372952f47714e1.sv.png)

Grattis, du har lyckats skapa och köra din första server!

### Officiella SDKs

MCP tillhandahåller officiella SDKs för flera språk:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Underhålls i samarbete med Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Underhålls i samarbete med Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den officiella TypeScript-implementationen
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den officiella Python-implementationen
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den officiella Kotlin-implementationen
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Underhålls i samarbete med Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den officiella Rust-implementationen

## Viktiga insikter

- Att sätta upp en MCP-utvecklingsmiljö är enkelt med språk-specifika SDKs
- Att bygga MCP-servrar innebär att skapa och registrera verktyg med tydliga scheman
- Testning och felsökning är avgörande för tillförlitliga MCP-implementationer

## Exempel

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Uppgift

Skapa en enkel MCP-server med ett verktyg du väljer:
1. Implementera verktyget i ditt föredragna språk (.NET, Java, Python eller JavaScript).
2. Definiera inmatningsparametrar och returvärden.
3. Kör inspektörverktyget för att säkerställa att servern fungerar som avsett.
4. Testa implementationen med olika inmatningar.

## Lösning

[Lösning](./solution/README.md)

## Ytterligare resurser

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Vad händer härnäst

Nästa: [Komma igång med MCP-klienter](/03-GettingStarted/02-client/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var medveten om att automatiska översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på sitt modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi är inte ansvariga för eventuella missförstånd eller feltolkningar som uppstår vid användningen av denna översättning.