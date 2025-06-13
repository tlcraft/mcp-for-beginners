<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:36:40+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "de"
}
-->
Im vorherigen Code haben wir:

- Die Bibliotheken importiert
- Eine Instanz eines Clients erstellt und diese mit stdio als Transport verbunden.
- Prompts, Ressourcen und Tools aufgelistet und alle aufgerufen.

Damit haben wir einen Client, der mit einem MCP Server kommunizieren kann.

Nehmen wir uns im nächsten Übungsteil Zeit, jeden Codeabschnitt zu analysieren und zu erklären, was passiert.

## Übung: Einen Client schreiben

Wie oben erwähnt, nehmen wir uns Zeit, den Code zu erklären, und natürlich kannst du gerne mitprogrammieren.

### -1- Bibliotheken importieren

Lass uns die benötigten Bibliotheken importieren. Wir brauchen Referenzen auf einen Client und auf unser gewähltes Transportprotokoll, stdio. stdio ist ein Protokoll für Anwendungen, die lokal auf deinem Rechner laufen. SSE ist ein weiteres Transportprotokoll, das wir in späteren Kapiteln vorstellen, aber für den Moment bleiben wir bei stdio.

Kommen wir nun zur Instanziierung.

### -2- Client und Transport instanziieren

Wir müssen eine Instanz des Transports und eine unseres Clients erstellen:

### -3- Serverfunktionen auflisten

Jetzt haben wir einen Client, der sich verbinden kann, wenn das Programm gestartet wird. Allerdings listet er seine Funktionen noch nicht auf, das machen wir jetzt:

Super, nun haben wir alle Funktionen erfasst. Die Frage ist, wann verwenden wir sie? Dieser Client ist recht einfach, das heißt, wir müssen die Funktionen explizit aufrufen, wenn wir sie brauchen. Im nächsten Kapitel erstellen wir einen fortgeschritteneren Client, der Zugriff auf ein eigenes großes Sprachmodell (LLM) hat. Für jetzt schauen wir uns an, wie wir die Funktionen auf dem Server aufrufen können:

### -4- Funktionen aufrufen

Um die Funktionen aufzurufen, müssen wir sicherstellen, dass wir die richtigen Argumente angeben und in manchen Fällen den Namen der Funktion, die wir ausführen wollen.

### -5- Client ausführen

Um den Client zu starten, gib im Terminal folgenden Befehl ein:

## Aufgabe

In dieser Aufgabe nutzt du dein Wissen zum Erstellen eines Clients und entwickelst deinen eigenen Client.

Hier ist ein Server, den du mit deinem Client-Code ansprechen kannst. Versuche, dem Server weitere Funktionen hinzuzufügen, um ihn interessanter zu machen.

## Lösung

[Lösung](./solution/README.md)

## Wichtigste Erkenntnisse

Die wichtigsten Erkenntnisse dieses Kapitels zu Clients sind:

- Sie können verwendet werden, um Funktionen auf dem Server zu entdecken und auszuführen.
- Sie können einen Server starten, während sie selbst starten (wie in diesem Kapitel), aber Clients können sich auch mit bereits laufenden Servern verbinden.
- Sie sind eine hervorragende Möglichkeit, Serverfunktionen zu testen, neben Alternativen wie dem Inspector, der im vorherigen Kapitel beschrieben wurde.

## Zusätzliche Ressourcen

- [Clients in MCP erstellen](https://modelcontextprotocol.io/quickstart/client)

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](../samples/javascript/README.md)
- [TypeScript Rechner](../samples/typescript/README.md)
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Was kommt als Nächstes

- Weiter: [Einen Client mit einem LLM erstellen](/03-GettingStarted/03-llm-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Originalsprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.