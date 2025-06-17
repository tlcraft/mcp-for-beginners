<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:11:21+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "de"
}
-->
# Ausführen des Beispiels

Hier gehen wir davon aus, dass du bereits einen funktionierenden Servercode hast. Bitte suche einen Server aus einem der vorherigen Kapitel heraus.

## Einrichtung von mcp.json

Hier ist eine Datei, die du als Referenz verwendest, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Ändere den Server-Eintrag bei Bedarf, damit er den absoluten Pfad zu deinem Server sowie den vollständigen Befehl zum Ausführen angibt.

Im oben genannten Beispieldatei sieht der Server-Eintrag folgendermaßen aus:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Dies entspricht dem Ausführen eines Befehls wie: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` gib etwas ein wie „add 3 to 20“.

    Du solltest oberhalb des Chat-Eingabefelds ein Werkzeug sehen, das dir anzeigt, dass du das Werkzeug zum Ausführen auswählen kannst, so wie in dieser Darstellung:

    ![VS Code zeigt an, dass es ein Werkzeug ausführen möchte](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.de.png)

    Die Auswahl des Werkzeugs sollte ein numerisches Ergebnis mit „23“ liefern, wenn deine Eingabe wie oben beschrieben war.

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.