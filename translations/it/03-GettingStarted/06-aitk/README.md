<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:21:18+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "it"
}
-->
# Consumo di un server dall'estensione AI Toolkit per Visual Studio Code

Quando costruisci un agente AI, non si tratta solo di generare risposte intelligenti; si tratta anche di dare al tuo agente la capacità di agire. È qui che entra in gioco il Model Context Protocol (MCP). MCP rende facile per gli agenti accedere a strumenti e servizi esterni in modo coerente. Pensalo come collegare il tuo agente a una cassetta degli attrezzi che può *effettivamente* utilizzare.

Supponiamo che tu connetta un agente al tuo server MCP calcolatrice. Improvvisamente, il tuo agente può eseguire operazioni matematiche semplicemente ricevendo un prompt come "Quanto fa 47 per 89?"—senza bisogno di codificare logicamente o costruire API personalizzate.

## Panoramica

Questa lezione copre come connettere un server MCP calcolatrice a un agente con l'estensione [AI Toolkit](https://aka.ms/AIToolkit) in Visual Studio Code, permettendo al tuo agente di eseguire operazioni matematiche come addizione, sottrazione, moltiplicazione e divisione attraverso il linguaggio naturale.

AI Toolkit è un'estensione potente per Visual Studio Code che semplifica lo sviluppo degli agenti. Gli ingegneri AI possono facilmente costruire applicazioni AI sviluppando e testando modelli AI generativi—localmente o nel cloud. L'estensione supporta la maggior parte dei modelli generativi principali disponibili oggi.

*Nota*: AI Toolkit attualmente supporta Python e TypeScript.

## Obiettivi di Apprendimento

Alla fine di questa lezione, sarai in grado di:

- Consumare un server MCP tramite AI Toolkit.
- Configurare una configurazione dell'agente per permettergli di scoprire e utilizzare gli strumenti forniti dal server MCP.
- Utilizzare strumenti MCP tramite il linguaggio naturale.

## Approccio

Ecco come dobbiamo affrontare questo a livello generale:

- Creare un agente e definire il suo prompt di sistema.
- Creare un server MCP con strumenti calcolatrice.
- Collegare l'Agent Builder al server MCP.
- Testare l'invocazione degli strumenti dell'agente tramite il linguaggio naturale.

Ottimo, ora che abbiamo capito il flusso, configuriamo un agente AI per sfruttare strumenti esterni tramite MCP, migliorando le sue capacità!

