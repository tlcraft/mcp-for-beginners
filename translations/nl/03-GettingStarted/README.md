<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:12:04+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "nl"
}
-->
## Aan de slag

Deze sectie bestaat uit verschillende lessen:

- **-1- Je eerste server**, in deze eerste les leer je hoe je je eerste server maakt en deze inspecteert met de inspectietool, een waardevolle manier om je server te testen en debuggen, [naar de les](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, in deze les leer je hoe je een client schrijft die verbinding kan maken met je server, [naar de les](/03-GettingStarted/02-client/README.md)

- **-3- Client met LLM**, een nog betere manier om een client te schrijven is door een LLM toe te voegen zodat deze kan "onderhandelen" met je server over wat te doen, [naar de les](/03-GettingStarted/03-llm-client/README.md)

- **-4- Consumeren van een server GitHub Copilot Agent-modus in Visual Studio Code**. Hier kijken we naar het draaien van onze MCP Server vanuit Visual Studio Code, [naar de les](/03-GettingStarted/04-vscode/README.md)

- **-5- Consumeren van een SSE (Server Sent Events)** SEE is een standaard voor server-naar-client streaming, waardoor servers real-time updates naar clients kunnen pushen via HTTP [naar de les](/03-GettingStarted/05-sse-server/README.md)

- **-6- Gebruik maken van AI Toolkit voor VSCode** om je MCP Clients en Servers te consumeren en testen [naar de les](/03-GettingStarted/06-aitk/README.md)

- **-7 Testen**. Hier zullen we ons vooral richten op hoe we onze server en client op verschillende manieren kunnen testen, [naar de les](/03-GettingStarted/07-testing/README.md)

- **-8- Implementatie**. Dit hoofdstuk bekijkt verschillende manieren om je MCP-oplossingen te implementeren, [naar de les](/03-GettingStarted/08-deployment/README.md)

Het Model Context Protocol (MCP) is een open protocol dat standaardiseert hoe applicaties context bieden aan LLM's. Denk aan MCP als een USB-C poort voor AI-toepassingen - het biedt een gestandaardiseerde manier om AI-modellen te verbinden met verschillende gegevensbronnen en tools.

## Leerdoelen

Aan het einde van deze les kun je:

- Ontwikkelomgevingen voor MCP opzetten in C#, Java, Python, TypeScript en JavaScript
- Basis MCP-servers bouwen en implementeren met aangepaste functies (resources, prompts en tools)
- Hostapplicaties maken die verbinding maken met MCP-servers
- MCP-implementaties testen en debuggen
- Veelvoorkomende opzetuitdagingen en hun oplossingen begrijpen
- Je MCP-implementaties verbinden met populaire LLM-diensten

## Je MCP-omgeving instellen

Voordat je begint met MCP, is het belangrijk om je ontwikkelomgeving voor te bereiden en de basisworkflow te begrijpen. Deze sectie leidt je door de eerste instelstappen om een soepele start met MCP te garanderen.

### Vereisten

Voordat je aan MCP-ontwikkeling begint, zorg ervoor dat je beschikt over:

- **Ontwikkelomgeving**: Voor je gekozen taal (C#, Java, Python, TypeScript of JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm of een moderne code-editor
- **Pakketmanagers**: NuGet, Maven/Gradle, pip of npm/yarn
- **API-sleutels**: Voor eventuele AI-diensten die je van plan bent te gebruiken in je hostapplicaties

### Officiële SDK's

In de komende hoofdstukken zie je oplossingen gebouwd met Python, TypeScript, Java en .NET. Hier zijn alle officieel ondersteunde SDK's.

MCP biedt officiële SDK's voor meerdere talen:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Onderhouden in samenwerking met Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Onderhouden in samenwerking met Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - De officiële TypeScript-implementatie
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - De officiële Python-implementatie
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - De officiële Kotlin-implementatie
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Onderhouden in samenwerking met Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - De officiële Rust-implementatie

## Belangrijke punten

- Het opzetten van een MCP-ontwikkelomgeving is eenvoudig met taalspecifieke SDK's
- Het bouwen van MCP-servers omvat het creëren en registreren van tools met duidelijke schema's
- MCP-clients verbinden met servers en modellen om uitgebreide mogelijkheden te benutten
- Testen en debuggen zijn essentieel voor betrouwbare MCP-implementaties
- Implementatie-opties variëren van lokale ontwikkeling tot cloudgebaseerde oplossingen

## Oefenen

We hebben een reeks voorbeelden die de oefeningen aanvullen die je in alle hoofdstukken in deze sectie zult zien. Bovendien heeft elk hoofdstuk ook zijn eigen oefeningen en opdrachten

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Aanvullende bronnen

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Wat volgt

Volgende: [Je eerste MCP Server maken](/03-GettingStarted/01-first-server/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in zijn oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.