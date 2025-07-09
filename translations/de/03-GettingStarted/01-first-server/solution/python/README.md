<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T22:55:17+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "de"
}
-->
# Ausführen dieses Beispiels

Es wird empfohlen, `uv` zu installieren, ist aber nicht zwingend erforderlich. Siehe [Anleitung](https://docs.astral.sh/uv/#highlights)

## -0- Erstelle eine virtuelle Umgebung

```bash
python -m venv venv
```

## -1- Aktiviere die virtuelle Umgebung

```bash
venv\Scrips\activate
```

## -2- Installiere die Abhängigkeiten

```bash
pip install "mcp[cli]"
```

## -3- Führe das Beispiel aus

```bash
mcp run server.py
```

## -4- Teste das Beispiel

Während der Server in einem Terminal läuft, öffne ein weiteres Terminal und führe folgenden Befehl aus:

```bash
mcp dev server.py
```

Dadurch sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, mit der du das Beispiel testen kannst.

Sobald der Server verbunden ist:

- Versuche, die Tools aufzulisten und führe `add` mit den Argumenten 2 und 4 aus, im Ergebnis solltest du 6 sehen.

- Gehe zu resources und resource template und rufe get_greeting auf, gib einen Namen ein und du solltest eine Begrüßung mit dem eingegebenen Namen sehen.

### Testen im CLI-Modus

Der Inspector, den du gestartet hast, ist eigentlich eine Node.js-Anwendung und `mcp dev` ist ein Wrapper darum herum.

Du kannst ihn direkt im CLI-Modus starten, indem du folgenden Befehl ausführst:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Dies listet alle im Server verfügbaren Tools auf. Du solltest folgende Ausgabe sehen:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Um ein Tool aufzurufen, tippe:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Mehr zum Inspector findest du [hier](https://github.com/modelcontextprotocol/inspector).

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.