## Prerequisiti

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit per Visual Studio Code](https://aka.ms/AIToolkit)

## Esercizio: Consumo di un server

In questo esercizio, costruirai, eseguirai e migliorerai un agente AI con strumenti da un server MCP all'interno di Visual Studio Code usando AI Toolkit.

### -0- Prestep, aggiungi il modello OpenAI GPT-4o ai Miei Modelli

L'esercizio sfrutta il modello **GPT-4o**. Il modello dovrebbe essere aggiunto ai **Miei Modelli** prima di creare l'agente.

1. Apri l'estensione **AI Toolkit** dalla **Activity Bar**.
1. Nella sezione **Catalog**, seleziona **Models** per aprire il **Catalogo Modelli**. Selezionando **Models** si apre il **Catalogo Modelli** in una nuova scheda dell'editor.
1. Nella barra di ricerca del **Catalogo Modelli**, inserisci **OpenAI GPT-4o**.
1. Clicca su **+ Add** per aggiungere il modello alla tua lista **My Models**. Assicurati di aver selezionato il modello che è **Hosted by GitHub**.
1. Nella **Activity Bar**, conferma che il modello **OpenAI GPT-4o** appare nella lista.

### -1- Crea un agente

Il **Agent (Prompt) Builder** ti permette di creare e personalizzare i tuoi agenti alimentati da AI. In questa sezione, creerai un nuovo agente e assegnerai un modello per alimentare la conversazione.

1. Apri l'estensione **AI Toolkit** dalla **Activity Bar**.
1. Nella sezione **Tools**, seleziona **Agent (Prompt) Builder**. Selezionando **Agent (Prompt) Builder** si apre il **Agent (Prompt) Builder** in una nuova scheda dell'editor.
1. Clicca il pulsante **+ New Builder**. L'estensione avvierà una procedura guidata di configurazione tramite il **Command Palette**.
1. Inserisci il nome **Calculator Agent** e premi **Enter**.
1. Nel **Agent (Prompt) Builder**, per il campo **Model**, seleziona il modello **OpenAI GPT-4o (via GitHub)**.

### -2- Crea un prompt di sistema per l'agente

Con l'agente strutturato, è il momento di definire la sua personalità e il suo scopo. In questa sezione, utilizzerai la funzione **Generate system prompt** per descrivere il comportamento previsto dell'agente—in questo caso, un agente calcolatrice—e far sì che il modello scriva il prompt di sistema per te.

1. Per la sezione **Prompts**, clicca sul pulsante **Generate system prompt**. Questo pulsante si apre nel prompt builder che sfrutta l'AI per generare un prompt di sistema per l'agente.
1. Nella finestra **Generate a prompt**, inserisci il seguente: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Clicca sul pulsante **Generate**. Apparirà una notifica nell'angolo in basso a destra che conferma che il prompt di sistema viene generato. Una volta completata la generazione del prompt, il prompt apparirà nel campo **System prompt** del **Agent (Prompt) Builder**.
1. Rivedi il **System prompt** e modificalo se necessario.

### -3- Crea un server MCP

Ora che hai definito il prompt di sistema del tuo agente—guidando il suo comportamento e le sue risposte—è il momento di dotare l'agente di capacità pratiche. In questa sezione, creerai un server MCP calcolatrice con strumenti per eseguire calcoli di addizione, sottrazione, moltiplicazione e divisione. Questo server permetterà al tuo agente di eseguire operazioni matematiche in tempo reale in risposta a prompt di linguaggio naturale.

AI Toolkit è dotato di modelli per facilitare la creazione del tuo server MCP. Utilizzeremo il modello Python per creare il server MCP calcolatrice.

*Nota*: AI Toolkit attualmente supporta Python e TypeScript.

1. Nella sezione **Tools** del **Agent (Prompt) Builder**, clicca sul pulsante **+ MCP Server**. L'estensione avvierà una procedura guidata di configurazione tramite il **Command Palette**.
1. Seleziona **+ Add Server**.
1. Seleziona **Create a New MCP Server**.
1. Seleziona **python-weather** come modello.
1. Seleziona **Default folder** per salvare il modello del server MCP.
1. Inserisci il seguente nome per il server: **Calculator**
1. Si aprirà una nuova finestra di Visual Studio Code. Seleziona **Yes, I trust the authors**.
1. Usando il terminale (**Terminal** > **New Terminal**), crea un ambiente virtuale: `python -m venv .venv`
1. Usando il terminale, attiva l'ambiente virtuale:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Usando il terminale, installa le dipendenze: `pip install -e .[dev]`
1. Nella vista **Explorer** della **Activity Bar**, espandi la directory **src** e seleziona **server.py** per aprire il file nell'editor.
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

### -4- Esegui l'agente con il server MCP calcolatrice

Ora che il tuo agente ha strumenti, è il momento di usarli! In questa sezione, invierai prompt all'agente per testare e validare se l'agente sfrutta lo strumento appropriato dal server MCP calcolatrice.

Eseguirai il server MCP calcolatrice sulla tua macchina di sviluppo locale tramite l'**Agent Builder** come client MCP.

1. Premi `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Ho comprato 3 articoli al prezzo di $25 ciascuno, e poi ho utilizzato uno sconto di $20. Quanto ho pagato?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` i valori sono assegnati per lo strumento **subtract**.
    - La risposta da ciascun strumento è fornita nella rispettiva **Tool Response**.
    - L'output finale dal modello è fornito nella risposta finale **Model Response**.
1. Invia ulteriori prompt per testare ulteriormente l'agente. Puoi modificare il prompt esistente nel campo **User prompt** cliccando nel campo e sostituendo il prompt esistente.
1. Una volta terminato il test dell'agente, puoi fermare il server tramite il **terminal** inserendo **CTRL/CMD+C** per uscire.

## Compito

Prova ad aggiungere una voce di strumento aggiuntiva al tuo file **server.py** (es: restituisci la radice quadrata di un numero). Invia ulteriori prompt che richiederebbero all'agente di sfruttare il tuo nuovo strumento (o strumenti esistenti). Assicurati di riavviare il server per caricare gli strumenti appena aggiunti.

## Soluzione

[Soluzione](./solution/README.md)

## Punti Chiave

I punti chiave di questo capitolo sono i seguenti:

- L'estensione AI Toolkit è un ottimo client che ti permette di consumare server MCP e i loro strumenti.
- Puoi aggiungere nuovi strumenti ai server MCP, espandendo le capacità dell'agente per soddisfare requisiti in evoluzione.
- AI Toolkit include modelli (ad esempio, modelli di server MCP Python) per semplificare la creazione di strumenti personalizzati.

## Risorse Aggiuntive

- [Documentazione AI Toolkit](https://aka.ms/AIToolkit/doc)

## Cosa c'è Dopo

Prossimo: [Lezione 4 Implementazione Pratica](/04-PracticalImplementation/README.md)

**Disclaimer**:
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.