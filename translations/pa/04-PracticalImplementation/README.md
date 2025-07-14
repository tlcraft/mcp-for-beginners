<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:50:35+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pa"
}
-->
# Practical Implementation

ਪ੍ਰਯੋਗਿਕ ਲਾਗੂ ਕਰਨ ਦਾ ਮਤਲਬ ਹੈ ਜਿੱਥੇ Model Context Protocol (MCP) ਦੀ ਤਾਕਤ ਹਕੀਕਤ ਵਿੱਚ ਬਦਲਦੀ ਹੈ। ਜਦੋਂ ਕਿ MCP ਦੇ ਸਿਧਾਂਤ ਅਤੇ ਆਰਕੀਟੈਕਚਰ ਨੂੰ ਸਮਝਣਾ ਜਰੂਰੀ ਹੈ, ਅਸਲ ਮੁੱਲ ਉਸ ਵੇਲੇ ਨਿਕਲਦਾ ਹੈ ਜਦੋਂ ਤੁਸੀਂ ਇਹ ਧਾਰਣਾਵਾਂ ਵਰਤ ਕੇ ਹਕੀਕਤੀ ਸਮੱਸਿਆਵਾਂ ਦਾ ਹੱਲ ਬਣਾਉਂਦੇ, ਟੈਸਟ ਕਰਦੇ ਅਤੇ ਤਿਆਰ ਕਰਦੇ ਹੋ। ਇਹ ਅਧਿਆਇ ਸਿਧਾਂਤਕ ਗਿਆਨ ਅਤੇ ਹੱਥੋਂ-ਹੱਥ ਵਿਕਾਸ ਦੇ ਵਿਚਕਾਰ ਦਾ ਫਰਕ ਪੂਰਾ ਕਰਦਾ ਹੈ ਅਤੇ ਤੁਹਾਨੂੰ MCP-ਆਧਾਰਿਤ ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ ਜੀਵੰਤ ਬਣਾਉਣ ਦੀ ਪ੍ਰਕਿਰਿਆ ਵਿੱਚ ਮਦਦ ਕਰਦਾ ਹੈ।

ਚਾਹੇ ਤੁਸੀਂ ਬੁੱਧੀਮਾਨ ਸਹਾਇਕ ਵਿਕਸਿਤ ਕਰ ਰਹੇ ਹੋ, ਕਾਰੋਬਾਰੀ ਵਰਕਫਲੋਜ਼ ਵਿੱਚ AI ਨੂੰ ਜੋੜ ਰਹੇ ਹੋ ਜਾਂ ਡਾਟਾ ਪ੍ਰੋਸੈਸਿੰਗ ਲਈ ਕਸਟਮ ਟੂਲ ਬਣਾ ਰਹੇ ਹੋ, MCP ਇੱਕ ਲਚਕੀਲਾ ਬੁਨਿਆਦ ਮੁਹੱਈਆ ਕਰਵਾਉਂਦਾ ਹੈ। ਇਸ ਦੀ ਭਾਸ਼ਾ-ਅਗਨੋਸਟਿਕ ਡਿਜ਼ਾਈਨ ਅਤੇ ਲੋਕਪ੍ਰਿਯ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਲਈ ਅਧਿਕਾਰਿਕ SDKs ਇਸਨੂੰ ਵਿਆਪਕ ਵਿਕਾਸਕਾਰਾਂ ਲਈ ਪਹੁੰਚਯੋਗ ਬਣਾਉਂਦੇ ਹਨ। ਇਹ SDKs ਵਰਤ ਕੇ, ਤੁਸੀਂ ਤੇਜ਼ੀ ਨਾਲ ਪ੍ਰੋਟੋਟਾਈਪ ਤਿਆਰ ਕਰ ਸਕਦੇ ਹੋ, ਦੁਹਰਾਈ ਕਰ ਸਕਦੇ ਹੋ ਅਤੇ ਵੱਖ-ਵੱਖ ਪਲੇਟਫਾਰਮਾਂ ਅਤੇ ਵਾਤਾਵਰਣਾਂ ਵਿੱਚ ਆਪਣੇ ਹੱਲਾਂ ਨੂੰ ਵਧਾ ਸਕਦੇ ਹੋ।

