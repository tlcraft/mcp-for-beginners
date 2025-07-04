<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-04T15:30:44+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "de"
}
-->
Jetzt, da wir ein bisschen mehr über SSE wissen, bauen wir als Nächstes einen SSE-Server.

## Übung: Erstellen eines SSE-Servers

Um unseren Server zu erstellen, müssen wir zwei Dinge beachten:

- Wir müssen einen Webserver verwenden, um Endpunkte für Verbindungen und Nachrichten bereitzustellen.
- Baue unseren Server wie gewohnt mit Tools, Ressourcen und Prompts auf, so wie wir es bei der Verwendung von stdio gemacht haben.

### -1- Erstellen einer Server-Instanz

Um unseren Server zu erstellen, verwenden wir dieselben Typen wie bei stdio. Für den Transport müssen wir jedoch SSE auswählen.

Fügen wir als Nächstes die benötigten Routen hinzu.

### -2- Routen hinzufügen

Fügen wir nun Routen hinzu, die die Verbindung und eingehende Nachrichten verwalten:

Als Nächstes erweitern wir den Server um weitere Funktionen.

### -3- Hinzufügen von Server-Funktionalitäten

Jetzt, wo wir alles SSE-spezifische definiert haben, fügen wir dem Server Funktionen wie Tools, Prompts und Ressourcen hinzu.

Dein kompletter Code sollte folgendermaßen aussehen:

Super, wir haben einen Server mit SSE, testen wir ihn als Nächstes.

## Übung: Debuggen eines SSE-Servers mit dem Inspector

Der Inspector ist ein großartiges Tool, das wir in einer vorherigen Lektion [Creating your first server](/03-GettingStarted/01-first-server/README.md) kennengelernt haben. Schauen wir, ob wir den Inspector auch hier verwenden können:

### -1- Den Inspector starten

Um den Inspector zu starten, muss zuerst ein SSE-Server laufen, also machen wir das als Nächstes:

1. Starte den Server

1. Starte den Inspector

    > ![NOTE]
    > Führe diesen Befehl in einem separaten Terminalfenster aus, in dem der Server nicht läuft. Beachte außerdem, dass du den untenstehenden Befehl an die URL anpassen musst, unter der dein Server läuft.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Das Starten des Inspectors sieht in allen Laufzeitumgebungen gleich aus. Beachte, dass wir statt eines Pfads zu unserem Server und eines Befehls zum Starten des Servers die URL übergeben, unter der der Server läuft, und außerdem die Route `/sse` angeben.

### -2- Das Tool ausprobieren

Verbinde den Server, indem du in der Dropdown-Liste SSE auswählst und das URL-Feld mit der Adresse füllst, unter der dein Server läuft, zum Beispiel http://localhost:4321/sse. Klicke dann auf die Schaltfläche „Connect“. Wie zuvor kannst du Tools auflisten, ein Tool auswählen und Eingabewerte angeben. Du solltest ein Ergebnis wie unten sehen:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.de.png)

Super, du kannst mit dem Inspector arbeiten, schauen wir uns als Nächstes an, wie man mit Visual Studio Code arbeitet.

## Aufgabe

Versuche, deinen Server mit weiteren Funktionen auszubauen. Sieh dir [diese Seite](https://api.chucknorris.io/) an, um zum Beispiel ein Tool hinzuzufügen, das eine API aufruft. Du entscheidest, wie der Server aussehen soll. Viel Spaß :)

## Lösung

[Lösung](./solution/README.md) Hier findest du eine mögliche Lösung mit funktionierendem Code.

## Wichtige Erkenntnisse

Die wichtigsten Erkenntnisse aus diesem Kapitel sind:

- SSE ist der zweite unterstützte Transport neben stdio.
- Um SSE zu unterstützen, musst du eingehende Verbindungen und Nachrichten mit einem Web-Framework verwalten.
- Du kannst sowohl den Inspector als auch Visual Studio Code verwenden, um einen SSE-Server zu nutzen, genau wie bei stdio-Servern. Beachte, dass es zwischen stdio und SSE einige Unterschiede gibt. Bei SSE musst du den Server separat starten und dann dein Inspector-Tool ausführen. Beim Inspector-Tool gibt es außerdem Unterschiede, da du die URL angeben musst.

## Beispiele

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Was kommt als Nächstes

- Nächstes Thema: [HTTP Streaming mit MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.