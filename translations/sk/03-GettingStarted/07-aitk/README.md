<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:40:33+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sk"
}
-->
# Používanie servera z rozšírenia AI Toolkit pre Visual Studio Code

Keď vytvárate AI agenta, nejde len o generovanie inteligentných odpovedí; ide aj o to, aby váš agent vedel konať. Práve tu prichádza na scénu Model Context Protocol (MCP). MCP umožňuje agentom jednoducho pristupovať k externým nástrojom a službám konzistentným spôsobom. Predstavte si to ako pripojenie agenta k nástrojovej skrinke, ktorú *skutočne* vie použiť.

Povedzme, že pripojíte agenta k vášmu kalkulačnému MCP serveru. Náhle môže agent vykonávať matematické operácie len na základe otázky ako „Koľko je 47 krát 89?“ — bez potreby pevne zakódovanej logiky alebo vytvárania vlastných API.

## Prehľad

Táto lekcia ukazuje, ako pripojiť kalkulačný MCP server k agentovi pomocou rozšírenia [AI Toolkit](https://aka.ms/AIToolkit) vo Visual Studio Code, čím umožníte agentovi vykonávať matematické operácie ako sčítanie, odčítanie, násobenie a delenie prostredníctvom prirodzeného jazyka.

AI Toolkit je výkonné rozšírenie pre Visual Studio Code, ktoré zjednodušuje vývoj agentov. AI inžinieri môžu jednoducho vytvárať AI aplikácie vývojom a testovaním generatívnych AI modelov – lokálne alebo v cloude. Rozšírenie podporuje väčšinu dnešných hlavných generatívnych modelov.

*Poznámka*: AI Toolkit momentálne podporuje Python a TypeScript.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Používať MCP server cez AI Toolkit.
- Nakonfigurovať agentovú konfiguráciu tak, aby mohol objavovať a využívať nástroje poskytované MCP serverom.
- Využívať MCP nástroje prostredníctvom prirodzeného jazyka.

## Prístup

Takto by sme mali postupovať na vysokej úrovni:

- Vytvoriť agenta a definovať jeho systémový prompt.
- Vytvoriť MCP server s kalkulačnými nástrojmi.
- Pripojiť Agent Builder k MCP serveru.
- Otestovať vyvolávanie nástrojov agenta cez prirodzený jazyk.

Skvelé, keď už chápeme postup, nakonfigurujme AI agenta tak, aby využíval externé nástroje cez MCP a rozšíril tak svoje schopnosti!

## Požiadavky

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pre Visual Studio Code](https://aka.ms/AIToolkit)

## Cvičenie: Používanie servera

V tomto cvičení vytvoríte, spustíte a vylepšíte AI agenta s nástrojmi z MCP servera priamo vo Visual Studio Code pomocou AI Toolkit.

### -0- Predkrok, pridajte model OpenAI GPT-4o do My Models

Cvičenie využíva model **GPT-4o**. Model by mal byť pridaný do **My Models** pred vytvorením agenta.

![Screenshot rozhrania výberu modelu v rozšírení AI Toolkit pre Visual Studio Code. Nadpis znie "Find the right model for your AI Solution" s podnadpisom vyzývajúcim používateľov objavovať, testovať a nasadzovať AI modely. Pod tým, v sekcii “Popular Models,” je zobrazených šesť modelov: DeepSeek-R1 (hostované na GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) a DeepSeek-R1 (hostované na Ollama). Každá karta obsahuje možnosti “Add” alebo “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.sk.png)

1. Otvorte rozšírenie **AI Toolkit** z **Activity Bar**.
1. V sekcii **Catalog** vyberte **Models** pre otvorenie **Model Catalog**. Výberom **Models** sa otvorí **Model Catalog** v novej karte editora.
1. Do vyhľadávacieho poľa v **Model Catalog** zadajte **OpenAI GPT-4o**.
1. Kliknite na **+ Add** pre pridanie modelu do zoznamu **My Models**. Uistite sa, že ste vybrali model, ktorý je **hostovaný na GitHub**.
1. V **Activity Bar** skontrolujte, či sa model **OpenAI GPT-4o** zobrazuje v zozname.

### -1- Vytvorte agenta

**Agent (Prompt) Builder** vám umožňuje vytvoriť a prispôsobiť vlastných AI agentov. V tejto časti vytvoríte nového agenta a priradíte mu model, ktorý bude poháňať konverzáciu.

![Screenshot rozhrania "Calculator Agent" v AI Toolkit pre Visual Studio Code. V ľavom paneli je vybraný model "OpenAI GPT-4o (via GitHub)." Systémový prompt znie "You are a professor in university teaching math," a užívateľský prompt hovorí "Explain to me the Fourier equation in simple terms." Ďalšie možnosti zahŕňajú tlačidlá na pridanie nástrojov, povolenie MCP Server a výber štruktúrovaného výstupu. Modré tlačidlo “Run” je v spodnej časti. V pravom paneli sú pod "Get Started with Examples" tri ukážkové agenti: Web Developer (s MCP Server, Second-Grade Simplifier a Dream Interpreter, každý s krátkym popisom funkcií).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.sk.png)

1. Otvorte rozšírenie **AI Toolkit** z **Activity Bar**.
1. V sekcii **Tools** vyberte **Agent (Prompt) Builder**. Výberom sa otvorí **Agent (Prompt) Builder** v novej karte editora.
1. Kliknite na tlačidlo **+ New Agent**. Rozšírenie spustí sprievodcu nastavením cez **Command Palette**.
1. Zadajte názov **Calculator Agent** a stlačte **Enter**.
1. V **Agent (Prompt) Builder** v poli **Model** vyberte model **OpenAI GPT-4o (via GitHub)**.

### -2- Vytvorte systémový prompt pre agenta

Keď máte agenta pripraveného, je čas definovať jeho osobnosť a účel. V tejto časti použijete funkciu **Generate system prompt** na opísanie správania agenta – v tomto prípade kalkulačného agenta – a model necháte vytvoriť systémový prompt za vás.

![Screenshot rozhrania "Calculator Agent" v AI Toolkit pre Visual Studio Code s otvoreným modálnym oknom s názvom "Generate a prompt." Okno vysvetľuje, že prompt šablóna môže byť vygenerovaná zdieľaním základných údajov a obsahuje textové pole s ukážkovým systémovým promptom: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Pod textovým poľom sú tlačidlá "Close" a "Generate." V pozadí je viditeľná časť konfigurácie agenta vrátane vybraného modelu "OpenAI GPT-4o (via GitHub)" a polí pre systémový a užívateľský prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.sk.png)

1. V sekcii **Prompts** kliknite na tlačidlo **Generate system prompt**. Toto tlačidlo otvorí tvorcu promptov, ktorý využíva AI na generovanie systémového promptu pre agenta.
1. V okne **Generate a prompt** zadajte: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknite na tlačidlo **Generate**. V pravom dolnom rohu sa zobrazí notifikácia potvrdzujúca generovanie systémového promptu. Po dokončení sa prompt zobrazí v poli **System prompt** v **Agent (Prompt) Builder**.
1. Skontrolujte systémový prompt a podľa potreby ho upravte.

### -3- Vytvorte MCP server

Keď ste definovali systémový prompt agenta – ktorý riadi jeho správanie a odpovede – je čas vybaviť agenta praktickými schopnosťami. V tejto časti vytvoríte kalkulačný MCP server s nástrojmi na vykonávanie sčítania, odčítania, násobenia a delenia. Tento server umožní agentovi vykonávať matematické operácie v reálnom čase na základe prirodzených jazykových požiadaviek.

![Screenshot spodnej časti rozhrania Calculator Agent v AI Toolkit pre Visual Studio Code. Zobrazuje rozbaľovacie menu pre “Tools” a “Structure output,” spolu s rozbaľovacím menu “Choose output format” nastaveným na “text.” Vpravo je tlačidlo “+ MCP Server” na pridanie Model Context Protocol servera. Nad sekciou Tools je zástupný obrázok ikony.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.sk.png)

AI Toolkit je vybavený šablónami, ktoré uľahčujú vytváranie vlastných MCP serverov. Použijeme Python šablónu na vytvorenie kalkulačného MCP servera.

*Poznámka*: AI Toolkit momentálne podporuje Python a TypeScript.

1. V sekcii **Tools** v **Agent (Prompt) Builder** kliknite na tlačidlo **+ MCP Server**. Rozšírenie spustí sprievodcu nastavením cez **Command Palette**.
1. Vyberte **+ Add Server**.
1. Vyberte **Create a New MCP Server**.
1. Vyberte šablónu **python-weather**.
1. Vyberte **Default folder** pre uloženie MCP server šablóny.
1. Zadajte názov servera: **Calculator**
1. Otvorí sa nové okno Visual Studio Code. Vyberte **Yes, I trust the authors**.
1. V termináli (**Terminal** > **New Terminal**) vytvorte virtuálne prostredie: `python -m venv .venv`
1. Aktivujte virtuálne prostredie v termináli:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Nainštalujte závislosti: `pip install -e .[dev]`
1. V zobrazení **Explorer** v **Activity Bar** rozbaľte adresár **src** a vyberte súbor **server.py** na otvorenie v editore.
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

### -4- Spustite agenta s kalkulačným MCP serverom

Keď má váš agent nástroje, je čas ich použiť! V tejto časti zadáte agentovi požiadavky, aby ste otestovali a overili, či agent využíva správny nástroj z kalkulačného MCP servera.

![Screenshot rozhrania Calculator Agent v AI Toolkit pre Visual Studio Code. V ľavom paneli, pod “Tools,” je pridaný MCP server s názvom local-server-calculator_server, ktorý zobrazuje štyri dostupné nástroje: add, subtract, multiply a divide. Odznak ukazuje, že štyri nástroje sú aktívne. Pod tým je zbalená sekcia “Structure output” a modré tlačidlo “Run.” V pravom paneli, pod “Model Response,” agent vyvoláva nástroje multiply a subtract s vstupmi {"a": 3, "b": 25} a {"a": 75, "b": 20}. Konečná “Tool Response” je 75.0. V spodnej časti je tlačidlo “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.sk.png)

Spustíte kalkulačný MCP server na vašom lokálnom vývojovom stroji cez **Agent Builder** ako MCP klienta.

1. Stlačte `F5` pre spustenie ladenia MCP servera. **Agent (Prompt) Builder** sa otvorí v novej karte editora. Stav servera je viditeľný v termináli.
1. Do poľa **User prompt** v **Agent (Prompt) Builder** zadajte: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Kliknite na tlačidlo **Run** pre vygenerovanie odpovede agenta.
1. Skontrolujte výstup agenta. Model by mal dospieť k záveru, že ste zaplatili **$55**.
1. Tu je rozpis, čo by sa malo stať:
    - Agent vyberie nástroje **multiply** a **subtract** na pomoc pri výpočte.
    - Priradia sa príslušné hodnoty `a` a `b` pre nástroj **multiply**.
    - Priradia sa príslušné hodnoty `a` a `b` pre nástroj **subtract**.
    - Odpovede z jednotlivých nástrojov sa zobrazia v príslušnej sekcii **Tool Response**.
    - Konečný výstup modelu sa zobrazí v sekcii **Model Response**.
1. Zadajte ďalšie požiadavky na ďalšie testovanie agenta. Existujúci prompt môžete upraviť kliknutím do poľa **User prompt** a jeho prepísaním.
1. Po dokončení testovania môžete server zastaviť v termináli stlačením **CTRL/CMD+C**.

## Zadanie

Skúste pridať ďalší nástroj do vášho súboru **server.py** (napr. vrátiť druhú odmocninu čísla). Zadajte ďalšie požiadavky, ktoré budú vyžadovať, aby agent využil váš nový nástroj (alebo existujúce nástroje). Nezabudnite reštartovať server, aby sa nové nástroje načítali.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Z tohto kapitoly si odnášame:

- Rozšírenie AI Toolkit je skvelý klient, ktorý umožňuje využívať MCP servery a ich nástroje.
- Môžete pridávať nové nástroje do MCP serverov, čím rozširujete schopnosti agenta podľa rastúcich požiadaviek.
- AI Toolkit obsahuje šablóny (napr. Python MCP server šablóny), ktoré zjednodušujú vytváranie vlastných nástrojov.

## Ďalšie zdroje

- [Dokumentácia AI Toolkit](https://aka.ms/AIToolkit/doc)

## Čo ďalej
- Ďalšie: [Testovanie a ladenie](../08-testing/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.