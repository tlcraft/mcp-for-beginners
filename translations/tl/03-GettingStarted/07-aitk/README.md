<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:38:44+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "tl"
}
-->
# Paggamit ng server mula sa AI Toolkit extension para sa Visual Studio Code

Kapag gumagawa ka ng AI agent, hindi lang ito tungkol sa pagbuo ng matatalinong sagot; mahalaga rin na mabigyan ang iyong agent ng kakayahang kumilos. Dito pumapasok ang Model Context Protocol (MCP). Pinapadali ng MCP para sa mga agent na ma-access ang mga panlabas na tool at serbisyo sa isang pare-parehong paraan. Isipin mo ito bilang pagsaksak ng iyong agent sa isang toolbox na *talagang* magagamit nito.

Halimbawa, ikonekta mo ang isang agent sa iyong calculator MCP server. Bigla, kaya nang magsagawa ng mga operasyon sa matematika ang iyong agent sa pamamagitan lang ng pagtanggap ng prompt tulad ng “Ano ang 47 times 89?”—hindi mo na kailangang i-hardcode ang lohika o gumawa ng custom na API.

## Pangkalahatang-ideya

Tinuturo sa araling ito kung paano ikonekta ang isang calculator MCP server sa isang agent gamit ang [AI Toolkit](https://aka.ms/AIToolkit) extension sa Visual Studio Code, na nagbibigay-daan sa iyong agent na magsagawa ng mga operasyon sa matematika tulad ng addition, subtraction, multiplication, at division gamit ang natural na wika.

Ang AI Toolkit ay isang makapangyarihang extension para sa Visual Studio Code na nagpapadali sa pagbuo ng mga agent. Madaling makabuo ang mga AI Engineer ng mga AI application sa pamamagitan ng pag-develop at pag-test ng mga generative AI model—lokal man o sa cloud. Sinusuportahan ng extension ang karamihan sa mga pangunahing generative model na available ngayon.

*Note*: Sa kasalukuyan, sinusuportahan ng AI Toolkit ang Python at TypeScript.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Gumamit ng MCP server gamit ang AI Toolkit.
- I-configure ang agent upang matuklasan at magamit ang mga tool na ibinibigay ng MCP server.
- Gamitin ang mga MCP tool gamit ang natural na wika.

## Paraan

Ganito ang pangkalahatang hakbang na dapat sundan:

- Gumawa ng agent at tukuyin ang system prompt nito.
- Gumawa ng MCP server na may mga calculator tool.
- Ikonekta ang Agent Builder sa MCP server.
- Subukan ang paggamit ng mga tool ng agent gamit ang natural na wika.

Maganda, ngayon na naiintindihan natin ang daloy, i-configure natin ang AI agent para magamit ang mga panlabas na tool sa pamamagitan ng MCP, upang mapalawak ang kakayahan nito!

## Mga Kinakailangan

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para sa Visual Studio Code](https://aka.ms/AIToolkit)

## Ehersisyo: Paggamit ng server

Sa ehersisyong ito, gagawa, magpapatakbo, at magpapahusay ka ng AI agent gamit ang mga tool mula sa isang MCP server sa loob ng Visual Studio Code gamit ang AI Toolkit.

### -0- Paunang hakbang, idagdag ang OpenAI GPT-4o model sa My Models

Ginagamit sa ehersisyong ito ang **GPT-4o** model. Dapat itong idagdag sa **My Models** bago gumawa ng agent.

![Screenshot ng interface ng pagpili ng modelo sa AI Toolkit extension ng Visual Studio Code. Ang heading ay "Find the right model for your AI Solution" na may subtitle na naghihikayat sa mga user na tuklasin, subukan, at i-deploy ang mga AI model. Sa ilalim ng “Popular Models,” may anim na model card: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), at DeepSeek-R1 (Ollama-hosted). Bawat card ay may opsyon na “Add” o “Try in Playground.”](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.tl.png)

1. Buksan ang **AI Toolkit** extension mula sa **Activity Bar**.
1. Sa seksyong **Catalog**, piliin ang **Models** para buksan ang **Model Catalog**. Ang pagpili ng **Models** ay magbubukas ng **Model Catalog** sa bagong editor tab.
1. Sa search bar ng **Model Catalog**, i-type ang **OpenAI GPT-4o**.
1. I-click ang **+ Add** para idagdag ang modelo sa iyong listahan ng **My Models**. Siguraduhing napili mo ang modelong **Hosted by GitHub**.
1. Sa **Activity Bar**, tiyaking lumitaw ang **OpenAI GPT-4o** model sa listahan.

