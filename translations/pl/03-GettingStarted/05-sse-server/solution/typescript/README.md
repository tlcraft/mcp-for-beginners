<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:20:15+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "pl"
}
-->
# Uruchamianie tego przykładu

## -1- Zainstaluj zależności

```bash
npm install
```

## -3- Uruchom przykład

```bash
npm run build
```

## -4- Przetestuj przykład

Gdy serwer działa w jednym terminalu, otwórz drugi terminal i uruchom następujące polecenie:

```bash
npm run inspector
```

To powinno uruchomić serwer WWW z interfejsem wizualnym, który pozwoli Ci przetestować przykład.

Po połączeniu się z serwerem:

- spróbuj wyświetlić listę narzędzi i uruchomić `add` z argumentami 2 i 4, w wyniku powinno pojawić się 6.
- przejdź do zasobów i szablonu zasobu, wywołaj "greeting", wpisz imię i powinieneś zobaczyć powitanie z podanym imieniem.

### Testowanie w trybie CLI

Inspektor, który uruchomiłeś, to w rzeczywistości aplikacja Node.js, a `mcp dev` jest jej nakładką.

- Uruchom serwer poleceniem `npm run build`.

- W osobnym terminalu wpisz następujące polecenie:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    To wyświetli listę wszystkich narzędzi dostępnych na serwerze. Powinieneś zobaczyć następujący wynik:

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- Wywołaj typ narzędzia, wpisując następujące polecenie:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Powinieneś zobaczyć następujący wynik:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Zazwyczaj dużo szybciej jest uruchomić inspektora w trybie CLI niż w przeglądarce.
> Więcej informacji o inspektorze znajdziesz [tutaj](https://github.com/modelcontextprotocol/inspector).

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.