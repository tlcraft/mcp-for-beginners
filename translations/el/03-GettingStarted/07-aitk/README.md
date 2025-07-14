<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:34:02+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "el"
}
-->
# Χρήση ενός server από την επέκταση AI Toolkit για το Visual Studio Code

Όταν δημιουργείς έναν AI agent, δεν πρόκειται μόνο για τη δημιουργία έξυπνων απαντήσεων· είναι επίσης σημαντικό να δώσεις στον agent σου τη δυνατότητα να αναλαμβάνει δράση. Εδώ μπαίνει το Model Context Protocol (MCP). Το MCP διευκολύνει τους agents να έχουν πρόσβαση σε εξωτερικά εργαλεία και υπηρεσίες με έναν συνεπή τρόπο. Σκέψου το σαν να συνδέεις τον agent σου σε ένα κουτί εργαλείων που μπορεί *πραγματικά* να χρησιμοποιήσει.

Ας πούμε ότι συνδέεις έναν agent με τον MCP server του υπολογιστή σου. Ξαφνικά, ο agent σου μπορεί να εκτελεί μαθηματικές πράξεις απλά λαμβάνοντας ένα prompt όπως «Πόσο κάνει 47 επί 89;»—χωρίς να χρειάζεται να κωδικοποιήσεις λογική ή να φτιάξεις προσαρμοσμένα APIs.

## Επισκόπηση

