<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:28:42+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "cs"
}
-->
# Spotřeba serveru z rozšíření AI Toolkit pro Visual Studio Code

Když vytváříte AI agenta, nejde jen o generování chytrých odpovědí; je také důležité dát agentovi schopnost jednat. A právě zde přichází na scénu Model Context Protocol (MCP). MCP usnadňuje agentům přístup k externím nástrojům a službám konzistentním způsobem. Představte si to jako připojení vašeho agenta k sadě nástrojů, které může *skutečně* používat.

Řekněme, že připojíte agenta k MCP serveru kalkulačky. Najednou váš agent může provádět matematické operace jen tím, že obdrží výzvu jako „Kolik je 47 krát 89?“—není potřeba hardcodovat logiku nebo vytvářet vlastní API.

## Přehled

Tato lekce pokrývá, jak připojit MCP server kalkulačky k agentovi pomocí rozšíření [AI Toolkit](https://aka.ms/AIToolkit) ve Visual Studio Code, což umožní vašemu agentovi provádět matematické operace jako sčítání, odčítání, násobení a dělení prostřednictvím přirozeného jazyka.

AI Toolkit je mocné rozšíření pro Visual Studio Code, které zjednodušuje vývoj agentů. AI inženýři mohou snadno vytvářet AI aplikace vyvíjením a testováním generativních AI modelů—lokálně nebo v cloudu. Rozšíření podporuje většinu hlavních generativních modelů dostupných dnes.

*Poznámka*: AI Toolkit aktuálně podporuje Python a TypeScript.

## Cíle učení

Na konci této lekce budete schopni:

- Spotřebovat MCP server přes AI Toolkit.
- Konfigurovat konfiguraci agenta, aby mu umožnila objevit a využívat nástroje poskytované MCP serverem.
- Využívat MCP nástroje prostřednictvím přirozeného jazyka.

## Přístup

Zde je, jak bychom měli k tomu přistoupit na vysoké úrovni:

- Vytvořit agenta a definovat jeho systémovou výzvu.
- Vytvořit MCP server s nástroji kalkulačky.
- Připojit Agent Builder k MCP serveru.
- Otestovat vyvolání nástroje agenta prostřednictvím přirozeného jazyka.

Skvělé, teď když chápeme tok, pojďme konfigurovat AI agenta, aby využíval externí nástroje prostřednictvím MCP, čímž zlepšíme jeho schopnosti!

## Předpoklady

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pro Visual Studio Code](https://aka.ms/AIToolkit)

## Cvičení: Spotřeba serveru

V tomto cvičení vytvoříte, spustíte a zlepšíte AI agenta s nástroji z MCP serveru uvnitř Visual Studio Code pomocí AI Toolkit.

### -0- Předsunutý krok, přidejte model OpenAI GPT-4o do Moje modely

Cvičení využívá model **GPT-4o**. Model by měl být přidán do **Moje modely** před vytvořením agenta.

1. Otevřete rozšíření **AI Toolkit** z **Activity Bar**.
1. V sekci **Catalog** vyberte **Models**, aby se otevřel **Model Catalog**. Výběrem **Models** se otevře **Model Catalog** v novém editoru.
1. V vyhledávacím poli **Model Catalog** zadejte **OpenAI GPT-4o**.
1. Klikněte na **+ Add**, aby se model přidal do vašeho seznamu **Moje modely**. Ujistěte se, že jste vybrali model, který je **Hosted by GitHub**.
1. V **Activity Bar** potvrďte, že se model **OpenAI GPT-4o** objeví v seznamu.

### -1- Vytvořit agenta

**Agent (Prompt) Builder** vám umožňuje vytvářet a přizpůsobovat vlastní AI-poháněné agenty. V této části vytvoříte nového agenta a přiřadíte mu model, který pohání konverzaci.

1. Otevřete rozšíření **AI Toolkit** z **Activity Bar**.
1. V sekci **Tools** vyberte **Agent (Prompt) Builder**. Výběrem **Agent (Prompt) Builder** se otevře **Agent (Prompt) Builder** v novém editoru.
1. Klikněte na tlačítko **+ New Builder**. Rozšíření spustí průvodce nastavením přes **Command Palette**.
1. Zadejte název **Calculator Agent** a stiskněte **Enter**.
1. V **Agent (Prompt) Builder**, pro pole **Model**, vyberte model **OpenAI GPT-4o (via GitHub)**.

### -2- Vytvořit systémovou výzvu pro agenta

S agentem vytvořeným, je čas definovat jeho osobnost a účel. V této části použijete funkci **Generate system prompt**, abyste popsali zamýšlené chování agenta—v tomto případě kalkulačkového agenta—a nechali model napsat systémovou výzvu za vás.

1. Pro sekci **Prompts** klikněte na tlačítko **Generate system prompt**. Toto tlačítko otevře v prompt builderu, který využívá AI k vytvoření systémové výzvy pro agenta.
1. V okně **Generate a prompt** zadejte následující: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klikněte na tlačítko **Generate**. V pravém dolním rohu se objeví oznámení, které potvrdí, že systémová výzva se generuje. Jakmile je generování výzvy dokončeno, výzva se objeví v poli **System prompt** v **Agent (Prompt) Builder**.
1. Prohlédněte si **System prompt** a v případě potřeby upravte.

### -3- Vytvořit MCP server

Teď, když jste definovali systémovou výzvu vašeho agenta—řídící jeho chování a odpovědi—je čas vybavit agenta praktickými schopnostmi. V této části vytvoříte MCP server kalkulačky s nástroji pro provádění výpočtů sčítání, odčítání, násobení a dělení. Tento server umožní vašemu agentovi provádět matematické operace v reálném čase v reakci na přirozené jazykové výzvy.

AI Toolkit je vybaven šablonami pro usnadnění vytváření vlastního MCP serveru. Použijeme Python šablonu pro vytvoření MCP serveru kalkulačky.

1. V sekci **Tools** v **Agent (Prompt) Builder** klikněte na tlačítko **+ MCP Server**. Rozšíření spustí průvodce nastavením přes **Command Palette**.
1. Vyberte **+ Add Server**.
1. Vyberte **Create a New MCP Server**.
1. Vyberte **python-weather** jako šablonu.
1. Vyberte **Default folder** pro uložení šablony MCP serveru.
1. Zadejte následující název pro server: **Calculator**
1. Otevře se nové okno Visual Studio Code. Vyberte **Yes, I trust the authors**.
1. Pomocí terminálu (**Terminal** > **New Terminal**) vytvořte virtuální prostředí: `python -m venv .venv`
1. Pomocí terminálu aktivujte virtuální prostředí:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Pomocí terminálu nainstalujte závislosti: `pip install -e .[dev]`
1. V **Explorer** pohledu **Activity Bar** rozbalte adresář **src** a vyberte **server.py**, aby se soubor otevřel v editoru.
1. Nahraďte kód v souboru **server.py** následujícím a uložte:

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

### -4- Spustit agenta s MCP serverem kalkulačky

Teď, když má váš agent nástroje, je čas je použít! V této části zadáte výzvy agentovi, abyste otestovali a ověřili, zda agent využívá příslušný nástroj z MCP serveru kalkulačky.

Budete spouštět MCP server kalkulačky na svém lokálním vývojovém počítači přes **Agent Builder** jako MCP klienta.

1. Stiskněte `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Koupil jsem 3 položky za cenu $25 každá a pak použil slevu $20. Kolik jsem zaplatil?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` hodnoty jsou přiřazeny pro nástroj **subtract**.
    - Odpověď z každého nástroje je poskytnuta v příslušném **Tool Response**.
    - Konečný výstup z modelu je poskytnut v konečné **Model Response**.
1. Zadejte další výzvy pro další testování agenta. Můžete upravit existující výzvu v poli **User prompt** kliknutím do pole a nahrazením stávající výzvy.
1. Jakmile dokončíte testování agenta, můžete server zastavit přes **terminal** zadáním **CTRL/CMD+C** pro ukončení.

## Úkol

Zkuste přidat další položku nástroje do souboru **server.py** (např. vrátit odmocninu čísla). Zadejte další výzvy, které by vyžadovaly, aby agent využil váš nový nástroj (nebo stávající nástroje). Ujistěte se, že restartujete server pro načtení nově přidaných nástrojů.

## Řešení

[Řešení](./solution/README.md)

## Klíčové poznatky

Poznatky z této kapitoly jsou následující:

- Rozšíření AI Toolkit je skvělý klient, který vám umožňuje spotřebovat MCP servery a jejich nástroje.
- Můžete přidat nové nástroje do MCP serverů, čímž rozšíříte schopnosti agenta, aby splňoval měnící se požadavky.
- AI Toolkit obsahuje šablony (např. Python MCP server šablony) pro zjednodušení tvorby vlastních nástrojů.

## Další zdroje

- [AI Toolkit dokumentace](https://aka.ms/AIToolkit/doc)

## Co dál

Dále: [Lekce 4 Praktická implementace](/04-PracticalImplementation/README.md)

**Upozornění**:  
Tento dokument byl přeložen pomocí služby AI pro překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, uvědomte si prosím, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme zodpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.