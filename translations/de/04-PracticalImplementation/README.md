<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:32:24+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "de"
}
-->
# Praktische Umsetzung

Die praktische Umsetzung ist der Moment, in dem die Stärke des Model Context Protocol (MCP) greifbar wird. Während das Verständnis der Theorie und Architektur hinter MCP wichtig ist, zeigt sich der wahre Wert erst, wenn Sie diese Konzepte anwenden, um Lösungen zu entwickeln, zu testen und bereitzustellen, die reale Probleme lösen. Dieses Kapitel überbrückt die Lücke zwischen theoretischem Wissen und praktischer Entwicklung und führt Sie durch den Prozess, MCP-basierte Anwendungen zum Leben zu erwecken.

Egal, ob Sie intelligente Assistenten entwickeln, KI in Geschäftsabläufe integrieren oder maßgeschneiderte Tools für die Datenverarbeitung erstellen – MCP bietet eine flexible Grundlage. Das sprachunabhängige Design und die offiziellen SDKs für gängige Programmiersprachen machen es einer breiten Entwicklergruppe zugänglich. Durch die Nutzung dieser SDKs können Sie schnell Prototypen erstellen, iterieren und Ihre Lösungen plattform- und umgebungsübergreifend skalieren.

In den folgenden Abschnitten finden Sie praxisnahe Beispiele, Beispielcode und Bereitstellungsstrategien, die zeigen, wie MCP in C#, Java, TypeScript, JavaScript und Python implementiert wird. Sie lernen auch, wie Sie MCP-Server debuggen und testen, APIs verwalten und Lösungen mit Azure in der Cloud bereitstellen. Diese praktischen Ressourcen sollen Ihr Lernen beschleunigen und Ihnen helfen, robuste, produktionsreife MCP-Anwendungen sicher zu entwickeln.

## Überblick

Diese Lektion konzentriert sich auf praktische Aspekte der MCP-Implementierung in verschiedenen Programmiersprachen. Wir zeigen, wie Sie die MCP-SDKs in C#, Java, TypeScript, JavaScript und Python verwenden, um robuste Anwendungen zu erstellen, MCP-Server zu debuggen und zu testen sowie wiederverwendbare Ressourcen, Prompts und Tools zu erstellen.

## Lernziele

Am Ende dieser Lektion können Sie:
- MCP-Lösungen mit offiziellen SDKs in verschiedenen Programmiersprachen implementieren
- MCP-Server systematisch debuggen und testen
- Serverfunktionen (Ressourcen, Prompts und Tools) erstellen und nutzen
- Effektive MCP-Workflows für komplexe Aufgaben entwerfen
- MCP-Implementierungen hinsichtlich Leistung und Zuverlässigkeit optimieren

## Offizielle SDK-Ressourcen

Das Model Context Protocol bietet offizielle SDKs für mehrere Sprachen:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Arbeiten mit MCP SDKs

Dieser Abschnitt bietet praktische Beispiele zur Implementierung von MCP in verschiedenen Programmiersprachen. Beispielcode finden Sie im Verzeichnis `samples`, sortiert nach Sprache.

### Verfügbare Beispiele

Das Repository enthält [Beispielimplementierungen](../../../04-PracticalImplementation/samples) in folgenden Sprachen:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Jedes Beispiel zeigt zentrale MCP-Konzepte und Implementierungsmuster für die jeweilige Sprache und Umgebung.

## Kernfunktionen des Servers

MCP-Server können jede beliebige Kombination dieser Funktionen implementieren:

### Ressourcen
Ressourcen liefern Kontext und Daten, die vom Nutzer oder KI-Modell verwendet werden können:
- Dokumenten-Repositorys
- Wissensdatenbanken
- Strukturierte Datenquellen
- Dateisysteme

### Prompts
Prompts sind vorgefertigte Nachrichten und Abläufe für Nutzer:
- Vordefinierte Gesprächsvorlagen
- Geführte Interaktionsmuster
- Spezialisierte Dialogstrukturen

### Tools
Tools sind Funktionen, die vom KI-Modell ausgeführt werden:
- Dienstprogramme zur Datenverarbeitung
- Integration externer APIs
- Rechenkapazitäten
- Suchfunktionen

