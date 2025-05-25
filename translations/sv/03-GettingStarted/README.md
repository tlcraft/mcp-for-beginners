<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:10:40+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sv"
}
-->
## Komma igång  

Detta avsnitt består av flera lektioner:

- **-1- Din första server**, i denna första lektion kommer du att lära dig hur man skapar sin första server och inspekterar den med inspektionsverktyget, ett värdefullt sätt att testa och felsöka din server, [till lektionen](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, i denna lektion kommer du att lära dig hur man skriver en klient som kan ansluta till din server, [till lektionen](/03-GettingStarted/02-client/README.md)

- **-3- Klient med LLM**, ett ännu bättre sätt att skriva en klient är att lägga till en LLM så att den kan "förhandla" med din server om vad som ska göras, [till lektionen](/03-GettingStarted/03-llm-client/README.md)

- **-4- Använda en server GitHub Copilot Agent-läge i Visual Studio Code**. Här tittar vi på att köra vår MCP-server från Visual Studio Code, [till lektionen](/03-GettingStarted/04-vscode/README.md)

- **-5- Använda från en SSE (Server Sent Events)** SEE är en standard för server-till-klient-strömning, vilket tillåter servrar att skicka realtidsuppdateringar till klienter över HTTP [till lektionen](/03-GettingStarted/05-sse-server/README.md)

- **-6- Använda AI Toolkit för VSCode** för att konsumera och testa dina MCP-klienter och servrar [till lektionen](/03-GettingStarted/06-aitk/README.md)

- **-7 Testning**. Här kommer vi särskilt att fokusera på hur vi kan testa vår server och klient på olika sätt, [till lektionen](/03-GettingStarted/07-testing/README.md)

- **-8- Distribution**. Detta kapitel kommer att titta på olika sätt att distribuera dina MCP-lösningar, [till lektionen](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) är ett öppet protokoll som standardiserar hur applikationer ger kontext till LLMs. Tänk på MCP som en USB-C-port för AI-applikationer - det ger ett standardiserat sätt att ansluta AI-modeller till olika datakällor och verktyg.

## Inlärningsmål

I slutet av denna lektion kommer du att kunna:

- Ställa in utvecklingsmiljöer för MCP i C#, Java, Python, TypeScript och JavaScript
- Bygga och distribuera grundläggande MCP-servrar med anpassade funktioner (resurser, prompts och verktyg)
- Skapa värdapplikationer som ansluter till MCP-servrar
- Testa och felsöka MCP-implementeringar
- Förstå vanliga installationsutmaningar och deras lösningar
- Ansluta dina MCP-implementeringar till populära LLM-tjänster

## Ställa in din MCP-miljö

Innan du börjar arbeta med MCP är det viktigt att förbereda din utvecklingsmiljö och förstå det grundläggande arbetsflödet. Detta avsnitt kommer att guida dig genom de inledande installationsstegen för att säkerställa en smidig start med MCP.

### Förutsättningar

Innan du dyker in i MCP-utveckling, se till att du har:

- **Utvecklingsmiljö**: För ditt valda språk (C#, Java, Python, TypeScript eller JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm eller någon modern kodredigerare
- **Paketchefer**: NuGet, Maven/Gradle, pip eller npm/yarn
- **API-nycklar**: För alla AI-tjänster du planerar att använda i dina värdapplikationer


### Officiella SDKs

I de kommande kapitlen kommer du att se lösningar byggda med Python, TypeScript, Java och .NET. Här är alla de officiellt stödda SDKs.

MCP tillhandahåller officiella SDKs för flera språk:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Underhålls i samarbete med Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Underhålls i samarbete med Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den officiella TypeScript-implementeringen
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den officiella Python-implementeringen
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den officiella Kotlin-implementeringen
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Underhålls i samarbete med Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den officiella Rust-implementeringen

## Viktiga insikter

- Att ställa in en MCP-utvecklingsmiljö är enkelt med språksspecifika SDKs
- Att bygga MCP-servrar innebär att skapa och registrera verktyg med tydliga scheman
- MCP-klienter ansluter till servrar och modeller för att utnyttja utökade funktioner
- Testning och felsökning är avgörande för pålitliga MCP-implementeringar
- Distributionsalternativen sträcker sig från lokal utveckling till molnbaserade lösningar

## Övning

Vi har en uppsättning exempel som kompletterar övningarna du kommer att se i alla kapitel i detta avsnitt. Dessutom har varje kapitel även sina egna övningar och uppgifter

- [Java Kalkylator](./samples/java/calculator/README.md)
- [.Net Kalkylator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkylator](./samples/javascript/README.md)
- [TypeScript Kalkylator](./samples/typescript/README.md)
- [Python Kalkylator](../../../03-GettingStarted/samples/python)

## Ytterligare resurser

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Vad händer härnäst

Nästa: [Skapa din första MCP-server](/03-GettingStarted/01-first-server/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Vi strävar efter noggrannhet, men var medveten om att automatiska översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess ursprungsspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.