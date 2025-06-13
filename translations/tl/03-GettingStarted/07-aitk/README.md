<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:25:29+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "tl"
}
-->
# Paggamit ng server mula sa AI Toolkit extension para sa Visual Studio Code

Kapag gumagawa ka ng AI agent, hindi lang ito tungkol sa paggawa ng matatalinong sagot; mahalaga rin na mabigyan ang iyong agent ng kakayahang kumilos. Dito pumapasok ang Model Context Protocol (MCP). Pinapadali ng MCP para sa mga agent na ma-access ang mga external na tools at serbisyo sa isang pare-parehong paraan. Isipin mo ito na parang ikinakabit mo ang iyong agent sa isang toolbox na *talagang* magagamit niya.

Halimbawa, kung ikokonekta mo ang isang agent sa iyong calculator MCP server, bigla na lang kayang magsagawa ng mga operasyon sa matematika sa pamamagitan ng pagtanggap ng prompt tulad ng “Ano ang 47 times 89?”—hindi mo na kailangang mag-hardcode ng logic o gumawa ng custom na API.

## Pangkalahatang-ideya

Tinuturo ng leksyon na ito kung paano ikonekta ang isang calculator MCP server sa isang agent gamit ang [AI Toolkit](https://aka.ms/AIToolkit) extension sa Visual Studio Code, para magawa ng iyong agent ang mga operasyon sa matematika gaya ng addition, subtraction, multiplication, at division gamit ang natural na wika.

Ang AI Toolkit ay isang makapangyarihang extension para sa Visual Studio Code na nagpapadali ng pagbuo ng mga agent. Madaling makabuo ang mga AI Engineers ng AI applications sa pamamagitan ng pag-develop at pag-test ng generative AI models—lokal man o sa cloud. Sinusuportahan ng extension ang karamihan sa mga pangunahing generative models na available ngayon.

*Note*: Sa ngayon, sinusuportahan ng AI Toolkit ang Python at TypeScript.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng leksyon na ito, magagawa mong:

- Gumamit ng MCP server gamit ang AI Toolkit.
- I-configure ang agent configuration para ma-discover at magamit nito ang mga tools na ibinibigay ng MCP server.
- Gamitin ang mga MCP tools gamit ang natural na wika.

## Pamamaraan

Ganito ang pangkalahatang paraan ng pagharap dito:

- Gumawa ng agent at tukuyin ang system prompt nito.
- Gumawa ng MCP server na may calculator tools.
- Ikonekta ang Agent Builder sa MCP server.
- Subukan ang pagtawag ng tool ng agent gamit ang natural na wika.

Maganda! Ngayon na naiintindihan na natin ang daloy, i-configure na natin ang AI agent para magamit ang mga external tools sa pamamagitan ng MCP, upang mapalawak ang kakayahan nito!

## Mga Kinakailangan

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para sa Visual Studio Code](https://aka.ms/AIToolkit)

## Ehersisyo: Paggamit ng server

Sa ehersisyong ito, gagawa, magpapatakbo, at pahuhusayin mo ang isang AI agent gamit ang mga tools mula sa MCP server sa loob ng Visual Studio Code gamit ang AI Toolkit.

### -0- Paunang hakbang, idagdag ang OpenAI GPT-4o model sa My Models

Ginagamit sa ehersisyong ito ang **GPT-4o** model. Dapat idagdag ang model sa **My Models** bago gumawa ng agent.

![Screenshot ng model selection interface sa AI Toolkit extension ng Visual Studio Code. Ang heading ay "Find the right model for your AI Solution" na may subtitle na naghihikayat sa mga user na mag-discover, mag-test, at mag-deploy ng AI models. Sa ilalim, sa “Popular Models,” may anim na model cards: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), at DeepSeek-R1 (Ollama-hosted). Bawat card ay may opsyon na “Add” o “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.tl.png)

1. Buksan ang **AI Toolkit** extension mula sa **Activity Bar**.
1. Sa seksyong **Catalog**, piliin ang **Models** para buksan ang **Model Catalog**. Ang pagpili ng **Models** ay magbubukas ng **Model Catalog** sa bagong editor tab.
1. Sa search bar ng **Model Catalog**, i-type ang **OpenAI GPT-4o**.
1. I-click ang **+ Add** para idagdag ang model sa iyong listahan ng **My Models**. Siguraduhing ang model na pipiliin mo ay **Hosted by GitHub**.
1. Sa **Activity Bar**, tiyaking lumitaw ang **OpenAI GPT-4o** model sa listahan.

