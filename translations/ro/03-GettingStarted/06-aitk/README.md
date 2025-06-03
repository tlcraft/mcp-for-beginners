<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:50:35+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "ro"
}
-->
# Consumarea unui server din extensia AI Toolkit pentru Visual Studio Code

Când construiești un agent AI, nu este vorba doar despre generarea unor răspunsuri inteligente; este și despre a-i oferi agentului tău capacitatea de a lua acțiuni. Aici intervine Model Context Protocol (MCP). MCP facilitează accesul agenților la unelte și servicii externe într-un mod consecvent. Gândește-te la asta ca și cum ai conecta agentul tău la o cutie de scule pe care o poate *folosi cu adevărat*.

Să presupunem că conectezi un agent la serverul tău MCP calculator. Dintr-o dată, agentul tău poate efectua operații matematice doar primind un prompt de genul „Cât fac 47 înmulțit cu 89?”—fără să fie nevoie să scrii logică hardcodata sau să construiești API-uri personalizate.

## Prezentare generală

Această lecție acoperă modul de conectare a unui server MCP calculator la un agent folosind extensia [AI Toolkit](https://aka.ms/AIToolkit) în Visual Studio Code, permițând agentului tău să efectueze operații matematice precum adunarea, scăderea, înmulțirea și împărțirea prin limbaj natural.

AI Toolkit este o extensie puternică pentru Visual Studio Code care simplifică dezvoltarea agenților. Inginerii AI pot construi ușor aplicații AI dezvoltând și testând modele generative AI—local sau în cloud. Extensia suportă majoritatea modelelor generative majore disponibile în prezent.

*Notă*: AI Toolkit suportă momentan Python și TypeScript.

## Obiective de învățare

La finalul acestei lecții, vei putea:

- Consuma un server MCP prin AI Toolkit.
- Configura o configurație de agent pentru a-i permite să descopere și să utilizeze uneltele oferite de serverul MCP.
- Utiliza uneltele MCP prin limbaj natural.

## Abordare

Iată cum trebuie să abordăm acest proces la nivel înalt:

- Creează un agent și definește promptul său de sistem.
- Creează un server MCP cu unelte calculator.
- Conectează Agent Builder la serverul MCP.
- Testează invocarea uneltelor agentului prin limbaj natural.

Perfect, acum că înțelegem fluxul, să configurăm un agent AI pentru a folosi unelte externe prin MCP, sporindu-i capabilitățile!

## Cerințe preliminare

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pentru Visual Studio Code](https://aka.ms/AIToolkit)

## Exercițiu: Consumarea unui server

În acest exercițiu, vei construi, rula și îmbunătăți un agent AI cu unelte dintr-un server MCP în Visual Studio Code folosind AI Toolkit.

### -0- Pas preliminar, adaugă modelul OpenAI GPT-4o în My Models

Exercițiul folosește modelul **GPT-4o**. Modelul trebuie adăugat în **My Models** înainte de a crea agentul.

![Screenshot al interfeței de selecție a modelului din extensia AI Toolkit pentru Visual Studio Code. Titlul spune „Find the right model for your AI Solution” cu un subtitlu care încurajează descoperirea, testarea și implementarea modelelor AI. Sub „Popular Models” sunt afișate șase carduri de modele: DeepSeek-R1 (hostat pe GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - mic, rapid) și DeepSeek-R1 (hostat pe Ollama). Fiecare card include opțiuni de „Add” sau „Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.ro.png)

1. Deschide extensia **AI Toolkit** din **Activity Bar**.
2. În secțiunea **Catalog**, selectează **Models** pentru a deschide **Model Catalog**. Selectarea **Models** deschide catalogul într-un tab nou.
3. În bara de căutare a **Model Catalog**, introdu **OpenAI GPT-4o**.
4. Apasă pe **+ Add** pentru a adăuga modelul în lista ta **My Models**. Asigură-te că ai selectat modelul **Hosted by GitHub**.
5. În **Activity Bar**, verifică dacă modelul **OpenAI GPT-4o** apare în listă.

### -1- Creează un agent

**Agent (Prompt) Builder** îți permite să creezi și să personalizezi proprii agenți AI. În această secțiune, vei crea un agent nou și îi vei atribui un model pentru a susține conversația.

![Screenshot al interfeței „Calculator Agent” din extensia AI Toolkit pentru Visual Studio Code. În panoul din stânga, modelul selectat este „OpenAI GPT-4o (via GitHub).” Un prompt de sistem spune „You are a professor in university teaching math,” iar promptul utilizatorului este „Explain to me the Fourier equation in simple terms.” Alte opțiuni includ butoane pentru adăugarea uneltelor, activarea MCP Server și selectarea output-ului structurat. Un buton albastru „Run” este jos. În panoul din dreapta, sub „Get Started with Examples,” sunt listate trei agenți exemplu: Web Developer (cu MCP Server, Second-Grade Simplifier și Dream Interpreter, fiecare cu descrieri scurte ale funcțiilor lor).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.ro.png)

1. Deschide extensia **AI Toolkit** din **Activity Bar**.
2. În secțiunea **Tools**, selectează **Agent (Prompt) Builder**. Aceasta deschide **Agent (Prompt) Builder** într-un tab nou.
3. Apasă butonul **+ New Agent**. Extensia va lansa un wizard prin **Command Palette**.
4. Introdu numele **Calculator Agent** și apasă **Enter**.
5. În **Agent (Prompt) Builder**, la câmpul **Model**, selectează modelul **OpenAI GPT-4o (via GitHub)**.

### -2- Creează un prompt de sistem pentru agent

Acum că agentul este schițat, e timpul să-i definești personalitatea și scopul. În această secțiune, vei folosi funcția **Generate system prompt** pentru a descrie comportamentul dorit al agentului — în acest caz, un agent calculator — și modelul va scrie promptul de sistem pentru tine.

![Screenshot al interfeței „Calculator Agent” din AI Toolkit pentru Visual Studio Code cu o fereastră modală deschisă intitulată „Generate a prompt.” Modalul explică că un șablon de prompt poate fi generat prin furnizarea unor detalii de bază și include o casetă de text cu promptul de sistem exemplu: „You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.” Sub caseta de text sunt butoanele „Close” și „Generate.” În fundal se văd parțial configurația agentului, inclusiv modelul selectat „OpenAI GPT-4o (via GitHub)” și câmpurile pentru promptul de sistem și cel al utilizatorului.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.ro.png)

1. În secțiunea **Prompts**, apasă butonul **Generate system prompt**. Acest buton deschide prompt builder-ul care folosește AI pentru a genera un prompt de sistem pentru agent.
2. În fereastra **Generate a prompt**, introdu următorul text: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Apasă butonul **Generate**. În colțul din dreapta jos va apărea o notificare care confirmă generarea promptului de sistem. După finalizare, promptul va apărea în câmpul **System prompt** din **Agent (Prompt) Builder**.
4. Revizuiește promptul de sistem și modifică-l dacă este necesar.

### -3- Creează un server MCP

Acum că ai definit promptul de sistem al agentului — care îi ghidează comportamentul și răspunsurile — e timpul să-l echipezi cu capabilități practice. În această secțiune, vei crea un server MCP calculator cu unelte pentru adunare, scădere, înmulțire și împărțire. Acest server va permite agentului să efectueze operații matematice în timp real ca răspuns la prompturi în limbaj natural.

!["Screenshot al secțiunii inferioare a interfeței Calculator Agent din extensia AI Toolkit pentru Visual Studio Code. Se văd meniuri extinse pentru „Tools” și „Structure output,” împreună cu un meniu dropdown „Choose output format” setat pe „text.” În dreapta, există un buton „+ MCP Server” pentru adăugarea unui server Model Context Protocol. Un placeholder pentru iconița unei imagini este afișat deasupra secțiunii Tools.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.ro.png)

AI Toolkit este echipat cu șabloane pentru a ușura crearea propriului server MCP. Vom folosi șablonul Python pentru a crea serverul MCP calculator.

*Notă*: AI Toolkit suportă momentan Python și TypeScript.

1. În secțiunea **Tools** din **Agent (Prompt) Builder**, apasă butonul **+ MCP Server**. Extensia va lansa un wizard prin **Command Palette**.
2. Selectează **+ Add Server**.
3. Selectează **Create a New MCP Server**.
4. Selectează șablonul **python-weather**.
5. Selectează **Default folder** pentru a salva șablonul serverului MCP.
6. Introdu următorul nume pentru server: **Calculator**
7. Se va deschide o nouă fereastră Visual Studio Code. Selectează **Yes, I trust the authors**.
8. Folosind terminalul (**Terminal** > **New Terminal**), creează un mediu virtual: `python -m venv .venv`
9. Folosind terminalul, activează mediul virtual:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Folosind terminalul, instalează dependențele: `pip install -e .[dev]`
11. În vizualizarea **Explorer** din **Activity Bar**, extinde directorul **src** și selectează fișierul **server.py** pentru a-l deschide în editor.
12. Înlocuiește codul din fișierul **server.py** cu următorul și salvează:

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

### -4- Rulează agentul cu serverul MCP calculator

Acum că agentul tău are unelte, e timpul să le folosești! În această secțiune, vei trimite prompturi agentului pentru a testa și valida dacă acesta folosește uneltele potrivite din serverul MCP calculator.

![Screenshot al interfeței Calculator Agent din extensia AI Toolkit pentru Visual Studio Code. În panoul din stânga, sub „Tools,” un server MCP numit local-server-calculator_server este adăugat, afișând patru unelte disponibile: add, subtract, multiply și divide. Un badge arată că patru unelte sunt active. Mai jos este o secțiune „Structure output” restrânsă și un buton albastru „Run.” În panoul din dreapta, sub „Model Response,” agentul invocă uneltele multiply și subtract cu intrările {"a": 3, "b": 25} și {"a": 75, "b": 20} respectiv. „Tool Response” final este afișat ca 75.0. Un buton „View Code” apare jos.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.ro.png)

Vei rula serverul MCP calculator pe mașina ta locală de dezvoltare prin **Agent Builder** ca și client MCP.

1. Apasă `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Am cumpărat 3 produse, fiecare cu prețul de 25$, apoi am folosit o reducere de 20$. Cât am plătit?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` valorile sunt atribuite pentru unealta **subtract**.
    - Răspunsul de la fiecare unealtă este afișat în câmpul **Tool Response** corespunzător.
    - Rezultatul final al modelului este afișat în câmpul **Model Response** final.
2. Trimite prompturi suplimentare pentru a testa agentul mai departe. Poți modifica promptul existent în câmpul **User prompt** făcând click în câmp și înlocuind promptul curent.
3. Când ai terminat testarea agentului, poți opri serverul din **terminal** prin apăsarea **CTRL/CMD+C** pentru a ieși.

## Tema pentru acasă

Încearcă să adaugi o unealtă suplimentară în fișierul tău **server.py** (ex: returnează rădăcina pătrată a unui număr). Trimite prompturi care ar necesita folosirea noii unelte (sau a celor existente) de către agent. Asigură-te că repornești serverul pentru a încărca uneltele adăugate.

## Soluție

[Solution](./solution/README.md)

## Puncte cheie

Ce am reținut din acest capitol:

- Extensia AI Toolkit este un client excelent care îți permite să consumi servere MCP și uneltele lor.
- Poți adăuga unelte noi serverelor MCP, extinzând capabilitățile agentului pentru a răspunde cerințelor în schimbare.
- AI Toolkit include șabloane (ex: șabloane pentru servere MCP în Python) pentru a simplifica crearea uneltelor personalizate.

## Resurse suplimentare

- [Documentația AI Toolkit](https://aka.ms/AIToolkit/doc)

## Ce urmează

Următorul pas: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere automată AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să țineți cont că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot rezulta din utilizarea acestei traduceri.