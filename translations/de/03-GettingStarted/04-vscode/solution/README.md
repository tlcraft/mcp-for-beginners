<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-16T15:15:48+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "de"
}
-->
# Ausführen des Beispiels

Hier gehen wir davon aus, dass du bereits einen funktionierenden Server-Code hast. Bitte suche einen Server aus einem der vorherigen Kapitel heraus.

## Einrichtung von mcp.json

Hier findest du eine Datei zur Orientierung, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Ändere den Server-Eintrag bei Bedarf so, dass er den absoluten Pfad zu deinem Server sowie den vollständigen Befehl zum Ausführen enthält.

Im oben genannten Beispieldatei sieht der Server-Eintrag folgendermaßen aus:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Dies entspricht dem Ausführen eines Befehls wie: `cmd /c node <absoluter Pfad>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` und gib etwas ein wie „add 3 to 20“.

    Du solltest oberhalb des Chat-Eingabefelds ein Werkzeug sehen, das dich auffordert, das Tool auszuwählen und auszuführen, wie in dieser Abbildung:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.de.png)

    Wenn du das Tool auswählst, sollte ein numerisches Ergebnis mit „23“ erscheinen, falls deine Eingabe wie oben beschrieben war.

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.