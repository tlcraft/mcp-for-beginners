<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:03:11+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "de"
}
-->
# Ausführen dieses Beispiels

Es wird empfohlen, `uv` zu installieren, aber es ist nicht zwingend erforderlich. Siehe [Anleitung](https://docs.astral.sh/uv/#highlights)

## -1- Abhängigkeiten installieren

```bash
npm install
```

## -3- Beispiel ausführen

```bash
npm run build
```

## -4- Beispiel testen

Während der Server in einem Terminal läuft, öffne ein weiteres Terminal und führe den folgenden Befehl aus:

```bash
npm run inspector
```

Dadurch sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, mit der du das Beispiel testen kannst.

Sobald der Server verbunden ist:

- Versuche, die Tools aufzulisten und führe `add` mit den Argumenten 2 und 4 aus, im Ergebnis solltest du 6 sehen.
- Gehe zu resources und resource template und rufe "greeting" auf, gib einen Namen ein und du solltest eine Begrüßung mit dem eingegebenen Namen sehen.

### Testen im CLI-Modus

Der Inspector, den du gestartet hast, ist tatsächlich eine Node.js-Anwendung und `mcp dev` ist eine Hülle darum.

Du kannst ihn direkt im CLI-Modus starten, indem du den folgenden Befehl ausführst:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Dies listet alle verfügbaren Tools auf dem Server auf. Du solltest die folgende Ausgabe sehen:

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Du solltest die folgende Ausgabe sehen:

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