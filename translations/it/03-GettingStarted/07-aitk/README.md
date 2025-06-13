<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:19:10+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "it"
}
-->
# Consumare un server dall’estensione AI Toolkit per Visual Studio Code

Quando costruisci un agente AI, non si tratta solo di generare risposte intelligenti; si tratta anche di dare al tuo agente la capacità di agire. È qui che entra in gioco il Model Context Protocol (MCP). MCP facilita l’accesso degli agenti a strumenti e servizi esterni in modo coerente. Pensalo come collegare il tuo agente a una cassetta degli attrezzi che può *davvero* usare.

Immagina di collegare un agente al tuo server MCP calcolatrice. All’improvviso, il tuo agente può eseguire operazioni matematiche semplicemente ricevendo un prompt come “Quanto fa 47 per 89?”—senza bisogno di codificare la logica o creare API personalizzate.

## Panoramica

Questa lezione spiega come collegare un server MCP calcolatrice a un agente con l’estensione [AI Toolkit](https://aka.ms/AIToolkit) in Visual Studio Code, permettendo al tuo agente di eseguire operazioni matematiche come addizione, sottrazione, moltiplicazione e divisione tramite linguaggio naturale.

AI Toolkit è un’estensione potente per Visual Studio Code che semplifica lo sviluppo di agenti. Gli AI Engineers possono facilmente costruire applicazioni AI sviluppando e testando modelli generativi, sia localmente che nel cloud. L’estensione supporta la maggior parte dei modelli generativi principali disponibili oggi.

*Nota*: AI Toolkit supporta attualmente Python e TypeScript.

## Obiettivi di apprendimento

Al termine di questa lezione, sarai in grado di:

- Consumare un server MCP tramite AI Toolkit.
- Configurare una configurazione agente per permettergli di scoprire e utilizzare gli strumenti forniti dal server MCP.
- Utilizzare gli strumenti MCP tramite linguaggio naturale.

## Approccio

Ecco come procedere ad alto livello:

- Creare un agente e definire il suo system prompt.
- Creare un server MCP con strumenti di calcolatrice.
- Collegare l’Agent Builder al server MCP.
- Testare l’invocazione degli strumenti dell’agente tramite linguaggio naturale.

Perfetto, ora che conosciamo il flusso, configuriamo un agente AI per sfruttare strumenti esterni tramite MCP, potenziandone le capacità!

## Prerequisiti

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit per Visual Studio Code](https://aka.ms/AIToolkit)

## Esercizio: Consumare un server

In questo esercizio costruirai, eseguirai e migliorerai un agente AI con strumenti da un server MCP all’interno di Visual Studio Code usando AI Toolkit.

### -0- Passaggio preliminare, aggiungere il modello OpenAI GPT-4o a My Models

L’esercizio utilizza il modello **GPT-4o**. Il modello deve essere aggiunto a **My Models** prima di creare l’agente.

![Screenshot di un’interfaccia di selezione modello nell’estensione AI Toolkit di Visual Studio Code. L’intestazione recita "Find the right model for your AI Solution" con un sottotitolo che invita a scoprire, testare e distribuire modelli AI. Sotto “Popular Models” sono mostrati sei modelli: DeepSeek-R1 (hosted su GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) e DeepSeek-R1 (hosted su Ollama). Ogni scheda include opzioni per “Add” o “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.it.png)

1. Apri l’estensione **AI Toolkit** dalla **Activity Bar**.
1. Nella sezione **Catalog**, seleziona **Models** per aprire il **Model Catalog**. Selezionando **Models** si apre il **Model Catalog** in una nuova scheda dell’editor.
1. Nella barra di ricerca del **Model Catalog**, inserisci **OpenAI GPT-4o**.
1. Clicca su **+ Add** per aggiungere il modello alla tua lista **My Models**. Assicurati di aver selezionato il modello **Hosted by GitHub**.
1. Nella **Activity Bar**, verifica che il modello **OpenAI GPT-4o** compaia nella lista.

### -1- Creare un agente

L’**Agent (Prompt) Builder** ti permette di creare e personalizzare i tuoi agenti AI. In questa sezione creerai un nuovo agente e assegnerai un modello per alimentare la conversazione.

![Screenshot dell’interfaccia "Calculator Agent" nell’estensione AI Toolkit per Visual Studio Code. Nel pannello sinistro, il modello selezionato è "OpenAI GPT-4o (via GitHub)." Un system prompt dice "You are a professor in university teaching math," e il prompt utente è "Explain to me the Fourier equation in simple terms." Opzioni aggiuntive includono pulsanti per aggiungere strumenti, abilitare MCP Server e selezionare output strutturato. In basso un pulsante blu “Run.” Nel pannello destro, sotto "Get Started with Examples," sono elencati tre agenti di esempio: Web Developer (con MCP Server), Second-Grade Simplifier e Dream Interpreter, ciascuno con brevi descrizioni.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.it.png)

1. Apri l’estensione **AI Toolkit** dalla **Activity Bar**.
1. Nella sezione **Tools**, seleziona **Agent (Prompt) Builder**. Si aprirà una nuova scheda dell’editor.
1. Clicca il pulsante **+ New Agent**. L’estensione avvierà una procedura guidata tramite la **Command Palette**.
1. Inserisci il nome **Calculator Agent** e premi **Enter**.
1. Nell’**Agent (Prompt) Builder**, per il campo **Model**, seleziona il modello **OpenAI GPT-4o (via GitHub)**.

### -2- Creare un system prompt per l’agente

Con l’agente impostato, è il momento di definire la sua personalità e scopo. In questa sezione userai la funzione **Generate system prompt** per descrivere il comportamento previsto dell’agente—in questo caso un agente calcolatrice—e lasciare che il modello generi il system prompt per te.

![Screenshot dell’interfaccia "Calculator Agent" nell’AI Toolkit con una finestra modale aperta intitolata "Generate a prompt." La modale spiega che si può generare un template di prompt condividendo informazioni di base e include una casella di testo con un prompt di esempio: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Sotto la casella ci sono i pulsanti "Close" e "Generate." Sullo sfondo si vede parte della configurazione dell’agente, incluso il modello selezionato "OpenAI GPT-4o (via GitHub)" e i campi per system e user prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.it.png)

1. Nella sezione **Prompts**, clicca il pulsante **Generate system prompt**. Si aprirà il prompt builder che utilizza l’AI per generare un system prompt per l’agente.
1. Nella finestra **Generate a prompt**, inserisci il seguente testo: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Clicca il pulsante **Generate**. Apparirà una notifica in basso a destra che conferma l’avvio della generazione del prompt. Al termine, il prompt apparirà nel campo **System prompt** dell’**Agent (Prompt) Builder**.
1. Rivedi il **System prompt** e modificalo se necessario.

### -3- Creare un server MCP

Ora che hai definito il system prompt dell’agente—che guida il suo comportamento e le risposte—è il momento di dotare l’agente di capacità pratiche. In questa sezione creerai un server MCP calcolatrice con strumenti per eseguire addizione, sottrazione, moltiplicazione e divisione. Questo server permetterà al tuo agente di eseguire operazioni matematiche in tempo reale in risposta a prompt in linguaggio naturale.

!["Screenshot della sezione inferiore dell’interfaccia Calculator Agent nell’estensione AI Toolkit per Visual Studio Code. Mostra menu espandibili per “Tools” e “Structure output,” con un menu a tendina “Choose output format” impostato su “text.” A destra, c’è un pulsante “+ MCP Server” per aggiungere un server Model Context Protocol. Sopra la sezione Tools c’è un’icona segnaposto immagine.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.it.png)

AI Toolkit offre template per facilitare la creazione del proprio server MCP. Useremo il template Python per creare il server MCP calcolatrice.

*Nota*: AI Toolkit supporta attualmente Python e TypeScript.

1. Nella sezione **Tools** dell’**Agent (Prompt) Builder**, clicca il pulsante **+ MCP Server**. Si avvierà una procedura guidata tramite la **Command Palette**.
1. Seleziona **+ Add Server**.
1. Seleziona **Create a New MCP Server**.
1. Seleziona il template **python-weather**.
1. Seleziona **Default folder** per salvare il template del server MCP.
1. Inserisci il nome del server: **Calculator**
1. Si aprirà una nuova finestra di Visual Studio Code. Seleziona **Yes, I trust the authors**.
1. Nel terminale (**Terminal** > **New Terminal**), crea un ambiente virtuale: `python -m venv .venv`
1. Nel terminale, attiva l’ambiente virtuale:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Nel terminale, installa le dipendenze: `pip install -e .[dev]`
1. Nella vista **Explorer** della **Activity Bar**, espandi la cartella **src** e seleziona **server.py** per aprire il file nell’editor.
1. Sostituisci il codice nel file **server.py** con il seguente e salva:

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

### -4- Eseguire l’agente con il server MCP calcolatrice

Ora che il tuo agente ha gli strumenti, è il momento di usarli! In questa sezione invierai prompt all’agente per testare e verificare se sfrutta lo strumento corretto dal server MCP calcolatrice.

![Screenshot dell’interfaccia Calculator Agent nell’estensione AI Toolkit per Visual Studio Code. Nel pannello sinistro, sotto “Tools,” è aggiunto un MCP server chiamato local-server-calculator_server, che mostra quattro strumenti disponibili: add, subtract, multiply e divide. Un badge indica che quattro strumenti sono attivi. Sotto c’è una sezione “Structure output” chiusa e un pulsante blu “Run.” Nel pannello destro, sotto “Model Response,” l’agente invoca gli strumenti multiply e subtract con input {"a": 3, "b": 25} e {"a": 75, "b": 20} rispettivamente. La “Tool Response” finale è 75.0. In basso compare un pulsante “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.it.png)

Eseguirai il server MCP calcolatrice sulla tua macchina locale come client MCP tramite l’**Agent Builder**.

1. Premi `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Ho comprato 3 articoli al prezzo di 25$ ciascuno, e poi ho usato uno sconto di 20$. Quanto ho pagato?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` i valori sono assegnati per lo strumento **subtract**.
    - La risposta di ogni strumento viene mostrata nella rispettiva **Tool Response**.
    - L’output finale del modello è mostrato nella **Model Response** finale.
1. Invia prompt aggiuntivi per testare ulteriormente l’agente. Puoi modificare il prompt esistente nel campo **User prompt** cliccando sul campo e sostituendo il testo.
1. Quando hai finito di testare l’agente, puoi fermare il server dal **terminal** premendo **CTRL/CMD+C** per uscire.

## Compito

Prova ad aggiungere una voce strumento aggiuntiva nel tuo file **server.py** (es: calcolare la radice quadrata di un numero). Invia prompt che richiedano all’agente di utilizzare il nuovo strumento (o quelli esistenti). Ricordati di riavviare il server per caricare gli strumenti appena aggiunti.

## Soluzione

[Solution](./solution/README.md)

## Punti chiave

I punti chiave di questo capitolo sono:

- L’estensione AI Toolkit è un ottimo client che ti permette di consumare server MCP e i loro strumenti.
- Puoi aggiungere nuovi strumenti ai server MCP, ampliando le capacità dell’agente per soddisfare esigenze in evoluzione.
- AI Toolkit include template (es. template Python per server MCP) per semplificare la creazione di strumenti personalizzati.

## Risorse aggiuntive

- [Documentazione AI Toolkit](https://aka.ms/AIToolkit/doc)

## Cosa c’è dopo
- Prossimo: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall’uso di questa traduzione.