<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:03:52+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਸੈਂਪਲ ਨੂੰ ਚਲਾਉਣਾ

## -1- ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ

```bash
dotnet restore
```

## -2- ਸੈਂਪਲ ਚਲਾਓ

```bash
dotnet run
```

## -3- ਸੈਂਪਲ ਦੀ ਜਾਂਚ ਕਰੋ

ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਉਣ ਤੋਂ ਪਹਿਲਾਂ ਇੱਕ ਵੱਖਰਾ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ (ਪੱਕਾ ਕਰੋ ਕਿ ਸਰਵਰ ਅਜੇ ਵੀ ਚੱਲ ਰਿਹਾ ਹੈ)।

ਜਦੋਂ ਇੱਕ ਟਰਮੀਨਲ ਵਿੱਚ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੋਵੇ, ਤਾਂ ਦੂਜਾ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

ਇਸ ਨਾਲ ਇੱਕ ਵੈੱਬ ਸਰਵਰ ਚੱਲੇਗਾ ਜਿਸਦਾ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਤੁਹਾਨੂੰ ਸੈਂਪਲ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦੇਵੇਗਾ।

> ਯਕੀਨੀ ਬਣਾਓ ਕਿ **Streamable HTTP** ਟਰਾਂਸਪੋਰਟ ਕਿਸਮ ਵਜੋਂ ਚੁਣਿਆ ਗਿਆ ਹੈ, ਅਤੇ URL `http://localhost:3001/mcp` ਹੈ।

ਜਦੋਂ ਸਰਵਰ ਜੁੜ ਜਾਵੇ:

- ਟੂਲਜ਼ ਦੀ ਸੂਚੀ ਬਣਾਉਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ ਅਤੇ `add` ਕਮਾਂਡ ਚਲਾਓ, ਜਿਸ ਵਿੱਚ 2 ਅਤੇ 4 ਆਰਗੁਮੈਂਟ ਹਨ, ਨਤੀਜੇ ਵਿੱਚ 6 ਆਉਣਾ ਚਾਹੀਦਾ ਹੈ।
- resources ਅਤੇ resource template 'ਤੇ ਜਾਓ ਅਤੇ "greeting" ਕਾਲ ਕਰੋ, ਇੱਕ ਨਾਮ ਟਾਈਪ ਕਰੋ ਅਤੇ ਤੁਹਾਨੂੰ ਦਿੱਤੇ ਨਾਮ ਨਾਲ ਇੱਕ ਸਲਾਮ ਮਿਲੇਗਾ।

### CLI ਮੋਡ ਵਿੱਚ ਟੈਸਟਿੰਗ

ਤੁਸੀਂ ਸਿੱਧਾ CLI ਮੋਡ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾ ਕੇ ਇਸਨੂੰ ਸ਼ੁਰੂ ਕਰ ਸਕਦੇ ਹੋ:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

ਇਸ ਨਾਲ ਸਰਵਰ ਵਿੱਚ ਉਪਲਬਧ ਸਾਰੇ ਟੂਲਜ਼ ਦੀ ਸੂਚੀ ਆਵੇਗੀ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:

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

ਕਿਸੇ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰਨ ਲਈ ਟਾਈਪ ਕਰੋ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਮਿਲੇਗਾ:

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
> ਆਮ ਤੌਰ 'ਤੇ CLI ਮੋਡ ਵਿੱਚ inspector ਨੂੰ ਚਲਾਉਣਾ ਬ੍ਰਾਊਜ਼ਰ ਨਾਲੋਂ ਕਾਫੀ ਤੇਜ਼ ਹੁੰਦਾ ਹੈ।
> inspector ਬਾਰੇ ਹੋਰ ਪੜ੍ਹੋ [ਇੱਥੇ](https://github.com/modelcontextprotocol/inspector)।

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।