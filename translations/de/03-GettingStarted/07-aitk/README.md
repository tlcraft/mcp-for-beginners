<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T15:31:04+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "de"
}
-->
# Nutzung eines Servers aus der AI Toolkit-Erweiterung für Visual Studio Code

Beim Erstellen eines KI-Agenten geht es nicht nur darum, intelligente Antworten zu generieren, sondern auch darum, dem Agenten die Fähigkeit zu geben, aktiv zu handeln. Genau hier kommt das Model Context Protocol (MCP) ins Spiel. MCP ermöglicht es Agenten, auf externe Werkzeuge und Dienste auf eine einheitliche Weise zuzugreifen. Man kann es sich vorstellen wie das Anschließen des Agenten an einen Werkzeugkasten, den er *wirklich* nutzen kann.

Angenommen, Sie verbinden einen Agenten mit Ihrem Rechner-MCP-Server. Plötzlich kann Ihr Agent mathematische Operationen ausführen, indem er einfach eine Eingabe wie „Was ist 47 mal 89?“ erhält – ohne dass Sie Logik fest programmieren oder eigene APIs erstellen müssen.

## Überblick

Diese Lektion zeigt, wie Sie einen Rechner-MCP-Server mit einem Agenten über die [AI Toolkit](https://aka.ms/AIToolkit)-Erweiterung in Visual Studio Code verbinden, sodass Ihr Agent mathematische Operationen wie Addition, Subtraktion, Multiplikation und Division über natürliche Sprache ausführen kann.

AI Toolkit ist eine leistungsstarke Erweiterung für Visual Studio Code, die die Entwicklung von Agenten vereinfacht. KI-Ingenieure können damit KI-Anwendungen einfach erstellen und generative KI-Modelle lokal oder in der Cloud entwickeln und testen. Die Erweiterung unterstützt die meisten heute verfügbaren großen generativen Modelle.

*Hinweis*: Das AI Toolkit unterstützt derzeit Python und TypeScript.

## Lernziele

Am Ende dieser Lektion können Sie:

- Einen MCP-Server über das AI Toolkit nutzen.
- Eine Agentenkonfiguration einrichten, damit der Agent Werkzeuge des MCP-Servers entdecken und verwenden kann.
- MCP-Werkzeuge über natürliche Sprache einsetzen.

## Vorgehensweise

So gehen wir auf hoher Ebene vor:

- Einen Agenten erstellen und dessen System-Prompt definieren.
- Einen MCP-Server mit Rechner-Werkzeugen erstellen.
- Den Agent Builder mit dem MCP-Server verbinden.
- Die Werkzeugaufrufe des Agenten über natürliche Sprache testen.

Super, jetzt wo wir den Ablauf kennen, konfigurieren wir einen KI-Agenten, der externe Werkzeuge über MCP nutzt und so seine Fähigkeiten erweitert!

## Voraussetzungen

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit für Visual Studio Code](https://aka.ms/AIToolkit)

## Übung: Einen Server nutzen

In dieser Übung bauen, starten und erweitern Sie einen KI-Agenten mit Werkzeugen eines MCP-Servers innerhalb von Visual Studio Code mithilfe des AI Toolkits.

### -0- Vorbereitung: Das OpenAI GPT-4o Modell zu My Models hinzufügen

Die Übung verwendet das **GPT-4o** Modell. Dieses sollte vor der Erstellung des Agenten zu **My Models** hinzugefügt werden.

![Screenshot einer Modellauswahl in der AI Toolkit-Erweiterung von Visual Studio Code. Überschrift: "Find the right model for your AI Solution" mit Untertitel, der Nutzer ermutigt, KI-Modelle zu entdecken, zu testen und bereitzustellen. Unter „Popular Models“ sind sechs Modellkarten zu sehen: DeepSeek-R1 (GitHub-gehostet), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Klein, Schnell) und DeepSeek-R1 (Ollama-gehostet). Jede Karte bietet Optionen zum „Hinzufügen“ oder „Im Playground testen“.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.de.png)

1. Öffnen Sie die **AI Toolkit**-Erweiterung über die **Activity Bar**.
2. Wählen Sie im Bereich **Catalog** den Eintrag **Models**, um den **Model Catalog** zu öffnen. Das öffnet den Model Catalog in einem neuen Editor-Tab.
3. Geben Sie in der Suchleiste des **Model Catalog** „OpenAI GPT-4o“ ein.
4. Klicken Sie auf **+ Add**, um das Modell zu Ihrer Liste **My Models** hinzuzufügen. Achten Sie darauf, das Modell auszuwählen, das **von GitHub gehostet** wird.
5. Überprüfen Sie in der **Activity Bar**, dass das Modell **OpenAI GPT-4o** in der Liste erscheint.

### -1- Einen Agenten erstellen

