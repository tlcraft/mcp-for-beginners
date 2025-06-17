<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T15:11:10+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "de"
}
-->
Lass uns im nächsten Abschnitt mehr darüber sprechen, wie wir die visuelle Oberfläche nutzen.

## Vorgehensweise

So gehen wir auf hoher Ebene vor:

- Eine Datei konfigurieren, um unseren MCP Server zu finden.
- Den Server starten/verbinden, damit er seine Fähigkeiten auflistet.
- Diese Fähigkeiten über die GitHub Copilot Chat-Oberfläche nutzen.

Super, jetzt wo wir den Ablauf verstanden haben, probieren wir in einer Übung, einen MCP Server über Visual Studio Code zu verwenden.

## Übung: Einen Server nutzen

In dieser Übung konfigurieren wir Visual Studio Code so, dass dein MCP Server gefunden wird und über die GitHub Copilot Chat-Oberfläche genutzt werden kann.

### -0- Vorbereitung: MCP Server-Erkennung aktivieren

Möglicherweise musst du die Erkennung von MCP Servern aktivieren.

1. Gehe zu `Datei -> Einstellungen -> Einstellungen` und suche nach `` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` in der settings.json Datei.

### -1- Konfigurationsdatei erstellen

Beginne damit, eine Konfigurationsdatei im Projektstamm anzulegen. Du benötigst eine Datei namens MCP.json, die du in einem Ordner namens .vscode ablegst. Sie sollte so aussehen:

```text
.vscode
|-- mcp.json
```

Als nächstes sehen wir, wie man einen Servereintrag hinzufügt.

### -2- Einen Server konfigurieren

Füge folgenden Inhalt in *mcp.json* ein:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Oben siehst du ein einfaches Beispiel, wie man einen Server startet, der in Node.js geschrieben ist. Für andere Laufzeitumgebungen gib den passenden Befehl zum Starten des Servers mit `command` and `args` an.

### -3- Server starten

Nachdem du einen Eintrag hinzugefügt hast, starten wir den Server:

1. Finde deinen Eintrag in *mcp.json* und achte darauf, dass du das „Play“-Symbol findest:

  ![Serverstart in Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.de.png)  

2. Klicke auf das „Play“-Symbol. Du solltest sehen, dass das Werkzeugsymbol im GitHub Copilot Chat die Anzahl der verfügbaren Werkzeuge erhöht. Wenn du auf dieses Werkzeugsymbol klickst, siehst du eine Liste der registrierten Werkzeuge. Du kannst jedes Werkzeug an- oder abwählen, je nachdem, ob GitHub Copilot es als Kontext verwenden soll:

  ![Werkzeuge in Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.de.png)

3. Um ein Werkzeug auszuführen, gib eine Eingabe ein, die zur Beschreibung eines deiner Werkzeuge passt, zum Beispiel: „add 22 to 1“:

  ![Werkzeug mit GitHub Copilot ausführen](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.de.png)

  Du solltest als Antwort 23 sehen.

## Aufgabe

Versuche, einen Servereintrag zu deiner *mcp.json* Datei hinzuzufügen und stelle sicher, dass du den Server starten und stoppen kannst. Prüfe außerdem, ob du über die GitHub Copilot Chat-Oberfläche mit den Werkzeugen auf deinem Server kommunizieren kannst.

## Lösung

[Lösung](./solution/README.md)

## Wichtige Erkenntnisse

Die wichtigsten Erkenntnisse aus diesem Kapitel sind:

- Visual Studio Code ist ein großartiger Client, mit dem du mehrere MCP Server und deren Werkzeuge nutzen kannst.
- Die GitHub Copilot Chat-Oberfläche ist der Weg, wie du mit den Servern interagierst.
- Du kannst den Nutzer nach Eingaben wie API-Schlüsseln fragen, die beim Konfigurieren des Servereintrags in der *mcp.json* Datei an den MCP Server übergeben werden.

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](../samples/javascript/README.md)
- [TypeScript Rechner](../samples/typescript/README.md)
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Weitere Ressourcen

- [Visual Studio Dokumentation](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Was kommt als Nächstes

- Nächstes Thema: [Erstellen eines SSE Servers](/03-GettingStarted/05-sse-server/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.