<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:21:30+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "de"
}
-->
# Nutzung eines Servers aus der AI Toolkit-Erweiterung für Visual Studio Code

Beim Aufbau eines KI-Agenten geht es nicht nur darum, intelligente Antworten zu generieren, sondern auch darum, dem Agenten die Fähigkeit zu geben, aktiv zu handeln. Hier kommt das Model Context Protocol (MCP) ins Spiel. MCP ermöglicht es Agenten, auf externe Werkzeuge und Dienste auf konsistente Weise zuzugreifen. Man kann es sich vorstellen wie das Anschließen eines Werkzeugkastens, den der Agent *wirklich* nutzen kann.

Angenommen, Sie verbinden einen Agenten mit Ihrem Rechner-MCP-Server. Plötzlich kann Ihr Agent mathematische Operationen ausführen, indem er einfach eine Eingabe wie „Was ist 47 mal 89?“ erhält – ohne dass Logik hartkodiert oder eigene APIs erstellt werden müssen.

## Überblick

Diese Lektion zeigt, wie Sie einen Rechner-MCP-Server mit einem Agenten über die [AI Toolkit](https://aka.ms/AIToolkit)-Erweiterung in Visual Studio Code verbinden, sodass Ihr Agent mathematische Operationen wie Addition, Subtraktion, Multiplikation und Division mittels natürlicher Sprache ausführen kann.

AI Toolkit ist eine leistungsstarke Erweiterung für Visual Studio Code, die die Entwicklung von Agenten vereinfacht. KI-Ingenieure können mühelos KI-Anwendungen erstellen und generative KI-Modelle lokal oder in der Cloud entwickeln und testen. Die Erweiterung unterstützt die meisten heute verfügbaren großen generativen Modelle.

*Hinweis*: AI Toolkit unterstützt derzeit Python und TypeScript.

## Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Einen MCP-Server über das AI Toolkit zu nutzen.
- Eine Agentenkonfiguration so einzurichten, dass sie Tools des MCP-Servers erkennt und verwendet.
- MCP-Tools über natürliche Sprache zu nutzen.

## Vorgehensweise

So gehen wir auf hoher Ebene vor:

- Einen Agenten erstellen und seinen System-Prompt definieren.
- Einen MCP-Server mit Rechner-Tools erstellen.
- Den Agent Builder mit dem MCP-Server verbinden.
- Die Werkzeugaufrufe des Agenten per natürlicher Sprache testen.

Super, jetzt da wir den Ablauf verstanden haben, konfigurieren wir einen KI-Agenten, der externe Werkzeuge über MCP nutzt und so seine Fähigkeiten erweitert!

## Voraussetzungen

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit für Visual Studio Code](https://aka.ms/AIToolkit)

## Übung: Einen Server nutzen

In dieser Übung bauen, starten und verbessern Sie einen KI-Agenten mit Werkzeugen von einem MCP-Server innerhalb von Visual Studio Code mithilfe des AI Toolkits.

### -0- Vorbereitung: Fügen Sie das OpenAI GPT-4o Modell zu My Models hinzu

Die Übung verwendet das **GPT-4o** Modell. Das Modell sollte vor der Erstellung des Agenten zu **My Models** hinzugefügt werden.

![Screenshot einer Modellauswahl-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Die Überschrift lautet „Find the right model for your AI Solution“ mit einem Untertitel, der Nutzer ermutigt, KI-Modelle zu entdecken, zu testen und bereitzustellen. Unter „Popular Models“ werden sechs Modellkarten angezeigt: DeepSeek-R1 (GitHub-gehostet), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Klein, Schnell) und DeepSeek-R1 (Ollama-gehostet). Jede Karte bietet Optionen zum „Hinzufügen“ oder „Im Playground testen“.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.de.png)

1. Öffnen Sie die **AI Toolkit**-Erweiterung über die **Activity Bar**.
1. Wählen Sie im Bereich **Catalog** den Eintrag **Models**, um den **Model Catalog** zu öffnen. Die Auswahl öffnet den **Model Catalog** in einem neuen Editor-Tab.
1. Geben Sie in der Suchleiste des **Model Catalog** **OpenAI GPT-4o** ein.
1. Klicken Sie auf **+ Add**, um das Modell zu Ihrer **My Models**-Liste hinzuzufügen. Achten Sie darauf, dass Sie das Modell auswählen, das **Hosted by GitHub** ist.
1. Überprüfen Sie in der **Activity Bar**, ob das **OpenAI GPT-4o** Modell in der Liste erscheint.

### -1- Erstellen Sie einen Agenten

