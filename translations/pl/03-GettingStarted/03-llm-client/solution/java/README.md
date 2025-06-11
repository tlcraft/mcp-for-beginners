<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:26:17+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "pl"
}
-->
# Calculator LLM Client

Aplikacja Java, która pokazuje, jak używać LangChain4j do połączenia się z usługą kalkulatora MCP (Model Context Protocol) z integracją GitHub Models.

## Wymagania wstępne

- Java 21 lub nowsza
- Maven 3.6+ (lub użyj dołączonego Maven wrappera)
- Konto GitHub z dostępem do GitHub Models
- Usługa kalkulatora MCP działająca na `http://localhost:8080`

## Jak uzyskać token GitHub

Ta aplikacja korzysta z GitHub Models, co wymaga osobistego tokenu dostępu GitHub. Postępuj według poniższych kroków, aby uzyskać token:

### 1. Wejdź na GitHub Models
1. Przejdź do [GitHub Models](https://github.com/marketplace/models)
2. Zaloguj się na swoje konto GitHub
3. Poproś o dostęp do GitHub Models, jeśli jeszcze go nie masz

### 2. Utwórz osobisty token dostępu
1. Przejdź do [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Kliknij "Generate new token" → "Generate new token (classic)"
3. Nadaj tokenowi opisową nazwę (np. "MCP Calculator Client")
4. Ustaw datę wygaśnięcia według potrzeb
5. Wybierz następujące zakresy:
   - `repo` (jeśli dostęp do prywatnych repozytoriów)
   - `user:email`
6. Kliknij "Generate token"
7. **Ważne**: Skopiuj token od razu - nie będzie można go później zobaczyć!

### 3. Ustaw zmienną środowiskową

#### Na Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Na Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Na macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Konfiguracja i instalacja

1. **Sklonuj repozytorium lub przejdź do katalogu projektu**

2. **Zainstaluj zależności**:
   ```cmd
   mvnw clean install
   ```
   Lub jeśli masz globalnie zainstalowany Maven:
   ```cmd
   mvn clean install
   ```

3. **Ustaw zmienną środowiskową** (patrz sekcja "Jak uzyskać token GitHub" powyżej)

4. **Uruchom usługę kalkulatora MCP**:
   Upewnij się, że masz uruchomioną usługę kalkulatora MCP z rozdziału 1 na `http://localhost:8080/sse`. Powinna działać przed uruchomieniem klienta.

## Uruchamianie aplikacji

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Co robi aplikacja

Aplikacja demonstruje trzy główne interakcje z usługą kalkulatora:

1. **Dodawanie**: Oblicza sumę 24.5 i 17.3
2. **Pierwiastek kwadratowy**: Oblicza pierwiastek kwadratowy z 144
3. **Pomoc**: Pokazuje dostępne funkcje kalkulatora

## Oczekiwany wynik

Po poprawnym uruchomieniu powinieneś zobaczyć wynik podobny do:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Rozwiązywanie problemów

### Najczęstsze problemy

1. **"GITHUB_TOKEN environment variable not set"**
   - Upewnij się, że ustawiłeś zmienną `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Debugowanie

Aby włączyć logowanie debugowania, dodaj następujący argument JVM podczas uruchamiania:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfiguracja

Aplikacja jest skonfigurowana do:
- Korzystania z GitHub Models z `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Ustawienia limitu czasu na 60 sekund dla żądań
- Włączenia logowania żądań/odpowiedzi do celów debugowania

## Zależności

Główne zależności używane w projekcie:
- **LangChain4j**: do integracji AI i zarządzania narzędziami
- **LangChain4j MCP**: do wsparcia Model Context Protocol
- **LangChain4j GitHub Models**: do integracji GitHub Models
- **Spring Boot**: do frameworka aplikacji i wstrzykiwania zależności

## Licencja

Projekt jest objęty licencją Apache License 2.0 - szczegóły w pliku [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE).

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być traktowany jako źródło wiążące. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.