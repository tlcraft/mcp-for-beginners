<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-16T15:24:46+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "de"
}
-->
Im vorherigen Code haben wir:

- Die Bibliotheken importiert
- Eine Instanz eines Clients erstellt und ihn über stdio als Transport verbunden.
- Prompts, Ressourcen und Tools aufgelistet und alle aufgerufen.

Da haben Sie es, ein Client, der mit einem MCP-Server kommunizieren kann.

Nehmen wir uns im nächsten Übungsabschnitt Zeit, um jeden Codeausschnitt zu analysieren und zu erklären, was passiert.

## Übung: Einen Client schreiben

Wie oben gesagt, nehmen wir uns Zeit, den Code zu erklären, und gerne können Sie dabei mitprogrammieren.

### -1- Bibliotheken importieren

Importieren wir die benötigten Bibliotheken. Wir brauchen Verweise auf einen Client und unser gewähltes Transportprotokoll, stdio. stdio ist ein Protokoll für Programme, die lokal auf Ihrem Rechner laufen. SSE ist ein weiteres Transportprotokoll, das wir in späteren Kapiteln vorstellen, aber das ist Ihre andere Option. Für den Moment bleiben wir bei stdio.

---

Kommen wir zur Instanziierung.

### -2- Client und Transport instanziieren

Wir müssen eine Instanz des Transports und des Clients erstellen:

---

### -3- Server-Funktionen auflisten

Jetzt haben wir einen Client, der sich verbinden kann, wenn das Programm ausgeführt wird. Allerdings listet er seine Funktionen noch nicht auf, das machen wir jetzt:

---

Super, jetzt haben wir alle Funktionen erfasst. Die Frage ist nun: Wann nutzen wir sie? Dieser Client ist recht einfach, das heißt, wir müssen die Funktionen explizit aufrufen, wenn wir sie brauchen. Im nächsten Kapitel erstellen wir einen fortgeschritteneren Client, der Zugriff auf ein eigenes großes Sprachmodell (LLM) hat. Für den Moment schauen wir uns an, wie wir die Funktionen auf dem Server aufrufen können:

### -4- Funktionen aufrufen

Um die Funktionen aufzurufen, müssen wir sicherstellen, dass wir die richtigen Argumente angeben und in manchen Fällen den Namen dessen, was wir aufrufen wollen.

---

### -5- Client starten

Um den Client zu starten, geben Sie folgenden Befehl im Terminal ein:

---

## Aufgabe

In dieser Aufgabe verwenden Sie das Gelernte zum Erstellen eines Clients, schreiben aber Ihren eigenen Client.

Hier ist ein Server, den Sie verwenden können und den Sie über Ihren Client-Code ansprechen müssen. Versuchen Sie, dem Server weitere Funktionen hinzuzufügen, um ihn interessanter zu machen.

---

## Lösung

[Lösung](./solution/README.md)

## Wichtige Erkenntnisse

Die wichtigsten Erkenntnisse dieses Kapitels über Clients sind:

- Sie können sowohl verwendet werden, um Funktionen auf dem Server zu entdecken als auch aufzurufen.
- Sie können einen Server starten, während sie selbst starten (wie in diesem Kapitel), aber Clients können sich auch mit bereits laufenden Servern verbinden.
- Sie sind eine großartige Möglichkeit, Server-Fähigkeiten zu testen, neben Alternativen wie dem Inspector, der im vorherigen Kapitel beschrieben wurde.

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
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Originalsprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.