Der **Agent (Prompt) Builder** ermöglicht es Ihnen, eigene KI-Agenten zu erstellen und anzupassen. In diesem Abschnitt erstellen Sie einen neuen Agenten und weisen ihm ein Modell zu, das die Konversation steuert.

![Screenshot der "Calculator Agent"-Builder-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Im linken Panel ist das Modell "OpenAI GPT-4o (via GitHub)" ausgewählt. Ein System-Prompt lautet: "You are a professor in university teaching math," und der Nutzer-Prompt: "Explain to me the Fourier equation in simple terms." Weitere Optionen sind Buttons zum Hinzufügen von Werkzeugen, Aktivieren des MCP Servers und Auswahl der strukturierten Ausgabe. Unten befindet sich ein blauer „Run“-Button. Im rechten Panel unter "Get Started with Examples" sind drei Beispielagenten gelistet: Web Developer (mit MCP Server, Second-Grade Simplifier und Dream Interpreter, jeweils mit kurzen Beschreibungen ihrer Funktionen).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.de.png)

1. Öffnen Sie die **AI Toolkit**-Erweiterung über die **Activity Bar**.
2. Wählen Sie im Bereich **Tools** den Eintrag **Agent (Prompt) Builder**. Das öffnet den Agent (Prompt) Builder in einem neuen Editor-Tab.
3. Klicken Sie auf die Schaltfläche **+ New Agent**. Die Erweiterung startet einen Einrichtungsassistenten über die **Command Palette**.
4. Geben Sie den Namen **Calculator Agent** ein und drücken Sie **Enter**.
5. Wählen Sie im Feld **Model** des **Agent (Prompt) Builder** das Modell **OpenAI GPT-4o (via GitHub)** aus.

### -2- Einen System-Prompt für den Agenten erstellen

Nachdem der Agent erstellt wurde, definieren Sie seine Persönlichkeit und seinen Zweck. In diesem Abschnitt verwenden Sie die Funktion **Generate system prompt**, um das gewünschte Verhalten des Agenten zu beschreiben – in diesem Fall als Rechner-Agent – und das Modell den System-Prompt für Sie schreiben zu lassen.

![Screenshot der "Calculator Agent"-Oberfläche im AI Toolkit für Visual Studio Code mit einem geöffneten Modalfenster „Generate a prompt“. Das Modal erklärt, dass eine Prompt-Vorlage durch Eingabe grundlegender Details generiert werden kann und zeigt ein Textfeld mit folgendem Beispiel-System-Prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Unter dem Textfeld befinden sich die Buttons „Close“ und „Generate“. Im Hintergrund ist ein Teil der Agentenkonfiguration sichtbar, inklusive des ausgewählten Modells "OpenAI GPT-4o (via GitHub)" und Feldern für System- und Nutzer-Prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.de.png)

1. Klicken Sie im Bereich **Prompts** auf die Schaltfläche **Generate system prompt**. Diese öffnet den Prompt Builder, der KI nutzt, um einen System-Prompt für den Agenten zu generieren.
2. Geben Sie im Fenster **Generate a prompt** Folgendes ein: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Klicken Sie auf **Generate**. Unten rechts erscheint eine Benachrichtigung, dass der System-Prompt generiert wird. Nach Abschluss wird der Prompt im Feld **System prompt** des **Agent (Prompt) Builder** angezeigt.
4. Überprüfen Sie den **System prompt** und passen Sie ihn bei Bedarf an.

### -3- Einen MCP-Server erstellen

Nachdem Sie den System-Prompt definiert haben, der das Verhalten und die Antworten des Agenten steuert, statten Sie den Agenten nun mit praktischen Fähigkeiten aus. In diesem Abschnitt erstellen Sie einen Rechner-MCP-Server mit Werkzeugen für Addition, Subtraktion, Multiplikation und Division. Dieser Server ermöglicht es Ihrem Agenten, mathematische Operationen in Echtzeit als Antwort auf natürliche Spracheingaben auszuführen.

![Screenshot des unteren Bereichs der Calculator Agent-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Es sind aufklappbare Menüs für „Tools“ und „Structure output“ zu sehen sowie ein Dropdown-Menü „Choose output format“ mit der Auswahl „text“. Rechts befindet sich ein Button „+ MCP Server“ zum Hinzufügen eines Model Context Protocol Servers. Über dem Tools-Bereich ist ein Platzhalter für ein Bildsymbol zu sehen.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.de.png)

Das AI Toolkit bietet Vorlagen, die das Erstellen eigener MCP-Server erleichtern. Wir verwenden die Python-Vorlage, um den Rechner-MCP-Server zu erstellen.

*Hinweis*: Das AI Toolkit unterstützt derzeit Python und TypeScript.