Der **Agent (Prompt) Builder** ermöglicht es Ihnen, eigene KI-gestützte Agenten zu erstellen und anzupassen. In diesem Abschnitt erstellen Sie einen neuen Agenten und weisen ihm ein Modell zu, das die Konversation steuert.

![Screenshot der „Calculator Agent“-Builder-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Im linken Bereich ist das Modell „OpenAI GPT-4o (via GitHub)“ ausgewählt. Ein System-Prompt lautet „You are a professor in university teaching math“ und der Nutzer-Prompt „Explain to me the Fourier equation in simple terms“. Weitere Optionen beinhalten Buttons zum Hinzufügen von Tools, Aktivieren des MCP Servers und Auswahl einer strukturierten Ausgabe. Unten befindet sich ein blauer „Run“-Button. Rechts sind unter „Get Started with Examples“ drei Beispielagenten gelistet: Web Developer (mit MCP Server), Second-Grade Simplifier und Dream Interpreter, jeweils mit kurzen Beschreibungen ihrer Funktionen.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.de.png)

1. Öffnen Sie die **AI Toolkit**-Erweiterung über die **Activity Bar**.
1. Wählen Sie im Bereich **Tools** den Eintrag **Agent (Prompt) Builder**. Dies öffnet den **Agent (Prompt) Builder** in einem neuen Editor-Tab.
1. Klicken Sie auf die Schaltfläche **+ New Agent**. Die Erweiterung startet einen Setup-Assistenten über die **Command Palette**.
1. Geben Sie den Namen **Calculator Agent** ein und drücken Sie **Enter**.
1. Wählen Sie im **Agent (Prompt) Builder** im Feld **Model** das Modell **OpenAI GPT-4o (via GitHub)** aus.

### -2- Erstellen Sie einen System-Prompt für den Agenten

Nachdem der Agent erstellt ist, definieren Sie nun seine Persönlichkeit und seinen Zweck. In diesem Abschnitt verwenden Sie die Funktion **Generate system prompt**, um das beabsichtigte Verhalten des Agenten zu beschreiben – in diesem Fall als Rechner-Agent – und das Modell den System-Prompt für Sie erstellen zu lassen.

![Screenshot der „Calculator Agent“-Oberfläche im AI Toolkit für Visual Studio Code mit einem geöffneten Modal-Fenster „Generate a prompt“. Das Modal erklärt, dass eine Prompt-Vorlage durch Eingabe grundlegender Details generiert werden kann und zeigt ein Textfeld mit dem Beispiel-System-Prompt: „You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.“ Darunter befinden sich die Buttons „Close“ und „Generate“. Im Hintergrund ist ein Teil der Agentenkonfiguration sichtbar, einschließlich des ausgewählten Modells „OpenAI GPT-4o (via GitHub)“ sowie Feldern für System- und Nutzer-Prompts.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.de.png)

1. Klicken Sie im Bereich **Prompts** auf die Schaltfläche **Generate system prompt**. Diese öffnet den Prompt-Builder, der KI nutzt, um einen System-Prompt für den Agenten zu erstellen.
1. Geben Sie im Fenster **Generate a prompt** Folgendes ein: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klicken Sie auf **Generate**. Eine Benachrichtigung erscheint unten rechts und bestätigt, dass der System-Prompt generiert wird. Nach Abschluss erscheint der Prompt im Feld **System prompt** des **Agent (Prompt) Builder**.
1. Überprüfen Sie den **System prompt** und passen Sie ihn bei Bedarf an.

### -3- Erstellen Sie einen MCP-Server

Nachdem Sie den System-Prompt Ihres Agenten definiert haben, der sein Verhalten und seine Antworten steuert, ist es an der Zeit, den Agenten mit praktischen Fähigkeiten auszustatten. In diesem Abschnitt erstellen Sie einen Rechner-MCP-Server mit Werkzeugen für Addition, Subtraktion, Multiplikation und Division. Dieser Server ermöglicht es Ihrem Agenten, mathematische Operationen in Echtzeit als Antwort auf natürliche Spracheingaben durchzuführen.

