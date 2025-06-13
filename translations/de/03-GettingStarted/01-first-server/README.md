<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T05:50:23+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "de"
}
-->
### -2- Projekt erstellen

Nachdem Sie das SDK installiert haben, erstellen wir als Nächstes ein Projekt:

### -3- Projektdateien erstellen

### -4- Server-Code erstellen

### -5- Hinzufügen eines Tools und einer Ressource

Fügen Sie ein Tool und eine Ressource hinzu, indem Sie den folgenden Code einfügen:

### -6- Fertiger Code

Fügen wir den letzten Code hinzu, den der Server benötigt, um gestartet zu werden:

### -7- Server testen

Starten Sie den Server mit folgendem Befehl:

### -8- Mit dem Inspector ausführen

Der Inspector ist ein großartiges Werkzeug, mit dem Sie Ihren Server starten und mit ihm interagieren können, um zu testen, ob alles funktioniert. Starten wir ihn:

> [!NOTE]
> Im Feld „Befehl“ sieht es möglicherweise anders aus, da es den Befehl zum Ausführen eines Servers mit Ihrer spezifischen Laufzeitumgebung enthält.

Sie sollten die folgende Benutzeroberfläche sehen:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.de.png)

1. Stellen Sie eine Verbindung zum Server her, indem Sie auf die Schaltfläche „Connect“ klicken.  
   Sobald Sie mit dem Server verbunden sind, sollten Sie Folgendes sehen:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.de.png)

2. Wählen Sie „Tools“ und dann „listTools“ aus. Sie sollten „Add“ sehen, klicken Sie auf „Add“ und füllen Sie die Parameterwerte aus.

   Sie sollten die folgende Antwort erhalten, also ein Ergebnis vom „add“-Tool:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.de.png)

Glückwunsch, Sie haben Ihren ersten Server erfolgreich erstellt und gestartet!

### Offizielle SDKs

MCP bietet offizielle SDKs für mehrere Sprachen an:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Wird in Zusammenarbeit mit Microsoft gepflegt  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Wird in Zusammenarbeit mit Spring AI gepflegt  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Offizielle TypeScript-Implementierung  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Offizielle Python-Implementierung  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Offizielle Kotlin-Implementierung  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Wird in Zusammenarbeit mit Loopwork AI gepflegt  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Offizielle Rust-Implementierung

## Wichtige Erkenntnisse

- Die Einrichtung einer MCP-Entwicklungsumgebung ist dank sprachspezifischer SDKs unkompliziert  
- Das Erstellen von MCP-Servern umfasst das Erstellen und Registrieren von Tools mit klaren Schemata  
- Testen und Debuggen sind essenziell für zuverlässige MCP-Implementierungen

## Beispiele

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Aufgabe

Erstellen Sie einen einfachen MCP-Server mit einem Tool Ihrer Wahl:  
1. Implementieren Sie das Tool in Ihrer bevorzugten Sprache (.NET, Java, Python oder JavaScript).  
2. Definieren Sie Eingabeparameter und Rückgabewerte.  
3. Führen Sie das Inspector-Tool aus, um sicherzustellen, dass der Server wie erwartet funktioniert.  
4. Testen Sie die Implementierung mit verschiedenen Eingaben.

## Lösung

[Lösung](./solution/README.md)

## Zusätzliche Ressourcen

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Was kommt als Nächstes

Weiter zu: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, bitten wir zu beachten, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Originalsprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.