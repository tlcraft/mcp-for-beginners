<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:58:32+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pa"
}
-->
# Practical Implementation

ਵਾਸਤਵਿਕ ਅਮਲ ਉਹ ਜਗ੍ਹਾ ਹੈ ਜਿੱਥੇ Model Context Protocol (MCP) ਦੀ ਤਾਕਤ ਅਸਲੀਅਤ ਵਿੱਚ ਸਾਹਮਣੇ ਆਉਂਦੀ ਹੈ। ਜਦੋਂ ਕਿ MCP ਦੇ ਸਿਧਾਂਤ ਅਤੇ ਆਰਕੀਟੈਕਚਰ ਨੂੰ ਸਮਝਣਾ ਮਹੱਤਵਪੂਰਨ ਹੈ, ਅਸਲ ਕਦਰ ਉਸ ਵੇਲੇ ਮਿਲਦੀ ਹੈ ਜਦੋਂ ਤੁਸੀਂ ਇਹ ਧਾਰਨਾਵਾਂ ਲਾਗੂ ਕਰਕੇ ਹਕੀਕਤੀ ਸਮੱਸਿਆਵਾਂ ਦਾ ਹੱਲ ਤਿਆਰ, ਟੈਸਟ ਅਤੇ ਡਿਪਲੌਇ ਕਰਦੇ ਹੋ। ਇਹ ਅਧਿਆਇ ਸਿਧਾਂਤਕ ਗਿਆਨ ਅਤੇ ਹੱਥ-ਵਰਕ ਵਿਕਾਸ ਦੇ ਵਿਚਕਾਰ ਪੂਲ ਬਣਾਉਂਦਾ ਹੈ, ਅਤੇ ਤੁਹਾਨੂੰ MCP ਅਧਾਰਿਤ ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ ਜੀਵੰਤ ਕਰਨ ਦੀ ਪ੍ਰਕਿਰਿਆ ਵਿੱਚ ਰਾਹ ਦਿਖਾਉਂਦਾ ਹੈ।

ਚਾਹੇ ਤੁਸੀਂ ਬੁੱਧਿਮਾਨ ਸਹਾਇਕਾਂ ਦਾ ਵਿਕਾਸ ਕਰ ਰਹੇ ਹੋ, ਵਪਾਰਕ ਕੰਮਕਾਜ ਵਿੱਚ AI ਨੂੰ ਸ਼ਾਮਿਲ ਕਰ ਰਹੇ ਹੋ ਜਾਂ ਡੇਟਾ ਪ੍ਰੋਸੈਸਿੰਗ ਲਈ ਕਸਟਮ ਟੂਲ ਬਣਾਉਂਦੇ ਹੋ, MCP ਇੱਕ ਲਚਕੀਲਾ ਅਧਾਰ ਮੁਹੱਈਆ ਕਰਵਾਉਂਦਾ ਹੈ। ਇਸ ਦੀ ਭਾਸ਼ਾ-ਅਗਨੋਸਟਿਕ ਡਿਜ਼ਾਈਨ ਅਤੇ ਪ੍ਰਸਿੱਧ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਲਈ ਅਧਿਕਾਰਕ SDKs ਇਸਨੂੰ ਵਿਆਪਕ ਵਿਕਾਸਕਾਰਾਂ ਲਈ ਪਹੁੰਚਯੋਗ ਬਣਾਉਂਦੇ ਹਨ। ਇਹ SDKs ਵਰਤ ਕੇ, ਤੁਸੀਂ ਜਲਦੀ ਪ੍ਰੋਟੋਟਾਈਪ ਤਿਆਰ ਕਰ ਸਕਦੇ ਹੋ, ਦੁਹਰਾਉਂਦੇ ਹੋ ਅਤੇ ਵੱਖ-ਵੱਖ ਪਲੇਟਫਾਰਮਾਂ ਅਤੇ ਮਾਹੌਲਾਂ ਵਿੱਚ ਆਪਣੇ ਹੱਲਾਂ ਨੂੰ ਸਕੇਲ ਕਰ ਸਕਦੇ ਹੋ।

