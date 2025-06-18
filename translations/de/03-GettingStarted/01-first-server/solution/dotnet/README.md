<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:46:59+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "de"
}
-->
# Dieses Beispiel ausführen

## -1- Installiere die Abhängigkeiten

```bash
dotnet restore
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

Damit sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, über die du das Beispiel testen kannst.

Sobald der Server verbunden ist:

- versuche, die Tools aufzulisten und `add` mit den Argumenten 2 und 4 auszuführen, im Ergebnis solltest du 6 sehen.
- gehe zu resources und resource template und rufe "greeting" auf, gib einen Namen ein und du solltest eine Begrüßung mit dem eingegebenen Namen sehen.

### Testen im CLI-Modus

Du kannst es direkt im CLI-Modus starten, indem du folgenden Befehl ausführst:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Dies listet alle im Server verfügbaren Tools auf. Du solltest folgende Ausgabe sehen:

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

Du solltest folgende Ausgabe erhalten:

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
> Es ist normalerweise deutlich schneller, den Inspector im CLI-Modus als im Browser auszuführen.
> Mehr Informationen zum Inspector findest du [hier](https://github.com/modelcontextprotocol/inspector).

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ausgangssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.