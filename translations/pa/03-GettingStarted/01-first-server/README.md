<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fa635ae747c9b4d5c2f61c6c46cb695f",
  "translation_date": "2025-07-17T18:18:41+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "pa"
}
-->
# MCP ਨਾਲ ਸ਼ੁਰੂਆਤ

Model Context Protocol (MCP) ਨਾਲ ਤੁਹਾਡੇ ਪਹਿਲੇ ਕਦਮਾਂ ਵਿੱਚ ਤੁਹਾਡਾ ਸਵਾਗਤ ਹੈ! ਚਾਹੇ ਤੁਸੀਂ MCP ਵਿੱਚ ਨਵੇਂ ਹੋ ਜਾਂ ਆਪਣੀ ਸਮਝ ਨੂੰ ਹੋਰ ਗਹਿਰਾ ਕਰਨਾ ਚਾਹੁੰਦੇ ਹੋ, ਇਹ ਗਾਈਡ ਤੁਹਾਨੂੰ ਜਰੂਰੀ ਸੈਟਅਪ ਅਤੇ ਵਿਕਾਸ ਪ੍ਰਕਿਰਿਆ ਵਿੱਚ ਲੈ ਕੇ ਚਲੇਗੀ। ਤੁਸੀਂ ਜਾਣੋਗੇ ਕਿ MCP ਕਿਵੇਂ AI ਮਾਡਲਾਂ ਅਤੇ ਐਪਲੀਕੇਸ਼ਨਾਂ ਦੇ ਵਿਚਕਾਰ ਬਿਨਾਂ ਰੁਕਾਵਟ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਨੂੰ ਯਕੀਨੀ ਬਣਾਉਂਦਾ ਹੈ, ਅਤੇ ਕਿਵੇਂ ਆਪਣਾ ਵਾਤਾਵਰਣ ਤੇਜ਼ੀ ਨਾਲ ਤਿਆਰ ਕਰਕੇ MCP-ਚਲਿਤ ਹੱਲਾਂ ਨੂੰ ਬਣਾਉਣਾ ਅਤੇ ਟੈਸਟ ਕਰਨਾ ਹੈ।

> TLDR; ਜੇ ਤੁਸੀਂ AI ਐਪ ਬਣਾਉਂਦੇ ਹੋ, ਤਾਂ ਤੁਹਾਨੂੰ ਪਤਾ ਹੈ ਕਿ ਤੁਸੀਂ ਆਪਣੇ LLM (ਵੱਡਾ ਭਾਸ਼ਾ ਮਾਡਲ) ਵਿੱਚ ਟੂਲ ਅਤੇ ਹੋਰ ਸਰੋਤ ਜੋੜ ਸਕਦੇ ਹੋ, ਤਾਂ ਜੋ LLM ਹੋਰ ਗਿਆਨਵਾਨ ਬਣ ਜਾਵੇ। ਪਰ ਜੇ ਤੁਸੀਂ ਉਹ ਟੂਲ ਅਤੇ ਸਰੋਤ ਸਰਵਰ 'ਤੇ ਰੱਖਦੇ ਹੋ, ਤਾਂ ਐਪ ਅਤੇ ਸਰਵਰ ਦੀਆਂ ਸਮਰੱਥਾਵਾਂ ਕਿਸੇ ਵੀ ਕਲਾਇੰਟ ਦੁਆਰਾ LLM ਹੋਵੇ ਜਾਂ ਨਾ ਹੋਵੇ ਵਰਤੀ ਜਾ ਸਕਦੀਆਂ ਹਨ।

## ਝਲਕ

ਇਸ ਪਾਠ ਵਿੱਚ MCP ਵਾਤਾਵਰਣ ਸੈਟਅਪ ਕਰਨ ਅਤੇ ਆਪਣੀਆਂ ਪਹਿਲੀਆਂ MCP ਐਪਲੀਕੇਸ਼ਨਾਂ ਬਣਾਉਣ ਲਈ ਪ੍ਰਯੋਗਿਕ ਮਾਰਗਦਰਸ਼ਨ ਦਿੱਤਾ ਗਿਆ ਹੈ। ਤੁਸੀਂ ਜਰੂਰੀ ਟੂਲ ਅਤੇ ਫਰੇਮਵਰਕ ਸੈਟਅਪ ਕਰਨਾ, ਬੁਨਿਆਦੀ MCP ਸਰਵਰ ਬਣਾਉਣਾ, ਹੋਸਟ ਐਪਲੀਕੇਸ਼ਨ ਬਣਾਉਣਾ ਅਤੇ ਆਪਣੀਆਂ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਦੀ ਜਾਂਚ ਕਰਨਾ ਸਿੱਖੋਗੇ।

Model Context Protocol (MCP) ਇੱਕ ਖੁੱਲ੍ਹਾ ਪ੍ਰੋਟੋਕੋਲ ਹੈ ਜੋ ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ LLMs ਨੂੰ ਸੰਦਰਭ ਪ੍ਰਦਾਨ ਕਰਨ ਦਾ ਇੱਕ ਮਿਆਰੀਕ੍ਰਿਤ ਤਰੀਕਾ ਦਿੰਦਾ ਹੈ। MCP ਨੂੰ AI ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ USB-C ਪੋਰਟ ਵਾਂਗ ਸੋਚੋ - ਇਹ AI ਮਾਡਲਾਂ ਨੂੰ ਵੱਖ-ਵੱਖ ਡਾਟਾ ਸਰੋਤਾਂ ਅਤੇ ਟੂਲਾਂ ਨਾਲ ਜੁੜਨ ਦਾ ਇੱਕ ਮਿਆਰੀ ਤਰੀਕਾ ਦਿੰਦਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੀ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- C#, Java, Python, TypeScript, ਅਤੇ JavaScript ਵਿੱਚ MCP ਲਈ ਵਿਕਾਸ ਵਾਤਾਵਰਣ ਸੈਟਅਪ ਕਰਨਾ
- ਕਸਟਮ ਫੀਚਰਾਂ (ਸਰੋਤ, ਪ੍ਰਾਂਪਟ, ਅਤੇ ਟੂਲ) ਨਾਲ ਬੁਨਿਆਦੀ MCP ਸਰਵਰ ਬਣਾਉਣਾ ਅਤੇ ਤੈਨਾਤ ਕਰਨਾ
- MCP ਸਰਵਰਾਂ ਨਾਲ ਜੁੜਨ ਵਾਲੀਆਂ ਹੋਸਟ ਐਪਲੀਕੇਸ਼ਨਾਂ ਬਣਾਉਣਾ
- MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਦੀ ਜਾਂਚ ਅਤੇ ਡੀਬੱਗ ਕਰਨਾ