ਅਗਲੇ ਹਿੱਸਿਆਂ ਵਿੱਚ, ਤੁਸੀਂ MCP ਨੂੰ C#, Java, TypeScript, JavaScript, ਅਤੇ Python ਵਿੱਚ ਲਾਗੂ ਕਰਨ ਦੇ ਪ੍ਰਯੋਗਿਕ ਉਦਾਹਰਨਾਂ, ਨਮੂਨਾ ਕੋਡ ਅਤੇ ਡਿਪਲੌਇਮੈਂਟ ਰਣਨੀਤੀਆਂ ਵੇਖੋਗੇ। ਤੁਸੀਂ ਆਪਣੇ MCP ਸਰਵਰਾਂ ਨੂੰ ਡਿਬੱਗ ਅਤੇ ਟੈਸਟ ਕਰਨਾ, APIs ਦਾ ਪ੍ਰਬੰਧਨ ਕਰਨਾ ਅਤੇ Azure ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕਲਾਉਡ ਵਿੱਚ ਹੱਲ ਡਿਪਲੌਇ ਕਰਨਾ ਵੀ ਸਿੱਖੋਗੇ। ਇਹ ਹੱਥ-ਵਰਕ ਸਰੋਤ ਤੁਹਾਡੇ ਸਿੱਖਣ ਦੀ ਗਤੀ ਤੇਜ਼ ਕਰਨ ਅਤੇ ਤੁਹਾਨੂੰ ਭਰੋਸੇਮੰਦ, ਉਤਪਾਦਨ-ਤਿਆਰ MCP ਐਪਲੀਕੇਸ਼ਨਾਂ ਬਣਾਉਣ ਵਿੱਚ ਮਦਦ ਕਰਨ ਲਈ ਬਣਾਏ ਗਏ ਹਨ।

## Overview

ਇਹ ਪਾਠ MCP ਲਾਗੂ ਕਰਨ ਦੇ ਵਾਸਤਵਿਕ ਪੱਖਾਂ 'ਤੇ ਧਿਆਨ ਕੇਂਦਰਿਤ ਕਰਦਾ ਹੈ ਜੋ ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਵਰਤਿਆ ਜਾ ਸਕਦਾ ਹੈ। ਅਸੀਂ ਵੇਖਾਂਗੇ ਕਿ ਕਿਵੇਂ MCP SDKs ਨੂੰ C#, Java, TypeScript, JavaScript ਅਤੇ Python ਵਿੱਚ ਵਰਤ ਕੇ ਮਜ਼ਬੂਤ ਐਪਲੀਕੇਸ਼ਨ ਬਣਾਈਆਂ ਜਾਂਦੀਆਂ ਹਨ, MCP ਸਰਵਰਾਂ ਨੂੰ ਡਿਬੱਗ ਅਤੇ ਟੈਸਟ ਕੀਤਾ ਜਾਂਦਾ ਹੈ, ਅਤੇ ਦੁਬਾਰਾ ਵਰਤੋਂਯੋਗ ਸਰੋਤ, ਪ੍ਰਾਂਪਟ ਅਤੇ ਟੂਲ ਬਣਾਏ ਜਾਂਦੇ ਹਨ।

## Learning Objectives

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:
- ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਅਧਿਕਾਰਕ SDKs ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਹੱਲ ਲਾਗੂ ਕਰਨਾ
- MCP ਸਰਵਰਾਂ ਨੂੰ ਵਿਧਾਨਤਮਕ ਤਰੀਕੇ ਨਾਲ ਡਿਬੱਗ ਅਤੇ ਟੈਸਟ ਕਰਨਾ
- ਸਰਵਰ ਫੀਚਰ (Resources, Prompts, ਅਤੇ Tools) ਬਣਾਉਣਾ ਅਤੇ ਵਰਤਣਾ
- ਜਟਿਲ ਕੰਮਾਂ ਲਈ ਪ੍ਰਭਾਵਸ਼ਾਲੀ MCP ਵਰਕਫਲੋ ਡਿਜ਼ਾਈਨ ਕਰਨਾ
- ਪ੍ਰਦਰਸ਼ਨ ਅਤੇ ਭਰੋਸੇਯੋਗਤਾ ਲਈ MCP ਲਾਗੂ ਕਰਨ ਨੂੰ ਸੁਧਾਰਨਾ

## Official SDK Resources

Model Context Protocol ਵੱਖ-ਵੱਖ ਭਾਸ਼ਾਵਾਂ ਲਈ ਅਧਿਕਾਰਕ SDKs ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

