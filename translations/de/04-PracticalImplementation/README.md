<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "20064351f7e0fa904e96b057ed742df3",
  "translation_date": "2025-07-22T08:31:01+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "de"
}
-->
# Praktische Umsetzung

Die praktische Umsetzung ist der Bereich, in dem die Stärke des Model Context Protocol (MCP) greifbar wird. Während das Verständnis der Theorie und Architektur hinter MCP wichtig ist, zeigt sich der wahre Wert, wenn Sie diese Konzepte anwenden, um Lösungen zu entwickeln, zu testen und bereitzustellen, die reale Probleme lösen. Dieses Kapitel schlägt die Brücke zwischen theoretischem Wissen und praktischer Entwicklung und führt Sie durch den Prozess, MCP-basierte Anwendungen zum Leben zu erwecken.

Egal, ob Sie intelligente Assistenten entwickeln, KI in Geschäftsabläufe integrieren oder benutzerdefinierte Tools für die Datenverarbeitung erstellen – MCP bietet eine flexible Grundlage. Sein sprachunabhängiges Design und die offiziellen SDKs für beliebte Programmiersprachen machen es für eine breite Palette von Entwicklern zugänglich. Durch die Nutzung dieser SDKs können Sie schnell Prototypen erstellen, iterieren und Ihre Lösungen über verschiedene Plattformen und Umgebungen skalieren.

In den folgenden Abschnitten finden Sie praktische Beispiele, Beispielcode und Strategien zur Bereitstellung, die zeigen, wie MCP in C#, Java, TypeScript, JavaScript und Python implementiert werden kann. Sie lernen außerdem, wie Sie MCP-Server debuggen und testen, APIs verwalten und Lösungen in der Cloud mit Azure bereitstellen. Diese praxisnahen Ressourcen sollen Ihr Lernen beschleunigen und Ihnen helfen, robuste, produktionsreife MCP-Anwendungen sicher zu entwickeln.

## Überblick

Diese Lektion konzentriert sich auf die praktischen Aspekte der MCP-Implementierung in mehreren Programmiersprachen. Wir werden untersuchen, wie MCP-SDKs in C#, Java, TypeScript, JavaScript und Python verwendet werden können, um robuste Anwendungen zu erstellen, MCP-Server zu debuggen und zu testen sowie wiederverwendbare Ressourcen, Prompts und Tools zu erstellen.

## Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- MCP-Lösungen mit offiziellen SDKs in verschiedenen Programmiersprachen zu implementieren
- MCP-Server systematisch zu debuggen und zu testen
- Serverfunktionen (Ressourcen, Prompts und Tools) zu erstellen und zu nutzen
- Effektive MCP-Workflows für komplexe Aufgaben zu entwerfen
- MCP-Implementierungen hinsichtlich Leistung und Zuverlässigkeit zu optimieren

## Offizielle SDK-Ressourcen

Das Model Context Protocol bietet offizielle SDKs für mehrere Sprachen:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Arbeiten mit MCP-SDKs

Dieser Abschnitt bietet praktische Beispiele für die Implementierung von MCP in mehreren Programmiersprachen. Sie finden Beispielcode im `samples`-Verzeichnis, der nach Sprache organisiert ist.

### Verfügbare Beispiele

Das Repository enthält [Beispielimplementierungen](../../../04-PracticalImplementation/samples) in den folgenden Sprachen:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Jedes Beispiel zeigt wichtige MCP-Konzepte und Implementierungsmuster für die jeweilige Sprache und das Ökosystem.

## Kernfunktionen des Servers

MCP-Server können jede Kombination der folgenden Funktionen implementieren:

### Ressourcen

Ressourcen bieten Kontext und Daten, die vom Benutzer oder KI-Modell verwendet werden können:

- Dokumenten-Repositories
- Wissensdatenbanken
- Strukturierte Datenquellen
- Dateisysteme

### Prompts

Prompts sind vorgefertigte Nachrichten und Workflows für Benutzer:

- Vordefinierte Gesprächsvorlagen
- Geführte Interaktionsmuster
- Spezialisierte Dialogstrukturen

### Tools

Tools sind Funktionen, die das KI-Modell ausführen kann:

- Datenverarbeitungswerkzeuge
- Integration externer APIs
- Rechnerische Fähigkeiten
- Suchfunktionen

## Beispielimplementierungen: C#-Implementierung

Das offizielle C#-SDK-Repository enthält mehrere Beispielimplementierungen, die verschiedene Aspekte von MCP demonstrieren:

