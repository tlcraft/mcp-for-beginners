<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:25:56+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sw"
}
-->
# Kutumia server kutoka kwenye AI Toolkit extension ya Visual Studio Code

Unapojenga wakala wa AI, siyo tu kuhusu kuunda majibu makini; pia ni kumuwezesha wakala wako kuchukua hatua. Hapo ndipo Model Context Protocol (MCP) inapoingia. MCP inafanya iwe rahisi kwa mawakala kufikia zana na huduma za nje kwa njia inayolingana. Fikiria kama unamunganya wakala wako kwenye sanduku la zana ambalo anaweza *kutumia kweli*.

Tuseme umeunganisha wakala kwenye server yako ya calculator MCP. Ghafla, wakala wako anaweza kufanya hesabu kwa kupokea tu maelekezo kama “Ni 47 mara 89 ni kiasi gani?”—hakuna haja ya kuandika mantiki ngumu au kujenga API maalum.

## Muhtasari

Somo hili linaelezea jinsi ya kuunganisha server ya calculator MCP kwa wakala kwa kutumia [AI Toolkit](https://aka.ms/AIToolkit) extension katika Visual Studio Code, kuwezesha wakala wako kufanya hesabu kama kuongeza, kutoa, kuzidisha, na kugawanya kwa lugha ya kawaida.

AI Toolkit ni extension yenye nguvu kwa Visual Studio Code inayorahisisha maendeleo ya mawakala. Wahandisi wa AI wanaweza kwa urahisi kuunda programu za AI kwa kuendeleza na kujaribu modeli za generative AI—kama za ndani au mtandaoni. Extension hii inaunga mkono modeli nyingi maarufu za generative zilizopo sasa.

*Note*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutumia server ya MCP kupitia AI Toolkit.
- Kusanidi usanidi wa wakala ili uweze kugundua na kutumia zana zinazotolewa na server ya MCP.
- Kutumia zana za MCP kwa lugha ya kawaida.

## Mbinu

Hivi ndivyo tunavyopaswa kuifanya kwa jumla:

- Tengeneza wakala na ueleze prompt ya mfumo wake.
- Tengeneza server ya MCP yenye zana za calculator.
- Unganisha Agent Builder na server ya MCP.
- Jaribu wakala kuendesha zana kwa lugha ya kawaida.

Vizuri, sasa tunapoelewa mtiririko, hebu tusanidi wakala wa AI kutumia zana za nje kupitia MCP, kuongeza uwezo wake!

## Mahitaji

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Zoho: Kutumia server

Katika zoho hili, utajenga, kuendesha, na kuboresha wakala wa AI kwa zana kutoka server ya MCP ndani ya Visual Studio Code kwa kutumia AI Toolkit.

### -0- Hatua ya awali, ongeza modeli ya OpenAI GPT-4o kwenye My Models

Zoho hili linatumia modeli ya **GPT-4o**. Modeli hii inapaswa kuongezwa kwenye **My Models** kabla ya kuunda wakala.

![Screenshot ya interface ya uteuzi modeli katika AI Toolkit ya Visual Studio Code. Kichwa kinaandika "Find the right model for your AI Solution" na kichwa kidogo kinahamasisha watumiaji kugundua, kujaribu, na kupeleka modeli za AI. Chini, chini ya “Popular Models,” kuna kadi sita za modeli: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), na DeepSeek-R1 (Ollama-hosted). Kila kadi ina chaguo la “Add” au “Try in Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.sw.png)

1. Fungua extension ya **AI Toolkit** kutoka **Activity Bar**.
1. Katika sehemu ya **Catalog**, chagua **Models** kufungua **Model Catalog**. Kuchagua **Models** hufungua **Model Catalog** kwenye tab mpya ya mhariri.
1. Katika upau wa utafutaji wa **Model Catalog**, andika **OpenAI GPT-4o**.
1. Bonyeza **+ Add** kuongeza modeli kwenye orodha yako ya **My Models**. Hakikisha umechagua modeli inayotolewa na **GitHub**.
1. Katika **Activity Bar**, thibitisha kuwa modeli ya **OpenAI GPT-4o** inaonekana kwenye orodha.

### -1- Tengeneza wakala

**Agent (Prompt) Builder** inakuwezesha kuunda na kubinafsisha mawakala wako wa AI. Katika sehemu hii, utaunda wakala mpya na kumtenga modeli itakayoiendesha mazungumzo.

