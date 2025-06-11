<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:34:59+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "tl"
}
-->
# Basic Calculator MCP Service

Ang serbisyong ito ay nagbibigay ng mga pangunahing operasyon ng calculator sa pamamagitan ng Model Context Protocol (MCP) gamit ang Spring Boot na may WebFlux transport. Dinisenyo ito bilang isang simpleng halimbawa para sa mga baguhan na nag-aaral tungkol sa mga implementasyon ng MCP.

Para sa karagdagang impormasyon, tingnan ang [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) na dokumentasyon ng sanggunian.


## Paggamit ng Serbisyo

Ipinapakita ng serbisyo ang mga sumusunod na API endpoints sa pamamagitan ng MCP protocol:

- `add(a, b)`: Pagdaragdag ng dalawang numero
- `subtract(a, b)`: Pagbabawas ng pangalawang numero mula sa una
- `multiply(a, b)`: Pagmumultiply ng dalawang numero
- `divide(a, b)`: Paghahati ng unang numero sa pangalawa (may pagsusuri sa zero)
- `power(base, exponent)`: Pagkalkula ng power ng isang numero
- `squareRoot(number)`: Pagkalkula ng square root (may pagsusuri sa negatibong numero)
- `modulus(a, b)`: Pagkalkula ng remainder kapag naghahati
- `absolute(number)`: Pagkalkula ng absolute value

## Mga Dependencies

Kailangan ng proyekto ang mga sumusunod na pangunahing dependencies:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Pagbuo ng Proyekto

I-build ang proyekto gamit ang Maven:
```bash
./mvnw clean install -DskipTests
```

## Pagpapatakbo ng Server

### Gamit ang Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Gamit ang MCP Inspector

Ang MCP Inspector ay isang kapaki-pakinabang na tool para makipag-ugnayan sa mga MCP services. Para magamit ito sa calculator service na ito:

1. **I-install at patakbuhin ang MCP Inspector** sa isang bagong terminal window:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Buksan ang web UI** sa pamamagitan ng pag-click sa URL na ipinapakita ng app (karaniwang http://localhost:6274)

3. **I-configure ang koneksyon**:
   - Itakda ang transport type sa "SSE"
   - Itakda ang URL sa SSE endpoint ng iyong tumatakbong server: `http://localhost:8080/sse`
   - I-click ang "Connect"

4. **Gamitin ang mga tools**:
   - I-click ang "List Tools" para makita ang mga available na operasyon ng calculator
   - Pumili ng tool at i-click ang "Run Tool" para isagawa ang operasyon

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.tl.png)

**Pagtatangi**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o kamalian. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pinakapinagkakatiwalaang sanggunian. Para sa mga mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.