<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5331ffd328a54b90f76706c52b673e27",
  "translation_date": "2025-05-16T15:07:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "de"
}
-->
### -2- Projekt erstellen

Jetzt, wo du dein SDK installiert hast, lass uns als Nächstes ein Projekt erstellen:

### -3- Projektdateien erstellen

### -4- Server-Code erstellen

### -5- Hinzufügen eines Tools und einer Ressource

Füge ein Tool und eine Ressource hinzu, indem du den folgenden Code einfügst:

### -6- Finaler Code

Fügen wir den letzten Code hinzu, den der Server benötigt, um starten zu können:

### -7- Server testen

Starte den Server mit folgendem Befehl:

### -8- Mit dem Inspector ausführen

Der Inspector ist ein großartiges Tool, das deinen Server starten kann und dir ermöglicht, mit ihm zu interagieren, damit du testen kannst, ob alles funktioniert. Lass uns ihn starten:

> [!NOTE]
> Im Feld „Befehl“ sieht es möglicherweise anders aus, da dort der Befehl zum Starten eines Servers mit deiner spezifischen Laufzeitumgebung steht.

Du solltest folgende Benutzeroberfläche sehen:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.de.png)

1. Verbinde dich mit dem Server, indem du auf die Schaltfläche „Connect“ klickst.  
   Sobald du verbunden bist, solltest du Folgendes sehen:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.de.png)

2. Wähle „Tools“ und „listTools“ aus, du solltest „Add“ sehen. Wähle „Add“ aus und fülle die Parameterwerte aus.

   Du solltest folgende Antwort sehen, also ein Ergebnis vom Tool „add“:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.de.png)

Glückwunsch, du hast erfolgreich deinen ersten Server erstellt und gestartet!

### Offizielle SDKs

MCP stellt offizielle SDKs für mehrere Programmiersprachen bereit:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Wird in Zusammenarbeit mit Microsoft gepflegt  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Wird in Zusammenarbeit mit Spring AI gepflegt  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Die offizielle TypeScript-Implementierung  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Die offizielle Python-Implementierung  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Die offizielle Kotlin-Implementierung  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Wird in Zusammenarbeit mit Loopwork AI gepflegt  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Die offizielle Rust-Implementierung

## Wichtige Erkenntnisse

- Das Einrichten einer MCP-Entwicklungsumgebung ist dank sprachspezifischer SDKs unkompliziert  
- Das Erstellen von MCP-Servern beinhaltet das Anlegen und Registrieren von Tools mit klar definierten Schemata  
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

Weiter zu: [Erste Schritte mit MCP Clients](/03-GettingStarted/02-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in der Originalsprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.