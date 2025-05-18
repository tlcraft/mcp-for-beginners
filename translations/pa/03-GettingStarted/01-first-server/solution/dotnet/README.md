<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:08:38+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਨਮੂਨੇ ਨੂੰ ਚਲਾਉਣਾ

## -1- ਨਿਰਭਰਤਾਵਾਂ ਇੰਸਟਾਲ ਕਰੋ

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- ਨਮੂਨਾ ਚਲਾਓ

```bash
dotnet run
```

## -4- ਨਮੂਨੇ ਦੀ ਜਾਂਚ ਕਰੋ

ਜਦੋਂ ਸਰਵਰ ਇੱਕ ਟਰਮੀਨਲ ਵਿੱਚ ਚੱਲ ਰਿਹਾ ਹੈ, ਤਾਂ ਦੂਜੇ ਟਰਮੀਨਲ ਨੂੰ ਖੋਲ੍ਹੋ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

ਇਸ ਨਾਲ ਇੱਕ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਵਾਲਾ ਵੈੱਬ ਸਰਵਰ ਸ਼ੁਰੂ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ ਜੋ ਤੁਹਾਨੂੰ ਨਮੂਨੇ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।

ਜਦੋਂ ਸਰਵਰ ਕਨੈਕਟ ਹੋ ਜਾਂਦਾ ਹੈ:

- ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਬਣਾਉਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ ਅਤੇ `add` ਚਲਾਓ, 2 ਅਤੇ 4 ਦੇ ਆਰਗਸ ਨਾਲ, ਤੁਹਾਨੂੰ ਨਤੀਜੇ ਵਿੱਚ 6 ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ।
- ਸਰੋਤਾਂ ਅਤੇ ਸਰੋਤ ਟੈਮਪਲੇਟ 'ਤੇ ਜਾਓ ਅਤੇ "greeting" ਕਾਲ ਕਰੋ, ਇੱਕ ਨਾਮ ਟਾਈਪ ਕਰੋ ਅਤੇ ਤੁਹਾਨੂੰ ਉਸ ਨਾਮ ਨਾਲ ਸਲਾਮੀ ਦੇਖਣੀ ਚਾਹੀਦੀ ਹੈ ਜੋ ਤੁਸੀਂ ਦਿੱਤਾ ਹੈ।

### CLI ਮੋਡ ਵਿੱਚ ਟੈਸਟਿੰਗ

ਤੁਸੀਂ ਹੇਠਾਂ ਦਿੱਤੇ ਕਮਾਂਡ ਨੂੰ ਚਲਾ ਕੇ ਇਸਨੂੰ ਸਿੱਧੇ CLI ਮੋਡ ਵਿੱਚ ਸ਼ੁਰੂ ਕਰ ਸਕਦੇ ਹੋ:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

ਇਸ ਨਾਲ ਸਰਵਰ ਵਿੱਚ ਉਪਲਬਧ ਸਾਰੇ ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਬਣ ਜਾਵੇਗੀ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ:

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

ਕਿਸੇ ਟੂਲ ਨੂੰ ਚਲਾਉਣ ਲਈ ਟਾਈਪ ਕਰੋ:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ:

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

> [!TIP]
> ਆਮ ਤੌਰ 'ਤੇ CLI ਮੋਡ ਵਿੱਚ ਇੰਸਪੈਕਟਰ ਨੂੰ ਚਲਾਉਣਾ ਬ੍ਰਾਊਜ਼ਰ ਨਾਲੋਂ ਕਾਫੀ ਤੇਜ਼ ਹੁੰਦਾ ਹੈ।
> ਇੰਸਪੈਕਟਰ ਬਾਰੇ ਹੋਰ ਪੜ੍ਹੋ [ਇੱਥੇ](https://github.com/modelcontextprotocol/inspector)।

**ਅਸਵੀਕਰਤੀ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਸੂਚਿਤ ਰਹੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸ ਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।