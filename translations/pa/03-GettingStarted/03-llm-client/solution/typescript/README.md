<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:54:43+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਨਮੂਨੇ ਨੂੰ ਚਲਾਉਣਾ

ਇਹ ਨਮੂਨਾ ਗਾਹਕ 'ਤੇ ਇੱਕ LLM ਰੱਖਣ ਨੂੰ ਸ਼ਾਮਲ ਕਰਦਾ ਹੈ। LLM ਨੂੰ ਚਲਾਉਣ ਲਈ ਤੁਹਾਨੂੰ ਜਾਂ ਤਾਂ ਇਸਨੂੰ Codespaces ਵਿੱਚ ਚਲਾਉਣਾ ਪਵੇਗਾ ਜਾਂ ਫਿਰ GitHub ਵਿੱਚ ਇੱਕ ਪ੍ਰਸਨਲ ਐਕਸੈਸ ਟੋਕਨ ਸੈਟਅਪ ਕਰਨਾ ਪਵੇਗਾ।

## -1- Dependencies ਇੰਸਟਾਲ ਕਰੋ

```bash
npm install
```

## -3- ਸਰਵਰ ਚਲਾਓ

```bash
npm run build
```

## -4- ਕਲਾਇੰਟ ਚਲਾਓ

```sh
npm run client
```

ਤੁਹਾਨੂੰ ਕੁਝ ਇਸ ਤਰ੍ਹਾਂ ਦਾ ਨਤੀਜਾ ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**ਅਸ्वीਕਰਨ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਜਾਣੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁੱਚਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੌਜੂਦ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਨਾਜ਼ੁਕ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।