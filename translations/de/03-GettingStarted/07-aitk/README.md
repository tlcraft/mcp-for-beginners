<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-12T22:28:53+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "de"
}
-->
# Nutzung eines Servers aus der AI Toolkit-Erweiterung für Visual Studio Code

Beim Erstellen eines KI-Agenten geht es nicht nur darum, intelligente Antworten zu generieren; es geht auch darum, dem Agenten die Fähigkeit zu geben, aktiv zu handeln. Genau hier kommt das Model Context Protocol (MCP) ins Spiel. MCP erleichtert es Agenten, konsistent auf externe Werkzeuge und Dienste zuzugreifen. Man kann es sich vorstellen wie das Anschließen des Agenten an einen Werkzeugkasten, den er *wirklich* nutzen kann.

Angenommen, Sie verbinden einen Agenten mit Ihrem Rechner-MCP-Server. Plötzlich kann Ihr Agent mathematische Operationen durchführen, indem er einfach eine Eingabe wie „Was ist 47 mal 89?“ erhält – ohne dass Sie Logik fest codieren oder eigene APIs erstellen müssen.

## Überblick

Diese Lektion zeigt, wie man einen Rechner-MCP-Server mit einem Agenten über die [AI Toolkit](https://aka.ms/AIToolkit)-Erweiterung in Visual Studio Code verbindet, sodass Ihr Agent mathematische Operationen wie Addition, Subtraktion, Multiplikation und Division in natürlicher Sprache ausführen kann.

AI Toolkit ist eine leistungsstarke Erweiterung für Visual Studio Code, die die Agentenentwicklung vereinfacht. AI Engineers können damit KI-Anwendungen leicht entwickeln und generative KI-Modelle lokal oder in der Cloud testen. Die Erweiterung unterstützt die meisten heute verfügbaren großen generativen Modelle.

*Hinweis*: Das AI Toolkit unterstützt derzeit Python und TypeScript.

## Lernziele

Am Ende dieser Lektion können Sie:

- Einen MCP-Server über das AI Toolkit nutzen.
- Eine Agentenkonfiguration einrichten, damit der Agent Werkzeuge vom MCP-Server finden und verwenden kann.
- MCP-Werkzeuge über natürliche Sprache verwenden.

## Vorgehensweise

So gehen wir auf hoher Ebene vor:

- Einen Agenten erstellen und dessen Systemprompt definieren.
- Einen MCP-Server mit Rechner-Werkzeugen erstellen.
- Den Agent Builder mit dem MCP-Server verbinden.
- Die Werkzeugaufrufe des Agenten über natürliche Sprache testen.

Super, da wir den Ablauf kennen, konfigurieren wir jetzt einen KI-Agenten, der externe Werkzeuge über MCP nutzt und so seine Fähigkeiten erweitert!

## Voraussetzungen

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit für Visual Studio Code](https://aka.ms/AIToolkit)

## Übung: Nutzung eines Servers

In dieser Übung bauen, starten und erweitern Sie einen KI-Agenten mit Werkzeugen von einem MCP-Server innerhalb von Visual Studio Code mit dem AI Toolkit.

### -0- Vorbereitung: Fügen Sie das OpenAI GPT-4o Modell zu My Models hinzu

Die Übung nutzt das **GPT-4o** Modell. Dieses sollte vor der Erstellung des Agenten zu **My Models** hinzugefügt werden.

![Screenshot einer Modellauswahloberfläche in der AI Toolkit-Erweiterung von Visual Studio Code. Die Überschrift lautet "Find the right model for your AI Solution" mit einem Untertitel, der Nutzer ermutigt, KI-Modelle zu entdecken, zu testen und bereitzustellen. Unter „Popular Models“ werden sechs Modellkarten angezeigt: DeepSeek-R1 (GitHub-gehostet), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Klein, Schnell) und DeepSeek-R1 (Ollama-gehostet). Jede Karte bietet Optionen zum „Hinzufügen“ oder „Im Playground testen“.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.de.png)

1. Öffnen Sie die **AI Toolkit**-Erweiterung über die **Activity Bar**.
2. Wählen Sie im Bereich **Catalog** die Option **Models**, um den **Model Catalog** zu öffnen. Das Öffnen von **Models** öffnet den **Model Catalog** in einem neuen Editor-Tab.
3. Geben Sie im Suchfeld des **Model Catalog** **OpenAI GPT-4o** ein.
4. Klicken Sie auf **+ Add**, um das Modell zu Ihrer **My Models**-Liste hinzuzufügen. Achten Sie darauf, dass Sie das Modell auswählen, das **Hosted by GitHub** ist.
5. Vergewissern Sie sich in der **Activity Bar**, dass das **OpenAI GPT-4o** Modell in der Liste erscheint.

