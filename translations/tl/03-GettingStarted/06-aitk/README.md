<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:46:37+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "tl"
}
-->
# Paggamit ng server mula sa AI Toolkit extension para sa Visual Studio Code

Kapag gumagawa ka ng AI agent, hindi lang ito tungkol sa paggawa ng matatalinong sagot; mahalaga rin na mabigyan ang agent ng kakayahang kumilos. Dito pumapasok ang Model Context Protocol (MCP). Pinapadali ng MCP para sa mga agent na ma-access ang mga external na tools at serbisyo sa isang pare-parehong paraan. Isipin mo ito na parang pagsaksak ng iyong agent sa isang toolbox na *talagang* magagamit nito.

Halimbawa, ikinonekta mo ang isang agent sa iyong calculator MCP server. Bigla, kaya na ng agent mo na magsagawa ng mga operasyon sa matematika sa pamamagitan lang ng pagtanggap ng prompt na “Ano ang 47 times 89?”—hindi mo na kailangang mag-hardcode ng logic o gumawa ng custom na API.

## Pangkalahatang-ideya

Tinuturo ng araling ito kung paano ikonekta ang calculator MCP server sa isang agent gamit ang [AI Toolkit](https://aka.ms/AIToolkit) extension sa Visual Studio Code, na nagbibigay-daan sa iyong agent na magsagawa ng mga operasyon sa matematika tulad ng addition, subtraction, multiplication, at division gamit ang natural na wika.

Ang AI Toolkit ay isang makapangyarihang extension para sa Visual Studio Code na nagpapadali sa pagbuo ng mga agent. Madaling makagawa ang mga AI Engineers ng AI applications sa pamamagitan ng pag-develop at pag-test ng mga generative AI models—lokal man o sa cloud. Sinusuportahan ng extension ang karamihan sa mga pangunahing generative models na available ngayon.

*Note*: Sa kasalukuyan, sinusuportahan ng AI Toolkit ang Python at TypeScript.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Gumamit ng MCP server gamit ang AI Toolkit.
- I-configure ang agent para mahanap at magamit ang mga tool na ibinibigay ng MCP server.
- Gamitin ang mga MCP tool gamit ang natural na wika.

## Pamamaraan

Ganito ang pangkalahatang hakbang na susundin natin:

- Gumawa ng agent at tukuyin ang system prompt nito.
- Gumawa ng MCP server na may mga calculator tools.
- Ikonekta ang Agent Builder sa MCP server.
- Subukan ang pagtawag ng tool ng agent gamit ang natural na wika.

Ayos! Ngayon na naiintindihan na natin ang daloy, i-configure natin ang AI agent para magamit ang mga external na tools sa pamamagitan ng MCP, para mapalawak ang kakayahan nito!

## Mga Kinakailangan

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para sa Visual Studio Code](https://aka.ms/AIToolkit)

## Ehersisyo: Paggamit ng server

Sa ehersisyong ito, gagawa, patatakbuhin, at paiigtingin mo ang isang AI agent gamit ang mga tool mula sa MCP server sa loob ng Visual Studio Code gamit ang AI Toolkit.

### -0- Paunang hakbang, idagdag ang OpenAI GPT-4o model sa My Models

Gagamitin sa ehersisyong ito ang **GPT-4o** model. Siguraduhing maidagdag ang model sa **My Models** bago gumawa ng agent.

![Screenshot ng model selection interface sa AI Toolkit extension ng Visual Studio Code. Nakasulat sa itaas ang "Find the right model for your AI Solution" na may subtitle na hinihikayat ang mga user na mag-discover, mag-test, at mag-deploy ng AI models. Sa ibaba, sa ilalim ng “Popular Models,” makikita ang anim na model cards: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), at DeepSeek-R1 (Ollama-hosted). Bawat card ay may opsyon na “Add” o “Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.tl.png)

1. Buksan ang **AI Toolkit** extension mula sa **Activity Bar**.
1. Sa seksyong **Catalog**, piliin ang **Models** para buksan ang **Model Catalog**. Ang pagpili ng **Models** ay magbubukas ng **Model Catalog** sa bagong editor tab.
1. Sa search bar ng **Model Catalog**, i-type ang **OpenAI GPT-4o**.
1. I-click ang **+ Add** para idagdag ang model sa iyong **My Models** list. Siguraduhing ang model na pinili mo ay **Hosted by GitHub**.
1. Sa **Activity Bar**, tiyaking lumabas ang **OpenAI GPT-4o** model sa listahan.

