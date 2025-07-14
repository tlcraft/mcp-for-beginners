<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:04:17+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "pl"
}
-->
# Uruchamianie tego przykładu

## -1- Zainstaluj zależności

```bash
dotnet restore
```

## -2- Uruchom przykład

```bash
dotnet run
```

## -3- Przetestuj przykład

Przed uruchomieniem poniższego polecenia otwórz osobny terminal (upewnij się, że serwer nadal działa).

Gdy serwer działa w jednym terminalu, otwórz drugi terminal i uruchom następujące polecenie:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

To powinno uruchomić serwer WWW z interfejsem wizualnym, który pozwoli Ci przetestować przykład.

> Upewnij się, że jako typ transportu wybrano **Streamable HTTP**, a URL to `http://localhost:3001/mcp`.

Po połączeniu z serwerem:

- spróbuj wyświetlić listę narzędzi i uruchom `add` z argumentami 2 i 4, w wyniku powinno pojawić się 6.
- przejdź do zasobów i szablonu zasobu, wywołaj "greeting", wpisz imię i powinieneś zobaczyć powitanie z podanym imieniem.

### Testowanie w trybie CLI

Możesz uruchomić go bezpośrednio w trybie CLI, wykonując następujące polecenie:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

To wyświetli listę wszystkich narzędzi dostępnych na serwerze. Powinieneś zobaczyć następujący wynik:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Aby wywołać narzędzie, wpisz:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> Więcej informacji o inspektorze znajdziesz [tutaj](https://github.com/modelcontextprotocol/inspector).

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.