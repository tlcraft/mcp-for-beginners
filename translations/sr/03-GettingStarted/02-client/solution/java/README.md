<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:17:18+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "sr"
}
-->
# MCP Java Client - Calculator Demo

Ovaj projekat prikazuje kako napraviti Java klijenta koji se povezuje i komunicira sa MCP (Model Context Protocol) serverom. U ovom primeru povezaćemo se na kalkulator server iz Poglavlja 01 i izvršiti različite matematičke operacije.

## Preduslovi

Pre nego što pokrenete ovog klijenta, potrebno je da:

1. **Pokrenete Calculator Server** iz Poglavlja 01:
   - Idite u direktorijum kalkulator servera: `03-GettingStarted/01-first-server/solution/java/`
   - Izgradite i pokrenite kalkulator server:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Server bi trebalo da radi na `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` je Java aplikacija koja pokazuje kako da:
- Povežete se na MCP server koristeći Server-Sent Events (SSE) transport
- Prikazujete dostupne alate sa servera
- Pozivate različite kalkulatorske funkcije na daljinu
- Obradite odgovore i prikažete rezultate

## Kako Radi

Klijent koristi Spring AI MCP framework da:

1. **Uspostavi Vezu**: Kreira WebFlux SSE klijent transport za povezivanje sa kalkulator serverom
2. **Inicijalizuje Klijenta**: Podešava MCP klijenta i uspostavlja vezu
3. **Otkrije Alate**: Prikazuje sve dostupne kalkulatorske operacije
4. **Izvrši Operacije**: Poziva različite matematičke funkcije sa primerima podataka
5. **Prikazuje Rezultate**: Prikazuje rezultate svake kalkulacije

## Struktura Projekta

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

## Ključne Zavisnosti

Projekat koristi sledeće ključne zavisnosti:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Ova zavisnost obezbeđuje:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport za komunikaciju preko weba
- MCP protokol šeme i tipove zahteva/odgovora

## Izgradnja Projekta

Izgradite projekat koristeći Maven wrapper:

```cmd
.\mvnw clean install
```

## Pokretanje Klijenta

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: Proverite da li kalkulator server radi na `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Prikaz Alata** - Prikazuje sve dostupne kalkulatorske operacije
3. **Izvrši Kalkulacije**:
   - Sabiranje: 5 + 3 = 8
   - Oduzimanje: 10 - 4 = 6
   - Množenje: 6 × 7 = 42
   - Deljenje: 20 ÷ 4 = 5
   - Stepenovanje: 2^8 = 256
   - Kvadratni koren: √16 = 4
   - Apsolutna vrednost: |-5.5| = 5.5
   - Pomoć: Prikazuje dostupne operacije

## Očekivani Rezultat

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

**Note**: Možda ćete videti Maven upozorenja o preostalih nitima na kraju - to je normalno za reaktivne aplikacije i ne ukazuje na grešku.

## Razumevanje Koda

### 1. Podešavanje Transporta
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Ovo kreira SSE (Server-Sent Events) transport koji se povezuje na kalkulator server.

### 2. Kreiranje Klijenta
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Kreira sinhroni MCP klijent i inicijalizuje vezu.

### 3. Pozivanje Alata
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Poziva "add" alat sa parametrima a=5.0 i b=3.0.

## Rešavanje Problema

### Server Ne Radi
Ako dobijete greške u vezi, proverite da li kalkulator server iz Poglavlja 01 radi:
```
Error: Connection refused
```
**Rešenje**: Prvo pokrenite kalkulator server.

### Port Je Zauzet
Ako je port 8080 zauzet:
```
Error: Address already in use
```
**Rešenje**: Zaustavite druge aplikacije koje koriste port 8080 ili promenite port servera.

### Greške Pri Izgradnji
Ako naiđete na greške pri izgradnji:
```cmd
.\mvnw clean install -DskipTests
```

## Saznajte Više

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем АИ услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења која произилазе из коришћења овог превода.