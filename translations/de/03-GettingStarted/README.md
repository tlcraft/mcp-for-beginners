<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-16T14:54:17+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "de"
}
-->
## Erste Schritte  

Dieser Abschnitt besteht aus mehreren Lektionen:

- **-1- Dein erster Server**: In dieser ersten Lektion lernst du, wie du deinen ersten Server erstellst und ihn mit dem Inspektor-Tool überprüfst – eine wertvolle Methode, um deinen Server zu testen und zu debuggen, [zur Lektion](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**: In dieser Lektion lernst du, wie du einen Client schreibst, der eine Verbindung zu deinem Server herstellen kann, [zur Lektion](/03-GettingStarted/02-client/README.md)

- **-3- Client mit LLM**: Eine noch bessere Möglichkeit, einen Client zu schreiben, ist das Hinzufügen eines LLM, damit er mit deinem Server "verhandeln" kann, was zu tun ist, [zur Lektion](/03-GettingStarted/03-llm-client/README.md)

- **-4- Nutzung eines Servers im GitHub Copilot Agent-Modus in Visual Studio Code**: Hier betrachten wir, wie wir unseren MCP Server direkt in Visual Studio Code ausführen, [zur Lektion](/03-GettingStarted/04-vscode/README.md)

- **-5- Nutzung von SSE (Server Sent Events)**: SSE ist ein Standard für serverseitiges Streaming zum Client, der es Servern ermöglicht, Echtzeit-Updates über HTTP an Clients zu senden, [zur Lektion](/03-GettingStarted/05-sse-server/README.md)

- **-6- Nutzung des AI Toolkit für VSCode**, um deine MCP Clients und Server zu konsumieren und zu testen, [zur Lektion](/03-GettingStarted/06-aitk/README.md)

- **-7- Testing**: Hier konzentrieren wir uns besonders darauf, wie wir unseren Server und Client auf verschiedene Arten testen können, [zur Lektion](/03-GettingStarted/07-testing/README.md)

- **-8- Deployment**: Dieses Kapitel behandelt verschiedene Möglichkeiten, deine MCP-Lösungen bereitzustellen, [zur Lektion](/03-GettingStarted/08-deployment/README.md)


Das Model Context Protocol (MCP) ist ein offenes Protokoll, das standardisiert, wie Anwendungen Kontext für LLMs bereitstellen. Man kann MCP wie einen USB-C-Anschluss für KI-Anwendungen sehen – es bietet eine standardisierte Möglichkeit, KI-Modelle mit verschiedenen Datenquellen und Tools zu verbinden.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Entwicklungsumgebungen für MCP in C#, Java, Python, TypeScript und JavaScript einzurichten
- Grundlegende MCP-Server mit benutzerdefinierten Funktionen (Ressourcen, Prompts und Tools) zu erstellen und bereitzustellen
- Host-Anwendungen zu erstellen, die eine Verbindung zu MCP-Servern herstellen
- MCP-Implementierungen zu testen und zu debuggen
- Häufige Einrichtungsprobleme und deren Lösungen zu verstehen
- Deine MCP-Implementierungen mit beliebten LLM-Diensten zu verbinden

## Einrichtung deiner MCP-Umgebung

Bevor du mit MCP arbeitest, ist es wichtig, deine Entwicklungsumgebung vorzubereiten und den grundlegenden Arbeitsablauf zu verstehen. Dieser Abschnitt führt dich durch die ersten Einrichtungsschritte, um einen reibungslosen Start mit MCP zu gewährleisten.

### Voraussetzungen

Bevor du mit der MCP-Entwicklung beginnst, stelle sicher, dass du Folgendes hast:

- **Entwicklungsumgebung**: Für deine gewählte Sprache (C#, Java, Python, TypeScript oder JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm oder einen modernen Code-Editor
- **Paketmanager**: NuGet, Maven/Gradle, pip oder npm/yarn
- **API-Schlüssel**: Für alle KI-Dienste, die du in deinen Host-Anwendungen verwenden möchtest


### Offizielle SDKs

In den kommenden Kapiteln wirst du Lösungen sehen, die mit Python, TypeScript, Java und .NET erstellt wurden. Hier sind alle offiziell unterstützten SDKs.

MCP stellt offizielle SDKs für mehrere Sprachen bereit:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Wird in Zusammenarbeit mit Microsoft gepflegt
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Wird in Zusammenarbeit mit Spring AI gepflegt
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Die offizielle TypeScript-Implementierung
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Die offizielle Python-Implementierung
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Die offizielle Kotlin-Implementierung
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Wird in Zusammenarbeit mit Loopwork AI gepflegt
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Die offizielle Rust-Implementierung

## Wichtige Erkenntnisse

- Die Einrichtung einer MCP-Entwicklungsumgebung ist dank sprachspezifischer SDKs unkompliziert
- Der Aufbau von MCP-Servern umfasst das Erstellen und Registrieren von Tools mit klaren Schemata
- MCP-Clients verbinden sich mit Servern und Modellen, um erweiterte Funktionen zu nutzen
- Testen und Debuggen sind entscheidend für zuverlässige MCP-Implementierungen
- Deployment-Optionen reichen von lokaler Entwicklung bis zu cloudbasierten Lösungen

## Üben

Wir haben eine Reihe von Beispielen, die die Übungen ergänzen, die du in allen Kapiteln dieses Abschnitts findest. Zusätzlich hat jedes Kapitel eigene Übungen und Aufgaben.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Was kommt als Nächstes

Weiter zu: [Erstellen deines ersten MCP Servers](/03-GettingStarted/01-first-server/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.