<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:31:22+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "pa"
}
-->
# Basic Calculator MCP Service

ਇਹ ਸੇਵਾ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ (MCP) ਰਾਹੀਂ ਬੇਸਿਕ ਕੈਲਕੂਲੇਟਰ ਓਪਰੇਸ਼ਨ ਪ੍ਰਦਾਨ ਕਰਦੀ ਹੈ, ਜੋ Spring Boot ਦੇ WebFlux ਟਰਾਂਸਪੋਰਟ ਨਾਲ ਬਣਾਈ ਗਈ ਹੈ। ਇਹ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਸਿੱਖ ਰਹੇ ਨਵਾਂ ਸਿੱਖਿਆਰਥੀਆਂ ਲਈ ਇੱਕ ਸਧਾਰਣ ਉਦਾਹਰਨ ਵਜੋਂ ਤਿਆਰ ਕੀਤੀ ਗਈ ਹੈ।

ਵਧੇਰੇ ਜਾਣਕਾਰੀ ਲਈ, [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) ਰੈਫਰੈਂਸ ਡੌਕਯੂਮੈਂਟ ਵੇਖੋ।

## ਸੇਵਾ ਦੀ ਵਰਤੋਂ

ਸੇਵਾ MCP ਪ੍ਰੋਟੋਕੋਲ ਰਾਹੀਂ ਹੇਠਾਂ ਦਿੱਤੇ API ਐਂਡਪੌਇੰਟ ਪ੍ਰਦਾਨ ਕਰਦੀ ਹੈ:

- `add(a, b)`: ਦੋ ਨੰਬਰਾਂ ਨੂੰ ਜੋੜੋ
- `subtract(a, b)`: ਪਹਿਲੇ ਨੰਬਰ ਵਿੱਚੋਂ ਦੂਜੇ ਨੰਬਰ ਨੂੰ ਘਟਾਓ
- `multiply(a, b)`: ਦੋ ਨੰਬਰਾਂ ਨੂੰ ਗੁਣਾ ਕਰੋ
- `divide(a, b)`: ਪਹਿਲੇ ਨੰਬਰ ਨੂੰ ਦੂਜੇ ਨਾਲ ਭਾਗ ਦਿਓ (ਜਿੱਥੇ ਜ਼ੀਰੋ ਦੀ ਜਾਂਚ ਕੀਤੀ ਜਾਵੇ)
- `power(base, exponent)`: ਕਿਸੇ ਨੰਬਰ ਦੀ ਘਾਤ ਉਤਾਰੋ
- `squareRoot(number)`: ਵਰਗਮੂਲ ਕੱਢੋ (ਨਕਾਰਾਤਮਕ ਨੰਬਰ ਦੀ ਜਾਂਚ ਨਾਲ)
- `modulus(a, b)`: ਭਾਗ ਦਿੰਦੇ ਸਮੇਂ ਬਾਕੀ ਰਹਿਣ ਵਾਲਾ ਹਿੱਸਾ ਕੱਢੋ
- `absolute(number)`: ਮੂਲ ਮੂਲਯ ਕੱਢੋ

## Dependencies

ਪ੍ਰੋਜੈਕਟ ਲਈ ਹੇਠਾਂ ਦਿੱਤੀਆਂ ਮੁੱਖ dependencies ਦੀ ਲੋੜ ਹੈ:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## ਪ੍ਰੋਜੈਕਟ ਬਣਾਉਣਾ

Maven ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪ੍ਰੋਜੈਕਟ ਬਣਾਓ:
```bash
./mvnw clean install -DskipTests
```

## ਸਰਵਰ ਚਲਾਉਣਾ

### Java ਦੀ ਵਰਤੋਂ ਕਰਕੇ

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### MCP Inspector ਦੀ ਵਰਤੋਂ ਕਰਕੇ

MCP Inspector ਇੱਕ ਮਦਦਗਾਰ ਟੂਲ ਹੈ MCP ਸੇਵਾਵਾਂ ਨਾਲ ਇੰਟਰੈਕਟ ਕਰਨ ਲਈ। ਇਸ ਕੈਲਕੂਲੇਟਰ ਸੇਵਾ ਨਾਲ ਇਸਦੀ ਵਰਤੋਂ ਕਰਨ ਲਈ:

1. **ਨਵੀਂ ਟਰਮੀਨਲ ਵਿੰਡੋ ਵਿੱਚ MCP Inspector ਇੰਸਟਾਲ ਅਤੇ ਚਲਾਓ**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **ਐਪ ਦੁਆਰਾ ਦਿਖਾਈ ਗਈ URL ਤੇ ਜਾ ਕੇ ਵੈੱਬ UI ਖੋਲ੍ਹੋ** (ਆਮ ਤੌਰ 'ਤੇ http://localhost:6274)

3. **ਕਨੈਕਸ਼ਨ ਕਨਫਿਗਰ ਕਰੋ**:
   - ਟਰਾਂਸਪੋਰਟ ਟਾਈਪ "SSE" ਸੈੱਟ ਕਰੋ
   - URL ਨੂੰ ਆਪਣੇ ਚੱਲ ਰਹੇ ਸਰਵਰ ਦੇ SSE ਐਂਡਪੌਇੰਟ 'ਤੇ ਸੈੱਟ ਕਰੋ: `http://localhost:8080/sse`
   - "Connect" 'ਤੇ ਕਲਿੱਕ ਕਰੋ

4. **ਟੂਲ ਵਰਤੋ**:
   - "List Tools" 'ਤੇ ਕਲਿੱਕ ਕਰਕੇ ਉਪਲਬਧ ਕੈਲਕੂਲੇਟਰ ਓਪਰੇਸ਼ਨ ਵੇਖੋ
   - ਕਿਸੇ ਟੂਲ ਨੂੰ ਚੁਣੋ ਅਤੇ "Run Tool" 'ਤੇ ਕਲਿੱਕ ਕਰਕੇ ਓਪਰੇਸ਼ਨ ਚਲਾਓ

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.pa.png)

**ਡਿਸਕਲੇਮਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉੱਪਜਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।