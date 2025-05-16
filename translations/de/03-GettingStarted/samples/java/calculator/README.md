<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "13231e9951b68efd9df8c56bd5cdb27e",
  "translation_date": "2025-05-16T15:02:55+00:00",
  "source_file": "03-GettingStarted/samples/java/calculator/README.md",
  "language_code": "de"
}
-->
# Basic Calculator MCP Service

Dieser Service bietet grundlegende Rechnerfunktionen über das Model Context Protocol (MCP) mit Spring Boot und WebFlux-Transport an. Er ist als einfaches Beispiel für Einsteiger konzipiert, die MCP-Implementierungen kennenlernen möchten.

Weitere Informationen finden Sie in der [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html)-Referenzdokumentation.

## Überblick

Der Service zeigt:
- Unterstützung für SSE (Server-Sent Events)
- Automatische Tool-Registrierung mittels der Spring AI `@Tool` Annotation
- Grundlegende Rechnerfunktionen:
  - Addition, Subtraktion, Multiplikation, Division
  - Potenz- und Quadratwurzelberechnung
  - Modulo (Rest) und Absolutwert
  - Hilfefunktion zur Beschreibung der Operationen

## Funktionen

Dieser Rechner-Service bietet folgende Möglichkeiten:

1. **Grundlegende arithmetische Operationen**:
   - Addition von zwei Zahlen
   - Subtraktion einer Zahl von einer anderen
   - Multiplikation von zwei Zahlen
   - Division einer Zahl durch eine andere (mit Überprüfung auf Division durch Null)

2. **Erweiterte Operationen**:
   - Potenzberechnung (Basis hoch Exponent)
   - Quadratwurzelberechnung (mit Prüfung auf negative Zahlen)
   - Modulo-Berechnung (Restwert)
   - Berechnung des Absolutwerts

3. **Hilfesystem**:
   - Eingebaute Hilfefunktion, die alle verfügbaren Operationen erklärt

## Nutzung des Services

Der Service stellt über das MCP-Protokoll folgende API-Endpunkte bereit:

- `add(a, b)`: Addiert zwei Zahlen
- `subtract(a, b)`: Subtrahiert die zweite Zahl von der ersten
- `multiply(a, b)`: Multipliziert zwei Zahlen
- `divide(a, b)`: Dividiert die erste Zahl durch die zweite (mit Nullprüfung)
- `power(base, exponent)`: Berechnet die Potenz einer Zahl
- `squareRoot(number)`: Berechnet die Quadratwurzel (mit Prüfung auf negative Zahl)
- `modulus(a, b)`: Berechnet den Restwert bei Division
- `absolute(number)`: Berechnet den Absolutwert
- `help()`: Liefert Informationen über verfügbare Operationen

## Test-Client

Ein einfacher Test-Client ist im `com.microsoft.mcp.sample.client` Paket enthalten. Die `SampleCalculatorClient` Klasse demonstriert die verfügbaren Operationen des Rechner-Services.

## Nutzung des LangChain4j Clients

Das Projekt enthält einen LangChain4j Beispiel-Client in `com.microsoft.mcp.sample.client.LangChain4jClient`, der zeigt, wie der Rechner-Service mit LangChain4j und GitHub-Modellen integriert wird:

### Voraussetzungen

1. **GitHub Token einrichten**:

   Um GitHubs KI-Modelle (wie phi-4) zu nutzen, benötigen Sie einen persönlichen Zugriffstoken von GitHub:

   a. Gehen Sie zu Ihren GitHub-Kontoeinstellungen: https://github.com/settings/tokens

   b. Klicken Sie auf „Generate new token“ → „Generate new token (classic)“

   c. Vergeben Sie einen aussagekräftigen Namen für Ihren Token

   d. Wählen Sie folgende Berechtigungen aus:
      - `repo` (Vollzugriff auf private Repositories)
      - `read:org` (Lesen von Organisations- und Teammitgliedschaften, Lesen von Organisationsprojekten)
      - `gist` (Erstellen von Gists)
      - `user:email` (Zugriff auf Benutzer-E-Mail-Adressen (nur lesen))

   e. Klicken Sie auf „Generate token“ und kopieren Sie Ihren neuen Token

   f. Legen Sie ihn als Umgebungsvariable fest:

      Unter Windows:
      ```
      set GITHUB_TOKEN=your-github-token
      ```

      Unter macOS/Linux:
      ```bash
      export GITHUB_TOKEN=your-github-token
      ```

   g. Für eine dauerhafte Einrichtung fügen Sie ihn über die Systemeinstellungen zu Ihren Umgebungsvariablen hinzu

2. Fügen Sie die LangChain4j GitHub-Abhängigkeit zu Ihrem Projekt hinzu (bereits in pom.xml enthalten):
   ```xml
   <dependency>
       <groupId>dev.langchain4j</groupId>
       <artifactId>langchain4j-github</artifactId>
       <version>${langchain4j.version}</version>
   </dependency>
   ```

3. Stellen Sie sicher, dass der Rechner-Server auf `localhost:8080` läuft

