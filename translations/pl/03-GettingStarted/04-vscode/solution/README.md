<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:44:53+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "pl"
}
-->
# Uruchamianie przykładu

Zakładamy, że masz już działający kod serwera. Znajdź serwer z jednego z wcześniejszych rozdziałów.

## Konfiguracja mcp.json

Oto plik, który możesz wykorzystać jako punkt odniesienia, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Zmień wpis serwera tak, aby wskazywał absolutną ścieżkę do twojego serwera wraz z pełną komendą potrzebną do uruchomienia.

W przykładowym pliku, o którym mowa powyżej, wpis serwera wygląda następująco:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Odpowiada to uruchomieniu polecenia w ten sposób: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` wpisz coś w stylu "add 3 to 20".

    Powinieneś zobaczyć narzędzie pojawiające się nad polem tekstowym czatu, które pozwala wybrać uruchomienie narzędzia, jak na tym obrazie:

    ![VS Code wskazuje, że chce uruchomić narzędzie](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.pl.png)

    Wybranie narzędzia powinno zwrócić wynik liczbowy "23", jeśli twój prompt był taki, jak wspomnieliśmy wcześniej.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy uważać za źródło autorytatywne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.