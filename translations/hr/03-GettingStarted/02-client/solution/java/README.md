<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:17:39+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "hr"
}
-->
# MCP Java Client - Calculator Demo

Ovaj projekt pokazuje kako kreirati Java klijenta koji se povezuje i komunicira s MCP (Model Context Protocol) serverom. U ovom primjeru povezujemo se na kalkulator server iz Poglavlja 01 i izvodimo različite matematičke operacije.

## Preduvjeti

Prije pokretanja ovog klijenta, potrebno je:

1. **Pokrenuti Calculator Server** iz Poglavlja 01:
   - Otvorite direktorij kalkulator servera: `03-GettingStarted/01-first-server/solution/java/`
   - Izgradite i pokrenite kalkulator server:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Server bi trebao biti dostupan na `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` je Java aplikacija koja pokazuje kako:
- Povezati se na MCP server koristeći Server-Sent Events (SSE) transport
- Nabrojati dostupne alate na serveru
- Daljinski pozvati različite kalkulatorske funkcije
- Obraditi odgovore i prikazati rezultate

## Kako radi

Klijent koristi Spring AI MCP framework da:

1. **Uspostavi vezu**: Kreira WebFlux SSE klijentski transport za povezivanje na kalkulator server
2. **Inicijalizira klijenta**: Postavlja MCP klijenta i uspostavlja vezu
3. **Otkrije alate**: Nabroji sve dostupne kalkulatorske operacije
4. **Izvrši operacije**: Pozove različite matematičke funkcije s primjerima podataka
5. **Prikaže rezultate**: Prikazuje rezultate svake kalkulacije

## Struktura projekta

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

## Ključne ovisnosti

Projekt koristi sljedeće ključne ovisnosti:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Ova ovisnost pruža:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport za web komunikaciju
- MCP protokol sheme i tipove zahtjeva/odgovora

## Izgradnja projekta

Izgradite projekt koristeći Maven wrapper:

```cmd
.\mvnw clean install
```

## Pokretanje klijenta

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: Provjerite da je kalkulator server pokrenut na `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Nabrojite alate** - Prikazuje sve dostupne kalkulatorske operacije
3. **Izvršite izračune**:
   - Zbrajanje: 5 + 3 = 8
   - Oduzimanje: 10 - 4 = 6
   - Množenje: 6 × 7 = 42
   - Dijeljenje: 20 ÷ 4 = 5
   - Stepenovanje: 2^8 = 256
   - Kvadratni korijen: √16 = 4
   - Apsolutna vrijednost: |-5.5| = 5.5
   - Pomoć: Prikazuje dostupne operacije

## Očekivani izlaz

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

**Note**: Na kraju se mogu pojaviti Maven upozorenja o aktivnim threadovima – to je normalno za reaktivne aplikacije i ne ukazuje na grešku.

## Razumijevanje koda

### 1. Postavljanje transporta
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Ovim se kreira SSE (Server-Sent Events) transport koji se povezuje na kalkulator server.

### 2. Kreiranje klijenta
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Kreira se sinkroni MCP klijent i inicijalizira veza.

### 3. Pozivanje alata
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Poziva se alat "add" s parametrima a=5.0 i b=3.0.

## Rješavanje problema

### Server nije pokrenut
Ako dobijete greške pri povezivanju, provjerite je li kalkulator server iz Poglavlja 01 pokrenut:
```
Error: Connection refused
```
**Rješenje**: Prvo pokrenite kalkulator server.

### Port je zauzet
Ako je port 8080 zauzet:
```
Error: Address already in use
```
**Rješenje**: Zaustavite druge aplikacije koje koriste port 8080 ili promijenite port servera.

### Greške pri izgradnji
Ako naiđete na greške pri izgradnji:
```cmd
.\mvnw clean install -DskipTests
```

## Saznajte više

- [Spring AI MCP Dokumentacija](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specifikacija](https://modelcontextprotocol.io/)
- [Spring WebFlux Dokumentacija](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba se smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.