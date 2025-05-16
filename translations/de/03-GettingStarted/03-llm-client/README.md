<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-16T14:56:20+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "de"
}
-->
Großartig, für unseren nächsten Schritt listen wir die Fähigkeiten auf dem Server auf.

### -2 Serverfähigkeiten auflisten

Jetzt verbinden wir uns mit dem Server und fragen nach seinen Fähigkeiten:

### -3 Serverfähigkeiten in LLM-Tools umwandeln

Der nächste Schritt nach dem Auflisten der Serverfähigkeiten besteht darin, sie in ein Format zu konvertieren, das das LLM versteht. Sobald wir das getan haben, können wir diese Fähigkeiten als Tools unserem LLM zur Verfügung stellen.

Großartig, jetzt sind wir bereit, Benutzeranfragen zu bearbeiten, also kümmern wir uns als Nächstes darum.

### -4 Benutzeraufforderungen bearbeiten

In diesem Teil des Codes werden wir Benutzeranfragen bearbeiten.

Großartig, du hast es geschafft!

## Aufgabe

Nimm den Code aus der Übung und erweitere den Server um weitere Tools. Erstelle dann einen Client mit einem LLM, wie in der Übung, und teste ihn mit verschiedenen Eingaben, um sicherzustellen, dass alle deine Server-Tools dynamisch aufgerufen werden. Diese Art, einen Client zu bauen, sorgt für eine großartige Benutzererfahrung, da die Endbenutzer Eingaben in natürlicher Sprache verwenden können, anstatt genaue Client-Befehle einzugeben, und dabei nicht merken, dass ein MCP-Server im Hintergrund angesprochen wird.

## Lösung

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Wichtige Erkenntnisse

- Das Hinzufügen eines LLM zu deinem Client bietet den Benutzern eine bessere Möglichkeit, mit MCP-Servern zu interagieren.
- Du musst die Antwort des MCP-Servers in ein Format umwandeln, das das LLM versteht.

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](../samples/javascript/README.md)
- [TypeScript Rechner](../samples/typescript/README.md)
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

## Was kommt als Nächstes

- Weiter: [Einen Server mit Visual Studio Code nutzen](/03-GettingStarted/04-vscode/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.