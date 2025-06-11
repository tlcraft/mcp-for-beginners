<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:28:12+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "de"
}
-->
# Basic Calculator MCP Service

Dieser Service stellt grundlegende Rechnerfunktionen über das Model Context Protocol (MCP) mit Spring Boot und WebFlux-Transport bereit. Er ist als einfaches Beispiel für Einsteiger konzipiert, die MCP-Implementierungen kennenlernen möchten.

Weitere Informationen finden Sie in der [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html)-Referenzdokumentation.


## Verwendung des Service

Der Service stellt über das MCP-Protokoll folgende API-Endpunkte bereit:

- `add(a, b)`: Zwei Zahlen addieren
- `subtract(a, b)`: Die zweite Zahl von der ersten subtrahieren
- `multiply(a, b)`: Zwei Zahlen multiplizieren
- `divide(a, b)`: Die erste Zahl durch die zweite teilen (mit Nullprüfung)
- `power(base, exponent)`: Die Potenz einer Zahl berechnen
- `squareRoot(number)`: Die Quadratwurzel berechnen (mit Prüfung auf negative Zahlen)
- `modulus(a, b)`: Den Rest bei der Division berechnen
- `absolute(number)`: Den Absolutwert berechnen

## Abhängigkeiten

Für das Projekt werden folgende wichtige Abhängigkeiten benötigt:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Projekt bauen

Bauen Sie das Projekt mit Maven:
```bash
./mvnw clean install -DskipTests
```

## Server starten

### Mit Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Mit MCP Inspector

Der MCP Inspector ist ein hilfreiches Werkzeug zur Interaktion mit MCP-Services. Um ihn mit diesem Rechner-Service zu verwenden:

1. **Installieren und starten Sie MCP Inspector** in einem neuen Terminalfenster:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Greifen Sie auf die Weboberfläche zu**, indem Sie auf die vom Programm angezeigte URL klicken (in der Regel http://localhost:6274)

3. **Konfigurieren Sie die Verbindung**:
   - Stellen Sie den Transporttyp auf „SSE“
   - Geben Sie die SSE-Endpunkt-URL Ihres laufenden Servers ein: `http://localhost:8080/sse`
   - Klicken Sie auf „Connect“

4. **Verwenden Sie die Werkzeuge**:
   - Klicken Sie auf „List Tools“, um verfügbare Rechneroperationen anzuzeigen
   - Wählen Sie ein Werkzeug aus und klicken Sie auf „Run Tool“, um eine Operation auszuführen

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.de.png)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.