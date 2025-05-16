<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-16T15:12:34+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "pl"
}
-->
# Uruchamianie tego przykładu

Zaleca się zainstalowanie `uv`, ale nie jest to konieczne, zobacz [instrukcje](https://docs.astral.sh/uv/#highlights)

## -0- Utwórz wirtualne środowisko

```bash
python -m venv venv
```

## -1- Aktywuj wirtualne środowisko

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

Gdy serwer działa w jednym terminalu, otwórz drugi terminal i uruchom następujące polecenie:

```bash
mcp dev server.py
```

To powinno uruchomić serwer WWW z interfejsem graficznym, który pozwoli Ci przetestować przykład.

Po połączeniu z serwerem:

- spróbuj wyświetlić listę narzędzi i uruchomić `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` to nakładka na to.

Możesz uruchomić go bezpośrednio w trybie CLI, wykonując następujące polecenie:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

To wyświetli listę wszystkich narzędzi dostępnych na serwerze. Powinieneś zobaczyć następujące wyjście:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Powinieneś zobaczyć następujące wyjście:

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
Niniejszy dokument został przetłumaczony za pomocą automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za wiarygodne źródło informacji. W przypadku informacji o istotnym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.