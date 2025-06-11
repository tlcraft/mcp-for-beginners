<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:36:29+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "sr"
}
-->
# Basic Calculator MCP Service

Ova usluga pruža osnovne kalkulatorske operacije preko Model Context Protocol (MCP) koristeći Spring Boot sa WebFlux transportom. Dizajnirana je kao jednostavan primer za početnike koji uče o MCP implementacijama.

Za više informacija, pogledajte [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) referentnu dokumentaciju.


## Korišćenje usluge

Usluga izlaže sledeće API krajnje tačke preko MCP protokola:

- `add(a, b)`: Saberi dva broja
- `subtract(a, b)`: Oduzmi drugi broj od prvog
- `multiply(a, b)`: Pomnoži dva broja
- `divide(a, b)`: Podeli prvi broj sa drugim (sa proverom na nulu)
- `power(base, exponent)`: Izračunaj stepen broja
- `squareRoot(number)`: Izračunaj kvadratni koren (sa proverom na negativan broj)
- `modulus(a, b)`: Izračunaj ostatak pri deljenju
- `absolute(number)`: Izračunaj apsolutnu vrednost

## Zavisnosti

Projekat zahteva sledeće ključne zavisnosti:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Pravljenje projekta

Napravite projekat koristeći Maven:
```bash
./mvnw clean install -DskipTests
```

## Pokretanje servera

### Korišćenje Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Korišćenje MCP Inspectora

MCP Inspector je koristan alat za interakciju sa MCP uslugama. Da biste ga koristili sa ovom kalkulatorskom uslugom:

1. **Instalirajte i pokrenite MCP Inspector** u novom terminal prozoru:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Pristupite web korisničkom interfejsu** klikom na URL koji aplikacija prikazuje (obično http://localhost:6274)

3. **Konfigurišite konekciju**:
   - Postavite tip transporta na "SSE"
   - Postavite URL na SSE krajnju tačku vašeg pokrenutog servera: `http://localhost:8080/sse`
   - Kliknite na "Connect"

4. **Koristite alate**:
   - Kliknite na "List Tools" da vidite dostupne kalkulatorske operacije
   - Izaberite alat i kliknite na "Run Tool" da izvršite operaciju

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.sr.png)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Не сносимо одговорност за било какве неспоразуме или погрешне тумачења која могу проистећи из коришћења овог превода.