## ਆਪਣਾ MCP ਵਾਤਾਵਰਣ ਸੈਟਅਪ ਕਰਨਾ

MCP ਨਾਲ ਕੰਮ ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਆਪਣਾ ਵਿਕਾਸ ਵਾਤਾਵਰਣ ਤਿਆਰ ਕਰਨਾ ਅਤੇ ਬੁਨਿਆਦੀ ਵਰਕਫਲੋ ਨੂੰ ਸਮਝਣਾ ਜਰੂਰੀ ਹੈ। ਇਹ ਹਿੱਸਾ ਤੁਹਾਨੂੰ ਸ਼ੁਰੂਆਤੀ ਸੈਟਅਪ ਕਦਮਾਂ ਵਿੱਚ ਮਦਦ ਕਰੇਗਾ ਤਾਂ ਜੋ MCP ਨਾਲ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਸ਼ੁਰੂਆਤ ਹੋ ਸਕੇ।

### ਲੋੜੀਂਦੇ ਚੀਜ਼ਾਂ

MCP ਵਿਕਾਸ ਵਿੱਚ ਡੁੱਬਣ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਹਾਡੇ ਕੋਲ ਹੈ:

- **ਵਿਕਾਸ ਵਾਤਾਵਰਣ**: ਆਪਣੀ ਚੁਣੀ ਹੋਈ ਭਾਸ਼ਾ ਲਈ (C#, Java, Python, TypeScript, ਜਾਂ JavaScript)
- **IDE/ਸੰਪਾਦਕ**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, ਜਾਂ ਕੋਈ ਵੀ ਆਧੁਨਿਕ ਕੋਡ ਸੰਪਾਦਕ
- **ਪੈਕੇਜ ਮੈਨੇਜਰ**: NuGet, Maven/Gradle, pip, ਜਾਂ npm/yarn
- **API ਕੁੰਜੀਆਂ**: ਜੇ ਤੁਸੀਂ ਆਪਣੇ ਹੋਸਟ ਐਪਲੀਕੇਸ਼ਨਾਂ ਵਿੱਚ ਕਿਸੇ AI ਸੇਵਾ ਦੀ ਵਰਤੋਂ ਕਰਨ ਜਾ ਰਹੇ ਹੋ

## ਬੁਨਿਆਦੀ MCP ਸਰਵਰ ਢਾਂਚਾ

ਇੱਕ MCP ਸਰਵਰ ਆਮ ਤੌਰ 'ਤੇ ਸ਼ਾਮਲ ਹੁੰਦਾ ਹੈ:

- **ਸਰਵਰ ਸੰਰਚਨਾ**: ਪੋਰਟ, ਪ੍ਰਮਾਣਿਕਤਾ, ਅਤੇ ਹੋਰ ਸੈਟਿੰਗਜ਼ ਸੈਟ ਕਰਨਾ
- **ਸਰੋਤ**: LLMs ਲਈ ਉਪਲਬਧ ਡਾਟਾ ਅਤੇ ਸੰਦਰਭ
- **ਟੂਲ**: ਉਹ ਫੰਕਸ਼ਨ ਜੋ ਮਾਡਲ ਕਾਲ ਕਰ ਸਕਦੇ ਹਨ
- **ਪ੍ਰਾਂਪਟ**: ਲਿਖਤ ਬਣਾਉਣ ਜਾਂ ਢਾਂਚਾ ਤਿਆਰ ਕਰਨ ਲਈ ਟੈਮਪਲੇਟ

ਇੱਥੇ TypeScript ਵਿੱਚ ਇੱਕ ਸਧਾਰਣ ਉਦਾਹਰਨ ਦਿੱਤੀ ਗਈ ਹੈ:

```typescript
import { Server, Tool, Resource } from "@modelcontextprotocol/typescript-server-sdk";

// Create a new MCP server
const server = new Server({
  port: 3000,
  name: "Example MCP Server",
  version: "1.0.0"
});

// Register a tool
server.registerTool({
  name: "calculator",
  description: "Performs basic calculations",
  parameters: {
    expression: {
      type: "string",
      description: "The math expression to evaluate"
    }
  },
  handler: async (params) => {
    const result = eval(params.expression);
    return { result };
  }
});

// Start the server
server.start();
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- MCP TypeScript SDK ਤੋਂ ਜਰੂਰੀ ਕਲਾਸਾਂ ਨੂੰ ਇੰਪੋਰਟ ਕੀਤਾ।
- ਇੱਕ ਨਵਾਂ MCP ਸਰਵਰ ਇੰਸਟੈਂਸ ਬਣਾਇਆ ਅਤੇ ਸੰਰਚਿਤ ਕੀਤਾ।
- ਇੱਕ ਕਸਟਮ ਟੂਲ (`calculator`) ਨੂੰ ਹੈਂਡਲਰ ਫੰਕਸ਼ਨ ਨਾਲ ਰਜਿਸਟਰ ਕੀਤਾ।
- ਆਉਣ ਵਾਲੀਆਂ MCP ਬੇਨਤੀਆਂ ਲਈ ਸਰਵਰ ਨੂੰ ਸੁਣਨਾ ਸ਼ੁਰੂ ਕੀਤਾ।

## ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ

ਆਪਣਾ MCP ਸਰਵਰ ਟੈਸਟ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਉਪਲਬਧ ਟੂਲਾਂ ਅਤੇ ਡੀਬੱਗਿੰਗ ਲਈ ਵਧੀਆ ਅਭਿਆਸਾਂ ਨੂੰ ਸਮਝਣਾ ਜਰੂਰੀ ਹੈ। ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਟੈਸਟਿੰਗ ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ ਕਿ ਤੁਹਾਡਾ ਸਰਵਰ ਉਮੀਦਾਂ ਅਨੁਸਾਰ ਕੰਮ ਕਰਦਾ ਹੈ ਅਤੇ ਤੁਹਾਨੂੰ ਸਮੱਸਿਆਵਾਂ ਨੂੰ ਤੇਜ਼ੀ ਨਾਲ ਪਛਾਣਨ ਅਤੇ ਹੱਲ ਕਰਨ ਵਿੱਚ ਮਦਦ ਕਰਦੀ ਹੈ। ਹੇਠਾਂ ਦਿੱਤਾ ਗਿਆ ਹਿੱਸਾ ਤੁਹਾਡੇ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਦੀ ਜਾਂਚ ਲਈ ਸਿਫਾਰਸ਼ੀ ਤਰੀਕਿਆਂ ਨੂੰ ਦਰਸਾਉਂਦਾ ਹੈ।

MCP ਤੁਹਾਡੇ ਸਰਵਰਾਂ ਦੀ ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ ਵਿੱਚ ਮਦਦ ਕਰਨ ਲਈ ਟੂਲ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ:

- **Inspector tool**, ਇਹ ਗ੍ਰਾਫਿਕਲ ਇੰਟਰਫੇਸ ਤੁਹਾਨੂੰ ਆਪਣੇ ਸਰਵਰ ਨਾਲ ਜੁੜਨ ਅਤੇ ਆਪਣੇ ਟੂਲ, ਪ੍ਰਾਂਪਟ ਅਤੇ ਸਰੋਤਾਂ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।
- **curl**, ਤੁਸੀਂ curl ਜਾਂ ਹੋਰ ਕਮਾਂਡ ਲਾਈਨ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਵੀ ਆਪਣੇ ਸਰਵਰ ਨਾਲ ਜੁੜ ਸਕਦੇ ਹੋ ਜੋ HTTP ਕਮਾਂਡਾਂ ਬਣਾਉਂਦੇ ਅਤੇ ਚਲਾਉਂਦੇ ਹਨ।

### MCP Inspector ਦੀ ਵਰਤੋਂ

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) ਇੱਕ ਵਿਜ਼ੂਅਲ ਟੈਸਟਿੰਗ ਟੂਲ ਹੈ ਜੋ ਤੁਹਾਡੀ ਮਦਦ ਕਰਦਾ ਹੈ:

1. **ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਦੀ ਖੋਜ**: ਉਪਲਬਧ ਸਰੋਤ, ਟੂਲ, ਅਤੇ ਪ੍ਰਾਂਪਟਾਂ ਨੂੰ ਆਪਣੇ ਆਪ ਪਤਾ ਲਗਾਓ
2. **ਟੂਲ ਐਗਜ਼ੀਕਿਊਸ਼ਨ ਦੀ ਜਾਂਚ**: ਵੱਖ-ਵੱਖ ਪੈਰਾਮੀਟਰਾਂ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ ਅਤੇ ਤੁਰੰਤ ਜਵਾਬ ਵੇਖੋ
3. **ਸਰਵਰ ਮੈਟਾਡੇਟਾ ਵੇਖੋ**: ਸਰਵਰ ਜਾਣਕਾਰੀ, ਸਕੀਮਾਂ, ਅਤੇ ਸੰਰਚਨਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰੋ

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

ਜਦੋਂ ਤੁਸੀਂ ਉਪਰੋਕਤ ਕਮਾਂਡਾਂ ਚਲਾਉਂਦੇ ਹੋ, MCP Inspector ਤੁਹਾਡੇ ਬ੍ਰਾਊਜ਼ਰ ਵਿੱਚ ਇੱਕ ਸਥਾਨਕ ਵੈੱਬ ਇੰਟਰਫੇਸ ਖੋਲ੍ਹੇਗਾ। ਤੁਸੀਂ ਆਪਣੇ ਰਜਿਸਟਰਡ MCP ਸਰਵਰਾਂ, ਉਨ੍ਹਾਂ ਦੇ ਉਪਲਬਧ ਟੂਲਾਂ, ਸਰੋਤਾਂ ਅਤੇ ਪ੍ਰਾਂਪਟਾਂ ਨੂੰ ਡੈਸ਼ਬੋਰਡ 'ਤੇ ਵੇਖ ਸਕਦੇ ਹੋ। ਇਹ ਇੰਟਰਫੇਸ ਤੁਹਾਨੂੰ ਟੂਲ ਐਗਜ਼ੀਕਿਊਸ਼ਨ ਦੀ ਇੰਟਰਐਕਟਿਵ ਜਾਂਚ ਕਰਨ, ਸਰਵਰ ਮੈਟਾਡੇਟਾ ਦੀ ਜਾਂਚ ਕਰਨ ਅਤੇ ਤੁਰੰਤ ਜਵਾਬ ਵੇਖਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਤੁਹਾਡੇ MCP ਸਰਵਰ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਦੀ ਪੁਸ਼ਟੀ ਅਤੇ ਡੀਬੱਗਿੰਗ ਆਸਾਨ ਹੋ ਜਾਂਦੀ ਹੈ।

ਇਹ ਇਸ ਤਰ੍ਹਾਂ ਦਿਖਾਈ ਦੇ ਸਕਦਾ ਹੈ:

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.pa.png)

## ਆਮ ਸੈਟਅਪ ਸਮੱਸਿਆਵਾਂ ਅਤੇ ਹੱਲ

| ਸਮੱਸਿਆ | ਸੰਭਾਵਿਤ ਹੱਲ |
|-------|-------------------|
| ਕਨੈਕਸ਼ਨ ਰੱਦ ਹੋ ਗਿਆ | ਜਾਂਚੋ ਕਿ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ ਅਤੇ ਪੋਰਟ ਸਹੀ ਹੈ |
| ਟੂਲ ਐਗਜ਼ੀਕਿਊਸ਼ਨ ਵਿੱਚ ਗਲਤੀਆਂ | ਪੈਰਾਮੀਟਰ ਵੈਰੀਫਿਕੇਸ਼ਨ ਅਤੇ ਗਲਤੀ ਸੰਭਾਲ ਦੀ ਸਮੀਖਿਆ ਕਰੋ |
| ਪ੍ਰਮਾਣਿਕਤਾ ਅਸਫਲ | API ਕੁੰਜੀਆਂ ਅਤੇ ਅਧਿਕਾਰਾਂ ਦੀ ਜਾਂਚ ਕਰੋ |
| ਸਕੀਮਾ ਵੈਰੀਫਿਕੇਸ਼ਨ ਗਲਤੀਆਂ | ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਪੈਰਾਮੀਟਰ ਪਰਿਭਾਸ਼ਿਤ ਸਕੀਮਾ ਨਾਲ ਮੇਲ ਖਾਂਦੇ ਹਨ |
| ਸਰਵਰ ਸ਼ੁਰੂ ਨਹੀਂ ਹੋ ਰਿਹਾ | ਪੋਰਟ ਟਕਰਾਅ ਜਾਂ ਗੁੰਮ ਹੋਈਆਂ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਦੀ ਜਾਂਚ ਕਰੋ |
| CORS ਗਲਤੀਆਂ | ਕ੍ਰਾਸ-ਓਰੀਜਿਨ ਬੇਨਤੀਆਂ ਲਈ ਸਹੀ CORS ਹੈਡਰ ਸੰਰਚਿਤ ਕਰੋ |
| ਪ੍ਰਮਾਣਿਕਤਾ ਸਮੱਸਿਆਵਾਂ | ਟੋਕਨ ਦੀ ਮਿਆਦ ਅਤੇ ਅਧਿਕਾਰਾਂ ਦੀ ਜਾਂਚ ਕਰੋ |

## ਸਥਾਨਕ ਵਿਕਾਸ

ਸਥਾਨਕ ਵਿਕਾਸ ਅਤੇ ਟੈਸਟਿੰਗ ਲਈ, ਤੁਸੀਂ ਆਪਣੇ ਮਸ਼ੀਨ 'ਤੇ ਸਿੱਧਾ MCP ਸਰਵਰ ਚਲਾ ਸਕਦੇ ਹੋ:

1. **ਸਰਵਰ ਪ੍ਰਕਿਰਿਆ ਸ਼ੁਰੂ ਕਰੋ**: ਆਪਣੀ MCP ਸਰਵਰ ਐਪਲੀਕੇਸ਼ਨ ਚਲਾਓ
2. **ਨੈੱਟਵਰਕਿੰਗ ਸੰਰਚਿਤ ਕਰੋ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਰਵਰ ਉਮੀਦ ਕੀਤੇ ਪੋਰਟ 'ਤੇ ਪਹੁੰਚਯੋਗ ਹੈ
3. **ਕਲਾਇੰਟਾਂ ਨੂੰ ਜੁੜੋ**: ਸਥਾਨਕ ਕਨੈਕਸ਼ਨ URL ਵਰਗੇ `http://localhost:3000` ਦੀ ਵਰਤੋਂ ਕਰੋ

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## ਆਪਣਾ ਪਹਿਲਾ MCP ਸਰਵਰ ਬਣਾਉਣਾ

ਅਸੀਂ ਪਹਿਲਾਂ [Core concepts](/01-CoreConcepts/README.md) ਬਾਰੇ ਪਾਠ ਕਰ ਚੁੱਕੇ ਹਾਂ, ਹੁਣ ਸਮਾਂ ਹੈ ਉਸ ਗਿਆਨ ਨੂੰ ਅਮਲ ਵਿੱਚ ਲਿਆਉਣ ਦਾ।

### ਸਰਵਰ ਕੀ ਕਰ ਸਕਦਾ ਹੈ

ਕੋਡ ਲਿਖਣ ਤੋਂ ਪਹਿਲਾਂ, ਆਓ ਯਾਦ ਕਰੀਏ ਕਿ ਇੱਕ ਸਰਵਰ ਕੀ ਕਰ ਸਕਦਾ ਹੈ:

ਇੱਕ MCP ਸਰਵਰ ਉਦਾਹਰਨ ਵਜੋਂ:

- ਸਥਾਨਕ ਫਾਈਲਾਂ ਅਤੇ ਡੇਟਾਬੇਸਾਂ ਤੱਕ ਪਹੁੰਚ ਕਰ ਸਕਦਾ ਹੈ
- ਦੂਰੇ API ਨਾਲ ਜੁੜ ਸਕਦਾ ਹੈ
- ਗਣਨਾਵਾਂ ਕਰ ਸਕਦਾ ਹੈ
- ਹੋਰ ਟੂਲਾਂ ਅਤੇ ਸੇਵਾਵਾਂ ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰ ਸਕਦਾ ਹੈ
- ਇੰਟਰਐਕਸ਼ਨ ਲਈ ਯੂਜ਼ਰ ਇੰਟਰਫੇਸ ਪ੍ਰਦਾਨ ਕਰ ਸਕਦਾ ਹੈ

ਵਧੀਆ, ਹੁਣ ਜਦੋਂ ਸਾਨੂੰ ਪਤਾ ਹੈ ਕਿ ਇਹ ਕੀ ਕਰ ਸਕਦਾ ਹੈ, ਆਓ ਕੋਡਿੰਗ ਸ਼ੁਰੂ ਕਰੀਏ।

## ਅਭਿਆਸ: ਸਰਵਰ ਬਣਾਉਣਾ

ਸਰਵਰ ਬਣਾਉਣ ਲਈ, ਤੁਹਾਨੂੰ ਇਹ ਕਦਮ ਫਾਲੋ ਕਰਨੇ ਪੈਣਗੇ:

- MCP SDK ਇੰਸਟਾਲ ਕਰੋ।
- ਇੱਕ ਪ੍ਰੋਜੈਕਟ ਬਣਾਓ ਅਤੇ ਪ੍ਰੋਜੈਕਟ ਢਾਂਚਾ ਸੈਟ ਕਰੋ।
- ਸਰਵਰ ਕੋਡ ਲਿਖੋ।
- ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰੋ।

### -1- SDK ਇੰਸਟਾਲ ਕਰੋ

ਇਹ ਤੁਹਾਡੇ ਚੁਣੇ ਹੋਏ ਰਨਟਾਈਮ ਦੇ ਅਨੁਸਾਰ ਥੋੜ੍ਹਾ ਵੱਖਰਾ ਹੋ ਸਕਦਾ ਹੈ, ਇਸ ਲਈ ਹੇਠਾਂ ਦਿੱਤੇ ਰਨਟਾਈਮ ਵਿੱਚੋਂ ਇੱਕ ਚੁਣੋ:

> [!NOTE]
> Python ਲਈ, ਅਸੀਂ ਪਹਿਲਾਂ ਪ੍ਰੋਜੈਕਟ ਢਾਂਚਾ ਬਣਾਵਾਂਗੇ ਅਤੇ ਫਿਰ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰਾਂਗੇ।

### TypeScript

```sh
npm install @modelcontextprotocol/sdk zod
npm install -D @types/node typescript
```

### Python

```sh
# Create project dir
mkdir calculator-server
cd calculator-server
# Open the folder in Visual Studio Code - Skip this if you are using a different IDE
code .
```

### .NET

```sh
dotnet new console -n McpCalculatorServer
cd McpCalculatorServer
```

### Java

Java ਲਈ, ਇੱਕ Spring Boot ਪ੍ਰੋਜੈਕਟ ਬਣਾਓ:

```bash
curl https://start.spring.io/starter.zip \
  -d dependencies=web \
  -d javaVersion=21 \
  -d type=maven-project \
  -d groupId=com.example \
  -d artifactId=calculator-server \
  -d name=McpServer \
  -d packageName=com.microsoft.mcp.sample.server \
  -o calculator-server.zip
```

ਜ਼ਿਪ ਫਾਈਲ ਨੂੰ ਅਨਜ਼ਿਪ ਕਰੋ:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

ਆਪਣੇ *pom.xml* ਫਾਈਲ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤੀ ਪੂਰੀ ਸੰਰਚਨਾ ਸ਼ਾਮਲ ਕਰੋ:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project xmlns="http://maven.apache.org/POM/4.0.0"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xsi:schemaLocation="http://maven.apache.org/POM/4.0.0 http://maven.apache.org/xsd/maven-4.0.0.xsd">
    <modelVersion>4.0.0</modelVersion>
    
    <!-- Spring Boot parent for dependency management -->
    <parent>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-parent</artifactId>
        <version>3.5.0</version>
        <relativePath />
    </parent>

    <!-- Project coordinates -->
    <groupId>com.example</groupId>
    <artifactId>calculator-server</artifactId>
    <version>0.0.1-SNAPSHOT</version>
    <name>Calculator Server</name>
    <description>Basic calculator MCP service for beginners</description>

    <!-- Properties -->
    <properties>
        <java.version>21</java.version>
        <maven.compiler.source>21</maven.compiler.source>
        <maven.compiler.target>21</maven.compiler.target>
    </properties>

    <!-- Spring AI BOM for version management -->
    <dependencyManagement>
        <dependencies>
            <dependency>
                <groupId>org.springframework.ai</groupId>
                <artifactId>spring-ai-bom</artifactId>
                <version>1.0.0-SNAPSHOT</version>
                <type>pom</type>
                <scope>import</scope>
            </dependency>
        </dependencies>
    </dependencyManagement>

    <!-- Dependencies -->
    <dependencies>
        <dependency>
            <groupId>org.springframework.ai</groupId>
            <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
        </dependency>
        <dependency>
            <groupId>org.springframework.boot</groupId>
            <artifactId>spring-boot-starter-actuator</artifactId>
        </dependency>
        <dependency>
         <groupId>org.springframework.boot</groupId>
         <artifactId>spring-boot-starter-test</artifactId>
         <scope>test</scope>
      </dependency>
    </dependencies>

    <!-- Build configuration -->
    <build>
        <plugins>
            <plugin>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-maven-plugin</artifactId>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <configuration>
                    <release>21</release>
                </configuration>
            </plugin>
        </plugins>
    </build>

    <!-- Repositories for Spring AI snapshots -->
    <repositories>
        <repository>
            <id>spring-milestones</id>
            <name>Spring Milestones</name>
            <url>https://repo.spring.io/milestone</url>
            <snapshots>
                <enabled>false</enabled>
            </snapshots>
        </repository>
        <repository>
            <id>spring-snapshots</id>
            <name>Spring Snapshots</name>
            <url>https://repo.spring.io/snapshot</url>
            <releases>
                <enabled>false</enabled>
            </releases>
        </repository>
    </repositories>
</project>
```

### -2- ਪ੍ਰੋਜੈਕਟ ਬਣਾਓ

ਹੁਣ ਜਦੋਂ ਤੁਹਾਡੇ ਕੋਲ SDK ਇੰਸਟਾਲ ਹੈ, ਆਓ ਅਗਲਾ ਕਦਮ ਪ੍ਰੋਜੈਕਟ ਬਣਾਉਣਾ ਹੈ:

### TypeScript

```sh
mkdir src
npm install -y
```

### Python

```sh
# Create a virtual env and install dependencies
python -m venv venv
venv\Scripts\activate
pip install "mcp[cli]"
```

### Java

```bash
cd calculator-server
./mvnw clean install -DskipTests
```

### -3- ਪ੍ਰੋਜੈਕਟ ਫਾਈਲਾਂ ਬਣਾਓ

### TypeScript

ਹੇਠਾਂ ਦਿੱਤੇ ਸਮੱਗਰੀ ਨਾਲ ਇੱਕ *package.json* ਬਣਾਓ:

```json
{
   "type": "module",
   "bin": {
     "weather": "./build/index.js"
   },
   "scripts": {
     "build": "tsc && node build/index.js"
   },
   "files": [
     "build"
   ]
}
```

ਹੇਠਾਂ ਦਿੱਤੇ ਸਮੱਗਰੀ ਨਾਲ ਇੱਕ *tsconfig.json* ਬਣਾਓ:

```json
{
  "compilerOptions": {
    "target": "ES2022",
    "module": "Node16",
    "moduleResolution": "Node16",
    "outDir": "./build",
    "rootDir": "./src",
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true,
    "forceConsistentCasingInFileNames": true
  },
  "include": ["src/**/*"],
  "exclude": ["node_modules"]
}
```

### Python

*server.py* ਫਾਈਲ ਬਣਾਓ

```sh
touch server.py
```

### .NET

ਲੋੜੀਂਦੇ NuGet ਪੈਕੇਜ ਇੰਸਟਾਲ ਕਰੋ:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

Java Spring Boot ਪ੍ਰੋਜੈਕਟਾਂ ਲਈ, ਪ੍ਰੋਜੈਕਟ ਢਾਂਚਾ ਆਪਣੇ ਆਪ ਬਣ ਜਾਂਦਾ ਹੈ।

### -4- ਸਰਵਰ ਕੋਡ ਬਣਾਓ

### TypeScript

*index.ts* ਫਾਈਲ ਬਣਾਓ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਕੋਡ ਸ਼ਾਮਲ ਕਰੋ:

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
 
// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});
```

ਹੁਣ ਤੁਹਾਡੇ ਕੋਲ ਇੱਕ ਸਰਵਰ ਹੈ, ਪਰ ਇਹ ਜ਼ਿਆਦਾ ਕੁਝ ਨਹੀਂ ਕਰਦਾ, ਆਓ ਇਸਨੂੰ ਠੀਕ ਕਰੀਏ।

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")
```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

// add features
```

### Java

Java ਲਈ, ਮੁੱਖ ਸਰਵਰ ਕੰਪੋਨੈਂਟ ਬਣਾਓ। ਪਹਿਲਾਂ, ਮੁੱਖ ਐਪਲੀਕੇਸ਼ਨ ਕਲਾਸ ਨੂੰ ਸੋਧੋ:

*src/main/java/com/microsoft/mcp/sample/server/McpServerApplication.java*:

```java
package com.microsoft.mcp.sample.server;

import org.springframework.ai.tool.ToolCallbackProvider;
import org.springframework.ai.tool.method.MethodToolCallbackProvider;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import com.microsoft.mcp.sample.server.service.CalculatorService;

@SpringBootApplication
public class McpServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(McpServerApplication.class, args);
    }
    
    @Bean
    public ToolCallbackProvider calculatorTools(CalculatorService calculator) {
        return MethodToolCallbackProvider.builder().toolObjects(calculator).build();
    }
}
```

ਕੈਲਕੂਲੇਟਰ ਸੇਵਾ ਬਣਾਓ *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

```java
package com.microsoft.mcp.sample.server.service;

import org.springframework.ai.tool.annotation.Tool;
import org.springframework.stereotype.Service;

/**
 * Service for basic calculator operations.
 * This service provides simple calculator functionality through MCP.
 */
@Service
public class CalculatorService {

    /**
     * Add two numbers
     * @param a The first number
     * @param b The second number
     * @return The sum of the two numbers
     */
    @Tool(description = "Add two numbers together")
    public String add(double a, double b) {
        double result = a + b;
        return formatResult(a, "+", b, result);
    }

    /**
     * Subtract one number from another
     * @param a The number to subtract from
     * @param b The number to subtract
     * @return The result of the subtraction
     */
    @Tool(description = "Subtract the second number from the first number")
    public String subtract(double a, double b) {
        double result = a - b;
        return formatResult(a, "-", b, result);
    }

    /**
     * Multiply two numbers
     * @param a The first number
     * @param b The second number
     * @return The product of the two numbers
     */
    @Tool(description = "Multiply two numbers together")
    public String multiply(double a, double b) {
        double result = a * b;
        return formatResult(a, "*", b, result);
    }

    /**
     * Divide one number by another
     * @param a The numerator
     * @param b The denominator
     * @return The result of the division
     */
    @Tool(description = "Divide the first number by the second number")
    public String divide(double a, double b) {
        if (b == 0) {
            return "Error: Cannot divide by zero";
        }
        double result = a / b;
        return formatResult(a, "/", b, result);
    }

    /**
     * Calculate the power of a number
     * @param base The base number
     * @param exponent The exponent
     * @return The result of raising the base to the exponent
     */
    @Tool(description = "Calculate the power of a number (base raised to an exponent)")
    public String power(double base, double exponent) {
        double result = Math.pow(base, exponent);
        return formatResult(base, "^", exponent, result);
    }

    /**
     * Calculate the square root of a number
     * @param number The number to find the square root of
     * @return The square root of the number
     */
    @Tool(description = "Calculate the square root of a number")
    public String squareRoot(double number) {
        if (number < 0) {
            return "Error: Cannot calculate square root of a negative number";
        }
        double result = Math.sqrt(number);
        return String.format("√%.2f = %.2f", number, result);
    }

    /**
     * Calculate the modulus (remainder) of division
     * @param a The dividend
     * @param b The divisor
     * @return The remainder of the division
     */
    @Tool(description = "Calculate the remainder when one number is divided by another")
    public String modulus(double a, double b) {
        if (b == 0) {
            return "Error: Cannot divide by zero";
        }
        double result = a % b;
        return formatResult(a, "%", b, result);
    }

    /**
     * Calculate the absolute value of a number
     * @param number The number to find the absolute value of
     * @return The absolute value of the number
     */
    @Tool(description = "Calculate the absolute value of a number")
    public String absolute(double number) {
        double result = Math.abs(number);
        return String.format("|%.2f| = %.2f", number, result);
    }

    /**
     * Get help about available calculator operations
     * @return Information about available operations
     */
    @Tool(description = "Get help about available calculator operations")
    public String help() {
        return "Basic Calculator MCP Service\n\n" +
               "Available operations:\n" +
               "1. add(a, b) - Adds two numbers\n" +
               "2. subtract(a, b) - Subtracts the second number from the first\n" +
               "3. multiply(a, b) - Multiplies two numbers\n" +
               "4. divide(a, b) - Divides the first number by the second\n" +
               "5. power(base, exponent) - Raises a number to a power\n" +
               "6. squareRoot(number) - Calculates the square root\n" + 
               "7. modulus(a, b) - Calculates the remainder of division\n" +
               "8. absolute(number) - Calculates the absolute value\n\n" +
               "Example usage: add(5, 3) will return 5 + 3 = 8";
    }

    /**
     * Format the result of a calculation
     */
    private String formatResult(double a, String operator, double b, double result) {
        return String.format("%.2f %s %.2f = %.2f", a, operator, b, result);
    }
}
```

**ਉਤਪਾਦਨ-ਤਿਆਰ ਸੇਵਾ ਲਈ ਵਿਕਲਪਿਕ ਕੰਪੋਨੈਂਟ:**

ਸਟਾਰਟਅਪ ਸੰਰਚਨਾ ਬਣਾਓ *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

```java
package com.microsoft.mcp.sample.server.config;

import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class StartupConfig {
    
    @Bean
    public CommandLineRunner startupInfo() {
        return args -> {
            System.out.println("\n" + "=".repeat(60));
            System.out.println("Calculator MCP Server is starting...");
            System.out.println("SSE endpoint: http://localhost:8080/sse");
            System.out.println("Health check: http://localhost:8080/actuator/health");
            System.out.println("=".repeat(60) + "\n");
        };
    }
}
```

ਹੈਲਥ ਕੰਟਰੋਲਰ ਬਣਾਓ *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

```java
package com.microsoft.mcp.sample.server.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;

@RestController
public class HealthController {
    
    @GetMapping("/health")
    public ResponseEntity<Map<String, Object>> healthCheck() {
        Map<String, Object> response = new HashMap<>();
        response.put("status", "UP");
        response.put("timestamp", LocalDateTime.now().toString());
        response.put("service", "Calculator MCP Server");
        return ResponseEntity.ok(response);
    }
}
```

ਇਕਸੈਪਸ਼ਨ ਹੈਂਡਲਰ ਬਣਾਓ *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

```java
package com.microsoft.mcp.sample.server.exception;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

@RestControllerAdvice
public class GlobalExceptionHandler {

    @ExceptionHandler(IllegalArgumentException.class)
    public ResponseEntity<ErrorResponse> handleIllegalArgumentException(IllegalArgumentException ex) {
        ErrorResponse error = new ErrorResponse(
            "Invalid_Input", 
            "Invalid input parameter: " + ex.getMessage());
        return new ResponseEntity<>(error, HttpStatus.BAD_REQUEST);
    }

    public static class ErrorResponse {
        private String code;
        private String message;

        public ErrorResponse(String code, String message) {
            this.code = code;
            this.message = message;
        }

        // Getters
        public String getCode() { return code; }
        public String getMessage() { return message; }
    }
}
```

ਕਸਟਮ ਬੈਨਰ ਬਣਾਓ *src/main/resources/banner.txt*:

```text
_____      _            _       _             
 / ____|    | |          | |     | |            
| |     __ _| | ___ _   _| | __ _| |_ ___  _ __ 
| |    / _` | |/ __| | | | |/ _` | __/ _ \| '__|
| |___| (_| | | (__| |_| | | (_| | || (_) | |   
 \_____\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   
                                                
Calculator MCP Server v1.0
Spring Boot MCP Application
```

### -5- ਇੱਕ ਟੂਲ ਅਤੇ ਇੱਕ ਸਰੋਤ ਜੋੜਨਾ

ਹੇਠਾਂ ਦਿੱਤਾ ਕੋਡ ਸ਼ਾਮਲ ਕਰਕੇ ਇੱਕ ਟੂਲ ਅਤੇ ਇੱਕ ਸਰੋਤ ਜੋੜੋ:

### TypeScript

```typescript
  server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);
```

ਤੁਹਾਡਾ ਟੂਲ ਪੈਰਾਮੀਟਰ `a` ਅਤੇ `b` ਲੈਂਦਾ ਹੈ ਅਤੇ ਇੱਕ ਫੰਕਸ਼ਨ ਚਲਾਉਂਦਾ ਹੈ ਜੋ ਇਸ ਰੂਪ ਵਿੱਚ ਜਵਾਬ ਦਿੰਦਾ ਹੈ:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

ਤੁਹਾਡਾ ਸਰੋਤ "greeting" ਸਟਰਿੰਗ ਰਾਹੀਂ ਪਹੁੰਚਯੋਗ ਹੈ ਅਤੇ ਪੈਰਾਮੀਟਰ `name` ਲੈਂਦਾ ਹੈ ਅਤੇ ਟੂਲ ਵਾਂਗ ਹੀ ਜਵਾਬ ਦਿੰਦਾ ਹੈ:

```typescript
{
  uri: "<href>",
  text: "a text"
}
```

### Python

```python
# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ ਟੂਲ `add` ਪਰਿਭਾਸ਼ਿਤ ਕੀਤਾ ਜੋ ਪੈਰਾਮੀਟਰ `a` ਅਤੇ `p` ਲੈਂਦਾ ਹੈ, ਦੋਹਾਂ ਇੰਟੀਜਰ ਹਨ।
- ਇੱਕ ਸਰੋਤ `greeting` ਬਣਾਇਆ ਜੋ ਪੈਰਾਮੀਟਰ `name` ਲੈਂਦਾ ਹੈ।

### .NET

ਇਸਨੂੰ ਆਪਣੇ Program.cs ਫਾਈਲ ਵਿੱਚ ਸ਼ਾਮਲ ਕਰੋ:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

ਟੂਲ ਪਹਿਲਾਂ ਹੀ ਪਿਛਲੇ ਕਦਮ ਵਿੱਚ ਬਣਾਏ ਜਾ ਚੁੱਕੇ ਹਨ।

### -6- ਅੰਤਿਮ ਕੋਡ

ਆਓ ਅੰਤਿਮ ਕੋਡ ਸ਼ਾਮਲ ਕਰੀਏ ਤਾਂ ਜੋ ਸਰਵਰ ਸ਼ੁਰੂ ਹੋ ਸਕੇ:

### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

ਪੂਰਾ ਕੋਡ ਇੱਥੇ ਹੈ:

@@
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - ਅਧਿਕਾਰਿਕ Kotlin ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI ਨਾਲ ਸਹਿਯੋਗ ਵਿੱਚ ਸੰਭਾਲਿਆ ਗਿਆ  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - ਅਧਿਕਾਰਿਕ Rust ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ  

## ਮੁੱਖ ਗੱਲਾਂ

- MCP ਵਿਕਾਸ ਵਾਤਾਵਰਣ ਸੈੱਟਅਪ ਕਰਨਾ ਭਾਸ਼ਾ-ਵਿਸ਼ੇਸ਼ SDKs ਨਾਲ ਸੌਖਾ ਹੈ  
- MCP ਸਰਵਰ ਬਣਾਉਣ ਵਿੱਚ ਸਾਫ਼ ਸਕੀਮਾਂ ਨਾਲ ਟੂਲ ਬਣਾਉਣਾ ਅਤੇ ਰਜਿਸਟਰ ਕਰਨਾ ਸ਼ਾਮਲ ਹੈ  
- ਭਰੋਸੇਮੰਦ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਲਈ ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ ਜ਼ਰੂਰੀ ਹੈ  

## ਨਮੂਨੇ

- [Java ਕੈਲਕੁਲੇਟਰ](../samples/java/calculator/README.md)  
- [.Net ਕੈਲਕੁਲੇਟਰ](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript ਕੈਲਕੁਲੇਟਰ](../samples/javascript/README.md)  
- [TypeScript ਕੈਲਕੁਲੇਟਰ](../samples/typescript/README.md)  
- [Python ਕੈਲਕੁਲੇਟਰ](../../../../03-GettingStarted/samples/python)  

## ਅਸਾਈਨਮੈਂਟ

ਆਪਣੀ ਪਸੰਦ ਦਾ ਟੂਲ ਵਰਤ ਕੇ ਇੱਕ ਸਧਾਰਣ MCP ਸਰਵਰ ਬਣਾਓ:

1. ਆਪਣੀ ਮਨਪਸੰਦ ਭਾਸ਼ਾ (.NET, Java, Python, ਜਾਂ JavaScript) ਵਿੱਚ ਟੂਲ ਨੂੰ ਇੰਪਲੀਮੈਂਟ ਕਰੋ।  
2. ਇਨਪੁੱਟ ਪੈਰਾਮੀਟਰ ਅਤੇ ਰਿਟਰਨ ਵੈਲਿਊਜ਼ ਨੂੰ ਪਰਿਭਾਸ਼ਿਤ ਕਰੋ।  
3. ਸਰਵਰ ਦੇ ਠੀਕ ਕੰਮ ਕਰਨ ਦੀ ਪੁਸ਼ਟੀ ਲਈ ਇੰਸਪੈਕਟਰ ਟੂਲ ਚਲਾਓ।  
4. ਵੱਖ-ਵੱਖ ਇਨਪੁੱਟ ਨਾਲ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਦੀ ਜਾਂਚ ਕਰੋ।  

## ਹੱਲ

[Solution](./solution/README.md)  

## ਵਾਧੂ ਸਰੋਤ

- [Azure 'ਤੇ Model Context Protocol ਨਾਲ ਏਜੰਟ ਬਣਾਓ](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Azure Container Apps (Node.js/TypeScript/JavaScript) ਨਾਲ ਰਿਮੋਟ MCP](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP ਏਜੰਟ](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## ਅਗਲਾ ਕੀ ਹੈ

ਅਗਲਾ: [MCP ਕਲਾਇੰਟਸ ਨਾਲ ਸ਼ੁਰੂਆਤ](../02-client/README.md)

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।