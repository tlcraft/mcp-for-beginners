<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:17:55+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "sl"
}
-->
# MCP Java Client - Calculator Demo

Ta proyekto na ipakitang paano gumawa ng Java client na kumokonekta at nakikipag-ugnayan sa MCP (Model Context Protocol) server. Sa halimbawa na ito, kakonekta tayo sa calculator server mula sa Kabanata 01 at gagawa ng iba't ibang matematikal na operasyon.

## Mga Kinakailangan

Bago patakbuhin ang client na ito, kailangan mong:

1. **Simulan ang Calculator Server** mula sa Kabanata 01:
   - Pumunta sa direktoryo ng calculator server: `03-GettingStarted/01-first-server/solution/java/`
   - I-build at patakbuhin ang calculator server:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Dapat tumatakbo ang server sa `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` ay isang Java application na nagpapakita kung paano:
- Kumonekta sa MCP server gamit ang Server-Sent Events (SSE) transport
- Ilista ang mga available na tool mula sa server
- Tawagan ang iba't ibang calculator functions nang remote
- Pangasiwaan ang mga sagot at ipakita ang mga resulta

## Paano Ito Gumagana

Gumagamit ang client ng Spring AI MCP framework para:

1. **Mag-establish ng Koneksyon**: Gumagawa ng WebFlux SSE client transport para kumonekta sa calculator server
2. **I-initialize ang Client**: Inaayos ang MCP client at itinatag ang koneksyon
3. **Mag-discover ng Tools**: Ipinapakita lahat ng available na calculator operations
4. **Magpatakbo ng Operasyon**: Tinatawag ang iba't ibang matematikal na function gamit ang sample data
5. **Ipakita ang Resulta**: Ipinapakita ang resulta ng bawat kalkulasyon

## Estruktura ng Proyekto

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

## Pangunahing Dependencies

Gumagamit ang proyekto ng mga sumusunod na pangunahing dependencies:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Ang dependency na ito ay nagbibigay ng:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport para sa web-based na komunikasyon
- MCP protocol schemas at mga uri ng request/response

## Pagbuo ng Proyekto

I-build ang proyekto gamit ang Maven wrapper:

```cmd
.\mvnw clean install
```

## Pagpapatakbo ng Client

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: Siguraduhing tumatakbo ang calculator server sa `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Ilista ang Tools** - Ipinapakita lahat ng available na calculator operations
3. **Gumawa ng Kalkulasyon**:
   - Addition: 5 + 3 = 8
   - Subtraction: 10 - 4 = 6
   - Multiplication: 6 × 7 = 42
   - Division: 20 ÷ 4 = 5
   - Power: 2^8 = 256
   - Square Root: √16 = 4
   - Absolute Value: |-5.5| = 5.5
   - Help: Ipinapakita ang mga available na operasyon

## Inaasahang Output

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

**Note**: Maaaring makakita ka ng mga warning mula sa Maven tungkol sa mga natitirang thread sa dulo - normal ito para sa mga reactive na aplikasyon at hindi ito nangangahulugan ng error.

## Pag-unawa sa Code

### 1. Setup ng Transport
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Gumagawa ito ng SSE (Server-Sent Events) transport na kumokonekta sa calculator server.

### 2. Paglikha ng Client
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Lumilikha ng synchronous MCP client at ini-initialize ang koneksyon.

### 3. Pagtawag sa Tools
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Tinatawag ang "add" tool gamit ang mga parameter na a=5.0 at b=3.0.

## Pag-troubleshoot

### Server Hindi Tumakbo
Kung makakakita ka ng mga error sa koneksyon, siguraduhing tumatakbo ang calculator server mula sa Kabanata 01:
```
Error: Connection refused
```
**Solusyon**: Simulan muna ang calculator server.

### Port Ginagamit Na
Kung ang port 8080 ay ginagamit na:
```
Error: Address already in use
```
**Solusyon**: Itigil ang ibang aplikasyon na gumagamit ng port 8080 o baguhin ang port ng server.

### Mga Error sa Build
Kung may mga error sa build:
```cmd
.\mvnw clean install -DskipTests
```

## Dagdag Pang Kaalaman

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku naj se šteje za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.