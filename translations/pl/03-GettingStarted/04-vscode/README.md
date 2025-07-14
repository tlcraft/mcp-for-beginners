<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:33:55+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "pl"
}
-->
Porozmawiajmy więcej o tym, jak korzystać z interfejsu wizualnego w kolejnych sekcjach.

## Podejście

Oto, jak powinniśmy podejść do tego na wysokim poziomie:

- Skonfigurować plik, aby znaleźć nasz MCP Server.
- Uruchomić/Połączyć się z tym serwerem, aby uzyskać listę jego możliwości.
- Korzystać z tych możliwości za pomocą interfejsu GitHub Copilot Chat.

Świetnie, teraz gdy rozumiemy ten proces, spróbujmy użyć MCP Server przez Visual Studio Code w ramach ćwiczenia.

## Ćwiczenie: Konsumowanie serwera

W tym ćwiczeniu skonfigurujemy Visual Studio Code, aby znalazło Twój MCP Server, tak aby można go było używać z poziomu interfejsu GitHub Copilot Chat.

### -0- Krok wstępny, włącz wykrywanie MCP Serverów

Może być konieczne włączenie wykrywania MCP Serverów.

1. Przejdź do `Plik -> Preferencje -> Ustawienia` w Visual Studio Code.

1. Wyszukaj "MCP" i włącz `chat.mcp.discovery.enabled` w pliku settings.json.

### -1- Utwórz plik konfiguracyjny

Zacznij od utworzenia pliku konfiguracyjnego w katalogu głównym projektu, potrzebujesz pliku o nazwie MCP.json, który umieścisz w folderze .vscode. Powinien wyglądać tak:

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
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Powyżej znajduje się prosty przykład, jak uruchomić serwer napisany w Node.js, dla innych środowisk uruchomieniowych wskaż odpowiednią komendę do uruchomienia serwera, używając `command` i `args`.

### -3- Uruchom serwer

Teraz, gdy dodałeś wpis, uruchom serwer:

1. Znajdź swój wpis w *mcp.json* i upewnij się, że widzisz ikonę "play":

  ![Uruchamianie serwera w Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.pl.png)  

1. Kliknij ikonę "play", powinieneś zobaczyć, że ikona narzędzi w GitHub Copilot Chat zwiększa liczbę dostępnych narzędzi. Po kliknięciu tej ikony zobaczysz listę zarejestrowanych narzędzi. Możesz zaznaczać/odznaczać każde narzędzie, w zależności od tego, czy chcesz, aby GitHub Copilot używał ich jako kontekstu:

  ![Uruchamianie serwera w Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.pl.png)

1. Aby uruchomić narzędzie, wpisz prompt, który pasuje do opisu jednego z Twoich narzędzi, na przykład prompt: "dodaj 22 do 1":

  ![Uruchamianie narzędzia z GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.pl.png)

  Powinieneś zobaczyć odpowiedź z wynikiem 23.

## Zadanie

Spróbuj dodać wpis serwera do swojego pliku *mcp.json* i upewnij się, że możesz uruchamiać/zatrzymywać serwer. Upewnij się również, że możesz komunikować się z narzędziami na swoim serwerze za pomocą interfejsu GitHub Copilot Chat.

## Rozwiązanie

[Solution](./solution/README.md)

## Kluczowe wnioski

Najważniejsze wnioski z tego rozdziału to:

- Visual Studio Code to świetny klient, który pozwala korzystać z wielu MCP Serverów i ich narzędzi.
- Interfejs GitHub Copilot Chat to sposób, w jaki wchodzisz w interakcję z serwerami.
- Możesz poprosić użytkownika o dane wejściowe, takie jak klucze API, które mogą być przekazywane do MCP Servera podczas konfigurowania wpisu serwera w pliku *mcp.json*.

## Przykłady

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Co dalej

- Następny: [Tworzenie serwera SSE](../05-sse-server/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.