ਇਸ ਭਾਗ ਵਿੱਚ MCP ਨੂੰ ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਲਾਗੂ ਕਰਨ ਦੇ ਪ੍ਰਯੋਗਿਕ ਉਦਾਹਰਨ ਦਿੱਤੇ ਗਏ ਹਨ। ਤੁਸੀਂ `samples` ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਭਾਸ਼ਾ ਅਨੁਸਾਰ ਸੰਗਠਿਤ ਨਮੂਨਾ ਕੋਡ ਲੱਭ ਸਕਦੇ ਹੋ।

### Available Samples

ਰਿਪੋਜਿਟਰੀ ਵਿੱਚ ਹੇਠ ਲਿਖੀਆਂ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ [ਨਮੂਨਾ ਲਾਗੂ ਕਰਨ ਵਾਲੇ ਕੋਡ](../../../04-PracticalImplementation/samples) ਸ਼ਾਮਿਲ ਹਨ:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

ਹਰ ਨਮੂਨਾ ਉਸ ਖਾਸ ਭਾਸ਼ਾ ਅਤੇ ਇਕੋਸਿਸਟਮ ਲਈ MCP ਦੇ ਮੁੱਖ ਸਿਧਾਂਤ ਅਤੇ ਲਾਗੂ ਕਰਨ ਦੇ ਤਰੀਕੇ ਦਰਸਾਉਂਦਾ ਹੈ।

## Core Server Features

MCP ਸਰਵਰ ਹੇਠ ਲਿਖੀਆਂ ਕਿਸੇ ਵੀ ਖਾਸੀਅਤਾਂ ਨੂੰ ਲਾਗੂ ਕਰ ਸਕਦੇ ਹਨ:

### Resources
Resources ਉਪਭੋਗਤਾ ਜਾਂ AI ਮਾਡਲ ਲਈ ਸੰਦਰਭ ਅਤੇ ਡੇਟਾ ਪ੍ਰਦਾਨ ਕਰਦੇ ਹਨ:
- ਦਸਤਾਵੇਜ਼ ਰਿਪੋਜ਼ਟਰੀਜ਼
- ਗਿਆਨ ਆਧਾਰ
- ਸੰਰਚਿਤ ਡੇਟਾ ਸਰੋਤ
- ਫਾਈਲ ਸਿਸਟਮ

### Prompts
Prompts ਉਪਭੋਗਤਾਵਾਂ ਲਈ ਟੈਂਪਲੇਟ ਕੀਤੇ ਗਏ ਸੁਨੇਹੇ ਅਤੇ ਵਰਕਫਲੋ ਹਨ:
- ਪਹਿਲਾਂ ਤੈਅ ਕੀਤੇ ਗਏ ਗੱਲਬਾਤ ਦੇ ਟੈਂਪਲੇਟ
- ਮਾਰਗਦਰਸ਼ਿਤ ਇੰਟਰੈਕਸ਼ਨ ਪੈਟਰਨ
- ਵਿਸ਼ੇਸ਼ ਡਾਇਲਾਗ ਸਟਰੱਕਚਰ

### Tools
Tools AI ਮਾਡਲ ਵੱਲੋਂ ਚਲਾਏ ਜਾਣ ਵਾਲੇ ਫੰਕਸ਼ਨ ਹਨ:
- ਡੇਟਾ ਪ੍ਰੋਸੈਸਿੰਗ ਯੂਟਿਲਿਟੀਜ਼
- ਬਾਹਰੀ API ਇੰਟਿਗ੍ਰੇਸ਼ਨ
- ਗਣਨਾਤਮਕ ਸਮਰੱਥਾਵਾਂ
- ਖੋਜ ਫੰਕਸ਼ਨਾਲਿਟੀ

## Sample Implementations: C#

ਅਧਿਕਾਰਕ C# SDK ਰਿਪੋਜਿਟਰੀ ਵਿੱਚ MCP ਦੇ ਵੱਖ-ਵੱਖ ਪੱਖਾਂ ਨੂੰ ਦਰਸਾਉਂਦੇ ਕਈ ਨਮੂਨਾ ਲਾਗੂ ਕਰਨ ਵਾਲੇ ਕੋਡ ਹਨ:

