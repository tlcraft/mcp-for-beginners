<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-16T15:29:01+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "de"
}
-->
# Verwendung eines Servers aus der AI Toolkit-Erweiterung für Visual Studio Code

Beim Erstellen eines KI-Agenten geht es nicht nur darum, intelligente Antworten zu generieren, sondern auch darum, dem Agenten die Fähigkeit zu geben, aktiv zu handeln. Genau hier kommt das Model Context Protocol (MCP) ins Spiel. MCP erleichtert es Agenten, auf externe Werkzeuge und Dienste auf konsistente Weise zuzugreifen. Man kann es sich vorstellen wie das Anschließen des Agenten an einen Werkzeugkasten, den er *wirklich* nutzen kann.

Angenommen, Sie verbinden einen Agenten mit Ihrem Rechner-MCP-Server. Plötzlich kann Ihr Agent mathematische Operationen ausführen, indem er einfach eine Anfrage wie „Was ist 47 mal 89?“ erhält – ohne dass Sie Logik hart codieren oder eigene APIs erstellen müssen.

## Überblick

Diese Lektion zeigt, wie man einen Rechner-MCP-Server mit einem Agenten über die [AI Toolkit](https://aka.ms/AIToolkit)-Erweiterung in Visual Studio Code verbindet, sodass Ihr Agent mathematische Operationen wie Addition, Subtraktion, Multiplikation und Division über natürliche Sprache ausführen kann.

AI Toolkit ist eine leistungsstarke Erweiterung für Visual Studio Code, die die Entwicklung von Agenten vereinfacht. KI-Ingenieure können damit problemlos KI-Anwendungen entwickeln und generative KI-Modelle lokal oder in der Cloud testen. Die Erweiterung unterstützt die meisten gängigen generativen Modelle, die heute verfügbar sind.

*Hinweis*: Das AI Toolkit unterstützt derzeit Python und TypeScript.

## Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Einen MCP-Server über das AI Toolkit zu nutzen.
- Eine Agentenkonfiguration einzurichten, damit der Agent die vom MCP-Server bereitgestellten Werkzeuge entdecken und verwenden kann.
- MCP-Werkzeuge über natürliche Sprache einzusetzen.

## Vorgehensweise

So gehen wir grob vor:

- Einen Agenten erstellen und dessen System-Prompt definieren.
- Einen MCP-Server mit Rechner-Werkzeugen erstellen.
- Den Agent Builder mit dem MCP-Server verbinden.
- Die Werkzeugaufrufe des Agenten über natürliche Sprache testen.

Super, jetzt wo wir den Ablauf kennen, konfigurieren wir einen KI-Agenten, der externe Werkzeuge über MCP nutzt und so seine Fähigkeiten erweitert!

## Voraussetzungen

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit für Visual Studio Code](https://aka.ms/AIToolkit)

## Übung: Einen Server nutzen

In dieser Übung bauen, starten und erweitern Sie einen KI-Agenten mit Werkzeugen von einem MCP-Server innerhalb von Visual Studio Code mithilfe des AI Toolkit.

### -0- Vorbereitung: OpenAI GPT-4o Modell zu My Models hinzufügen

Die Übung verwendet das **GPT-4o** Modell. Dieses sollte vor der Agentenerstellung zu **My Models** hinzugefügt werden.

![Screenshot der Modellauswahloberfläche in der AI Toolkit-Erweiterung von Visual Studio Code. Die Überschrift lautet "Find the right model for your AI Solution" mit einem Untertitel, der Nutzer ermutigt, KI-Modelle zu entdecken, zu testen und einzusetzen. Unter „Popular Models“ sind sechs Modellkarten zu sehen: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) und DeepSeek-R1 (Ollama-hosted). Jede Karte bietet Optionen zum „Add“ oder „Try in Playground“.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.de.png)

1. Öffnen Sie die **AI Toolkit** Erweiterung über die **Activity Bar**.
2. Wählen Sie im Abschnitt **Catalog** den Punkt **Models**, um den **Model Catalog** zu öffnen. Die Auswahl öffnet den **Model Catalog** in einem neuen Editor-Tab.
3. Geben Sie in der Suchleiste des **Model Catalog** **OpenAI GPT-4o** ein.
4. Klicken Sie auf **+ Add**, um das Modell zu Ihrer Liste **My Models** hinzuzufügen. Achten Sie darauf, dass Sie das Modell auswählen, das **Hosted by GitHub** ist.
5. Überprüfen Sie in der **Activity Bar**, ob das Modell **OpenAI GPT-4o** in der Liste erscheint.

