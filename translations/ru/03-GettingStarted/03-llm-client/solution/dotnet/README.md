<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T05:47:42+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

> [!NOTE]
> В этом примере предполагается, что вы используете GitHub Codespaces. Если вы хотите запустить его локально, необходимо создать персональный токен доступа (PAT) на GitHub.
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

## Установка библиотек

```sh
dotnet restore
```

Должны быть установлены следующие библиотеки: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## Запуск

```sh 
dotnet run
```

Вы должны увидеть вывод, похожий на следующий:

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

Большая часть вывода — это отладочная информация, но важно, что вы получаете список инструментов с MCP Server, преобразуете их в инструменты LLM, и в итоге получаете ответ клиента MCP «Sum 6».

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия обеспечить точность, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.