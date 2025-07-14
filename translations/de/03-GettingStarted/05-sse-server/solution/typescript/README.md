<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:18:13+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "de"
}
-->
# Ausführen dieses Beispiels

## -1- Installiere die Abhängigkeiten

```bash
npm install
```

## -3- Führe das Beispiel aus


```bash
npm run build
```

## -4- Teste das Beispiel

Während der Server in einem Terminal läuft, öffne ein weiteres Terminal und führe den folgenden Befehl aus:

```bash
npm run inspector
```

Dadurch sollte ein Webserver mit einer visuellen Oberfläche gestartet werden, die es dir ermöglicht, das Beispiel zu testen.

Sobald der Server verbunden ist:

- Versuche, Tools aufzulisten und führe `add` mit den Argumenten 2 und 4 aus, im Ergebnis solltest du 6 sehen.
- Gehe zu resources und resource template und rufe "greeting" auf, gib einen Namen ein und du solltest eine Begrüßung mit dem eingegebenen Namen sehen.

### Testen im CLI-Modus

Der Inspector, den du gestartet hast, ist tatsächlich eine Node.js-Anwendung und `mcp dev` ist eine Hülle darum.

- Starte den Server mit dem Befehl `npm run build`.

- Führe in einem separaten Terminal den folgenden Befehl aus:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Dies listet alle im Server verfügbaren Tools auf. Du solltest die folgende Ausgabe sehen:

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

- Rufe einen Tool-Typ auf, indem du den folgenden Befehl eingibst:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Du solltest die folgende Ausgabe sehen:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Es ist in der Regel viel schneller, den Inspector im CLI-Modus als im Browser auszuführen.
> Mehr zum Inspector findest du [hier](https://github.com/modelcontextprotocol/inspector).

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.