### -1- Einen Agenten erstellen

Der **Agent (Prompt) Builder** ermöglicht es Ihnen, eigene KI-Agenten zu erstellen und anzupassen. In diesem Abschnitt erstellen Sie einen neuen Agenten und weisen ihm ein Modell zu, das die Konversation steuert.

![Screenshot der "Calculator Agent"-Builder-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Im linken Panel ist das Modell "OpenAI GPT-4o (via GitHub)" ausgewählt. Ein System-Prompt lautet "You are a professor in university teaching math," und der Nutzer-Prompt lautet "Explain to me the Fourier equation in simple terms." Weitere Optionen umfassen Buttons zum Hinzufügen von Tools, Aktivieren des MCP Servers und Auswählen der strukturierten Ausgabe. Unten befindet sich ein blauer „Run“-Button. Im rechten Panel sind unter "Get Started with Examples" drei Beispielagenten aufgelistet: Web Developer (mit MCP Server, Second-Grade Simplifier und Dream Interpreter, jeweils mit kurzer Beschreibung ihrer Funktionen).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.de.png)

1. Öffnen Sie die **AI Toolkit** Erweiterung über die **Activity Bar**.
2. Wählen Sie im Abschnitt **Tools** den Punkt **Agent (Prompt) Builder**. Dies öffnet den **Agent (Prompt) Builder** in einem neuen Editor-Tab.
3. Klicken Sie auf die Schaltfläche **+ New Builder**. Die Erweiterung startet einen Setup-Assistenten über die **Command Palette**.
4. Geben Sie den Namen **Calculator Agent** ein und bestätigen Sie mit **Enter**.
5. Wählen Sie im **Agent (Prompt) Builder** im Feld **Model** das Modell **OpenAI GPT-4o (via GitHub)** aus.

### -2- Einen System-Prompt für den Agenten erstellen

Nachdem der Agent angelegt wurde, definieren Sie seine Persönlichkeit und seinen Zweck. In diesem Abschnitt nutzen Sie die Funktion **Generate system prompt**, um das gewünschte Verhalten des Agenten zu beschreiben – hier ein Rechner-Agent – und das Modell den System-Prompt für Sie erstellen zu lassen.

![Screenshot der "Calculator Agent"-Oberfläche im AI Toolkit für Visual Studio Code mit einem geöffneten Modalfenster "Generate a prompt". Das Modal erklärt, dass eine Prompt-Vorlage durch das Teilen grundlegender Details generiert werden kann und zeigt ein Textfeld mit folgendem Beispiel-Prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Unter dem Textfeld befinden sich die Buttons "Close" und "Generate". Im Hintergrund ist ein Teil der Agentenkonfiguration sichtbar, einschließlich des ausgewählten Modells "OpenAI GPT-4o (via GitHub)" und Feldern für System- und Nutzer-Prompts.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.de.png)

1. Klicken Sie im Abschnitt **Prompts** auf die Schaltfläche **Generate system prompt**. Diese öffnet den Prompt-Builder, der KI nutzt, um einen System-Prompt für den Agenten zu generieren.
2. Geben Sie im Fenster **Generate a prompt** Folgendes ein: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Klicken Sie auf **Generate**. Unten rechts erscheint eine Benachrichtigung, dass der System-Prompt generiert wird. Nach Abschluss wird der Prompt im Feld **System prompt** des **Agent (Prompt) Builder** angezeigt.
4. Überprüfen Sie den **System prompt** und passen Sie ihn bei Bedarf an.

### -3- Einen MCP-Server erstellen

Nachdem Sie den System-Prompt für Ihren Agenten definiert haben, der sein Verhalten und seine Antworten steuert, ist es Zeit, ihn mit praktischen Funktionen auszustatten. In diesem Abschnitt erstellen Sie einen Rechner-MCP-Server mit Werkzeugen für Addition, Subtraktion, Multiplikation und Division. Dieser Server ermöglicht Ihrem Agenten, in Echtzeit mathematische Operationen als Antwort auf natürliche Sprachbefehle auszuführen.