### -1- Einen Agenten erstellen

Der **Agent (Prompt) Builder** ermöglicht es Ihnen, eigene KI-gestützte Agenten zu erstellen und anzupassen. In diesem Abschnitt erstellen Sie einen neuen Agenten und wählen ein Modell für die Unterhaltung aus.

![Screenshot der "Calculator Agent" Builder-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Im linken Bereich ist das Modell "OpenAI GPT-4o (via GitHub)" ausgewählt. Ein Systemprompt lautet "You are a professor in university teaching math" und der Nutzerprompt „Explain to me the Fourier equation in simple terms“. Weitere Optionen umfassen Buttons zum Hinzufügen von Werkzeugen, Aktivieren des MCP Servers und Auswahl der strukturierten Ausgabe. Unten befindet sich ein blauer „Run“-Button. Im rechten Bereich unter „Get Started with Examples“ sind drei Beispielagenten aufgelistet: Web Developer (mit MCP Server), Second-Grade Simplifier und Dream Interpreter, jeweils mit kurzen Beschreibungen ihrer Funktionen.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.de.png)

1. Öffnen Sie die **AI Toolkit**-Erweiterung über die **Activity Bar**.
2. Wählen Sie im Bereich **Tools** den **Agent (Prompt) Builder** aus. Das Öffnen des **Agent (Prompt) Builder** öffnet diesen in einem neuen Editor-Tab.
3. Klicken Sie auf die Schaltfläche **+ New Agent**. Die Erweiterung startet einen Setup-Assistenten über die **Command Palette**.
4. Geben Sie den Namen **Calculator Agent** ein und drücken Sie **Enter**.
5. Wählen Sie im **Agent (Prompt) Builder** im Feld **Model** das Modell **OpenAI GPT-4o (via GitHub)** aus.

### -2- Einen Systemprompt für den Agenten erstellen

Nachdem der Agent erstellt ist, definieren Sie nun seine Persönlichkeit und seinen Zweck. In diesem Abschnitt verwenden Sie die Funktion **Generate system prompt**, um das gewünschte Verhalten des Agenten zu beschreiben – in diesem Fall als Rechner-Agent – und das Modell den Systemprompt für Sie erstellen zu lassen.

![Screenshot der "Calculator Agent"-Oberfläche im AI Toolkit für Visual Studio Code mit geöffnetem Modalfenster „Generate a prompt“. Das Modal erklärt, dass eine Prompt-Vorlage durch Eingabe grundlegender Details generiert werden kann, und zeigt ein Textfeld mit dem Beispiel-Systemprompt: „You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.“ Unter dem Textfeld befinden sich die Buttons „Close“ und „Generate“. Im Hintergrund ist ein Teil der Agentenkonfiguration sichtbar, einschließlich des ausgewählten Modells „OpenAI GPT-4o (via GitHub)“ und der Felder für System- und Nutzer-Prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.de.png)

1. Klicken Sie im Abschnitt **Prompts** auf die Schaltfläche **Generate system prompt**. Diese öffnet den Prompt-Builder, der KI nutzt, um einen Systemprompt für den Agenten zu generieren.
2. Geben Sie im Fenster **Generate a prompt** Folgendes ein: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Klicken Sie auf **Generate**. Unten rechts erscheint eine Benachrichtigung, dass der Systemprompt generiert wird. Sobald die Generierung abgeschlossen ist, erscheint der Prompt im Feld **System prompt** des **Agent (Prompt) Builder**.
4. Überprüfen Sie den **System prompt** und passen Sie ihn bei Bedarf an.

### -3- Einen MCP-Server erstellen

Nachdem Sie den Systemprompt definiert haben, der das Verhalten und die Antworten des Agenten steuert, statten Sie den Agenten jetzt mit praktischen Fähigkeiten aus. In diesem Abschnitt erstellen Sie einen Rechner-MCP-Server mit Werkzeugen für Addition, Subtraktion, Multiplikation und Division. Dieser Server ermöglicht es Ihrem Agenten, in Echtzeit mathematische Operationen als Antwort auf natürliche Sprache auszuführen.

