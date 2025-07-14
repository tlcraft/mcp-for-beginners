<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:19:49+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਸੈਂਪਲ ਨੂੰ ਚਲਾਉਣਾ

## -1- ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ

```bash
npm install
```

## -3- ਸੈਂਪਲ ਚਲਾਓ

```bash
npm run build
```

## -4- ਸੈਂਪਲ ਦੀ ਜਾਂਚ ਕਰੋ

ਜਦੋਂ ਸਰਵਰ ਇੱਕ ਟਰਮੀਨਲ ਵਿੱਚ ਚੱਲ ਰਿਹਾ ਹੋਵੇ, ਤਾਂ ਦੂਜਾ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

```bash
npm run inspector
```

ਇਸ ਨਾਲ ਇੱਕ ਵੈੱਬ ਸਰਵਰ ਸ਼ੁਰੂ ਹੋਵੇਗਾ ਜਿਸ ਵਿੱਚ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਹੋਵੇਗਾ ਜੋ ਤੁਹਾਨੂੰ ਸੈਂਪਲ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦੇਵੇਗਾ।

ਜਦੋਂ ਸਰਵਰ ਕਨੈਕਟ ਹੋ ਜਾਵੇ:

- ਟੂਲਜ਼ ਦੀ ਲਿਸਟ ਬਣਾਉਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ ਅਤੇ `add` ਕਮਾਂਡ ਚਲਾਓ, ਜਿਸ ਵਿੱਚ 2 ਅਤੇ 4 ਆਰਗੁਮੈਂਟ ਹਨ, ਨਤੀਜੇ ਵਿੱਚ 6 ਆਉਣਾ ਚਾਹੀਦਾ ਹੈ।
- resources ਅਤੇ resource template ਵਿੱਚ ਜਾਓ ਅਤੇ "greeting" ਕਾਲ ਕਰੋ, ਇੱਕ ਨਾਮ ਟਾਈਪ ਕਰੋ ਅਤੇ ਤੁਹਾਨੂੰ ਉਸ ਨਾਮ ਨਾਲ ਇੱਕ ਸਲਾਮ ਮਿਲੇਗਾ ਜੋ ਤੁਸੀਂ ਦਿੱਤਾ ਹੈ।

### CLI ਮੋਡ ਵਿੱਚ ਟੈਸਟਿੰਗ

ਜੋ ਇੰਸਪੈਕਟਰ ਤੁਸੀਂ ਚਲਾਇਆ ਹੈ, ਉਹ ਅਸਲ ਵਿੱਚ ਇੱਕ Node.js ਐਪ ਹੈ ਅਤੇ `mcp dev` ਇਸ ਦਾ ਇੱਕ wrapper ਹੈ।

- ਸਰਵਰ ਨੂੰ ਕਮਾਂਡ `npm run build` ਨਾਲ ਸ਼ੁਰੂ ਕਰੋ।

- ਇੱਕ ਵੱਖਰੇ ਟਰਮੀਨਲ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    ਇਸ ਨਾਲ ਸਰਵਰ ਵਿੱਚ ਉਪਲਬਧ ਸਾਰੇ ਟੂਲਜ਼ ਦੀ ਲਿਸਟ ਆਵੇਗੀ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ:

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

- ਇੱਕ ਟੂਲ ਟਾਈਪ ਨੂੰ ਕਾਲ ਕਰਨ ਲਈ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਟਾਈਪ ਕਰੋ:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤਾ ਨਤੀਜਾ ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> ਆਮ ਤੌਰ 'ਤੇ ਇੰਸਪੈਕਟਰ ਨੂੰ CLI ਮੋਡ ਵਿੱਚ ਚਲਾਉਣਾ ਬ੍ਰਾਊਜ਼ਰ ਵਿੱਚ ਚਲਾਉਣ ਨਾਲੋਂ ਕਾਫੀ ਤੇਜ਼ ਹੁੰਦਾ ਹੈ।
> ਇੰਸਪੈਕਟਰ ਬਾਰੇ ਹੋਰ ਪੜ੍ਹੋ [ਇੱਥੇ](https://github.com/modelcontextprotocol/inspector)।

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।