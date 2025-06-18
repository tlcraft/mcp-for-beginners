<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T06:09:37+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "sr"
}
-->
# Покрени овај пример

> [!NOTE]
> Овај пример претпоставља да користите GitHub Codespaces инстанцу. Ако желите да покренете ово локално, потребно је да подесите personal access token (PAT) на GitHub-у.
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

## Инсталирај библиотеке

```sh
dotnet restore
```

Требало би да инсталирате следеће библиотеке: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## Покрени

```sh 
dotnet run
```

Требало би да видите излаз сличан овоме:

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

Већи део излаза је само дебаговање, али важно је да видите да набрајате алате са MCP сервера, претварате их у LLM алате и на крају добијате одговор MCP клијента "Sum 6".

**Одрицање одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални превод од стране људског преводиоца. Нисмо одговорни за било каква неспоразума или погрешна тумачења која могу настати употребом овог превода.