!["Screenshot des unteren Bereichs der Calculator Agent-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Es sind ausklappbare Menüs für „Tools“ und „Structure output“ zu sehen sowie ein Dropdown-Menü „Choose output format“ mit der Einstellung „text“. Rechts befindet sich ein Button „+ MCP Server“ zum Hinzufügen eines Model Context Protocol Servers. Über dem Bereich „Tools“ ist ein Platzhalter für ein Bildsymbol zu sehen.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.de.png)

Das AI Toolkit bietet Vorlagen, die das Erstellen eigener MCP-Server erleichtern. Wir verwenden die Python-Vorlage für den Rechner-MCP-Server.

*Hinweis*: Das AI Toolkit unterstützt derzeit Python und TypeScript.

1. Klicken Sie im Abschnitt **Tools** des **Agent (Prompt) Builder** auf die Schaltfläche **+ MCP Server**. Die Erweiterung startet einen Setup-Assistenten über die **Command Palette**.
2. Wählen Sie **+ Add Server**.
3. Wählen Sie **Create a New MCP Server**.
4. Wählen Sie die Vorlage **python-weather** aus.
5. Wählen Sie den **Default folder**, um die MCP-Server-Vorlage zu speichern.
6. Geben Sie als Namen für den Server **Calculator** ein.
7. Ein neues Visual Studio Code-Fenster öffnet sich. Wählen Sie **Yes, I trust the authors**.
8. Erstellen Sie im Terminal (**Terminal** > **New Terminal**) eine virtuelle Umgebung: `python -m venv .venv`
9. Aktivieren Sie im Terminal die virtuelle Umgebung:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Installieren Sie im Terminal die Abhängigkeiten: `pip install -e .[dev]`
11. Erweitern Sie im **Explorer**-Fenster der **Activity Bar** das Verzeichnis **src** und öffnen Sie die Datei **server.py**.
12. Ersetzen Sie den Code in der Datei **server.py** durch den folgenden und speichern Sie:

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

### -4- Agent mit dem Rechner-MCP-Server ausführen

Jetzt, wo Ihr Agent Werkzeuge hat, ist es Zeit, sie zu nutzen! In diesem Abschnitt senden Sie Anfragen an den Agenten, um zu testen und zu überprüfen, ob er das passende Werkzeug vom Rechner-MCP-Server verwendet.

![Screenshot der Calculator Agent-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Im linken Panel unter „Tools“ ist ein MCP-Server namens local-server-calculator_server hinzugefügt, der vier verfügbare Werkzeuge zeigt: add, subtract, multiply und divide. Ein Badge zeigt, dass vier Werkzeuge aktiv sind. Darunter ist ein eingeklapptes „Structure output“-Menü und ein blauer „Run“-Button. Im rechten Panel unter „Model Response“ ruft der Agent die Werkzeuge multiply und subtract mit den Eingaben {"a": 3, "b": 25} bzw. {"a": 75, "b": 20} auf. Die finale „Tool Response“ wird als 75.0 angezeigt. Unten erscheint ein „View Code“-Button.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.de.png)

Sie führen den Rechner-MCP-Server lokal auf Ihrem Entwicklungsrechner über den **Agent Builder** als MCP-Client aus.

1. Drücken Sie `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` Werte werden für das Werkzeug **subtract** zugewiesen.
    - Die Antwort jedes Werkzeugs wird in der jeweiligen **Tool Response** angezeigt.
    - Das endgültige Ergebnis vom Modell wird in der abschließenden **Model Response** dargestellt.
2. Senden Sie weitere Anfragen, um den Agenten weiter zu testen. Sie können den vorhandenen Prompt im Feld **User prompt** ändern, indem Sie in das Feld klicken und den Text ersetzen.
3. Wenn Sie mit dem Testen fertig sind, können Sie den Server im **Terminal** mit **CTRL/CMD+C** beenden.

## Aufgabe

Versuchen Sie, eine weitere Werkzeug-Funktion in Ihre **server.py** Datei einzufügen (z. B. die Berechnung der Quadratwurzel einer Zahl). Senden Sie anschließend weitere Anfragen, bei denen der Agent Ihr neues Werkzeug (oder vorhandene Werkzeuge) nutzen muss. Denken Sie daran, den Server neu zu starten, damit die neuen Werkzeuge geladen werden.

## Lösung

[Lösung](./solution/README.md)

## Wichtigste Erkenntnisse

Folgendes nehmen Sie aus diesem Kapitel mit:

- Die AI Toolkit-Erweiterung ist ein großartiger Client, mit dem Sie MCP-Server und deren Werkzeuge nutzen können.
- Sie können MCP-Server um neue Werkzeuge erweitern und so die Fähigkeiten des Agenten an wachsende Anforderungen anpassen.
- Das AI Toolkit enthält Vorlagen (z. B. Python MCP-Server-Vorlagen), die die Erstellung eigener Werkzeuge vereinfachen.

## Zusätzliche Ressourcen

- [AI Toolkit Dokumentation](https://aka.ms/AIToolkit/doc)

## Was kommt als Nächstes

Weiter zu: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.