### -1- Gumawa ng agent

Pinapahintulutan ka ng **Agent (Prompt) Builder** na gumawa at i-customize ang sarili mong AI-powered agent. Sa bahaging ito, gagawa ka ng bagong agent at magtatalaga ng model para sa pagbuo ng usapan.

![Screenshot ng "Calculator Agent" builder interface sa AI Toolkit extension para sa Visual Studio Code. Sa kaliwang panel, ang napiling modelo ay "OpenAI GPT-4o (via GitHub)." Ang system prompt ay "You are a professor in university teaching math," at ang user prompt ay "Explain to me the Fourier equation in simple terms." May mga opsyon para magdagdag ng tools, paganahin ang MCP Server, at pumili ng structured output. May asul na “Run” button sa ibaba. Sa kanang panel, sa ilalim ng "Get Started with Examples," may tatlong sample agents: Web Developer (na may MCP Server), Second-Grade Simplifier, at Dream Interpreter, bawat isa ay may maikling paglalarawan ng kanilang mga function.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.tl.png)

1. Buksan ang **AI Toolkit** extension mula sa **Activity Bar**.
1. Sa seksyong **Tools**, piliin ang **Agent (Prompt) Builder**. Ang pagpili nito ay magbubukas ng bagong editor tab para sa **Agent (Prompt) Builder**.
1. I-click ang **+ New Agent** button. Magbubukas ang setup wizard sa pamamagitan ng **Command Palette**.
1. I-type ang pangalan na **Calculator Agent** at pindutin ang **Enter**.
1. Sa **Agent (Prompt) Builder**, sa field na **Model**, piliin ang **OpenAI GPT-4o (via GitHub)** model.

### -2- Gumawa ng system prompt para sa agent

Ngayon na na-set up na ang agent, panahon na para tukuyin ang personalidad at layunin nito. Sa bahaging ito, gagamitin mo ang **Generate system prompt** na feature para ilarawan ang inaasahang kilos ng agent—sa kasong ito, isang calculator agent—at hayaang ang model ang gumawa ng system prompt para sa iyo.

![Screenshot ng "Calculator Agent" interface sa AI Toolkit para sa Visual Studio Code na may bukas na modal window na pinamagatang "Generate a prompt." Ipinaliwanag sa modal na maaaring gumawa ng prompt template sa pamamagitan ng pagbibigay ng mga pangunahing detalye. May text box na may sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Sa ilalim ng text box ay may mga button na "Close" at "Generate." Sa background, makikita ang bahagi ng agent configuration, kabilang ang napiling model na "OpenAI GPT-4o (via GitHub)" at mga field para sa system at user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.tl.png)

1. Sa seksyong **Prompts**, i-click ang **Generate system prompt** button. Magbubukas ito ng prompt builder na gumagamit ng AI para gumawa ng system prompt para sa agent.
1. Sa window na **Generate a prompt**, i-type ang: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. I-click ang **Generate** button. Lalabas ang notification sa ibabang-kanang bahagi na nagpapatunay na ginagawa ang system prompt. Kapag tapos na, lalabas ang prompt sa **System prompt** field ng **Agent (Prompt) Builder**.
1. Suriin ang **System prompt** at baguhin kung kinakailangan.

### -3- Gumawa ng MCP server

Ngayon na natukoy mo na ang system prompt ng iyong agent—na siyang gagabay sa kilos at sagot nito—panahon na para bigyan ang agent ng mga praktikal na kakayahan. Sa bahaging ito, gagawa ka ng calculator MCP server na may mga tool para magsagawa ng addition, subtraction, multiplication, at division. Papayagan ng server na ito ang iyong agent na magsagawa ng mga real-time na operasyon sa matematika bilang tugon sa mga prompt gamit ang natural na wika.

