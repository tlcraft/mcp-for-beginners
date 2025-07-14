<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:15:02+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "pl"
}
-->
# Uruchamianie tego przykładu

Zaleca się zainstalowanie `uv`, ale nie jest to konieczne, zobacz [instrukcje](https://docs.astral.sh/uv/#highlights)

## -0- Utwórz środowisko wirtualne

```bash
python -m venv venv
```

## -1- Aktywuj środowisko wirtualne

```bash
venv\Scrips\activate
```

## -2- Zainstaluj zależności

```bash
pip install "mcp[cli]"
```

## -3- Uruchom przykład

```bash
mcp run server.py
```

## -4- Przetestuj przykład

Gdy serwer działa w jednym terminalu, otwórz inny terminal i uruchom następujące polecenie:

```bash
mcp dev server.py
```

To powinno uruchomić serwer WWW z interfejsem wizualnym, który pozwoli Ci przetestować przykład.

Po połączeniu z serwerem:

- spróbuj wyświetlić listę narzędzi i uruchom `add` z argumentami 2 i 4, w wyniku powinno pojawić się 6.
- przejdź do zasobów i szablonu zasobu, wywołaj get_greeting, wpisz imię i powinieneś zobaczyć powitanie z podanym imieniem.

### Testowanie w trybie CLI

Inspektor, który uruchomiłeś, to w rzeczywistości aplikacja Node.js, a `mcp dev` to jej nakładka.

Możesz uruchomić go bezpośrednio w trybie CLI, wykonując następujące polecenie:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
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

Aby wywołać narzędzie, wpisz:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Powinieneś zobaczyć następujący wynik:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Zazwyczaj znacznie szybciej jest uruchomić inspektora w trybie CLI niż w przeglądarce.
> Więcej o inspektorze przeczytasz [tutaj](https://github.com/modelcontextprotocol/inspector).

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.