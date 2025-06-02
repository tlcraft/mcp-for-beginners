<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T16:52:31+00:00",
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

Fügen wir den letzten Code hinzu, den der Server benötigt, um starten zu können:

### -7- Server testen

Starte den Server mit folgendem Befehl:

### -8- Mit dem Inspector ausführen

Der Inspector ist ein großartiges Werkzeug, das deinen Server starten kann und dir ermöglicht, mit ihm zu interagieren, damit du testen kannst, ob alles funktioniert. Lass uns ihn starten:

> [!NOTE]
> Im Feld „command“ kann es anders aussehen, da dort der Befehl für das Ausführen eines Servers mit deinem spezifischen Runtime angegeben ist.

Du solltest die folgende Benutzeroberfläche sehen:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.de.png)

1. Verbinde dich mit dem Server, indem du auf die Schaltfläche „Connect“ klickst.  
   Sobald du verbunden bist, solltest du Folgendes sehen:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.de.png)

2. Wähle „Tools“ und dann „listTools“ aus. Du solltest die Option „Add“ sehen, klicke darauf und fülle die Parameterwerte aus.

   Du solltest die folgende Antwort erhalten, also ein Ergebnis vom „add“-Tool:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.de.png)

Glückwunsch, du hast deinen ersten Server erfolgreich erstellt und gestartet!

### Offizielle SDKs

MCP stellt offizielle SDKs für mehrere Programmiersprachen bereit:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – In Zusammenarbeit mit Microsoft gepflegt  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – In Zusammenarbeit mit Spring AI gepflegt  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Offizielle TypeScript-Implementierung  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Offizielle Python-Implementierung  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Offizielle Kotlin-Implementierung  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – In Zusammenarbeit mit Loopwork AI gepflegt  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Offizielle Rust-Implementierung

## Wichtige Erkenntnisse

- Das Einrichten einer MCP-Entwicklungsumgebung ist dank sprachspezifischer SDKs unkompliziert  
- Der Aufbau von MCP-Servern umfasst das Erstellen und Registrieren von Tools mit klar definierten Schemata  
- Testen und Debuggen sind essenziell für zuverlässige MCP-Implementierungen

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)  
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Rechner](../samples/javascript/README.md)  
- [TypeScript Rechner](../samples/typescript/README.md)  
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Aufgabe

Erstelle einen einfachen MCP-Server mit einem Tool deiner Wahl:  
1. Implementiere das Tool in deiner bevorzugten Sprache (.NET, Java, Python oder JavaScript).  
2. Definiere Eingabeparameter und Rückgabewerte.  
3. Starte das Inspector-Tool, um sicherzustellen, dass der Server wie gewünscht funktioniert.  
4. Teste die Implementierung mit verschiedenen Eingaben.

## Lösung

[Lösung](./solution/README.md)

## Zusätzliche Ressourcen

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Was kommt als Nächstes

Weiter: [Erste Schritte mit MCP Clients](/03-GettingStarted/02-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.