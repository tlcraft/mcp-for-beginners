<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f27f8c14853621d982185e6bbdd1dc6",
  "translation_date": "2025-05-17T13:21:56+00:00",
  "source_file": "03-GettingStarted/samples/javascript/README.md",
  "language_code": "pa"
}
-->
# ਨਮੂਨਾ

ਇਹ MCP ਸਰਵਰ ਲਈ ਇੱਕ ਜਾਵਾਸਕ੍ਰਿਪਟ ਨਮੂਨਾ ਹੈ

ਇਹ ਹੈ ਕਿ ਇਸ ਦਾ ਕੈਲਕੂਲੇਟਰ ਹਿੱਸਾ ਕਿਸ ਤਰ੍ਹਾਂ ਦਿਖਦਾ ਹੈ:

```javascript
// Define calculator tools for each operation
server.tool(
  "add",
  {
    a: z.number(),
    b: z.number()
  },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

server.tool(
  "subtract",
  {
    a: z.number(),
    b: z.number()
  },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a - b) }]
  })
);

server.tool(
  "multiply",
  {
    a: z.number(),
    b: z.number()
  },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a * b) }]
  })
);

server.tool(
  "divide",
  {
    a: z.number(),
    b: z.number()
  },
  async ({ a, b }) => {
    if (b === 0) {
      return {
        content: [{ type: "text", text: "Error: Cannot divide by zero" }],
        isError: true
      };
    }
    return {
      content: [{ type: "text", text: String(a / b) }]
    };
  }
);
```

## ਇੰਸਟਾਲ ਕਰੋ

ਹੇਠਾਂ ਦਿੱਤੇ ਕਮਾਂਡ ਚਲਾਓ:

```bash
npm install
```

## ਚਲਾਓ

```bash
npm start
```

**ਅਸਵੀਕਤੀ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦਾ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਜ਼ਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਮਾਨਵ ਦੁਆਰਾ ਕੀਤਾ ਗਿਆ ਪੇਸ਼ੇਵਰ ਅਨੁਵਾਦ ਸਿਫਾਰਸ਼ੀ ਹੈ। ਅਨੁਵਾਦਿਤ ਕੀਤੇ ਗਏ ਦਸਤਾਵੇਜ਼ ਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਸਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਹੋਣ ਵਾਲੀ ਕਿਸੇ ਵੀ ਗਲਤ ਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।