<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:55:59+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
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

ਇੱਕ ਟਰਮੀਨਲ ਵਿੱਚ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੋਵੇ, ਤਾਂ ਦੂਜਾ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

ਇਸ ਨਾਲ ਇੱਕ ਵੈੱਬ ਸਰਵਰ ਚੱਲੂ ਹੋਵੇਗਾ ਜਿਸਦਾ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਤੁਹਾਨੂੰ ਸੈਂਪਲ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦੇਵੇਗਾ।

> ਯਕੀਨੀ ਬਣਾਓ ਕਿ **SSE** ਨੂੰ ਟਰਾਂਸਪੋਰਟ ਕਿਸਮ ਵਜੋਂ ਚੁਣਿਆ ਗਿਆ ਹੈ, ਅਤੇ URL `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add` ਹੈ, ਜਿਸਦੇ ਨਾਲ args 2 ਅਤੇ 4 ਹਨ, ਤਾਂ ਨਤੀਜੇ ਵਿੱਚ 6 ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ।
- resources ਅਤੇ resource template ਵਿੱਚ ਜਾਓ ਅਤੇ "greeting" ਕਾਲ ਕਰੋ, ਕੋਈ ਨਾਮ ਲਿਖੋ ਅਤੇ ਤੁਹਾਨੂੰ ਦਿੱਤੇ ਗਏ ਨਾਮ ਨਾਲ ਸਲਾਮ ਦਿਖਾਈ ਦੇਵੇਗਾ।

### CLI ਮੋਡ ਵਿੱਚ ਜਾਂਚ

ਤੁਸੀਂ ਸਿੱਧਾ CLI ਮੋਡ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾ ਕੇ ਇਸਨੂੰ ਲਾਂਚ ਕਰ ਸਕਦੇ ਹੋ:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

ਇਸ ਨਾਲ ਸਰਵਰ ਵਿੱਚ ਉਪਲਬਧ ਸਾਰੇ ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਆਵੇਗੀ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਮਿਲੇਗਾ:

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

ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:

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
> CLI ਮੋਡ ਵਿੱਚ ispector ਚਲਾਉਣਾ ਬ੍ਰਾਉਜ਼ਰ ਨਾਲੋਂ ਆਮ ਤੌਰ ਤੇ ਕਾਫੀ ਤੇਜ਼ ਹੁੰਦਾ ਹੈ।
> inspector ਬਾਰੇ ਹੋਰ ਪੜ੍ਹੋ [ਇੱਥੇ](https://github.com/modelcontextprotocol/inspector)।

**ਡਿਸਕਲੇਮਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਤੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੇ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪ੍ਰੋਫੈਸ਼ਨਲ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।