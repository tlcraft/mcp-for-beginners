<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:29:34+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "ro"
}
-->
# Consumarea unui server din extensia AI Toolkit pentru Visual Studio Code

Când construiești un agent AI, nu este doar despre generarea de răspunsuri inteligente; este și despre a-i oferi agentului capacitatea de a acționa. Aici intervine Protocolul Contextului Modelului (MCP). MCP facilitează accesul agenților la instrumente și servicii externe într-un mod consistent. Gândește-te la asta ca la conectarea agentului tău la o trusă de unelte pe care chiar o poate folosi.

Să presupunem că conectezi un agent la serverul MCP al calculatorului tău. Dintr-o dată, agentul tău poate efectua operații matematice doar primind un prompt precum „Cât face 47 înmulțit cu 89?”—fără a fi nevoie să codifici logică sau să construiești API-uri personalizate.

## Prezentare generală

Această lecție acoperă cum să conectezi un server MCP de calculator la un agent cu extensia [AI Toolkit](https://aka.ms/AIToolkit) în Visual Studio Code, permițând agentului tău să efectueze operații matematice precum adunarea, scăderea, înmulțirea și împărțirea prin limbaj natural.

AI Toolkit este o extensie puternică pentru Visual Studio Code care simplifică dezvoltarea agenților. Inginerii AI pot construi cu ușurință aplicații AI dezvoltând și testând modele AI generative—local sau în cloud. Extensia suportă majoritatea modelelor generative disponibile astăzi.

*Notă*: AI Toolkit suportă în prezent Python și TypeScript.

## Obiective de învățare

Până la sfârșitul acestei lecții, vei fi capabil să:

- Consumi un server MCP prin AI Toolkit.
- Configurezi o configurație de agent pentru a-i permite să descopere și să utilizeze instrumentele furnizate de serverul MCP.
- Utilizezi instrumentele MCP prin limbaj natural.

## Abordare

Iată cum trebuie să abordăm acest lucru la un nivel înalt:

- Creează un agent și definește promptul său de sistem.
- Creează un server MCP cu instrumente de calculator.
- Conectează Builder-ul Agentului la serverul MCP.
- Testează invocarea instrumentelor agentului prin limbaj natural.

Grozav, acum că înțelegem fluxul, să configurăm un agent AI pentru a folosi instrumente externe prin MCP, îmbunătățindu-i capacitățile!

## Cerințe preliminare

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pentru Visual Studio Code](https://aka.ms/AIToolkit)

## Exercițiu: Consumarea unui server

În acest exercițiu, vei construi, rula și îmbunătăți un agent AI cu instrumente dintr-un server MCP în interiorul Visual Studio Code folosind AI Toolkit.

### -0- Prepas, adaugă modelul OpenAI GPT-4o la Modelele Mele

Exercițiul folosește modelul **GPT-4o**. Modelul trebuie să fie adăugat la **Modelele Mele** înainte de a crea agentul.

1. Deschide extensia **AI Toolkit** din **Activity Bar**.
1. În secțiunea **Catalog**, selectează **Models** pentru a deschide **Model Catalog**. Selectarea **Models** deschide **Model Catalog** într-o filă nouă de editor.
1. În bara de căutare **Model Catalog**, introdu **OpenAI GPT-4o**.
1. Fă clic pe **+ Add** pentru a adăuga modelul la lista ta **My Models**. Asigură-te că ai selectat modelul care este **Hosted by GitHub**.
1. În **Activity Bar**, confirmă că modelul **OpenAI GPT-4o** apare în listă.

### -1- Creează un agent

**Agent (Prompt) Builder** îți permite să creezi și să personalizezi propriii agenți AI. În această secțiune, vei crea un agent nou și vei atribui un model pentru a alimenta conversația.

1. Deschide extensia **AI Toolkit** din **Activity Bar**.
1. În secțiunea **Tools**, selectează **Agent (Prompt) Builder**. Selectarea **Agent (Prompt) Builder** deschide **Agent (Prompt) Builder** într-o filă nouă de editor.
1. Fă clic pe butonul **+ New Builder**. Extensia va lansa un asistent de configurare prin **Command Palette**.
1. Introdu numele **Calculator Agent** și apasă **Enter**.
1. În **Agent (Prompt) Builder**, pentru câmpul **Model**, selectează modelul **OpenAI GPT-4o (via GitHub)**.

### -2- Creează un prompt de sistem pentru agent

Cu agentul configurat, este timpul să-i definești personalitatea și scopul. În această secțiune, vei folosi funcția **Generate system prompt** pentru a descrie comportamentul dorit al agentului—în acest caz, un agent de calculator—și vei avea modelul să scrie promptul de sistem pentru tine.

1. Pentru secțiunea **Prompts**, fă clic pe butonul **Generate system prompt**. Acest buton se deschide în constructorul de prompturi care folosește AI pentru a genera un prompt de sistem pentru agent.
1. În fereastra **Generate a prompt**, introdu următorul text: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Fă clic pe butonul **Generate**. Va apărea o notificare în colțul din dreapta jos confirmând că promptul de sistem este generat. Odată ce generarea promptului este completă, promptul va apărea în câmpul **System prompt** al **Agent (Prompt) Builder**.
1. Revizuiește **System prompt** și modifică dacă este necesar.

### -3- Creează un server MCP

Acum că ai definit promptul de sistem al agentului—ghidându-i comportamentul și răspunsurile—este timpul să echipezi agentul cu capabilități practice. În această secțiune, vei crea un server MCP de calculator cu instrumente pentru a executa calcule de adunare, scădere, înmulțire și împărțire. Acest server va permite agentului tău să efectueze operații matematice în timp real ca răspuns la prompturi în limbaj natural.

AI Toolkit este echipat cu șabloane pentru a facilita crearea propriului server MCP. Vom folosi șablonul Python pentru a crea serverul MCP de calculator.

*Notă*: AI Toolkit suportă în prezent Python și TypeScript.

1. În secțiunea **Tools** a **Agent (Prompt) Builder**, fă clic pe butonul **+ MCP Server**. Extensia va lansa un asistent de configurare prin **Command Palette**.
1. Selectează **+ Add Server**.
1. Selectează **Create a New MCP Server**.
1. Selectează **python-weather** ca șablon.
1. Selectează **Default folder** pentru a salva șablonul serverului MCP.
1. Introdu următorul nume pentru server: **Calculator**
1. Se va deschide o fereastră nouă Visual Studio Code. Selectează **Yes, I trust the authors**.
1. Folosind terminalul (**Terminal** > **New Terminal**), creează un mediu virtual: `python -m venv .venv`
1. Folosind terminalul, activează mediul virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Folosind terminalul, instalează dependențele: `pip install -e .[dev]`
1. În vizualizarea **Explorer** a **Activity Bar**, extinde directorul **src** și selectează **server.py** pentru a deschide fișierul în editor.
1. Înlocuiește codul din fișierul **server.py** cu următorul și salvează:

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

### -4- Rulează agentul cu serverul MCP de calculator

Acum că agentul tău are instrumente, este timpul să le folosești! În această secțiune, vei trimite prompturi agentului pentru a testa și valida dacă agentul folosește instrumentul adecvat de la serverul MCP de calculator.

Vei rula serverul MCP de calculator pe mașina ta de dezvoltare locală prin **Agent Builder** ca client MCP.

1. Apasă `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Am cumpărat 3 articole la prețul de 25 $ fiecare, și apoi am folosit un discount de 20 $. Cât am plătit?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` sunt atribuite pentru instrumentul **subtract**.
    - Răspunsul de la fiecare instrument este furnizat în respectivul **Tool Response**.
    - Rezultatul final de la model este furnizat în **Model Response** final.
1. Trimite prompturi suplimentare pentru a testa mai departe agentul. Poți modifica promptul existent în câmpul **User prompt** făcând clic în câmp și înlocuind promptul existent.
1. După ce ai terminat testarea agentului, poți opri serverul prin **terminal** introducând **CTRL/CMD+C** pentru a ieși.

## Temă

Încearcă să adaugi o intrare suplimentară de instrument în fișierul **server.py** (ex: returnează rădăcina pătrată a unui număr). Trimite prompturi suplimentare care ar necesita ca agentul să folosească noul tău instrument (sau instrumentele existente). Asigură-te că repornești serverul pentru a încărca instrumentele nou adăugate.

## Soluție

[Soluție](./solution/README.md)

## Concluzii cheie

Concluziile din acest capitol sunt următoarele:

- Extensia AI Toolkit este un client excelent care îți permite să consumi servere MCP și instrumentele lor.
- Poți adăuga noi instrumente la serverele MCP, extinzând capacitățile agentului pentru a satisface cerințele în evoluție.
- AI Toolkit include șabloane (ex: șabloane de server MCP Python) pentru a simplifica crearea de instrumente personalizate.

## Resurse suplimentare

- [Documentația AI Toolkit](https://aka.ms/AIToolkit/doc)

## Ce urmează

Urmează: [Lecția 4 Implementare practică](/04-PracticalImplementation/README.md)

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să obținem acuratețe, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem responsabili pentru niciun fel de neînțelegeri sau interpretări greșite care rezultă din utilizarea acestei traduceri.