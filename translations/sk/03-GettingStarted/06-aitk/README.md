<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:49:54+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sk"
}
-->
# Používanie servera z rozšírenia AI Toolkit pre Visual Studio Code

Keď vytvárate AI agenta, nejde len o generovanie inteligentných odpovedí; ide aj o to, aby váš agent mohol konať. Práve tu prichádza na scénu Model Context Protocol (MCP). MCP umožňuje agentom jednoduchý a konzistentný prístup k externým nástrojom a službám. Predstavte si to ako zapojenie agenta do nástrojovej skrinky, ktorú *skutočne* vie využiť.

Napríklad, keď prepojíte agenta so serverom MCP kalkulačky, váš agent môže vykonávať matematické operácie len na základe zadania otázky ako „Koľko je 47 krát 89?“ — bez potreby písať logiku na pevno alebo vytvárať vlastné API.

## Prehľad

Táto lekcia vysvetľuje, ako prepojiť server MCP kalkulačky s agentom pomocou rozšírenia [AI Toolkit](https://aka.ms/AIToolkit) vo Visual Studio Code, čím umožníte agentovi vykonávať matematické operácie ako sčítanie, odčítanie, násobenie a delenie pomocou prirodzeného jazyka.

AI Toolkit je výkonné rozšírenie pre Visual Studio Code, ktoré zjednodušuje vývoj agentov. AI inžinieri môžu jednoducho vytvárať AI aplikácie vývojom a testovaním generatívnych AI modelov — lokálne alebo v cloude. Rozšírenie podporuje väčšinu dnešných hlavných generatívnych modelov.

*Poznámka*: AI Toolkit momentálne podporuje Python a TypeScript.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Spotrebovať MCP server cez AI Toolkit.
- Nakonfigurovať agentovú konfiguráciu tak, aby mohol objavovať a využívať nástroje poskytované MCP serverom.
- Používať MCP nástroje cez prirodzený jazyk.

## Postup

Takto by sme mali postupovať na vyššej úrovni:

- Vytvoriť agenta a definovať jeho systémový prompt.
- Vytvoriť MCP server s kalkulačnými nástrojmi.
- Prepojiť Agent Builder so serverom MCP.
- Otestovať vyvolávanie nástrojov agenta cez prirodzený jazyk.

Skvelé, keď už chápeme postup, nakonfigurujme AI agenta tak, aby využíval externé nástroje cez MCP a tým rozšíril svoje schopnosti!

## Požiadavky

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pre Visual Studio Code](https://aka.ms/AIToolkit)

## Cvičenie: Použitie servera

V tomto cvičení vytvoríte, spustíte a vylepšíte AI agenta s nástrojmi z MCP servera priamo vo Visual Studio Code pomocou AI Toolkit.

### -0- Predpríprava: pridajte model OpenAI GPT-4o do My Models

Cvičenie využíva model **GPT-4o**. Tento model by mal byť pridaný do **My Models** ešte pred vytvorením agenta.

![Screenshot výberu modelu v rozšírení AI Toolkit vo Visual Studio Code. Nadpis hovorí "Find the right model for your AI Solution" a podnadpis vyzýva používateľov, aby objavovali, testovali a nasadzovali AI modely. Pod tým, v sekcii “Popular Models,” je zobrazených šesť modelov: DeepSeek-R1 (hostované na GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - malý, rýchly) a DeepSeek-R1 (hostované na Ollama). Každá karta obsahuje možnosť “Add” alebo “Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.sk.png)

1. Otvorte rozšírenie **AI Toolkit** z **Activity Bar**.
2. V sekcii **Catalog** vyberte **Models** pre otvorenie **Model Catalog**. Výberom **Models** sa Model Catalog otvorí v novej záložke editora.
3. Do vyhľadávacieho poľa v **Model Catalog** zadajte **OpenAI GPT-4o**.
4. Kliknite na **+ Add** pre pridanie modelu do zoznamu **My Models**. Uistite sa, že ste vybrali model **Hosted by GitHub**.
5. V **Activity Bar** si overte, že model **OpenAI GPT-4o** sa zobrazuje v zozname.

### -1- Vytvorenie agenta

**Agent (Prompt) Builder** vám umožňuje vytvoriť a prispôsobiť vlastných AI agentov. V tejto časti vytvoríte nového agenta a priradíte mu model, ktorý bude poháňať konverzáciu.

![Screenshot rozhrania "Calculator Agent" v AI Toolkit rozšírení pre Visual Studio Code. Na ľavej strane je vybraný model "OpenAI GPT-4o (via GitHub)." Systémový prompt znie "You are a professor in university teaching math," a užívateľský prompt hovorí "Explain to me the Fourier equation in simple terms." Ďalšie možnosti zahŕňajú tlačidlá na pridanie nástrojov, povolenie MCP Servera a výber štruktúrovaného výstupu. V spodnej časti je modré tlačidlo “Run.” Na pravej strane sú uvedené tri ukážkové agenti s krátkymi popismi.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.sk.png)

1. Otvorte rozšírenie **AI Toolkit** z **Activity Bar**.
2. V sekcii **Tools** vyberte **Agent (Prompt) Builder**. Otvorí sa nová záložka editora s týmto nástrojom.
3. Kliknite na tlačidlo **+ New Agent**. Rozšírenie spustí sprievodcu nastavením cez **Command Palette**.
4. Zadajte názov **Calculator Agent** a stlačte **Enter**.
5. V **Agent (Prompt) Builder** v poli **Model** vyberte model **OpenAI GPT-4o (via GitHub)**.

### -2- Vytvorenie systémového promptu pre agenta

Keď už máte agenta nastaveného, je čas definovať jeho osobnosť a účel. V tejto časti použijete funkciu **Generate system prompt**, ktorá popíše správanie agenta — v tomto prípade kalkulačného agenta — a model pre vás vytvorí systémový prompt.

![Screenshot rozhrania "Calculator Agent" v AI Toolkit pre Visual Studio Code s otvoreným dialógom "Generate a prompt." Dialóg vysvetľuje, že možno vygenerovať šablónu promptu zadaním základných údajov a obsahuje textové pole s príkladom systémového promptu: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Pod textovým poľom sú tlačidlá "Close" a "Generate." V pozadí je vidieť časť konfigurácie agenta vrátane vybraného modelu a polí pre systémový a užívateľský prompt.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.sk.png)

1. V sekcii **Prompts** kliknite na tlačidlo **Generate system prompt**. Otvorí sa prompt builder, ktorý využíva AI na vytvorenie systémového promptu pre agenta.
2. V okne **Generate a prompt** zadajte: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Kliknite na tlačidlo **Generate**. V pravom dolnom rohu sa zobrazí notifikácia o generovaní systémového promptu. Po dokončení sa prompt zobrazí v poli **System prompt** v **Agent (Prompt) Builder**.
4. Skontrolujte systémový prompt a podľa potreby ho upravte.

### -3- Vytvorenie MCP servera

Keď ste definovali systémový prompt, ktorý riadi správanie a odpovede agenta, je čas vybaviť ho praktickými schopnosťami. V tejto časti vytvoríte MCP server kalkulačky s nástrojmi na sčítanie, odčítanie, násobenie a delenie. Tento server umožní agentovi vykonávať matematické operácie v reálnom čase na základe prirodzeného jazyka.

!["Screenshot spodnej časti rozhrania Calculator Agent v AI Toolkit pre Visual Studio Code. Zobrazené sú rozbaľovacie menu “Tools” a “Structure output,” spolu s rozbaľovacím menu “Choose output format” nastaveným na “text.” Vpravo je tlačidlo “+ MCP Server” na pridanie Model Context Protocol servera. Nad sekciou Tools je zástupný obrázok ikony.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.sk.png)

AI Toolkit obsahuje šablóny, ktoré uľahčujú vytváranie vlastných MCP serverov. Použijeme Python šablónu na vytvorenie kalkulačného MCP servera.

*Poznámka*: AI Toolkit momentálne podporuje Python a TypeScript.

1. V sekcii **Tools** v **Agent (Prompt) Builder** kliknite na tlačidlo **+ MCP Server**. Rozšírenie spustí sprievodcu nastavením cez **Command Palette**.
2. Vyberte **+ Add Server**.
3. Vyberte **Create a New MCP Server**.
4. Vyberte šablónu **python-weather**.
5. Vyberte **Default folder** na uloženie MCP server šablóny.
6. Zadajte názov servera: **Calculator**
7. Otvorí sa nové okno Visual Studio Code. Potvrďte **Yes, I trust the authors**.
8. V termináli (**Terminal** > **New Terminal**) vytvorte virtuálne prostredie: `python -m venv .venv`
9. V termináli aktivujte virtuálne prostredie:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. V termináli nainštalujte závislosti: `pip install -e .[dev]`
11. V **Explorer** v **Activity Bar** rozbaľte priečinok **src** a otvorte súbor **server.py**.
12. Nahraďte kód v **server.py** nasledujúcim obsahom a uložte:

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

Keď má agent nástroje, je čas ich použiť! V tejto časti zadáte agentovi prompt, aby ste otestovali, či využíva správne nástroje z kalkulačného MCP servera.

![Screenshot rozhrania Calculator Agent v AI Toolkit pre Visual Studio Code. Na ľavej strane v sekcii “Tools” je pridaný MCP server s názvom local-server-calculator_server, ktorý zobrazuje štyri dostupné nástroje: add, subtract, multiply a divide. Je vidieť odznak s počtom štyroch aktívnych nástrojov. Pod tým je zbalená sekcia “Structure output” a modré tlačidlo “Run.” Na pravej strane v sekcii “Model Response” agent volá nástroje multiply a subtract so vstupmi {"a": 3, "b": 25} a {"a": 75, "b": 20}. Konečná odpoveď nástroja je 75.0. V spodnej časti je tlačidlo “View Code.”](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.sk.png)

Server MCP kalkulačky spustíte lokálne ako klient MCP cez **Agent Builder**.

1. Stlačte `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` hodnoty sú priradené pre nástroj **subtract**.
    - Odpoveď z každého nástroja sa zobrazí v príslušnom poli **Tool Response**.
    - Konečný výstup modelu je zobrazený v poli **Model Response**.
2. Zadajte ďalšie prompty na ďalšie testovanie agenta. Môžete upraviť existujúci prompt v poli **User prompt** kliknutím do poľa a prepísaním.
3. Po dokončení testovania môžete server zastaviť v termináli stlačením **CTRL/CMD+C**.

## Zadanie

Skúste do svojho súboru **server.py** pridať ďalší nástroj (napr. výpočet druhého koreňa čísla). Potom zadajte ďalšie prompty, ktoré budú vyžadovať použitie vášho nového (alebo existujúcich) nástrojov. Nezabudnite reštartovať server, aby sa nové nástroje načítali.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Z tohto kapitolu si odnášame:

- Rozšírenie AI Toolkit je skvelý klient, ktorý umožňuje používať MCP Servery a ich nástroje.
- Môžete pridávať nové nástroje do MCP serverov, čím rozšírite schopnosti agenta podľa aktuálnych požiadaviek.
- AI Toolkit obsahuje šablóny (napr. Python MCP server šablóny), ktoré zjednodušujú tvorbu vlastných nástrojov.

## Ďalšie zdroje

- [Dokumentácia AI Toolkit](https://aka.ms/AIToolkit/doc)

## Čo ďalej

Ďalej: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.