### -1- Gumawa ng agent

Pinapayagan ka ng **Agent (Prompt) Builder** na gumawa at i-customize ang sarili mong AI-powered agents. Sa bahaging ito, gagawa ka ng bagong agent at mag-aassign ng model para patakbuhin ang pag-uusap.

![Screenshot ng "Calculator Agent" builder interface sa AI Toolkit extension ng Visual Studio Code. Sa kaliwang panel, ang napiling model ay "OpenAI GPT-4o (via GitHub)." May system prompt na nagsasabing "You are a professor in university teaching math," at user prompt na "Explain to me the Fourier equation in simple terms." May mga opsyon para magdagdag ng tools, paganahin ang MCP Server, at pumili ng structured output. Nasa ibaba ang asul na “Run” button. Sa kanang panel, sa ilalim ng "Get Started with Examples," may tatlong sample agents: Web Developer (na may MCP Server), Second-Grade Simplifier, at Dream Interpreter, na may maikling paglalarawan ng kanilang mga function.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.tl.png)

1. Buksan ang **AI Toolkit** extension mula sa **Activity Bar**.
1. Sa seksyong **Tools**, piliin ang **Agent (Prompt) Builder**. Ang pagpili dito ay magbubukas ng **Agent (Prompt) Builder** sa bagong editor tab.
1. I-click ang **+ New Agent** button. Maglulunsad ang extension ng setup wizard sa pamamagitan ng **Command Palette**.
1. I-type ang pangalang **Calculator Agent** at pindutin ang **Enter**.
1. Sa **Agent (Prompt) Builder**, sa field na **Model**, piliin ang **OpenAI GPT-4o (via GitHub)** model.

### -2- Gumawa ng system prompt para sa agent

Ngayon na na-setup mo na ang agent, oras na upang tukuyin ang personalidad at layunin nito. Sa bahaging ito, gagamitin mo ang **Generate system prompt** na feature para ilarawan ang nais na ugali ng agent—sa kasong ito, isang calculator agent—at hayaan ang model na isulat ang system prompt para sa iyo.

![Screenshot ng "Calculator Agent" interface sa AI Toolkit para sa Visual Studio Code na may bukas na modal window na pinamagatang "Generate a prompt." Ipinaliwanag sa modal na pwedeng gumawa ng prompt template sa pamamagitan ng pagbibigay ng mga pangunahing detalye at may textbox na may sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Sa ilalim ng textbox ay may mga button na "Close" at "Generate." Sa background, makikita ang bahagi ng agent configuration kasama ang napiling model na "OpenAI GPT-4o (via GitHub)" at mga field para sa system at user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.tl.png)

1. Sa seksyong **Prompts**, i-click ang **Generate system prompt** button. Magbubukas ito ng prompt builder na gumagamit ng AI para gumawa ng system prompt para sa agent.
1. Sa window na **Generate a prompt**, i-type ang sumusunod: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. I-click ang **Generate** button. Lalabas ang notification sa ibabang-kanang bahagi na nagpapatunay na ginagawa ang system prompt. Kapag tapos na, lalabas ang prompt sa **System prompt** field ng **Agent (Prompt) Builder**.
1. Suriin ang **System prompt** at baguhin kung kinakailangan.

### -3- Gumawa ng MCP server

Ngayon na naitakda mo na ang system prompt ng iyong agent—na gumagabay sa ugali at mga sagot nito—oras na para bigyan ang agent ng praktikal na kakayahan. Sa bahaging ito, gagawa ka ng calculator MCP server na may mga tools para sa addition, subtraction, multiplication, at division. Papayagan ng server na ito ang iyong agent na magsagawa ng real-time na mga operasyon sa matematika bilang tugon sa mga natural na wika na prompt.

