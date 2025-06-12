<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:15:11+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "sw"
}
-->
# MCP Java Client - Demo ya Calculator

Mradi huu unaonyesha jinsi ya kuunda mteja wa Java unaounganisha na kuwasiliana na seva ya MCP (Model Context Protocol). Katika mfano huu, tutajiunga na seva ya calculator kutoka Sura ya 01 na kufanya shughuli mbalimbali za kihisabati.

## Mahitaji Kabla ya Kuendesha

Kabla ya kuendesha mteja huyu, unahitaji:

1. **Anzisha Seva ya Calculator** kutoka Sura ya 01:
   - Nenda kwenye saraka ya seva ya calculator: `03-GettingStarted/01-first-server/solution/java/`
   - Jenga na endesha seva ya calculator:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Seva inapaswa kuwa inafanya kazi kwenye `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` ni programu ya Java inayonyesha jinsi ya:
- Kuungana na seva ya MCP kwa kutumia Server-Sent Events (SSE) kama usafirishaji
- Orodhesha zana zinazopatikana kutoka kwenye seva
- Piga simu kwa kazi mbalimbali za calculator kwa mbali
- Shughulikia majibu na onyesha matokeo

## Jinsi Inavyofanya Kazi

Mteja hutumia mfumo wa Spring AI MCP kufanya:

1. **Kuanzisha Muunganisho**: Huunda mteja wa WebFlux SSE kama usafirishaji kuungana na seva ya calculator
2. **Kuanzisha Mteja**: Huandaa mteja wa MCP na kuanzisha muunganisho
3. **Kubaini Zana**: Orodhesha shughuli zote zinazopatikana za calculator
4. **Kutekeleza Shughuli**: Piga simu kwa kazi mbalimbali za kihisabati kwa data ya mfano
5. **Onyesha Matokeo**: Onyesha matokeo ya kila hesabu

## Muundo wa Mradi

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

## Mategemeo Muhimu

Mradi hutumia mategemeo yafuatayo muhimu:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Mategemeo haya yanatoa:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - usafirishaji wa SSE kwa mawasiliano ya mtandao
- Mipangilio ya itifaki ya MCP na aina za maombi/jawabu

## Kujenga Mradi

Jenga mradi kwa kutumia Maven wrapper:

```cmd
.\mvnw clean install
```

## Kuendesha Mteja

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: Hakikisha seva ya calculator inafanya kazi kwenye `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Orodhesha Zana** - Onyesha shughuli zote zinazopatikana za calculator
3. **Fanya Hesabu**:
   - Jumlisha: 5 + 3 = 8
   - Toa: 10 - 4 = 6
   - Zidisha: 6 × 7 = 42
   - Gawanya: 20 ÷ 4 = 5
   - Nguvu: 2^8 = 256
   - Mzizi wa Mraba: √16 = 4
   - Thamani Kamili: |-5.5| = 5.5
   - Msaada: Onyesha shughuli zinazopatikana

## Matokeo Yanayotarajiwa

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

**Note**: Unaweza kuona onyo za Maven kuhusu thread zinazobaki mwishoni - hili ni kawaida kwa programu zinazotumia reactive na halimaanishi hitilafu.

## Kuelewa Msimbo

### 1. Kuandaa Usafirishaji
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Hii huunda usafirishaji wa SSE (Server-Sent Events) unaounganisha na seva ya calculator.

### 2. Kuunda Mteja
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Huunda mteja wa MCP wa synchronous na kuanzisha muunganisho.

### 3. Kupiga Simu kwa Zana
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Inapiga simu kwa zana ya "add" kwa vigezo a=5.0 na b=3.0.

## Kutatua Matatizo

### Seva Haifanyi Kazi
Kama unapata makosa ya muunganisho, hakikisha seva ya calculator kutoka Sura ya 01 inafanya kazi:
```
Error: Connection refused
```
**Solution**: Anzisha seva ya calculator kwanza.

### Bandari Tayari Imetumika
Kama bandari 8080 inatumika:
```
Error: Address already in use
```
**Solution**: Zima programu nyingine zinazotumia bandari 8080 au badilisha seva itumie bandari tofauti.

### Makosa ya Kujenga
Kama unakutana na makosa ya kujenga:
```cmd
.\mvnw clean install -DskipTests
```

## Jifunze Zaidi

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Kiarifu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za moja kwa moja zinaweza kuwa na makosa au upungufu wa usahihi. Hati asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na watu inashauriwa. Hatuna dhamana kwa maelezo potofu au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.