### Ausführen des LangChain4j Clients

Dieses Beispiel zeigt:
- Verbindung zum Rechner-MCP-Server über SSE-Transport
- Nutzung von LangChain4j zur Erstellung eines Chatbots, der Rechnerfunktionen verwendet
- Integration mit GitHub KI-Modellen (aktuell das phi-4 Modell)

Der Client sendet folgende Beispielanfragen, um die Funktionalität zu demonstrieren:
1. Berechnung der Summe zweier Zahlen
2. Berechnung der Quadratwurzel einer Zahl
3. Abruf von Hilfsinformationen zu verfügbaren Rechner-Operationen

Führen Sie das Beispiel aus und überprüfen Sie die Konsolenausgabe, um zu sehen, wie das KI-Modell die Rechner-Tools zur Beantwortung der Anfragen nutzt.

### GitHub Modell-Konfiguration

Der LangChain4j Client ist so konfiguriert, dass er GitHubs phi-4 Modell mit folgenden Einstellungen verwendet:

```java
ChatLanguageModel model = GitHubChatModel.builder()
    .apiKey(System.getenv("GITHUB_TOKEN"))
    .timeout(Duration.ofSeconds(60))
    .modelName("phi-4")
    .logRequests(true)
    .logResponses(true)
    .build();
```

Um andere GitHub-Modelle zu verwenden, ändern Sie einfach den Parameter `modelName` auf ein anderes unterstütztes Modell (z.B. "claude-3-haiku-20240307", "llama-3-70b-8192" usw.).

## Abhängigkeiten

Das Projekt benötigt folgende wichtige Abhängigkeiten:

```xml
<!-- For MCP Server -->
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>

<!-- For LangChain4j integration -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-mcp</artifactId>
    <version>${langchain4j.version}</version>
</dependency>

<!-- For GitHub models support -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-github</artifactId>
    <version>${langchain4j.version}</version>
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

Der MCP Inspector ist ein nützliches Tool zur Interaktion mit MCP-Services. So nutzen Sie ihn mit diesem Rechner-Service:

1. **Installieren und starten Sie MCP Inspector** in einem neuen Terminalfenster:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Öffnen Sie die Weboberfläche**, indem Sie auf die vom Programm angezeigte URL klicken (normalerweise http://localhost:6274)

3. **Konfigurieren Sie die Verbindung**:
   - Wählen Sie als Transporttyp „SSE“
   - Geben Sie die URL zum SSE-Endpunkt Ihres laufenden Servers ein: `http://localhost:8080/sse`
   - Klicken Sie auf „Connect“

4. **Verwenden Sie die Tools**:
   - Klicken Sie auf „List Tools“, um verfügbare Rechner-Operationen anzuzeigen
   - Wählen Sie ein Tool aus und klicken Sie auf „Run Tool“, um eine Operation auszuführen

![MCP Inspector Screenshot](../../../../../../translated_images/tool.c75a0b2380efcf1a47a8478f54380a36ddcca7943b98f56dabbac8b07e15c3bb.de.png)

### Mit Docker

Das Projekt enthält eine Dockerfile für die containerisierte Bereitstellung:

1. **Bauen Sie das Docker-Image**:
   ```bash
   docker build -t calculator-mcp-service .
   ```

2. **Starten Sie den Docker-Container**:
   ```bash
   docker run -p 8080:8080 calculator-mcp-service
   ```

Dies bewirkt:
- Erstellung eines mehrstufigen Docker-Images mit Maven 3.9.9 und Eclipse Temurin 24 JDK
- Erstellung eines optimierten Container-Images
- Exponierung des Services auf Port 8080
- Start des MCP-Rechner-Services im Container

Sie können den Service unter `http://localhost:8080` erreichen, sobald der Container läuft.

## Fehlerbehebung

### Häufige Probleme mit dem GitHub Token

1. **Token-Berechtigungsprobleme**: Wenn Sie einen 403 Forbidden-Fehler erhalten, prüfen Sie, ob Ihr Token die korrekten Berechtigungen gemäß den Voraussetzungen besitzt.

2. **Token nicht gefunden**: Wenn die Fehlermeldung „No API key found“ erscheint, stellen Sie sicher, dass die Umgebungsvariable GITHUB_TOKEN korrekt gesetzt ist.

3. **Rate Limiting**: Die GitHub API unterliegt Ratenbegrenzungen. Wenn Sie eine Fehlermeldung wegen Überschreitung der Rate (Statuscode 429) erhalten, warten Sie einige Minuten und versuchen Sie es erneut.

4. **Token-Ablauf**: GitHub-Tokens können ablaufen. Wenn nach einiger Zeit Authentifizierungsfehler auftreten, generieren Sie einen neuen Token und aktualisieren Sie die Umgebungsvariable.

Bei weiteren Fragen konsultieren Sie bitte die [LangChain4j Dokumentation](https://github.com/langchain4j/langchain4j) oder die [GitHub API Dokumentation](https://docs.github.com/en/rest).

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.