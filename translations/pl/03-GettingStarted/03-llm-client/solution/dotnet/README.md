<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T05:58:24+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "pl"
}
-->
# Uruchom ten przykład

> [!NOTE]
> Ten przykład zakłada, że korzystasz z instancji GitHub Codespaces. Jeśli chcesz uruchomić go lokalnie, musisz utworzyć token dostępu osobistego (PAT) na GitHub.
>
> ```bash
> # zsh/bash
> export GITHUB_TOKEN="{{YOUR_GITHUB_PAT}}"
> ```
>
> ```powershell
> # PowerShell
> $env:GITHUB_TOKEN = "{{YOUR_GITHUB_PAT}}"
> ```

## Zainstaluj biblioteki

```sh
dotnet restore
```

Powinny zostać zainstalowane następujące biblioteki: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## Uruchom

```sh 
dotnet run
```

Powinieneś zobaczyć wyjście podobne do:

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

Wiele z wyjścia to tylko debugowanie, ale ważne jest to, że wyświetlasz narzędzia z serwera MCP, przekształcasz je w narzędzia LLM i otrzymujesz odpowiedź klienta MCP „Sum 6”.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło wiarygodne. W przypadku informacji o krytycznym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.