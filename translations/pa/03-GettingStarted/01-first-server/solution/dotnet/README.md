<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:55:51+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਸੈਂਪਲ ਨੂੰ ਚਲਾਉਣਾ

## -1- Dependencies ਇੰਸਟਾਲ ਕਰੋ

```bash
dotnet restore
```

## -3- ਸੈਂਪਲ ਚਲਾਓ

```bash
dotnet run
```

## -4- ਸੈਂਪਲ ਦੀ ਟੈਸਟਿੰਗ ਕਰੋ

ਜਦੋਂ ਸਰਵਰ ਇੱਕ ਟਰਮੀਨਲ ਵਿੱਚ ਚੱਲ ਰਿਹਾ ਹੋਵੇ, ਦੂਜਾ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

ਇਸ ਨਾਲ ਇੱਕ ਵੈੱਬ ਸਰਵਰ ਚੱਲੇਗਾ ਜਿਸ ਵਿੱਚ ਇੱਕ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਹੋਵੇਗਾ ਜੋ ਤੁਹਾਨੂੰ ਸੈਂਪਲ ਦੀ ਟੈਸਟਿੰਗ ਕਰਨ ਦੀ ਆਗਿਆ ਦੇਵੇਗਾ।

ਜਦੋਂ ਸਰਵਰ ਕਨੈਕਟ ਹੋ ਜਾਵੇ: 

- ਟੂਲਜ਼ ਦੀ ਲਿਸਟ ਬਣਾਉਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ ਅਤੇ `add` ਕਮਾਂਡ ਚਲਾਓ, 2 ਅਤੇ 4 ਦੇ ਆਰਗਯੂਮੈਂਟ ਦੇ ਕੇ, ਨਤੀਜੇ ਵਿੱਚ 6 ਦੇਖਣਾ ਚਾਹੀਦਾ ਹੈ।
- resources ਅਤੇ resource template 'ਤੇ ਜਾਓ ਅਤੇ "greeting" ਕਾਲ ਕਰੋ, ਇੱਕ ਨਾਮ ਟਾਈਪ ਕਰੋ ਅਤੇ ਤੁਹਾਨੂੰ ਦਿੱਤੇ ਨਾਮ ਨਾਲ ਇੱਕ greeting ਦੇਖਣ ਨੂੰ ਮਿਲੇਗੀ।

### CLI ਮੋਡ ਵਿੱਚ ਟੈਸਟਿੰਗ

ਤੁਸੀਂ ਇਸਨੂੰ ਸਿੱਧਾ CLI ਮੋਡ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾ ਕੇ ਸ਼ੁਰੂ ਕਰ ਸਕਦੇ ਹੋ:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

ਇਸ ਨਾਲ ਸਰਵਰ ਵਿੱਚ ਉਪਲਬਧ ਸਾਰੇ ਟੂਲਜ਼ ਦੀ ਲਿਸਟ ਮਿਲੇਗੀ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਦੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:

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

ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਮਿਲੇਗਾ:

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
> CLI ਮੋਡ ਵਿੱਚ inspector ਚਲਾਉਣਾ ਬ੍ਰਾਊਜ਼ਰ ਨਾਲੋਂ ਜ਼ਿਆਦਾ ਤੇਜ਼ ਹੁੰਦਾ ਹੈ।
> inspector ਬਾਰੇ ਹੋਰ ਪੜ੍ਹੋ [ਇੱਥੇ](https://github.com/modelcontextprotocol/inspector)।

**ਡਿਸਕਲੇਮਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਥਿਰਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਣ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।