![Screenshot ya interface ya "Calculator Agent" katika AI Toolkit ya Visual Studio Code. Paneli ya kushoto inaonyesha modeli iliyochaguliwa ni "OpenAI GPT-4o (via GitHub)." Prompt ya mfumo inasema "You are a professor in university teaching math," na prompt ya mtumiaji ni, "Explain to me the Fourier equation in simple terms." Chaguzi za ziada ni vifungo vya kuongeza zana, kuwezesha MCP Server, na kuchagua structured output. Kitufe cha buluu cha “Run” kiko chini. Paneli ya kulia inaonyesha "Get Started with Examples," na mawakala sampuli watatu: Web Developer (na MCP Server), Second-Grade Simplifier, na Dream Interpreter, kila moja na maelezo mafupi.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.sw.png)

1. Fungua extension ya **AI Toolkit** kutoka **Activity Bar**.
1. Katika sehemu ya **Tools**, chagua **Agent (Prompt) Builder**. Kuchagua **Agent (Prompt) Builder** hufungua tab mpya ya mhariri.
1. Bonyeza kitufe cha **+ New Agent**. Extension itafungua wizard ya usanidi kupitia **Command Palette**.
1. Weka jina **Calculator Agent** na bonyeza **Enter**.
1. Katika **Agent (Prompt) Builder**, chaguo la **Model**, chagua modeli ya **OpenAI GPT-4o (via GitHub)**.

### -2- Tengeneza prompt ya mfumo kwa wakala

Mara wakala anapokuwa na muundo, ni wakati wa kufafanua tabia na kusudi lake. Katika sehemu hii, utatumia kipengele cha **Generate system prompt** kuelezea tabia inayotarajiwa ya wakala—hapa, wakala wa calculator—na kumwomba modeli kuandika prompt ya mfumo kwako.

![Screenshot ya interface ya "Calculator Agent" katika AI Toolkit ya Visual Studio Code yenye dirisha la modal linaloitwa "Generate a prompt." Modal linaelezea kuwa template ya prompt inaweza kutengenezwa kwa kushiriki maelezo ya msingi na lina sanduku la maandishi lenye mfano wa prompt ya mfumo: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Chini ya sanduku kuna vifungo vya "Close" na "Generate." Nyuma, sehemu ya usanidi wa wakala inaonekana, ikiwa ni pamoja na modeli iliyochaguliwa "OpenAI GPT-4o (via GitHub)" na sehemu za system na user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.sw.png)

1. Katika sehemu ya **Prompts**, bonyeza kitufe cha **Generate system prompt**. Kitufe hiki hufungua prompt builder inayotumia AI kuunda prompt ya mfumo kwa wakala.
1. Katika dirisha la **Generate a prompt**, weka yafuatayo: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Bonyeza kitufe cha **Generate**. Taarifa itatokea chini kulia kuthibitisha kuwa prompt ya mfumo inaandaliwa. Baada ya kukamilika, prompt itaonekana kwenye sehemu ya **System prompt** ya **Agent (Prompt) Builder**.
1. Pitia **System prompt** na ubadilishe kama inahitajika.

### -3- Tengeneza server ya MCP

Sasa umefafanua prompt ya mfumo wa wakala—inayoelekeza tabia na majibu yake—ni wakati wa kumpa wakala uwezo wa vitendo. Katika sehemu hii, utaunda server ya calculator MCP yenye zana za kuongeza, kutoa, kuzidisha, na kugawanya. Server hii itamwezesha wakala kufanya hesabu za wakati halisi kwa majibu ya maelekezo ya lugha ya kawaida.

