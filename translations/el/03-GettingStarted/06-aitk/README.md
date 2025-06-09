<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:38:52+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "el"
}
-->
# Κατανάλωση ενός server από την επέκταση AI Toolkit για το Visual Studio Code

Όταν δημιουργείτε έναν AI agent, δεν πρόκειται μόνο για τη δημιουργία έξυπνων απαντήσεων· έχει σημασία και να δώσετε στον agent τη δυνατότητα να αναλαμβάνει δράση. Εδώ έρχεται το Model Context Protocol (MCP). Το MCP διευκολύνει τους agents να έχουν πρόσβαση σε εξωτερικά εργαλεία και υπηρεσίες με έναν συνεπή τρόπο. Σκεφτείτε το σαν να συνδέετε τον agent σας σε ένα κουτί εργαλείων που μπορεί *πραγματικά* να χρησιμοποιήσει.

Ας υποθέσουμε ότι συνδέετε έναν agent στον MCP server του calculator σας. Ξαφνικά, ο agent μπορεί να εκτελεί μαθηματικές πράξεις απλά λαμβάνοντας ένα prompt όπως «Πόσο κάνει το 47 επί 89;»—χωρίς να χρειάζεται να γράψετε χειροκίνητα λογική ή να φτιάξετε προσαρμοσμένα APIs.

## Επισκόπηση

