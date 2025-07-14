<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:40:08+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "cs"
}
-->
# Používání serveru z rozšíření AI Toolkit pro Visual Studio Code

Když vytváříte AI agenta, nejde jen o generování chytrých odpovědí; jde také o to, aby váš agent měl schopnost jednat. Právě zde přichází na řadu Model Context Protocol (MCP). MCP usnadňuje agentům přístup k externím nástrojům a službám jednotným způsobem. Představte si to jako připojení agenta k sadě nástrojů, kterou *opravdu* umí používat.

Řekněme, že připojíte agenta k vašemu kalkulačnímu MCP serveru. Najednou může agent provádět matematické operace jen na základě dotazu jako „Kolik je 47 krát 89?“ — bez nutnosti pevně zakódovat logiku nebo vytvářet vlastní API.

## Přehled

Tato lekce ukazuje, jak připojit kalkulační MCP server k agentovi pomocí rozšíření [AI Toolkit](https://aka.ms/AIToolkit) ve Visual Studio Code, což umožní vašemu agentovi provádět matematické operace jako sčítání, odčítání, násobení a dělení pomocí přirozeného jazyka.

AI Toolkit je výkonné rozšíření pro Visual Studio Code, které usnadňuje vývoj agentů. AI inženýři mohou snadno vytvářet AI aplikace vývojem a testováním generativních AI modelů — lokálně nebo v cloudu. Rozšíření podporuje většinu hlavních generativních modelů dostupných dnes.

*Poznámka*: AI Toolkit aktuálně podporuje Python a TypeScript.

## Cíle učení

Na konci této lekce budete umět:

- Používat MCP server přes AI Toolkit.
- Nakonfigurovat agentovu konfiguraci tak, aby dokázal objevit a využívat nástroje poskytované MCP serverem.
- Využívat MCP nástroje pomocí přirozeného jazyka.

## Přístup

Takto bychom měli postupovat na vysoké úrovni:

- Vytvořit agenta a definovat jeho systémový prompt.
- Vytvořit MCP server s kalkulačními nástroji.
- Připojit Agent Builder k MCP serveru.
- Otestovat volání nástrojů agenta pomocí přirozeného jazyka.

Skvěle, teď když rozumíme postupu, nakonfigurujme AI agenta tak, aby využíval externí nástroje přes MCP a rozšířil tak své schopnosti!

## Požadavky

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit pro Visual Studio Code](https://aka.ms/AIToolkit)

## Cvičení: Používání serveru

V tomto cvičení vytvoříte, spustíte a vylepšíte AI agenta s nástroji z MCP serveru přímo ve Visual Studio Code pomocí AI Toolkit.

### -0- Předkrok, přidání modelu OpenAI GPT-4o do My Models

Cvičení využívá model **GPT-4o**. Model by měl být přidán do **My Models** před vytvořením agenta.

![Screenshot rozhraní pro výběr modelu v rozšíření AI Toolkit ve Visual Studio Code. Nadpis zní "Najděte správný model pro vaše AI řešení" s podtitulem vybízejícím k objevování, testování a nasazení AI modelů. Pod ním je sekce „Populární modely“ se šesti kartami modelů: DeepSeek-R1 (hostováno na GitHubu), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - malý, rychlý) a DeepSeek-R1 (hostováno na Ollama). Každá karta obsahuje možnosti „Přidat“ model nebo „Vyzkoušet v Playground“.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.cs.png)

1. Otevřete rozšíření **AI Toolkit** z **Activity Bar**.
1. V sekci **Catalog** vyberte **Models** pro otevření **Model Catalog**. Výběr **Models** otevře **Model Catalog** v nové záložce editoru.
1. Do vyhledávacího pole **Model Catalog** zadejte **OpenAI GPT-4o**.
1. Klikněte na **+ Add** pro přidání modelu do seznamu **My Models**. Ujistěte se, že jste vybrali model, který je **hostován na GitHubu**.
1. V **Activity Bar** ověřte, že se model **OpenAI GPT-4o** objevil v seznamu.

### -1- Vytvoření agenta

**Agent (Prompt) Builder** vám umožňuje vytvořit a přizpůsobit vlastní AI agenty. V této části vytvoříte nového agenta a přiřadíte mu model, který bude pohánět konverzaci.

![Screenshot rozhraní "Calculator Agent" v AI Toolkit rozšíření pro Visual Studio Code. V levém panelu je vybraný model "OpenAI GPT-4o (via GitHub)." Systémový prompt říká "Jste profesor na univerzitě vyučující matematiku," a uživatelský prompt zní "Vysvětli mi Fourierovu rovnici jednoduše." Další možnosti zahrnují tlačítka pro přidání nástrojů, povolení MCP Serveru a výběr strukturovaného výstupu. Ve spodní části je modré tlačítko „Run“. V pravém panelu pod "Začínáme s příklady" jsou tři ukázkoví agenti: Web Developer (s MCP Serverem, zjednodušovačem pro druhou třídu a výkladem snů, každý s krátkým popisem funkcí).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.cs.png)

