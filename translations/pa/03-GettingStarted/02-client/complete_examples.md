<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:33:28+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "pa"
}
-->
# Complete MCP Client Examples

ਇਸ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਵੱਖ-ਵੱਖ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ MCP ਕਲਾਇੰਟਾਂ ਦੇ ਪੂਰੇ, ਕੰਮ ਕਰਨ ਵਾਲੇ ਉਦਾਹਰਣ ਹਨ। ਹਰ ਕਲਾਇੰਟ ਮੁੱਖ README.md ਟਿਊਟੋਰਿਯਲ ਵਿੱਚ ਦਿੱਤੀ ਗਈ ਪੂਰੀ ਕਾਰਗੁਜ਼ਾਰੀ ਨੂੰ ਦਰਸਾਉਂਦਾ ਹੈ।

## Available Clients

### 1. Java Client (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) HTTP ਰਾਹੀਂ
- **Target Server**: `http://localhost:8080`
- **Features**: 
  - ਕਨੈਕਸ਼ਨ ਸਥਾਪਨਾ ਅਤੇ ਪਿੰਗ
  - ਟੂਲ ਸੂਚੀਬੱਧ ਕਰਨਾ
  - ਕੈਲਕੁਲੇਟਰ ਓਪਰੇਸ਼ਨ (ਜੋੜ, ਘਟਾਓ, ਗੁਣਾ, ਭਾਗ, ਮਦਦ)
  - ਗਲਤੀ ਸੰਭਾਲਣਾ ਅਤੇ ਨਤੀਜੇ ਪ੍ਰਾਪਤ ਕਰਨਾ

**To run:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Client (`client_example_csharp.cs`)
- **Transport**: Stdio (ਸਟੈਂਡਰਡ ਇਨਪੁੱਟ/ਆਉਟਪੁੱਟ)
- **Target Server**: ਲੋਕਲ .NET MCP ਸਰਵਰ dotnet run ਰਾਹੀਂ
- **Features**:
  - stdio ਟਰਾਂਸਪੋਰਟ ਰਾਹੀਂ ਸਰਵਰ ਦਾ ਆਟੋਮੈਟਿਕ ਸਟਾਰਟਅਪ
  - ਟੂਲ ਅਤੇ ਸਰੋਤ ਸੂਚੀਬੱਧ ਕਰਨਾ
  - ਕੈਲਕੁਲੇਟਰ ਓਪਰੇਸ਼ਨ
  - JSON ਨਤੀਜੇ ਪਾਰਸ ਕਰਨਾ
  - ਵਿਸਤ੍ਰਿਤ ਗਲਤੀ ਸੰਭਾਲਣਾ

**To run:**
```bash
dotnet run
```

### 3. TypeScript Client (`client_example_typescript.ts`)
- **Transport**: Stdio (ਸਟੈਂਡਰਡ ਇਨਪੁੱਟ/ਆਉਟਪੁੱਟ)
- **Target Server**: ਲੋਕਲ Node.js MCP ਸਰਵਰ
- **Features**:
  - ਪੂਰਾ MCP ਪ੍ਰੋਟੋਕੋਲ ਸਹਿਯੋਗ
  - ਟੂਲ, ਸਰੋਤ ਅਤੇ ਪ੍ਰਾਂਪਟ ਓਪਰੇਸ਼ਨ
  - ਕੈਲਕੁਲੇਟਰ ਓਪਰੇਸ਼ਨ
  - ਸਰੋਤ ਪੜ੍ਹਨਾ ਅਤੇ ਪ੍ਰਾਂਪਟ ਚਲਾਉਣਾ
  - ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣਾ

**To run:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Client (`client_example_python.py`)
- **Transport**: Stdio (ਸਟੈਂਡਰਡ ਇਨਪੁੱਟ/ਆਉਟਪੁੱਟ)  
- **Target Server**: ਲੋਕਲ Python MCP ਸਰਵਰ
- **Features**:
  - Async/await ਪੈਟਰਨ ਨਾਲ ਓਪਰੇਸ਼ਨ
  - ਟੂਲ ਅਤੇ ਸਰੋਤ ਖੋਜ
  - ਕੈਲਕੁਲੇਟਰ ਓਪਰੇਸ਼ਨ ਟੈਸਟਿੰਗ
  - ਸਰੋਤ ਸਮੱਗਰੀ ਪੜ੍ਹਨਾ
  - ਕਲਾਸ-ਆਧਾਰਿਤ ਸੰਗਠਨ

