<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:16:16+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "sk"
}
-->
# MCP Java Client - Calculator Demo

Tento projekt ukazuje, ako vytvoriť Java klienta, ktorý sa pripája a komunikuje so serverom MCP (Model Context Protocol). V tomto príklade sa pripojíme k serveru kalkulačky z kapitoly 01 a vykonáme rôzne matematické operácie.

## Požiadavky

Pred spustením tohto klienta je potrebné:

1. **Spustiť server kalkulačky** z kapitoly 01:
   - Prejdite do adresára servera kalkulačky: `03-GettingStarted/01-first-server/solution/java/`
   - Skompilujte a spustite server kalkulačky:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Server by mal bežať na `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` je Java aplikácia, ktorá demonštruje, ako:
- Pripojiť sa k MCP serveru pomocou Server-Sent Events (SSE) transportu
- Zobraziť zoznam dostupných nástrojov zo servera
- Vzdialene volať rôzne funkcie kalkulačky
- Spracovať odpovede a zobraziť výsledky

## Ako to funguje

Klient používa Spring AI MCP framework na:

1. **Nadviazanie spojenia**: Vytvorí WebFlux SSE klientsky transport pre pripojenie k serveru kalkulačky
2. **Inicializáciu klienta**: Nastaví MCP klienta a nadviaže spojenie
3. **Objavenie nástrojov**: Zobrazí všetky dostupné operácie kalkulačky
4. **Vykonanie operácií**: Zavolá rôzne matematické funkcie s ukážkovými dátami
5. **Zobrazenie výsledkov**: Ukáže výsledky každej kalkulácie

## Štruktúra projektu

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

## Kľúčové závislosti

Projekt používa nasledujúce hlavné závislosti:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Táto závislosť poskytuje:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport pre komunikáciu cez web
- Schémy MCP protokolu a typy požiadaviek/odpovedí

## Kompilácia projektu

Projekt zostavte pomocou Maven wrappera:

```cmd
.\mvnw clean install
```

## Spustenie klienta

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Poznámka**: Uistite sa, že server kalkulačky beží na `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Zobrazenie nástrojov** - Ukáže všetky dostupné operácie kalkulačky
3. **Vykonanie výpočtov**:
   - Sčítanie: 5 + 3 = 8
   - Odčítanie: 10 - 4 = 6
   - Násobenie: 6 × 7 = 42
   - Delenie: 20 ÷ 4 = 5
   - Mocnina: 2^8 = 256
   - Druhá odmocnina: √16 = 4
   - Absolútna hodnota: |-5.5| = 5.5
   - Pomoc: Zobrazí dostupné operácie

## Očakávaný výstup

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

**Poznámka**: Na konci môžete vidieť varovania Maven ohľadom zostávajúcich vlákien – je to bežné pri reaktívnych aplikáciách a neznamená to chybu.

## Pochopenie kódu

### 1. Nastavenie transportu
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Toto vytvára SSE (Server-Sent Events) transport, ktorý sa pripája k serveru kalkulačky.

### 2. Vytvorenie klienta
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Vytvorí synchronný MCP klient a inicializuje spojenie.

### 3. Volanie nástrojov
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Volá nástroj "add" s parametrami a=5.0 a b=3.0.

## Riešenie problémov

### Server nebeží
Ak dostávate chyby pripojenia, uistite sa, že server kalkulačky z kapitoly 01 beží:
```
Error: Connection refused
```
**Riešenie**: Najprv spustite server kalkulačky.

### Port je už obsadený
Ak je port 8080 obsadený:
```
Error: Address already in use
```
**Riešenie**: Ukončite iné aplikácie používajúce port 8080 alebo upravte server, aby používal iný port.

### Chyby pri kompilácii
Ak narazíte na chyby pri kompilácii:
```cmd
.\mvnw clean install -DskipTests
```

## Viac informácií

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.