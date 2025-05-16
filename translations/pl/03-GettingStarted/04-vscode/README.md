<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c37fabfbc0dcbc9a4afb6d17e7d3be9f",
  "translation_date": "2025-05-16T15:15:23+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "pl"
}
-->
Porozmawiajmy więcej o tym, jak korzystać z interfejsu wizualnego w kolejnych sekcjach.

## Podejście

Oto, jak powinniśmy to ogólnie podejść:

- Skonfigurować plik, aby znaleźć nasz MCP Server.
- Uruchomić/połączyć się z tym serwerem, aby wyświetlić jego możliwości.
- Korzystać z tych możliwości przez interfejs czatu GitHub Copilot.

Świetnie, teraz gdy rozumiemy ten proces, spróbujmy użyć MCP Servera w Visual Studio Code podczas ćwiczenia.

## Ćwiczenie: Korzystanie z serwera

W tym ćwiczeniu skonfigurujemy Visual Studio Code, aby znalazł twój MCP Server i można go było używać z poziomu interfejsu czatu GitHub Copilot.

### -0- Krok wstępny, włącz wykrywanie MCP Serverów

Może być konieczne włączenie wykrywania MCP Serverów.

1. Przejdź do `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` w pliku settings.json.

### -1- Utwórz plik konfiguracyjny

Zacznij od utworzenia pliku konfiguracyjnego w katalogu głównym projektu, potrzebujesz pliku o nazwie MCP.json umieszczonego w folderze .vscode. Powinien wyglądać tak:

```text
.vscode
|-- mcp.json
```

Następnie zobaczmy, jak dodać wpis serwera.

### -2- Skonfiguruj serwer

Dodaj następującą zawartość do *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "cmd",
           "args": [
               "/c", "node", "<absolute path>\\build\\index.js"
           ]
       }
    }
}
```

Powyżej znajduje się prosty przykład uruchomienia serwera napisanego w Node.js, dla innych środowisk wskaż odpowiednią komendę do uruchomienia serwera, używając `command` and `args`.

### -3- Uruchom serwer

Teraz, gdy dodałeś wpis, uruchom serwer:

1. Znajdź swój wpis w *mcp.json* i upewnij się, że widzisz ikonę „play”:

  ![Uruchamianie serwera w Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.pl.png)

2. Kliknij ikonę „play”, powinieneś zobaczyć, że ikona narzędzi w czacie GitHub Copilot zwiększa liczbę dostępnych narzędzi. Po kliknięciu tej ikony zobaczysz listę zarejestrowanych narzędzi. Możesz zaznaczać lub odznaczać każde narzędzie, w zależności od tego, czy chcesz, aby GitHub Copilot używał ich jako kontekstu:

  ![Narzędzia w Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.pl.png)

3. Aby uruchomić narzędzie, wpisz zapytanie, które odpowiada opisowi jednego z twoich narzędzi, na przykład „add 22 to 1”:

  ![Uruchamianie narzędzia z GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.pl.png)

  Powinieneś zobaczyć odpowiedź: 23.

## Zadanie

Spróbuj dodać wpis serwera do swojego pliku *mcp.json* i upewnij się, że możesz uruchamiać i zatrzymywać serwer. Sprawdź także, czy możesz komunikować się z narzędziami na swoim serwerze przez interfejs czatu GitHub Copilot.

## Rozwiązanie

[Solution](./solution/README.md)

## Najważniejsze wnioski

Najważniejsze punkty z tego rozdziału to:

- Visual Studio Code to świetny klient, który pozwala korzystać z wielu MCP Serverów i ich narzędzi.
- Interfejs czatu GitHub Copilot to sposób, w jaki wchodzisz w interakcję z serwerami.
- Możesz prosić użytkownika o dane wejściowe, takie jak klucze API, które można przekazać do MCP Servera podczas konfigurowania wpisu serwera w pliku *mcp.json*.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Co dalej

- Następny temat: [Tworzenie serwera SSE](/03-GettingStarted/05-sse-server/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego języku źródłowym powinien być uznawany za źródło wiarygodne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.