## Beispielimplementierungen: C#

Das offizielle C# SDK-Repository enthält mehrere Beispielimplementierungen, die verschiedene Aspekte von MCP zeigen:

- **Basic MCP Client**: Einfaches Beispiel, wie man einen MCP-Client erstellt und Tools aufruft
- **Basic MCP Server**: Minimale Serverimplementierung mit grundlegender Tool-Registrierung
- **Advanced MCP Server**: Voll ausgestatteter Server mit Tool-Registrierung, Authentifizierung und Fehlerbehandlung
- **ASP.NET Integration**: Beispiele zur Integration mit ASP.NET Core
- **Tool-Implementierungsmuster**: Verschiedene Muster zur Umsetzung von Tools mit unterschiedlicher Komplexität

Das MCP C# SDK befindet sich in der Vorschauphase, und die APIs können sich ändern. Wir werden diesen Blog kontinuierlich aktualisieren, während sich das SDK weiterentwickelt.

### Wichtige Funktionen
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Anleitung zum Erstellen Ihres [ersten MCP Servers](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Für vollständige C#-Implementierungsbeispiele besuchen Sie das [offizielle C# SDK-Beispiel-Repository](https://github.com/modelcontextprotocol/csharp-sdk).

## Beispielimplementierung: Java Implementation

Das Java SDK bietet robuste MCP-Implementierungsoptionen mit Enterprise-Features.

### Wichtige Funktionen

- Integration des Spring Frameworks
- Starke Typsicherheit
- Unterstützung für reaktive Programmierung
- Umfassende Fehlerbehandlung

Für ein vollständiges Java-Implementierungsbeispiel siehe [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) im Samples-Verzeichnis.

## Beispielimplementierung: JavaScript Implementation

Das JavaScript SDK bietet einen leichtgewichtigen und flexiblen Ansatz zur MCP-Implementierung.

### Wichtige Funktionen

- Unterstützung für Node.js und Browser
- Promise-basierte API
- Einfache Integration mit Express und anderen Frameworks
- WebSocket-Unterstützung für Streaming

Für ein vollständiges JavaScript-Implementierungsbeispiel siehe [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) im Samples-Verzeichnis.

## Beispielimplementierung: Python Implementation

Das Python SDK bietet einen „pythonic“ Ansatz zur MCP-Implementierung mit exzellenter Integration von ML-Frameworks.

### Wichtige Funktionen

- Async/await-Unterstützung mit asyncio
- Integration mit Flask und FastAPI
- Einfache Tool-Registrierung
- Native Integration mit populären ML-Bibliotheken

Für ein vollständiges Python-Implementierungsbeispiel siehe [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) im Samples-Verzeichnis.

## API-Management

Azure API Management ist eine hervorragende Lösung, um MCP-Server abzusichern. Die Idee ist, eine Azure API Management-Instanz vor Ihren MCP-Server zu schalten und Funktionen zu nutzen, die Sie wahrscheinlich benötigen, wie:

- Ratenbegrenzung
- Tokenverwaltung
- Monitoring
- Lastverteilung
- Sicherheit

### Azure-Beispiel

Hier ein Azure-Beispiel, das genau das macht, also [Erstellen eines MCP Servers und Absicherung mit Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

So läuft der Autorisierungsprozess im folgenden Bild ab:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Im gezeigten Bild passiert Folgendes:

- Authentifizierung/Autorisierung erfolgt über Microsoft Entra.
- Azure API Management fungiert als Gateway und nutzt Richtlinien, um den Datenverkehr zu steuern und zu verwalten.
- Azure Monitor protokolliert alle Anfragen zur weiteren Analyse.

#### Autorisierungsablauf

Schauen wir uns den Autorisierungsablauf etwas genauer an:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP-Autorisierungsspezifikation

Erfahren Sie mehr über die [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow).

## Remote MCP Server auf Azure bereitstellen

Schauen wir, ob wir das zuvor erwähnte Beispiel bereitstellen können:

1. Klonen Sie das Repository

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registrieren Sie `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` und prüfen Sie nach einiger Zeit, ob die Registrierung abgeschlossen ist.

3. Führen Sie diesen [azd](https://aka.ms/azd)-Befehl aus, um den API-Management-Dienst, die Function App (mit Code) und alle weiteren benötigten Azure-Ressourcen bereitzustellen:

    ```shell
    azd up
    ```

    Dieser Befehl sollte alle Cloud-Ressourcen auf Azure bereitstellen.

### Testen Ihres Servers mit MCP Inspector

1. Öffnen Sie ein **neues Terminalfenster**, installieren und starten Sie MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Sie sollten eine Benutzeroberfläche ähnlich dieser sehen:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.de.png)

2. Klicken Sie mit gedrückter STRG-Taste, um die MCP Inspector Web-App über die von der App angezeigte URL zu laden (z. B. http://127.0.0.1:6274/#resources)
3. Stellen Sie den Transporttyp auf `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` und **Verbinden**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Tools auflisten**. Klicken Sie auf ein Tool und **Tool ausführen**.

Wenn alle Schritte erfolgreich waren, sind Sie nun mit dem MCP-Server verbunden und konnten ein Tool aufrufen.

## MCP-Server für Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Dieses Set an Repositories ist eine Schnellstartvorlage zum Erstellen und Bereitstellen von benutzerdefinierten Remote-MCP-Servern (Model Context Protocol) mit Azure Functions in Python, C# .NET oder Node/TypeScript.

Die Beispiele bieten eine Komplettlösung, die Entwicklern ermöglicht:

- Lokal entwickeln und ausführen: Entwicklung und Debugging eines MCP-Servers auf dem lokalen Rechner
- Bereitstellung auf Azure: Einfache Bereitstellung in der Cloud mit einem einzigen azd up-Befehl
- Verbindung von Clients: Verbindung zum MCP-Server von verschiedenen Clients, einschließlich des Copilot-Agent-Modus von VS Code und des MCP Inspector Tools

### Wichtige Funktionen:

- Sicherheit von Anfang an: Der MCP-Server ist durch Schlüssel und HTTPS abgesichert
- Authentifizierungsoptionen: Unterstützt OAuth mit integrierter Authentifizierung und/oder API Management
- Netzwerktrennung: Ermöglicht Netzwerktrennung mit Azure Virtual Networks (VNET)
- Serverlose Architektur: Nutzt Azure Functions für skalierbare, ereignisgesteuerte Ausführung
- Lokale Entwicklung: Umfassende Unterstützung für lokale Entwicklung und Debugging
- Einfache Bereitstellung: Vereinfachter Bereitstellungsprozess für Azure

Das Repository enthält alle notwendigen Konfigurationsdateien, Quellcode und Infrastrukturdefinitionen, um schnell mit einer produktionsreifen MCP-Server-Implementierung zu starten.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Beispielimplementierung von MCP mit Azure Functions und Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Beispielimplementierung von MCP mit Azure Functions und C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Beispielimplementierung von MCP mit Azure Functions und Node/TypeScript

## Wichtigste Erkenntnisse

- MCP SDKs bieten sprachspezifische Werkzeuge zur Implementierung robuster MCP-Lösungen
- Der Debugging- und Testprozess ist entscheidend für zuverlässige MCP-Anwendungen
- Wiederverwendbare Prompt-Vorlagen ermöglichen konsistente KI-Interaktionen
- Gut gestaltete Workflows können komplexe Aufgaben mit mehreren Tools orchestrieren
- Die Implementierung von MCP-Lösungen erfordert Berücksichtigung von Sicherheit, Leistung und Fehlerbehandlung

## Übung

Entwerfen Sie einen praktischen MCP-Workflow, der ein reales Problem in Ihrem Bereich löst:

1. Identifizieren Sie 3-4 Tools, die bei der Lösung dieses Problems hilfreich wären
2. Erstellen Sie ein Ablaufdiagramm, das zeigt, wie diese Tools zusammenarbeiten
3. Implementieren Sie eine einfache Version eines der Tools in Ihrer bevorzugten Sprache
4. Erstellen Sie eine Prompt-Vorlage, die dem Modell hilft, Ihr Tool effektiv zu nutzen

## Zusätzliche Ressourcen


---

Weiter: [Fortgeschrittene Themen](../05-AdvancedTopics/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.