Αυτό το μάθημα καλύπτει πώς να συνδέσεις έναν MCP server υπολογιστή με έναν agent χρησιμοποιώντας την επέκταση [AI Toolkit](https://aka.ms/AIToolkit) στο Visual Studio Code, δίνοντας στον agent σου τη δυνατότητα να εκτελεί μαθηματικές πράξεις όπως πρόσθεση, αφαίρεση, πολλαπλασιασμό και διαίρεση μέσω φυσικής γλώσσας.

Το AI Toolkit είναι μια ισχυρή επέκταση για το Visual Studio Code που απλοποιεί την ανάπτυξη agents. Οι AI Engineers μπορούν εύκολα να δημιουργήσουν εφαρμογές AI αναπτύσσοντας και δοκιμάζοντας γενετικά μοντέλα AI—τοπικά ή στο cloud. Η επέκταση υποστηρίζει τα περισσότερα από τα σημαντικότερα γενετικά μοντέλα που υπάρχουν σήμερα.

*Σημείωση*: Το AI Toolkit υποστηρίζει προς το παρόν Python και TypeScript.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα είσαι σε θέση να:

- Καταναλώνεις έναν MCP server μέσω του AI Toolkit.
- Διαμορφώσεις μια ρύθμιση agent ώστε να μπορεί να ανακαλύπτει και να χρησιμοποιεί τα εργαλεία που παρέχει ο MCP server.
- Χρησιμοποιείς τα εργαλεία MCP μέσω φυσικής γλώσσας.

## Προσέγγιση

Ακολουθεί μια γενική προσέγγιση:

- Δημιουργία ενός agent και ορισμός του system prompt του.
- Δημιουργία ενός MCP server με εργαλεία υπολογιστή.
- Σύνδεση του Agent Builder με τον MCP server.
- Δοκιμή της κλήσης εργαλείων του agent μέσω φυσικής γλώσσας.

Τέλεια, τώρα που κατανοούμε τη ροή, ας διαμορφώσουμε έναν AI agent ώστε να αξιοποιεί εξωτερικά εργαλεία μέσω MCP, ενισχύοντας τις δυνατότητές του!

## Προαπαιτούμενα

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit για Visual Studio Code](https://aka.ms/AIToolkit)

## Άσκηση: Χρήση ενός server

Σε αυτή την άσκηση, θα δημιουργήσεις, θα τρέξεις και θα βελτιώσεις έναν AI agent με εργαλεία από έναν MCP server μέσα στο Visual Studio Code χρησιμοποιώντας το AI Toolkit.

### -0- Προετοιμασία, πρόσθεσε το μοντέλο OpenAI GPT-4o στα My Models

Η άσκηση χρησιμοποιεί το μοντέλο **GPT-4o**. Το μοντέλο πρέπει να προστεθεί στα **My Models** πριν δημιουργήσεις τον agent.

![Screenshot of a model selection interface in Visual Studio Code's AI Toolkit extension. The heading reads "Find the right model for your AI Solution" with a subtitle encouraging users to discover, test, and deploy AI models. Below, under “Popular Models,” six model cards are displayed: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), and DeepSeek-R1 (Ollama-hosted). Each card includes options to “Add” the model or “Try in Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.el.png)

1. Άνοιξε την επέκταση **AI Toolkit** από τη **Γραμμή Δραστηριοτήτων**.
1. Στην ενότητα **Catalog**, επίλεξε **Models** για να ανοίξεις το **Model Catalog**. Η επιλογή **Models** ανοίγει το **Model Catalog** σε νέα καρτέλα επεξεργασίας.
1. Στη γραμμή αναζήτησης του **Model Catalog**, πληκτρολόγησε **OpenAI GPT-4o**.
1. Κάνε κλικ στο **+ Add** για να προσθέσεις το μοντέλο στη λίστα **My Models**. Βεβαιώσου ότι έχεις επιλέξει το μοντέλο που είναι **Hosted by GitHub**.
1. Στη **Γραμμή Δραστηριοτήτων**, επιβεβαίωσε ότι το μοντέλο **OpenAI GPT-4o** εμφανίζεται στη λίστα.

### -1- Δημιουργία agent

Ο **Agent (Prompt) Builder** σου επιτρέπει να δημιουργήσεις και να προσαρμόσεις τους δικούς σου AI-powered agents. Σε αυτή την ενότητα, θα δημιουργήσεις έναν νέο agent και θα του αναθέσεις ένα μοντέλο για να τροφοδοτεί τη συνομιλία.

![Screenshot of the "Calculator Agent" builder interface in the AI Toolkit extension for Visual Studio Code. On the left panel, the model selected is "OpenAI GPT-4o (via GitHub)." A system prompt reads "You are a professor in university teaching math," and the user prompt says, "Explain to me the Fourier equation in simple terms." Additional options include buttons for adding tools, enabling MCP Server, and selecting structured output. A blue “Run” button is at the bottom. On the right panel, under "Get Started with Examples," three sample agents are listed: Web Developer (with MCP Server, Second-Grade Simplifier, and Dream Interpreter, each with brief descriptions of their functions.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.el.png)

1. Άνοιξε την επέκταση **AI Toolkit** από τη **Γραμμή Δραστηριοτήτων**.
1. Στην ενότητα **Tools**, επίλεξε **Agent (Prompt) Builder**. Η επιλογή ανοίγει τον **Agent (Prompt) Builder** σε νέα καρτέλα επεξεργασίας.
1. Πάτησε το κουμπί **+ New Agent**. Η επέκταση θα ξεκινήσει έναν οδηγό ρύθμισης μέσω της **Command Palette**.
1. Πληκτρολόγησε το όνομα **Calculator Agent** και πάτησε **Enter**.
1. Στον **Agent (Prompt) Builder**, στο πεδίο **Model**, επίλεξε το μοντέλο **OpenAI GPT-4o (via GitHub)**.

### -2- Δημιουργία system prompt για τον agent

Με τον agent έτοιμο, ήρθε η ώρα να ορίσεις την προσωπικότητα και το σκοπό του. Σε αυτή την ενότητα, θα χρησιμοποιήσεις τη λειτουργία **Generate system prompt** για να περιγράψεις τη συμπεριφορά που θέλεις να έχει ο agent—στην προκειμένη περίπτωση, ένας agent υπολογιστή—και να αφήσεις το μοντέλο να γράψει το system prompt για σένα.

![Screenshot of the "Calculator Agent" interface in the AI Toolkit for Visual Studio Code with a modal window open titled "Generate a prompt." The modal explains that a prompt template can be generated by sharing basic details and includes a text box with the sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Below the text box are "Close" and "Generate" buttons. In the background, part of the agent configuration is visible, including the selected model "OpenAI GPT-4o (via GitHub)" and fields for system and user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.el.png)

1. Στην ενότητα **Prompts**, πάτησε το κουμπί **Generate system prompt**. Αυτό το κουμπί ανοίγει τον prompt builder που χρησιμοποιεί AI για να δημιουργήσει ένα system prompt για τον agent.
1. Στο παράθυρο **Generate a prompt**, πληκτρολόγησε το εξής: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Πάτησε το κουμπί **Generate**. Θα εμφανιστεί μια ειδοποίηση κάτω δεξιά που επιβεβαιώνει ότι το system prompt δημιουργείται. Μόλις ολοκληρωθεί, το prompt θα εμφανιστεί στο πεδίο **System prompt** του **Agent (Prompt) Builder**.
1. Δες το **System prompt** και τροποποίησέ το αν χρειάζεται.

### -3- Δημιουργία MCP server

Τώρα που έχεις ορίσει το system prompt του agent—που καθοδηγεί τη συμπεριφορά και τις απαντήσεις του—ήρθε η ώρα να τον εξοπλίσεις με πρακτικές δυνατότητες. Σε αυτή την ενότητα, θα δημιουργήσεις έναν MCP server υπολογιστή με εργαλεία για εκτέλεση πράξεων πρόσθεσης, αφαίρεσης, πολλαπλασιασμού και διαίρεσης. Αυτός ο server θα επιτρέψει στον agent σου να εκτελεί μαθηματικούς υπολογισμούς σε πραγματικό χρόνο απαντώντας σε prompts φυσικής γλώσσας.

!["Screenshot of the lower section of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. It shows expandable menus for “Tools” and “Structure output,” along with a dropdown menu labeled “Choose output format” set to “text.” To the right, there is a button labeled “+ MCP Server” for adding a Model Context Protocol server. An image icon placeholder is shown above the Tools section.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.el.png)

Το AI Toolkit διαθέτει πρότυπα για να διευκολύνει τη δημιουργία του δικού σου MCP server. Θα χρησιμοποιήσουμε το πρότυπο Python για τη δημιουργία του MCP server υπολογιστή.

*Σημείωση*: Το AI Toolkit υποστηρίζει προς το παρόν Python και TypeScript.

1. Στην ενότητα **Tools** του **Agent (Prompt) Builder**, πάτησε το κουμπί **+ MCP Server**. Η επέκταση θα ξεκινήσει έναν οδηγό ρύθμισης μέσω της **Command Palette**.
1. Επίλεξε **+ Add Server**.
1. Επίλεξε **Create a New MCP Server**.
1. Επίλεξε το πρότυπο **python-weather**.
1. Επίλεξε **Default folder** για να αποθηκευτεί το πρότυπο MCP server.
1. Πληκτρολόγησε το όνομα **Calculator** για τον server.
1. Θα ανοίξει ένα νέο παράθυρο Visual Studio Code. Επίλεξε **Yes, I trust the authors**.
1. Χρησιμοποιώντας το τερματικό (**Terminal** > **New Terminal**), δημιούργησε ένα virtual environment: `python -m venv .venv`
1. Ενεργοποίησε το virtual environment μέσω τερματικού:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Εγκατέστησε τις εξαρτήσεις μέσω τερματικού: `pip install -e .[dev]`
1. Στην προβολή **Explorer** της **Γραμμής Δραστηριοτήτων**, άνοιξε τον φάκελο **src** και επίλεξε το αρχείο **server.py** για να το ανοίξεις στον επεξεργαστή.
1. Αντικατέστησε τον κώδικα στο αρχείο **server.py** με τον παρακάτω και αποθήκευσε:

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

### -4- Τρέξε τον agent με τον MCP server υπολογιστή

Τώρα που ο agent σου έχει εργαλεία, ήρθε η ώρα να τα χρησιμοποιήσεις! Σε αυτή την ενότητα, θα στείλεις prompts στον agent για να δοκιμάσεις και να επιβεβαιώσεις αν ο agent χρησιμοποιεί το κατάλληλο εργαλείο από τον MCP server υπολογιστή.

![Screenshot of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. On the left panel, under “Tools,” an MCP server named local-server-calculator_server is added, showing four available tools: add, subtract, multiply, and divide. A badge shows that four tools are active. Below is a collapsed “Structure output” section and a blue “Run” button. On the right panel, under “Model Response,” the agent invokes the multiply and subtract tools with inputs {"a": 3, "b": 25} and {"a": 75, "b": 20} respectively. The final “Tool Response” is shown as 75.0. A “View Code” button appears at the bottom.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.el.png)

Θα τρέξεις τον MCP server υπολογιστή τοπικά μέσω του **Agent Builder** ως MCP client.

1. Πάτησε `F5` για να ξεκινήσεις το debugging του MCP server. Ο **Agent (Prompt) Builder** θα ανοίξει σε νέα καρτέλα επεξεργασίας. Η κατάσταση του server φαίνεται στο τερματικό.
1. Στο πεδίο **User prompt** του **Agent (Prompt) Builder**, πληκτρολόγησε το εξής prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Πάτησε το κουμπί **Run** για να δημιουργηθεί η απάντηση του agent.
1. Δες την έξοδο του agent. Το μοντέλο θα πρέπει να καταλήξει ότι πλήρωσες **$55**.
1. Να τι θα πρέπει να συμβεί:
    - Ο agent επιλέγει τα εργαλεία **multiply** και **subtract** για να βοηθήσουν στον υπολογισμό.
    - Οι αντίστοιχες τιμές `a` και `b` ορίζονται για το εργαλείο **multiply**.
    - Οι αντίστοιχες τιμές `a` και `b` ορίζονται για το εργαλείο **subtract**.
    - Η απάντηση από κάθε εργαλείο εμφανίζεται στο αντίστοιχο **Tool Response**.
    - Η τελική απάντηση από το μοντέλο εμφανίζεται στο τελικό **Model Response**.
1. Στείλε επιπλέον prompts για να δοκιμάσεις περαιτέρω τον agent. Μπορείς να τροποποιήσεις το υπάρχον prompt στο πεδίο **User prompt** κάνοντας κλικ μέσα και αντικαθιστώντας το.
1. Όταν τελειώσεις με τις δοκιμές, μπορείς να σταματήσεις τον server μέσω του **τερματικού** πατώντας **CTRL/CMD+C**.

## Ανάθεση

Δοκίμασε να προσθέσεις ένα επιπλέον εργαλείο στο αρχείο **server.py** (π.χ. να επιστρέφει την τετραγωνική ρίζα ενός αριθμού). Στείλε επιπλέον prompts που θα απαιτούν από τον agent να χρησιμοποιήσει το νέο εργαλείο (ή τα υπάρχοντα). Μην ξεχάσεις να επανεκκινήσεις τον server για να φορτωθούν τα νέα εργαλεία.

## Λύση

[Solution](./solution/README.md)

## Βασικά Συμπεράσματα

Τα βασικά σημεία από αυτό το κεφάλαιο είναι τα εξής:

- Η επέκταση AI Toolkit είναι ένας εξαιρετικός client που σου επιτρέπει να χρησιμοποιείς MCP Servers και τα εργαλεία τους.
- Μπορείς να προσθέσεις νέα εργαλεία σε MCP servers, επεκτείνοντας τις δυνατότητες του agent ώστε να καλύπτει τις εξελισσόμενες ανάγκες.
- Το AI Toolkit περιλαμβάνει πρότυπα (π.χ. πρότυπα MCP server σε Python) που απλοποιούν τη δημιουργία προσαρμοσμένων εργαλείων.

## Επιπλέον Πόροι

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Τι Ακολουθεί
- Επόμενο: [Testing & Debugging](../08-testing/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.