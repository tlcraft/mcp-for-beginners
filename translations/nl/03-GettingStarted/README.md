<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T00:18:01+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "nl"
}
-->
## Aan de slag  

Deze sectie bestaat uit meerdere lessen:

- **1 Je eerste server**, in deze eerste les leer je hoe je je eerste server maakt en deze inspecteert met de inspector tool, een waardevolle manier om je server te testen en te debuggen, [naar de les](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, in deze les leer je hoe je een client schrijft die verbinding kan maken met je server, [naar de les](/03-GettingStarted/02-client/README.md)

- **3 Client met LLM**, een nog betere manier om een client te schrijven is door er een LLM aan toe te voegen zodat deze met je server kan "onderhandelen" over wat er gedaan moet worden, [naar de les](/03-GettingStarted/03-llm-client/README.md)

- **4 Gebruik van een server GitHub Copilot Agent modus in Visual Studio Code**. Hier bekijken we het draaien van onze MCP Server vanuit Visual Studio Code, [naar de les](/03-GettingStarted/04-vscode/README.md)

- **5 Gebruik maken van een SSE (Server Sent Events)** SSE is een standaard voor server-naar-client streaming, waarmee servers real-time updates naar clients kunnen pushen via HTTP [naar de les](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming met MCP (Streamable HTTP)**. Leer over moderne HTTP streaming, voortgangsnotificaties, en hoe je schaalbare, real-time MCP servers en clients implementeert met Streamable HTTP. [naar de les](/03-GettingStarted/06-http-streaming/README.md)

- **7 Gebruik van AI Toolkit voor VSCode** om je MCP Clients en Servers te gebruiken en te testen [naar de les](/03-GettingStarted/07-aitk/README.md)

- **8 Testen**. Hier richten we ons vooral op hoe we onze server en client op verschillende manieren kunnen testen, [naar de les](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**. Dit hoofdstuk behandelt verschillende manieren om je MCP-oplossingen te deployen, [naar de les](/03-GettingStarted/09-deployment/README.md)


Het Model Context Protocol (MCP) is een open protocol dat standaardiseert hoe applicaties context aan LLMs aanleveren. Zie MCP als een USB-C poort voor AI-applicaties - het biedt een gestandaardiseerde manier om AI-modellen te verbinden met verschillende databronnen en tools.

## Leerdoelen

Aan het einde van deze les kun je:

- Ontwikkelomgevingen opzetten voor MCP in C#, Java, Python, TypeScript en JavaScript
- Basis MCP servers bouwen en deployen met aangepaste functies (resources, prompts en tools)
- Hostapplicaties maken die verbinding maken met MCP servers
- MCP-implementaties testen en debuggen
- Veelvoorkomende opstartproblemen en hun oplossingen begrijpen
- Je MCP-implementaties koppelen aan populaire LLM-diensten

## Je MCP-omgeving instellen

Voordat je begint met MCP is het belangrijk om je ontwikkelomgeving voor te bereiden en de basisworkflow te begrijpen. Deze sectie begeleidt je door de eerste stappen om een soepele start met MCP te garanderen.

### Vereisten

Voordat je aan MCP-ontwikkeling begint, zorg dat je hebt:

- **Ontwikkelomgeving**: Voor je gekozen programmeertaal (C#, Java, Python, TypeScript of JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm of een andere moderne code-editor
- **Package Managers**: NuGet, Maven/Gradle, pip of npm/yarn
- **API-sleutels**: Voor eventuele AI-diensten die je in je hostapplicaties wilt gebruiken


### Officiële SDK's

In de komende hoofdstukken zie je oplossingen gebouwd met Python, TypeScript, Java en .NET. Hier vind je alle officieel ondersteunde SDK’s.

MCP biedt officiële SDK’s voor meerdere talen:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Onderhouden in samenwerking met Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Onderhouden in samenwerking met Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - De officiële TypeScript-implementatie
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - De officiële Python-implementatie
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - De officiële Kotlin-implementatie
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Onderhouden in samenwerking met Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - De officiële Rust-implementatie

## Belangrijkste punten

- Het opzetten van een MCP-ontwikkelomgeving is eenvoudig met taal-specifieke SDK’s
- Het bouwen van MCP-servers omvat het creëren en registreren van tools met duidelijke schema’s
- MCP-clients maken verbinding met servers en modellen om uitgebreide mogelijkheden te benutten
- Testen en debuggen zijn essentieel voor betrouwbare MCP-implementaties
- Deployment-opties variëren van lokale ontwikkeling tot cloud-gebaseerde oplossingen

## Oefenen

We hebben een set voorbeelden die de oefeningen in alle hoofdstukken van deze sectie aanvullen. Daarnaast heeft elk hoofdstuk ook zijn eigen oefeningen en opdrachten

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Extra bronnen

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Wat nu?

Volgende: [Je eerste MCP Server maken](/03-GettingStarted/01-first-server/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.