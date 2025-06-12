<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:10:25+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pa"
}
-->
# Practical Implementation

ਪ੍ਰਾਇਕਟਿਕਲ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਓਥੇ ਹੁੰਦੀ ਹੈ ਜਿੱਥੇ Model Context Protocol (MCP) ਦੀ ਤਾਕਤ ਹਕੀਕਤ ਵਿੱਚ ਬਦਲਦੀ ਹੈ। ਜਦੋਂ ਕਿ MCP ਦੇ ਥਿਊਰੀ ਅਤੇ ਆਰਕੀਟੈਕਚਰ ਨੂੰ ਸਮਝਣਾ ਜਰੂਰੀ ਹੈ, ਅਸਲੀ ਮੁੱਲ ਉਸ ਵੇਲੇ ਨਿਕਲਦਾ ਹੈ ਜਦੋਂ ਤੁਸੀਂ ਇਹ ਸੰਕਲਪ ਬਣਾ ਕੇ, ਟੈਸਟ ਕਰਕੇ ਅਤੇ ਤਿਆਰ ਕਰਕੇ ਅਸਲ ਦੁਨੀਆ ਦੀਆਂ ਸਮੱਸਿਆਵਾਂ ਦਾ ਹੱਲ ਕਰਦੇ ਹੋ। ਇਹ ਅਧਿਆਇ ਵਿਚਾਰਧਾਰਾ ਅਤੇ ਹੱਥਾਂ-ਹੱਥ ਵਿਕਾਸ ਦੇ ਦਰਮਿਆਨ ਪੁਲ ਬਣਾਉਂਦਾ ਹੈ, ਤੁਹਾਨੂੰ MCP-ਆਧਾਰਿਤ ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ ਜੀਵੰਤ ਕਰਨ ਦੀ ਪ੍ਰਕਿਰਿਆ ਵਿੱਚ ਮਦਦ ਕਰਦਾ ਹੈ।

ਚਾਹੇ ਤੁਸੀਂ ਬੁੱਧੀਮਾਨ ਸਹਾਇਕਾਂ ਨੂੰ ਵਿਕਸਿਤ ਕਰ ਰਹੇ ਹੋ, ਕਾਰੋਬਾਰੀ ਵਰਕਫਲੋਜ਼ ਵਿੱਚ AI ਨੂੰ ਜੋੜ ਰਹੇ ਹੋ, ਜਾਂ ਡਾਟਾ ਪ੍ਰੋਸੈਸਿੰਗ ਲਈ ਕਸਟਮ ਟੂਲ ਬਣਾ ਰਹੇ ਹੋ, MCP ਇੱਕ ਲਚਕੀਲਾ ਬੁਨਿਆਦ ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ। ਇਸ ਦੀ ਭਾਸ਼ਾ-ਅਗਨੋਸਟਿਕ ਡਿਜ਼ਾਈਨ ਅਤੇ ਲੋਕਪ੍ਰਿਯ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਲਈ ਅਧਿਕਾਰਕ SDKs ਇਸਨੂੰ ਵਿਆਪਕ ਵਿਕਾਸਕਾਰਾਂ ਲਈ ਪਹੁੰਚਯੋਗ ਬਣਾਉਂਦੇ ਹਨ। ਇਨ੍ਹਾਂ SDKs ਦੀ ਵਰਤੋਂ ਕਰਕੇ, ਤੁਸੀਂ ਤੇਜ਼ੀ ਨਾਲ ਪ੍ਰੋਟੋਟਾਈਪ ਤਿਆਰ ਕਰ ਸਕਦੇ ਹੋ, ਦੁਹਰਾਵਟ ਕਰ ਸਕਦੇ ਹੋ ਅਤੇ ਵੱਖ-ਵੱਖ ਪਲੇਟਫਾਰਮਾਂ ਅਤੇ ਮਾਹੌਲਾਂ ਵਿੱਚ ਆਪਣੇ ਹੱਲਾਂ ਨੂੰ ਵਧਾ ਸਕਦੇ ਹੋ।