ਅਗਲੇ ਭਾਗਾਂ ਵਿੱਚ, ਤੁਸੀਂ ਪ੍ਰਯੋਗਿਕ ਉਦਾਹਰਣਾਂ, ਨਮੂਨਾ ਕੋਡ ਅਤੇ ਡਿਪਲੋਇਮੈਂਟ ਰਣਨੀਤੀਆਂ ਵੇਖੋਗੇ ਜੋ ਦਿਖਾਉਂਦੀਆਂ ਹਨ ਕਿ ਕਿਵੇਂ MCP ਨੂੰ C#, Java, TypeScript, JavaScript ਅਤੇ Python ਵਿੱਚ ਲਾਗੂ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। ਤੁਸੀਂ ਇਹ ਵੀ ਸਿੱਖੋਗੇ ਕਿ MCP ਸਰਵਰਾਂ ਨੂੰ ਕਿਵੇਂ ਡੀਬੱਗ ਅਤੇ ਟੈਸਟ ਕਰਨਾ ਹੈ, APIs ਦਾ ਪ੍ਰਬੰਧਨ ਕਰਨਾ ਹੈ ਅਤੇ Azure ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਹੱਲਾਂ ਨੂੰ ਕਲਾਉਡ 'ਤੇ ਡਿਪਲੋਇ ਕਰਨਾ ਹੈ। ਇਹ ਹੱਥੋਂ-ਹੱਥ ਸਰੋਤ ਤੁਹਾਡੇ ਸਿੱਖਣ ਦੀ ਗਤੀ ਤੇਜ਼ ਕਰਨ ਅਤੇ ਮਜ਼ਬੂਤ, ਪ੍ਰੋਡਕਸ਼ਨ-ਤਿਆਰ MCP ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ ਆਤਮਵਿਸ਼ਵਾਸ ਨਾਲ ਬਣਾਉਣ ਵਿੱਚ ਮਦਦ ਕਰਨ ਲਈ ਬਣਾਏ ਗਏ ਹਨ।

## Overview

ਇਹ ਪਾਠ MCP ਲਾਗੂ ਕਰਨ ਦੇ ਪ੍ਰਯੋਗਿਕ ਪੱਖਾਂ 'ਤੇ ਧਿਆਨ ਕੇਂਦਰਿਤ ਕਰਦਾ ਹੈ ਜੋ ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਹੁੰਦੇ ਹਨ। ਅਸੀਂ ਵੇਖਾਂਗੇ ਕਿ ਕਿਵੇਂ MCP SDKs ਨੂੰ C#, Java, TypeScript, JavaScript ਅਤੇ Python ਵਿੱਚ ਵਰਤ ਕੇ ਮਜ਼ਬੂਤ ਐਪਲੀਕੇਸ਼ਨ ਬਣਾਈਆਂ ਜਾਂਦੀਆਂ ਹਨ, MCP ਸਰਵਰਾਂ ਨੂੰ ਡੀਬੱਗ ਅਤੇ ਟੈਸਟ ਕੀਤਾ ਜਾਂਦਾ ਹੈ ਅਤੇ ਦੁਬਾਰਾ ਵਰਤਣ ਯੋਗ ਸਰੋਤ, ਪ੍ਰਾਂਪਟ ਅਤੇ ਟੂਲ ਬਣਾਏ ਜਾਂਦੇ ਹਨ।

## Learning Objectives

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:
- ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਅਧਿਕਾਰਿਕ SDKs ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਹੱਲ ਲਾਗੂ ਕਰਨਾ
- MCP ਸਰਵਰਾਂ ਨੂੰ ਵਿਧੀਵਤ ਤਰੀਕੇ ਨਾਲ ਡੀਬੱਗ ਅਤੇ ਟੈਸਟ ਕਰਨਾ
- ਸਰਵਰ ਫੀਚਰ (Resources, Prompts, ਅਤੇ Tools) ਬਣਾਉਣਾ ਅਤੇ ਵਰਤਣਾ
- ਜਟਿਲ ਕੰਮਾਂ ਲਈ ਪ੍ਰਭਾਵਸ਼ਾਲੀ MCP ਵਰਕਫਲੋਜ਼ ਡਿਜ਼ਾਈਨ ਕਰਨਾ
- ਪ੍ਰਦਰਸ਼ਨ ਅਤੇ ਭਰੋਸੇਯੋਗਤਾ ਲਈ MCP ਲਾਗੂ ਕਰਨ ਨੂੰ ਅਪਟੀਮਾਈਜ਼ ਕਰਨਾ

