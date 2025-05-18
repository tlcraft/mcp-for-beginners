<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:29:08+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sk"
}
-->
# Používanie servera z rozšírenia AI Toolkit pre Visual Studio Code

Keď vytvárate AI agenta, nejde len o generovanie inteligentných odpovedí; je to aj o tom, aby váš agent dokázal konať. Tu prichádza na scénu Model Context Protocol (MCP). MCP uľahčuje agentom prístup k externým nástrojom a službám konzistentným spôsobom. Predstavte si to ako pripojenie vášho agenta k nástrojovej skrinke, ktorú môže *skutočne* používať.

Povedzme, že pripojíte agenta k MCP serveru kalkulačky. Zrazu váš agent dokáže vykonávať matematické operácie len tým, že dostane výzvu ako „Koľko je 47 krát 89?“—bez potreby pevne zakódovať logiku alebo vytvárať vlastné API.

## Prehľad

Táto lekcia pokrýva, ako pripojiť MCP server kalkulačky k agentovi pomocou rozšírenia [AI Toolkit](https://aka.ms/AIToolkit) vo Visual Studio Code, čo umožní vášmu agentovi vykonávať matematické operácie, ako sú sčítanie, odčítanie, násobenie a delenie prostredníctvom prirodzeného jazyka.

AI Toolkit je silné rozšírenie pre Visual Studio Code, ktoré zjednodušuje vývoj agentov. AI inžinieri môžu ľahko vytvárať AI aplikácie vyvíjaním a testovaním generatívnych AI modelov—lokálne alebo v cloude. Rozšírenie podporuje väčšinu hlavných generatívnych modelov dostupných dnes.

*Poznámka*: AI Toolkit momentálne podporuje Python a TypeScript.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Používať MCP server cez AI Toolkit.
- Nastaviť konfiguráciu agenta, aby mohol objaviť a využívať nástroje poskytované MCP serverom.
- Využívať MCP nástroje prostredníctvom prirodzeného jazyka.

## Prístup

Tu je vysoká úroveň, ako k tomu musíme pristupovať:

- Vytvoriť agenta a definovať jeho systémovú výzvu.
- Vytvoriť MCP server s nástrojmi kalkulačky.
- Pripojiť Agent Builder k MCP serveru.
- Testovať vyvolanie nástroja agenta cez prirodzený jazyk.

Skvelé, teraz keď rozumieme toku, nakonfigurujme AI agenta, aby využíval externé nástroje prostredníctvom MCP, čím rozšírime jeho schopnosti!

## Predpoklady

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pre Visual Studio Code](https://aka.ms/AIToolkit)

## Cvičenie: Používanie servera

V tomto cvičení vytvoríte, spustíte a zlepšíte AI agenta s nástrojmi z MCP servera vo Visual Studio Code pomocou AI Toolkit.

### -0- Predkrok, pridajte model OpenAI GPT-4o do Moje Modely

Cvičenie využíva model **GPT-4o**. Model by mal byť pridaný do **Moje Modely** pred vytvorením agenta.

1. Otvorte rozšírenie **AI Toolkit** z **Activity Bar**.
1. V sekcii **Catalog** vyberte **Models** na otvorenie **Model Catalog**. Výberom **Models** sa otvorí **Model Catalog** v novom editore.
1. V **Model Catalog** vyhľadávacom poli zadajte **OpenAI GPT-4o**.
1. Kliknite na **+ Add** na pridanie modelu do zoznamu **Moje Modely**. Uistite sa, že ste vybrali model **Hosted by GitHub**.
1. V **Activity Bar** potvrďte, že model **OpenAI GPT-4o** sa zobrazuje v zozname.

### -1- Vytvorenie agenta

**Agent (Prompt) Builder** vám umožňuje vytvoriť a prispôsobiť si vlastných AI agentov. V tejto sekcii vytvoríte nového agenta a priradíte model na podporu konverzácie.

1. Otvorte rozšírenie **AI Toolkit** z **Activity Bar**.
1. V sekcii **Tools** vyberte **Agent (Prompt) Builder**. Výberom **Agent (Prompt) Builder** sa otvorí **Agent (Prompt) Builder** v novom editore.
1. Kliknite na tlačidlo **+ New Builder**. Rozšírenie spustí sprievodcu nastavením cez **Command Palette**.
1. Zadajte názov **Calculator Agent** a stlačte **Enter**.
1. V **Agent (Prompt) Builder** pre pole **Model** vyberte model **OpenAI GPT-4o (via GitHub)**.

### -2- Vytvorenie systémovej výzvy pre agenta

Keď je agent pripravený, je čas definovať jeho osobnosť a účel. V tejto sekcii použijete funkciu **Generate system prompt** na popísanie zamýšľaného správania agenta—v tomto prípade kalkulačného agenta—a necháte model napísať systémovú výzvu za vás.

1. Pre sekciu **Prompts** kliknite na tlačidlo **Generate system prompt**. Toto tlačidlo sa otvorí v nástroji na tvorbu výziev, ktorý využíva AI na generovanie systémovej výzvy pre agenta.
1. V okne **Generate a prompt** zadajte nasledujúce: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite na tlačidlo **Generate**. V pravom dolnom rohu sa zobrazí upozornenie potvrdzujúce, že systémová výzva sa generuje. Po dokončení generovania sa výzva zobrazí v poli **System prompt** v **Agent (Prompt) Builder**.
1. Skontrolujte **System prompt** a upravte, ak je to potrebné.

### -3- Vytvorenie MCP servera

Teraz, keď ste definovali systémovú výzvu vášho agenta—riadiacu jeho správanie a odpovede—je čas vybaviť agenta praktickými schopnosťami. V tejto sekcii vytvoríte MCP server kalkulačky s nástrojmi na vykonávanie výpočtov sčítania, odčítania, násobenia a delenia. Tento server umožní vášmu agentovi vykonávať matematické operácie v reálnom čase v reakcii na prirodzené jazykové výzvy.

AI Toolkit je vybavený šablónami na uľahčenie vytvorenia vlastného MCP servera. Použijeme Python šablónu na vytvorenie MCP servera kalkulačky.

*Poznámka*: AI Toolkit momentálne podporuje Python a TypeScript.

1. V sekcii **Tools** v **Agent (Prompt) Builder** kliknite na tlačidlo **+ MCP Server**. Rozšírenie spustí sprievodcu nastavením cez **Command Palette**.
1. Vyberte **+ Add Server**.
1. Vyberte **Create a New MCP Server**.
1. Vyberte **python-weather** ako šablónu.
1. Vyberte **Default folder** na uloženie šablóny MCP servera.
1. Zadajte nasledujúci názov pre server: **Calculator**
1. Otvorí sa nové okno Visual Studio Code. Vyberte **Yes, I trust the authors**.
1. Pomocou terminálu (**Terminal** > **New Terminal**) vytvorte virtuálne prostredie: `python -m venv .venv`
1. Pomocou terminálu aktivujte virtuálne prostredie:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Pomocou terminálu nainštalujte závislosti: `pip install -e .[dev]`
1. V zobrazení **Explorer** v **Activity Bar** rozbaľte adresár **src** a vyberte **server.py** na otvorenie súboru v editore.
1. Nahraďte kód v súbore **server.py** nasledujúcim a uložte:

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

### -4- Spustenie agenta s MCP serverom kalkulačky

Teraz, keď váš agent má nástroje, je čas ich použiť! V tejto sekcii odošlete výzvy agentovi, aby ste otestovali a overili, či agent využíva vhodný nástroj z MCP servera kalkulačky.

Budete spúšťať MCP server kalkulačky na vašom lokálnom vývojovom počítači cez **Agent Builder** ako MCP klient.

1. Stlačte `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Kúpil som 3 položky po 25 dolárov a potom použil zľavu 20 dolárov. Koľko som zaplatil?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` hodnoty sú priradené pre nástroj **subtract**.
    - Odpoveď z každého nástroja je poskytnutá v príslušnej **Tool Response**.
    - Konečný výstup z modelu je poskytnutý v konečnej **Model Response**.
1. Odovzdajte ďalšie výzvy, aby ste ďalej testovali agenta. Môžete upraviť existujúcu výzvu v poli **User prompt** kliknutím do poľa a nahradením existujúcej výzvy.
1. Keď dokončíte testovanie agenta, môžete zastaviť server cez **terminál** zadaním **CTRL/CMD+C** na ukončenie.

## Úloha

Skúste pridať ďalší nástroj do vášho súboru **server.py** (napr. vrátiť druhú odmocninu čísla). Odovzdajte ďalšie výzvy, ktoré by vyžadovali, aby agent využil váš nový nástroj (alebo existujúce nástroje). Uistite sa, že ste reštartovali server, aby sa načítali novo pridané nástroje.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Z tejto kapitoly si odnesiete nasledovné:

- Rozšírenie AI Toolkit je skvelý klient, ktorý vám umožňuje používať MCP servery a ich nástroje.
- Môžete pridávať nové nástroje do MCP serverov, čím rozširujete schopnosti agenta na splnenie vyvíjajúcich sa požiadaviek.
- AI Toolkit obsahuje šablóny (napr. Python MCP server šablóny) na zjednodušenie vytvárania vlastných nástrojov.

## Dodatočné zdroje

- [Dokumentácia AI Toolkit](https://aka.ms/AIToolkit/doc)

## Čo ďalej

Ďalej: [Lekcia 4 Praktická Implementácia](/04-PracticalImplementation/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by sa mal považovať za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.