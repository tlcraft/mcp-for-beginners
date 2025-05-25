<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-16T15:11:11+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "de"
}
-->
# Dieses Beispiel ausführen

## -1- Installiere die Abhängigkeiten

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Führe das Beispiel aus


```bash
dotnet run
```

## -4- Teste das Beispiel

Während der Server in einem Terminal läuft, öffne ein weiteres Terminal und führe folgenden Befehl aus:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Dadurch sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, mit der du das Beispiel testen kannst.

Sobald der Server verbunden ist:

- versuche, die Werkzeuge aufzulisten und `add` mit den Argumenten 2 und 4 auszuführen, im Ergebnis solltest du 6 sehen.
- gehe zu resources und resource template und rufe "greeting" auf, gib einen Namen ein und du solltest eine Begrüßung mit dem angegebenen Namen sehen.

### Testen im CLI-Modus

Du kannst es direkt im CLI-Modus starten, indem du folgenden Befehl ausführst:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Dies listet alle auf dem Server verfügbaren Werkzeuge auf. Du solltest folgende Ausgabe sehen:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Um ein Werkzeug aufzurufen, tippe:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Du solltest folgende Ausgabe sehen:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Es ist in der Regel deutlich schneller, den Inspector im CLI-Modus als im Browser auszuführen.
> Mehr über den Inspector erfährst du [hier](https://github.com/modelcontextprotocol/inspector).

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.