## Official SDK Resources

Model Context Protocol ਵੱਖ-ਵੱਖ ਭਾਸ਼ਾਵਾਂ ਲਈ ਅਧਿਕਾਰਿਕ SDKs ਮੁਹੱਈਆ ਕਰਵਾਉਂਦਾ ਹੈ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

ਇਹ ਭਾਗ MCP ਨੂੰ ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਲਾਗੂ ਕਰਨ ਦੇ ਪ੍ਰਯੋਗਿਕ ਉਦਾਹਰਣ ਮੁਹੱਈਆ ਕਰਵਾਉਂਦਾ ਹੈ। ਤੁਸੀਂ `samples` ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਭਾਸ਼ਾ ਅਨੁਸਾਰ ਸੰਗਠਿਤ ਨਮੂਨਾ ਕੋਡ ਲੱਭ ਸਕਦੇ ਹੋ।

### Available Samples

ਰਿਪੋਜ਼ਟਰੀ ਵਿੱਚ ਹੇਠ ਲਿਖੀਆਂ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ [ਨਮੂਨਾ ਲਾਗੂ ਕਰਨ](../../../04-PracticalImplementation/samples) ਸ਼ਾਮਲ ਹਨ:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

ਹਰ ਨਮੂਨਾ ਉਸ ਖਾਸ ਭਾਸ਼ਾ ਅਤੇ ਪਰਿਵਾਰ ਲਈ MCP ਦੇ ਮੁੱਖ ਧਾਰਣਾਵਾਂ ਅਤੇ ਲਾਗੂ ਕਰਨ ਦੇ ਢਾਂਚੇ ਦਿਖਾਉਂਦਾ ਹੈ।

## Core Server Features

MCP ਸਰਵਰ ਇਹਨਾਂ ਫੀਚਰਾਂ ਦੇ ਕਿਸੇ ਵੀ ਸੰਯੋਗ ਨੂੰ ਲਾਗੂ ਕਰ ਸਕਦੇ ਹਨ:

### Resources
Resources ਉਪਭੋਗਤਾ ਜਾਂ AI ਮਾਡਲ ਲਈ ਸੰਦਰਭ ਅਤੇ ਡਾਟਾ ਪ੍ਰਦਾਨ ਕਰਦੇ ਹਨ:
- ਦਸਤਾਵੇਜ਼ ਸੰਗ੍ਰਹਿ
- ਗਿਆਨ ਅਧਾਰ
- ਸੰਰਚਿਤ ਡਾਟਾ ਸਰੋਤ
- ਫਾਈਲ ਸਿਸਟਮ

### Prompts
Prompts ਉਪਭੋਗਤਾਵਾਂ ਲਈ ਟੈਮਪਲੇਟ ਕੀਤੇ ਗਏ ਸੁਨੇਹੇ ਅਤੇ ਵਰਕਫਲੋਜ਼ ਹਨ:
- ਪਹਿਲਾਂ ਤੋਂ ਨਿਰਧਾਰਿਤ ਗੱਲਬਾਤ ਟੈਮਪਲੇਟ
- ਮਾਰਗਦਰਸ਼ਿਤ ਇੰਟਰੈਕਸ਼ਨ ਪੈਟਰਨ
- ਵਿਸ਼ੇਸ਼ ਡਾਇਲਾਗ ਢਾਂਚੇ

### Tools
Tools AI ਮਾਡਲ ਲਈ ਚਲਾਉਣ ਵਾਲੇ ਫੰਕਸ਼ਨ ਹਨ:
- ਡਾਟਾ ਪ੍ਰੋਸੈਸਿੰਗ ਯੂਟਿਲਿਟੀਜ਼
- ਬਾਹਰੀ API ਇੰਟੀਗ੍ਰੇਸ਼ਨ
- ਗਣਨਾਤਮਕ ਸਮਰੱਥਾਵਾਂ
- ਖੋਜ ਕਾਰਜ

## Sample Implementations: C#

ਅਧਿਕਾਰਿਕ C# SDK ਰਿਪੋਜ਼ਟਰੀ ਵਿੱਚ ਕਈ ਨਮੂਨਾ ਲਾਗੂ ਕਰਨ ਹਨ ਜੋ MCP ਦੇ ਵੱਖ-ਵੱਖ ਪੱਖਾਂ ਨੂੰ ਦਰਸਾਉਂਦੇ ਹਨ:

