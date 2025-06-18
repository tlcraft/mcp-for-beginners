<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:47:04+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "de"
}
-->
# Dieses Beispiel ausführen

## -1- Abhängigkeiten installieren

```bash
dotnet restore
```

## -2- Beispiel ausführen

```bash
dotnet run
```

## -3- Beispiel testen

Öffne vor dem Ausführen der folgenden Befehle ein separates Terminal (stelle sicher, dass der Server weiterhin läuft).

Während der Server in einem Terminal läuft, öffne ein weiteres Terminal und führe den folgenden Befehl aus:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Dadurch sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, mit der du das Beispiel testen kannst.

> Achte darauf, dass **SSE** als Transporttyp ausgewählt ist und die URL `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add` lautet. Mit den Argumenten 2 und 4 solltest du als Ergebnis 6 sehen.
- Gehe zu resources und resource template, rufe "greeting" auf, gib einen Namen ein und du solltest eine Begrüßung mit dem eingegebenen Namen erhalten.

### Testen im CLI-Modus

Du kannst es direkt im CLI-Modus starten, indem du den folgenden Befehl ausführst:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Dies listet alle im Server verfügbaren Tools auf. Du solltest folgende Ausgabe sehen:

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

Um ein Tool aufzurufen, gib ein:

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
> Es ist in der Regel viel schneller, den Inspector im CLI-Modus als im Browser auszuführen.
> Mehr zum Inspector erfährst du [hier](https://github.com/modelcontextprotocol/inspector).

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir um Genauigkeit bemüht sind, bitten wir zu beachten, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ausgangssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.