!["Screenshot ng ibabang bahagi ng Calculator Agent interface sa AI Toolkit extension para sa Visual Studio Code. Makikita dito ang mga expandable menu para sa “Tools” at “Structure output,” pati na rin ang dropdown menu na “Choose output format” na naka-set sa “text.” Sa kanan, may button na “+ MCP Server” para magdagdag ng Model Context Protocol server. May placeholder icon ng larawan sa itaas ng Tools section.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.tl.png)

May mga template ang AI Toolkit para mapadali ang paggawa ng sarili mong MCP server. Gagamitin natin ang Python template para gumawa ng calculator MCP server.

*Note*: Sa kasalukuyan, sinusuportahan ng AI Toolkit ang Python at TypeScript.

1. Sa seksyong **Tools** ng **Agent (Prompt) Builder**, i-click ang **+ MCP Server** button. Magbubukas ang setup wizard sa pamamagitan ng **Command Palette**.
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
1. Sa **Explorer** view ng **Activity Bar**, i-expand ang **src** directory at piliin ang **server.py** para buksan sa editor.
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

Ngayon na may mga tool na ang iyong agent, panahon na para gamitin ang mga ito! Sa bahaging ito, magbibigay ka ng mga prompt sa agent para subukan at tiyakin kung ginagamit nito ang tamang tool mula sa calculator MCP server.

![Screenshot ng Calculator Agent interface sa AI Toolkit extension para sa Visual Studio Code. Sa kaliwang panel, sa ilalim ng “Tools,” may idinagdag na MCP server na pinangalanang local-server-calculator_server, na nagpapakita ng apat na available na tool: add, subtract, multiply, at divide. May badge na nagpapakita na apat na tool ang aktibo. Sa ibaba ay may nakatagong “Structure output” section at isang asul na “Run” button. Sa kanang panel, sa ilalim ng “Model Response,” tinatawag ng agent ang multiply at subtract tools na may inputs na {"a": 3, "b": 25} at {"a": 75, "b": 20} ayon sa pagkakasunod. Ang huling “Tool Response” ay ipinapakita bilang 75.0. May “View Code” button sa ibaba.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.tl.png)

Patatakbuhin mo ang calculator MCP server sa iyong lokal na development machine gamit ang **Agent Builder** bilang MCP client.

1. Pindutin ang `F5` para simulan ang debugging ng MCP server. Magbubukas ang **Agent (Prompt) Builder** sa bagong editor tab. Makikita ang status ng server sa terminal.
1. Sa field na **User prompt** ng **Agent (Prompt) Builder**, i-type ang prompt na ito: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. I-click ang **Run** button para makuha ang sagot ng agent.
1. Suriin ang output ng agent. Dapat matukoy ng model na nagbayad ka ng **$55**.
1. Narito ang detalye ng mga dapat mangyari:
    - Pinipili ng agent ang mga tool na **multiply** at **subtract** para makatulong sa kalkulasyon.
    - Itinalaga ang mga kaukulang `a` at `b` na halaga para sa **multiply** tool.
    - Itinalaga ang mga kaukulang `a` at `b` na halaga para sa **subtract** tool.
    - Ibinibigay ang sagot mula sa bawat tool sa kani-kanilang **Tool Response**.
    - Ang huling output mula sa model ay makikita sa huling **Model Response**.
1. Magbigay pa ng ibang mga prompt para masubukan ang agent. Maaari mong baguhin ang kasalukuyang prompt sa **User prompt** field sa pamamagitan ng pag-click dito at pagpapalit ng prompt.
1. Kapag tapos ka na sa pagsubok, maaari mong itigil ang server sa pamamagitan ng **terminal** gamit ang **CTRL/CMD+C** para lumabas.

## Takdang-Aralin

Subukang magdagdag ng karagdagang tool entry sa iyong **server.py** file (halimbawa: magbalik ng square root ng isang numero). Magbigay ng mga karagdagang prompt na mangangailangan sa agent na gamitin ang bagong tool (o mga kasalukuyang tool). Siguraduhing i-restart ang server para ma-load ang mga bagong tool.

## Solusyon

[Solution](./solution/README.md)

## Mahahalagang Punto

Narito ang mga mahahalagang punto mula sa kabanatang ito:

- Ang AI Toolkit extension ay isang mahusay na client na nagpapahintulot sa iyo na gamitin ang MCP Servers at ang kanilang mga tool.
- Maaari kang magdagdag ng mga bagong tool sa MCP servers, na nagpapalawak sa kakayahan ng agent upang matugunan ang mga nagbabagong pangangailangan.
- Kasama sa AI Toolkit ang mga template (hal., Python MCP server templates) para mapadali ang paggawa ng mga custom na tool.

## Karagdagang Mga Sanggunian

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Ano ang Susunod
- Susunod: [Testing & Debugging](../08-testing/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.