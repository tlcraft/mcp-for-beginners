<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:58:17+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
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

Mając serwer uruchomiony w jednym terminalu, otwórz drugi terminal i wykonaj następujące polecenie:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

To powinno uruchomić serwer WWW z interfejsem wizualnym, który pozwoli Ci przetestować przykład.

> Upewnij się, że jako typ transportu wybrano **SSE**, a URL to `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, z argumentami 2 i 4, w wyniku powinieneś zobaczyć 6.
- przejdź do resources i resource template, wywołaj "greeting", wpisz imię i powinieneś zobaczyć powitanie z podanym imieniem.

### Testowanie w trybie CLI

Możesz uruchomić go bezpośrednio w trybie CLI, wykonując następujące polecenie:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Wyświetli to listę wszystkich narzędzi dostępnych na serwerze. Powinieneś zobaczyć następujący wynik:

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
> Zazwyczaj znacznie szybciej jest uruchomić inspector w trybie CLI niż w przeglądarce.
> Więcej informacji o inspectorze znajdziesz [tutaj](https://github.com/modelcontextprotocol/inspector).

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uważany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.