ਅਗਲੇ ਹਿੱਸਿਆਂ ਵਿੱਚ, ਤੁਸੀਂ ਪ੍ਰਾਇਕਟਿਕਲ ਉਦਾਹਰਣਾਂ, ਨਮੂਨਾ ਕੋਡ ਅਤੇ ਡਿਪਲੋਇਮੈਂਟ ਰਣਨੀਤੀਆਂ ਵੇਖੋਗੇ ਜੋ ਦਿਖਾਉਂਦੀਆਂ ਹਨ ਕਿ ਕਿਵੇਂ MCP ਨੂੰ C#, Java, TypeScript, JavaScript ਅਤੇ Python ਵਿੱਚ ਲਾਗੂ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। ਤੁਸੀਂ ਇਹ ਵੀ ਸਿੱਖੋਗੇ ਕਿ MCP ਸਰਵਰਾਂ ਨੂੰ ਕਿਵੇਂ ਡੀਬੱਗ ਅਤੇ ਟੈਸਟ ਕਰਨਾ ਹੈ, APIs ਦਾ ਪ੍ਰਬੰਧਨ ਕਰਨਾ ਹੈ, ਅਤੇ Azure ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕਲਾਉਡ 'ਤੇ ਹੱਲਾਂ ਨੂੰ ਡਿਪਲੋਇ ਕਰਨਾ ਹੈ। ਇਹ ਹੱਥ-ਵਿੱਚ ਸਾਧਨ ਤੁਹਾਡੇ ਸਿੱਖਣ ਦੀ ਗਤੀ ਤੇਜ਼ ਕਰਨ ਅਤੇ ਮਜ਼ਬੂਤ, ਪ੍ਰੋਡਕਸ਼ਨ-ਰੇਡੀ MCP ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ ਆਤਮ-ਵਿਸ਼ਵਾਸ ਨਾਲ ਬਣਾਉਣ ਵਿੱਚ ਮਦਦ ਲਈ ਬਣਾਏ ਗਏ ਹਨ।

## Overview

ਇਹ ਪਾਠ MCP ਦੀ ਪ੍ਰਾਇਕਟਿਕਲ ਲਾਗੂਅਤ ਦੇ ਪੱਖਾਂ 'ਤੇ ਧਿਆਨ ਕੇਂਦਰਿਤ ਕਰਦਾ ਹੈ ਜੋ ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਹੈ। ਅਸੀਂ ਵੇਖਾਂਗੇ ਕਿ ਕਿਵੇਂ MCP SDKs ਨੂੰ C#, Java, TypeScript, JavaScript ਅਤੇ Python ਵਿੱਚ ਵਰਤ ਕੇ ਮਜ਼ਬੂਤ ਐਪਲੀਕੇਸ਼ਨ ਬਣਾਈਆਂ ਜਾਂਦੀਆਂ ਹਨ, MCP ਸਰਵਰਾਂ ਨੂੰ ਡੀਬੱਗ ਅਤੇ ਟੈਸਟ ਕੀਤਾ ਜਾਂਦਾ ਹੈ, ਅਤੇ ਦੁਬਾਰਾ ਵਰਤਣਯੋਗ ਸਰੋਤ, ਪ੍ਰਾਂਪਟ ਅਤੇ ਟੂਲ ਬਣਾਏ ਜਾਂਦੇ ਹਨ।

## Learning Objectives

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:
- ਅਧਿਕਾਰਕ SDKs ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਹੱਲਾਂ ਨੂੰ ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਲਾਗੂ ਕਰਨਾ
- MCP ਸਰਵਰਾਂ ਨੂੰ ਵਿਧਾਨਕ ਤਰੀਕੇ ਨਾਲ ਡੀਬੱਗ ਅਤੇ ਟੈਸਟ ਕਰਨਾ
- ਸਰਵਰ ਫੀਚਰ (Resources, Prompts, ਅਤੇ Tools) ਬਣਾਉਣਾ ਅਤੇ ਵਰਤਣਾ
- ਜਟਿਲ ਕਾਰਜਾਂ ਲਈ ਪ੍ਰਭਾਵਸ਼ালী MCP ਵਰਕਫਲੋ ਡਿਜ਼ਾਈਨ ਕਰਨਾ
- ਪ੍ਰਦਰਸ਼ਨ ਅਤੇ ਭਰੋਸੇਯੋਗਤਾ ਲਈ MCP ਲਾਗੂਅਤਾਂ ਨੂੰ ਅਪਟੀਮਾਈਜ਼ ਕਰਨਾ

