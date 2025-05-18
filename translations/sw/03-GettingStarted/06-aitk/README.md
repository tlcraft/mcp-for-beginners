<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:27:46+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sw"
}
-->
# Kutumia seva kutoka kwa kiendelezi cha AI Toolkit kwa Visual Studio Code

Unapojenga wakala wa AI, sio tu kuhusu kuzalisha majibu ya akili; ni pia kuhusu kumpa wakala wako uwezo wa kuchukua hatua. Hapo ndipo Model Context Protocol (MCP) inapoingia. MCP inafanya iwe rahisi kwa mawakala kufikia zana na huduma za nje kwa njia ya uthabiti. Fikiria kama kuunganisha wakala wako kwenye kisanduku cha zana anachoweza *kweli* kutumia.

Tuseme unaunganisha wakala na seva ya MCP ya kikokotoo chako. Ghafla, wakala wako anaweza kufanya hesabu za hisabati kwa kupokea tu ujumbe kama "Ni mara ngapi 47 mara 89?"—hakuna haja ya kuandika kanuni au kujenga API za kibinafsi.

## Muhtasari

Somu hili linashughulikia jinsi ya kuunganisha seva ya MCP ya kikokotoo na wakala kwa kiendelezi cha [AI Toolkit](https://aka.ms/AIToolkit) katika Visual Studio Code, ikimwezesha wakala wako kufanya hesabu za hisabati kama kuongeza, kutoa, kuzidisha, na kugawa kupitia lugha ya kawaida.

AI Toolkit ni kiendelezi chenye nguvu kwa Visual Studio Code ambacho huwezesha maendeleo ya wakala. Wahandisi wa AI wanaweza kwa urahisi kujenga programu za AI kwa kuendeleza na kujaribu mifano ya AI inayozalisha—kwa ndani au kwenye wingu. Kiendelezi kinasaidia mifano mikubwa inayozalisha inayopatikana leo.

*Angalizo*: AI Toolkit kwa sasa inasaidia Python na TypeScript.

## Malengo ya Kujifunza

Mwisho wa somu hili, utaweza:

- Kutumia seva ya MCP kupitia AI Toolkit.
- Kuseti usanidi wa wakala ili kuwezesha ugunduzi na utumiaji wa zana zinazotolewa na seva ya MCP.
- Kutumia zana za MCP kupitia lugha ya kawaida.

## Njia

Hivi ndivyo tunavyohitaji kukaribia hili kwa kiwango cha juu:

- Unda wakala na ufafanue ujumbe wa mfumo wake.
- Unda seva ya MCP na zana za kikokotoo.
- Unganisha Mjenzi wa Wakala na seva ya MCP.
- Jaribu uanzishaji wa zana za wakala kupitia lugha ya kawaida.

Nzuri, sasa kwamba tunaelewa mtiririko, wacha tuseti wakala wa AI ili kutumia zana za nje kupitia MCP, kuimarisha uwezo wake!

## Mahitaji ya awali

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit kwa Visual Studio Code](https://aka.ms/AIToolkit)

## Zoezi: Kutumia seva

Katika zoezi hili, utajenga, kuendesha, na kuimarisha wakala wa AI na zana kutoka kwa seva ya MCP ndani ya Visual Studio Code ukitumia AI Toolkit.

### -0- Hatua ya awali, ongeza mfano wa OpenAI GPT-4o kwenye Mifano Yangu

Zoezi linatumia mfano wa **GPT-4o**. Mfano unapaswa kuongezwa kwenye **Mifano Yangu** kabla ya kuunda wakala.

1. Fungua kiendelezi cha **AI Toolkit** kutoka kwenye **Activity Bar**.
1. Katika sehemu ya **Catalog**, chagua **Models** kufungua **Model Catalog**. Kuchagua **Models** kunafungua **Model Catalog** kwenye tab mpya ya mhariri.
1. Katika sehemu ya utafutaji ya **Model Catalog**, ingiza **OpenAI GPT-4o**.
1. Bonyeza **+ Add** kuongeza mfano kwenye orodha yako ya **My Models**. Hakikisha umechagua mfano unao **Hosted by GitHub**.
1. Katika **Activity Bar**, hakikisha mfano wa **OpenAI GPT-4o** unaonekana kwenye orodha.

### -1- Unda wakala

**Mjenzi wa Wakala (Ujumbe)** hukuwezesha kuunda na kubinafsisha mawakala wako wenye nguvu za AI. Katika sehemu hii, utaunda wakala mpya na kupeana mfano ili kuendesha mazungumzo.

1. Fungua kiendelezi cha **AI Toolkit** kutoka kwenye **Activity Bar**.
1. Katika sehemu ya **Tools**, chagua **Agent (Prompt) Builder**. Kuchagua **Agent (Prompt) Builder** kunafungua **Agent (Prompt) Builder** kwenye tab mpya ya mhariri.
1. Bonyeza kitufe cha **+ New Builder**. Kiendelezi kitaanzisha mwongozo wa usanidi kupitia **Command Palette**.
1. Ingiza jina **Calculator Agent** na bonyeza **Enter**.
1. Katika **Agent (Prompt) Builder**, kwa sehemu ya **Model**, chagua mfano **OpenAI GPT-4o (via GitHub)**.

### -2- Unda ujumbe wa mfumo kwa wakala

Kwa wakala ulioandaliwa, ni wakati wa kufafanua tabia na madhumuni yake. Katika sehemu hii, utatumia kipengele cha **Generate system prompt** kuelezea tabia iliyokusudiwa ya wakala—katika kesi hii, wakala wa kikokotoo—na kuandika ujumbe wa mfumo kwa ajili yako.

1. Kwa sehemu ya **Prompts**, bonyeza kitufe cha **Generate system prompt**. Kitufe hiki kinafungua mjenzi wa ujumbe ambao unatumia AI kuzalisha ujumbe wa mfumo kwa wakala.
1. Katika dirisha la **Generate a prompt**, ingiza ifuatayo: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Bonyeza kitufe cha **Generate**. Arifa itaonekana kwenye kona ya chini-kulia ikithibitisha kwamba ujumbe wa mfumo unazalishwa. Mara tu kizazi cha ujumbe kitakapokamilika, ujumbe utaonekana kwenye sehemu ya **System prompt** ya **Agent (Prompt) Builder**.
1. Angalia **System prompt** na ubadilishe ikiwa ni lazima.

### -3- Unda seva ya MCP

Sasa kwamba umefafanua ujumbe wa mfumo wa wakala wako—ukiongoza tabia na majibu yake—ni wakati wa kumpa wakala uwezo wa vitendo. Katika sehemu hii, utaunda seva ya MCP ya kikokotoo na zana za kutekeleza hesabu za kuongeza, kutoa, kuzidisha, na kugawa. Seva hii itamwezesha wakala wako kufanya hesabu za hisabati wakati halisi kwa majibu ya ujumbe wa lugha ya kawaida.

AI Toolkit imeandaliwa na templeti kwa urahisi wa kuunda seva yako ya MCP. Tutatumia templeti ya Python kuunda seva ya MCP ya kikokotoo.

*Angalizo*: AI Toolkit kwa sasa inasaidia Python na TypeScript.

1. Katika sehemu ya **Tools** ya **Agent (Prompt) Builder**, bonyeza kitufe cha **+ MCP Server**. Kiendelezi kitaanzisha mwongozo wa usanidi kupitia **Command Palette**.
1. Chagua **+ Add Server**.
1. Chagua **Create a New MCP Server**.
1. Chagua **python-weather** kama templeti.
1. Chagua **Default folder** kuhifadhi templeti ya seva ya MCP.
1. Ingiza jina lifuatalo kwa seva: **Calculator**
1. Dirisha jipya la Visual Studio Code litafunguka. Chagua **Yes, I trust the authors**.
1. Ukutumia terminal (**Terminal** > **New Terminal**), unda mazingira ya kawaida: `python -m venv .venv`
1. Ukutumia terminal, wezesha mazingira ya kawaida:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Ukutumia terminal, weka utegemezi: `pip install -e .[dev]`
1. Katika mwonekano wa **Explorer** wa **Activity Bar**, panua saraka ya **src** na chagua **server.py** kufungua faili katika mhariri.
1. Badilisha msimbo katika faili ya **server.py** na ifuatayo na uhifadhi:

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

### -4- Endesha wakala na seva ya MCP ya kikokotoo

Sasa kwamba wakala wako ana zana, ni wakati wa kuzitumia! Katika sehemu hii, utawasilisha maoni kwa wakala ili kujaribu na kuthibitisha ikiwa wakala anatumia zana inayofaa kutoka kwa seva ya MCP ya kikokotoo.

Utaendesha seva ya MCP ya kikokotoo kwenye mashine yako ya maendeleo ya ndani kupitia **Agent Builder** kama mteja wa MCP.

1. Bonyeza `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Nilinunua vitu 3 vilivyopangwa bei ya $25 kila kimoja, na kisha nikatumia punguzo la $20. Je, nililipa kiasi gani?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` thamani zimepewa kwa zana ya **subtract**.
    - Majibu kutoka kila zana yanatolewa katika **Tool Response** husika.
    - Matokeo ya mwisho kutoka kwa mfano yanatolewa katika **Model Response** ya mwisho.
1. Wasilisha maoni ya ziada ili kujaribu zaidi wakala. Unaweza kubadilisha maoni yaliyopo katika sehemu ya **User prompt** kwa kubonyeza ndani ya sehemu na kubadilisha maoni yaliyopo.
1. Mara tu unamaliza kujaribu wakala, unaweza kusimamisha seva kupitia **terminal** kwa kuingiza **CTRL/CMD+C** kuacha.

## Kazi ya Nyumbani

Jaribu kuongeza zana ya ziada kwenye faili yako ya **server.py** (mfano: kurudisha mzizi wa mraba wa namba). Wasilisha maoni ya ziada ambayo yanahitaji wakala kutumia zana yako mpya (au zana zilizopo). Hakikisha unarudisha seva ili kupakia zana zilizoongezwa.

## Suluhisho

[Suluhisho](./solution/README.md)

## Mambo Muhimu ya Kujifunza

Mambo muhimu kutoka sura hii ni kama ifuatavyo:

- Kiendelezi cha AI Toolkit ni mteja mzuri kinachokuruhusu kutumia Seva za MCP na zana zake.
- Unaweza kuongeza zana mpya kwenye seva za MCP, kupanua uwezo wa wakala kukidhi mahitaji yanayobadilika.
- AI Toolkit inajumuisha templeti (mfano, templeti za seva za Python MCP) ili kurahisisha uundaji wa zana za kibinafsi.

## Rasilimali za Ziada

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Kinachofuata

Kinachofuata: [Somu la 4 Utekelezaji wa Kivitendo](/04-PracticalImplementation/README.md)

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwepo kwa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo chenye mamlaka. Kwa habari muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa maelewano au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.