- **Basic MCP Client**: MCP ਕਲਾਇੰਟ ਬਣਾਉਣ ਅਤੇ ਟੂਲ ਕਾਲ ਕਰਨ ਦਾ ਸਧਾਰਣ ਉਦਾਹਰਨ
- **Basic MCP Server**: ਬੁਨਿਆਦੀ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਨਾਲ ਘੱਟੋ-ਘੱਟ ਸਰਵਰ ਲਾਗੂ ਕਰਨ ਵਾਲਾ
- **Advanced MCP Server**: ਪੂਰਨ ਫੀਚਰ ਵਾਲਾ ਸਰਵਰ, ਜਿਸ ਵਿੱਚ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ, ਪ੍ਰਮਾਣੀਕਰਨ ਅਤੇ ਗਲਤੀ ਸੰਭਾਲ ਸ਼ਾਮਿਲ ਹੈ
- **ASP.NET Integration**: ASP.NET Core ਨਾਲ ਇੰਟਿਗ੍ਰੇਸ਼ਨ ਦਿਖਾਉਂਦੇ ਉਦਾਹਰਨ
- **Tool Implementation Patterns**: ਵੱਖ-ਵੱਖ ਜਟਿਲਤਾ ਦੇ ਸਤਰਾਂ ਲਈ ਟੂਲ ਲਾਗੂ ਕਰਨ ਦੇ ਵੱਖਰੇ ਤਰੀਕੇ

MCP C# SDK ਪ੍ਰੀਵਿਊ ਵਿੱਚ ਹੈ ਅਤੇ APIs ਵਿੱਚ ਬਦਲਾਅ ਆ ਸਕਦੇ ਹਨ। ਜਿਵੇਂ ਜਿਵੇਂ SDK ਵਿਕਸਤ ਹੁੰਦਾ ਹੈ, ਅਸੀਂ ਇਸ ਬਲੌਗ ਨੂੰ ਅਪਡੇਟ ਕਰਦੇ ਰਹਾਂਗੇ।

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- ਆਪਣਾ [ਪਹਿਲਾ MCP ਸਰਵਰ ਬਣਾਉਣਾ](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

ਪੂਰੇ C# ਲਾਗੂ ਕਰਨ ਵਾਲੇ ਨਮੂਨਿਆਂ ਲਈ, [ਅਧਿਕਾਰਕ C# SDK ਨਮੂਨਾ ਰਿਪੋਜਿਟਰੀ](https://github.com/modelcontextprotocol/csharp-sdk) ਵੇਖੋ।

## Sample implementation: Java Implementation

Java SDK ਮਜ਼ਬੂਤ MCP ਲਾਗੂ ਕਰਨ ਦੇ ਵਿਕਲਪ ਅਤੇ ਉਦਯੋਗ-ਗਰੇਡ ਫੀਚਰ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ।

### Key Features

- Spring Framework ਇੰਟਿਗ੍ਰੇਸ਼ਨ
- ਮਜ਼ਬੂਤ ਟਾਈਪ ਸੇਫਟੀ
- ਰੀਐਕਟਿਵ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਸਹਾਇਤਾ
- ਵਿਆਪਕ ਗਲਤੀ ਸੰਭਾਲ

ਪੂਰੇ Java ਲਾਗੂ ਕਰਨ ਵਾਲੇ ਨਮੂਨੇ ਲਈ, samples ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) ਵੇਖੋ।

## Sample implementation: JavaScript Implementation

JavaScript SDK MCP ਲਾਗੂ ਕਰਨ ਲਈ ਹਲਕਾ-ਫੁਲਕਾ ਅਤੇ ਲਚਕੀਲਾ ਤਰੀਕਾ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ।

### Key Features

- Node.js ਅਤੇ ਬ੍ਰਾਊਜ਼ਰ ਸਹਾਇਤਾ
- ਪ੍ਰੋਮਿਸ-ਅਧਾਰਿਤ API
- Express ਅਤੇ ਹੋਰ ਫਰੇਮਵਰਕਾਂ ਨਾਲ ਆਸਾਨ ਇੰਟਿਗ੍ਰੇਸ਼ਨ
- ਸਟ੍ਰੀਮਿੰਗ ਲਈ WebSocket ਸਹਾਇਤਾ

ਪੂਰੇ JavaScript ਲਾਗੂ ਕਰਨ ਵਾਲੇ ਨਮੂਨੇ ਲਈ, samples ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) ਵੇਖੋ।

## Sample implementation: Python Implementation