## Official SDK Resources

Model Context Protocol ਵੱਖ-ਵੱਖ ਭਾਸ਼ਾਵਾਂ ਲਈ ਅਧਿਕਾਰਕ SDKs ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

ਇਹ ਭਾਗ MCP ਨੂੰ ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਲਾਗੂ ਕਰਨ ਦੇ ਪ੍ਰਾਇਕਟਿਕਲ ਉਦਾਹਰਣ ਮੁਹੱਈਆ ਕਰਵਾਉਂਦਾ ਹੈ। ਤੁਸੀਂ `samples` ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਭਾਸ਼ਾ ਅਨੁਸਾਰ ਵਿਵਸਥਿਤ ਨਮੂਨਾ ਕੋਡ ਲੱਭ ਸਕਦੇ ਹੋ।

### Available Samples

ਰਿਪੋਜ਼ਟਰੀ ਵਿੱਚ ਹੇਠ ਲਿਖੀਆਂ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਨਮੂਨਾ ਲਾਗੂਅਤਾਂ ਸ਼ਾਮਲ ਹਨ:

- C#
- Java
- TypeScript
- JavaScript
- Python

ਹਰ ਨਮੂਨਾ ਉਸ ਖਾਸ ਭਾਸ਼ਾ ਅਤੇ ਪਰਿਵੇਸ਼ ਲਈ MCP ਦੇ ਮੁੱਖ ਸੰਕਲਪ ਅਤੇ ਲਾਗੂਅਤ ਦੇ ਪੈਟਰਨ ਦਿਖਾਉਂਦਾ ਹੈ।

## Core Server Features

MCP ਸਰਵਰ ਇਹਨਾਂ ਵਿੱਚੋਂ ਕਿਸੇ ਵੀ ਸੰਯੋਜਨ ਨੂੰ ਲਾਗੂ ਕਰ ਸਕਦੇ ਹਨ:

### Resources
Resources ਵਰਤੋਂਕਾਰ ਜਾਂ AI ਮਾਡਲ ਲਈ ਸੰਦਰਭ ਅਤੇ ਡਾਟਾ ਪ੍ਰਦਾਨ ਕਰਦੇ ਹਨ:
- ਦਸਤਾਵੇਜ਼ ਸੰਗ੍ਰਹਿ
- ਗਿਆਨ ਅਧਾਰ
- ਸੰਰਚਿਤ ਡਾਟਾ ਸਰੋਤ
- ਫਾਈਲ ਸਿਸਟਮ

### Prompts
Prompts ਵਰਤੋਂਕਾਰਾਂ ਲਈ ਟੈਮਪਲੇਟ ਕੀਤੇ ਗਏ ਸੁਨੇਹੇ ਅਤੇ ਵਰਕਫਲੋ ਹੁੰਦੇ ਹਨ:
- ਪਹਿਲਾਂ ਤੋਂ ਪਰਿਭਾਸ਼ਿਤ ਗੱਲਬਾਤ ਟੈਮਪਲੇਟ
- ਮਾਰਗਦਰਸ਼ਿਤ ਇੰਟਰਐਕਸ਼ਨ ਪੈਟਰਨ
- ਵਿਸ਼ੇਸ਼ ਡਾਇਲਾਗ ਢਾਂਚੇ

### Tools
Tools AI ਮਾਡਲ ਲਈ ਚਲਾਉਣ ਵਾਲੇ ਫੰਕਸ਼ਨ ਹਨ:
- ਡਾਟਾ ਪ੍ਰੋਸੈਸਿੰਗ ਯੂਟਿਲਿਟੀਜ਼
- ਬਾਹਰੀ API ਇੰਟਿਗ੍ਰੇਸ਼ਨ
- ਗਣਨਾਤਮਕ ਸਮਰੱਥਾਵਾਂ
- ਖੋਜ ਕਾਰਜ

## Sample Implementations: C#

