<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-16T14:59:07+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "pl"
}
-->
# Uruchom ten przykład

> [!NOTE]
> Ten przykład zakłada, że korzystasz z instancji GitHub Codespaces. Jeśli chcesz uruchomić to lokalnie, musisz utworzyć personalny token dostępu na GitHub.

## Zainstaluj biblioteki

```sh
dotnet restore
```

Powinny zostać zainstalowane następujące biblioteki: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## Uruchom

```sh 
dotnet run
```

Powinieneś zobaczyć wynik podobny do:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

Większość wyjścia to debugowanie, ale ważne jest, że wymieniasz narzędzia z MCP Server, przekształcasz je w narzędzia LLM i otrzymujesz odpowiedź klienta MCP "Sum 6".

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w jego rodzimym języku należy traktować jako źródło wiarygodne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.