<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:44:21+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "de"
}
-->
Super, für den nächsten Schritt listen wir die Fähigkeiten auf dem Server auf.

### -2 Fähigkeiten des Servers auflisten

Jetzt verbinden wir uns mit dem Server und fragen nach seinen Fähigkeiten:

### -3- Serverfähigkeiten in LLM-Tools umwandeln

Der nächste Schritt nach dem Auflisten der Serverfähigkeiten ist, diese in ein Format zu konvertieren, das das LLM versteht. Sobald wir das getan haben, können wir diese Fähigkeiten als Tools unserem LLM zur Verfügung stellen.

Super, wir sind jetzt bereit, Benutzeranfragen zu bearbeiten, also kümmern wir uns als Nächstes darum.

### -4- Benutzeranfrage verarbeiten

In diesem Teil des Codes werden wir Benutzeranfragen bearbeiten.

Super, du hast es geschafft!

## Aufgabe

Nimm den Code aus der Übung und erweitere den Server um weitere Tools. Erstelle dann einen Client mit einem LLM, wie in der Übung, und teste ihn mit verschiedenen Eingaben, um sicherzustellen, dass alle deine Server-Tools dynamisch aufgerufen werden. Diese Art, einen Client zu bauen, sorgt für eine großartige Benutzererfahrung, da die Nutzer Eingaben in natürlicher Sprache verwenden können, anstatt exakte Client-Befehle zu kennen, und dabei gar nicht merken, dass ein MCP-Server angesprochen wird.

## Lösung

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Wichtige Erkenntnisse

- Ein LLM in den Client einzubinden, bietet eine bessere Möglichkeit für Nutzer, mit MCP-Servern zu interagieren.
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
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.