!["Screenshot ng lower section ng Calculator Agent interface sa AI Toolkit extension para sa Visual Studio Code. Makikita dito ang mga expandable menus para sa “Tools” at “Structure output,” pati na rin ang dropdown menu na “Choose output format” na nakaset sa “text.” Sa kanan, may button na “+ MCP Server” para magdagdag ng Model Context Protocol server. May placeholder icon ng larawan sa itaas ng Tools section.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.tl.png)

May mga template ang AI Toolkit para mapadali ang paggawa ng sarili mong MCP server. Gagamit tayo ng Python template para gumawa ng calculator MCP server.

*Note*: Sa ngayon, sinusuportahan ng AI Toolkit ang Python at TypeScript.

1. Sa seksyong **Tools** ng **Agent (Prompt) Builder**, i-click ang **+ MCP Server** button. Maglulunsad ang extension ng setup wizard sa pamamagitan ng **Command Palette**.
1. Piliin ang **+ Add Server**.
1. Piliin ang **Create a New MCP Server**.
1. Piliin ang **python-weather** bilang template.
1. Piliin ang **Default folder** para i-save ang MCP server template.
1. I-type ang pangalan ng server: **Calculator**
1. Magbubukas ang bagong Visual Studio Code window. Piliin ang **Yes, I trust the authors**.
1. Sa terminal (**Terminal** > **New Terminal**), gumawa ng virtual environment: `python -m venv .venv`
1. Sa terminal, i-activate ang virtual environment:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Sa terminal, i-install ang mga dependencies: `pip install -e .[dev]`
1. Sa **Explorer** view ng **Activity Bar**, i-expand ang **src** directory at piliin ang **server.py** para buksan ito sa editor.
1. Palitan ang code sa **server.py** ng sumusunod at i-save:

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

### -4- Patakbuhin ang agent gamit ang calculator MCP server

Ngayon na may mga tools na ang iyong agent, panahon na para gamitin ang mga ito! Sa bahaging ito, magpapasa ka ng mga prompt sa agent para subukan at kumpirmahin kung ginagamit ba ng agent ang tamang tool mula sa calculator MCP server.

![Screenshot ng Calculator Agent interface sa AI Toolkit extension para sa Visual Studio Code. Sa kaliwang panel, sa ilalim ng “Tools,” may MCP server na pinangalanang local-server-calculator_server na may apat na available na tools: add, subtract, multiply, at divide. May badge na nagpapakita na apat na tools ang active. Sa ibaba ay may nakatagong “Structure output” section at asul na “Run” button. Sa kanang panel, sa ilalim ng “Model Response,” tinawag ng agent ang multiply at subtract tools na may inputs na {"a": 3, "b": 25} at {"a": 75, "b": 20} ayon sa pagkakasunod. Ang huling “Tool Response” ay 75.0. May “View Code” button sa ibaba.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.tl.png)

Patatakbuhin mo ang calculator MCP server sa iyong lokal na dev machine gamit ang **Agent Builder** bilang MCP client.

1. Pindutin ang `F5` para patakbuhin ang server.
1. Sa **User prompt**, ipasok ang:  
   `Bumili ako ng 3 items na nagkakahalaga ng $25 bawat isa, tapos gumamit ng $20 na discount. Magkano ang binayaran ko?`  
   Sa likod, ang mga value na `a` at `b` ay ia-assign para sa **subtract** tool.
    - Ang sagot mula sa bawat tool ay makikita sa kani-kanilang **Tool Response**.
    - Ang huling output mula sa model ay makikita sa huling **Model Response**.
1. Mag-submit ng dagdag pang mga prompt para masubukan pa ang agent. Pwede mong baguhin ang kasalukuyang prompt sa **User prompt** field sa pamamagitan ng pag-click at pagpapalit ng prompt.
1. Kapag tapos ka na sa pagsusuri, pwede mong ihinto ang server sa pamamagitan ng pagpasok ng **CTRL/CMD+C** sa **terminal**.

## Takdang-Aralin

Subukang magdagdag ng bagong tool entry sa iyong **server.py** file (halimbawa: mag-return ng square root ng isang numero). Mag-submit ng mga dagdag na prompt na mangangailangan na gamitin ng agent ang bago mong tool (o mga existing tools). Siguraduhing i-restart ang server para ma-load ang mga bagong tools.

## Solusyon

[Solution](./solution/README.md)

## Mga Mahahalagang Punto

Narito ang mga natutunan sa kabanatang ito:

- Ang AI Toolkit extension ay isang mahusay na client na nagpapahintulot sa'yo na gumamit ng MCP Servers at kanilang mga tools.
- Pwede kang magdagdag ng bagong tools sa MCP servers para mapalawak ang kakayahan ng agent ayon sa mga bagong pangangailangan.
- Kasama sa AI Toolkit ang mga template (halimbawa, Python MCP server templates) para mapadali ang paggawa ng custom tools.

## Karagdagang Resources

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Ano ang Susunod
- Susunod: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Pagsasalin**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaintindihan o maling interpretasyon na nagmula sa paggamit ng pagsasaling ito.