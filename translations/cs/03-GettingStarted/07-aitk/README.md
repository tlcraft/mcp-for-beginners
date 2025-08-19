<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:40:08+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "cs"
}
-->
# Použití serveru z rozšíření AI Toolkit pro Visual Studio Code

Když vytváříte AI agenta, nejde jen o generování chytrých odpovědí; jde také o to, aby váš agent měl schopnost jednat. Právě zde přichází na řadu Model Context Protocol (MCP). MCP usnadňuje agentům přístup k externím nástrojům a službám jednotným způsobem. Představte si to jako připojení agenta k sadě nástrojů, kterou *opravdu* umí používat.

Řekněme, že připojíte agenta k vašemu kalkulačnímu MCP serveru. Najednou může agent provádět matematické operace jen na základě dotazu jako „Kolik je 47 krát 89?“ — bez nutnosti pevně zakódovat logiku nebo vytvářet vlastní API.

## Přehled

Tato lekce pokrývá, jak připojit MCP server kalkulačky k agentovi pomocí rozšíření [AI Toolkit](https://aka.ms/AIToolkit) ve Visual Studio Code, což umožní vašemu agentovi provádět matematické operace, jako je sčítání, odčítání, násobení a dělení, prostřednictvím přirozeného jazyka.

AI Toolkit je výkonné rozšíření pro Visual Studio Code, které usnadňuje vývoj agentů. AI inženýři mohou snadno vytvářet AI aplikace vývojem a testováním generativních AI modelů — lokálně nebo v cloudu. Rozšíření podporuje většinu hlavních generativních modelů dostupných dnes.

*Poznámka*: AI Toolkit aktuálně podporuje Python a TypeScript.

## Cíle učení

Na konci této lekce budete schopni:

- Používat MCP server prostřednictvím AI Toolkitu.
- Nakonfigurovat agenta tak, aby mohl objevovat a využívat nástroje poskytované MCP serverem.
- Využívat MCP nástroje prostřednictvím přirozeného jazyka.

## Přístup

Zde je přehledný postup, jak na to:

- Vytvořit agenta a definovat jeho systémový prompt.
- Vytvořit MCP server s nástroji kalkulačky.
- Připojit Agent Builder k MCP serveru.
- Otestovat vyvolání nástrojů agenta prostřednictvím přirozeného jazyka.

Skvělé, teď když rozumíme postupu, pojďme nakonfigurovat AI agenta, aby mohl využívat externí nástroje prostřednictvím MCP a rozšířit tak své schopnosti!

## Požadavky

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pro Visual Studio Code](https://aka.ms/AIToolkit)

## Cvičení: Použití serveru

V tomto cvičení vytvoříte, spustíte a vylepšíte AI agenta s nástroji z MCP serveru přímo ve Visual Studio Code pomocí AI Toolkit.

V tomto cvičení vytvoříte, spustíte a vylepšíte AI agenta s nástroji z MCP serveru uvnitř Visual Studio Code pomocí AI Toolkitu.

### -0- Předkrok: Přidání modelu OpenAI GPT-4o do sekce My Models

Cvičení využívá model **GPT-4o**. Model by měl být přidán do sekce **My Models** před vytvořením agenta.

1. Otevřete rozšíření **AI Toolkit** z **Activity Bar**.
1. V sekci **Catalog** vyberte **Models**, čímž otevřete **Model Catalog**. Výběr **Models** otevře **Model Catalog** v nové záložce editoru.
1. Do vyhledávacího pole **Model Catalog** zadejte **OpenAI GPT-4o**.
1. Klikněte na **+ Add** pro přidání modelu do seznamu **My Models**. Ujistěte se, že jste vybrali model, který je **hostován na GitHubu**.
1. V **Activity Bar** ověřte, že se model **OpenAI GPT-4o** objevil v seznamu.

### -1- Vytvoření agenta

**Agent (Prompt) Builder** vám umožňuje vytvořit a přizpůsobit vlastní AI agenty. V této části vytvoříte nového agenta a přiřadíte mu model, který bude pohánět konverzaci.

![Screenshot rozhraní "Calculator Agent" v AI Toolkit rozšíření pro Visual Studio Code. V levém panelu je vybraný model "OpenAI GPT-4o (via GitHub)." Systémový prompt říká "Jste profesor na univerzitě vyučující matematiku," a uživatelský prompt zní "Vysvětli mi Fourierovu rovnici jednoduše." Další možnosti zahrnují tlačítka pro přidání nástrojů, povolení MCP Serveru a výběr strukturovaného výstupu. Ve spodní části je modré tlačítko „Run“. V pravém panelu pod "Začínáme s příklady" jsou tři ukázkoví agenti: Web Developer (s MCP Serverem, zjednodušovačem pro druhou třídu a výkladem snů, každý s krátkým popisem funkcí).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.cs.png)

1. Otevřete rozšíření **AI Toolkit** z **Activity Bar**.
1. V sekci **Tools** vyberte **Agent (Prompt) Builder**. Výběr **Agent (Prompt) Builder** otevře **Agent (Prompt) Builder** v nové záložce editoru.
1. Klikněte na tlačítko **+ New Agent**. Rozšíření spustí průvodce nastavením prostřednictvím **Command Palette**.
1. Zadejte název **Calculator Agent** a stiskněte **Enter**.
1. V **Agent (Prompt) Builder** vyberte pro pole **Model** model **OpenAI GPT-4o (via GitHub)**.

### -2- Vytvoření systémového promptu pro agenta

Po vytvoření základní struktury agenta je čas definovat jeho osobnost a účel. V této části použijete funkci **Generate system prompt**, abyste popsali zamýšlené chování agenta—v tomto případě kalkulačky—a nechali model vygenerovat systémový prompt za vás.

1. V sekci **Prompts** klikněte na tlačítko **Generate system prompt**. Toto tlačítko otevře nástroj pro generování promptu, který využívá AI k vytvoření systémového promptu pro agenta.
1. V okně **Generate a prompt** zadejte následující: `Jste užitečný a efektivní matematický asistent. Když dostanete úlohu zahrnující základní aritmetiku, odpovíte správným výsledkem.`
1. Klikněte na tlačítko **Generate**. V pravém dolním rohu se zobrazí oznámení potvrzující, že systémový prompt se generuje. Po dokončení se prompt objeví v poli **System prompt** v **Agent (Prompt) Builder**.
1. Zkontrolujte **System prompt** a v případě potřeby jej upravte.

### -3- Vytvoření MCP serveru

Nyní, když jste definovali systémový prompt agenta — který určuje jeho chování a odpovědi — je čas vybavit agenta praktickými schopnostmi. V této části vytvoříte kalkulační MCP server s nástroji pro provádění sčítání, odčítání, násobení a dělení. Tento server umožní vašemu agentovi provádět matematické operace v reálném čase na základě přirozených jazykových dotazů.

![Screenshot spodní části rozhraní Calculator Agent v AI Toolkit rozšíření pro Visual Studio Code. Zobrazuje rozbalovací menu „Tools“ a „Structure output“ spolu s rozbalovacím seznamem „Choose output format“ nastaveným na „text“. Vpravo je tlačítko „+ MCP Server“ pro přidání Model Context Protocol serveru. Nad sekcí Tools je zástupný obrázek ikony.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.cs.png)

AI Toolkit je vybaven šablonami, které usnadňují vytvoření vlastního MCP serveru. Použijeme Python šablonu pro vytvoření kalkulačního MCP serveru.

*Poznámka*: AI Toolkit aktuálně podporuje Python a TypeScript.

1. V sekci **Tools** v **Agent (Prompt) Builder** klikněte na tlačítko **+ MCP Server**. Rozšíření spustí průvodce nastavením prostřednictvím **Command Palette**.
1. Vyberte **+ Add Server**.
1. Vyberte **Create a New MCP Server**.
1. Vyberte šablonu **python-weather**.
1. Vyberte **Default folder** pro uložení šablony MCP serveru.
1. Zadejte název serveru: **Calculator**
1. Otevře se nové okno Visual Studio Code. Vyberte **Yes, I trust the authors**.
1. V terminálu (**Terminal** > **New Terminal**) vytvořte virtuální prostředí: `python -m venv .venv`
1. V terminálu aktivujte virtuální prostředí:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. V terminálu nainstalujte závislosti: `pip install -e .[dev]`
1. V zobrazení **Explorer** v **Activity Bar** rozbalte adresář **src** a otevřete soubor **server.py** v editoru.
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

### -4- Spuštění agenta s MCP serverem kalkulačky

Nyní, když váš agent má nástroje, je čas je použít! V této části zadáte prompt agentovi, abyste otestovali a ověřili, zda agent využívá příslušný nástroj z MCP serveru kalkulačky.

1. Stiskněte `F5` pro spuštění ladění MCP serveru. **Agent (Prompt) Builder** se otevře v nové záložce editoru. Stav serveru je viditelný v terminálu.
1. Do pole **User prompt** v **Agent (Prompt) Builder** zadejte následující dotaz: `Koupil jsem 3 položky za 25 dolarů každá a pak jsem použil slevu 20 dolarů. Kolik jsem zaplatil?`
1. Klikněte na tlačítko **Run** pro vygenerování odpovědi agenta.
1. Zkontrolujte výstup agenta. Model by měl dojít k závěru, že jste zaplatili **55 dolarů**.
1. Zde je rozpis, co by mělo proběhnout:
    - Agent vybere nástroje **multiply** a **subtract** pro pomoc s výpočtem.
    - Pro nástroj **multiply** jsou přiřazeny hodnoty `a` a `b`.
    - Pro nástroj **subtract** jsou přiřazeny hodnoty `a` a `b`.
    - Odpovědi z jednotlivých nástrojů jsou zobrazeny v příslušných polích **Tool Response**.
    - Konečný výstup modelu je zobrazen v poli **Model Response**.
1. Zadejte další dotazy pro další testování agenta. Můžete upravit existující dotaz v poli **User prompt** kliknutím do pole a přepsáním textu.
1. Po dokončení testování můžete server zastavit v terminálu stisknutím **CTRL/CMD+C**.

## Zadání

Zkuste přidat další nástroj do souboru **server.py** (například výpočet druhé odmocniny čísla). Zadejte další dotazy, které budou vyžadovat, aby agent využil váš nový nástroj (nebo stávající nástroje). Nezapomeňte server restartovat, aby se nové nástroje načetly.

## Řešení

[Řešení](./solution/README.md)

## Klíčové poznatky

Z této kapitoly si odnesete následující:

- Rozšíření AI Toolkit je skvělý klient, který umožňuje využívat MCP servery a jejich nástroje.
- Do MCP serverů můžete přidávat nové nástroje, čímž rozšíříte schopnosti agenta tak, aby splňoval měnící se požadavky.
- AI Toolkit obsahuje šablony (např. šablony MCP serverů pro Python), které zjednodušují vytváření vlastních nástrojů.

## Další zdroje

- [Dokumentace AI Toolkitu](https://aka.ms/AIToolkit/doc)

## Co dál
- Další: [Testování a ladění](../08-testing/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.