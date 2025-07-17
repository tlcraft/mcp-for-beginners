<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:29:32+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "de"
}
-->
# Vollständige MCP-Client-Beispiele

Dieses Verzeichnis enthält vollständige, funktionierende Beispiele von MCP-Clients in verschiedenen Programmiersprachen. Jeder Client zeigt die volle Funktionalität, die im Haupt-README.md-Tutorial beschrieben ist.

## Verfügbare Clients

### 1. Java Client (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) über HTTP
- **Zielserver**: `http://localhost:8080`
- **Funktionen**: 
  - Verbindungsaufbau und Ping
  - Auflistung der Tools
  - Rechneroperationen (addieren, subtrahieren, multiplizieren, dividieren, Hilfe)
  - Fehlerbehandlung und Ergebnisextraktion

**Zum Ausführen:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Client (`client_example_csharp.cs`)
- **Transport**: Stdio (Standard Ein-/Ausgabe)
- **Zielserver**: Lokaler .NET MCP-Server via dotnet run
- **Funktionen**:
  - Automatischer Serverstart über stdio-Transport
  - Auflistung von Tools und Ressourcen
  - Rechneroperationen
  - JSON-Ergebnisparsing
  - Umfassende Fehlerbehandlung

**Zum Ausführen:**
```bash
dotnet run
```

### 3. TypeScript Client (`client_example_typescript.ts`)
- **Transport**: Stdio (Standard Ein-/Ausgabe)
- **Zielserver**: Lokaler Node.js MCP-Server
- **Funktionen**:
  - Vollständige MCP-Protokollunterstützung
  - Operationen mit Tools, Ressourcen und Prompts
  - Rechneroperationen
  - Ressourcen lesen und Prompts ausführen
  - Robuste Fehlerbehandlung

**Zum Ausführen:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Client (`client_example_python.py`)
- **Transport**: Stdio (Standard Ein-/Ausgabe)  
- **Zielserver**: Lokaler Python MCP-Server
- **Funktionen**:
  - Async/await-Muster für Operationen
  - Entdeckung von Tools und Ressourcen
  - Testen von Rechneroperationen
  - Lesen von Ressourceninhalten
  - Klassenbasierte Organisation

**Zum Ausführen:**
```bash
python client_example_python.py
```

## Gemeinsame Funktionen aller Clients

Jede Client-Implementierung zeigt:

1. **Verbindungsmanagement**
   - Aufbau der Verbindung zum MCP-Server
   - Umgang mit Verbindungsfehlern
   - Sauberes Aufräumen und Ressourcenverwaltung

2. **Server-Erkennung**
   - Auflistung verfügbarer Tools
   - Auflistung verfügbarer Ressourcen (sofern unterstützt)
   - Auflistung verfügbarer Prompts (sofern unterstützt)

3. **Tool-Aufruf**
   - Grundlegende Rechneroperationen (addieren, subtrahieren, multiplizieren, dividieren)
   - Hilfe-Befehl für Serverinformationen
   - Korrekte Übergabe von Argumenten und Ergebnisverarbeitung

4. **Fehlerbehandlung**
   - Verbindungsfehler
   - Fehler bei der Tool-Ausführung
   - Elegantes Scheitern und Benutzerfeedback

5. **Ergebnisverarbeitung**
   - Extrahieren von Textinhalten aus Antworten
   - Formatierung der Ausgabe für bessere Lesbarkeit
   - Umgang mit verschiedenen Antwortformaten

## Voraussetzungen

Bevor Sie diese Clients ausführen, stellen Sie sicher, dass:

1. **Der entsprechende MCP-Server läuft** (aus `../01-first-server/`)
2. **Die benötigten Abhängigkeiten für Ihre Sprache installiert sind**
3. **Die Netzwerkverbindung korrekt ist** (für HTTP-basierte Transporte)

## Wichtige Unterschiede zwischen den Implementierungen

| Sprache   | Transport | Serverstart   | Async-Modell | Wichtige Bibliotheken |
|-----------|-----------|---------------|--------------|----------------------|
| Java      | SSE/HTTP  | Extern        | Synchron     | WebFlux, MCP SDK     |
| C#        | Stdio     | Automatisch   | Async/Await  | .NET MCP SDK         |
| TypeScript| Stdio     | Automatisch   | Async/Await  | Node MCP SDK         |
| Python    | Stdio     | Automatisch   | AsyncIO      | Python MCP SDK       |

## Nächste Schritte

Nach dem Durcharbeiten dieser Client-Beispiele:

1. **Passen Sie die Clients an**, um neue Funktionen oder Operationen hinzuzufügen
2. **Erstellen Sie Ihren eigenen Server** und testen Sie ihn mit diesen Clients
3. **Experimentieren Sie mit verschiedenen Transporten** (SSE vs. Stdio)
4. **Entwickeln Sie eine komplexere Anwendung**, die MCP-Funktionalität integriert

## Fehlerbehebung

### Häufige Probleme

1. **Verbindung abgelehnt**: Stellen Sie sicher, dass der MCP-Server am erwarteten Port/Pfad läuft
2. **Modul nicht gefunden**: Installieren Sie das benötigte MCP SDK für Ihre Sprache
3. **Zugriff verweigert**: Prüfen Sie die Dateiberechtigungen für den stdio-Transport
4. **Tool nicht gefunden**: Vergewissern Sie sich, dass der Server die erwarteten Tools implementiert

### Debug-Tipps

1. **Aktivieren Sie ausführliches Logging** in Ihrem MCP SDK
2. **Überprüfen Sie die Server-Logs** auf Fehlermeldungen
3. **Stellen Sie sicher, dass Tool-Namen und Signaturen** zwischen Client und Server übereinstimmen
4. **Testen Sie zuerst mit MCP Inspector**, um die Serverfunktionalität zu prüfen

## Verwandte Dokumentation

- [Haupt-Client-Tutorial](./README.md)
- [MCP Server-Beispiele](../../../../03-GettingStarted/01-first-server)
- [MCP mit LLM-Integration](../../../../03-GettingStarted/03-llm-client)
- [Offizielle MCP-Dokumentation](https://modelcontextprotocol.io/)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.