<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "13231e9951b68efd9df8c56bd5cdb27e",
  "translation_date": "2025-05-16T15:04:13+00:00",
  "source_file": "03-GettingStarted/samples/java/calculator/README.md",
  "language_code": "pl"
}
-->
# Basic Calculator MCP Service

Ta usługa zapewnia podstawowe operacje kalkulatora za pomocą Model Context Protocol (MCP) wykorzystując Spring Boot z transportem WebFlux. Została zaprojektowana jako prosty przykład dla początkujących uczących się implementacji MCP.

Więcej informacji znajdziesz w dokumentacji referencyjnej [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html).

## Przegląd

Usługa demonstruje:
- Obsługę SSE (Server-Sent Events)
- Automatyczną rejestrację narzędzi za pomocą adnotacji Spring AI `@Tool`
- Podstawowe funkcje kalkulatora:
  - Dodawanie, odejmowanie, mnożenie, dzielenie
  - Potęgowanie i pierwiastek kwadratowy
  - Moduł (reszta z dzielenia) oraz wartość bezwzględna
  - Funkcję pomocy opisującą operacje

## Funkcje

Ten kalkulator oferuje następujące możliwości:

1. **Podstawowe działania arytmetyczne**:
   - Dodawanie dwóch liczb
   - Odejmowanie jednej liczby od drugiej
   - Mnożenie dwóch liczb
   - Dzielenie jednej liczby przez drugą (z kontrolą dzielenia przez zero)

2. **Zaawansowane operacje**:
   - Potęgowanie (podnoszenie do potęgi)
   - Obliczanie pierwiastka kwadratowego (z kontrolą dla liczb ujemnych)
   - Obliczanie reszty z dzielenia
   - Obliczanie wartości bezwzględnej

3. **System pomocy**:
   - Wbudowana funkcja pomocy wyjaśniająca dostępne operacje

## Korzystanie z usługi

Usługa udostępnia następujące endpointy API przez protokół MCP:

- `add(a, b)`: Dodaj dwie liczby
- `subtract(a, b)`: Odejmij drugą liczbę od pierwszej
- `multiply(a, b)`: Pomnóż dwie liczby
- `divide(a, b)`: Podziel pierwszą liczbę przez drugą (z kontrolą dzielenia przez zero)
- `power(base, exponent)`: Oblicz potęgę liczby
- `squareRoot(number)`: Oblicz pierwiastek kwadratowy (z kontrolą dla liczb ujemnych)
- `modulus(a, b)`: Oblicz resztę z dzielenia
- `absolute(number)`: Oblicz wartość bezwzględną
- `help()`: Pobierz informacje o dostępnych operacjach

## Klient testowy

Prosty klient testowy znajduje się w pakiecie `com.microsoft.mcp.sample.client`. Klasa `SampleCalculatorClient` demonstruje dostępne operacje kalkulatora.

## Korzystanie z klienta LangChain4j

Projekt zawiera przykładowego klienta LangChain4j w `com.microsoft.mcp.sample.client.LangChain4jClient`, który pokazuje, jak zintegrować usługę kalkulatora z LangChain4j i modelami GitHub:

### Wymagania wstępne

1. **Konfiguracja tokena GitHub**:
   
   Aby korzystać z modeli AI GitHub (np. phi-4), potrzebujesz osobistego tokena dostępu GitHub:

   a. Przejdź do ustawień konta GitHub: https://github.com/settings/tokens
   
   b. Kliknij „Generate new token” → „Generate new token (classic)”
   
   c. Nadaj tokenowi opisową nazwę
   
   d. Wybierz następujące zakresy:
      - `repo` (Pełna kontrola nad prywatnymi repozytoriami)
      - `read:org` (Odczyt członkostwa w organizacji i zespołach, odczyt projektów organizacji)
      - `gist` (Tworzenie gists)
      - `user:email` (Dostęp do adresów email użytkownika (tylko do odczytu))
   
   e. Kliknij „Generate token” i skopiuj nowy token
   
   f. Ustaw go jako zmienną środowiskową:
      
      Na Windows:
      ```
      set GITHUB_TOKEN=your-github-token
      ```
      
      Na macOS/Linux:
      ```bash
      export GITHUB_TOKEN=your-github-token
      ```

   g. Aby ustawienie było trwałe, dodaj go do zmiennych środowiskowych przez ustawienia systemowe

2. Dodaj zależność LangChain4j GitHub do projektu (już zawarte w pom.xml):
   ```xml
   <dependency>
       <groupId>dev.langchain4j</groupId>
       <artifactId>langchain4j-github</artifactId>
       <version>${langchain4j.version}</version>
   </dependency>
   ```

3. Upewnij się, że serwer kalkulatora działa na `localhost:8080`

### Uruchamianie klienta LangChain4j