**To run:**
```bash
python client_example_python.py
```

## Common Features Across All Clients

ਹਰ ਕਲਾਇੰਟ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਇਹ ਦਰਸਾਉਂਦਾ ਹੈ:

1. **ਕਨੈਕਸ਼ਨ ਪ੍ਰਬੰਧਨ**
   - MCP ਸਰਵਰ ਨਾਲ ਕਨੈਕਸ਼ਨ ਸਥਾਪਿਤ ਕਰਨਾ
   - ਕਨੈਕਸ਼ਨ ਗਲਤੀਆਂ ਨੂੰ ਸੰਭਾਲਣਾ
   - ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਸਾਫ-ਸਫਾਈ ਅਤੇ ਸਰੋਤ ਪ੍ਰਬੰਧਨ

2. **ਸਰਵਰ ਖੋਜ**
   - ਉਪਲਬਧ ਟੂਲਾਂ ਦੀ ਸੂਚੀ
   - ਉਪਲਬਧ ਸਰੋਤਾਂ ਦੀ ਸੂਚੀ (ਜਿੱਥੇ ਸਹਿਯੋਗ ਹੈ)
   - ਉਪਲਬਧ ਪ੍ਰਾਂਪਟਾਂ ਦੀ ਸੂਚੀ (ਜਿੱਥੇ ਸਹਿਯੋਗ ਹੈ)

3. **ਟੂਲ ਕਾਲ**
   - ਬੁਨਿਆਦੀ ਕੈਲਕੁਲੇਟਰ ਓਪਰੇਸ਼ਨ (ਜੋੜ, ਘਟਾਓ, ਗੁਣਾ, ਭਾਗ)
   - ਸਰਵਰ ਜਾਣਕਾਰੀ ਲਈ ਮਦਦ ਕਮਾਂਡ
   - ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਆਰਗੁਮੈਂਟ ਭੇਜਣਾ ਅਤੇ ਨਤੀਜੇ ਸੰਭਾਲਣਾ

4. **ਗਲਤੀ ਸੰਭਾਲਣਾ**
   - ਕਨੈਕਸ਼ਨ ਗਲਤੀਆਂ
   - ਟੂਲ ਚਲਾਉਣ ਦੀਆਂ ਗਲਤੀਆਂ
   - ਨਰਮ ਫੇਲ੍ਹ ਅਤੇ ਯੂਜ਼ਰ ਫੀਡਬੈਕ

5. **ਨਤੀਜਾ ਪ੍ਰਕਿਰਿਆ**
   - ਜਵਾਬਾਂ ਵਿੱਚੋਂ ਟੈਕਸਟ ਸਮੱਗਰੀ ਕੱਢਣਾ
   - ਪੜ੍ਹਨ ਯੋਗ ਆਉਟਪੁੱਟ ਫਾਰਮੈਟ ਕਰਨਾ
   - ਵੱਖ-ਵੱਖ ਜਵਾਬ ਫਾਰਮੈਟਾਂ ਨੂੰ ਸੰਭਾਲਣਾ

## Prerequisites

ਇਹ ਕਲਾਇੰਟ ਚਲਾਉਣ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ:

1. **ਸੰਬੰਧਿਤ MCP ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ** (`../01-first-server/` ਤੋਂ)
2. **ਆਪਣੀ ਚੁਣੀ ਹੋਈ ਭਾਸ਼ਾ ਲਈ ਲੋੜੀਂਦੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕੀਤੀਆਂ ਹੋਣ**
3. **ਠੀਕ ਨੈੱਟਵਰਕ ਕਨੈਕਸ਼ਨ** (HTTP-ਆਧਾਰਿਤ ਟਰਾਂਸਪੋਰਟ ਲਈ)

## Key Differences Between Implementations

