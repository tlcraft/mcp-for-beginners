<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T15:10:50+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "de"
}
-->
Im vorherigen Code haben wir:

- Die Bibliotheken importiert
- Eine Instanz eines Clients erstellt und diese mit stdio als Transport verbunden.
- Prompts, Ressourcen und Tools aufgelistet und alle aufgerufen.

Da haben Sie es, ein Client, der mit einem MCP-Server kommunizieren kann.

Nehmen wir uns im nächsten Übungsteil Zeit, jeden Codeausschnitt zu analysieren und zu erklären, was passiert.

## Übung: Einen Client schreiben

Wie oben erwähnt, nehmen wir uns Zeit, den Code zu erklären, und Sie können gerne mitprogrammieren, wenn Sie möchten.

### -1- Bibliotheken importieren

Lassen Sie uns die benötigten Bibliotheken importieren. Wir brauchen Referenzen auf einen Client und auf unser gewähltes Transportprotokoll, stdio. stdio ist ein Protokoll für Dinge, die auf Ihrem lokalen Rechner laufen sollen. SSE ist ein weiteres Transportprotokoll, das wir in zukünftigen Kapiteln vorstellen werden, das ist Ihre andere Option. Für jetzt bleiben wir aber bei stdio.

---

Kommen wir zur Instanziierung.

### -2- Client und Transport instanziieren

Wir müssen eine Instanz des Transports und eine unseres Clients erstellen:

---

### -3- Server-Funktionen auflisten

Nun haben wir einen Client, der sich verbinden kann, wenn das Programm ausgeführt wird. Allerdings listet er seine Funktionen noch nicht auf, das machen wir jetzt:

---

Super, jetzt haben wir alle Funktionen erfasst. Nun stellt sich die Frage: Wann nutzen wir sie? Dieser Client ist recht einfach, das heißt, wir müssen die Funktionen explizit aufrufen, wenn wir sie brauchen. Im nächsten Kapitel erstellen wir einen fortgeschritteneren Client, der Zugriff auf sein eigenes großes Sprachmodell (LLM) hat. Für jetzt schauen wir uns an, wie man die Funktionen auf dem Server aufruft:

### -4- Funktionen aufrufen

Um Funktionen aufzurufen, müssen wir sicherstellen, dass wir die richtigen Argumente angeben und in manchen Fällen den Namen der Funktion, die wir aufrufen möchten.

---

### -5- Client ausführen

Um den Client auszuführen, geben Sie folgenden Befehl im Terminal ein:

---

## Aufgabe

In dieser Aufgabe nutzen Sie das Gelernte zum Erstellen eines Clients, erstellen aber einen eigenen Client.

Hier ist ein Server, den Sie mit Ihrem Client-Code ansprechen können. Versuchen Sie, dem Server weitere Funktionen hinzuzufügen, um ihn interessanter zu machen.

---

## Lösung

[Lösung](./solution/README.md)

## Wichtigste Erkenntnisse

Die wichtigsten Erkenntnisse aus diesem Kapitel zum Thema Clients sind:

- Clients können sowohl dazu verwendet werden, Funktionen auf dem Server zu entdecken als auch aufzurufen.
- Clients können einen Server starten, während sie selbst starten (wie in diesem Kapitel), aber Clients können auch eine Verbindung zu bereits laufenden Servern herstellen.
- Clients sind eine großartige Möglichkeit, Server-Funktionalitäten zu testen, neben Alternativen wie dem Inspector, wie im vorherigen Kapitel beschrieben.

## Zusätzliche Ressourcen

- [Clients in MCP erstellen](https://modelcontextprotocol.io/quickstart/client)

## Beispiele

- [Java Rechner](../samples/java/calculator/README.md)
- [.Net Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rechner](../samples/javascript/README.md)
- [TypeScript Rechner](../samples/typescript/README.md)
- [Python Rechner](../../../../03-GettingStarted/samples/python)

## Was kommt als Nächstes

- Als Nächstes: [Einen Client mit einem LLM erstellen](/03-GettingStarted/03-llm-client/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.