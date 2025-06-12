<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:33:48+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "pl"
}
-->
# Lekcja: Budowa serwera Web Search MCP

Ten rozdział pokazuje, jak zbudować praktycznego agenta AI, który integruje się z zewnętrznymi API, obsługuje różnorodne typy danych, zarządza błędami i koordynuje wiele narzędzi — wszystko w formacie gotowym do produkcji. Zobaczysz:

- **Integrację z zewnętrznymi API wymagającymi uwierzytelnienia**
- **Obsługę różnych typów danych z wielu punktów końcowych**
- **Solidne strategie obsługi błędów i logowania**
- **Koordynację wielu narzędzi w jednym serwerze**

Na koniec zdobędziesz praktyczne doświadczenie z wzorcami i najlepszymi praktykami niezbędnymi w zaawansowanych aplikacjach AI i opartych na LLM.

## Wprowadzenie

W tej lekcji nauczysz się, jak zbudować zaawansowany serwer MCP i klienta, którzy rozszerzają możliwości LLM o dane z internetu w czasie rzeczywistym, korzystając z SerpAPI. To kluczowa umiejętność do tworzenia dynamicznych agentów AI, którzy mają dostęp do aktualnych informacji z sieci.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Bezpiecznie integrować zewnętrzne API (takie jak SerpAPI) z serwerem MCP
- Implementować wiele narzędzi do wyszukiwania w sieci, wiadomości, produktów oraz Q&A
- Parsować i formatować dane strukturalne pod potrzeby LLM
- Skutecznie obsługiwać błędy i zarządzać limitami API
- Budować i testować zarówno zautomatyzowanych, jak i interaktywnych klientów MCP

## Serwer Web Search MCP

Ta sekcja przedstawia architekturę i funkcje serwera Web Search MCP. Zobaczysz, jak FastMCP i SerpAPI współpracują, aby rozszerzyć możliwości LLM o dane internetowe w czasie rzeczywistym.

### Przegląd

Implementacja zawiera cztery narzędzia, które pokazują, jak MCP radzi sobie z różnorodnymi zadaniami opartymi na zewnętrznych API w sposób bezpieczny i efektywny:

- **general_search**: Do szerokich wyników wyszukiwania w sieci
- **news_search**: Do najnowszych nagłówków wiadomości
- **product_search**: Do danych e-commerce
- **qna**: Do fragmentów pytań i odpowiedzi

### Funkcje
- **Przykłady kodu**: Zawiera bloki kodu specyficzne dla Pythona (łatwo rozszerzalne na inne języki) z sekcjami zwijanymi dla przejrzystości

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

Przed uruchomieniem klienta warto zrozumieć, co robi serwer. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Oto krótki przykład, jak serwer definiuje i rejestruje narzędzie:

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **Integracja z zewnętrznym API**: Pokazuje bezpieczne zarządzanie kluczami API i zapytaniami zewnętrznymi
- **Parsowanie danych strukturalnych**: Przekształca odpowiedzi API na format przyjazny dla LLM
- **Obsługa błędów**: Solidna obsługa błędów z odpowiednim logowaniem
- **Interaktywny klient**: Zawiera zarówno testy automatyczne, jak i tryb interaktywny do testowania
- **Zarządzanie kontekstem**: Wykorzystuje MCP Context do logowania i śledzenia zapytań

## Wymagania wstępne

Zanim zaczniesz, upewnij się, że Twoje środowisko jest poprawnie skonfigurowane, wykonując poniższe kroki. Zapewni to instalację wszystkich zależności i poprawną konfigurację kluczy API do bezproblemowego rozwoju i testów.