- **Basic MCP Client**: ਇੱਕ ਸਧਾਰਣ ਉਦਾਹਰਣ ਜੋ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ ਕਿਵੇਂ MCP ਕਲਾਇੰਟ ਬਣਾਇਆ ਜਾਂਦਾ ਹੈ ਅਤੇ ਟੂਲ ਕਾਲ ਕੀਤੇ ਜਾਂਦੇ ਹਨ
- **Basic MCP Server**: ਬੁਨਿਆਦੀ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਨਾਲ ਘੱਟੋ-ਘੱਟ ਸਰਵਰ ਲਾਗੂ ਕਰਨ
- **Advanced MCP Server**: ਪੂਰਨ ਫੀਚਰ ਵਾਲਾ ਸਰਵਰ ਜਿਸ ਵਿੱਚ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ, ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਗਲਤੀ ਸੰਭਾਲ ਸ਼ਾਮਲ ਹੈ
- **ASP.NET Integration**: ASP.NET Core ਨਾਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਦਿਖਾਉਂਦੇ ਉਦਾਹਰਣ
- **Tool Implementation Patterns**: ਵੱਖ-ਵੱਖ ਜਟਿਲਤਾ ਪੱਧਰਾਂ ਵਾਲੇ ਟੂਲ ਲਾਗੂ ਕਰਨ ਦੇ ਪੈਟਰਨ

MCP C# SDK ਪ੍ਰੀਵਿਊ ਵਿੱਚ ਹੈ ਅਤੇ APIs ਵਿੱਚ ਬਦਲਾਅ ਆ ਸਕਦੇ ਹਨ। ਅਸੀਂ ਇਸ ਬਲੌਗ ਨੂੰ SDK ਦੇ ਵਿਕਾਸ ਦੇ ਨਾਲ ਲਗਾਤਾਰ ਅਪਡੇਟ ਕਰਦੇ ਰਹਾਂਗੇ।

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- ਆਪਣਾ [ਪਹਿਲਾ MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) ਬਣਾਉਣਾ।

ਪੂਰੇ C# ਲਾਗੂ ਕਰਨ ਦੇ ਨਮੂਨੇ ਲਈ, [ਅਧਿਕਾਰਿਕ C# SDK ਨਮੂਨਾ ਰਿਪੋਜ਼ਟਰੀ](https://github.com/modelcontextprotocol/csharp-sdk) ਵੇਖੋ।

## Sample implementation: Java Implementation

Java SDK ਮਜ਼ਬੂਤ MCP ਲਾਗੂ ਕਰਨ ਦੇ ਵਿਕਲਪਾਂ ਨਾਲ ਆਉਂਦਾ ਹੈ ਜੋ ਉਦਯੋਗ-ਪੱਧਰੀ ਫੀਚਰਾਂ ਨਾਲ ਭਰਪੂਰ ਹਨ।

### Key Features

- Spring Framework ਇੰਟੀਗ੍ਰੇਸ਼ਨ
- ਮਜ਼ਬੂਤ ਟਾਈਪ ਸੁਰੱਖਿਆ
- ਪ੍ਰਤੀਕ੍ਰਿਆਸ਼ੀਲ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਸਹਾਇਤਾ
- ਵਿਸ਼ਤ੍ਰਿਤ ਗਲਤੀ ਸੰਭਾਲ

ਪੂਰੇ Java ਲਾਗੂ ਕਰਨ ਦੇ ਨਮੂਨੇ ਲਈ, samples ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ [Java sample](samples/java/containerapp/README.md) ਵੇਖੋ।

## Sample implementation: JavaScript Implementation

JavaScript SDK MCP ਲਾਗੂ ਕਰਨ ਲਈ ਹਲਕਾ-ਫੁਲਕਾ ਅਤੇ ਲਚਕੀਲਾ ਤਰੀਕਾ ਮੁਹੱਈਆ ਕਰਵਾਉਂਦਾ ਹੈ।

### Key Features

- Node.js ਅਤੇ ਬ੍ਰਾਊਜ਼ਰ ਸਹਾਇਤਾ
- Promise-ਆਧਾਰਿਤ API
- Express ਅਤੇ ਹੋਰ ਫਰੇਮਵਰਕਸ ਨਾਲ ਆਸਾਨ ਇੰਟੀਗ੍ਰੇਸ਼ਨ
- ਸਟ੍ਰੀਮਿੰਗ ਲਈ WebSocket ਸਹਾਇਤਾ

