<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:09:07+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "de"
}
-->
Im vorherigen Code haben wir:

- Die Bibliotheken importiert
- Eine Instanz eines Clients erstellt und diese mit stdio als Transport verbunden.
- Prompts, Ressourcen und Tools aufgelistet und alle aufgerufen.

Da haben Sie es, ein Client, der mit einem MCP-Server kommunizieren kann.

Nehmen wir uns im nächsten Übungsteil Zeit, um jeden Codeabschnitt zu analysieren und zu erklären, was passiert.

## Übung: Einen Client schreiben

Wie oben gesagt, nehmen wir uns Zeit, den Code zu erklären, und Sie können gerne mitprogrammieren, wenn Sie möchten.

### -1- Bibliotheken importieren

Lassen Sie uns die benötigten Bibliotheken importieren. Wir brauchen Referenzen auf einen Client und auf unser gewähltes Transportprotokoll, stdio. stdio ist ein Protokoll für Dinge, die auf Ihrem lokalen Rechner laufen sollen. SSE ist ein weiteres Transportprotokoll, das wir in zukünftigen Kapiteln zeigen werden, aber das ist Ihre andere Option. Für den Moment machen wir mit stdio weiter.

---

Kommen wir zur Instanziierung.

### -2- Client und Transport instanziieren

Wir müssen eine Instanz des Transports und eine unseres Clients erstellen:

---

### -3- Serverfunktionen auflisten

Jetzt haben wir einen Client, der sich verbinden kann, wenn das Programm ausgeführt wird. Allerdings listet er seine Funktionen noch nicht auf, das machen wir jetzt:

---

Super, jetzt haben wir alle Funktionen erfasst. Die Frage ist nun, wann verwenden wir sie? Dieser Client ist ziemlich einfach, einfach in dem Sinne, dass wir die Funktionen explizit aufrufen müssen, wenn wir sie brauchen. Im nächsten Kapitel erstellen wir einen fortgeschritteneren Client, der Zugriff auf sein eigenes großes Sprachmodell (LLM) hat. Für jetzt schauen wir uns an, wie wir die Funktionen auf dem Server aufrufen können:

### -4- Funktionen aufrufen

Um die Funktionen aufzurufen, müssen wir sicherstellen, dass wir die richtigen Argumente angeben und in manchen Fällen den Namen dessen, was wir aufrufen wollen.

---

### -5- Client ausführen

Um den Client auszuführen, geben Sie folgenden Befehl im Terminal ein:

---

## Aufgabe

In dieser Aufgabe verwenden Sie das Gelernte zum Erstellen eines Clients, aber erstellen Sie einen eigenen Client.

Hier ist ein Server, den Sie über Ihren Client-Code ansprechen können. Versuchen Sie, dem Server weitere Funktionen hinzuzufügen, um ihn interessanter zu machen.

---

## Lösung

[Lösung](./solution/README.md)

## Wichtige Erkenntnisse

Die wichtigsten Erkenntnisse dieses Kapitels zu Clients sind:

- Sie können verwendet werden, um Funktionen auf dem Server zu entdecken und aufzurufen.
- Sie können einen Server starten, während sie selbst starten (wie in diesem Kapitel), aber Clients können sich auch mit bereits laufenden Servern verbinden.
- Sie sind eine großartige Möglichkeit, Serverfunktionen zu testen, neben Alternativen wie dem Inspector, wie im vorherigen Kapitel beschrieben.

## Zusätzliche Ressourcen

- [Clients in MCP erstellen](https://modelcontextprotocol.io/quickstart/client)

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](../samples/javascript/README.md)
- [TypeScript Rechner](../samples/typescript/README.md)
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Was kommt als Nächstes

- Weiter: [Einen Client mit einem LLM erstellen](../03-llm-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.