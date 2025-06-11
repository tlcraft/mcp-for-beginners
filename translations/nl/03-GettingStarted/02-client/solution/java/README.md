<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:13:13+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "nl"
}
-->
# MCP Java Client - Calculator Demo

Dit project laat zien hoe je een Java-client maakt die verbinding maakt met en communiceert met een MCP (Model Context Protocol) server. In dit voorbeeld verbinden we met de rekenmachine-server uit Hoofdstuk 01 en voeren we verschillende wiskundige bewerkingen uit.

## Vereisten

Voordat je deze client start, moet je het volgende doen:

1. **Start de Calculator Server** uit Hoofdstuk 01:
   - Navigeer naar de directory van de rekenmachine-server: `03-GettingStarted/01-first-server/solution/java/`
   - Bouw en start de rekenmachine-server:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - De server moet draaien op `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` is een Java-applicatie die laat zien hoe je:
- Verbindt met een MCP-server via Server-Sent Events (SSE) transport
- Beschikbare tools van de server ophaalt
- Verschillende calculatorfuncties op afstand aanroept
- Reacties verwerkt en resultaten toont

## Hoe Het Werkt

De client gebruikt het Spring AI MCP-framework om:

1. **Verbinding te Maken**: Maakt een WebFlux SSE client transport aan om verbinding te maken met de rekenmachine-server
2. **Client Initialiseren**: Zet de MCP-client op en maakt de verbinding
3. **Tools Ontdekken**: Haalt alle beschikbare rekenmachinebewerkingen op
4. **Bewerkingen Uitvoeren**: Roept verschillende wiskundige functies aan met voorbeeldgegevens
5. **Resultaten Weergeven**: Toont de uitkomsten van elke berekening

## Projectstructuur

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Belangrijke Afhankelijkheden

Het project gebruikt de volgende belangrijke afhankelijkheden:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Deze afhankelijkheid biedt:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport voor webgebaseerde communicatie
- MCP protocol schema’s en request/response types

## Project Bouwen

Bouw het project met de Maven-wrapper:

```cmd
.\mvnw clean install
```

## Client Uitvoeren

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Opmerking**: Zorg ervoor dat de rekenmachine-server draait op `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Tools Lijst** - Toont alle beschikbare rekenmachinebewerkingen
3. **Berekeningen Uitvoeren**:
   - Optellen: 5 + 3 = 8
   - Aftrekken: 10 - 4 = 6
   - Vermenigvuldigen: 6 × 7 = 42
   - Delen: 20 ÷ 4 = 5
   - Macht: 2^8 = 256
   - Vierkantswortel: √16 = 4
   - Absolute Waarde: |-5.5| = 5.5
   - Help: Toont beschikbare bewerkingen

## Verwachte Output

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Opmerking**: Je kunt aan het einde waarschuwingen van Maven zien over actieve threads - dit is normaal bij reactieve applicaties en duidt niet op een fout.

## De Code Begrijpen

### 1. Transport Instellen
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Dit maakt een SSE (Server-Sent Events) transport aan dat verbinding maakt met de rekenmachine-server.

### 2. Client Aanmaken
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Maakt een synchrone MCP-client aan en initialiseert de verbinding.

### 3. Tools Aanroepen
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Roep de "add" tool aan met parameters a=5.0 en b=3.0.

## Problemen Oplossen

### Server Draait Niet
Als je verbindingsfouten krijgt, controleer dan of de rekenmachine-server uit Hoofdstuk 01 draait:
```
Error: Connection refused
```
**Oplossing**: Start eerst de rekenmachine-server.

### Poort Al In Gebruik
Als poort 8080 bezet is:
```
Error: Address already in use
```
**Oplossing**: Stop andere applicaties die poort 8080 gebruiken of wijzig de server om een andere poort te gebruiken.

### Build Fouten
Als je buildfouten tegenkomt:
```cmd
.\mvnw clean install -DskipTests
```

## Meer Informatie

- [Spring AI MCP Documentatie](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specificatie](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentatie](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.