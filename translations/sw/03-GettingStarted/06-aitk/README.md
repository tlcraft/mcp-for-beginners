<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:47:15+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "sw"
}
-->
# Kutumia server kutoka kwa AI Toolkit extension kwa Visual Studio Code

Unapojenga wakala wa AI, siyo tu kuhusu kutoa majibu smart; pia ni kumuwezesha wakala wako kuchukua hatua. Hapa ndipo Model Context Protocol (MCP) inakuja. MCP inafanya iwe rahisi kwa mawakala kufikia zana na huduma za nje kwa njia ya kawaida. Fikiria kama unamunganisha wakala wako kwenye sanduku la zana analoweza *kweli* kutumia.

Tuseme unamunganisha wakala kwenye server ya calculator MCP. Ghafla, wakala wako anaweza kufanya hesabu kwa kupokea tu maelekezo kama “Je, 47 mara 89 ni ngapi?”—huna haja ya kuandika mantiki ngumu au kujenga APIs maalum.

## Muhtasari

Somo hili linaelezea jinsi ya kuunganisha server ya calculator MCP kwa wakala kwa kutumia [AI Toolkit](https://aka.ms/AIToolkit) extension ndani ya Visual Studio Code, na kumwezesha wakala wako kufanya hesabu kama kuongeza, kutoa, kuzidisha, na kugawanya kupitia lugha ya kawaida.

AI Toolkit ni extension yenye nguvu kwa Visual Studio Code inayorahisisha maendeleo ya mawakala. Wahandisi wa AI wanaweza kujenga na kujaribu modeli za AI za kizazi—kitaifa au kwenye wingu. Extension hii inaunga mkono modeli nyingi maarufu za kizazi zilizopo leo.

*Note*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutumia server ya MCP kupitia AI Toolkit.
- Kusanidi usanidi wa wakala ili uweze kugundua na kutumia zana zinazotolewa na server ya MCP.
- Kutumia zana za MCP kupitia lugha ya kawaida.

## Mbinu

Hivi ndivyo tunavyopaswa kuifikia kwa kiwango cha juu:

- Tengeneza wakala na ueleze system prompt yake.
- Tengeneza server ya MCP yenye zana za calculator.
- Unganisha Agent Builder na server ya MCP.
- Jaribu mwito wa zana za wakala kupitia lugha ya kawaida.

Nzuri, sasa tunapoelewa mtiririko, tuchague kusanidi wakala wa AI kutumia zana za nje kupitia MCP, tukiongeza uwezo wake!

## Mahitaji ya Awali

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit kwa Visual Studio Code](https://aka.ms/AIToolkit)

## Zoef: Kutumia server

Katika zoef hili, utajenga, kuendesha, na kuboresha wakala wa AI kwa zana kutoka kwa server ya MCP ndani ya Visual Studio Code kwa kutumia AI Toolkit.

### -0- Hatua ya awali, ongeza model ya OpenAI GPT-4o kwenye My Models

Zoef hili linatumia model ya **GPT-4o**. Modeli hii inapaswa kuongezwa kwenye **My Models** kabla ya kuunda wakala.

![Screenshot ya kiolesura cha kuchagua modeli katika AI Toolkit ya Visual Studio Code. Kichwa kinasoma "Find the right model for your AI Solution" na kichwa kidogo kinahimiza watumiaji kugundua, kujaribu, na kupeleka modeli za AI. Chini, chini ya “Popular Models,” kadi sita za modeli zinaonyeshwa: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), na DeepSeek-R1 (Ollama-hosted). Kila kadi ina chaguo la “Add” au “Try in Playground](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.sw.png)

1. Fungua extension ya **AI Toolkit** kutoka **Activity Bar**.
1. Katika sehemu ya **Catalog**, chagua **Models** kufungua **Model Catalog**. Kuchagua **Models** hufungua **Model Catalog** katika tabo mpya ya mhariri.
1. Katika upau wa utafutaji wa **Model Catalog**, andika **OpenAI GPT-4o**.
1. Bonyeza **+ Add** kuongeza modeli kwenye orodha yako ya **My Models**. Hakikisha umechagua modeli inayohudumiwa na **GitHub**.
1. Katika **Activity Bar**, thibitisha kuwa modeli ya **OpenAI GPT-4o** inaonekana kwenye orodha.