- **Einfacher MCP-Client**: Einfaches Beispiel, das zeigt, wie ein MCP-Client erstellt und Tools aufgerufen werden
- **Einfacher MCP-Server**: Minimaler Server mit grundlegender Tool-Registrierung
- **Erweiterter MCP-Server**: Voll ausgestatteter Server mit Tool-Registrierung, Authentifizierung und Fehlerbehandlung
- **ASP.NET-Integration**: Beispiele zur Integration mit ASP.NET Core
- **Tool-Implementierungsmuster**: Verschiedene Muster zur Implementierung von Tools mit unterschiedlicher Komplexität

Das MCP-C#-SDK befindet sich in der Vorschau und die APIs können sich ändern. Wir werden diesen Blog kontinuierlich aktualisieren, während sich das SDK weiterentwickelt.

### Wichtige Funktionen

- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)
- Erstellen Ihres [ersten MCP-Servers](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Für vollständige C#-Implementierungsbeispiele besuchen Sie das [offizielle C#-SDK-Samples-Repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Beispielimplementierung: Java-Implementierung

Das Java-SDK bietet robuste MCP-Implementierungsoptionen mit Funktionen auf Unternehmensniveau.

### Wichtige Funktionen

- Integration mit dem Spring Framework
- Starke Typensicherheit
- Unterstützung für reaktive Programmierung
- Umfassende Fehlerbehandlung

Für ein vollständiges Java-Implementierungsbeispiel siehe [Java-Beispiel](samples/java/containerapp/README.md) im Samples-Verzeichnis.

## Beispielimplementierung: JavaScript-Implementierung

Das JavaScript-SDK bietet einen leichtgewichtigen und flexiblen Ansatz für die MCP-Implementierung.

### Wichtige Funktionen

- Unterstützung für Node.js und Browser
- Promise-basierte API
- Einfache Integration mit Express und anderen Frameworks
- Unterstützung für WebSocket-Streaming

Für ein vollständiges JavaScript-Implementierungsbeispiel siehe [JavaScript-Beispiel](samples/javascript/README.md) im Samples-Verzeichnis.

## Beispielimplementierung: Python-Implementierung

Das Python-SDK bietet einen Python-typischen Ansatz für die MCP-Implementierung mit hervorragender Integration in ML-Frameworks.

### Wichtige Funktionen

- Unterstützung für Async/Await mit asyncio
- Integration mit FastAPI
- Einfache Tool-Registrierung
- Native Integration mit beliebten ML-Bibliotheken

Für ein vollständiges Python-Implementierungsbeispiel siehe [Python-Beispiel](samples/python/README.md) im Samples-Verzeichnis.

## API-Management

Azure API Management ist eine hervorragende Lösung, um MCP-Server zu sichern. Die Idee ist, eine Azure API Management-Instanz vor Ihren MCP-Server zu setzen und sie Funktionen übernehmen zu lassen, die Sie wahrscheinlich benötigen, wie:

- Ratenbegrenzung
- Token-Management
- Überwachung
- Lastverteilung
- Sicherheit

### Azure-Beispiel

Hier ist ein Azure-Beispiel, das genau das tut, nämlich [einen MCP-Server erstellen und ihn mit Azure API Management sichern](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Sehen Sie sich den Autorisierungsablauf im folgenden Bild an:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Im vorherigen Bild geschieht Folgendes:

- Authentifizierung/Autorisierung erfolgt über Microsoft Entra.
- Azure API Management fungiert als Gateway und verwendet Richtlinien, um den Datenverkehr zu steuern und zu verwalten.
- Azure Monitor protokolliert alle Anfragen für weitere Analysen.

#### Autorisierungsablauf

Schauen wir uns den Autorisierungsablauf genauer an:

![Sequenzdiagramm](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP-Autorisierungsspezifikation

Erfahren Sie mehr über die [MCP-Autorisierungsspezifikation](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Remote-MCP-Server auf Azure bereitstellen

Sehen wir uns an, ob wir das zuvor erwähnte Beispiel bereitstellen können:

1. Repository klonen

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. `Microsoft.App`-Ressourcenanbieter registrieren.

   - Wenn Sie die Azure CLI verwenden, führen Sie `az provider register --namespace Microsoft.App --wait` aus.
   - Wenn Sie Azure PowerShell verwenden, führen Sie `Register-AzResourceProvider -ProviderNamespace Microsoft.App` aus. Führen Sie dann `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` nach einiger Zeit aus, um zu überprüfen, ob die Registrierung abgeschlossen ist.

1. Führen Sie diesen [azd](https://aka.ms/azd)-Befehl aus, um den API-Management-Dienst, die Function App (mit Code) und alle anderen erforderlichen Azure-Ressourcen bereitzustellen:

    ```shell
    azd up
    ```

    Dieser Befehl sollte alle Cloud-Ressourcen auf Azure bereitstellen.

### Testen Ihres Servers mit MCP Inspector

1. In einem **neuen Terminalfenster** MCP Inspector installieren und ausführen

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Sie sollten eine Oberfläche ähnlich der folgenden sehen:

    ![Mit Node Inspector verbinden](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.de.png)

1. Mit STRG klicken, um die MCP Inspector-Web-App von der URL zu laden, die von der App angezeigt wird (z. B. [http://127.0.0.1:6274/#resources](http://127.0.0.1:6274/#resources)).
1. Den Transporttyp auf `SSE` setzen.
1. Die URL zu Ihrem laufenden API Management SSE-Endpunkt eingeben, der nach `azd up` angezeigt wird, und **Verbinden**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

1. **Tools auflisten**. Auf ein Tool klicken und **Tool ausführen**.

Wenn alle Schritte funktioniert haben, sollten Sie jetzt mit dem MCP-Server verbunden sein und ein Tool aufrufen können.

## MCP-Server für Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Diese Repository-Sammlung bietet eine Schnellstartvorlage zum Erstellen und Bereitstellen benutzerdefinierter Remote-MCP-Server (Model Context Protocol) mit Azure Functions in Python, C# .NET oder Node/TypeScript.

Die Samples bieten eine vollständige Lösung, die Entwicklern Folgendes ermöglicht:

- Lokal entwickeln und ausführen: Entwicklung und Debugging eines MCP-Servers auf einem lokalen Rechner
- Bereitstellung auf Azure: Einfaches Bereitstellen in der Cloud mit einem einfachen `azd up`-Befehl
- Verbindung von Clients: Verbindung zum MCP-Server von verschiedenen Clients, einschließlich des Copilot-Agent-Modus von VS Code und des MCP Inspector-Tools

### Wichtige Funktionen

- Sicherheit von Anfang an: Der MCP-Server ist mit Schlüsseln und HTTPS gesichert
- Authentifizierungsoptionen: Unterstützt OAuth mit integrierter Authentifizierung und/oder API Management
- Netzwerkisolierung: Ermöglicht Netzwerkisolierung mit Azure Virtual Networks (VNET)
- Serverlose Architektur: Nutzt Azure Functions für skalierbare, ereignisgesteuerte Ausführung
- Lokale Entwicklung: Umfassende Unterstützung für lokale Entwicklung und Debugging
- Einfache Bereitstellung: Vereinfachter Bereitstellungsprozess auf Azure

Das Repository enthält alle notwendigen Konfigurationsdateien, Quellcode und Infrastrukturdefinitionen, um schnell mit einer produktionsreifen MCP-Server-Implementierung zu beginnen.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Beispielimplementierung von MCP mit Azure Functions in Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Beispielimplementierung von MCP mit Azure Functions in C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Beispielimplementierung von MCP mit Azure Functions in Node/TypeScript.

## Wichtige Erkenntnisse

- MCP-SDKs bieten sprachspezifische Tools zur Implementierung robuster MCP-Lösungen
- Der Debugging- und Testprozess ist entscheidend für zuverlässige MCP-Anwendungen
- Wiederverwendbare Prompt-Vorlagen ermöglichen konsistente KI-Interaktionen
- Gut gestaltete Workflows können komplexe Aufgaben mit mehreren Tools orchestrieren
- Die Implementierung von MCP-Lösungen erfordert Überlegungen zu Sicherheit, Leistung und Fehlerbehandlung

## Übung

Entwerfen Sie einen praktischen MCP-Workflow, der ein reales Problem in Ihrem Bereich löst:

1. Identifizieren Sie 3-4 Tools, die nützlich wären, um dieses Problem zu lösen.
2. Erstellen Sie ein Workflow-Diagramm, das zeigt, wie diese Tools interagieren.
3. Implementieren Sie eine einfache Version eines der Tools in Ihrer bevorzugten Sprache.
4. Erstellen Sie eine Prompt-Vorlage, die dem Modell hilft, Ihr Tool effektiv zu nutzen.

## Zusätzliche Ressourcen

---

Weiter: [Fortgeschrittene Themen](../05-AdvancedTopics/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, weisen wir darauf hin, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache sollte als maßgebliche Quelle betrachtet werden. Für kritische Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die sich aus der Nutzung dieser Übersetzung ergeben.