ਪੂਰੇ JavaScript ਲਾਗੂ ਕਰਨ ਦੇ ਨਮੂਨੇ ਲਈ, samples ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ [JavaScript sample](samples/javascript/README.md) ਵੇਖੋ।

## Sample implementation: Python Implementation

Python SDK MCP ਲਾਗੂ ਕਰਨ ਲਈ ਇੱਕ Pythonic ਤਰੀਕਾ ਦਿੰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ ਸ਼ਾਨਦਾਰ ML ਫਰੇਮਵਰਕ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਹਨ।

### Key Features

- asyncio ਨਾਲ async/await ਸਹਾਇਤਾ
- Flask ਅਤੇ FastAPI ਇੰਟੀਗ੍ਰੇਸ਼ਨ
- ਸਧਾਰਣ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ
- ਲੋਕਪ੍ਰਿਯ ML ਲਾਇਬ੍ਰੇਰੀਜ਼ ਨਾਲ ਮੂਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ਪੂਰੇ Python ਲਾਗੂ ਕਰਨ ਦੇ ਨਮੂਨੇ ਲਈ, samples ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ [Python sample](samples/python/README.md) ਵੇਖੋ।

## API management 

Azure API Management MCP ਸਰਵਰਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨ ਦਾ ਇੱਕ ਵਧੀਆ ਹੱਲ ਹੈ। ਵਿਚਾਰ ਇਹ ਹੈ ਕਿ ਤੁਸੀਂ ਆਪਣੇ MCP ਸਰਵਰ ਦੇ ਸਾਹਮਣੇ ਇੱਕ Azure API Management ਇੰਸਟੈਂਸ ਰੱਖੋ ਅਤੇ ਇਹ ਉਹ ਫੀਚਰ ਸੰਭਾਲੇ ਜੋ ਤੁਸੀਂ ਚਾਹੁੰਦੇ ਹੋ ਜਿਵੇਂ ਕਿ:

- ਰੇਟ ਲਿਮਿਟਿੰਗ
- ਟੋਕਨ ਪ੍ਰਬੰਧਨ
- ਮਾਨੀਟਰਿੰਗ
- ਲੋਡ ਬੈਲੈਂਸਿੰਗ
- ਸੁਰੱਖਿਆ

### Azure Sample

ਇੱਥੇ ਇੱਕ Azure Sample ਹੈ ਜੋ ਇਹੀ ਕਰਦਾ ਹੈ, ਜਿਵੇਂ ਕਿ MCP ਸਰਵਰ ਬਣਾਉਣਾ ਅਤੇ Azure API Management ਨਾਲ ਇਸਨੂੰ ਸੁਰੱਖਿਅਤ ਕਰਨਾ।

ਹੇਠਾਂ ਦਿੱਤੀ ਤਸਵੀਰ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕਤਾ ਪ੍ਰਕਿਰਿਆ ਦਿਖਾਈ ਗਈ ਹੈ:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

ਉਪਰੋਕਤ ਤਸਵੀਰ ਵਿੱਚ, ਹੇਠ ਲਿਖਿਆ ਹੁੰਦਾ ਹੈ:

- ਪ੍ਰਮਾਣਿਕਤਾ/ਪ੍ਰਮਾਣੀਕਰਨ Microsoft Entra ਦੀ ਵਰਤੋਂ ਨਾਲ ਹੁੰਦਾ ਹੈ।
- Azure API Management ਇੱਕ ਗੇਟਵੇ ਵਜੋਂ ਕੰਮ ਕਰਦਾ ਹੈ ਅਤੇ ਟ੍ਰੈਫਿਕ ਨੂੰ ਨਿਰਦੇਸ਼ਿਤ ਅਤੇ ਪ੍ਰਬੰਧਿਤ ਕਰਨ ਲਈ ਨੀਤੀਆਂ ਵਰਤਦਾ ਹੈ।
- Azure Monitor ਸਾਰੇ ਬੇਨਤੀਆਂ ਨੂੰ ਲਾਗ ਕਰਦਾ ਹੈ ਤਾਕਿ ਅੱਗੇ ਵਿਸ਼ਲੇਸ਼ਣ ਕੀਤੀ ਜਾ ਸਕੇ।

#### Authorization flow

