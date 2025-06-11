<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:36:54+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "sl"
}
-->
# Basic Calculator MCP Service

Ta storitev omogoča osnovne kalkulator funkcije preko Model Context Protocol (MCP) z uporabo Spring Boot in WebFlux transporta. Namenjena je kot preprost primer za začetnike, ki se učijo o MCP implementacijah.

Za več informacij glej [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) referenčno dokumentacijo.


## Uporaba storitve

Storitev ponuja naslednje API končne točke preko MCP protokola:

- `add(a, b)`: Seštej dve števili
- `subtract(a, b)`: Odštej drugo število od prvega
- `multiply(a, b)`: Pomnoži dve števili
- `divide(a, b)`: Deli prvo število z drugim (s preverjanjem ničle)
- `power(base, exponent)`: Izračunaj potenciranje števila
- `squareRoot(number)`: Izračunaj kvadratni koren (s preverjanjem negativnih števil)
- `modulus(a, b)`: Izračunaj ostanek pri deljenju
- `absolute(number)`: Izračunaj absolutno vrednost

## Odvisnosti

Projekt zahteva naslednje ključne odvisnosti:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Gradnja projekta

Projekt zgradi z uporabo Mavena:
```bash
./mvnw clean install -DskipTests
```

## Zagon strežnika

### Z uporabo Jave

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Z uporabo MCP Inspectorja

MCP Inspector je uporabno orodje za delo z MCP storitvami. Za uporabo z to kalkulator storitvijo:

1. **Namesti in zaženi MCP Inspector** v novem terminal oknu:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Dostopi do spletnega vmesnika** s klikom na URL, ki ga prikaže aplikacija (običajno http://localhost:6274)

3. **Nastavi povezavo**:
   - Nastavi transport tip na "SSE"
   - Vnesi URL do SSE končne točke tvojega strežnika: `http://localhost:8080/sse`
   - Klikni "Connect"

4. **Uporabi orodja**:
   - Klikni "List Tools" za ogled razpoložljivih kalkulator funkcij
   - Izberi orodje in klikni "Run Tool" za izvedbo operacije

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.sl.png)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazumevanja ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.