### -1- Gumawa ng agent

Pinapahintulutan ka ng **Agent (Prompt) Builder** na gumawa at i-customize ang sarili mong AI-powered agent. Sa bahaging ito, gagawa ka ng bagong agent at magtatalaga ng model na siyang magpapatakbo ng pag-uusap.

![Screenshot ng "Calculator Agent" builder interface sa AI Toolkit extension ng Visual Studio Code. Sa kaliwang panel, ang napiling model ay "OpenAI GPT-4o (via GitHub)." May system prompt na nagsasabing "You are a professor in university teaching math," at user prompt na "Explain to me the Fourier equation in simple terms." May mga opsyon para magdagdag ng tools, paganahin ang MCP Server, at pumili ng structured output. May asul na “Run” button sa ibaba. Sa kanang panel, sa ilalim ng "Get Started with Examples," may tatlong sample agents: Web Developer (may MCP Server), Second-Grade Simplifier, at Dream Interpreter, na may mga maikling paglalarawan ng kanilang mga gawain.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.tl.png)

1. Buksan ang **AI Toolkit** extension mula sa **Activity Bar**.
1. Sa seksyong **Tools**, piliin ang **Agent (Prompt) Builder**. Magbubukas ito sa bagong editor tab.
1. I-click ang **+ New Agent** button. Maglalabas ang extension ng setup wizard sa pamamagitan ng **Command Palette**.
1. Ilagay ang pangalan na **Calculator Agent** at pindutin ang **Enter**.
1. Sa **Agent (Prompt) Builder**, sa field na **Model**, piliin ang **OpenAI GPT-4o (via GitHub)** model.

### -2- Gumawa ng system prompt para sa agent

Ngayon na na-set up na ang agent, panahon na para tukuyin ang personalidad at layunin nito. Sa bahaging ito, gagamitin mo ang **Generate system prompt** feature para ilarawan ang intensyon ng agent—sa kasong ito, isang calculator agent—at hayaan ang model na isulat ang system prompt para sa iyo.

![Screenshot ng "Calculator Agent" interface sa AI Toolkit para sa Visual Studio Code na may bukas na modal window na pinamagatang "Generate a prompt." Ipinapaliwanag ng modal na pwedeng gumawa ng prompt template sa pamamagitan ng pagbibigay ng mga pangunahing detalye at may textbox na may sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Sa ibaba ng textbox ay may mga button na "Close" at "Generate." Sa background, makikita ang bahagi ng agent configuration kasama ang napiling model "OpenAI GPT-4o (via GitHub)" at mga field para sa system at user prompts.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.tl.png)

1. Sa seksyong **Prompts**, i-click ang **Generate system prompt** button. Bubukas ito sa prompt builder na gumagamit ng AI para gumawa ng system prompt para sa agent.
1. Sa window na **Generate a prompt**, ilagay ang sumusunod: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. I-click ang **Generate** button. Lalabas ang notification sa ibabang-kanang sulok na nagpapatunay na ginagawa ang system prompt. Kapag tapos na, lalabas ang prompt sa **System prompt** field ng **Agent (Prompt) Builder**.
1. Suriin ang **System prompt** at baguhin kung kinakailangan.

### -3- Gumawa ng MCP server

Ngayon na natukoy mo na ang system prompt ng agent—na gagabay sa kilos at sagot nito—panahon na para bigyan ang agent ng praktikal na kakayahan. Sa bahaging ito, gagawa ka ng calculator MCP server na may mga tool para sa addition, subtraction, multiplication, at division. Papayagan ng server na ito ang agent na magsagawa ng mga real-time na operasyon sa matematika bilang tugon sa mga prompt gamit ang natural na wika.

![Screenshot ng ibabang bahagi ng Calculator Agent interface sa AI Toolkit extension para sa Visual Studio Code. Makikita ang mga expandable menus para sa “Tools” at “Structure output,” pati na rin ang dropdown menu na “Choose output format” na nakapili sa “text.” Sa kanan, may button na “+ MCP Server” para magdagdag ng Model Context Protocol server. May placeholder icon ng larawan sa itaas ng Tools section.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.tl.png)

