<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:36:34+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "it"
}
-->
# Utilizzare un server dall’estensione AI Toolkit per Visual Studio Code

Quando crei un agente AI, non si tratta solo di generare risposte intelligenti; è anche importante dare al tuo agente la capacità di agire. Ed è qui che entra in gioco il Model Context Protocol (MCP). MCP facilita l’accesso degli agenti a strumenti e servizi esterni in modo uniforme. Pensalo come se collegassi il tuo agente a una cassetta degli attrezzi che può *davvero* usare.

Supponiamo di collegare un agente al tuo server MCP calcolatrice. Improvvisamente, il tuo agente può eseguire operazioni matematiche semplicemente ricevendo un prompt come “Quanto fa 47 per 89?”—senza bisogno di codificare la logica o creare API personalizzate.

## Panoramica

Questa lezione spiega come collegare un server MCP calcolatrice a un agente con l’estensione [AI Toolkit](https://aka.ms/AIToolkit) in Visual Studio Code, permettendo al tuo agente di eseguire operazioni matematiche come addizione, sottrazione, moltiplicazione e divisione tramite linguaggio naturale.

AI Toolkit è un’estensione potente per Visual Studio Code che semplifica lo sviluppo di agenti. Gli AI Engineer possono costruire facilmente applicazioni AI sviluppando e testando modelli generativi AI—localmente o nel cloud. L’estensione supporta la maggior parte dei modelli generativi principali disponibili oggi.

*Nota*: AI Toolkit supporta attualmente Python e TypeScript.

## Obiettivi di apprendimento

Al termine di questa lezione, sarai in grado di:

- Consumare un server MCP tramite AI Toolkit.
- Configurare una configurazione agente per permettergli di scoprire e utilizzare gli strumenti forniti dal server MCP.
- Utilizzare gli strumenti MCP tramite linguaggio naturale.

## Approccio

Ecco come procedere a grandi linee:

- Creare un agente e definire il suo prompt di sistema.
- Creare un server MCP con strumenti calcolatrice.
- Collegare l’Agent Builder al server MCP.
- Testare l’invocazione degli strumenti dell’agente tramite linguaggio naturale.

Perfetto, ora che abbiamo chiaro il flusso, configuriamo un agente AI per sfruttare strumenti esterni tramite MCP, potenziandone le capacità!

## Prerequisiti

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit per Visual Studio Code](https://aka.ms/AIToolkit)

## Esercizio: Consumare un server

In questo esercizio costruirai, eseguirai e migliorerai un agente AI con strumenti da un server MCP all’interno di Visual Studio Code usando AI Toolkit.

### -0- Passaggio preliminare, aggiungi il modello OpenAI GPT-4o a My Models

L’esercizio utilizza il modello **GPT-4o**. Il modello deve essere aggiunto a **My Models** prima di creare l’agente.

![Screenshot dell’interfaccia di selezione modello nell’estensione AI Toolkit di Visual Studio Code. L’intestazione recita "Find the right model for your AI Solution" con un sottotitolo che invita a scoprire, testare e distribuire modelli AI. Sotto “Popular Models,” sono mostrati sei modelli: DeepSeek-R1 (hosted su GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) e DeepSeek-R1 (hosted su Ollama). Ogni scheda include opzioni “Add” o “Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.it.png)

1. Apri l’estensione **AI Toolkit** dalla **Activity Bar**.
1. Nella sezione **Catalog**, seleziona **Models** per aprire il **Model Catalog**. Selezionare **Models** apre il **Model Catalog** in una nuova scheda dell’editor.
1. Nella barra di ricerca del **Model Catalog**, digita **OpenAI GPT-4o**.
1. Clicca su **+ Add** per aggiungere il modello alla lista **My Models**. Assicurati di selezionare il modello **Hosted by GitHub**.
1. Nella **Activity Bar**, verifica che il modello **OpenAI GPT-4o** compaia nella lista.

### -1- Crea un agente

L’**Agent (Prompt) Builder** ti permette di creare e personalizzare i tuoi agenti AI. In questa sezione, creerai un nuovo agente e assegnerai un modello per alimentare la conversazione.

![Screenshot dell’interfaccia "Calculator Agent" nell’estensione AI Toolkit di Visual Studio Code. Nel pannello sinistro, il modello selezionato è "OpenAI GPT-4o (via GitHub)". Un prompt di sistema dice "You are a professor in university teaching math," e il prompt utente dice "Explain to me the Fourier equation in simple terms." Altre opzioni includono pulsanti per aggiungere strumenti, abilitare MCP Server e selezionare output strutturato. In basso c’è un pulsante blu “Run”. Nel pannello a destra, sotto "Get Started with Examples," sono elencati tre agenti di esempio: Web Developer (con MCP Server), Second-Grade Simplifier e Dream Interpreter, ciascuno con una breve descrizione.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.it.png)

1. Apri l’estensione **AI Toolkit** dalla **Activity Bar**.
1. Nella sezione **Tools**, seleziona **Agent (Prompt) Builder**. Selezionare **Agent (Prompt) Builder** apre l’editor in una nuova scheda.
1. Clicca sul pulsante **+ New Agent**. L’estensione avvierà una procedura guidata tramite la **Command Palette**.
1. Inserisci il nome **Calculator Agent** e premi **Enter**.
1. Nell’**Agent (Prompt) Builder**, nel campo **Model**, seleziona il modello **OpenAI GPT-4o (via GitHub)**.

### -2- Crea un prompt di sistema per l’agente

Ora che l’agente è stato creato, è il momento di definire la sua personalità e scopo. In questa sezione, userai la funzione **Generate system prompt** per descrivere il comportamento previsto dell’agente—in questo caso un agente calcolatrice—e lasciare che il modello scriva il prompt di sistema per te.

![Screenshot dell’interfaccia "Calculator Agent" in AI Toolkit per Visual Studio Code con una finestra modale aperta intitolata "Generate a prompt." La modale spiega che un template di prompt può essere generato fornendo dettagli di base e include una casella di testo con il prompt di sistema di esempio: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Sotto la casella ci sono i pulsanti "Close" e "Generate". Sullo sfondo si vede parte della configurazione dell’agente, incluso il modello selezionato "OpenAI GPT-4o (via GitHub)" e i campi per prompt di sistema e utente.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.it.png)

1. Nella sezione **Prompts**, clicca il pulsante **Generate system prompt**. Questo apre il prompt builder che sfrutta l’AI per generare un prompt di sistema per l’agente.
1. Nella finestra **Generate a prompt**, inserisci il testo: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Clicca il pulsante **Generate**. In basso a destra comparirà una notifica che conferma l’avvio della generazione del prompt. Una volta completata, il prompt apparirà nel campo **System prompt** dell’**Agent (Prompt) Builder**.
1. Rivedi il **System prompt** e modifica se necessario.

### -3- Crea un server MCP

Ora che hai definito il prompt di sistema dell’agente—che guida il suo comportamento e le risposte—è il momento di dotare l’agente di capacità pratiche. In questa sezione, creerai un server MCP calcolatrice con strumenti per eseguire addizione, sottrazione, moltiplicazione e divisione. Questo server permetterà al tuo agente di eseguire operazioni matematiche in tempo reale in risposta a prompt in linguaggio naturale.

![Screenshot della parte inferiore dell’interfaccia Calculator Agent nell’estensione AI Toolkit per Visual Studio Code. Mostra menu espandibili per “Tools” e “Structure output,” insieme a un menu a tendina “Choose output format” impostato su “text.” A destra c’è un pulsante “+ MCP Server” per aggiungere un Model Context Protocol server. Sopra la sezione Tools c’è un segnaposto icona immagine.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.it.png)

AI Toolkit è dotato di template per facilitare la creazione del proprio server MCP. Useremo il template Python per creare il server MCP calcolatrice.

*Nota*: AI Toolkit supporta attualmente Python e TypeScript.

1. Nella sezione **Tools** dell’**Agent (Prompt) Builder**, clicca il pulsante **+ MCP Server**. L’estensione avvierà una procedura guidata tramite la **Command Palette**.
1. Seleziona **+ Add Server**.
1. Seleziona **Create a New MCP Server**.
1. Seleziona **python-weather** come template.
1. Seleziona **Default folder** per salvare il template del server MCP.
1. Inserisci questo nome per il server: **Calculator**
1. Si aprirà una nuova finestra di Visual Studio Code. Seleziona **Yes, I trust the authors**.
1. Nel terminale (**Terminal** > **New Terminal**), crea un ambiente virtuale: `python -m venv .venv`
1. Nel terminale, attiva l’ambiente virtuale:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Nel terminale, installa le dipendenze: `pip install -e .[dev]`
1. Nella vista **Explorer** della **Activity Bar**, espandi la directory **src** e apri il file **server.py** nell’editor.
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

### -4- Esegui l’agente con il server MCP calcolatrice

Ora che il tuo agente ha gli strumenti, è il momento di usarli! In questa sezione invierai prompt all’agente per testare e verificare che utilizzi lo strumento appropriato dal server MCP calcolatrice.

![Screenshot dell’interfaccia Calculator Agent nell’estensione AI Toolkit per Visual Studio Code. Nel pannello sinistro, sotto “Tools,” è aggiunto un MCP server chiamato local-server-calculator_server, che mostra quattro strumenti disponibili: add, subtract, multiply e divide. Un badge indica che quattro strumenti sono attivi. Sotto c’è la sezione “Structure output” chiusa e un pulsante blu “Run.” Nel pannello a destra, sotto “Model Response,” l’agente invoca gli strumenti multiply e subtract con input {"a": 3, "b": 25} e {"a": 75, "b": 20} rispettivamente. La “Tool Response” finale è mostrata come 75.0. In basso appare un pulsante “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.it.png)

Eseguirai il server MCP calcolatrice sulla tua macchina di sviluppo locale tramite l’**Agent Builder** come client MCP.

1. Premi `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` i valori sono assegnati allo strumento **subtract**.
    - La risposta di ciascuno strumento viene fornita nella rispettiva **Tool Response**.
    - L’output finale del modello è mostrato nella risposta finale **Model Response**.
1. Invia ulteriori prompt per testare l’agente. Puoi modificare il prompt esistente nel campo **User prompt** cliccandoci e sostituendo il testo.
1. Quando hai finito di testare l’agente, puoi fermare il server dal **terminal** premendo **CTRL/CMD+C** per uscire.

## Compito

Prova ad aggiungere una voce di strumento aggiuntiva nel file **server.py** (es: restituisci la radice quadrata di un numero). Invia prompt che richiedano all’agente di usare il tuo nuovo strumento (o quelli esistenti). Ricordati di riavviare il server per caricare gli strumenti appena aggiunti.

## Soluzione

[Solution](./solution/README.md)

## Punti chiave

I punti chiave di questo capitolo sono:

- L’estensione AI Toolkit è un ottimo client che ti permette di consumare server MCP e i loro strumenti.
- Puoi aggiungere nuovi strumenti ai server MCP, ampliando le capacità dell’agente per rispondere a esigenze in evoluzione.
- AI Toolkit include template (ad esempio template Python per server MCP) per semplificare la creazione di strumenti personalizzati.

## Risorse aggiuntive

- [Documentazione AI Toolkit](https://aka.ms/AIToolkit/doc)

## Cosa c’è dopo

Successivo: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua madre deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.