ਅਧਿਕਾਰਕ C# SDK ਰਿਪੋਜ਼ਟਰੀ ਵਿੱਚ MCP ਦੇ ਵੱਖ-ਵੱਖ ਪੱਖਾਂ ਨੂੰ ਦਰਸਾਉਂਦੀਆਂ ਕਈ ਨਮੂਨਾ ਲਾਗੂਅਤਾਂ ਹਨ:

- **Basic MCP Client**: ਸਾਦਾ ਉਦਾਹਰਣ ਜੋ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ MCP ਕਲਾਇੰਟ ਕਿਵੇਂ ਬਣਾਇਆ ਜਾਵੇ ਅਤੇ ਟੂਲ ਕਿਵੇਂ ਕਾਲ ਕੀਤੇ ਜਾਣ
- **Basic MCP Server**: ਬੁਨਿਆਦੀ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਨਾਲ ਘੱਟੋ-ਘੱਟ ਸਰਵਰ ਲਾਗੂਅਤ
- **Advanced MCP Server**: ਪੂਰੀ ਤਰ੍ਹਾਂ ਫੀਚਰ ਵਾਲਾ ਸਰਵਰ ਜਿਸ ਵਿੱਚ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ, ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਗਲਤੀ ਸੰਭਾਲ ਸ਼ਾਮਲ ਹੈ
- **ASP.NET Integration**: ASP.NET Core ਨਾਲ ਇੰਟਿਗ੍ਰੇਸ਼ਨ ਦਿਖਾਉਂਦੇ ਉਦਾਹਰਣ
- **Tool Implementation Patterns**: ਵੱਖ-ਵੱਖ ਜਟਿਲਤਾ ਪੱਧਰਾਂ ਨਾਲ ਟੂਲ ਲਾਗੂ ਕਰਨ ਦੇ ਪੈਟਰਨ

MCP C# SDK ਅਜੇ ਪ੍ਰੀਵਿਊ ਵਿੱਚ ਹੈ ਅਤੇ APIs ਬਦਲ ਸਕਦੇ ਹਨ। ਅਸੀਂ SDK ਦੇ ਵਿਕਾਸ ਦੇ ਨਾਲ ਇਸ ਬਲੌਗ ਨੂੰ ਲਗਾਤਾਰ ਅਪਡੇਟ ਕਰਾਂਗੇ।

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- ਆਪਣਾ [ਪਹਿਲਾ MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) ਬਣਾਉਣ ਲਈ।

ਪੂਰੀ C# ਲਾਗੂਅਤਾਂ ਲਈ, ਅਧਿਕਾਰਕ C# SDK ਨਮੂਨਾ ਰਿਪੋਜ਼ਟਰੀ ਵੇਖੋ: [official C# SDK samples repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

Java SDK MCP ਦੀ ਮਜ਼ਬੂਤ ਲਾਗੂਅਤ ਲਈ ਉਦਯੋਗ-ਗ੍ਰੇਡ ਫੀਚਰਾਂ ਨਾਲ ਭਰਪੂਰ ਵਿਕਲਪ ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ।

### Key Features

- Spring Framework ਇੰਟਿਗ੍ਰੇਸ਼ਨ
- ਮਜ਼ਬੂਤ ਟਾਈਪ ਸੇਫਟੀ
- ਰਿਐਕਟਿਵ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਸਹਾਇਤਾ
- ਵਿਸਥਾਰਪੂਰਕ ਗਲਤੀ ਸੰਭਾਲ

ਪੂਰੀ Java ਲਾਗੂਅਤ ਲਈ ਨਮੂਨਾ ਦੇਖੋ [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) ਸੈਂਪਲ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ।

## Sample implementation: JavaScript Implementation

JavaScript SDK MCP ਲਾਗੂਅਤ ਲਈ ਇੱਕ ਹਲਕਾ ਅਤੇ ਲਚਕੀਲਾ ਤਰੀਕਾ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ।

### Key Features

- Node.js ਅਤੇ ਬ੍ਰਾਊਜ਼ਰ ਸਹਾਇਤਾ
- Promise-ਆਧਾਰਿਤ API
- Express ਅਤੇ ਹੋਰ ਫਰੇਮਵਰਕਸ ਨਾਲ ਆਸਾਨ ਇੰਟਿਗ੍ਰੇਸ਼ਨ
- Streaming ਲਈ WebSocket ਸਹਾਇਤਾ

