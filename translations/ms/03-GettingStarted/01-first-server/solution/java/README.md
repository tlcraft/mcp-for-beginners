<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:34:48+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "ms"
}
-->
# Basic Calculator MCP Service

This service offers basic calculator functions through the Model Context Protocol (MCP) using Spring Boot with WebFlux transport. It’s designed as a simple example for those new to MCP implementations.

For more details, see the [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) reference documentation.


## Using the Service

The service provides the following API endpoints via the MCP protocol:

- `add(a, b)`: Add two numbers
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (checks for zero)
- `power(base, exponent)`: Calculate the power of a number
- `squareRoot(number)`: Calculate the square root (checks for negative numbers)
- `modulus(a, b)`: Calculate the remainder of a division
- `absolute(number)`: Calculate the absolute value

## Dependencies

The project depends on the following key libraries:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Building the Project

Build the project using Maven:
```bash
./mvnw clean install -DskipTests
```

## Running the Server

### Using Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Using MCP Inspector

MCP Inspector is a handy tool for working with MCP services. To use it with this calculator service:

1. **Install and start MCP Inspector** in a new terminal window:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Open the web UI** by clicking the URL shown by the app (usually http://localhost:6274)

3. **Set up the connection**:
   - Choose "SSE" as the transport type
   - Enter your server’s SSE endpoint URL: `http://localhost:8080/sse`
   - Click "Connect"

4. **Use the tools**:
   - Click "List Tools" to view available calculator operations
   - Select a tool and click "Run Tool" to perform an operation

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.ms.png)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.