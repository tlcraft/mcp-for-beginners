<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-16T15:16:12+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "pl"
}
-->
# Uruchamianie przykładu

Zakładamy, że masz już działający kod serwera. Proszę znajdź serwer z jednego z wcześniejszych rozdziałów.

## Konfiguracja mcp.json

Oto plik, którego możesz użyć jako odniesienia, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Zmień wpis serwera tak, aby wskazywał na bezwzględną ścieżkę do Twojego serwera, włącznie z pełną komendą potrzebną do uruchomienia.

W przykładowym pliku wspomnianym powyżej wpis serwera wygląda następująco:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Odpowiada to uruchomieniu polecenia w stylu: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` wpisz coś w stylu "add 3 to 20".

    Powinieneś zobaczyć narzędzie wyświetlone nad polem tekstowym czatu, wskazujące, że możesz wybrać uruchomienie narzędzia, jak na tym obrazku:

    ![VS Code wskazujący, że chce uruchomić narzędzie](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.pl.png)

    Wybranie narzędzia powinno dać wynik liczbowy „23”, jeśli Twoja komenda była podobna do tej, o której wspomnieliśmy wcześniej.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiążące. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.