ਪੂਰੀ JavaScript ਲਾਗੂਅਤ ਲਈ ਨਮੂਨਾ ਦੇਖੋ [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) ਸੈਂਪਲ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ।

## Sample implementation: Python Implementation

Python SDK MCP ਲਾਗੂਅਤ ਲਈ ਇੱਕ Pythonic ਤਰੀਕਾ ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ ਬਿਹਤਰੀਨ ML ਫਰੇਮਵਰਕ ਇੰਟਿਗ੍ਰੇਸ਼ਨ ਸ਼ਾਮਲ ਹਨ।

### Key Features

- asyncio ਨਾਲ async/await ਸਹਾਇਤਾ
- Flask ਅਤੇ FastAPI ਇੰਟਿਗ੍ਰੇਸ਼ਨ
- ਸਧਾਰਣ ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ
- ਲੋਕਪ੍ਰਿਯ ML ਲਾਇਬ੍ਰੇਰੀਆਂ ਨਾਲ ਕੁਦਰਤੀ ਇੰਟਿਗ੍ਰੇਸ਼ਨ

ਪੂਰੀ Python ਲਾਗੂਅਤ ਲਈ ਨਮੂਨਾ ਦੇਖੋ [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) ਸੈਂਪਲ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ।

## API management 

Azure API Management ਇੱਕ ਵਧੀਆ ਹੱਲ ਹੈ ਇਹ ਸੁਰੱਖਿਅਤ MCP ਸਰਵਰਾਂ ਲਈ। ਮਕਸਦ ਇਹ ਹੈ ਕਿ MCP ਸਰਵਰ ਦੇ ਸਾਹਮਣੇ ਇੱਕ Azure API Management ਇੰਸਟੈਂਸ ਰੱਖਿਆ ਜਾਵੇ ਜੋ ਉਹ ਫੀਚਰ ਸੰਭਾਲੇ ਜੋ ਤੁਸੀਂ ਚਾਹੁੰਦੇ ਹੋ, ਜਿਵੇਂ:

- ਰੇਟ ਲਿਮਿਟਿੰਗ
- ਟੋਕਨ ਪ੍ਰਬੰਧਨ
- ਮਾਨੀਟਰਿੰਗ
- ਲੋਡ ਬੈਲੈਂਸਿੰਗ
- ਸੁਰੱਖਿਆ

### Azure Sample

ਇੱਥੇ ਇੱਕ Azure Sample ਹੈ ਜੋ ਇਹੀ ਕਰਦਾ ਹੈ, ਜਿਵੇਂ ਕਿ [MCP Server ਬਣਾਉਣਾ ਅਤੇ Azure API Management ਨਾਲ ਸੁਰੱਖਿਅਤ ਕਰਨਾ](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)।

ਹੇਠਾਂ ਦਿੱਤੀ ਤਸਵੀਰ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕਤਾ ਫਲੋ ਕਿਵੇਂ ਹੁੰਦਾ ਹੈ ਵੇਖੋ:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

ਉਪਰ ਦਿੱਤੀ ਤਸਵੀਰ ਵਿੱਚ ਇਹ ਹੁੰਦਾ ਹੈ:

- Microsoft Entra ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪ੍ਰਮਾਣਿਕਤਾ/ਅਧਿਕਾਰਨ ਹੁੰਦਾ ਹੈ।
- Azure API Management ਗੇਟਵੇ ਵਜੋਂ ਕੰਮ ਕਰਦਾ ਹੈ ਅਤੇ ਟ੍ਰੈਫਿਕ ਨੂੰ ਨਿਰਦੇਸ਼ਤ ਅਤੇ ਪ੍ਰਬੰਧਿਤ ਕਰਨ ਲਈ ਨੀਤੀਆਂ ਵਰਤਦਾ ਹੈ।
- Azure Monitor ਸਾਰੇ ਰਿਕਵੇਸਟਾਂ ਨੂੰ ਲਾਗ ਕਰਦਾ ਹੈ ਅਗਲੇ ਵਿਸ਼ਲੇਸ਼ਣ ਲਈ।

