<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:39:08+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sw"
}
-->
# Kutumia server kutoka kwa ugani wa AI Toolkit kwa Visual Studio Code

Unapojenga wakala wa AI, siyo tu kuhusu kutoa majibu mahiri; pia ni kuhusu kumpa wakala wako uwezo wa kuchukua hatua. Hapa ndipo Model Context Protocol (MCP) inapoingia. MCP hufanya iwe rahisi kwa mawakala kufikia zana na huduma za nje kwa njia thabiti. Fikiria kama unamunganisha wakala wako kwenye sanduku la zana ambalo anaweza *kutumia kweli*.

Tuseme unamuunganisha wakala kwenye server ya calculator ya MCP. Ghafla, wakala wako anaweza kufanya hesabu za hisabati kwa kupokea tu ombi kama “Ni 47 mara 89 ni kiasi gani?”—hakuna haja ya kuandika mantiki ngumu au kujenga API maalum.

## Muhtasari

Somo hili linaelezea jinsi ya kuunganisha server ya calculator MCP kwa wakala kwa kutumia ugani wa [AI Toolkit](https://aka.ms/AIToolkit) katika Visual Studio Code, na kumwezesha wakala wako kufanya hesabu kama kuongeza, kutoa, kuzidisha, na kugawanya kupitia lugha ya kawaida.

AI Toolkit ni ugani wenye nguvu kwa Visual Studio Code unaorahisisha maendeleo ya mawakala. Wahandisi wa AI wanaweza kujenga programu za AI kwa urahisi kwa kuunda na kujaribu mifano ya AI ya kizazi—kama kwa ndani au kwenye wingu. Ugani huu unaunga mkono mifano mingi mikubwa ya kizazi inayopatikana leo.

*Kumbuka*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutumia server ya MCP kupitia AI Toolkit.
- Kusanidi usanidi wa wakala ili kumwezesha kugundua na kutumia zana zinazotolewa na server ya MCP.
- Kutumia zana za MCP kupitia lugha ya kawaida.

## Mbinu

Hivi ndivyo tunavyopaswa kuishughulikia kwa kiwango cha juu:

- Tengeneza wakala na ufafanue ombi la mfumo wake.
- Tengeneza server ya MCP yenye zana za calculator.
- Unganisha Agent Builder na server ya MCP.
- Jaribu kuitwa kwa zana za wakala kupitia lugha ya kawaida.

Nzuri, sasa tunapoelewa mtiririko, tuchague wakala wa AI kutumia zana za nje kupitia MCP, tukiongeza uwezo wake!

## Mahitaji ya Awali

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit kwa Visual Studio Code](https://aka.ms/AIToolkit)

## Zoef: Kutumia server

Katika zoezi hili, utajenga, kuendesha, na kuboresha wakala wa AI kwa kutumia zana kutoka kwa server ya MCP ndani ya Visual Studio Code kwa kutumia AI Toolkit.

### -0- Hatua ya awali, ongeza mfano wa OpenAI GPT-4o kwenye My Models

Zoezi linatumia mfano wa **GPT-4o**. Mfano huu unapaswa kuongezwa kwenye **My Models** kabla ya kuunda wakala.

![Picha ya kiolesura cha kuchagua mfano katika ugani wa AI Toolkit wa Visual Studio Code. Kichwa kinasema "Tafuta mfano unaofaa kwa Suluhisho lako la AI" na kichwa kidogo kinahimiza watumiaji kugundua, kujaribu, na kupeleka mifano ya AI. Chini, chini ya “Popular Models,” kuna kadi sita za mifano: DeepSeek-R1 (inayohudumiwa na GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Ndogo, Haraka), na DeepSeek-R1 (inayohudumiwa na Ollama). Kadi kila moja ina chaguo za “Add” au “Try in Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.sw.png)

1. Fungua ugani wa **AI Toolkit** kutoka **Activity Bar**.
1. Katika sehemu ya **Catalog**, chagua **Models** kufungua **Model Catalog**. Kuchagua **Models** hufungua **Model Catalog** kwenye kichupo kipya cha mhariri.
1. Katika upau wa utafutaji wa **Model Catalog**, andika **OpenAI GPT-4o**.
1. Bonyeza **+ Add** kuongeza mfano kwenye orodha yako ya **My Models**. Hakikisha umechagua mfano unaoendeshwa na **GitHub**.
1. Katika **Activity Bar**, thibitisha kuwa mfano wa **OpenAI GPT-4o** unaonekana kwenye orodha.

### -1- Unda wakala

**Agent (Prompt) Builder** inakuwezesha kuunda na kubinafsisha mawakala wako wenye nguvu za AI. Katika sehemu hii, utaunda wakala mpya na kumtenga mfano wa kuendesha mazungumzo.

![Picha ya kiolesura cha "Calculator Agent" katika ugani wa AI Toolkit kwa Visual Studio Code. Paneli ya kushoto inaonyesha mfano ulioteuliwa "OpenAI GPT-4o (via GitHub)." Ombi la mfumo linasema "Wewe ni profesa wa chuo kikuu anaye fundisha hisabati," na ombi la mtumiaji linasema, "Nielezee mlinganyo wa Fourier kwa maneno rahisi." Chaguzi za ziada ni vifungo vya kuongeza zana, kuwezesha MCP Server, na kuchagua muundo wa matokeo. Kuna kitufe cha buluu cha “Run” chini. Paneli ya kulia inaonyesha "Anza na Mifano," na mawakala watatu wa mfano: Web Developer (na MCP Server, Second-Grade Simplifier, na Dream Interpreter, kila mmoja na maelezo mafupi ya kazi zao.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.sw.png)

1. Fungua ugani wa **AI Toolkit** kutoka **Activity Bar**.
1. Katika sehemu ya **Tools**, chagua **Agent (Prompt) Builder**. Kuchagua **Agent (Prompt) Builder** hufungua kichupo kipya cha mhariri.
1. Bonyeza kitufe cha **+ New Agent**. Ugani utaanzisha mtaalamu wa usanidi kupitia **Command Palette**.
1. Andika jina **Calculator Agent** kisha bonyeza **Enter**.
1. Katika **Agent (Prompt) Builder**, kwa sehemu ya **Model**, chagua mfano wa **OpenAI GPT-4o (via GitHub)**.

### -2- Unda ombi la mfumo kwa wakala

Baada ya kuanzisha wakala, ni wakati wa kufafanua tabia na kusudi lake. Katika sehemu hii, utatumia kipengele cha **Generate system prompt** kuelezea tabia inayotarajiwa ya wakala—katika kesi hii, wakala wa calculator—na kumruhusu mfano kuandika ombi la mfumo kwa niaba yako.

![Picha ya kiolesura cha "Calculator Agent" katika AI Toolkit kwa Visual Studio Code na dirisha la modal linaloitwa "Generate a prompt." Modal linaelezea kuwa templeti ya ombi inaweza kutengenezwa kwa kushiriki maelezo ya msingi na lina sanduku la maandishi lenye mfano wa ombi wa mfumo: "Wewe ni msaidizi wa hisabati mwenye msaada na ufanisi. Unapopewa tatizo linalohusiana na hesabu za msingi, unajibu kwa jibu sahihi." Chini ya sanduku kuna vifungo vya "Close" na "Generate." Nyuma, sehemu ya usanidi wa wakala inaonekana, ikiwa ni pamoja na mfano ulioteuliwa "OpenAI GPT-4o (via GitHub)" na sehemu za ombi la mfumo na mtumiaji.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.sw.png)

1. Kwa sehemu ya **Prompts**, bonyeza kitufe cha **Generate system prompt**. Kitufe hiki hufungua mjenzi wa ombi unaotumia AI kuunda ombi la mfumo kwa wakala.
1. Katika dirisha la **Generate a prompt**, andika yafuatayo: `Wewe ni msaidizi wa hisabati mwenye msaada na ufanisi. Unapopewa tatizo linalohusiana na hesabu za msingi, unajibu kwa jibu sahihi.`
1. Bonyeza kitufe cha **Generate**. Taarifa itatokea chini kulia kuthibitisha kuwa ombi la mfumo linaandaliwa. Baada ya kumaliza, ombi litaonekana kwenye sehemu ya **System prompt** ya **Agent (Prompt) Builder**.
1. Kagua **System prompt** na ubadilishe kama inahitajika.

### -3- Unda server ya MCP

Sasa baada ya kufafanua ombi la mfumo wa wakala—linaloongoza tabia na majibu yake—ni wakati wa kumpa wakala uwezo wa vitendo. Katika sehemu hii, utaunda server ya calculator MCP yenye zana za kufanya hesabu za kuongeza, kutoa, kuzidisha, na kugawanya. Server hii itamwezesha wakala wako kufanya hesabu za wakati halisi kwa majibu ya lugha ya kawaida.

![Picha ya sehemu ya chini ya kiolesura cha Calculator Agent katika ugani wa AI Toolkit kwa Visual Studio Code. Inaonyesha menyu zinazoweza kupanuliwa za “Tools” na “Structure output,” pamoja na menyu ya kushuka chini yenye lebo “Choose output format” iliyowekwa kwa “text.” Kushoto kuna kitufe cha “+ MCP Server” cha kuongeza server ya Model Context Protocol. Picha ya ikoni ya picha inaonekana juu ya sehemu ya Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.sw.png)

AI Toolkit ina templeti zinazorahisisha kuunda server yako ya MCP. Tutatumia templeti ya Python kuunda server ya calculator MCP.

*Kumbuka*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.

1. Katika sehemu ya **Tools** ya **Agent (Prompt) Builder**, bonyeza kitufe cha **+ MCP Server**. Ugani utaanzisha mtaalamu wa usanidi kupitia **Command Palette**.
1. Chagua **+ Add Server**.
1. Chagua **Create a New MCP Server**.
1. Chagua templeti ya **python-weather**.
1. Chagua **Default folder** kuhifadhi templeti ya server ya MCP.
1. Andika jina lifuatalo kwa server: **Calculator**
1. Dirisha jipya la Visual Studio Code litafunguka. Chagua **Yes, I trust the authors**.
1. Kutumia terminal (**Terminal** > **New Terminal**), tengeneza mazingira ya virtual: `python -m venv .venv`
1. Kutumia terminal, wezesha mazingira ya virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Kutumia terminal, sakinisha utegemezi: `pip install -e .[dev]`
1. Katika mtazamo wa **Explorer** wa **Activity Bar**, panua saraka ya **src** na chagua **server.py** kufungua faili katika mhariri.
1. Badilisha msimbo katika faili ya **server.py** na yafuatayo kisha hifadhi:

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

Sasa wakala wako ana zana, ni wakati wa kuzitumia! Katika sehemu hii, utatuma maombi kwa wakala kujaribu na kuthibitisha kama wakala anatumia zana sahihi kutoka kwa server ya calculator MCP.

![Picha ya kiolesura cha Calculator Agent katika ugani wa AI Toolkit kwa Visual Studio Code. Paneli ya kushoto, chini ya “Tools,” server ya MCP iitwayo local-server-calculator_server imeongezwa, ikionyesha zana nne zinazopatikana: add, subtract, multiply, na divide. Bango linaonyesha zana nne ziko hai. Chini kuna sehemu iliyofungwa ya “Structure output” na kitufe cha buluu cha “Run.” Paneli ya kulia, chini ya “Model Response,” wakala anaitisha zana za multiply na subtract kwa maingizo {"a": 3, "b": 25} na {"a": 75, "b": 20} mtawalia. Jibu la mwisho la “Tool Response” linaonyeshwa kama 75.0. Kitufe cha “View Code” kiko chini.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.sw.png)

Utaendesha server ya calculator MCP kwenye mashine yako ya maendeleo kama mteja wa MCP kupitia **Agent Builder**.

1. Bonyeza `F5` kuanza debugging ya server ya MCP. **Agent (Prompt) Builder** itaonekana kwenye kichupo kipya cha mhariri. Hali ya server itaonekana kwenye terminal.
1. Katika sehemu ya **User prompt** ya **Agent (Prompt) Builder**, andika ombi lifuatalo: `Nimenunua vitu 3 kila kimoja kwa bei ya $25, kisha nikatumia punguzo la $20. Nililipa kiasi gani?`
1. Bonyeza kitufe cha **Run** kuunda jibu la wakala.
1. Kagua matokeo ya wakala. Mfano unapaswa kuhitimisha kuwa ulilipa **$55**.
1. Hapa ni muhtasari wa kinachotakiwa kutokea:
    - Wakala huchagua zana za **multiply** na **subtract** kusaidia katika hesabu.
    - Thamani za `a` na `b` zinatengwa kwa zana ya **multiply**.
    - Thamani za `a` na `b` zinatengwa kwa zana ya **subtract**.
    - Jibu kutoka kwa kila zana hutolewa katika sehemu ya **Tool Response**.
    - Matokeo ya mwisho kutoka kwa mfano hutolewa katika sehemu ya mwisho ya **Model Response**.
1. Tuma maombi zaidi kujaribu zaidi wakala. Unaweza kubadilisha ombi lililopo katika sehemu ya **User prompt** kwa kubonyeza na kuandika upya.
1. Ukimaliza kujaribu wakala, unaweza kuacha server kupitia **terminal** kwa kubonyeza **CTRL/CMD+C** kuacha.

## Kazi ya Nyumbani

Jaribu kuongeza zana mpya kwenye faili yako ya **server.py** (mfano: rudisha mzizi wa mraba wa nambari). Tuma maombi zaidi yanayomlazimu wakala kutumia zana yako mpya (au zana zilizopo). Hakikisha unaanzisha upya server ili zana mpya zipakuliwe.

## Suluhisho

[Suluhisho](./solution/README.md)

## Muhimu wa Kumbuka

Mambo muhimu ya kuchukua kutoka sura hii ni:

- Ugani wa AI Toolkit ni mteja mzuri unaokuwezesha kutumia MCP Servers na zana zao.
- Unaweza kuongeza zana mpya kwa MCP servers, ukiongeza uwezo wa wakala kukidhi mahitaji yanayobadilika.
- AI Toolkit ina templeti (mfano, templeti za server ya MCP za Python) zinazorahisisha kuunda zana maalum.

## Rasilimali Zaidi

- [Nyaraka za AI Toolkit](https://aka.ms/AIToolkit/doc)

## Kinachofuata
- Ifuatayo: [Testing & Debugging](../08-testing/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.