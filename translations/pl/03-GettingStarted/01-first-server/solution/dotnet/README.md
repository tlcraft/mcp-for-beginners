<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-16T15:11:41+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "pl"
}
-->
# Uruchamianie tego przykładu

## -1- Zainstaluj zależności

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Uruchom przykład

```bash
dotnet run
```

## -4- Przetestuj przykład

Mając serwer uruchomiony w jednym terminalu, otwórz drugi terminal i wykonaj następujące polecenie:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

To powinno uruchomić serwer WWW z interfejsem wizualnym, który pozwoli Ci przetestować przykład.

Gdy serwer będzie połączony:

- spróbuj wyświetlić listę narzędzi i uruchomić `add` z argumentami 2 i 4, w wyniku powinno pojawić się 6.
- przejdź do zasobów i szablonu zasobu, wywołaj "greeting", wpisz imię i powinieneś zobaczyć powitanie z podanym imieniem.

### Testowanie w trybie CLI

Możesz uruchomić go bezpośrednio w trybie CLI, wykonując następujące polecenie:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

To wyświetli wszystkie narzędzia dostępne na serwerze. Powinieneś zobaczyć następujący wynik:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
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
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Powinieneś zobaczyć następujący wynik:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Zazwyczaj dużo szybciej jest uruchomić inspector w trybie CLI niż w przeglądarce.
> Przeczytaj więcej o inspectorze [tutaj](https://github.com/modelcontextprotocol/inspector).

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy uważać za źródło wiarygodne. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.