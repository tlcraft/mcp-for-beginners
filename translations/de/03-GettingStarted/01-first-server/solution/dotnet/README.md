<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-09T21:56:42+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "de"
}
-->
# Ausführen dieses Beispiels

## -1- Installiere die Abhängigkeiten

```bash
dotnet restore
```

## -3- Führe das Beispiel aus

```bash
dotnet run
```

## -4- Teste das Beispiel

Während der Server in einem Terminal läuft, öffne ein weiteres Terminal und führe den folgenden Befehl aus:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Dadurch sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, die es dir ermöglicht, das Beispiel zu testen.

Sobald der Server verbunden ist:

- Versuche, die Tools aufzulisten und `add` mit den Argumenten 2 und 4 auszuführen, im Ergebnis solltest du 6 sehen.
- Gehe zu resources und resource template und rufe "greeting" auf, gib einen Namen ein und du solltest eine Begrüßung mit dem eingegebenen Namen sehen.

### Testen im CLI-Modus

Du kannst es direkt im CLI-Modus starten, indem du den folgenden Befehl ausführst:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Dies listet alle verfügbaren Tools auf dem Server auf. Du solltest die folgende Ausgabe sehen:

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

Um ein Tool aufzurufen, tippe:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Du solltest die folgende Ausgabe sehen:

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
> Es ist in der Regel viel schneller, den Inspector im CLI-Modus als im Browser auszuführen.
> Mehr zum Inspector erfährst du [hier](https://github.com/modelcontextprotocol/inspector).

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.