!["Screenshot des unteren Bereichs der Calculator Agent-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Zu sehen sind aufklappbare Menüs für „Tools“ und „Structure output“ sowie ein Dropdown-Menü „Choose output format“ mit der Einstellung „text“. Rechts befindet sich ein Button „+ MCP Server“ zum Hinzufügen eines Model Context Protocol-Servers. Über dem Tools-Bereich ist ein Bildsymbol als Platzhalter.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.de.png)

Das AI Toolkit bietet Vorlagen, die das Erstellen eigener MCP-Server erleichtern. Wir verwenden die Python-Vorlage für den Rechner-MCP-Server.

*Hinweis*: Das AI Toolkit unterstützt derzeit Python und TypeScript.

1. Klicken Sie im Bereich **Tools** des **Agent (Prompt) Builder** auf die Schaltfläche **+ MCP Server**. Die Erweiterung startet einen Setup-Assistenten über die **Command Palette**.
2. Wählen Sie **+ Add Server**.
3. Wählen Sie **Create a New MCP Server**.
4. Wählen Sie die Vorlage **python-weather** aus.
5. Wählen Sie **Default folder**, um die MCP-Server-Vorlage zu speichern.
6. Geben Sie folgenden Namen für den Server ein: **Calculator**
7. Ein neues Visual Studio Code-Fenster öffnet sich. Wählen Sie **Yes, I trust the authors**.
8. Erstellen Sie im Terminal (**Terminal** > **New Terminal**) eine virtuelle Umgebung: `python -m venv .venv`
9. Aktivieren Sie die virtuelle Umgebung im Terminal:
    1. Windows – `.venv\Scripts\activate`
    2. macOS/Linux – `source venv/bin/activate`
10. Installieren Sie die Abhängigkeiten im Terminal: `pip install -e .[dev]`
11. Erweitern Sie im **Explorer**-Bereich der **Activity Bar** das Verzeichnis **src** und öffnen Sie die Datei **server.py**.
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

### -4- Den Agenten mit dem Rechner-MCP-Server ausführen

Da Ihr Agent jetzt Werkzeuge hat, ist es Zeit, diese zu nutzen! In diesem Abschnitt senden Sie Eingaben an den Agenten, um zu testen und zu überprüfen, ob er die passenden Werkzeuge des Rechner-MCP-Servers verwendet.

![Screenshot der Calculator Agent-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Im linken Bereich unter „Tools“ ist ein MCP-Server namens local-server-calculator_server hinzugefügt, der vier verfügbare Werkzeuge zeigt: add, subtract, multiply und divide. Ein Badge zeigt, dass vier Werkzeuge aktiv sind. Darunter ist der Bereich „Structure output“ eingeklappt und ein blauer „Run“-Button. Im rechten Bereich unter „Model Response“ ruft der Agent die Werkzeuge multiply und subtract mit Eingaben {"a": 3, "b": 25} bzw. {"a": 75, "b": 20} auf. Die finale „Tool Response“ wird als 75.0 angezeigt. Unten befindet sich ein Button „View Code“.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.de.png)

Sie führen den Rechner-MCP-Server auf Ihrer lokalen Entwicklungsmaschine über den **Agent Builder** als MCP-Client aus.

1. Drücken Sie `F5`` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` Werte werden für das Werkzeug **subtract** zugewiesen.
    - Die Antwort jedes Werkzeugs wird in der jeweiligen **Tool Response** angezeigt.
    - Die endgültige Ausgabe des Modells erscheint in der abschließenden **Model Response**.
2. Geben Sie weitere Eingaben ein, um den Agenten weiter zu testen. Sie können den bestehenden Prompt im Feld **User prompt** durch Anklicken und Ersetzen ändern.
3. Wenn Sie mit dem Testen fertig sind, können Sie den Server über das **Terminal** mit **CTRL/CMD+C** beenden.

## Aufgabe

Versuchen Sie, einen zusätzlichen Werkzeugeintrag in Ihre **server.py**-Datei hinzuzufügen (z. B. die Quadratwurzel einer Zahl berechnen). Geben Sie weitere Eingaben ein, die den Agenten dazu bringen, Ihr neues Werkzeug (oder vorhandene Werkzeuge) zu verwenden. Vergessen Sie nicht, den Server neu zu starten, damit die neuen Werkzeuge geladen werden.

## Lösung

[Lösung](./solution/README.md)

## Wichtige Erkenntnisse

Folgendes nehmen Sie aus diesem Kapitel mit:

- Die AI Toolkit-Erweiterung ist ein großartiger Client, mit dem Sie MCP-Server und deren Werkzeuge nutzen können.
- Sie können MCP-Server um neue Werkzeuge erweitern und so die Fähigkeiten des Agenten an sich ändernde Anforderungen anpassen.
- Das AI Toolkit enthält Vorlagen (z. B. Python MCP-Server-Vorlagen), die das Erstellen eigener Werkzeuge vereinfachen.

## Zusätzliche Ressourcen

- [AI Toolkit Dokumentation](https://aka.ms/AIToolkit/doc)

## Was kommt als Nächstes
- Weiter: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, bitten wir zu beachten, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.