#### Authorization flow

ਆਓ ਪ੍ਰਮਾਣਿਕਤਾ ਫਲੋ ਨੂੰ ਹੋਰ ਵਿਸਥਾਰ ਨਾਲ ਵੇਖੀਏ:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

[ਹੋਰ ਜਾਣਕਾਰੀ ਲਈ MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) ਵੇਖੋ।

## Deploy Remote MCP Server to Azure

ਆਓ ਦੇਖੀਏ ਕਿ ਅਸੀਂ ਪਹਿਲਾਂ ਦਿੱਤੇ ਨਮੂਨੇ ਨੂੰ ਡਿਪਲੋਇ ਕਰ ਸਕਦੇ ਹਾਂ:

1. ਰਿਪੋ ਕਲੋਨ ਕਰੋ

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` ਨੂੰ ਰਜਿਸਟਰ ਕਰੋ:

    `` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

    ਕੁਝ ਸਮੇਂ ਬਾਅਦ ਜਾਂਚ ਕਰੋ ਕਿ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਪੂਰੀ ਹੋ ਗਈ ਹੈ ਜਾਂ ਨਹੀਂ।

3. ਇਸ [azd](https://aka.ms/azd) ਕਮਾਂਡ ਨੂੰ ਚਲਾਓ ਜੋ API Management ਸੇਵਾ, ਫੰਕਸ਼ਨ ਐਪ (ਕੋਡ ਸਮੇਤ) ਅਤੇ ਹੋਰ ਸਾਰੇ ਲੋੜੀਂਦੇ Azure ਸਰੋਤ ਪ੍ਰੋਵਿਜ਼ਨ ਕਰੇਗਾ:

    ```shell
    azd up
    ```

    ਇਹ ਕਮਾਂਡ Azure 'ਤੇ ਸਾਰੇ ਕਲਾਉਡ ਸਰੋਤ ਡਿਪਲੋਇ ਕਰ ਦੇਵੇਗੀ।

### Testing your server with MCP Inspector

1. ਇੱਕ **ਨਵੀਂ ਟਰਮੀਨਲ ਵਿੰਡੋ** ਵਿੱਚ MCP Inspector ਇੰਸਟਾਲ ਅਤੇ ਚਲਾਓ

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    ਤੁਹਾਨੂੰ ਇਹੋ ਜਿਹਾ ਇੰਟਰਫੇਸ ਵੇਖਣਾ ਚਾਹੀਦਾ ਹੈ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pa.png) 

2. CTRL ਕਲਿੱਕ ਕਰੋ MCP Inspector ਵੈੱਬ ਐਪ ਨੂੰ URL ਤੋਂ ਲੋਡ ਕਰਨ ਲਈ (ਜਿਵੇਂ http://127.0.0.1:6274/#resources)
3. ਟ੍ਰਾਂਸਪੋਰਟ ਟਾਈਪ ਨੂੰ `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` ਤੇ ਸੈੱਟ ਕਰੋ ਅਤੇ **Connect** ਕਰੋ:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** ਕਰੋ। ਕਿਸੇ ਟੂਲ 'ਤੇ ਕਲਿੱਕ ਕਰੋ ਅਤੇ **Run Tool** ਕਰੋ।

ਜੇ ਸਾਰੇ ਕਦਮ ਸਹੀ ਤਰ੍ਹਾਂ ਹੋ ਗਏ, ਤਾਂ ਤੁਸੀਂ ਹੁਣ MCP ਸਰਵਰ ਨਾਲ ਜੁੜੇ ਹੋ ਅਤੇ ਟੂਲ ਕਾਲ ਕਰਨ ਵਿੱਚ ਸਫਲ ਰਹੇ ਹੋ।

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): ਇਹ ਰਿਪੋਜ਼ਟਰੀਜ਼ ਦਾ ਸੈੱਟ ਹੈ ਜੋ Python, C# .NET ਜਾਂ Node/TypeScript ਨਾਲ Azure Functions ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕਸਟਮ ਰਿਮੋਟ MCP ਸਰਵਰ ਬਣਾਉਣ ਅਤੇ ਡਿਪਲੋਇ ਕਰਨ ਲਈ ਤੁਰੰਤ ਸ਼ੁਰੂਆਤੀ ਟੈਮਪਲੇਟ ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ।

ਨਮੂਨੇ ਇੱਕ ਪੂਰਾ ਹੱਲ ਪ੍ਰਦਾਨ ਕਰਦੇ ਹਨ ਜੋ ਵਿਕਾਸਕਾਰਾਂ ਨੂੰ ਸਹੂਲਤ ਦਿੰਦੇ ਹਨ:

- ਲੋਕਲ ਮਸ਼ੀਨ 'ਤੇ MCP ਸਰਵਰ ਬਣਾਉਣਾ ਅਤੇ ਡੀਬੱਗ ਕਰਨਾ
- ਆਸਾਨੀ ਨਾਲ Azure 'ਤੇ azd up ਕਮਾਂਡ ਨਾਲ ਡਿਪਲੋਇ ਕਰਨਾ
- ਵੱਖ-ਵੱਖ ਕਲਾਇੰਟਾਂ ਤੋਂ MCP ਸਰਵਰ ਨਾਲ ਜੁੜਨਾ, ਜਿਵੇਂ VS Code ਦੇ Copilot ਏਜੰਟ ਮੋਡ ਅਤੇ MCP Inspector ਟੂਲ

### Key Features:

- ਡਿਜ਼ਾਈਨ ਦੁਆਰਾ ਸੁਰੱਖਿਆ: MCP ਸਰਵਰ ਕੁੰਜੀਆਂ ਅਤੇ HTTPS ਨਾਲ ਸੁਰੱਖਿਅਤ
- ਪ੍ਰਮਾਣਿਕਤਾ ਦੇ ਵਿਕਲਪ: OAuth ਦਾ ਸਹਾਰਾ, ਇੰਬਿਲਟ auth ਅਤੇ/ਜਾਂ API Management ਨਾਲ
- ਨੈੱਟਵਰਕ ਅਲੱਗਾਵ: Azure Virtual Networks (VNET) ਨਾਲ ਨੈੱਟਵਰਕ ਅਲੱਗਾਵ ਦੀ ਆਗਿਆ
- ਸਰਵਰਲੈੱਸ ਆਰਕੀਟੈਕਚਰ: ਸਕੇਲ ਕਰਨ ਯੋਗ, ਘਟਨਾ-ਚਲਿਤ Azure Functions ਦੀ ਵਰਤੋਂ
- ਲੋਕਲ ਵਿਕਾਸ: ਵਿਆਪਕ ਲੋਕਲ ਵਿਕਾਸ ਅਤੇ ਡੀਬੱਗ ਸਹਾਇਤਾ
- ਸਧਾਰਣ ਡਿਪਲੋਇਮੈਂਟ: Azure ਲਈ ਸੁਚਾਰੂ ਡਿਪਲੋਇਮੈਂਟ ਪ੍ਰਕਿਰਿਆ

ਇਹ ਰਿਪੋਜ਼ਟਰੀ ਸਾਰੇ ਜਰੂਰੀ ਕਨਫਿਗਰੇਸ਼ਨ ਫਾਈਲਾਂ, ਸੋర్స్ ਕੋਡ ਅਤੇ ਇੰਫ੍ਰਾਸਟਰੱਕਚਰ ਪਰਿਭਾਸ਼ਾਵਾਂ ਸ਼ਾਮਲ ਕਰਦਾ ਹੈ ਜੋ ਤੁਹਾਨੂੰ ਤੁਰੰਤ ਪ੍ਰੋਡਕਸ਼ਨ-ਰੇਡੀ MCP ਸਰਵਰ ਲਾਗੂਅਤ ਨਾਲ ਸ਼ੁਰੂ ਕਰਨ ਲਈ ਮਦਦ ਕਰਦੇ ਹਨ।

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python ਨਾਲ Azure Functions ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਦਾ ਨਮੂਨਾ ਲਾਗੂਅਤ

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET ਨਾਲ Azure Functions ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਦਾ ਨਮੂ

**ਡਿਸਕਲੇਮਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਨਾਲ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਪਸ਼ਟਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਨਾਲ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।