1. Klicken Sie im Bereich **Tools** des **Agent (Prompt) Builder** auf die Schaltfläche **+ MCP Server**. Die Erweiterung startet einen Einrichtungsassistenten über die **Command Palette**.
2. Wählen Sie **+ Add Server**.
3. Wählen Sie **Create a New MCP Server**.
4. Wählen Sie die Vorlage **python-weather** aus.
5. Wählen Sie den **Default folder** zum Speichern der MCP-Server-Vorlage.
6. Geben Sie als Namen für den Server **Calculator** ein.
7. Ein neues Visual Studio Code-Fenster öffnet sich. Wählen Sie **Yes, I trust the authors**.
8. Erstellen Sie im Terminal (**Terminal** > **New Terminal**) eine virtuelle Umgebung: `python -m venv .venv`
9. Aktivieren Sie im Terminal die virtuelle Umgebung:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Installieren Sie im Terminal die Abhängigkeiten: `pip install -e .[dev]`
11. Öffnen Sie im **Explorer** der **Activity Bar** das Verzeichnis **src** und wählen Sie die Datei **server.py** zum Bearbeiten aus.
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

Jetzt, wo Ihr Agent Werkzeuge hat, ist es Zeit, sie zu nutzen! In diesem Abschnitt senden Sie Eingaben an den Agenten, um zu testen und zu überprüfen, ob der Agent das passende Werkzeug vom Rechner-MCP-Server verwendet.

![Screenshot der Calculator Agent-Oberfläche in der AI Toolkit-Erweiterung für Visual Studio Code. Im linken Panel unter „Tools“ ist ein MCP-Server namens local-server-calculator_server hinzugefügt, der vier verfügbare Werkzeuge zeigt: add, subtract, multiply und divide. Ein Badge zeigt, dass vier Werkzeuge aktiv sind. Darunter ist ein eingeklapptes „Structure output“-Menü und ein blauer „Run“-Button. Im rechten Panel unter „Model Response“ ruft der Agent die Werkzeuge multiply und subtract mit den Eingaben {"a": 3, "b": 25} bzw. {"a": 75, "b": 20} auf. Die finale „Tool Response“ wird als 75.0 angezeigt. Unten erscheint ein „View Code“-Button.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.de.png)

Sie führen den Rechner-MCP-Server lokal auf Ihrer Entwicklungsmaschine über den **Agent Builder** als MCP-Client aus.

1. Drücken Sie `F5`, um das Debugging des MCP-Servers zu starten. Der **Agent (Prompt) Builder** öffnet sich in einem neuen Editor-Tab. Der Serverstatus ist im Terminal sichtbar.
2. Geben Sie im Feld **User prompt** des **Agent (Prompt) Builder** folgenden Text ein: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. Klicken Sie auf die Schaltfläche **Run**, um die Antwort des Agenten zu generieren.
4. Überprüfen Sie die Ausgabe des Agenten. Das Modell sollte zu dem Ergebnis kommen, dass Sie **55 $** bezahlt haben.
5. So sollte der Ablauf aussehen:
    - Der Agent wählt die Werkzeuge **multiply** und **subtract** zur Unterstützung der Berechnung aus.
    - Die jeweiligen Werte für `a` und `b` werden für das Werkzeug **multiply** zugewiesen.
    - Die jeweiligen Werte für `a` und `b` werden für das Werkzeug **subtract** zugewiesen.
    - Die Antwort jedes Werkzeugs wird in der jeweiligen **Tool Response** angezeigt.
    - Die finale Ausgabe des Modells erscheint in der abschließenden **Model Response**.
6. Geben Sie weitere Eingaben ein, um den Agenten weiter zu testen. Sie können den bestehenden Text im Feld **User prompt** durch Klicken und Ersetzen ändern.
7. Wenn Sie mit dem Testen fertig sind, können Sie den Server im **Terminal** mit **STRG/CMD+C** beenden.

## Aufgabe

Versuchen Sie, Ihrer **server.py**-Datei einen weiteren Werkzeug-Eintrag hinzuzufügen (z. B. die Quadratwurzel einer Zahl berechnen). Geben Sie weitere Eingaben ein, die den Agenten dazu bringen, Ihr neues Werkzeug (oder bestehende Werkzeuge) zu nutzen. Vergessen Sie nicht, den Server neu zu starten, damit die neuen Werkzeuge geladen werden.

## Lösung

[Lösung](./solution/README.md)

## Wichtige Erkenntnisse

Folgendes nehmen Sie aus diesem Kapitel mit:

- Die AI Toolkit-Erweiterung ist ein großartiger Client, mit dem Sie MCP-Server und deren Werkzeuge nutzen können.
- Sie können MCP-Servern neue Werkzeuge hinzufügen und so die Fähigkeiten des Agenten an sich ändernde Anforderungen anpassen.
- Das AI Toolkit enthält Vorlagen (z. B. Python MCP-Server-Vorlagen), die das Erstellen eigener Werkzeuge vereinfachen.

## Zusätzliche Ressourcen

- [AI Toolkit Dokumentation](https://aka.ms/AIToolkit/doc)

## Was kommt als Nächstes
- Weiter mit: [Testing & Debugging](../08-testing/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.