<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:34:33+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "pl"
}
-->
# Kompletny zestaw przykładów klientów MCP

Ten katalog zawiera kompletne, działające przykłady klientów MCP w różnych językach programowania. Każdy klient demonstruje pełną funkcjonalność opisaną w głównym samouczku README.md.

## Dostępni klienci

### 1. Klient Java (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) przez HTTP
- **Docelowy serwer**: `http://localhost:8080`
- **Funkcje**: 
  - Nawiązywanie połączenia i ping
  - Lista narzędzi
  - Operacje kalkulatora (dodawanie, odejmowanie, mnożenie, dzielenie, pomoc)
  - Obsługa błędów i wyciąganie wyników

**Aby uruchomić:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. Klient C# (`client_example_csharp.cs`)
- **Transport**: Stdio (Standardowe wejście/wyjście)
- **Docelowy serwer**: Lokalny serwer MCP .NET uruchamiany przez dotnet run
- **Funkcje**:
  - Automatyczne uruchamianie serwera przez transport stdio
  - Lista narzędzi i zasobów
  - Operacje kalkulatora
  - Parsowanie wyników w formacie JSON
  - Kompleksowa obsługa błędów

**Aby uruchomić:**
```bash
dotnet run
```

### 3. Klient TypeScript (`client_example_typescript.ts`)
- **Transport**: Stdio (Standardowe wejście/wyjście)
- **Docelowy serwer**: Lokalny serwer MCP Node.js
- **Funkcje**:
  - Pełne wsparcie protokołu MCP
  - Operacje na narzędziach, zasobach i promptach
  - Operacje kalkulatora
  - Odczyt zasobów i wykonywanie promptów
  - Solidna obsługa błędów

**Aby uruchomić:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Klient Python (`client_example_python.py`)
- **Transport**: Stdio (Standardowe wejście/wyjście)  
- **Docelowy serwer**: Lokalny serwer MCP Python
- **Funkcje**:
  - Wzorzec async/await dla operacji
  - Odkrywanie narzędzi i zasobów
  - Testowanie operacji kalkulatora
  - Odczyt zawartości zasobów
  - Organizacja oparta na klasach

**Aby uruchomić:**
```bash
python client_example_python.py
```

## Wspólne cechy wszystkich klientów

Każda implementacja klienta demonstruje:

1. **Zarządzanie połączeniem**
   - Nawiązywanie połączenia z serwerem MCP
   - Obsługa błędów połączenia
   - Prawidłowe sprzątanie i zarządzanie zasobami

2. **Odkrywanie serwera**
   - Lista dostępnych narzędzi
   - Lista dostępnych zasobów (tam gdzie obsługiwane)
   - Lista dostępnych promptów (tam gdzie obsługiwane)

3. **Wywoływanie narzędzi**
   - Podstawowe operacje kalkulatora (dodawanie, odejmowanie, mnożenie, dzielenie)
   - Komenda pomocy z informacjami o serwerze
   - Prawidłowe przekazywanie argumentów i obsługa wyników

4. **Obsługa błędów**
   - Błędy połączenia
   - Błędy wykonania narzędzi
   - Łagodne zakończenie działania i informowanie użytkownika

5. **Przetwarzanie wyników**
   - Wyciąganie tekstowej zawartości z odpowiedzi
   - Formatowanie wyjścia dla czytelności
   - Obsługa różnych formatów odpowiedzi

## Wymagania wstępne

Przed uruchomieniem tych klientów upewnij się, że:

1. **Odpowiedni serwer MCP jest uruchomiony** (z katalogu `../01-first-server/`)
2. **Zainstalowano wymagane zależności** dla wybranego języka
3. **Sieć działa poprawnie** (dla transportów opartych na HTTP)

## Kluczowe różnice między implementacjami

| Język      | Transport | Uruchomienie serwera | Model asynchroniczny | Kluczowe biblioteki |
|------------|-----------|----------------------|---------------------|---------------------|
| Java       | SSE/HTTP  | Zewnętrzne           | Synchroniczny       | WebFlux, MCP SDK    |
| C#         | Stdio     | Automatyczne         | Async/Await         | .NET MCP SDK        |
| TypeScript | Stdio     | Automatyczne         | Async/Await         | Node MCP SDK        |
| Python     | Stdio     | Automatyczne         | AsyncIO             | Python MCP SDK      |

## Kolejne kroki

Po zapoznaniu się z tymi przykładami klientów:

1. **Zmodyfikuj klientów**, aby dodać nowe funkcje lub operacje
2. **Stwórz własny serwer** i przetestuj go z tymi klientami
3. **Eksperymentuj z różnymi transportami** (SSE vs. Stdio)
4. **Zbuduj bardziej złożoną aplikację**, która integruje funkcjonalność MCP

## Rozwiązywanie problemów

### Najczęstsze problemy

1. **Połączenie odrzucone**: Upewnij się, że serwer MCP działa na oczekiwanym porcie/ścieżce
2. **Nie znaleziono modułu**: Zainstaluj wymagany MCP SDK dla swojego języka
3. **Brak uprawnień**: Sprawdź uprawnienia plików dla transportu stdio
4. **Narzędzie nie znalezione**: Zweryfikuj, czy serwer implementuje oczekiwane narzędzia

### Wskazówki do debugowania

1. **Włącz szczegółowe logowanie** w swoim MCP SDK
2. **Sprawdź logi serwera** pod kątem komunikatów o błędach
3. **Zweryfikuj nazwy i sygnatury narzędzi** zgodność między klientem a serwerem
4. **Najpierw przetestuj z MCP Inspector**, aby zweryfikować działanie serwera

## Powiązana dokumentacja

- [Główny samouczek klienta](./README.md)
- [Przykłady serwera MCP](../../../../03-GettingStarted/01-first-server)
- [MCP z integracją LLM](../../../../03-GettingStarted/03-llm-client)
- [Oficjalna dokumentacja MCP](https://modelcontextprotocol.io/)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.