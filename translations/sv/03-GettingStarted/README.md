<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:34:53+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sv"
}
-->
## Kom igång  

Den här sektionen består av flera lektioner:

- **-1- Din första server**, i denna första lektion kommer du att lära dig hur du skapar din första server och inspekterar den med inspektörsverktyget, ett värdefullt sätt att testa och felsöka din server, [till lektionen](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, i denna lektion lär du dig hur du skriver en klient som kan ansluta till din server, [till lektionen](/03-GettingStarted/02-client/README.md)

- **-3- Klient med LLM**, ett ännu bättre sätt att skriva en klient är genom att lägga till en LLM så att den kan "förhandla" med din server om vad som ska göras, [till lektionen](/03-GettingStarted/03-llm-client/README.md)

- **-4- Använda en server GitHub Copilot Agent-läge i Visual Studio Code**. Här tittar vi på att köra vår MCP Server från Visual Studio Code, [till lektionen](/03-GettingStarted/04-vscode/README.md)

- **-5- Konsumera från en SSE (Server Sent Events)** SSE är en standard för server-till-klient streaming, som tillåter servrar att skicka realtidsuppdateringar till klienter över HTTP [till lektionen](/03-GettingStarted/05-sse-server/README.md)

- **-6- Använda AI Toolkit för VSCode** för att konsumera och testa dina MCP-klienter och servrar [till lektionen](/03-GettingStarted/06-aitk/README.md)

- **-7 Testning**. Här fokuserar vi särskilt på hur vi kan testa vår server och klient på olika sätt, [till lektionen](/03-GettingStarted/07-testing/README.md)

- **-8- Distribution**. Detta kapitel tar upp olika sätt att distribuera dina MCP-lösningar, [till lektionen](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) är ett öppet protokoll som standardiserar hur applikationer tillhandahåller kontext till LLM:er. Tänk på MCP som en USB-C-port för AI-applikationer – det ger ett standardiserat sätt att koppla AI-modeller till olika datakällor och verktyg.

## Lärandemål

I slutet av denna lektion kommer du att kunna:

- Sätta upp utvecklingsmiljöer för MCP i C#, Java, Python, TypeScript och JavaScript
- Bygga och distribuera grundläggande MCP-servrar med anpassade funktioner (resurser, prompts och verktyg)
- Skapa host-applikationer som ansluter till MCP-servrar
- Testa och felsöka MCP-implementationer
- Förstå vanliga installationsutmaningar och deras lösningar
- Ansluta dina MCP-implementationer till populära LLM-tjänster

## Sätta upp din MCP-miljö

Innan du börjar arbeta med MCP är det viktigt att förbereda din utvecklingsmiljö och förstå det grundläggande arbetsflödet. Denna sektion guidar dig genom de första installationsstegen för att säkerställa en smidig start med MCP.

### Förutsättningar

Innan du dyker in i MCP-utveckling, se till att du har:

- **Utvecklingsmiljö**: För ditt valda språk (C#, Java, Python, TypeScript eller JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm eller någon modern kodredigerare
- **Paketchefer**: NuGet, Maven/Gradle, pip eller npm/yarn
- **API-nycklar**: För eventuella AI-tjänster du planerar att använda i dina host-applikationer


### Officiella SDK:er

I kommande kapitel kommer du att se lösningar byggda med Python, TypeScript, Java och .NET. Här är alla officiellt stödda SDK:er.

MCP erbjuder officiella SDK:er för flera språk:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Underhålls i samarbete med Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Underhålls i samarbete med Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Den officiella TypeScript-implementationen
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Den officiella Python-implementationen
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Den officiella Kotlin-implementationen
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Underhålls i samarbete med Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Den officiella Rust-implementationen

## Viktiga insikter

- Att sätta upp en MCP-utvecklingsmiljö är enkelt med språksspecifika SDK:er
- Att bygga MCP-servrar innebär att skapa och registrera verktyg med tydliga scheman
- MCP-klienter ansluter till servrar och modeller för att utnyttja utökade funktioner
- Testning och felsökning är avgörande för pålitliga MCP-implementationer
- Distributionsalternativ sträcker sig från lokal utveckling till molnbaserade lösningar

## Övning

Vi har ett antal exempel som kompletterar övningarna du kommer att se i alla kapitel i denna sektion. Dessutom har varje kapitel egna övningar och uppgifter

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Ytterligare resurser

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Vad händer härnäst

Nästa: [Skapa din första MCP Server](/03-GettingStarted/01-first-server/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var vänlig notera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess ursprungsspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår från användningen av denna översättning.