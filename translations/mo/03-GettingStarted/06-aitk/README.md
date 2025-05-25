<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:16:21+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "mo"
}
-->
# Konsome një server nga zgjerimi AI Toolkit për Visual Studio Code

Kur po ndërtoni një agjent AI, nuk është vetëm për gjenerimin e përgjigjeve të zgjuara; është gjithashtu për t'i dhënë agjentit tuaj aftësinë për të vepruar. Këtu hyn në lojë Model Context Protocol (MCP). MCP e bën të lehtë për agjentët të aksesojnë mjete dhe shërbime të jashtme në një mënyrë të qëndrueshme. Mendoni për të si të lidhni agjentin tuaj me një kuti mjetesh që mund të *përdorë* realisht.

Le të themi se lidhni një agjent me serverin tuaj MCP të kalkulatorit. Papritur, agjenti juaj mund të kryejë operacione matematikore vetëm duke marrë një kërkesë si "Sa është 47 herë 89?"—pa nevojë për të koduar logjikën ose për të ndërtuar API të personalizuara.

## Përmbledhje

Ky mësim mbulon se si të lidhni një server MCP kalkulatori me një agjent me zgjerimin [AI Toolkit](https://aka.ms/AIToolkit) në Visual Studio Code, duke i mundësuar agjentit tuaj të kryejë operacione matematikore si mbledhje, zbritje, shumëzim dhe pjesëtim përmes gjuhës natyrale.

AI Toolkit është një zgjerim i fuqishëm për Visual Studio Code që thjeshton zhvillimin e agjentëve. Inxhinierët AI mund të ndërtojnë lehtësisht aplikacione AI duke zhvilluar dhe testuar modele AI gjenerative—lokalisht ose në cloud. Zgjerimi mbështet shumicën e modeleve gjenerative kryesore të disponueshme sot.

*Shënim*: AI Toolkit aktualisht mbështet Python dhe TypeScript.

## Objektivat e mësimit

Në fund të këtij mësimi, do të jeni në gjendje:

- Konsumoni një server MCP përmes AI Toolkit.
- Konfiguroni një konfigurim agjenti për t'i mundësuar atij të zbulojë dhe përdorë mjetet e ofruara nga serveri MCP.
- Përdorni mjetet MCP përmes gjuhës natyrale.

## Qasja

Ja si duhet të qasemi në këtë në një nivel të lartë:

- Krijoni një agjent dhe përcaktoni kërkesën e sistemit të tij.
- Krijoni një server MCP me mjete kalkulatori.
- Lidhni Ndërtuesin e Agjentit me serverin MCP.
- Testoni aktivizimin e mjeteve të agjentit përmes gjuhës natyrale.

Shkëlqyeshëm, tani që kuptojmë rrjedhën, le të konfigurojmë një agjent AI për të shfrytëzuar mjetet e jashtme përmes MCP, duke përmirësuar aftësitë e tij!

## Kërkesat paraprake

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit për Visual Studio Code](https://aka.ms/AIToolkit)

## Ushtrimi: Konsumimi i një serveri

Në këtë ushtrim, do të ndërtoni, ekzekutoni dhe përmirësoni një agjent AI me mjete nga një server MCP brenda Visual Studio Code duke përdorur AI Toolkit.

### -0- Hapi paraprak, shtoni modelin OpenAI GPT-4o në Modelet e Mia

Ushtrimi përdor modelin **GPT-4o**. Modeli duhet të shtohet në **Modelet e Mia** para se të krijoni agjentin.

1. Hapni zgjerimin **AI Toolkit** nga **Activity Bar**.
1. Në seksionin **Catalog**, zgjidhni **Models** për të hapur **Model Catalog**. Zgjedhja e **Models** hap **Model Catalog** në një skedë të re redaktimi.
1. Në shiritin e kërkimit të **Model Catalog**, shkruani **OpenAI GPT-4o**.
1. Klikoni **+ Add** për të shtuar modelin në listën tuaj **My Models**. Sigurohuni që keni zgjedhur modelin që është **Hosted by GitHub**.
1. Në **Activity Bar**, konfirmoni që modeli **OpenAI GPT-4o** shfaqet në listë.

### -1- Krijoni një agjent

**Agent (Prompt) Builder** ju mundëson të krijoni dhe personalizoni agjentët tuaj të fuqizuar nga AI. Në këtë seksion, do të krijoni një agjent të ri dhe do të caktoni një model për të fuqizuar bisedën.

1. Hapni zgjerimin **AI Toolkit** nga **Activity Bar**.
1. Në seksionin **Tools**, zgjidhni **Agent (Prompt) Builder**. Zgjedhja e **Agent (Prompt) Builder** hap **Agent (Prompt) Builder** në një skedë të re redaktimi.
1. Klikoni butonin **+ New Builder**. Zgjerimi do të nisë një magjistar konfigurimi përmes **Command Palette**.
1. Shkruani emrin **Calculator Agent** dhe shtypni **Enter**.
1. Në **Agent (Prompt) Builder**, për fushën **Model**, zgjidhni modelin **OpenAI GPT-4o (via GitHub)**.

### -2- Krijoni një kërkesë sistemi për agjentin

Me agjentin e strukturuar, është koha të përcaktoni personalitetin dhe qëllimin e tij. Në këtë seksion, do të përdorni funksionin **Generate system prompt** për të përshkruar sjelljen e synuar të agjentit—në këtë rast, një agjent kalkulatori—dhe do të keni modelin që shkruan kërkesën e sistemit për ju.

1. Për seksionin **Prompts**, klikoni butonin **Generate system prompt**. Ky buton hap në ndërtuesin e kërkesave që përdor AI për të gjeneruar një kërkesë sistemi për agjentin.
1. Në dritaren **Generate a prompt**, shkruani sa vijon: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klikoni butonin **Generate**. Një njoftim do të shfaqet në këndin e poshtëm të djathtë duke konfirmuar që kërkesa e sistemit po gjenerohet. Pasi gjenerimi i kërkesës të përfundojë, kërkesa do të shfaqet në fushën **System prompt** të **Agent (Prompt) Builder**.
1. Rishikoni **System prompt** dhe modifikoni nëse është e nevojshme.

### -3- Krijoni një server MCP

Tani që keni përcaktuar kërkesën e sistemit të agjentit tuaj—duke udhëhequr sjelljen dhe përgjigjet e tij—është koha për të pajisur agjentin me aftësi praktike. Në këtë seksion, do të krijoni një server MCP kalkulatori me mjete për të kryer kalkulime mbledhjeje, zbritjeje, shumëzimi dhe pjesëtimi. Ky server do të mundësojë agjentin tuaj të kryejë operacione matematikore në kohë reale në përgjigje të kërkesave të gjuhës natyrale.

AI Toolkit është i pajisur me shabllone për lehtësinë e krijimit të serverit tuaj MCP. Ne do të përdorim shabllonin Python për krijimin e serverit MCP të kalkulatorit.

*Shënim*: AI Toolkit aktualisht mbështet Python dhe TypeScript.

1. Në seksionin **Tools** të **Agent (Prompt) Builder**, klikoni butonin **+ MCP Server**. Zgjerimi do të nisë një magjistar konfigurimi përmes **Command Palette**.
1. Zgjidhni **+ Add Server**.
1. Zgjidhni **Create a New MCP Server**.
1. Zgjidhni **python-weather** si shabllon.
1. Zgjidhni **Default folder** për të ruajtur shabllonin e serverit MCP.
1. Shkruani emrin e mëposhtëm për serverin: **Calculator**
1. Një dritare e re e Visual Studio Code do të hapet. Zgjidhni **Yes, I trust the authors**.
1. Duke përdorur terminalin (**Terminal** > **New Terminal**), krijoni një mjedis virtual: `python -m venv .venv`
1. Duke përdorur terminalin, aktivizoni mjedisin virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Duke përdorur terminalin, instaloni varësitë: `pip install -e .[dev]`
1. Në pamjen **Explorer** të **Activity Bar**, zgjeroni direktorinë **src** dhe zgjidhni **server.py** për të hapur skedarin në redaktor.
1. Zëvendësoni kodin në skedarin **server.py** me sa vijon dhe ruajeni:

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

### -4- Ekzekutoni agjentin me serverin MCP të kalkulatorit

Tani që agjenti juaj ka mjete, është koha t'i përdorni ato! Në këtë seksion, do të paraqisni kërkesa agjentit për të testuar dhe verifikuar nëse agjenti përdor mjetin e duhur nga serveri MCP i kalkulatorit.

Ju do të ekzekutoni serverin MCP të kalkulatorit në makinën tuaj lokale të zhvillimit përmes **Agent Builder** si klient MCP.

1. Shtypni `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Bleva 3 artikuj të çmuar me $25 secili, dhe pastaj përdora një zbritje prej $20. Sa pagova?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` vlerat janë caktuar për mjetin **subtract**.
    - Përgjigja nga secili mjet jepet në **Tool Response** përkatës.
    - Rezultati përfundimtar nga modeli jepet në **Model Response** përfundimtar.
1. Paraqisni kërkesa shtesë për të testuar më tej agjentin. Mund të modifikoni kërkesën ekzistuese në fushën **User prompt** duke klikuar në fushë dhe duke zëvendësuar kërkesën ekzistuese.
1. Pasi të keni mbaruar testimin e agjentit, mund të ndaloni serverin përmes **terminalit** duke shtypur **CTRL/CMD+C** për të dalë.

## Detyra

Provoni të shtoni një hyrje mjeti shtesë në skedarin tuaj **server.py** (p.sh.: ktheni rrënjën katrore të një numri). Paraqisni kërkesa shtesë që do të kërkonin agjentin për të përdorur mjetin tuaj të ri (ose mjetet ekzistuese). Sigurohuni që të rinisni serverin për të ngarkuar mjetet e saposhtuara.

## Zgjidhja

[Zgjidhja](./solution/README.md)

## Përmbledhjet kryesore

Përmbledhjet nga ky kapitull janë si vijon:

- Zgjerimi AI Toolkit është një klient i shkëlqyer që ju lejon të konsumoni serverët MCP dhe mjetet e tyre.
- Mund të shtoni mjete të reja në serverët MCP, duke zgjeruar aftësitë e agjentit për të përmbushur kërkesat në zhvillim.
- AI Toolkit përfshin shabllone (p.sh., shabllonet e serverit MCP të Python) për të thjeshtuar krijimin e mjeteve të personalizuara.

## Burime shtesë

- [Dokumentet e AI Toolkit](https://aka.ms/AIToolkit/doc)

## Çfarë është më pas

Tjetra: [Mësimi 4 Zbatimi Praktik](/04-PracticalImplementation/README.md)

I'm sorry, but I am unable to translate text into "mo" as it is not a recognized language. Could you please provide more information or clarify your request?