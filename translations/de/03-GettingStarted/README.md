<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:16:29+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "de"
}
-->
## Erste Schritte  

Dieser Abschnitt besteht aus mehreren Lektionen:

- **-1- Dein erster Server**, in dieser ersten Lektion lernst du, wie du deinen ersten Server erstellst und ihn mit dem Inspektor-Tool überprüfst – eine wertvolle Methode, um deinen Server zu testen und zu debuggen, [zur Lektion](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, in dieser Lektion erfährst du, wie du einen Client schreibst, der sich mit deinem Server verbinden kann, [zur Lektion](/03-GettingStarted/02-client/README.md)

- **-3- Client mit LLM**, eine noch bessere Möglichkeit, einen Client zu schreiben, besteht darin, ein LLM hinzuzufügen, damit es mit deinem Server „verhandeln“ kann, was zu tun ist, [zur Lektion](/03-GettingStarted/03-llm-client/README.md)

- **-4- Nutzung des Server GitHub Copilot Agent Modus in Visual Studio Code**. Hier betrachten wir, wie wir unseren MCP Server direkt aus Visual Studio Code heraus ausführen, [zur Lektion](/03-GettingStarted/04-vscode/README.md)

- **-5- Nutzung von SSE (Server Sent Events)** SSE ist ein Standard für Server-zu-Client-Streaming, der es Servern ermöglicht, Echtzeit-Updates über HTTP an Clients zu senden, [zur Lektion](/03-GettingStarted/05-sse-server/README.md)

- **-6- Nutzung des AI Toolkits für VSCode** zum Konsumieren und Testen deiner MCP Clients und Server, [zur Lektion](/03-GettingStarted/06-aitk/README.md)

- **-7 Testen**. Hier liegt der Fokus darauf, wie wir unseren Server und Client auf verschiedene Weise testen können, [zur Lektion](/03-GettingStarted/07-testing/README.md)

- **-8- Deployment**. Dieses Kapitel behandelt verschiedene Möglichkeiten, deine MCP-Lösungen bereitzustellen, [zur Lektion](/03-GettingStarted/08-deployment/README.md)


Das Model Context Protocol (MCP) ist ein offenes Protokoll, das standardisiert, wie Anwendungen Kontext für LLMs bereitstellen. Man kann MCP sich vorstellen wie einen USB-C-Anschluss für KI-Anwendungen – es bietet eine standardisierte Möglichkeit, KI-Modelle mit verschiedenen Datenquellen und Tools zu verbinden.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Entwicklungsumgebungen für MCP in C#, Java, Python, TypeScript und JavaScript einzurichten
- Einfache MCP-Server mit benutzerdefinierten Funktionen (Ressourcen, Prompts und Tools) zu erstellen und bereitzustellen
- Host-Anwendungen zu erstellen, die sich mit MCP-Servern verbinden
- MCP-Implementierungen zu testen und zu debuggen
- Häufige Herausforderungen bei der Einrichtung zu verstehen und Lösungen dafür zu kennen
- Deine MCP-Implementierungen mit gängigen LLM-Diensten zu verbinden

## Einrichtung deiner MCP-Umgebung

Bevor du mit MCP arbeitest, ist es wichtig, deine Entwicklungsumgebung vorzubereiten und den grundlegenden Workflow zu verstehen. Dieser Abschnitt führt dich durch die ersten Einrichtungsschritte, um einen reibungslosen Start mit MCP zu gewährleisten.

### Voraussetzungen

Bevor du mit der MCP-Entwicklung beginnst, stelle sicher, dass du Folgendes hast:

- **Entwicklungsumgebung**: Für deine gewählte Sprache (C#, Java, Python, TypeScript oder JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm oder einen anderen modernen Code-Editor
- **Paketmanager**: NuGet, Maven/Gradle, pip oder npm/yarn
- **API-Schlüssel**: Für alle KI-Dienste, die du in deinen Host-Anwendungen nutzen möchtest

### Offizielle SDKs

In den kommenden Kapiteln wirst du Lösungen sehen, die mit Python, TypeScript, Java und .NET erstellt wurden. Hier findest du alle offiziell unterstützten SDKs.

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
- Der Aufbau von MCP-Servern umfasst das Erstellen und Registrieren von Tools mit klar definierten Schemata
- MCP-Clients verbinden sich mit Servern und Modellen, um erweiterte Funktionen zu nutzen
- Testen und Debuggen sind entscheidend für zuverlässige MCP-Implementierungen
- Bereitstellungsoptionen reichen von lokaler Entwicklung bis hin zu cloudbasierten Lösungen

## Üben

Wir bieten eine Reihe von Beispielen, die die Übungen in allen Kapiteln dieses Abschnitts ergänzen. Zusätzlich hat jedes Kapitel eigene Übungen und Aufgaben.

- [Java Rechner](./samples/java/calculator/README.md)
- [.Net Rechner](../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](./samples/javascript/README.md)
- [TypeScript Rechner](./samples/typescript/README.md)
- [Python Rechner](../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Was kommt als Nächstes

Weiter zu: [Erstellen deines ersten MCP Servers](/03-GettingStarted/01-first-server/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ausgangssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.