Przykład demonstruje:
- Połączenie z serwerem kalkulatora MCP przez transport SSE
- Użycie LangChain4j do stworzenia chatbota korzystającego z operacji kalkulatora
- Integrację z modelami AI GitHub (obecnie model phi-4)

Klient wysyła przykładowe zapytania, aby pokazać działanie:
1. Obliczanie sumy dwóch liczb
2. Obliczanie pierwiastka kwadratowego liczby
3. Pobieranie informacji pomocniczych o dostępnych operacjach kalkulatora

Uruchom przykład i sprawdź wyjście w konsoli, aby zobaczyć, jak model AI wykorzystuje narzędzia kalkulatora do odpowiedzi.

### Konfiguracja modelu GitHub

Klient LangChain4j jest skonfigurowany do używania modelu phi-4 GitHub z następującymi ustawieniami:

```java
ChatLanguageModel model = GitHubChatModel.builder()
    .apiKey(System.getenv("GITHUB_TOKEN"))
    .timeout(Duration.ofSeconds(60))
    .modelName("phi-4")
    .logRequests(true)
    .logResponses(true)
    .build();
```

Aby użyć innych modeli GitHub, wystarczy zmienić parametr `modelName` na inny obsługiwany model (np. „claude-3-haiku-20240307”, „llama-3-70b-8192” itd.).

## Zależności

Projekt wymaga następujących kluczowych zależności:

```xml
<!-- For MCP Server -->
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>

<!-- For LangChain4j integration -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-mcp</artifactId>
    <version>${langchain4j.version}</version>
</dependency>

<!-- For GitHub models support -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-github</artifactId>
    <version>${langchain4j.version}</version>
</dependency>
```

## Budowanie projektu

Zbuduj projekt używając Maven:
```bash
./mvnw clean install -DskipTests
```

## Uruchamianie serwera

### Korzystając z Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Korzystając z MCP Inspector

MCP Inspector to przydatne narzędzie do interakcji z usługami MCP. Aby użyć go z tym kalkulatorem:

1. **Zainstaluj i uruchom MCP Inspector** w nowym oknie terminala:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Dostęp do interfejsu webowego** przez kliknięcie wyświetlonego adresu URL (zazwyczaj http://localhost:6274)

3. **Skonfiguruj połączenie**:
   - Ustaw typ transportu na „SSE”
   - Ustaw URL na endpoint SSE działającego serwera: `http://localhost:8080/sse`
   - Kliknij „Connect”

4. **Używaj narzędzi**:
   - Kliknij „List Tools”, aby zobaczyć dostępne operacje kalkulatora
   - Wybierz narzędzie i kliknij „Run Tool”, aby wykonać operację

![MCP Inspector Screenshot](../../../../../../translated_images/tool.c75a0b2380efcf1a47a8478f54380a36ddcca7943b98f56dabbac8b07e15c3bb.pl.png)

### Korzystając z Dockera

Projekt zawiera Dockerfile do wdrożenia w kontenerze:

1. **Zbuduj obraz Dockera**:
   ```bash
   docker build -t calculator-mcp-service .
   ```

2. **Uruchom kontener Dockera**:
   ```bash
   docker run -p 8080:8080 calculator-mcp-service
   ```

To spowoduje:
- Zbudowanie wieloetapowego obrazu Dockera z Maven 3.9.9 i Eclipse Temurin 24 JDK
- Utworzenie zoptymalizowanego obrazu kontenera
- Udostępnienie usługi na porcie 8080
- Uruchomienie usługi kalkulatora MCP wewnątrz kontenera

Po uruchomieniu kontenera możesz uzyskać dostęp do usługi pod adresem `http://localhost:8080`.

## Rozwiązywanie problemów

### Najczęstsze problemy z tokenem GitHub

1. **Problemy z uprawnieniami tokena**: Jeśli otrzymujesz błąd 403 Forbidden, sprawdź, czy token ma odpowiednie uprawnienia zgodnie z wymaganiami.

2. **Token nie znaleziony**: Jeśli pojawia się błąd „No API key found”, upewnij się, że zmienna środowiskowa GITHUB_TOKEN jest poprawnie ustawiona.

3. **Limit zapytań**: API GitHub ma limity zapytań. Jeśli napotkasz błąd limitu (kod 429), odczekaj kilka minut przed ponowną próbą.

4. **Wygasanie tokena**: Tokeny GitHub mogą wygasać. Jeśli po pewnym czasie pojawiają się błędy uwierzytelniania, wygeneruj nowy token i zaktualizuj zmienną środowiskową.

Jeśli potrzebujesz dalszej pomocy, sprawdź [dokumentację LangChain4j](https://github.com/langchain4j/langchain4j) lub [dokumentację API GitHub](https://docs.github.com/en/rest).

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być uważany za źródło wiążące. W przypadku informacji o istotnym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.