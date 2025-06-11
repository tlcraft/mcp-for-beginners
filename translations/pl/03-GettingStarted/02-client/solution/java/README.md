<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:10:27+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "pl"
}
-->
# MCP Java Client - Calculator Demo

Ten projekt pokazuje, jak stworzyć klienta Java, który łączy się i komunikuje z serwerem MCP (Model Context Protocol). W tym przykładzie połączymy się z serwerem kalkulatora z Rozdziału 01 i wykonamy różne operacje matematyczne.

## Wymagania wstępne

Przed uruchomieniem tego klienta należy:

1. **Uruchomić serwer kalkulatora** z Rozdziału 01:
   - Przejdź do katalogu serwera kalkulatora: `03-GettingStarted/01-first-server/solution/java/`
   - Zbuduj i uruchom serwer kalkulatora:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Serwer powinien działać pod adresem `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` to aplikacja Java, która pokazuje, jak:
- Połączyć się z serwerem MCP za pomocą transportu Server-Sent Events (SSE)
- Wyświetlić listę dostępnych narzędzi na serwerze
- Zdalnie wywołać różne funkcje kalkulatora
- Obsłużyć odpowiedzi i wyświetlić wyniki

## Jak to działa

Klient korzysta z frameworka Spring AI MCP, aby:

1. **Nawiązać połączenie**: Tworzy transport WebFlux SSE, który łączy się z serwerem kalkulatora
2. **Zainicjalizować klienta**: Ustawia klienta MCP i nawiązuje połączenie
3. **Odkryć narzędzia**: Wyświetla listę wszystkich dostępnych operacji kalkulatora
4. **Wykonać operacje**: Wywołuje różne funkcje matematyczne na przykładowych danych
5. **Wyświetlić wyniki**: Pokazuje wyniki każdego obliczenia

## Struktura projektu

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

## Kluczowe zależności

Projekt korzysta z następujących kluczowych zależności:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Ta zależność zapewnia:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - transport SSE do komunikacji webowej
- Schematy protokołu MCP oraz typy zapytań/odpowiedzi

## Budowanie projektu

Zbuduj projekt używając wrappera Maven:

```cmd
.\mvnw clean install
```

## Uruchamianie klienta

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: Upewnij się, że serwer kalkulatora działa pod adresem `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Wyświetl narzędzia** - Pokazuje wszystkie dostępne operacje kalkulatora
3. **Wykonaj obliczenia**:
   - Dodawanie: 5 + 3 = 8
   - Odejmowanie: 10 - 4 = 6
   - Mnożenie: 6 × 7 = 42
   - Dzielenie: 20 ÷ 4 = 5
   - Potęgowanie: 2^8 = 256
   - Pierwiastek kwadratowy: √16 = 4
   - Wartość bezwzględna: |-5.5| = 5.5
   - Pomoc: Pokazuje dostępne operacje

## Oczekiwany wynik

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

**Note**: Pod koniec mogą pojawić się ostrzeżenia Mavena o pozostających wątkach - jest to normalne w aplikacjach reaktywnych i nie oznacza błędu.

## Zrozumienie kodu

### 1. Konfiguracja transportu
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Tworzy transport SSE (Server-Sent Events), który łączy się z serwerem kalkulatora.

### 2. Tworzenie klienta
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Tworzy synchronicznego klienta MCP i inicjalizuje połączenie.

### 3. Wywoływanie narzędzi
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Wywołuje narzędzie "add" z parametrami a=5.0 i b=3.0.

## Rozwiązywanie problemów

### Serwer nie działa
Jeśli pojawią się błędy połączenia, upewnij się, że serwer kalkulatora z Rozdziału 01 jest uruchomiony:
```
Error: Connection refused
```
**Rozwiązanie**: Najpierw uruchom serwer kalkulatora.

### Port jest zajęty
Jeśli port 8080 jest zajęty:
```
Error: Address already in use
```
**Rozwiązanie**: Zatrzymaj inne aplikacje korzystające z portu 8080 lub zmień port serwera na inny.

### Błędy podczas budowania
Jeśli pojawią się błędy podczas budowania:
```cmd
.\mvnw clean install -DskipTests
```

## Dowiedz się więcej

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za wiarygodne źródło. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.