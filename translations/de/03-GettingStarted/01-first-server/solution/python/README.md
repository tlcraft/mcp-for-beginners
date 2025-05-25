<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-16T15:12:03+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "de"
}
-->
# Dieses Beispiel ausführen

Es wird empfohlen, `uv` zu installieren, ist aber nicht zwingend erforderlich. Siehe [Anleitung](https://docs.astral.sh/uv/#highlights)

## -0- Eine virtuelle Umgebung erstellen

```bash
python -m venv venv
```

## -1- Die virtuelle Umgebung aktivieren

```bash
venv\Scrips\activate
```

## -2- Die Abhängigkeiten installieren

```bash
pip install "mcp[cli]"
```

## -3- Das Beispiel ausführen

```bash
mcp run server.py
```

## -4- Das Beispiel testen

Mit dem laufenden Server in einem Terminal öffne ein weiteres Terminal und führe folgenden Befehl aus:

```bash
mcp dev server.py
```

Dadurch sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, mit der du das Beispiel testen kannst.

Sobald der Server verbunden ist:

- versuche, Tools aufzulisten, und führe `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` aus, das ein Wrapper dafür ist.

Du kannst es auch direkt im CLI-Modus starten, indem du folgenden Befehl ausführst:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Dies listet alle auf dem Server verfügbaren Tools auf. Du solltest folgende Ausgabe sehen:

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
> Im CLI-Modus läuft der Inspector meist deutlich schneller als im Browser.
> Mehr zum Inspector findest du [hier](https://github.com/modelcontextprotocol/inspector).

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.