!["Screenshot des unteren Bereichs der Calculator Agent-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Es sind ausklappbare Menüs für „Tools“ und „Structure output“ sichtbar sowie ein Dropdown-Menü „Choose output format“ mit der Einstellung „text“. Rechts befindet sich eine Schaltfläche „+ MCP Server“ zum Hinzufügen eines Model Context Protocol Servers. Über dem Bereich „Tools“ ist ein Platzhalter für ein Bildsymbol zu sehen.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.de.png)

AI Toolkit bietet Vorlagen, die das Erstellen eines eigenen MCP-Servers erleichtern. Wir verwenden die Python-Vorlage, um den Rechner-MCP-Server zu erstellen.

*Hinweis*: AI Toolkit unterstützt derzeit Python und TypeScript.

1. Klicken Sie im Bereich **Tools** des **Agent (Prompt) Builder** auf die Schaltfläche **+ MCP Server**. Die Erweiterung startet einen Setup-Assistenten über die **Command Palette**.
1. Wählen Sie **+ Add Server**.
1. Wählen Sie **Create a New MCP Server**.
1. Wählen Sie die Vorlage **python-weather** aus.
1. Wählen Sie den **Default folder** zum Speichern der MCP-Server-Vorlage.
1. Geben Sie folgenden Namen für den Server ein: **Calculator**
1. Ein neues Visual Studio Code-Fenster öffnet sich. Wählen Sie **Yes, I trust the authors**.
1. Erstellen Sie im Terminal (**Terminal** > **New Terminal**) eine virtuelle Umgebung: `python -m venv .venv`
1. Aktivieren Sie im Terminal die virtuelle Umgebung:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Installieren Sie im Terminal die Abhängigkeiten: `pip install -e .[dev]`
1. Öffnen Sie im **Explorer** der **Activity Bar** das Verzeichnis **src** und wählen Sie die Datei **server.py** zum Bearbeiten aus.
1. Ersetzen Sie den Code in der Datei **server.py** durch den folgenden und speichern Sie:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Starten Sie den Agenten mit dem Rechner-MCP-Server

Jetzt, da Ihr Agent Werkzeuge hat, ist es Zeit, sie zu nutzen! In diesem Abschnitt senden Sie Eingaben an den Agenten, um zu testen und zu überprüfen, ob er das richtige Werkzeug vom Rechner-MCP-Server verwendet.

![Screenshot der Calculator Agent-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Im linken Bereich unter „Tools“ ist ein MCP-Server namens local-server-calculator_server hinzugefügt, der vier verfügbare Werkzeuge zeigt: add, subtract, multiply und divide. Ein Badge zeigt an, dass vier Werkzeuge aktiv sind. Darunter ist ein eingeklappter Bereich „Structure output“ und ein blauer „Run“-Button. Im rechten Bereich unter „Model Response“ ruft der Agent die Werkzeuge multiply und subtract mit den Eingaben {"a": 3, "b": 25} bzw. {"a": 75, "b": 20} auf. Die finale „Tool Response“ wird mit 75.0 angezeigt. Unten gibt es einen Button „View Code“.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.de.png)

Sie führen den Rechner-MCP-Server auf Ihrer lokalen Entwicklungsmaschine über den **Agent Builder** als MCP-Client aus.

1. Drücken Sie `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Ich habe 3 Artikel zu je 25 $ gekauft und anschließend einen Rabatt von 20 $ genutzt. Wie viel habe ich bezahlt?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` Werte werden für das Werkzeug **subtract** zugewiesen.
    - Die Antwort jedes Werkzeugs wird in der jeweiligen **Tool Response** angezeigt.
    - Das finale Ergebnis des Modells erscheint in der abschließenden **Model Response**.
1. Geben Sie weitere Eingaben ein, um den Agenten weiter zu testen. Sie können die bestehende Eingabe im Feld **User prompt** durch Anklicken und Ersetzen anpassen.
1. Wenn Sie mit dem Testen fertig sind, können Sie den Server über das **Terminal** mit **CTRL/CMD+C** beenden.

## Aufgabe

Versuchen Sie, Ihrer Datei **server.py** einen weiteren Werkzeug-Eintrag hinzuzufügen (z. B. Rückgabe der Quadratwurzel einer Zahl). Senden Sie weitere Eingaben, die den Agenten dazu bringen, Ihr neues Werkzeug (oder bestehende Werkzeuge) zu verwenden. Denken Sie daran, den Server neu zu starten, damit die neuen Werkzeuge geladen werden.

## Lösung

[Lösung](./solution/README.md)

## Wichtige Erkenntnisse

Folgende Erkenntnisse nehmen Sie aus diesem Kapitel mit:

- Die AI Toolkit-Erweiterung ist ein großartiger Client, mit dem Sie MCP-Server und deren Werkzeuge nutzen können.
- Sie können MCP-Servern neue Werkzeuge hinzufügen, um die Fähigkeiten des Agenten an sich ändernde Anforderungen anzupassen.
- AI Toolkit enthält Vorlagen (z. B. Python MCP-Server-Vorlagen), die das Erstellen eigener Werkzeuge erleichtern.

## Zusätzliche Ressourcen

- [AI Toolkit Dokumentation](https://aka.ms/AIToolkit/doc)

## Was kommt als Nächstes

Weiter zu: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.