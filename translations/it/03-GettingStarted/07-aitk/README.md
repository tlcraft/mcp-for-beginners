<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:32:51+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "it"
}
-->
# Consumare un server dall’estensione AI Toolkit per Visual Studio Code

Quando crei un agente AI, non si tratta solo di generare risposte intelligenti; è anche importante dare al tuo agente la capacità di agire. È qui che entra in gioco il Model Context Protocol (MCP). MCP rende semplice per gli agenti accedere a strumenti e servizi esterni in modo coerente. Pensalo come collegare il tuo agente a una cassetta degli attrezzi che può *davvero* usare.

Immagina di collegare un agente al tuo server MCP calcolatrice. Improvvisamente, il tuo agente può eseguire operazioni matematiche semplicemente ricevendo un prompt come “Quanto fa 47 per 89?”—senza bisogno di codificare la logica o costruire API personalizzate.

## Panoramica

Questa lezione spiega come collegare un server MCP calcolatrice a un agente con l’estensione [AI Toolkit](https://aka.ms/AIToolkit) in Visual Studio Code, permettendo al tuo agente di eseguire operazioni matematiche come addizione, sottrazione, moltiplicazione e divisione tramite linguaggio naturale.

AI Toolkit è un’estensione potente per Visual Studio Code che semplifica lo sviluppo di agenti. Gli AI Engineer possono facilmente costruire applicazioni AI sviluppando e testando modelli generativi AI—localmente o nel cloud. L’estensione supporta la maggior parte dei modelli generativi più diffusi oggi.

*Nota*: AI Toolkit supporta attualmente Python e TypeScript.

## Obiettivi di apprendimento

Al termine di questa lezione, sarai in grado di:

- Consumare un server MCP tramite AI Toolkit.
- Configurare un agente per permettergli di scoprire e utilizzare gli strumenti forniti dal server MCP.
- Utilizzare gli strumenti MCP tramite linguaggio naturale.

## Approccio

Ecco come procedere ad alto livello:

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

### -0- Passo preliminare, aggiungi il modello OpenAI GPT-4o a My Models

L’esercizio utilizza il modello **GPT-4o**. Il modello deve essere aggiunto a **My Models** prima di creare l’agente.

![Screenshot dell’interfaccia di selezione modello nell’estensione AI Toolkit di Visual Studio Code. L’intestazione recita "Find the right model for your AI Solution" con un sottotitolo che invita a scoprire, testare e distribuire modelli AI. Sotto, nella sezione “Popular Models,” sono mostrati sei modelli: DeepSeek-R1 (hosted su GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), e DeepSeek-R1 (hosted su Ollama). Ogni scheda include opzioni per “Add” o “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.it.png)

1. Apri l’estensione **AI Toolkit** dalla **Activity Bar**.
2. Nella sezione **Catalog**, seleziona **Models** per aprire il **Model Catalog**. Selezionare **Models** apre il **Model Catalog** in una nuova scheda dell’editor.
3. Nella barra di ricerca del **Model Catalog**, digita **OpenAI GPT-4o**.
4. Clicca su **+ Add** per aggiungere il modello alla lista **My Models**. Assicurati di aver selezionato il modello **Hosted by GitHub**.
5. Nella **Activity Bar**, verifica che il modello **OpenAI GPT-4o** appaia nella lista.

### -1- Crea un agente

L’**Agent (Prompt) Builder** ti permette di creare e personalizzare i tuoi agenti AI. In questa sezione creerai un nuovo agente e assegnerai un modello per alimentare la conversazione.

![Screenshot dell’interfaccia "Calculator Agent" nell’estensione AI Toolkit per Visual Studio Code. Nel pannello a sinistra, il modello selezionato è "OpenAI GPT-4o (via GitHub)." Un prompt di sistema recita "You are a professor in university teaching math," e il prompt utente dice "Explain to me the Fourier equation in simple terms." Opzioni aggiuntive includono pulsanti per aggiungere strumenti, abilitare MCP Server e selezionare output strutturato. In basso un pulsante blu “Run.” Nel pannello a destra, sotto "Get Started with Examples," sono elencati tre agenti di esempio: Web Developer (con MCP Server, Second-Grade Simplifier e Dream Interpreter, ciascuno con brevi descrizioni delle loro funzioni).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.it.png)

1. Apri l’estensione **AI Toolkit** dalla **Activity Bar**.
2. Nella sezione **Tools**, seleziona **Agent (Prompt) Builder**. Selezionare **Agent (Prompt) Builder** apre l’editor in una nuova scheda.
3. Clicca sul pulsante **+ New Agent**. L’estensione avvierà una procedura guidata tramite la **Command Palette**.
4. Inserisci il nome **Calculator Agent** e premi **Enter**.
5. Nell’**Agent (Prompt) Builder**, per il campo **Model**, seleziona il modello **OpenAI GPT-4o (via GitHub)**.

### -2- Crea un prompt di sistema per l’agente

Con l’agente impostato, è il momento di definire la sua personalità e scopo. In questa sezione userai la funzione **Generate system prompt** per descrivere il comportamento previsto dell’agente—in questo caso, un agente calcolatrice—e far scrivere il prompt di sistema al modello.

![Screenshot dell’interfaccia "Calculator Agent" nell’AI Toolkit per Visual Studio Code con una finestra modale aperta intitolata "Generate a prompt." La modale spiega che un template di prompt può essere generato fornendo dettagli di base e include una casella di testo con il prompt di sistema di esempio: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Sotto la casella ci sono i pulsanti "Close" e "Generate." Sullo sfondo, parte della configurazione dell’agente è visibile, incluso il modello selezionato "OpenAI GPT-4o (via GitHub)" e i campi per prompt di sistema e utente.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.it.png)

1. Nella sezione **Prompts**, clicca sul pulsante **Generate system prompt**. Questo apre il prompt builder che usa l’AI per generare un prompt di sistema per l’agente.
2. Nella finestra **Generate a prompt**, inserisci il seguente testo: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Clicca sul pulsante **Generate**. Apparirà una notifica in basso a destra che conferma la generazione del prompt di sistema. Al termine, il prompt apparirà nel campo **System prompt** dell’**Agent (Prompt) Builder**.
4. Rivedi il **System prompt** e modificalo se necessario.

### -3- Crea un server MCP

Ora che hai definito il prompt di sistema dell’agente—che guida il suo comportamento e le risposte—è il momento di dotare l’agente di capacità pratiche. In questa sezione creerai un server MCP calcolatrice con strumenti per eseguire addizione, sottrazione, moltiplicazione e divisione. Questo server permetterà al tuo agente di eseguire operazioni matematiche in tempo reale in risposta a prompt in linguaggio naturale.

![Screenshot della sezione inferiore dell’interfaccia Calculator Agent nell’estensione AI Toolkit per Visual Studio Code. Mostra menu espandibili per “Tools” e “Structure output,” insieme a un menu a tendina “Choose output format” impostato su “text.” A destra, un pulsante “+ MCP Server” per aggiungere un server Model Context Protocol. Sopra la sezione Tools è mostrato un segnaposto icona immagine.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.it.png)

AI Toolkit è dotato di template per facilitare la creazione del proprio server MCP. Useremo il template Python per creare il server MCP calcolatrice.

*Nota*: AI Toolkit supporta attualmente Python e TypeScript.

1. Nella sezione **Tools** dell’**Agent (Prompt) Builder**, clicca sul pulsante **+ MCP Server**. L’estensione avvierà una procedura guidata tramite la **Command Palette**.
2. Seleziona **+ Add Server**.
3. Seleziona **Create a New MCP Server**.
4. Seleziona **python-weather** come template.
5. Seleziona **Default folder** per salvare il template del server MCP.
6. Inserisci il nome seguente per il server: **Calculator**
7. Si aprirà una nuova finestra di Visual Studio Code. Seleziona **Yes, I trust the authors**.
8. Usando il terminale (**Terminal** > **New Terminal**), crea un ambiente virtuale: `python -m venv .venv`
9. Attiva l’ambiente virtuale dal terminale:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Installa le dipendenze dal terminale: `pip install -e .[dev]`
11. Nella vista **Explorer** della **Activity Bar**, espandi la directory **src** e seleziona **server.py** per aprire il file nell’editor.
12. Sostituisci il codice nel file **server.py** con il seguente e salva:

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

Ora che il tuo agente ha gli strumenti, è il momento di usarli! In questa sezione invierai prompt all’agente per testare e verificare se l’agente utilizza lo strumento appropriato dal server MCP calcolatrice.

![Screenshot dell’interfaccia Calculator Agent nell’estensione AI Toolkit per Visual Studio Code. Nel pannello a sinistra, sotto “Tools,” è aggiunto un server MCP chiamato local-server-calculator_server, che mostra quattro strumenti disponibili: add, subtract, multiply e divide. Un badge indica che quattro strumenti sono attivi. Sotto c’è una sezione “Structure output” compressa e un pulsante blu “Run.” Nel pannello a destra, sotto “Model Response,” l’agente invoca gli strumenti multiply e subtract con input {"a": 3, "b": 25} e {"a": 75, "b": 20} rispettivamente. La “Tool Response” finale è mostrata come 75.0. In basso appare un pulsante “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.it.png)

Eseguirai il server MCP calcolatrice sulla tua macchina di sviluppo locale tramite l’**Agent Builder** come client MCP.

1. Premi `F5` per avviare il debug del server MCP. L’**Agent (Prompt) Builder** si aprirà in una nuova scheda dell’editor. Lo stato del server è visibile nel terminale.
2. Nel campo **User prompt** dell’**Agent (Prompt) Builder**, inserisci il seguente prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. Clicca sul pulsante **Run** per generare la risposta dell’agente.
4. Rivedi l’output dell’agente. Il modello dovrebbe concludere che hai pagato **$55**.
5. Ecco cosa dovrebbe succedere:
    - L’agente seleziona gli strumenti **multiply** e **subtract** per aiutare nel calcolo.
    - I valori `a` e `b` sono assegnati rispettivamente per lo strumento **multiply**.
    - I valori `a` e `b` sono assegnati rispettivamente per lo strumento **subtract**.
    - La risposta di ogni strumento è fornita nella rispettiva **Tool Response**.
    - L’output finale del modello è fornito nella risposta finale **Model Response**.
6. Invia prompt aggiuntivi per testare ulteriormente l’agente. Puoi modificare il prompt esistente nel campo **User prompt** cliccandoci sopra e sostituendo il testo.
7. Quando hai finito di testare l’agente, puoi fermare il server dal **terminal** premendo **CTRL/CMD+C** per uscire.

## Compito

Prova ad aggiungere una voce di strumento aggiuntiva al tuo file **server.py** (es: restituisci la radice quadrata di un numero). Invia prompt aggiuntivi che richiedano all’agente di usare il tuo nuovo strumento (o strumenti esistenti). Ricordati di riavviare il server per caricare gli strumenti appena aggiunti.

## Soluzione

[Solution](./solution/README.md)

## Punti chiave

I punti chiave di questo capitolo sono:

- L’estensione AI Toolkit è un ottimo client che ti permette di consumare server MCP e i loro strumenti.
- Puoi aggiungere nuovi strumenti ai server MCP, ampliando le capacità dell’agente per soddisfare requisiti in evoluzione.
- AI Toolkit include template (es. template server MCP Python) per semplificare la creazione di strumenti personalizzati.

## Risorse aggiuntive

- [Documentazione AI Toolkit](https://aka.ms/AIToolkit/doc)

## Cosa c’è dopo
- Prossimo: [Testing & Debugging](../08-testing/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.