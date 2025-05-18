<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:27:21+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "tl"
}
-->
# Paggamit ng server mula sa AI Toolkit extension para sa Visual Studio Code

Kapag nagtatayo ka ng AI agent, hindi lang ito tungkol sa pagbuo ng matatalinong sagot; mahalaga rin na bigyan mo ang iyong agent ng kakayahang kumilos. Dito pumapasok ang Model Context Protocol (MCP). Pinapadali ng MCP para sa mga agent na ma-access ang mga external na tools at serbisyo sa isang consistent na paraan. Isipin mo ito na parang ikinokonekta mo ang iyong agent sa isang toolbox na magagamit nito.

Halimbawa, ikonekta mo ang isang agent sa iyong calculator MCP server. Bigla, ang iyong agent ay makakagawa ng mga operasyon sa matematika sa pamamagitan lang ng pagtanggap ng prompt tulad ng "Ano ang 47 times 89?"—hindi na kailangan ng hardcode logic o pagbuo ng custom APIs.

## Pangkalahatang-ideya

Saklaw ng araling ito kung paano ikonekta ang isang calculator MCP server sa isang agent gamit ang [AI Toolkit](https://aka.ms/AIToolkit) extension sa Visual Studio Code, na nagbibigay-daan sa iyong agent na magsagawa ng mga operasyon sa matematika tulad ng addition, subtraction, multiplication, at division sa pamamagitan ng natural na wika.

Ang AI Toolkit ay isang makapangyarihang extension para sa Visual Studio Code na pinapasimple ang pag-develop ng agent. Madaling makakagawa ang mga AI Engineers ng AI applications sa pamamagitan ng pag-develop at pag-test ng generative AI models—locally o sa cloud. Sinusuportahan ng extension ang karamihan sa mga pangunahing generative models na available ngayon.

*Note*: Sa kasalukuyan, sinusuportahan ng AI Toolkit ang Python at TypeScript.

## Mga Layunin sa Pag-aaral

Sa pagtatapos ng araling ito, magagawa mo ang sumusunod:

- Paggamit ng MCP server sa pamamagitan ng AI Toolkit.
- I-configure ang configuration ng agent upang paganahin ito na matuklasan at gamitin ang mga tool na ibinigay ng MCP server.
- Gamitin ang mga tool ng MCP sa pamamagitan ng natural na wika.

## Paraan

Narito kung paano natin kailangan lapitan ito sa mataas na antas:

- Gumawa ng agent at tukuyin ang system prompt nito.
- Gumawa ng MCP server na may mga calculator tools.
- Ikonekta ang Agent Builder sa MCP server.
- I-test ang invocation ng tool ng agent sa pamamagitan ng natural na wika.

Magaling, ngayong naiintindihan na natin ang daloy, mag-configure tayo ng AI agent upang gamitin ang mga external tools sa pamamagitan ng MCP, pinapahusay ang mga kakayahan nito!

## Mga Kinakailangan

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para sa Visual Studio Code](https://aka.ms/AIToolkit)

## Ehersisyo: Paggamit ng server

Sa ehersisyong ito, magtatayo, magpapatakbo, at magpapahusay ka ng AI agent gamit ang mga tool mula sa isang MCP server sa loob ng Visual Studio Code gamit ang AI Toolkit.

### -0- Paunang hakbang, idagdag ang OpenAI GPT-4o model sa My Models

Ginagamit ng ehersisyo ang **GPT-4o** model. Dapat idagdag ang model sa **My Models** bago gumawa ng agent.

1. Buksan ang **AI Toolkit** extension mula sa **Activity Bar**.
1. Sa **Catalog** section, piliin ang **Models** upang buksan ang **Model Catalog**. Ang pagpili sa **Models** ay magbubukas ng **Model Catalog** sa isang bagong editor tab.
1. Sa **Model Catalog** search bar, ilagay ang **OpenAI GPT-4o**.
1. I-click ang **+ Add** upang idagdag ang model sa iyong **My Models** list. Siguraduhin na napili mo ang model na **Hosted by GitHub**.
1. Sa **Activity Bar**, kumpirmahin na ang **OpenAI GPT-4o** model ay lumalabas sa listahan.

### -1- Gumawa ng agent

Ang **Agent (Prompt) Builder** ay nagbibigay-daan sa iyo na gumawa at i-customize ang sarili mong AI-powered agents. Sa seksyong ito, gagawa ka ng bagong agent at mag-aasign ng model upang paganahin ang pag-uusap.

1. Buksan ang **AI Toolkit** extension mula sa **Activity Bar**.
1. Sa **Tools** section, piliin ang **Agent (Prompt) Builder**. Ang pagpili sa **Agent (Prompt) Builder** ay magbubukas ng **Agent (Prompt) Builder** sa isang bagong editor tab.
1. I-click ang **+ New Builder** button. Ang extension ay maglulunsad ng setup wizard sa pamamagitan ng **Command Palette**.
1. Ilagay ang pangalan **Calculator Agent** at pindutin ang **Enter**.
1. Sa **Agent (Prompt) Builder**, para sa **Model** field, piliin ang **OpenAI GPT-4o (via GitHub)** model.

### -2- Gumawa ng system prompt para sa agent

Kapag na-skeleton na ang agent, oras na upang tukuyin ang personalidad at layunin nito. Sa seksyong ito, gagamitin mo ang **Generate system prompt** feature upang ilarawan ang nais na pag-uugali ng agent—sa kasong ito, isang calculator agent—at hayaan ang model na isulat ang system prompt para sa iyo.

1. Para sa **Prompts** section, i-click ang **Generate system prompt** button. Ang button na ito ay magbubukas sa prompt builder na gumagamit ng AI upang bumuo ng system prompt para sa agent.
1. Sa **Generate a prompt** window, ilagay ang sumusunod: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. I-click ang **Generate** button. Isang notification ang lalabas sa ibabang-kanang sulok na kumpirmasyon na ang system prompt ay ginagawa. Kapag kumpleto na ang pagbuo ng prompt, ang prompt ay lilitaw sa **System prompt** field ng **Agent (Prompt) Builder**.
1. Suriin ang **System prompt** at baguhin kung kinakailangan.

### -3- Gumawa ng MCP server

Ngayon na na-tukoy mo ang system prompt ng iyong agent—ginagabayan ang pag-uugali at mga tugon nito—oras na upang bigyan ang agent ng mga praktikal na kakayahan. Sa seksyong ito, gagawa ka ng calculator MCP server na may mga tool upang magsagawa ng mga kalkulasyon ng addition, subtraction, multiplication, at division. Ang server na ito ay magpapahintulot sa iyong agent na magsagawa ng real-time na mga operasyon sa matematika bilang tugon sa mga natural na language prompts.

Ang AI Toolkit ay may mga templates para sa kadalian ng paggawa ng sarili mong MCP server. Gagamitin natin ang Python template para sa paggawa ng calculator MCP server.

*Note*: Sa kasalukuyan, sinusuportahan ng AI Toolkit ang Python at TypeScript.

1. Sa **Tools** section ng **Agent (Prompt) Builder**, i-click ang **+ MCP Server** button. Ang extension ay maglulunsad ng setup wizard sa pamamagitan ng **Command Palette**.
1. Piliin ang **+ Add Server**.
1. Piliin ang **Create a New MCP Server**.
1. Piliin ang **python-weather** bilang template.
1. Piliin ang **Default folder** upang i-save ang MCP server template.
1. Ilagay ang sumusunod na pangalan para sa server: **Calculator**
1. Isang bagong Visual Studio Code window ang magbubukas. Piliin ang **Yes, I trust the authors**.
1. Gamitin ang terminal (**Terminal** > **New Terminal**), gumawa ng virtual environment: `python -m venv .venv`
1. Gamitin ang terminal, i-activate ang virtual environment:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Gamitin ang terminal, i-install ang dependencies: `pip install -e .[dev]`
1. Sa **Explorer** view ng **Activity Bar**, i-expand ang **src** directory at piliin ang **server.py** upang buksan ang file sa editor.
1. Palitan ang code sa **server.py** file ng sumusunod at i-save:

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

Ngayon na ang iyong agent ay may mga tool, oras na upang gamitin ang mga ito! Sa seksyong ito, magbibigay ka ng mga prompt sa agent upang subukan at kumpirmahin kung ang agent ay gumagamit ng tamang tool mula sa calculator MCP server.

Ikaw ay magpapatakbo ng calculator MCP server sa iyong local dev machine sa pamamagitan ng **Agent Builder** bilang MCP client.

1. Pindutin ang `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` values ay na-assign para sa **subtract** tool.
    - Ang tugon mula sa bawat tool ay ibinibigay sa respective **Tool Response**.
    - Ang final output mula sa model ay ibinibigay sa final **Model Response**.
1. Mag-submit ng karagdagang mga prompt upang mas higit pang subukan ang agent. Maaari mong baguhin ang existing prompt sa **User prompt** field sa pamamagitan ng pag-click sa field at pagpapalit ng existing prompt.
1. Kapag tapos ka na sa pag-test sa agent, maaari mong ihinto ang server sa pamamagitan ng **terminal** sa pamamagitan ng pagpasok ng **CTRL/CMD+C** upang mag-quit.

## Takdang-aralin

Subukang magdagdag ng karagdagang tool entry sa iyong **server.py** file (halimbawa: ibalik ang square root ng isang numero). Mag-submit ng karagdagang mga prompt na mangangailangan sa agent na gamitin ang iyong bagong tool (o existing tools). Siguraduhing i-restart ang server upang i-load ang mga bagong idinagdag na tools.

## Solusyon

[Solusyon](./solution/README.md)

## Mga Pangunahing Puntos

Ang mga pangunahing puntos mula sa kabanatang ito ay ang sumusunod:

- Ang AI Toolkit extension ay isang mahusay na client na nagpapahintulot sa iyo na gamitin ang MCP Servers at ang kanilang mga tools.
- Maaari kang magdagdag ng mga bagong tools sa MCP servers, pinapalawak ang kakayahan ng agent upang matugunan ang mga umuusbong na pangangailangan.
- Kasama sa AI Toolkit ang mga templates (halimbawa, Python MCP server templates) upang pasimplehin ang paglikha ng custom tools.

## Karagdagang Mga Mapagkukunan

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Ano ang Susunod

Susunod: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap namin ang pagiging tumpak, mangyaring tandaan na ang awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na mapagkakatiwalaang mapagkukunan. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.