- Python 3.8 lub nowszy
- Klucz API SerpAPI (zarejestruj się na [SerpAPI](https://serpapi.com/) — dostępny darmowy plan)

## Instalacja

Aby rozpocząć, wykonaj następujące kroki, aby skonfigurować środowisko:

1. Zainstaluj zależności za pomocą uv (zalecane) lub pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Utwórz plik `.env` w katalogu głównym projektu z kluczem SerpAPI:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Użytkowanie

Serwer Web Search MCP to kluczowy komponent, który udostępnia narzędzia do wyszukiwania w sieci, wiadomości, produktów i Q&A poprzez integrację z SerpAPI. Obsługuje przychodzące zapytania, zarządza wywołaniami API, parsuje odpowiedzi i zwraca do klienta dane w formacie strukturalnym.

Pełną implementację możesz przejrzeć w [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Uruchamianie serwera

Aby uruchomić serwer MCP, użyj następującego polecenia:

```bash
python server.py
```

Serwer będzie działał jako serwer MCP oparty na stdio, do którego klient może się bezpośrednio podłączyć.

### Tryby klienta

Klient (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Uruchamianie klienta

Aby uruchomić testy automatyczne (spowoduje to automatyczne uruchomienie serwera):

```bash
python client.py
```

Lub uruchom w trybie interaktywnym:

```bash
python client.py --interactive
```

### Testowanie różnymi metodami

Istnieje kilka sposobów testowania i interakcji z narzędziami udostępnionymi przez serwer, w zależności od Twoich potrzeb i sposobu pracy.

#### Pisanie własnych skryptów testowych z MCP Python SDK
Możesz też tworzyć własne skrypty testowe, korzystając z MCP Python SDK:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

W tym kontekście „skrypt testowy” oznacza niestandardowy program w Pythonie, który piszesz, aby działał jako klient serwera MCP. Zamiast formalnego testu jednostkowego, skrypt ten pozwala programowo łączyć się z serwerem, wywoływać dowolne jego narzędzia z wybranymi parametrami i analizować wyniki. To podejście jest przydatne do:
- Prototypowania i eksperymentowania z wywołaniami narzędzi
- Weryfikacji odpowiedzi serwera na różne dane wejściowe
- Automatyzacji powtarzalnych wywołań narzędzi
- Budowania własnych przepływów pracy lub integracji na bazie serwera MCP

Możesz używać skryptów testowych do szybkiego wypróbowywania nowych zapytań, debugowania zachowania narzędzi lub jako punktu wyjścia do bardziej zaawansowanej automatyzacji. Poniżej przykład użycia MCP Python SDK do stworzenia takiego skryptu:

## Opisy narzędzi

Możesz korzystać z poniższych narzędzi udostępnianych przez serwer do wykonywania różnych rodzajów wyszukiwań i zapytań. Każde narzędzie jest opisane poniżej wraz z parametrami i przykładowym użyciem.

Ta sekcja zawiera szczegóły dotyczące każdego dostępnego narzędzia i ich parametrów.

### general_search

Wykonuje ogólne wyszukiwanie w sieci i zwraca sformatowane wyniki.

**Jak wywołać to narzędzie:**

Możesz wywołać `general_search` z własnego skryptu, korzystając z MCP Python SDK, lub interaktywnie za pomocą Inspektora albo trybu interaktywnego klienta. Oto przykład kodu z użyciem SDK:

<details>
<summary>Przykład w Pythonie</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

Alternatywnie, w trybie interaktywnym wybierz `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Zapytanie wyszukiwania

**Przykładowe zapytanie:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Wyszukuje najnowsze artykuły wiadomości powiązane z zapytaniem.

**Jak wywołać to narzędzie:**

Możesz wywołać `news_search` z własnego skryptu, korzystając z MCP Python SDK, lub interaktywnie za pomocą Inspektora albo trybu interaktywnego klienta. Oto przykład kodu z użyciem SDK:

<details>
<summary>Przykład w Pythonie</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

Alternatywnie, w trybie interaktywnym wybierz `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Zapytanie wyszukiwania

**Przykładowe zapytanie:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Wyszukuje produkty pasujące do zapytania.

**Jak wywołać to narzędzie:**

Możesz wywołać `product_search` z własnego skryptu, korzystając z MCP Python SDK, lub interaktywnie za pomocą Inspektora albo trybu interaktywnego klienta. Oto przykład kodu z użyciem SDK:

<details>
<summary>Przykład w Pythonie</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

Alternatywnie, w trybie interaktywnym wybierz `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Zapytanie wyszukiwania produktu

**Przykładowe zapytanie:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Uzyskuje bezpośrednie odpowiedzi na pytania z wyszukiwarek.

**Jak wywołać to narzędzie:**

Możesz wywołać `qna` z własnego skryptu, korzystając z MCP Python SDK, lub interaktywnie za pomocą Inspektora albo trybu interaktywnego klienta. Oto przykład kodu z użyciem SDK:

<details>
<summary>Przykład w Pythonie</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

Alternatywnie, w trybie interaktywnym wybierz `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Pytanie, na które szukasz odpowiedzi

**Przykładowe zapytanie:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Szczegóły kodu

Ta sekcja zawiera fragmenty kodu i odniesienia do implementacji serwera i klienta.

<details>
<summary>Python</summary>

Pełne szczegóły implementacji znajdziesz w [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Zaawansowane koncepcje w tej lekcji

Zanim zaczniesz budować, oto kilka ważnych zaawansowanych pojęć, które pojawią się w całym rozdziale. Ich zrozumienie pomoże Ci śledzić materiał, nawet jeśli są dla Ciebie nowe:

- **Koordynacja wielu narzędzi**: Oznacza uruchamianie kilku różnych narzędzi (takich jak wyszukiwanie w sieci, wiadomości, produkty i Q&A) w jednym serwerze MCP. Pozwala to serwerowi obsługiwać różnorodne zadania, a nie tylko jedno.
- **Obsługa limitów API**: Wiele zewnętrznych API (np. SerpAPI) ogranicza liczbę zapytań w określonym czasie. Dobry kod sprawdza te limity i radzi sobie z nimi w sposób łagodny, aby aplikacja nie przestała działać po przekroczeniu limitu.
- **Parsowanie danych strukturalnych**: Odpowiedzi API są często złożone i zagnieżdżone. Ta koncepcja polega na przekształceniu tych odpowiedzi na czyste, łatwe w użyciu formaty, przyjazne dla LLM lub innych programów.
- **Odporność na błędy**: Czasem coś idzie nie tak — może sieć zawiedzie, albo API nie zwróci oczekiwanych danych. Odporność na błędy oznacza, że Twój kod potrafi radzić sobie z tymi problemami i nadal dostarczać przydatne informacje, zamiast się zawieszać.
- **Walidacja parametrów**: Chodzi o sprawdzanie, czy wszystkie dane wejściowe do narzędzi są poprawne i bezpieczne. Obejmuje to ustawianie wartości domyślnych i sprawdzanie typów, co pomaga unikać błędów i nieporozumień.

Ta sekcja pomoże Ci diagnozować i rozwiązywać typowe problemy, które możesz napotkać podczas pracy z serwerem Web Search MCP. Jeśli pojawią się błędy lub nieoczekiwane zachowanie, ta część zawiera rozwiązania najczęstszych problemów. Przejrzyj te wskazówki zanim poprosisz o dalszą pomoc — często szybko rozwiązują problemy.

## Rozwiązywanie problemów

Podczas pracy z serwerem Web Search MCP mogą się zdarzyć problemy — to normalne przy pracy z zewnętrznymi API i nowymi narzędziami. Ta sekcja oferuje praktyczne rozwiązania najczęstszych problemów, abyś mógł szybko wrócić do pracy. Jeśli napotkasz błąd, zacznij tutaj: poniższe wskazówki dotyczą problemów, z którymi najczęściej borykają się użytkownicy i często pozwalają rozwiązać problem bez dodatkowej pomocy.

### Najczęstsze problemy

Poniżej znajdziesz najczęściej występujące problemy wraz z jasnym wyjaśnieniem i krokami do ich rozwiązania:

1. **Brak SERPAPI_KEY w pliku .env**
   - Jeśli zobaczysz błąd `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` — upewnij się, że masz plik `.env` z poprawnym kluczem. Jeśli klucz jest poprawny, a błąd nadal występuje, sprawdź, czy nie wyczerpałeś limitu darmowego planu.

### Tryb debugowania

Domyślnie aplikacja loguje tylko ważne informacje. Jeśli chcesz zobaczyć więcej szczegółów o przebiegu działania (np. aby zdiagnozować trudne problemy), możesz włączyć tryb DEBUG. Pokaże on dużo więcej informacji o każdym kroku aplikacji.

**Przykład: Normalny output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Przykład: output DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Zauważ, że tryb DEBUG zawiera dodatkowe linie dotyczące zapytań HTTP, odpowiedzi i innych szczegółów wewnętrznych. To może być bardzo pomocne przy rozwiązywaniu problemów.

Aby włączyć tryb DEBUG, ustaw poziom logowania na DEBUG na początku pliku `client.py` or `server.py`:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## Co dalej

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy traktować jako źródło ostateczne. W przypadku istotnych informacji zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.