### -1- Tengeneza wakala

**Agent (Prompt) Builder** inakuwezesha kutengeneza na kubinafsisha mawakala wako wa AI. Katika sehemu hii, utaunda wakala mpya na kumteua modeli itakayomsaidia kuendesha mazungumzo.

![Screenshot ya kiolesura cha "Calculator Agent" katika AI Toolkit ya Visual Studio Code. Paneli ya kushoto inaonyesha modeli iliyochaguliwa "OpenAI GPT-4o (via GitHub)." System prompt inasema "You are a professor in university teaching math," na user prompt ni "Explain to me the Fourier equation in simple terms." Chaguzi za kuongeza zana, kuwezesha MCP Server, na kuchagua output ya muundo zinapatikana. Kitufe cha buluu “Run” kiko chini. Paneli ya kulia inaonyesha mifano mitatu ya mawakala: Web Developer (na MCP Server), Second-Grade Simplifier, na Dream Interpreter, kila moja ikielezea kazi zake.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.sw.png)

1. Fungua extension ya **AI Toolkit** kutoka **Activity Bar**.
1. Katika sehemu ya **Tools**, chagua **Agent (Prompt) Builder**. Kuchagua **Agent (Prompt) Builder** hufungua tabo mpya ya mhariri.
1. Bonyeza kitufe cha **+ New Agent**. Extension itazindua wizard ya usanidi kupitia **Command Palette**.
1. Weka jina **Calculator Agent** kisha bonyeza **Enter**.
1. Katika **Agent (Prompt) Builder**, kwa uwanja wa **Model**, chagua modeli ya **OpenAI GPT-4o (via GitHub)**.

### -2- Tengeneza system prompt kwa wakala

Baada ya kuunda muundo wa wakala, ni wakati wa kuainisha tabia na madhumuni yake. Katika sehemu hii, utatumia kipengele cha **Generate system prompt** kuelezea tabia inayotarajiwa ya wakala—hapa ni wakala wa calculator—na kumruhusu modeli kuandika system prompt kwa niaba yako.

![Screenshot ya kiolesura cha "Calculator Agent" katika AI Toolkit ya Visual Studio Code na dirisha la modal linaloitwa "Generate a prompt." Dirisha linaeleza kuwa template ya prompt inaweza kutengenezwa kwa kushiriki maelezo ya msingi na lina sanduku la maandishi lenye mfano wa system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Chini ya sanduku kuna vitufe vya "Close" na "Generate." Nyuma kuna sehemu ya usanidi wa wakala, ikionyesha modeli iliyochaguliwa "OpenAI GPT-4o (via GitHub)" na viwanja vya system na user prompts.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.sw.png)

1. Kwa sehemu ya **Prompts**, bonyeza kitufe cha **Generate system prompt**. Kitufe hiki kitafungua prompt builder inayotumia AI kuunda system prompt kwa wakala.
1. Katika dirisha la **Generate a prompt**, ingiza yafuatayo: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Bonyeza kitufe cha **Generate**. Taarifa itatokea chini-kulia ikithibitisha kuwa system prompt inaandaliwa. Baada ya kumaliza, prompt itaonekana katika uwanja wa **System prompt** wa **Agent (Prompt) Builder**.
1. Pitia **System prompt** na ubadilishe kama inahitajika.

### -3- Tengeneza server ya MCP

Sasa umebainisha system prompt ya wakala wako—kuongoza tabia na majibu yake—ni wakati wa kumpa wakala uwezo wa vitendo. Katika sehemu hii, utaunda server ya calculator MCP yenye zana za kuongeza, kutoa, kuzidisha, na kugawanya. Server hii itamwezesha wakala wako kufanya hesabu kwa wakati halisi kwa majibu ya lugha ya kawaida.