ਆਓ ਪ੍ਰਮਾਣੀਕਰਨ ਪ੍ਰਕਿਰਿਆ ਨੂੰ ਹੋਰ ਵਿਸਥਾਰ ਨਾਲ ਵੇਖੀਏ:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

ਹੋਰ ਜਾਣਕਾਰੀ ਲਈ [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) ਵੇਖੋ।

## Deploy Remote MCP Server to Azure

ਆਓ ਵੇਖੀਏ ਕਿ ਅਸੀਂ ਪਹਿਲਾਂ ਦਿੱਤੇ ਨਮੂਨੇ ਨੂੰ ਕਿਵੇਂ ਡਿਪਲੋਇ ਕਰ ਸਕਦੇ ਹਾਂ:

1. ਰਿਪੋ ਕਲੋਨ ਕਰੋ

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. `Microsoft.App` resource provider ਨੂੰ ਰਜਿਸਟਰ ਕਰੋ।
    * ਜੇ ਤੁਸੀਂ Azure CLI ਵਰਤ ਰਹੇ ਹੋ, ਤਾਂ ਚਲਾਓ `az provider register --namespace Microsoft.App --wait`।
    * ਜੇ ਤੁਸੀਂ Azure PowerShell ਵਰਤ ਰਹੇ ਹੋ, ਤਾਂ ਚਲਾਓ `Register-AzResourceProvider -ProviderNamespace Microsoft.App`। ਫਿਰ ਕੁਝ ਸਮੇਂ ਬਾਅਦ `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` ਚੈੱਕ ਕਰੋ ਕਿ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਪੂਰਾ ਹੋ ਗਿਆ ਹੈ ਜਾਂ ਨਹੀਂ।

2. ਇਹ [azd](https://aka.ms/azd) ਕਮਾਂਡ ਚਲਾਓ ਜੋ API Management ਸੇਵਾ, ਫੰਕਸ਼ਨ ਐਪ (ਕੋਡ ਸਮੇਤ) ਅਤੇ ਹੋਰ ਸਾਰੇ ਲੋੜੀਂਦੇ Azure ਸਰੋਤ ਪ੍ਰੋਵਾਈਜ਼ਨ ਕਰੇਗੀ

    ```shell
    azd up
    ```

    ਇਹ ਕਮਾਂਡ ਸਾਰੇ ਕਲਾਉਡ ਸਰੋਤ Azure 'ਤੇ ਡਿਪਲੋਇ ਕਰ ਦੇਵੇਗੀ।

### Testing your server with MCP Inspector

1. ਇੱਕ **ਨਵੀਂ ਟਰਮੀਨਲ ਵਿੰਡੋ** ਵਿੱਚ MCP Inspector ਇੰਸਟਾਲ ਅਤੇ ਚਲਾਓ

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    ਤੁਹਾਨੂੰ ਇੱਕ ਇੰਟਰਫੇਸ ਇਸ ਤਰ੍ਹਾਂ ਦੇਖਾਈ ਦੇਵੇਗਾ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pa.png) 

1. CTRL ਕਲਿੱਕ ਕਰਕੇ MCP Inspector ਵੈੱਬ ਐਪ ਨੂੰ URL ਤੋਂ ਲੋਡ ਕਰੋ ਜੋ ਐਪ ਵੱਲੋਂ ਦਿਖਾਇਆ ਗਿਆ ਹੈ (ਜਿਵੇਂ http://127.0.0.1:6274/#resources)
1. ਟ੍ਰਾਂਸਪੋਰਟ ਕਿਸਮ ਨੂੰ `SSE` ਤੇ ਸੈੱਟ ਕਰੋ
1. URL ਨੂੰ ਆਪਣੇ ਚੱਲ ਰਹੇ API Management SSE ਐਂਡਪੌਇੰਟ ਤੇ ਸੈੱਟ ਕਰੋ ਜੋ `azd up` ਤੋਂ ਬਾਅਦ ਦਿਖਾਈ ਦਿੰਦਾ ਹੈ ਅਤੇ **Connect** ਕਰੋ:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਕਿਸੇ ਟੂਲ 'ਤੇ ਕਲਿੱਕ ਕਰਕੇ **Run Tool** ਕਰੋ।  

ਜੇ ਸਾਰੇ ਕਦਮ ਸਹੀ ਤਰ੍ਹਾਂ ਕੰਮ ਕਰ ਗਏ ਹਨ, ਤਾਂ ਤੁਸੀਂ ਹੁਣ MCP ਸਰਵਰ ਨਾਲ ਜੁੜ ਚੁੱਕੇ ਹੋ ਅਤੇ ਟੂਲ ਕਾਲ ਕਰਨ ਵਿੱਚ ਸਫਲ ਹੋ।

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): ਇਹ ਰਿਪੋਜ਼ਟਰੀਜ਼ ਦਾ ਸੈੱਟ ਹੈ ਜੋ Azure Functions ਨਾਲ Python, C# .NET ਜਾਂ Node/TypeScript ਵਰਤ ਕੇ ਕਸਟਮ ਰਿਮੋਟ MCP (Model Context Protocol) ਸਰਵਰ ਬਣਾਉਣ ਅਤੇ ਡਿਪਲੋਇ ਕਰਨ ਲਈ ਕਵਿਕਸਟਾਰਟ ਟੈਮਪਲੇਟ ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ।