Python SDK MCP ਲਾਗੂ ਕਰਨ ਲਈ Pythonic ਅੰਦਾਜ਼ ਅਤੇ ਸ਼ਾਨਦਾਰ ML ਫਰੇਮਵਰਕ ਇੰਟਿਗ੍ਰੇਸ਼ਨਾਂ ਨਾਲ ਆਉਂਦਾ ਹੈ।

### Key Features

- asyncio ਨਾਲ async/await ਸਹਾਇਤਾ
- Flask ਅਤੇ FastAPI ਇੰਟਿਗ੍ਰੇਸ਼ਨ
- ਸਧਾਰਣ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ
- ਪ੍ਰਸਿੱਧ ML ਲਾਇਬ੍ਰੇਰੀਆਂ ਨਾਲ ਮੂਲ ਇੰਟਿਗ੍ਰੇਸ਼ਨ

ਪੂਰੇ Python ਲਾਗੂ ਕਰਨ ਵਾਲੇ ਨਮੂਨੇ ਲਈ, samples ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) ਵੇਖੋ।

## API management 

Azure API Management MCP ਸਰਵਰਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਦਾ ਵਧੀਆ ਜਵਾਬ ਹੈ। ਵਿਚਾਰ ਇਹ ਹੈ ਕਿ ਤੁਸੀਂ ਆਪਣੇ MCP ਸਰਵਰ ਦੇ ਸਾਹਮਣੇ ਇੱਕ Azure API Management ਇੰਸਟੈਂਸ ਰੱਖੋ ਅਤੇ ਇਹ ਉਹ ਫੀਚਰ ਸੰਭਾਲੇ ਜੋ ਤੁਸੀਂ ਚਾਹੁੰਦੇ ਹੋ ਜਿਵੇਂ:

- ਰੇਟ ਲਿਮਿਟਿੰਗ
- ਟੋਕਨ ਪ੍ਰਬੰਧਨ
- ਮਾਨੀਟਰਿੰਗ
- ਲੋਡ ਬੈਲੈਂਸਿੰਗ
- ਸੁਰੱਖਿਆ

### Azure Sample