1. Otevřete rozšíření **AI Toolkit** z **Activity Bar**.
1. V sekci **Tools** vyberte **Agent (Prompt) Builder**. Výběr otevře **Agent (Prompt) Builder** v nové záložce editoru.
1. Klikněte na tlačítko **+ New Agent**. Rozšíření spustí průvodce nastavením přes **Command Palette**.
1. Zadejte název **Calculator Agent** a stiskněte **Enter**.
1. V **Agent (Prompt) Builder** v poli **Model** vyberte model **OpenAI GPT-4o (via GitHub)**.

### -2- Vytvoření systémového promptu pro agenta

Po vytvoření základu agenta je čas definovat jeho osobnost a účel. V této části použijete funkci **Generate system prompt**, která popíše zamýšlené chování agenta — v tomto případě kalkulačního agenta — a model pro vás vytvoří systémový prompt.

![Screenshot rozhraní "Calculator Agent" v AI Toolkit pro Visual Studio Code s otevřeným modálním oknem „Generate a prompt“. Okno vysvětluje, že lze vygenerovat šablonu promptu sdílením základních informací a obsahuje textové pole s ukázkovým systémovým promptem: "Jste užitečný a efektivní matematický asistent. Když dostanete úlohu zahrnující základní aritmetiku, odpovíte správným výsledkem." Pod textovým polem jsou tlačítka „Close“ a „Generate“. V pozadí je vidět část konfigurace agenta včetně vybraného modelu "OpenAI GPT-4o (via GitHub)" a polí pro systémový a uživatelský prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.cs.png)

1. V sekci **Prompts** klikněte na tlačítko **Generate system prompt**. Toto tlačítko otevře generátor promptů, který využívá AI k vytvoření systémového promptu pro agenta.
1. V okně **Generate a prompt** zadejte následující text: `Jste užitečný a efektivní matematický asistent. Když dostanete úlohu zahrnující základní aritmetiku, odpovíte správným výsledkem.`
1. Klikněte na tlačítko **Generate**. V pravém dolním rohu se zobrazí oznámení potvrzující, že se systémový prompt generuje. Po dokončení se prompt zobrazí v poli **System prompt** v **Agent (Prompt) Builder**.
1. Zkontrolujte systémový prompt a případně jej upravte.

### -3- Vytvoření MCP serveru

Nyní, když jste definovali systémový prompt agenta — který určuje jeho chování a odpovědi — je čas vybavit agenta praktickými schopnostmi. V této části vytvoříte kalkulační MCP server s nástroji pro provádění sčítání, odčítání, násobení a dělení. Tento server umožní vašemu agentovi provádět matematické operace v reálném čase na základě přirozených jazykových dotazů.

![Screenshot spodní části rozhraní Calculator Agent v AI Toolkit rozšíření pro Visual Studio Code. Zobrazuje rozbalovací menu „Tools“ a „Structure output“ spolu s rozbalovacím seznamem „Choose output format“ nastaveným na „text“. Vpravo je tlačítko „+ MCP Server“ pro přidání Model Context Protocol serveru. Nad sekcí Tools je zástupný obrázek ikony.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.cs.png)

AI Toolkit je vybaven šablonami, které usnadňují vytvoření vlastního MCP serveru. Použijeme Python šablonu pro vytvoření kalkulačního MCP serveru.

*Poznámka*: AI Toolkit aktuálně podporuje Python a TypeScript.

1. V sekci **Tools** v **Agent (Prompt) Builder** klikněte na tlačítko **+ MCP Server**. Rozšíření spustí průvodce nastavením přes **Command Palette**.
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

### -4- Spuštění agenta s kalkulačním MCP serverem

Nyní, když má váš agent nástroje, je čas je použít! V této části zadáte agentovi dotazy, abyste otestovali a ověřili, zda agent využívá správný nástroj z kalkulačního MCP serveru.

![Screenshot rozhraní Calculator Agent v AI Toolkit rozšíření pro Visual Studio Code. V levém panelu pod „Tools“ je přidán MCP server s názvem local-server-calculator_server, který zobrazuje čtyři dostupné nástroje: add, subtract, multiply a divide. Odznak ukazuje, že jsou aktivní čtyři nástroje. Pod tím je sbalená sekce „Structure output“ a modré tlačítko „Run“. V pravém panelu pod „Model Response“ agent volá nástroje multiply a subtract s vstupy {"a": 3, "b": 25} a {"a": 75, "b": 20}. Konečná „Tool Response“ je 75.0. Ve spodní části je tlačítko „View Code“.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.cs.png)

Během ladění budete spouštět kalkulační MCP server na svém lokálním vývojovém stroji přes **Agent Builder** jako MCP klienta.

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

## Hlavní poznatky

Z této kapitoly si odnesete následující:

- Rozšíření AI Toolkit je skvělý klient, který umožňuje používat MCP servery a jejich nástroje.
- Můžete přidávat nové nástroje do MCP serverů a rozšiřovat tak schopnosti agenta podle měnících se požadavků.
- AI Toolkit obsahuje šablony (např. Python MCP server šablony), které usnadňují tvorbu vlastních nástrojů.

## Další zdroje

- [Dokumentace AI Toolkit](https://aka.ms/AIToolkit/doc)

## Co dál
- Další: [Testování a ladění](../08-testing/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.