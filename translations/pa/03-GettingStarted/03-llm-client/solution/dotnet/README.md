<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T05:56:07+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਸੈਂਪਲ ਨੂੰ ਚਲਾਓ

> [!NOTE]
> ਇਹ ਸੈਂਪਲ ਧਾਰਣਾ ਕਰਦਾ ਹੈ ਕਿ ਤੁਸੀਂ GitHub Codespaces ਦਾ ਇਸਤੇਮਾਲ ਕਰ ਰਹੇ ਹੋ। ਜੇ ਤੁਸੀਂ ਇਸਨੂੰ ਲੋਕਲ ਤੌਰ 'ਤੇ ਚਲਾਉਣਾ ਚਾਹੁੰਦੇ ਹੋ, ਤਾਂ ਤੁਹਾਨੂੰ GitHub 'ਤੇ ਇੱਕ ਨਿੱਜੀ ਐਕਸੈੱਸ ਟੋਕਨ (PAT) ਸੈਟਅੱਪ ਕਰਨਾ ਪਵੇਗਾ।
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

## ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਸਟਾਲ ਕਰੋ

```sh
dotnet restore
```

ਹੇਠ ਲਿਖੀਆਂ ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਸਟਾਲ ਹੋਣੀਆਂ ਚਾਹੀਦੀਆਂ ਹਨ: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## ਚਲਾਓ

```sh 
dotnet run
```

ਤੁਹਾਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਦਾ ਨਤੀਜਾ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:

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

ਨਤੀਜੇ ਵਿੱਚ ਕਾਫੀ ਹਿੱਸਾ ਡੀਬੱਗਿੰਗ ਦਾ ਹੁੰਦਾ ਹੈ ਪਰ ਜ਼ਰੂਰੀ ਗੱਲ ਇਹ ਹੈ ਕਿ ਤੁਸੀਂ MCP Server ਤੋਂ ਟੂਲ ਲਿਸਟ ਕਰ ਰਹੇ ਹੋ, ਉਹਨਾਂ ਨੂੰ LLM ਟੂਲਾਂ ਵਿੱਚ ਬਦਲ ਰਹੇ ਹੋ ਅਤੇ ਅਖੀਰਕਾਰ ਤੁਹਾਨੂੰ MCP ਕਲਾਇੰਟ ਦਾ ਜਵਾਬ "Sum 6" ਮਿਲਦਾ ਹੈ।

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਆਟੋਮੈਟਿਕ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਪਸ਼ਟਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਅਧਿਕਾਰਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜ਼ਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੇ ਉਪਯੋਗ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।