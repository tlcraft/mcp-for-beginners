<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:27:23+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sk"
}
-->
# Používanie servera z rozšírenia AI Toolkit pre Visual Studio Code

Keď vytvárate AI agenta, nejde len o generovanie inteligentných odpovedí; ide aj o to, aby váš agent vedel konať. Práve tu prichádza na scénu Model Context Protocol (MCP). MCP umožňuje agentom jednoducho pristupovať k externým nástrojom a službám konzistentným spôsobom. Predstavte si to ako pripojenie vášho agenta do skrinky s nástrojmi, ktorú *skutočne* vie využiť.

Povedzme, že prepojíte agenta so serverom MCP kalkulačky. Náhle môže váš agent vykonávať matematické operácie len na základe príkazu ako „Koľko je 47 krát 89?“ — bez potreby pevne zakódovanej logiky alebo vytvárania vlastných API.

## Prehľad

Táto lekcia ukazuje, ako pripojiť server MCP kalkulačky k agentovi pomocou rozšírenia [AI Toolkit](https://aka.ms/AIToolkit) vo Visual Studio Code, čím umožníte agentovi vykonávať matematické operácie ako sčítanie, odčítanie, násobenie a delenie pomocou prirodzeného jazyka.

AI Toolkit je výkonné rozšírenie pre Visual Studio Code, ktoré zjednodušuje vývoj agentov. AI inžinieri môžu jednoducho vytvárať AI aplikácie vývojom a testovaním generatívnych AI modelov — lokálne alebo v cloude. Rozšírenie podporuje väčšinu dnešných hlavných generatívnych modelov.

*Poznámka*: AI Toolkit momentálne podporuje Python a TypeScript.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Spotrebovať MCP server cez AI Toolkit.
- Nakonfigurovať agentovú konfiguráciu tak, aby mohol objavovať a využívať nástroje poskytované MCP serverom.
- Využívať nástroje MCP cez prirodzený jazyk.

## Postup

Takto by sme mali pristupovať k riešeniu na vyššej úrovni:

- Vytvoriť agenta a definovať jeho systémový prompt.
- Vytvoriť MCP server s kalkulačnými nástrojmi.
- Prepojiť Agent Builder so serverom MCP.
- Otestovať vyvolávanie nástrojov agenta cez prirodzený jazyk.

Skvelé, keď už rozumieme postupu, nakonfigurujme AI agenta tak, aby využíval externé nástroje cez MCP a rozšíril tak svoje schopnosti!

## Požiadavky

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pre Visual Studio Code](https://aka.ms/AIToolkit)

## Cvičenie: Použitie servera

V tomto cvičení vytvoríte, spustíte a vylepšíte AI agenta s nástrojmi zo servera MCP priamo vo Visual Studio Code pomocou AI Toolkit.

### -0- Predkrok, pridajte model OpenAI GPT-4o do My Models

Cvičenie využíva model **GPT-4o**. Model by mal byť pridaný do **My Models** pred vytvorením agenta.

![Screenshot výberu modelu v rozšírení AI Toolkit vo Visual Studio Code. Nadpis znie "Find the right model for your AI Solution" s podnadpisom vyzývajúcim používateľov objavovať, testovať a nasadzovať AI modely. Pod tým je zobrazených šesť modelov: DeepSeek-R1 (hostované na GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) a DeepSeek-R1 (hostované na Ollama). Každý model má možnosť “Add” alebo “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.sk.png)

1. Otvorte rozšírenie **AI Toolkit** z **Activity Bar**.
2. V sekcii **Catalog** vyberte **Models** pre otvorenie **Model Catalog**. Výberom **Models** sa otvorí **Model Catalog** v novej karte editora.
3. Do vyhľadávacieho poľa **Model Catalog** zadajte **OpenAI GPT-4o**.
4. Kliknite na **+ Add** pre pridanie modelu do vášho zoznamu **My Models**. Uistite sa, že ste vybrali model **Hosted by GitHub**.
5. V **Activity Bar** skontrolujte, či sa model **OpenAI GPT-4o** zobrazuje v zozname.

### -1- Vytvorenie agenta

**Agent (Prompt) Builder** vám umožňuje vytvárať a prispôsobovať vlastných AI agentov. V tejto časti vytvoríte nového agenta a priradíte mu model, ktorý bude poháňať konverzáciu.

![Screenshot rozhrania "Calculator Agent" v AI Toolkit pre Visual Studio Code. Na ľavej strane je vybraný model "OpenAI GPT-4o (via GitHub)." Systémový prompt znie "You are a professor in university teaching math," a užívateľský prompt je "Explain to me the Fourier equation in simple terms." Ďalšie možnosti zahŕňajú tlačidlá na pridanie nástrojov, aktiváciu MCP Server a výber štruktúrovaného výstupu. Modré tlačidlo “Run” je v spodnej časti. Na pravej strane sú tri príklady agentov: Web Developer (s MCP Server, Second-Grade Simplifier a Dream Interpreter), každý s krátkym popisom funkcií.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.sk.png)

1. Otvorte rozšírenie **AI Toolkit** z **Activity Bar**.
2. V sekcii **Tools** vyberte **Agent (Prompt) Builder**. Otvorí sa nová karta editora s **Agent (Prompt) Builder**.
3. Kliknite na tlačidlo **+ New Agent**. Rozšírenie spustí sprievodcu nastavením cez **Command Palette**.
4. Zadajte názov **Calculator Agent** a stlačte **Enter**.
5. V **Agent (Prompt) Builder** v poli **Model** vyberte model **OpenAI GPT-4o (via GitHub)**.

### -2- Vytvorenie systémového promptu pre agenta

Keď máte agenta pripraveného, je čas definovať jeho osobnosť a účel. V tejto časti použijete funkciu **Generate system prompt** na popis správania agenta — v tomto prípade kalkulačného agenta — a model za vás vytvorí systémový prompt.

![Screenshot rozhrania "Calculator Agent" v AI Toolkit pre Visual Studio Code s otvoreným oknom "Generate a prompt." Okno vysvetľuje, že prompt šablónu je možné vygenerovať zadaním základných údajov a obsahuje textové pole s ukážkovým systémovým promptom: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Pod textovým poľom sú tlačidlá "Close" a "Generate." V pozadí je viditeľná časť konfigurácie agenta vrátane vybraného modelu "OpenAI GPT-4o (via GitHub)" a polí pre systémový a užívateľský prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.sk.png)

1. V sekcii **Prompts** kliknite na tlačidlo **Generate system prompt**. Toto tlačidlo otvorí generátor promptov, ktorý využíva AI na vytvorenie systémového promptu pre agenta.
2. V okne **Generate a prompt** zadajte: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Kliknite na tlačidlo **Generate**. V pravom dolnom rohu sa zobrazí oznámenie, že sa systémový prompt generuje. Po dokončení sa prompt zobrazí v poli **System prompt** v **Agent (Prompt) Builder**.
4. Skontrolujte systémový prompt a prípadne ho upravte.

### -3- Vytvorenie MCP servera

Keď už máte definovaný systémový prompt agenta, ktorý riadi jeho správanie a odpovede, je čas vybaviť agenta praktickými schopnosťami. V tejto časti vytvoríte kalkulačný MCP server s nástrojmi na vykonávanie sčítania, odčítania, násobenia a delenia. Tento server umožní agentovi vykonávať matematické operácie v reálnom čase na základe prirodzených jazykových príkazov.

!["Screenshot dolnej časti rozhrania Calculator Agent v AI Toolkit pre Visual Studio Code. Zobrazuje rozbaľovacie menu pre “Tools” a “Structure output,” spolu s rozbaľovacím menu “Choose output format” nastaveným na “text.” Vpravo je tlačidlo “+ MCP Server” na pridanie Model Context Protocol servera. Nad sekciou Tools je ikona obrázka.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.sk.png)

AI Toolkit obsahuje šablóny, ktoré uľahčujú vytvorenie vlastného MCP servera. Použijeme Python šablónu na vytvorenie kalkulačného MCP servera.

*Poznámka*: AI Toolkit momentálne podporuje Python a TypeScript.

1. V sekcii **Tools** v **Agent (Prompt) Builder** kliknite na tlačidlo **+ MCP Server**. Rozšírenie spustí sprievodcu nastavením cez **Command Palette**.
2. Vyberte **+ Add Server**.
3. Vyberte **Create a New MCP Server**.
4. Vyberte šablónu **python-weather**.
5. Vyberte **Default folder** pre uloženie MCP server šablóny.
6. Zadajte názov servera: **Calculator**
7. Otvorí sa nové okno Visual Studio Code. Potvrďte výber **Yes, I trust the authors**.
8. V termináli (**Terminal** > **New Terminal**) vytvorte virtuálne prostredie: `python -m venv .venv`
9. Aktivujte virtuálne prostredie:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Nainštalujte závislosti: `pip install -e .[dev]`
11. V zobrazení **Explorer** v **Activity Bar** rozbaľte adresár **src** a otvorte súbor **server.py**.
12. Nahraďte kód v súbore **server.py** nasledujúcim a uložte:

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

### -4- Spustenie agenta s kalkulačným MCP serverom

Keď má váš agent nástroje, je čas ich využiť! V tejto časti odošlete agentovi príkazy, aby ste otestovali a overili, či agent správne využíva nástroje z kalkulačného MCP servera.

![Screenshot rozhrania Calculator Agent v AI Toolkit pre Visual Studio Code. Na ľavej strane v sekcii “Tools” je pridaný MCP server s názvom local-server-calculator_server, ktorý zobrazuje štyri dostupné nástroje: add, subtract, multiply a divide. Štítok ukazuje, že štyri nástroje sú aktívne. Pod tým je zbalená sekcia “Structure output” a modré tlačidlo “Run.” Na pravej strane v sekcii “Model Response” agent vyvoláva nástroje multiply a subtract s vstupmi {"a": 3, "b": 25} a {"a": 75, "b": 20}. Konečná odpoveď nástroja je 75.0. V spodnej časti je tlačidlo “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.sk.png)

Server MCP kalkulačky spustíte lokálne na vývojovom stroji cez **Agent Builder** ako MCP klienta.

1. Stlačte `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` hodnoty sú priradené pre nástroj **subtract**.
    - Odpovede z každého nástroja sa zobrazia v príslušnom poli **Tool Response**.
    - Konečný výstup modelu je zobrazený v poli **Model Response**.
2. Odošlite ďalšie príkazy na testovanie agenta. Môžete upraviť existujúci príkaz v poli **User prompt** kliknutím a prepísaním.
3. Po dokončení testovania môžete server zastaviť v termináli stlačením **CTRL/CMD+C**.

## Zadanie

Skúste pridať ďalší nástroj do vášho súboru **server.py** (napr. výpočet druhej odmocniny čísla). Odošlite ďalšie príkazy, ktoré budú vyžadovať využitie vášho nového nástroja (alebo existujúcich). Nezabudnite server reštartovať, aby sa nové nástroje načítali.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Z tejto kapitoly si odnášame:

- Rozšírenie AI Toolkit je skvelý klient, ktorý umožňuje využívať MCP servery a ich nástroje.
- Môžete pridávať nové nástroje do MCP serverov, čím rozšírite schopnosti agenta podľa meniacich sa požiadaviek.
- AI Toolkit obsahuje šablóny (napr. Python MCP server šablóny), ktoré zjednodušujú tvorbu vlastných nástrojov.

## Dodatočné zdroje

- [AI Toolkit dokumentácia](https://aka.ms/AIToolkit/doc)

## Čo ďalej
- Ďalej: [Testovanie a ladenie](/03-GettingStarted/08-testing/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.