Αυτό το μάθημα καλύπτει πώς να συνδέσετε έναν calculator MCP server σε έναν agent με την επέκταση [AI Toolkit](https://aka.ms/AIToolkit) στο Visual Studio Code, δίνοντας στον agent σας τη δυνατότητα να εκτελεί μαθηματικές πράξεις όπως πρόσθεση, αφαίρεση, πολλαπλασιασμό και διαίρεση μέσω φυσικής γλώσσας.

Το AI Toolkit είναι μια ισχυρή επέκταση για το Visual Studio Code που απλοποιεί την ανάπτυξη agents. Οι AI Engineers μπορούν εύκολα να δημιουργούν AI εφαρμογές αναπτύσσοντας και δοκιμάζοντας γενετικά μοντέλα AI—τοπικά ή στο cloud. Η επέκταση υποστηρίζει τα περισσότερα δημοφιλή γενετικά μοντέλα που υπάρχουν σήμερα.

*Note*: Το AI Toolkit υποστηρίζει προς το παρόν Python και TypeScript.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Καταναλώνετε έναν MCP server μέσω του AI Toolkit.
- Ρυθμίζετε μια agent configuration ώστε να μπορεί να ανακαλύπτει και να χρησιμοποιεί εργαλεία που παρέχει ο MCP server.
- Χρησιμοποιείτε τα εργαλεία MCP μέσω φυσικής γλώσσας.

## Προσέγγιση

Ακολουθεί μια γενική προσέγγιση:

- Δημιουργήστε έναν agent και ορίστε το system prompt του.
- Δημιουργήστε έναν MCP server με εργαλεία calculator.
- Συνδέστε τον Agent Builder με τον MCP server.
- Δοκιμάστε την κλήση εργαλείων του agent μέσω φυσικής γλώσσας.

Τέλεια, τώρα που κατανοούμε τη ροή, ας ρυθμίσουμε έναν AI agent ώστε να αξιοποιεί εξωτερικά εργαλεία μέσω MCP, ενισχύοντας τις δυνατότητές του!

## Απαιτούμενα

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit για Visual Studio Code](https://aka.ms/AIToolkit)

## Άσκηση: Κατανάλωση ενός server

Σε αυτήν την άσκηση, θα δημιουργήσετε, θα εκτελέσετε και θα βελτιώσετε έναν AI agent με εργαλεία από έναν MCP server μέσα στο Visual Studio Code χρησιμοποιώντας το AI Toolkit.

### -0- Προκαταρκτικό βήμα, προσθέστε το μοντέλο OpenAI GPT-4o στα My Models

Η άσκηση χρησιμοποιεί το μοντέλο **GPT-4o**. Το μοντέλο πρέπει να προστεθεί στα **My Models** πριν τη δημιουργία του agent.

![Screenshot of a model selection interface in Visual Studio Code's AI Toolkit extension. The heading reads "Find the right model for your AI Solution" with a subtitle encouraging users to discover, test, and deploy AI models. Below, under “Popular Models,” six model cards are displayed: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), and DeepSeek-R1 (Ollama-hosted). Each card includes options to “Add” the model or “Try in Playground](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.el.png)

1. Ανοίξτε την επέκταση **AI Toolkit** από τη **γραμμή δραστηριοτήτων (Activity Bar)**.
1. Στην ενότητα **Catalog**, επιλέξτε **Models** για να ανοίξετε το **Model Catalog**. Η επιλογή **Models** ανοίγει το **Model Catalog** σε νέα καρτέλα επεξεργασίας.
1. Στη γραμμή αναζήτησης του **Model Catalog**, πληκτρολογήστε **OpenAI GPT-4o**.
1. Πατήστε **+ Add** για να προσθέσετε το μοντέλο στη λίστα **My Models**. Βεβαιωθείτε ότι έχετε επιλέξει το μοντέλο που είναι **Hosted by GitHub**.
1. Στη **γραμμή δραστηριοτήτων**, επιβεβαιώστε ότι το μοντέλο **OpenAI GPT-4o** εμφανίζεται στη λίστα.

### -1- Δημιουργία agent

Ο **Agent (Prompt) Builder** σας επιτρέπει να δημιουργήσετε και να προσαρμόσετε τους δικούς σας AI-powered agents. Σε αυτήν την ενότητα, θα δημιουργήσετε έναν νέο agent και θα του αναθέσετε ένα μοντέλο για να τροφοδοτεί τη συνομιλία.

![Screenshot of the "Calculator Agent" builder interface in the AI Toolkit extension for Visual Studio Code. On the left panel, the model selected is "OpenAI GPT-4o (via GitHub)." A system prompt reads "You are a professor in university teaching math," and the user prompt says, "Explain to me the Fourier equation in simple terms." Additional options include buttons for adding tools, enabling MCP Server, and selecting structured output. A blue “Run” button is at the bottom. On the right panel, under "Get Started with Examples," three sample agents are listed: Web Developer (with MCP Server, Second-Grade Simplifier, and Dream Interpreter, each with brief descriptions of their functions.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.el.png)

1. Ανοίξτε την επέκταση **AI Toolkit** από τη **γραμμή δραστηριοτήτων**.
1. Στην ενότητα **Tools**, επιλέξτε **Agent (Prompt) Builder**. Η επιλογή ανοίγει τον **Agent (Prompt) Builder** σε νέα καρτέλα.
1. Πατήστε το κουμπί **+ New Agent**. Η επέκταση θα ξεκινήσει έναν οδηγό ρύθμισης μέσω της **Command Palette**.
1. Πληκτρολογήστε το όνομα **Calculator Agent** και πατήστε **Enter**.
1. Στον **Agent (Prompt) Builder**, στο πεδίο **Model**, επιλέξτε το μοντέλο **OpenAI GPT-4o (via GitHub)**.

### -2- Δημιουργία system prompt για τον agent

Με τον agent έτοιμο, ήρθε η ώρα να ορίσετε την προσωπικότητα και το σκοπό του. Σε αυτήν την ενότητα, θα χρησιμοποιήσετε τη λειτουργία **Generate system prompt** για να περιγράψετε τη συμπεριφορά που θέλετε—σε αυτή την περίπτωση, έναν calculator agent—και το μοντέλο θα γράψει το system prompt για εσάς.

![Screenshot of the "Calculator Agent" interface in the AI Toolkit for Visual Studio Code with a modal window open titled "Generate a prompt." The modal explains that a prompt template can be generated by sharing basic details and includes a text box with the sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Below the text box are "Close" and "Generate" buttons. In the background, part of the agent configuration is visible, including the selected model "OpenAI GPT-4o (via GitHub)" and fields for system and user prompts.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.el.png)

1. Στην ενότητα **Prompts**, πατήστε το κουμπί **Generate system prompt**. Αυτό ανοίγει τον prompt builder που χρησιμοποιεί AI για να δημιουργήσει το system prompt του agent.
1. Στο παράθυρο **Generate a prompt**, εισάγετε το εξής: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Πατήστε το κουμπί **Generate**. Θα εμφανιστεί ειδοποίηση κάτω δεξιά που επιβεβαιώνει ότι το system prompt δημιουργείται. Μόλις ολοκληρωθεί, το prompt θα εμφανιστεί στο πεδίο **System prompt** του **Agent (Prompt) Builder**.
1. Ελέγξτε το **System prompt** και τροποποιήστε το αν χρειάζεται.

### -3- Δημιουργία MCP server

Τώρα που έχετε ορίσει το system prompt του agent—που καθοδηγεί τη συμπεριφορά και τις απαντήσεις του—ήρθε η ώρα να τον εξοπλίσετε με πρακτικές δυνατότητες. Σε αυτή την ενότητα, θα δημιουργήσετε έναν calculator MCP server με εργαλεία για πρόσθεση, αφαίρεση, πολλαπλασιασμό και διαίρεση. Αυτός ο server θα επιτρέψει στον agent να εκτελεί μαθηματικούς υπολογισμούς σε πραγματικό χρόνο ως απάντηση σε φυσικά prompts.

!["Screenshot of the lower section of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. It shows expandable menus for “Tools” and “Structure output,” along with a dropdown menu labeled “Choose output format” set to “text.” To the right, there is a button labeled “+ MCP Server” for adding a Model Context Protocol server. An image icon placeholder is shown above the Tools section.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.el.png)

Το AI Toolkit διαθέτει πρότυπα για να διευκολύνει τη δημιουργία MCP servers. Θα χρησιμοποιήσουμε το Python template για να δημιουργήσουμε τον calculator MCP server.

*Note*: Το AI Toolkit υποστηρίζει προς το παρόν Python και TypeScript.

1. Στην ενότητα **Tools** του **Agent (Prompt) Builder**, πατήστε το κουμπί **+ MCP Server**. Η επέκταση θα ξεκινήσει έναν οδηγό ρύθμισης μέσω της **Command Palette**.
1. Επιλέξτε **+ Add Server**.
1. Επιλέξτε **Create a New MCP Server**.
1. Επιλέξτε το πρότυπο **python-weather**.
1. Επιλέξτε **Default folder** για να αποθηκευτεί το πρότυπο MCP server.
1. Πληκτρολογήστε το όνομα **Calculator** για τον server.
1. Θα ανοίξει ένα νέο παράθυρο Visual Studio Code. Επιλέξτε **Yes, I trust the authors**.
1. Χρησιμοποιώντας το τερματικό (**Terminal** > **New Terminal**), δημιουργήστε ένα virtual environment: `python -m venv .venv`
1. Στο τερματικό, ενεργοποιήστε το virtual environment:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Στο τερματικό, εγκαταστήστε τις εξαρτήσεις: `pip install -e .[dev]`
1. Στην προβολή **Explorer** της **γραμμής δραστηριοτήτων**, επεκτείνετε τον φάκελο **src** και ανοίξτε το αρχείο **server.py**.
1. Αντικαταστήστε τον κώδικα στο αρχείο **server.py** με τον ακόλουθο και αποθηκεύστε:

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

### -4- Εκτέλεση του agent με τον calculator MCP server

Τώρα που ο agent σας έχει εργαλεία, ήρθε η ώρα να τα χρησιμοποιήσετε! Σε αυτή την ενότητα, θα στείλετε prompts στον agent για να δοκιμάσετε και να επαληθεύσετε αν ο agent αξιοποιεί το κατάλληλο εργαλείο από τον calculator MCP server.

![Screenshot of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. On the left panel, under “Tools,” an MCP server named local-server-calculator_server is added, showing four available tools: add, subtract, multiply, and divide. A badge shows that four tools are active. Below is a collapsed “Structure output” section and a blue “Run” button. On the right panel, under “Model Response,” the agent invokes the multiply and subtract tools with inputs {"a": 3, "b": 25} and {"a": 75, "b": 20} respectively. The final “Tool Response” is shown as 75.0. A “View Code” button appears at the bottom.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.el.png)

Θα εκτελέσετε τον calculator MCP server τοπικά στον υπολογιστή ανάπτυξης μέσω του **Agent Builder** ως MCP client.

1. Πατήστε `F5`` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` τιμές ανατίθενται στο εργαλείο **subtract**.
    - Η απόκριση από κάθε εργαλείο εμφανίζεται στο αντίστοιχο **Tool Response**.
    - Το τελικό αποτέλεσμα από το μοντέλο εμφανίζεται στο τελικό **Model Response**.
1. Στείλτε επιπλέον prompts για να δοκιμάσετε περαιτέρω τον agent. Μπορείτε να τροποποιήσετε το υπάρχον prompt στο πεδίο **User prompt** κάνοντας κλικ μέσα και αντικαθιστώντας το.
1. Όταν τελειώσετε τις δοκιμές, μπορείτε να σταματήσετε τον server από το **τερματικό** πατώντας **CTRL/CMD+C**.

## Ανάθεση

Δοκιμάστε να προσθέσετε μια επιπλέον είσοδο εργαλείου στο αρχείο **server.py** (π.χ. να επιστρέφει την τετραγωνική ρίζα ενός αριθμού). Στείλτε επιπλέον prompts που θα απαιτούν από τον agent να χρησιμοποιήσει το νέο εργαλείο (ή τα υπάρχοντα). Φροντίστε να επανεκκινήσετε τον server για να φορτωθούν τα νέα εργαλεία.

## Λύση

[Solution](./solution/README.md)

## Κύρια Συμπεράσματα

Τα βασικά σημεία από αυτό το κεφάλαιο είναι τα εξής:

- Η επέκταση AI Toolkit είναι ένας εξαιρετικός client που σας επιτρέπει να καταναλώνετε MCP Servers και τα εργαλεία τους.
- Μπορείτε να προσθέσετε νέα εργαλεία σε MCP servers, επεκτείνοντας τις δυνατότητες του agent ώστε να καλύπτουν τις εξελισσόμενες ανάγκες.
- Το AI Toolkit περιλαμβάνει πρότυπα (π.χ. Python MCP server templates) που απλοποιούν τη δημιουργία προσαρμοσμένων εργαλείων.

## Επιπλέον Πόροι

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Τι Ακολουθεί

Επόμενο: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης με τεχνητή νοημοσύνη [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται η επαγγελματική μετάφραση από άνθρωπο. Δεν φέρουμε καμία ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.