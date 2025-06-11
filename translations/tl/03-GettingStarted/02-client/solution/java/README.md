<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:14:43+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "tl"
}
-->
# MCP Java Client - Calculator Demo

Ipinapakita ng proyektong ito kung paano gumawa ng Java client na kumokonekta at nakikipag-ugnayan sa isang MCP (Model Context Protocol) server. Sa halimbawang ito, kokonekta tayo sa calculator server mula sa Kabanata 01 at magsasagawa ng iba't ibang operasyon sa matematika.

## Prerequisites

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
- Ilista ang mga magagamit na tool mula sa server
- Tawagan ang iba't ibang calculator functions nang remote
- Pangasiwaan ang mga tugon at ipakita ang mga resulta

## Paano Ito Gumagana

Gumagamit ang client ng Spring AI MCP framework upang:

1. **Mag-establish ng Koneksyon**: Gumagawa ng WebFlux SSE client transport para kumonekta sa calculator server
2. **I-initialize ang Client**: Inaayos ang MCP client at nililikha ang koneksyon
3. **Hanapin ang mga Tool**: Ipinapakita ang lahat ng magagamit na operasyon ng calculator
4. **Isagawa ang mga Operasyon**: Tinatawagan ang iba't ibang mathematical functions gamit ang sample data
5. **Ipakita ang mga Resulta**: Ipinapakita ang resulta ng bawat kalkulasyon

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

Nagbibigay ang dependency na ito ng:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport para sa web-based na komunikasyon
- MCP protocol schemas at request/response types

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
2. **Ilista ang mga Tool** - Ipinapakita ang lahat ng magagamit na operasyon ng calculator
3. **Gawin ang mga Kalkulasyon**:
   - Addition: 5 + 3 = 8
   - Subtraction: 10 - 4 = 6
   - Multiplication: 6 × 7 = 42
   - Division: 20 ÷ 4 = 5
   - Power: 2^8 = 256
   - Square Root: √16 = 4
   - Absolute Value: |-5.5| = 5.5
   - Help: Ipinapakita ang mga magagamit na operasyon

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

**Note**: Maaaring makakita ka ng mga babala mula sa Maven tungkol sa mga natitirang thread sa dulo - normal ito para sa mga reactive applications at hindi nangangahulugang may error.

## Pag-unawa sa Code

### 1. Transport Setup
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

### 3. Pagtawag sa mga Tool
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Tinutawag ang "add" tool na may mga parameter na a=5.0 at b=3.0.

## Pag-troubleshoot

### Hindi Tumatakbong Server
Kung nakakaranas ng connection errors, siguraduhing tumatakbo ang calculator server mula sa Kabanata 01:
```
Error: Connection refused
```
**Solusyon**: Simulan muna ang calculator server.

### Nakagamit na ang Port
Kung abala ang port 8080:
```
Error: Address already in use
```
**Solusyon**: Itigil ang ibang aplikasyon na gumagamit ng port 8080 o baguhin ang server upang gumamit ng ibang port.

### Mga Error sa Build
Kung may build errors:
```cmd
.\mvnw clean install -DskipTests
```

## Dagdag na Kaalaman

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaintindihan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.