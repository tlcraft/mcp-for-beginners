<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T17:55:09+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "de"
}
-->
Großartig, für unseren nächsten Schritt listen wir die Fähigkeiten auf dem Server auf.

### -2 Server-Fähigkeiten auflisten

Jetzt verbinden wir uns mit dem Server und fragen nach seinen Fähigkeiten:

### -3- Server-Fähigkeiten in LLM-Werkzeuge umwandeln

Der nächste Schritt nach dem Auflisten der Server-Fähigkeiten ist, diese in ein Format zu konvertieren, das das LLM versteht. Sobald wir das gemacht haben, können wir diese Fähigkeiten als Werkzeuge unserem LLM bereitstellen.

Großartig, wir sind jetzt bereit, Benutzeranfragen zu bearbeiten, also kümmern wir uns als Nächstes darum.

### -4- Benutzeranfrage bearbeiten

In diesem Teil des Codes werden wir Benutzeranfragen verarbeiten.

Super, du hast es geschafft!

## Aufgabe

Nimm den Code aus der Übung und erweitere den Server um weitere Werkzeuge. Erstelle dann einen Client mit einem LLM, wie in der Übung, und teste ihn mit verschiedenen Eingabeaufforderungen, um sicherzustellen, dass alle Server-Werkzeuge dynamisch aufgerufen werden. Diese Art, einen Client zu bauen, sorgt für eine großartige Benutzererfahrung, da der Endanwender Eingabeaufforderungen verwenden kann, anstatt genaue Client-Befehle einzugeben, und dabei nichts von einem MCP-Server mitbekommt, der aufgerufen wird.

## Lösung

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Wichtige Erkenntnisse

- Das Hinzufügen eines LLM zu deinem Client bietet eine bessere Möglichkeit für Benutzer, mit MCP-Servern zu interagieren.
- Du musst die Antwort des MCP-Servers in etwas umwandeln, das das LLM verstehen kann.

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](../../../../03-GettingStarted/samples/javascript)
- [TypeScript Rechner](../../../../03-GettingStarted/samples/typescript)
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

## Was kommt als Nächstes

- Weiter: [Einen Server mit Visual Studio Code nutzen](/03-GettingStarted/04-vscode/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Originalsprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.