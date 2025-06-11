<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:35:26+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "hu"
}
-->
# Alap Számológép MCP Szolgáltatás

Ez a szolgáltatás alapvető számológép műveleteket kínál a Model Context Protocol (MCP) segítségével, Spring Boot és WebFlux szállítással. Egyszerű példaként készült kezdők számára, akik az MCP megvalósításokat tanulják.

További információkért lásd a [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) referencia dokumentációt.

## A szolgáltatás használata

A szolgáltatás a következő API végpontokat teszi elérhetővé az MCP protokollon keresztül:

- `add(a, b)`: Két szám összeadása
- `subtract(a, b)`: Második szám kivonása az elsőből
- `multiply(a, b)`: Két szám szorzása
- `divide(a, b)`: Az első szám osztása a másodikkal (nulla ellenőrzéssel)
- `power(base, exponent)`: Egy szám hatványozása
- `squareRoot(number)`: Négyzetgyök számítása (negatív szám ellenőrzéssel)
- `modulus(a, b)`: Maradék számítása osztáskor
- `absolute(number)`: Abszolút érték számítása

## Függőségek

A projekt a következő kulcsfontosságú függőségeket igényli:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## A projekt építése

A projekt Maven segítségével építhető:

```bash
./mvnw clean install -DskipTests
```

## A szerver futtatása

### Java használatával

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### MCP Inspector használata

Az MCP Inspector egy hasznos eszköz az MCP szolgáltatásokkal való interakcióhoz. Az alábbi lépésekkel használhatod ezt a számológép szolgáltatást:

1. **Telepítsd és indítsd el az MCP Inspectort** egy új terminál ablakban:  
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Nyisd meg a webes felületet** a megjelenő URL-re kattintva (általában http://localhost:6274)

3. **Állítsd be a kapcsolatot**:  
   - Válaszd a "SSE" szállítási típust  
   - Állítsd be az URL-t a futó szerver SSE végpontjára: `http://localhost:8080/sse`  
   - Kattints a "Connect" gombra

4. **Használd az eszközöket**:  
   - Kattints a "List Tools" gombra az elérhető számológép műveletek megtekintéséhez  
   - Válassz ki egy eszközt, majd kattints a "Run Tool" gombra a művelet végrehajtásához

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.hu.png)

**Nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy helytelen értelmezésekért.