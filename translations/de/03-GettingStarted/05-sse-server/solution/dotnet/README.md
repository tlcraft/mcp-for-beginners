<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-16T15:20:57+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "de"
}
-->
# Dieses Beispiel ausführen

## -1- Installiere die Abhängigkeiten

```bash
dotnet run
```

## -2- Führe das Beispiel aus

```bash
dotnet run
```

## -3- Teste das Beispiel

Starte ein separates Terminal, bevor du den folgenden Befehl ausführst (stelle sicher, dass der Server noch läuft).

Während der Server in einem Terminal läuft, öffne ein weiteres Terminal und führe den folgenden Befehl aus:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Dadurch sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, die es dir ermöglicht, das Beispiel zu testen.

Sobald der Server verbunden ist:

- versuche, die Tools aufzulisten und `add` mit den Argumenten 2 und 4 auszuführen, das Ergebnis sollte 6 sein.
- gehe zu resources und resource template und rufe "greeting" auf, gib einen Namen ein und du solltest eine Begrüßung mit dem eingegebenen Namen sehen.

### Testen im CLI-Modus

Du kannst es direkt im CLI-Modus starten, indem du den folgenden Befehl ausführst:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Dies listet alle auf dem Server verfügbaren Tools auf. Du solltest folgende Ausgabe sehen:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Um ein Tool aufzurufen, tippe:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Du solltest folgende Ausgabe sehen:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Es ist normalerweise viel schneller, den Inspector im CLI-Modus als im Browser auszuführen.
> Lies mehr über den Inspector [hier](https://github.com/modelcontextprotocol/inspector).

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.