!["Screenshot ya sehemu ya chini ya kiolesura cha Calculator Agent katika AI Toolkit ya Visual Studio Code. Inaonyesha menyu zinazoweza kupanuliwa za “Tools” na “Structure output,” pamoja na menyu ya kushuka ya “Choose output format” imewekwa “text.” Kushoto kuna kitufe cha “+ MCP Server” cha kuongeza Model Context Protocol server. Picha ya ikoni ya picha iko juu ya sehemu ya Tools.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.sw.png)

AI Toolkit ina templates zinazorahisisha kuunda server zako za MCP. Tutatumia template ya Python kuunda server ya calculator MCP.

*Note*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.

1. Katika sehemu ya **Tools** ya **Agent (Prompt) Builder**, bonyeza kitufe cha **+ MCP Server**. Extension itazindua wizard ya usanidi kupitia **Command Palette**.
1. Chagua **+ Add Server**.
1. Chagua **Create a New MCP Server**.
1. Chagua **python-weather** kama template.
1. Chagua **Default folder** kuhifadhi template ya server ya MCP.
1. Ingiza jina lifuatalo kwa server: **Calculator**
1. Dirisha jipya la Visual Studio Code litafunguka. Chagua **Yes, I trust the authors**.
1. Tumia terminal (**Terminal** > **New Terminal**), tengeneza virtual environment: `python -m venv .venv`
1. Tumia terminal, wezesha virtual environment:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Tumia terminal, weka tegemezi: `pip install -e .[dev]`
1. Katika mtazamo wa **Explorer** wa **Activity Bar**, panua saraka ya **src** na chagua **server.py** kufungua faili kwenye mhariri.
1. Badilisha msimbo uliopo katika faili ya **server.py** na ifanye kuwa ifuatayo kisha uhifadhi:

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

### -4- Endesha wakala kwa server ya calculator MCP

Sasa wakala wako ana zana, ni wakati wa kuzitumia! Katika sehemu hii, utatuma maelekezo kwa wakala kujaribu na kuthibitisha kama wakala anatumia zana sahihi kutoka kwa server ya calculator MCP.

![Screenshot ya kiolesura cha Calculator Agent katika AI Toolkit ya Visual Studio Code. Paneli ya kushoto, chini ya “Tools,” server ya MCP iitwayo local-server-calculator_server imeongezwa, ikionyesha zana nne zinazopatikana: add, subtract, multiply, na divide. Alama inaonyesha zana nne zimeshajumuishwa. Chini kuna sehemu iliyofichwa ya “Structure output” na kitufe cha buluu “Run.” Paneli ya kulia, chini ya “Model Response,” wakala anaita zana za multiply na subtract na maingizo {"a": 3, "b": 25} na {"a": 75, "b": 20} mtawalia. “Tool Response” ya mwisho inaonyesha 75.0. Kitufe cha “View Code” kiko chini.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.sw.png)

Utaendesha server ya calculator MCP kwenye mashine yako ya maendeleo kama mteja wa MCP kupitia **Agent Builder**.

1. Bonyeza `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Nimenunua vitu 3 kila kimoja bei ni $25, kisha nikatumia punguzo la $20. Nililipa kiasi gani?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` thamani zimewekwa kwa zana ya **subtract**.
    - Majibu kutoka kwa kila zana yanatolewa katika **Tool Response** husika.
    - Matokeo ya mwisho kutoka kwa modeli yanatolewa katika **Model Response** ya mwisho.
1. Tuma maelekezo zaidi kujaribu zaidi wakala. Unaweza kubadilisha maelekezo yaliyopo katika uwanja wa **User prompt** kwa kubonyeza na kubadilisha maelekezo yaliyopo.
1. Ukimaliza kujaribu wakala, unaweza kuacha server kupitia **terminal** kwa kubonyeza **CTRL/CMD+C** kuacha.

## Kazi ya Nyumbani

Jaribu kuongeza zana mpya kwenye faili yako ya **server.py** (mfano: rudisha mzizi wa mraba wa nambari). Tuma maelekezo zaidi yanayohitaji wakala kutumia zana mpya (au zana zilizopo). Hakikisha unaanzisha upya server ili ipokee zana mpya.

## Suluhisho

[Suluhisho](./solution/README.md)

## Muhimu Kukumbuka

Mambo muhimu ya kuchukua kutoka sura hii ni:

- Extension ya AI Toolkit ni mteja mzuri unaokuwezesha kutumia MCP Servers na zana zao.
- Unaweza kuongeza zana mpya kwa MCP servers, ukiongeza uwezo wa wakala kufanikisha mahitaji yanayobadilika.
- AI Toolkit ina templates (mfano, templates za server ya MCP ya Python) zinazorahisisha uundaji wa zana za kawaida.

## Rasilimali Zaidi

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Ifuatayo

Ifuatayo: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Kandido**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Hati asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.