| Language   | Transport | Server Startup | Async Model | Key Libraries |
|------------|-----------|----------------|-------------|---------------|
| Java       | SSE/HTTP  | ਬਾਹਰੀ          | ਸਿੰਕ          | WebFlux, MCP SDK |
| C#         | Stdio     | ਆਟੋਮੈਟਿਕ       | Async/Await | .NET MCP SDK |
| TypeScript | Stdio     | ਆਟੋਮੈਟਿਕ       | Async/Await | Node MCP SDK |
| Python     | Stdio     | ਆਟੋਮੈਟਿਕ       | AsyncIO     | Python MCP SDK |

## Next Steps

ਇਹ ਕਲਾਇੰਟ ਉਦਾਹਰਣਾਂ ਨੂੰ ਵੇਖਣ ਤੋਂ ਬਾਅਦ:

1. **ਕਲਾਇੰਟਾਂ ਵਿੱਚ ਨਵੇਂ ਫੀਚਰ ਜਾਂ ਓਪਰੇਸ਼ਨ ਸ਼ਾਮਲ ਕਰੋ**
2. **ਆਪਣਾ ਸਰਵਰ ਬਣਾਓ ਅਤੇ ਇਨ੍ਹਾਂ ਕਲਾਇੰਟਾਂ ਨਾਲ ਟੈਸਟ ਕਰੋ**
3. **ਵੱਖ-ਵੱਖ ਟਰਾਂਸਪੋਰਟ (SSE ਵਿਰੁੱਧ Stdio) ਨਾਲ ਪ੍ਰਯੋਗ ਕਰੋ**
4. **ਇੱਕ ਹੋਰ ਜਟਿਲ ਐਪਲੀਕੇਸ਼ਨ ਬਣਾਓ ਜੋ MCP ਕਾਰਗੁਜ਼ਾਰੀ ਨੂੰ ਜੋੜਦਾ ਹੋਵੇ**

## Troubleshooting

### Common Issues

1. **ਕਨੈਕਸ਼ਨ ਰੱਦ ਹੋ ਗਿਆ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ MCP ਸਰਵਰ ਉਮੀਦ ਕੀਤੇ ਪੋਰਟ/ਪਾਥ 'ਤੇ ਚੱਲ ਰਿਹਾ ਹੈ
2. **ਮੋਡੀਊਲ ਨਹੀਂ ਮਿਲਿਆ**: ਆਪਣੀ ਭਾਸ਼ਾ ਲਈ ਲੋੜੀਂਦਾ MCP SDK ਇੰਸਟਾਲ ਕਰੋ
3. **ਪ੍ਰਵਾਨਗੀ ਨਾ ਮਿਲੀ**: stdio ਟਰਾਂਸਪੋਰਟ ਲਈ ਫਾਈਲ ਪਰਮਿਸ਼ਨ ਚੈੱਕ ਕਰੋ
4. **ਟੂਲ ਨਹੀਂ ਮਿਲਿਆ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਰਵਰ ਉਮੀਦ ਕੀਤੇ ਟੂਲਾਂ ਨੂੰ ਇੰਪਲੀਮੈਂਟ ਕਰਦਾ ਹੈ

### Debug Tips

1. **ਆਪਣੇ MCP SDK ਵਿੱਚ ਵਿਸਤ੍ਰਿਤ ਲੌਗਿੰਗ ਚਾਲੂ ਕਰੋ**
2. **ਸਰਵਰ ਲੌਗਾਂ ਵਿੱਚ ਗਲਤੀ ਸੁਨੇਹੇ ਚੈੱਕ ਕਰੋ**
3. **ਕਲਾਇੰਟ ਅਤੇ ਸਰਵਰ ਵਿਚਕਾਰ ਟੂਲ ਨਾਮ ਅਤੇ ਸਿਗਨੇਚਰ ਮਿਲਦੇ ਹਨ ਜਾਂ ਨਹੀਂ ਵੇਰੋ**
4. **ਸਰਵਰ ਕਾਰਗੁਜ਼ਾਰੀ ਦੀ ਪੁਸ਼ਟੀ ਲਈ ਪਹਿਲਾਂ MCP Inspector ਨਾਲ ਟੈਸਟ ਕਰੋ**

## Related Documentation

- [Main Client Tutorial](./README.md)
- [MCP Server Examples](../../../../03-GettingStarted/01-first-server)
- [MCP with LLM Integration](../../../../03-GettingStarted/03-llm-client)
- [Official MCP Documentation](https://modelcontextprotocol.io/)

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।