May mga template ang AI Toolkit para mapadali ang paggawa ng sarili mong MCP server. Gagamitin natin ang Python template para sa paggawa ng calculator MCP server.

*Note*: Sa kasalukuyan, sinusuportahan ng AI Toolkit ang Python at TypeScript.

1. Sa seksyong **Tools** ng **Agent (Prompt) Builder**, i-click ang **+ MCP Server** button. Maglalabas ang extension ng setup wizard sa pamamagitan ng **Command Palette**.
1. Piliin ang **+ Add Server**.
1. Piliin ang **Create a New MCP Server**.
1. Piliin ang **python-weather** bilang template.
1. Piliin ang **Default folder** para i-save ang MCP server template.
1. Ilagay ang pangalan ng server: **Calculator**
1. Magbubukas ang bagong Visual Studio Code window. Piliin ang **Yes, I trust the authors**.
1. Sa terminal (**Terminal** > **New Terminal**), gumawa ng virtual environment: `python -m venv .venv`
1. Sa terminal, i-activate ang virtual environment:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Sa terminal, i-install ang mga dependencies: `pip install -e .[dev]`
1. Sa **Explorer** view ng **Activity Bar**, i-expand ang **src** directory at piliin ang **server.py** para buksan ito sa editor.
1. Palitan ang laman ng **server.py** file ng sumusunod at i-save:

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

Ngayon na may mga tool na ang iyong agent, panahon na para gamitin ang mga ito! Sa bahaging ito, magsusumite ka ng mga prompt sa agent para subukan at tiyakin kung ginagamit ng agent ang tamang tool mula sa calculator MCP server.

![Screenshot ng Calculator Agent interface sa AI Toolkit extension para sa Visual Studio Code. Sa kaliwang panel, sa ilalim ng “Tools,” may idinagdag na MCP server na pinangalanang local-server-calculator_server, na nagpapakita ng apat na available na tools: add, subtract, multiply, at divide. May badge na nagpapakita na apat na tools ang active. Sa ibaba ay nakatago ang “Structure output” section at may asul na “Run” button. Sa kanang panel, sa ilalim ng “Model Response,” tinatawag ng agent ang multiply at subtract tools na may inputs na {"a": 3, "b": 25} at {"a": 75, "b": 20} ayon sa pagkakasunod. Ang huling “Tool Response” ay ipinapakita bilang 75.0. May button na “View Code” sa ibaba.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.tl.png)

Patatakbuhin mo ang calculator MCP server sa iyong lokal na dev machine gamit ang **Agent Builder** bilang MCP client.

1. Pindutin ang `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` na mga values ay naka-assign para sa **subtract** tool.
    - Ang sagot mula sa bawat tool ay makikita sa kani-kanilang **Tool Response**.
    - Ang huling output mula sa model ay makikita sa final na **Model Response**.
1. Mag-submit ng dagdag pang mga prompt para masubukan pa ang agent. Maaari mong baguhin ang kasalukuyang prompt sa **User prompt** field sa pamamagitan ng pag-click at pagpapalit ng prompt.
1. Kapag tapos ka na sa pagsubok, pwede mong itigil ang server sa pamamagitan ng **terminal** sa pagpasok ng **CTRL/CMD+C** para lumabas.

## Takdang-Aralin

Subukan mong magdagdag ng bagong tool entry sa iyong **server.py** file (halimbawa: magbalik ng square root ng isang numero). Mag-submit ng dagdag pang mga prompt na mangangailangan na gamitin ng agent ang bagong tool (o mga kasalukuyang tool). Siguraduhing i-restart ang server para ma-load ang mga bagong tool.

## Solusyon

[Solution](./solution/README.md)

## Mahahalagang Punto

Ang mga mahahalagang natutunan mula sa kabanatang ito ay:

- Ang AI Toolkit extension ay isang mahusay na client na nagpapahintulot sa iyo na gumamit ng MCP Servers at kanilang mga tools.
- Maaari kang magdagdag ng bagong tools sa MCP servers, na nagpapalawak ng kakayahan ng agent upang matugunan ang mga nagbabagong pangangailangan.
- Kasama sa AI Toolkit ang mga template (hal., Python MCP server templates) para mapadali ang paggawa ng mga custom na tools.

## Karagdagang Resources

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Ano ang Susunod

Susunod: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Pagtatanggol**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.