ਇੱਥੇ ਇੱਕ Azure Sample ਹੈ ਜੋ ਬਿਲਕੁਲ ਇਹ ਕਰਦਾ ਹੈ, ਜਿਵੇਂ ਕਿ MCP ਸਰਵਰ ਬਣਾਉਣਾ ਅਤੇ Azure API Management ਨਾਲ ਇਸ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨਾ ([ਲਿੰਕ](https://github.com/Azure-Samples/remote-mcp-apim-functions-python))।

ਹੇਠਾਂ ਦਿੱਤੀ ਚਿੱਤਰ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕਤਾ ਪ੍ਰਕਿਰਿਆ ਵੇਖੋ:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

ਉਪਰ ਦਿੱਤੇ ਚਿੱਤਰ ਵਿੱਚ ਹੇਠ ਲਿਖੀਆਂ ਗੱਲਾਂ ਹੁੰਦੀਆਂ ਹਨ:

- ਪ੍ਰਮਾਣੀਕਰਨ/ਪ੍ਰਮਾਣਿਕਤਾ Microsoft Entra ਦੀ ਵਰਤੋਂ ਨਾਲ ਹੁੰਦੀ ਹੈ।
- Azure API Management ਇੱਕ ਗੇਟਵੇ ਵਜੋਂ ਕੰਮ ਕਰਦਾ ਹੈ ਅਤੇ ਟ੍ਰੈਫਿਕ ਨੂੰ ਦਿਸ਼ਾ ਦੇਣ ਅਤੇ ਪ੍ਰਬੰਧਿਤ ਕਰਨ ਲਈ ਨੀਤੀਆਂ ਵਰਤਦਾ ਹੈ।
- Azure Monitor ਸਾਰੇ ਰਿਕਵੈਸਟਾਂ ਨੂੰ ਲੌਗ ਕਰਦਾ ਹੈ ਤਾਂ ਜੋ ਅੱਗੇ ਵਿਸ਼ਲੇਸ਼ਣ ਕੀਤੀ ਜਾ ਸਕੇ।

#### Authorization flow

ਚਲੋ ਪ੍ਰਮਾਣਿਕਤਾ ਪ੍ਰਕਿਰਿਆ ਨੂੰ ਹੋਰ ਵਿਸਥਾਰ ਨਾਲ ਵੇਖੀਏ:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

[MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) ਬਾਰੇ ਹੋਰ ਜਾਣਕਾਰੀ ਲਈ ਵੇਖੋ।

## Deploy Remote MCP Server to Azure

ਆਓ ਵੇਖੀਏ ਕਿ ਅਸੀਂ ਪਹਿਲਾਂ ਦਿੱਤੇ ਨਮੂਨੇ ਨੂੰ ਕਿਵੇਂ ਡਿਪਲੌਇ ਕਰ ਸਕਦੇ ਹਾਂ:

1. ਰਿਪੋ ਕਲੋਨ ਕਰੋ

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` ਪ੍ਰੋਵਾਈਡਰ ਨੂੰ ਰਜਿਸਟਰ ਕਰੋ:

    `az provider register --namespace Microsoft.App --wait`

    ਜਾਂ

    `Register-AzResourceProvider -ProviderNamespace Microsoft.App`

    ਕੁਝ ਸਮੇਂ ਬਾਅਦ ਚੈੱਕ ਕਰੋ ਕਿ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਪੂਰੀ ਹੋ ਚੁੱਕੀ ਹੈ ਜਾਂ ਨਹੀਂ:

    `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

3. ਇਸ [azd](https://aka.ms/azd) ਕਮਾਂਡ ਨੂੰ ਚਲਾਓ ਤਾਂ ਜੋ API Management ਸੇਵਾ, ਫੰਕਸ਼ਨ ਐਪ (ਕੋਡ ਸਮੇਤ) ਅਤੇ ਹੋਰ ਜ਼ਰੂਰੀ Azure ਸਰੋਤ ਪ੍ਰੋਵਾਈਜ਼ ਕੀਤੇ ਜਾ ਸਕਣ:

    ```shell
    azd up
    ```

    ਇਹ ਕਮਾਂਡ ਸਾਰੇ ਕਲਾਉਡ ਸਰੋਤ Azure 'ਤੇ ਡਿਪਲੌਇ ਕਰ ਦੇਵੇਗੀ।

### Testing your server with MCP Inspector

1. ਇੱਕ **ਨਵੀਂ ਟਰਮੀਨਲ ਵਿੰਡੋ** ਵਿੱਚ MCP Inspector ਇੰਸਟਾਲ ਅਤੇ ਚਲਾਓ:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    ਤੁਹਾਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਦਾ ਇੰਟਰਫੇਸ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pa.png) 

2. CTRL ਕਲਿੱਕ ਕਰਕੇ MCP Inspector ਵੈੱਬ ਐਪ ਨੂੰ ਐਪ ਵੱਲੋਂ ਦਿਖਾਈ ਦੇ ਰਹੇ URL (ਜਿਵੇਂ http://127.0.0.1:6274/#resources) ਤੋਂ ਲੋਡ ਕਰੋ
3. ਟ੍ਰਾਂਸਪੋਰਟ ਟਾਈਪ ਨੂੰ `SSE` 'ਤੇ ਸੈੱਟ ਕਰੋ ਅਤੇ **Connect** ਕਰੋ:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਕਿਸੇ ਟੂਲ 'ਤੇ ਕਲਿੱਕ ਕਰਕੇ **Run Tool** ਕਰੋ।  

ਜੇ ਸਾਰੇ ਕਦਮ ਸਹੀ ਤਰ੍ਹਾਂ ਹੋ ਗਏ, ਤਾਂ ਹੁਣ ਤੁਸੀਂ MCP ਸਰਵਰ ਨਾਲ ਜੁੜ ਗਏ ਹੋ ਅਤੇ ਕਿਸੇ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰ ਪਾਏ ਹੋ।

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): ਇਹ ਰਿਪੋਜ਼ਿਟਰੀਜ਼ ਦਾ ਸੈੱਟ ਤੇਜ਼ ਸ਼ੁਰੂਆਤ ਵਾਲਾ ਟੈਮਪਲੇਟ ਹੈ ਜੋ Azure Functions ਦੀ ਵਰਤੋਂ ਕਰਕੇ Python, C# .NET ਜਾਂ Node/TypeScript ਨਾਲ ਕਸਟਮ ਰਿਮੋਟ MCP (Model Context Protocol) ਸਰਵਰ ਬਣਾਉਣ ਅਤੇ ਡਿਪਲੌਇ ਕਰਨ ਲਈ ਹੈ।

ਇਹ ਨਮੂਨੇ ਇੱਕ ਪੂਰਾ ਹੱਲ ਪ੍ਰਦਾਨ ਕਰਦੇ ਹਨ ਜੋ ਵਿਕਾਸਕਾਰਾਂ ਨੂੰ ਸਹੂਲਤ ਦਿੰਦਾ ਹੈ:

- ਲੋਕਲ ਤੌਰ 'ਤੇ ਬਣਾਉਣਾ ਅਤੇ ਚਲਾਉਣਾ: ਇੱਕ MCP ਸਰਵਰ ਨੂੰ ਲੋਕਲ ਮਸ਼ੀਨ 'ਤੇ ਵਿਕਸਿਤ ਅਤੇ ਡਿਬੱਗ ਕਰੋ
- Azure 'ਤੇ ਡਿਪਲੌਇ ਕਰੋ: ਇੱਕ ਸਧਾਰਣ azd up ਕਮਾਂਡ ਨਾਲ ਆਸਾਨੀ ਨਾਲ ਕਲਾਉਡ 'ਤੇ ਡਿਪਲੌਇ ਕਰੋ
- ਕਲਾਇੰਟਾਂ ਤੋਂ ਕਨੈਕਟ ਕਰੋ: ਵੱਖ-ਵੱਖ ਕਲਾਇੰਟਾਂ ਤੋਂ MCP ਸਰਵਰ ਨਾਲ ਜੁੜੋ, ਜਿਸ ਵਿੱਚ VS Code ਦਾ Copilot ਏਜੰਟ ਮੋਡ ਅਤੇ MCP Inspector ਟੂਲ ਸ਼ਾਮਿਲ ਹਨ

### Key Features:

- ਡਿਜ਼ਾਈਨ ਦੁਆਰਾ ਸੁਰੱਖਿਆ: MCP ਸਰਵਰ ਕੁੰਜੀਆਂ ਅਤੇ HTTPS ਦੀ ਵਰਤੋਂ ਨਾਲ ਸੁਰੱਖਿਅਤ ਹੈ
- ਪ੍ਰਮਾਣੀਕਰਨ ਵਿਕਲਪ: ਬਿਲਟ-ਇਨ auth ਅਤੇ/ਜਾਂ API Management ਵਰਤ ਕੇ OAuth ਸਹਾਇਤਾ
- ਨੈੱਟਵਰਕ ਅਲੱਗਾਵ: Azure Virtual Networks (VNET) ਦੀ ਵਰਤੋਂ ਨਾਲ ਨੈੱਟਵਰਕ ਅਲੱਗਾਵ ਦੀ ਆਗਿਆ
- ਸਰਵਰਲੇਸ ਆਰਕੀਟੈਕਚਰ: ਵਧੇਰੇ ਸਕੇਲ ਕਰਨ ਯੋਗ, ਘਟਨਾ-ਚਾਲਿਤ ਕਾਰਜਾਂ ਲਈ Azure Functions ਦੀ ਵਰਤੋਂ
- ਲੋਕਲ ਵਿਕਾਸ: ਵਿਸਤ੍ਰਿਤ ਲੋਕਲ ਵਿਕਾਸ ਅਤੇ ਡਿਬੱਗ ਸਹਾਇਤਾ
- ਸਧਾਰਣ ਡਿਪਲੌਇਮੈਂਟ: Azure ਲਈ ਸਧਾਰਨ ਡਿਪਲੌਇਮੈਂਟ ਪ੍ਰਕਿਰਿਆ

ਇਹ ਰਿਪੋਜ਼ਿਟਰੀ ਸਾਰੇ ਜ਼ਰੂਰੀ ਸੰਰਚਨਾ ਫਾਇਲਾਂ, ਸੋਰਸ ਕੋਡ ਅਤੇ ਢਾਂਚਾ ਪਰਿਭਾਸ਼ਾਵਾਂ ਸ਼ਾਮਿਲ ਕਰਦਾ ਹੈ ਤਾਂ ਜੋ ਤੁਸੀਂ ਤੁਰੰਤ ਉਤਪਾਦਨ-ਤਿਆਰ MCP ਸਰਵਰ ਲਾਗੂ ਕਰਨਾ

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ ਏਆਈ ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਜਾਣੂ ਰਹੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਧਿਕਾਰਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਭੁੱਲਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।