ਇਹ ਨਮੂਨੇ ਇੱਕ ਪੂਰਾ ਹੱਲ ਦਿੰਦੇ ਹਨ ਜੋ ਵਿਕਾਸਕਾਰਾਂ ਨੂੰ ਸਹੂਲਤ ਦਿੰਦਾ ਹੈ:

- ਲੋਕਲ ਤੌਰ 'ਤੇ ਬਣਾਉਣਾ ਅਤੇ ਚਲਾਉਣਾ: ਇੱਕ MCP ਸਰਵਰ ਨੂੰ ਲੋਕਲ ਮਸ਼ੀਨ 'ਤੇ ਵਿਕਸਿਤ ਅਤੇ ਡੀਬੱਗ ਕਰਨਾ
- Azure 'ਤੇ ਡਿਪਲੋਇ ਕਰਨਾ: ਸਧਾਰਣ `azd up` ਕਮਾਂਡ ਨਾਲ ਕਲਾਉਡ 'ਤੇ ਆਸਾਨੀ ਨਾਲ ਡਿਪਲੋਇ ਕਰਨਾ
- ਕਲਾਇੰਟਾਂ ਤੋਂ ਕਨੈਕਟ ਕਰਨਾ: ਵੱਖ-ਵੱਖ ਕਲਾਇੰਟਾਂ ਤੋਂ MCP ਸਰਵਰ ਨਾਲ ਜੁੜਨਾ, ਜਿਵੇਂ VS Code ਦੇ Copilot ਏਜੰਟ ਮੋਡ ਅਤੇ MCP Inspector ਟੂਲ

### Key Features:

- ਡਿਜ਼ਾਈਨ ਦੁਆਰਾ ਸੁਰੱਖਿਆ: MCP ਸਰਵਰ ਕੁੰਜੀਆਂ ਅਤੇ HTTPS ਦੀ ਵਰਤੋਂ ਨਾਲ ਸੁਰੱਖਿਅਤ ਹੈ
- ਪ੍ਰਮਾਣਿਕਤਾ ਵਿਕਲਪ: ਬਿਲਟ-ਇਨ auth ਅਤੇ/ਜਾਂ API Management ਵਰਤ ਕੇ OAuth ਸਹਾਇਤਾ
- ਨੈੱਟਵਰਕ ਅਲੱਗਾਵ: Azure Virtual Networks (VNET) ਦੀ ਵਰਤੋਂ ਨਾਲ ਨੈੱਟਵਰਕ ਅਲੱਗਾਵ ਦੀ ਆਗਿਆ
- ਸਰਵਰਲੈੱਸ ਆਰਕੀਟੈਕਚਰ: ਸਕੇਲ ਕਰਨ ਯੋਗ, ਇਵੈਂਟ-ਚਲਿਤ ਕਾਰਜ ਲਈ Azure Functions ਦੀ ਵਰਤੋਂ
- ਲੋਕਲ ਵਿਕਾਸ: ਵਿਸਤ੍ਰਿਤ ਲੋਕਲ ਵਿਕਾਸ ਅਤੇ ਡੀਬੱਗਿੰਗ ਸਹਾਇਤਾ
- ਸਧਾਰਣ ਡਿਪਲੋਇਮੈਂਟ: Azure ਲਈ ਸਧਾਰਣ ਡਿਪਲੋਇਮੈਂਟ ਪ੍ਰਕਿਰਿਆ

ਰ

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।