<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "315ecce765d22639b60dbc41344c8533",
  "translation_date": "2025-07-09T22:55:05+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "de"
}
-->
### -2- Projekt erstellen

Nachdem du das SDK installiert hast, erstellen wir als Nächstes ein Projekt:

### -3- Projektdateien erstellen

### -4- Servercode erstellen

### -5- Hinzufügen eines Tools und einer Ressource

Füge ein Tool und eine Ressource hinzu, indem du den folgenden Code einfügst:

### -6- Finaler Code

Fügen wir den letzten benötigten Code hinzu, damit der Server starten kann:

### -7- Server testen

Starte den Server mit folgendem Befehl:

### -8- Mit dem Inspector ausführen

Der Inspector ist ein großartiges Tool, das deinen Server starten kann und dir ermöglicht, mit ihm zu interagieren, um zu testen, ob alles funktioniert. Lass uns ihn starten:
> [!NOTE]  
> Im Feld „command“ kann es anders aussehen, da dort der Befehl zum Starten eines Servers mit deiner spezifischen Laufzeitumgebung steht.
Sie sollten die folgende Benutzeroberfläche sehen:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.de.png)

1. Verbinden Sie sich mit dem Server, indem Sie die Schaltfläche Connect auswählen.
   Sobald Sie mit dem Server verbunden sind, sollten Sie Folgendes sehen:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.de.png)

1. Wählen Sie "Tools" und dann "listTools". Sie sollten "Add" sehen, wählen Sie "Add" aus und füllen Sie die Parameterwerte aus.

   Sie sollten die folgende Antwort sehen, also ein Ergebnis vom "add"-Tool:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.de.png)

Glückwunsch, Sie haben erfolgreich Ihren ersten Server erstellt und ausgeführt!

### Offizielle SDKs

MCP bietet offizielle SDKs für mehrere Sprachen an:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Wird in Zusammenarbeit mit Microsoft gepflegt
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Wird in Zusammenarbeit mit Spring AI gepflegt
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Die offizielle TypeScript-Implementierung
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Die offizielle Python-Implementierung
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Die offizielle Kotlin-Implementierung
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Wird in Zusammenarbeit mit Loopwork AI gepflegt
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Die offizielle Rust-Implementierung

## Wichtige Erkenntnisse

- Das Einrichten einer MCP-Entwicklungsumgebung ist mit sprachspezifischen SDKs unkompliziert
- Der Aufbau von MCP-Servern umfasst das Erstellen und Registrieren von Tools mit klaren Schemata
- Testen und Debuggen sind entscheidend für zuverlässige MCP-Implementierungen

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](../samples/javascript/README.md)
- [TypeScript Rechner](../samples/typescript/README.md)
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Aufgabe

Erstellen Sie einen einfachen MCP-Server mit einem Tool Ihrer Wahl:

1. Implementieren Sie das Tool in Ihrer bevorzugten Sprache (.NET, Java, Python oder JavaScript).
2. Definieren Sie Eingabeparameter und Rückgabewerte.
3. Führen Sie das Inspector-Tool aus, um sicherzustellen, dass der Server wie gewünscht funktioniert.
4. Testen Sie die Implementierung mit verschiedenen Eingaben.

## Lösung

[Lösung](./solution/README.md)

## Zusätzliche Ressourcen

- [Agents mit Model Context Protocol auf Azure erstellen](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP mit Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Was kommt als Nächstes

Weiter: [Erste Schritte mit MCP Clients](../02-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.