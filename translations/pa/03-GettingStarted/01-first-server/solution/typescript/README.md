<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:22:43+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਨਮੂਨੇ ਨੂੰ ਚਲਾਉਣਾ

ਤੁਹਾਨੂੰ `uv` ਇੰਸਟਾਲ ਕਰਨ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ ਪਰ ਇਹ ਲਾਜ਼ਮੀ ਨਹੀਂ ਹੈ, ਵੇਖੋ [ਨਿਰਦੇਸ਼](https://docs.astral.sh/uv/#highlights)

## -1- ਨਿਰਭਰਤਾਵਾਂ ਇੰਸਟਾਲ ਕਰੋ

```bash
npm install
```

## -3- ਨਮੂਨਾ ਚਲਾਓ

```bash
npm run build
```

## -4- ਨਮੂਨੇ ਦੀ ਜਾਂਚ ਕਰੋ

ਜਦੋਂ ਸਰਵਰ ਇੱਕ ਟਰਮੀਨਲ ਵਿੱਚ ਚੱਲ ਰਿਹਾ ਹੋਵੇ, ਤਾਂ ਦੂਜੇ ਟਰਮੀਨਲ ਵਿੱਚ ਜਾਓ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

```bash
npm run inspector
```

ਇਸ ਨਾਲ ਇੱਕ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਦੇ ਨਾਲ ਵੈੱਬ ਸਰਵਰ ਸ਼ੁਰੂ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ ਜੋ ਤੁਹਾਨੂੰ ਨਮੂਨੇ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।

ਜਦੋਂ ਸਰਵਰ ਕਨੈਕਟ ਹੋ ਜਾਵੇ:

- ਸੰਦਾਂ ਦੀ ਸੂਚੀ ਕਰਨ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ ਅਤੇ `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` ਇਸਦਾ ਇੱਕ ਵ੍ਰੈਪਰ ਹੈ।

ਤੁਸੀਂ ਇਸਨੂੰ CLI ਮੋਡ ਵਿੱਚ ਸਿੱਧਾ ਚਲਾ ਸਕਦੇ ਹੋ ਹੇਠਾਂ ਦਿੱਤੇ ਕਮਾਂਡ ਚਲਾ ਕੇ:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

ਇਹ ਸਰਵਰ ਵਿੱਚ ਉਪਲਬਧ ਸਾਰੇ ਸੰਦਾਂ ਦੀ ਸੂਚੀ ਦਿਖਾਵੇਗਾ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਆਉਟਪੁੱਟ ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

ਇੱਕ ਸੰਦ ਨੂੰ ਸੱਦਣ ਲਈ ਟਾਈਪ ਕਰੋ:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਆਉਟਪੁੱਟ ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ:

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
> ਆਮ ਤੌਰ 'ਤੇ CLI ਮੋਡ ਵਿੱਚ ਇੰਸਪੈਕਟਰ ਨੂੰ ਚਲਾਉਣਾ ਬਰਾਊਜ਼ਰ ਵਿੱਚ ਚਲਾਉਣ ਨਾਲੋਂ ਕਾਫ਼ੀ ਤੇਜ਼ ਹੁੰਦਾ ਹੈ।
> ਇੰਸਪੈਕਟਰ ਬਾਰੇ ਹੋਰ ਪੜ੍ਹੋ [ਇਥੇ](https://github.com/modelcontextprotocol/inspector)।

**ਅਸਵੀਕਰਤੀ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਯਤਨਸ਼ੀਲ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਦਿਓ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁਣਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸ ਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੇ ਕਿਸੇ ਵੀ ਗਲਤਫਹਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।