!["Screenshot ya sehemu ya chini ya interface ya Calculator Agent katika AI Toolkit ya Visual Studio Code. Inaonyesha menyu zinazoweza kupanuliwa za “Tools” na “Structure output,” pamoja na dropdown ya “Choose output format” imewekwa “text.” Kushoto kuna kitufe cha “+ MCP Server” cha kuongeza server ya Model Context Protocol. Picha ya ikoni ya picha ipo juu ya sehemu ya Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.sw.png)

AI Toolkit ina templates za kurahisisha kuunda server zako za MCP. Tutatumia template ya Python kuunda server ya calculator MCP.

*Note*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.

1. Katika sehemu ya **Tools** ya **Agent (Prompt) Builder**, bonyeza kitufe cha **+ MCP Server**. Extension itafungua wizard ya usanidi kupitia **Command Palette**.
1. Chagua **+ Add Server**.
1. Chagua **Create a New MCP Server**.
1. Chagua template ya **python-weather**.
1. Chagua **Default folder** kuhifadhi template ya server ya MCP.
1. Weka jina lifuatalo kwa server: **Calculator**
1. Dirisha jipya la Visual Studio Code litafunguka. Chagua **Yes, I trust the authors**.
1. Tumia terminal (**Terminal** > **New Terminal**), tengeneza virtual environment: `python -m venv .venv`
1. Tumia terminal, washawishi virtual environment:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Tumia terminal, weka dependencies: `pip install -e .[dev]`
1. Katika mtazamo wa **Explorer** wa **Activity Bar**, panua saraka ya **src** na chagua **server.py** kufungua faili katika mhariri.
1. Badilisha msimbo uliopo katika faili **server.py** na huu ufuatao kisha uhifadhi:

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

### -4- Endesha wakala na server ya calculator MCP

Sasa wakala wako ana zana, ni wakati wa kuzitumia! Katika sehemu hii, utatuma maelekezo kwa wakala kujaribu na kuthibitisha kama wakala anatumia zana sahihi kutoka server ya calculator MCP.

![Screenshot ya interface ya Calculator Agent katika AI Toolkit ya Visual Studio Code. Paneli ya kushoto, chini ya “Tools,” kuna server ya MCP iitwayo local-server-calculator_server imeongezwa, ikionyesha zana nne zinazopatikana: add, subtract, multiply, na divide. Alama inaonyesha zana nne zinafanya kazi. Chini kuna sehemu ya “Structure output” iliyofichwa na kitufe cha buluu cha “Run.” Paneli ya kulia, chini ya “Model Response,” wakala anaitisha zana za multiply na subtract kwa maingizo {"a": 3, "b": 25} na {"a": 75, "b": 20} mtawalia. Jibu la mwisho la “Tool Response” linaonyeshwa kama 75.0. Kitufe cha “View Code” kiko chini.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.sw.png)

Utaendesha server ya calculator MCP kwenye mashine yako ya maendeleo kama mteja wa MCP kupitia **Agent Builder**.

1. Bonyeza `F5`` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Ninununua vitu 3 kila kimoja kikigharimu $25, kisha nikatumia punguzo la $20. Nililipa kiasi gani?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` thamani za zimetengwa kwa zana ya **subtract**.
    - Jibu kutoka kwa kila zana linatolewa katika **Tool Response** husika.
    - Matokeo ya mwisho kutoka kwa modeli yanatolewa katika **Model Response** ya mwisho.
1. Tuma maelekezo zaidi kujaribu wakala. Unaweza kubadilisha prompt iliyopo katika sehemu ya **User prompt** kwa kubonyeza sehemu hiyo na kubadilisha maelekezo yaliyopo.
1. Ukimaliza kujaribu wakala, unaweza kuacha server kupitia **terminal** kwa kubonyeza **CTRL/CMD+C** kuacha.

## Kazi ya Nyumbani

Jaribu kuongeza zana mpya kwenye faili yako ya **server.py** (mfano: rudisha mzizi wa mraba wa nambari). Tuma maelekezo zaidi yanayohitaji wakala kutumia zana yako mpya (au zana zilizopo). Hakikisha unasasisha server kuleta zana mpya.

## Suluhisho

[Suluhisho](./solution/README.md)

## Muhimu Kutambua

Mambo muhimu kutoka sura hii ni:

- Extension ya AI Toolkit ni mteja mzuri unaokuwezesha kutumia MCP Servers na zana zao.
- Unaweza kuongeza zana mpya kwenye MCP servers, ukiongeza uwezo wa wakala kukidhi mahitaji yanayobadilika.
- AI Toolkit ina templates (mfano, template za server ya MCP za Python) kurahisisha kuunda zana maalum.

## Rasilimali Zaidi

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Kile Kifuatacho
- Kifuatacho: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Kiarifu cha Kutolewa:**  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za moja kwa moja zinaweza kuwa na makosa au upungufu wa usahihi. Hati asilia katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatuna dhamana kwa maelezo potofu au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.