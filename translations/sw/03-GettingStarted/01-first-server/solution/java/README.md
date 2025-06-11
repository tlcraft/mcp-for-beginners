<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:35:12+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "sw"
}
-->
# Basic Calculator MCP Service

Huduma hii hutoa shughuli za msingi za kalkuleta kupitia Model Context Protocol (MCP) kwa kutumia Spring Boot na usafirishaji wa WebFlux. Imeundwa kama mfano rahisi kwa wanaoanza kujifunza kuhusu utekelezaji wa MCP.

Kwa maelezo zaidi, angalia nyaraka za marejeleo za [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html).

## Using the Service

Huduma inaonyesha API endpoints zifuatazo kupitia itifaki ya MCP:

- `add(a, b)`: Ongeza nambari mbili pamoja
- `subtract(a, b)`: Toa nambari ya pili kutoka ya kwanza
- `multiply(a, b)`: Zidisha nambari mbili
- `divide(a, b)`: Gawanya nambari ya kwanza kwa ya pili (kwa ukaguzi wa sifuri)
- `power(base, exponent)`: Hesabu nguvu ya nambari
- `squareRoot(number)`: Hesabu mzizi wa mraba (kwa ukaguzi wa nambari hasi)
- `modulus(a, b)`: Hesabu mabaki wakati wa kugawanya
- `absolute(number)`: Hesabu thamani kamili (absolute value)

## Dependencies

Mradi unahitaji utegemezi muhimu zifuatazo:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Building the Project

Jenga mradi kwa kutumia Maven:
```bash
./mvnw clean install -DskipTests
```

## Running the Server

### Using Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Using MCP Inspector

MCP Inspector ni zana yenye msaada kwa kuingiliana na huduma za MCP. Ili kuitumia na huduma hii ya kalkuleta:

1. **Sakinisha na endesha MCP Inspector** katika dirisha jipya la terminal:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Fikia UI ya wavuti** kwa kubofya URL inayotolewa na app (kawaida http://localhost:6274)

3. **Sanidi muunganisho**:
   - Weka aina ya usafirishaji kuwa "SSE"
   - Weka URL ya endpoint ya SSE ya seva yako inayotumika: `http://localhost:8080/sse`
   - Bonyeza "Connect"

4. **Tumia zana**:
   - Bonyeza "List Tools" kuona shughuli za kalkuleta zilizopo
   - Chagua zana na bonyeza "Run Tool" kutekeleza shughuli

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.sw.png)

**Kiondoa lawama**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asilia katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya mtaalamu wa binadamu inashauriwa. Hatubebwi jukumu lolote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.