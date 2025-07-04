<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T18:51:05+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "ro"
}
-->
# Consumarea unui server din extensia AI Toolkit pentru Visual Studio Code

Când construiești un agent AI, nu este vorba doar despre generarea unor răspunsuri inteligente; este și despre a-i oferi agentului tău capacitatea de a acționa. Aici intervine Model Context Protocol (MCP). MCP face ușor accesul agenților la unelte și servicii externe într-un mod consecvent. Gândește-te la asta ca la conectarea agentului tău la o trusă de unelte pe care o poate *folosi cu adevărat*.

Să presupunem că conectezi un agent la serverul tău MCP pentru calculator. Dintr-o dată, agentul tău poate efectua operații matematice doar primind o solicitare de genul „Cât face 47 înmulțit cu 89?” — fără să fie nevoie să scrii logică hardcodata sau să construiești API-uri personalizate.

## Prezentare generală

Această lecție acoperă modul de conectare a unui server MCP pentru calculator la un agent folosind extensia [AI Toolkit](https://aka.ms/AIToolkit) în Visual Studio Code, permițând agentului să efectueze operații matematice precum adunare, scădere, înmulțire și împărțire prin limbaj natural.

AI Toolkit este o extensie puternică pentru Visual Studio Code care simplifică dezvoltarea agenților. Inginerii AI pot construi cu ușurință aplicații AI dezvoltând și testând modele generative AI — local sau în cloud. Extensia suportă majoritatea modelelor generative importante disponibile în prezent.

*Notă*: AI Toolkit suportă în prezent Python și TypeScript.

## Obiective de învățare

La finalul acestei lecții, vei putea:

- Consuma un server MCP prin AI Toolkit.
- Configura o configurație de agent pentru a-i permite să descopere și să utilizeze uneltele oferite de serverul MCP.
- Utiliza uneltele MCP prin limbaj natural.

## Abordare

Iată cum trebuie să abordăm acest proces la nivel înalt:

- Creează un agent și definește promptul său de sistem.
- Creează un server MCP cu unelte pentru calculator.
- Conectează Agent Builder la serverul MCP.
- Testează invocarea uneltelor agentului prin limbaj natural.

Perfect, acum că înțelegem fluxul, să configurăm un agent AI pentru a folosi unelte externe prin MCP, sporindu-i capacitățile!

## Cerințe preliminare

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pentru Visual Studio Code](https://aka.ms/AIToolkit)

## Exercițiu: Consumarea unui server

În acest exercițiu, vei construi, rula și îmbunătăți un agent AI cu unelte dintr-un server MCP în Visual Studio Code folosind AI Toolkit.

### -0- Pas preliminar, adaugă modelul OpenAI GPT-4o în My Models

Exercițiul folosește modelul **GPT-4o**. Modelul trebuie adăugat în **My Models** înainte de a crea agentul.

![Screenshot al interfeței de selecție a modelului în extensia AI Toolkit din Visual Studio Code. Titlul spune „Find the right model for your AI Solution” cu un subtitlu care încurajează utilizatorii să descopere, testeze și să implementeze modele AI. Sub „Popular Models” sunt afișate șase carduri de modele: DeepSeek-R1 (hostat pe GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) și DeepSeek-R1 (hostat pe Ollama). Fiecare card include opțiuni pentru „Add” sau „Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.ro.png)

1. Deschide extensia **AI Toolkit** din **Activity Bar**.
1. În secțiunea **Catalog**, selectează **Models** pentru a deschide **Model Catalog**. Selectarea **Models** deschide **Model Catalog** într-un tab nou al editorului.
1. În bara de căutare a **Model Catalog**, introdu **OpenAI GPT-4o**.
1. Apasă **+ Add** pentru a adăuga modelul în lista ta **My Models**. Asigură-te că ai selectat modelul care este **Hosted by GitHub**.
1. În **Activity Bar**, confirmă că modelul **OpenAI GPT-4o** apare în listă.

### -1- Creează un agent

**Agent (Prompt) Builder** îți permite să creezi și să personalizezi proprii agenți alimentați de AI. În această secțiune, vei crea un agent nou și îi vei atribui un model pentru a susține conversația.

![Screenshot al interfeței „Calculator Agent” în AI Toolkit pentru Visual Studio Code. În panoul din stânga, modelul selectat este „OpenAI GPT-4o (via GitHub).” Un prompt de sistem spune „You are a professor in university teaching math,” iar promptul utilizatorului spune „Explain to me the Fourier equation in simple terms.” Opțiuni suplimentare includ butoane pentru adăugarea uneltelor, activarea MCP Server și selectarea output-ului structurat. Un buton albastru „Run” este în partea de jos. În panoul din dreapta, sub „Get Started with Examples,” sunt listate trei agenți exemplu: Web Developer (cu MCP Server, Second-Grade Simplifier și Dream Interpreter, fiecare cu descrieri scurte ale funcțiilor lor).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.ro.png)

1. Deschide extensia **AI Toolkit** din **Activity Bar**.
1. În secțiunea **Tools**, selectează **Agent (Prompt) Builder**. Selectarea deschide **Agent (Prompt) Builder** într-un tab nou al editorului.
1. Apasă butonul **+ New Agent**. Extensia va lansa un wizard de configurare prin **Command Palette**.
1. Introdu numele **Calculator Agent** și apasă **Enter**.
1. În **Agent (Prompt) Builder**, la câmpul **Model**, selectează modelul **OpenAI GPT-4o (via GitHub)**.

### -2- Creează un prompt de sistem pentru agent

Odată ce agentul este creat, este timpul să îi definești personalitatea și scopul. În această secțiune, vei folosi funcția **Generate system prompt** pentru a descrie comportamentul dorit al agentului — în acest caz, un agent calculator — și modelul va scrie promptul de sistem pentru tine.

![Screenshot al interfeței „Calculator Agent” în AI Toolkit pentru Visual Studio Code cu o fereastră modală deschisă intitulată „Generate a prompt.” Modalul explică că un șablon de prompt poate fi generat prin furnizarea unor detalii de bază și include o casetă de text cu promptul de sistem exemplu: „You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.” Sub caseta de text sunt butoanele „Close” și „Generate.” În fundal, se vede o parte din configurația agentului, inclusiv modelul selectat „OpenAI GPT-4o (via GitHub)” și câmpurile pentru promptul de sistem și cel al utilizatorului.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.ro.png)

1. În secțiunea **Prompts**, apasă butonul **Generate system prompt**. Acest buton deschide constructorul de prompturi care folosește AI pentru a genera un prompt de sistem pentru agent.
1. În fereastra **Generate a prompt**, introdu următorul text: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Apasă butonul **Generate**. În colțul din dreapta jos va apărea o notificare care confirmă generarea promptului de sistem. După finalizare, promptul va apărea în câmpul **System prompt** din **Agent (Prompt) Builder**.
1. Revizuiește promptul de sistem și modifică-l dacă este necesar.

### -3- Creează un server MCP

Acum că ai definit promptul de sistem al agentului — care îi ghidează comportamentul și răspunsurile — este timpul să îi oferi agentului capacități practice. În această secțiune, vei crea un server MCP pentru calculator cu unelte care execută operații de adunare, scădere, înmulțire și împărțire. Acest server va permite agentului să efectueze operații matematice în timp real ca răspuns la solicitări în limbaj natural.

![Screenshot al secțiunii inferioare a interfeței Calculator Agent în AI Toolkit pentru Visual Studio Code. Se văd meniuri extensibile pentru „Tools” și „Structure output,” împreună cu un meniu dropdown intitulat „Choose output format” setat pe „text.” În dreapta, este un buton „+ MCP Server” pentru adăugarea unui server Model Context Protocol. Deasupra secțiunii Tools este un placeholder pentru o pictogramă de imagine.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.ro.png)

AI Toolkit vine echipat cu șabloane pentru a facilita crearea propriului server MCP. Vom folosi șablonul Python pentru a crea serverul MCP pentru calculator.

*Notă*: AI Toolkit suportă în prezent Python și TypeScript.

1. În secțiunea **Tools** din **Agent (Prompt) Builder**, apasă butonul **+ MCP Server**. Extensia va lansa un wizard de configurare prin **Command Palette**.
1. Selectează **+ Add Server**.
1. Selectează **Create a New MCP Server**.
1. Selectează șablonul **python-weather**.
1. Selectează **Default folder** pentru a salva șablonul serverului MCP.
1. Introdu următorul nume pentru server: **Calculator**
1. Se va deschide o fereastră nouă Visual Studio Code. Selectează **Yes, I trust the authors**.
1. Folosind terminalul (**Terminal** > **New Terminal**), creează un mediu virtual: `python -m venv .venv`
1. Activează mediul virtual în terminal:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Instalează dependențele în terminal: `pip install -e .[dev]`
1. În vizualizarea **Explorer** din **Activity Bar**, extinde directorul **src** și selectează **server.py** pentru a deschide fișierul în editor.
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

### -4- Rulează agentul cu serverul MCP pentru calculator

Acum că agentul tău are unelte, este timpul să le folosești! În această secțiune, vei trimite solicitări agentului pentru a testa și valida dacă agentul folosește uneltele potrivite din serverul MCP pentru calculator.

![Screenshot al interfeței Calculator Agent în AI Toolkit pentru Visual Studio Code. În panoul din stânga, sub „Tools,” este adăugat un server MCP numit local-server-calculator_server, care afișează patru unelte disponibile: add, subtract, multiply și divide. Un badge arată că patru unelte sunt active. Mai jos este o secțiune „Structure output” restrânsă și un buton albastru „Run.” În panoul din dreapta, sub „Model Response,” agentul invocă uneltele multiply și subtract cu inputurile {"a": 3, "b": 25} și {"a": 75, "b": 20} respectiv. Răspunsul final „Tool Response” este afișat ca 75.0. Un buton „View Code” apare în partea de jos.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.ro.png)

Vei rula serverul MCP pentru calculator pe mașina ta locală de dezvoltare prin **Agent Builder** ca și client MCP.

1. Apasă `F5` pentru a porni depanarea serverului MCP. **Agent (Prompt) Builder** se va deschide într-un tab nou al editorului. Starea serverului este vizibilă în terminal.
1. În câmpul **User prompt** al **Agent (Prompt) Builder**, introdu următoarea solicitare: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Apasă butonul **Run** pentru a genera răspunsul agentului.
1. Revizuiește răspunsul agentului. Modelul ar trebui să concluzioneze că ai plătit **55$**.
1. Iată o defalcare a ceea ce ar trebui să se întâmple:
    - Agentul selectează uneltele **multiply** și **subtract** pentru a ajuta la calcul.
    - Valorile `a` și `b` sunt atribuite pentru unealta **multiply**.
    - Valorile `a` și `b` sunt atribuite pentru unealta **subtract**.
    - Răspunsul de la fiecare unealtă este afișat în câmpul **Tool Response** corespunzător.
    - Rezultatul final al modelului este afișat în **Model Response**.
1. Trimite solicitări suplimentare pentru a testa agentul mai departe. Poți modifica promptul existent în câmpul **User prompt** făcând click în câmp și înlocuind promptul curent.
1. După ce termini testarea agentului, poți opri serverul din **terminal** prin apăsarea **CTRL/CMD+C** pentru a ieși.

## Tema

Încearcă să adaugi o unealtă suplimentară în fișierul tău **server.py** (ex: să returnezi rădăcina pătrată a unui număr). Trimite solicitări suplimentare care să necesite ca agentul să folosească noua unealtă (sau uneltele existente). Asigură-te că repornești serverul pentru a încărca uneltele adăugate.

## Soluție

[Soluție](./solution/README.md)

## Concluzii cheie

Concluziile din acest capitol sunt următoarele:

- Extensia AI Toolkit este un client excelent care îți permite să consumi servere MCP și uneltele lor.
- Poți adăuga unelte noi serverelor MCP, extinzând capacitățile agentului pentru a răspunde cerințelor în evoluție.
- AI Toolkit include șabloane (de exemplu, șabloane pentru servere MCP Python) pentru a simplifica crearea uneltelor personalizate.

## Resurse suplimentare

- [Documentația AI Toolkit](https://aka.ms/AIToolkit/doc)

## Ce urmează
- Următorul pas: [Testare și depanare](../08-testing/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.