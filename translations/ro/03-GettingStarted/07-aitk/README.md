<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98bcd044860716da5819e31c152813b7",
  "translation_date": "2025-08-18T20:50:22+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "ro"
}
-->
# Consumarea unui server din extensia AI Toolkit pentru Visual Studio Code

Când construiești un agent AI, nu este vorba doar despre generarea de răspunsuri inteligente; este și despre a-i oferi agentului capacitatea de a acționa. Aici intervine Model Context Protocol (MCP). MCP face ca agenții să poată accesa instrumente și servicii externe într-un mod consistent. Gândește-te la asta ca la conectarea agentului tău la o trusă de unelte pe care o poate *folosi efectiv*.

Să presupunem că conectezi un agent la serverul MCP al unui calculator. Dintr-o dată, agentul tău poate efectua operații matematice doar primind o solicitare precum „Cât face 47 înmulțit cu 89?”—fără a fi nevoie să codifici logică sau să construiești API-uri personalizate.

## Prezentare generală

Această lecție acoperă modul de conectare a unui server MCP de tip calculator la un agent folosind extensia [AI Toolkit](https://aka.ms/AIToolkit) din Visual Studio Code, permițând agentului să efectueze operații matematice precum adunarea, scăderea, înmulțirea și împărțirea prin limbaj natural.

AI Toolkit este o extensie puternică pentru Visual Studio Code care simplifică dezvoltarea agenților. Inginerii AI pot construi cu ușurință aplicații AI dezvoltând și testând modele generative AI—local sau în cloud. Extensia suportă majoritatea modelelor generative importante disponibile astăzi.

*Notă*: AI Toolkit suportă în prezent Python și TypeScript.

## Obiective de învățare

Până la finalul acestei lecții, vei putea:

- Consuma un server MCP prin AI Toolkit.
- Configura un agent astfel încât să descopere și să utilizeze instrumentele oferite de serverul MCP.
- Utiliza instrumentele MCP prin limbaj natural.

## Abordare

Iată cum trebuie să abordăm acest proces la un nivel înalt:

- Creează un agent și definește-i promptul de sistem.
- Creează un server MCP cu instrumente de calculator.
- Conectează Agent Builder la serverul MCP.
- Testează invocarea instrumentelor agentului prin limbaj natural.

Perfect, acum că înțelegem fluxul, să configurăm un agent AI pentru a utiliza instrumente externe prin MCP, îmbunătățindu-i capabilitățile!

## Cerințe preliminare

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pentru Visual Studio Code](https://aka.ms/AIToolkit)

## Exercițiu: Consumarea unui server

> [!WARNING]
> Notă pentru utilizatorii macOS. Investigăm în prezent o problemă care afectează instalarea dependențelor pe macOS. Ca urmare, utilizatorii macOS nu vor putea finaliza acest tutorial momentan. Vom actualiza instrucțiunile imediat ce o soluție este disponibilă. Vă mulțumim pentru răbdare și înțelegere!

În acest exercițiu, vei construi, rula și îmbunătăți un agent AI cu instrumente de la un server MCP în Visual Studio Code folosind AI Toolkit.

### -0- Pas preliminar, adaugă modelul OpenAI GPT-4o la My Models

Exercițiul utilizează modelul **GPT-4o**. Modelul trebuie adăugat la **My Models** înainte de a crea agentul.

![Captură de ecran a interfeței de selecție a modelelor din extensia AI Toolkit pentru Visual Studio Code. Titlul este "Găsește modelul potrivit pentru soluția ta AI" cu un subtitlu care încurajează utilizatorii să descopere, testeze și să implementeze modele AI. Mai jos, sub “Modele populare,” sunt afișate șase carduri de modele: DeepSeek-R1 (găzduit pe GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Mic, Rapid) și DeepSeek-R1 (găzduit pe Ollama). Fiecare card include opțiuni pentru “Adaugă” modelul sau “Încearcă în Playground.”](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.ro.png)

1. Deschide extensia **AI Toolkit** din **Activity Bar**.
1. În secțiunea **Catalog**, selectează **Models** pentru a deschide **Model Catalog**. Selectarea **Models** deschide **Model Catalog** într-o filă nouă a editorului.
1. În bara de căutare a **Model Catalog**, introdu **OpenAI GPT-4o**.
1. Fă clic pe **+ Add** pentru a adăuga modelul la lista ta **My Models**. Asigură-te că ai selectat modelul **Hosted by GitHub**.
1. În **Activity Bar**, confirmă că modelul **OpenAI GPT-4o** apare în listă.

### -1- Creează un agent

**Agent (Prompt) Builder** îți permite să creezi și să personalizezi propriii agenți AI. În această secțiune, vei crea un nou agent și îi vei atribui un model pentru a alimenta conversația.

![Captură de ecran a interfeței "Calculator Agent" din extensia AI Toolkit pentru Visual Studio Code. În panoul din stânga, modelul selectat este "OpenAI GPT-4o (via GitHub)." Un prompt de sistem spune "Ești un profesor universitar care predă matematică," iar promptul utilizatorului spune, "Explică-mi ecuația Fourier pe înțelesul tuturor." Opțiuni suplimentare includ butoane pentru adăugarea de instrumente, activarea MCP Server și selectarea ieșirii structurate. Un buton albastru “Run” este în partea de jos. În panoul din dreapta, sub "Începe cu exemple," sunt listați trei agenți exemplu: Web Developer (cu MCP Server, Simplificator pentru clasa a doua și Interpret de vise, fiecare cu descrieri scurte ale funcțiilor lor).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.ro.png)

1. Deschide extensia **AI Toolkit** din **Activity Bar**.
1. În secțiunea **Tools**, selectează **Agent (Prompt) Builder**. Selectarea **Agent (Prompt) Builder** deschide **Agent (Prompt) Builder** într-o filă nouă a editorului.
1. Fă clic pe butonul **+ New Agent**. Extensia va lansa un asistent de configurare prin **Command Palette**.
1. Introdu numele **Calculator Agent** și apasă **Enter**.
1. În **Agent (Prompt) Builder**, pentru câmpul **Model**, selectează modelul **OpenAI GPT-4o (via GitHub)**.

### -2- Creează un prompt de sistem pentru agent

După ce ai creat structura agentului, este timpul să-i definești personalitatea și scopul. În această secțiune, vei utiliza funcția **Generate system prompt** pentru a descrie comportamentul intenționat al agentului—în acest caz, un agent calculator—și vei lăsa modelul să scrie promptul de sistem pentru tine.

![Captură de ecran a interfeței "Calculator Agent" din AI Toolkit pentru Visual Studio Code cu o fereastră modală deschisă intitulată "Generate a prompt." Fereastra explică faptul că un șablon de prompt poate fi generat prin furnizarea unor detalii de bază și include o casetă de text cu promptul de sistem exemplu: "Ești un asistent matematic util și eficient. Când primești o problemă care implică aritmetică de bază, răspunzi cu rezultatul corect." Sub caseta de text sunt butoanele "Close" și "Generate." În fundal, o parte din configurația agentului este vizibilă, incluzând modelul selectat "OpenAI GPT-4o (via GitHub)" și câmpurile pentru prompturile de sistem și utilizator.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.ro.png)

1. Pentru secțiunea **Prompts**, fă clic pe butonul **Generate system prompt**. Acest buton deschide generatorul de prompturi, care utilizează AI pentru a genera un prompt de sistem pentru agent.
1. În fereastra **Generate a prompt**, introdu următorul text: `Ești un asistent matematic util și eficient. Când primești o problemă care implică aritmetică de bază, răspunzi cu rezultatul corect.`
1. Fă clic pe butonul **Generate**. O notificare va apărea în colțul din dreapta jos, confirmând că promptul de sistem este generat. După finalizarea generării, promptul va apărea în câmpul **System prompt** din **Agent (Prompt) Builder**.
1. Revizuiește **System prompt** și modifică-l dacă este necesar.

### -3- Creează un server MCP

Acum că ai definit promptul de sistem al agentului—ghidându-i comportamentul și răspunsurile—este timpul să echipezi agentul cu capabilități practice. În această secțiune, vei crea un server MCP de tip calculator cu instrumente pentru a efectua calcule de adunare, scădere, înmulțire și împărțire. Acest server va permite agentului să efectueze operații matematice în timp real ca răspuns la solicitări în limbaj natural.

!["Captură de ecran a secțiunii inferioare a interfeței Calculator Agent din extensia AI Toolkit pentru Visual Studio Code. Aceasta arată meniuri extensibile pentru “Tools” și “Structure output,” împreună cu un meniu dropdown etichetat “Choose output format” setat pe “text.” În dreapta, există un buton etichetat “+ MCP Server” pentru adăugarea unui server Model Context Protocol. Un substituent pentru o pictogramă imagine este afișat deasupra secțiunii Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.ro.png)

AI Toolkit este echipat cu șabloane pentru a facilita crearea propriilor servere MCP. Vom utiliza șablonul Python pentru a crea serverul MCP de tip calculator.

*Notă*: AI Toolkit suportă în prezent Python și TypeScript.

1. În secțiunea **Tools** din **Agent (Prompt) Builder**, fă clic pe butonul **+ MCP Server**. Extensia va lansa un asistent de configurare prin **Command Palette**.
1. Selectează **+ Add Server**.
1. Selectează **Create a New MCP Server**.
1. Selectează **python-weather** ca șablon.
1. Selectează **Default folder** pentru a salva șablonul serverului MCP.
1. Introdu următorul nume pentru server: **Calculator**
1. O nouă fereastră Visual Studio Code se va deschide. Selectează **Yes, I trust the authors**.
1. Folosind terminalul (**Terminal** > **New Terminal**), creează un mediu virtual: `python -m venv .venv`
1. Folosind terminalul, activează mediul virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source .venv/bin/activate`
1. Folosind terminalul, instalează dependențele: `pip install -e .[dev]`
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

### -4- Rulează agentul cu serverul MCP de tip calculator

Acum că agentul tău are instrumente, este timpul să le folosească! În această secțiune, vei trimite solicitări agentului pentru a testa și valida dacă agentul utilizează instrumentul corespunzător de la serverul MCP de tip calculator.

![Captură de ecran a interfeței Calculator Agent din extensia AI Toolkit pentru Visual Studio Code. În panoul din stânga, sub “Tools,” un server MCP numit local-server-calculator_server este adăugat, afișând patru instrumente disponibile: add, subtract, multiply și divide. O insignă arată că patru instrumente sunt active. Mai jos este o secțiune “Structure output” colapsată și un buton albastru “Run.” În panoul din dreapta, sub “Model Response,” agentul invocă instrumentele multiply și subtract cu intrările {"a": 3, "b": 25} și {"a": 75, "b": 20} respectiv. Răspunsul final al instrumentului este afișat ca 75.0. Un buton “View Code” apare în partea de jos.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.ro.png)

Vei rula serverul MCP de tip calculator pe mașina ta locală de dezvoltare prin **Agent Builder** ca MCP client.

1. Apasă `F5` pentru a începe depanarea serverului MCP. **Agent (Prompt) Builder** se va deschide într-o filă nouă a editorului. Starea serverului este vizibilă în terminal.
1. În câmpul **User prompt** din **Agent (Prompt) Builder**, introdu următoarea solicitare: `Am cumpărat 3 articole la prețul de 25$ fiecare, apoi am folosit un cupon de reducere de 20$. Cât am plătit?`
1. Fă clic pe butonul **Run** pentru a genera răspunsul agentului.
1. Revizuiește ieșirea agentului. Modelul ar trebui să concluzioneze că ai plătit **55$**.
1. Iată o descriere a ceea ce ar trebui să se întâmple:
    - Agentul selectează instrumentele **multiply** și **subtract** pentru a ajuta la calcul.
    - Valorile respective `a` și `b` sunt atribuite pentru instrumentul **multiply**.
    - Valorile respective `a` și `b` sunt atribuite pentru instrumentul **subtract**.
    - Răspunsul fiecărui instrument este furnizat în **Tool Response**.
    - Ieșirea finală a modelului este furnizată în **Model Response**.
1. Trimite solicitări suplimentare pentru a testa în continuare agentul. Poți modifica solicitarea existentă în câmpul **User prompt** făcând clic în câmp și înlocuind solicitarea existentă.
1. După ce ai terminat de testat agentul, poți opri serverul prin **terminal** introducând **CTRL/CMD+C** pentru a ieși.

## Temă

Încearcă să adaugi o intrare suplimentară pentru un instrument în fișierul tău **server.py** (ex: returnează rădăcina pătrată a unui număr). Trimite solicitări suplimentare care ar necesita ca agentul să utilizeze noul tău instrument (sau instrumentele existente). Asigură-te că repornești serverul pentru a încărca instrumentele nou adăugate.

## Soluție

[Soluție](./solution/README.md)

## Concluzii cheie

Concluziile acestui capitol sunt următoarele:

- Extensia AI Toolkit este un client excelent care permite consumarea serverelor MCP și a instrumentelor acestora.
- Poți adăuga noi instrumente la serverele MCP, extinzând capabilitățile agentului pentru a răspunde cerințelor în continuă schimbare.
- AI Toolkit include șabloane (ex: șabloane pentru servere MCP în Python) pentru a simplifica crearea de instrumente personalizate.

## Resurse suplimentare

- [Documentația AI Toolkit](https://aka.ms/AIToolkit/doc)

## Ce urmează
- Următorul capitol: [Testare și depanare](../08-testing/README.md)

**Declinarea responsabilității**:  
Acest document a fost tradus utilizând serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși depunem eforturi pentru a asigura acuratețea, vă rugăm să aveți în vedere că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.