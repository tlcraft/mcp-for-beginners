<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:17:04+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਸੈਂਪਲ ਨੂੰ ਚਲਾਉਣਾ

## -1- Dependencies ਇੰਸਟਾਲ ਕਰੋ

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

ਇਸ ਨਾਲ ਇੱਕ ਵੈੱਬ ਸਰਵਰ ਚੱਲੇਗਾ ਜਿਸ ਵਿੱਚ ਇੱਕ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਹੋਵੇਗਾ ਜੋ ਤੁਹਾਨੂੰ ਸੈਂਪਲ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦੇਵੇਗਾ।

> ਪੱਕਾ ਕਰੋ ਕਿ **Streamable HTTP** ਟਰਾਂਸਪੋਰਟ ਟਾਈਪ ਵਜੋਂ ਚੁਣਿਆ ਗਿਆ ਹੈ, ਅਤੇ URL `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add` ਹੈ, ਜਿਸ ਵਿੱਚ args 2 ਅਤੇ 4 ਹਨ, ਤਾਂ ਨਤੀਜੇ ਵਿੱਚ 6 ਦੇਖਣ ਨੂੰ ਮਿਲੇਗਾ।  
> - resources ਅਤੇ resource template 'ਤੇ ਜਾਓ ਅਤੇ "greeting" ਕਾਲ ਕਰੋ, ਕਿਸੇ ਨਾਮ ਨੂੰ ਟਾਈਪ ਕਰੋ ਅਤੇ ਤੁਹਾਨੂੰ ਉਹਨਾਂ ਨਾਮਾਂ ਨਾਲ ਸਲਾਮ ਮਿਲੇਗਾ ਜੋ ਤੁਸੀਂ ਦਿੱਤੇ ਹਨ।

### CLI ਮੋਡ ਵਿੱਚ ਜਾਂਚ

ਤੁਸੀਂ ਸਿੱਧਾ CLI ਮੋਡ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾ ਕੇ ਇਹ ਲਾਂਚ ਕਰ ਸਕਦੇ ਹੋ:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

ਇਸ ਨਾਲ ਸਰਵਰ ਵਿੱਚ ਉਪਲਬਧ ਸਾਰੇ ਟੂਲ ਲਿਸਟ ਹੋ ਜਾਣਗੇ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:

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
> CLI ਮੋਡ ਵਿੱਚ ispector ਚਲਾਉਣਾ ਬ੍ਰਾਊਜ਼ਰ ਨਾਲੋਂ ਆਮ ਤੌਰ ਤੇ ਬਹੁਤ ਤੇਜ਼ ਹੁੰਦਾ ਹੈ।  
> ispector ਬਾਰੇ ਹੋਰ ਪੜ੍ਹੋ [ਇੱਥੇ](https://github.com/modelcontextprotocol/inspector)।

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਸ ਦਸਤਾਵੇਜ਼ ਦਾ ਅਨੁਵਾਦ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਯਤਨਸ਼ੀਲ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਣਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਣ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੇ ਇਸਤੇਮਾਲ ਤੋਂ ਉਤਪੰਨ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।