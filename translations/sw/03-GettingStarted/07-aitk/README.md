<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98bcd044860716da5819e31c152813b7",
<<<<<<< HEAD
  "translation_date": "2025-08-18T19:05:56+00:00",
=======
  "translation_date": "2025-08-18T14:10:16+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sw"
}
-->
# Kutumia seva kutoka kwa kiendelezi cha AI Toolkit kwa Visual Studio Code

<<<<<<< HEAD
Unapojenga wakala wa AI, si tu kuhusu kutoa majibu ya busara; ni pia kuhusu kumpa wakala wako uwezo wa kuchukua hatua. Hapo ndipo Model Context Protocol (MCP) inapoingia. MCP inarahisisha mawakala kufikia zana na huduma za nje kwa njia thabiti. Fikiria kama kuunganisha wakala wako kwenye kisanduku cha zana ambacho anaweza *kweli* kutumia.

Tuseme umeunganisha wakala wako na seva ya MCP ya kikokotoo. Ghafla, wakala wako anaweza kufanya hesabu za hisabati kwa kupokea tu maelekezo kama “Je, 47 mara 89 ni ngapi?”—hakuna haja ya kuweka mantiki kwa mkono au kujenga API maalum.

## Muhtasari

Somo hili linashughulikia jinsi ya kuunganisha seva ya MCP ya kikokotoo na wakala kwa kutumia kiendelezi cha [AI Toolkit](https://aka.ms/AIToolkit) katika Visual Studio Code, na kumwezesha wakala wako kufanya hesabu za hisabati kama kuongeza, kutoa, kuzidisha, na kugawanya kupitia lugha ya kawaida.

AI Toolkit ni kiendelezi chenye nguvu kwa Visual Studio Code kinachorahisisha maendeleo ya mawakala. Wahandisi wa AI wanaweza kwa urahisi kujenga programu za AI kwa kuendeleza na kujaribu mifano ya AI ya kizazi—kwa ndani au kwenye wingu. Kiendelezi hiki kinaunga mkono mifano mingi maarufu ya kizazi inayopatikana leo.

*Kidokezo*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.
=======
Unapojenga wakala wa AI, si tu kuhusu kutoa majibu ya busara; ni pia kuhusu kumpa wakala wako uwezo wa kuchukua hatua. Hapo ndipo Model Context Protocol (MCP) inapoingia. MCP hufanya iwe rahisi kwa mawakala kufikia zana na huduma za nje kwa njia thabiti. Fikiria kama kuunganisha wakala wako kwenye kisanduku cha zana ambacho anaweza *kweli* kutumia.

Tuseme umeunganisha wakala wako na seva ya MCP ya kalkuleta. Ghafla, wakala wako anaweza kufanya hesabu za hisabati kwa kupokea tu swali kama “Je, 47 mara 89 ni ngapi?”—hakuna haja ya kuweka mantiki kwa mkono au kujenga API maalum.

## Muhtasari

Somo hili linaelezea jinsi ya kuunganisha seva ya MCP ya kalkuleta na wakala kwa kutumia kiendelezi cha [AI Toolkit](https://aka.ms/AIToolkit) katika Visual Studio Code, na kumwezesha wakala wako kufanya hesabu za hisabati kama kuongeza, kutoa, kuzidisha, na kugawanya kupitia lugha ya kawaida.

AI Toolkit ni kiendelezi chenye nguvu kwa Visual Studio Code kinachorahisisha maendeleo ya mawakala. Wahandisi wa AI wanaweza kwa urahisi kujenga programu za AI kwa kuunda na kujaribu mifano ya AI ya kizazi—kwa ndani au kwenye wingu. Kiendelezi hiki kinaunga mkono mifano mingi ya kizazi inayopatikana leo.

*Kumbuka*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.
>>>>>>> origin/main

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutumia seva ya MCP kupitia AI Toolkit.
- Kuseti usanidi wa wakala ili kumwezesha kugundua na kutumia zana zinazotolewa na seva ya MCP.
- Kutumia zana za MCP kupitia lugha ya kawaida.

## Njia

Hivi ndivyo tunavyohitaji kukaribia hili kwa kiwango cha juu:

<<<<<<< HEAD
- Unda wakala na ufafanue maelekezo ya mfumo wake.
- Unda seva ya MCP yenye zana za kikokotoo.
=======
- Unda wakala na ufafanue mwongozo wake wa mfumo.
- Unda seva ya MCP yenye zana za kalkuleta.
>>>>>>> origin/main
- Unganisha Agent Builder na seva ya MCP.
- Jaribu mwito wa zana za wakala kupitia lugha ya kawaida.

Sawa, sasa tunapojua mtiririko, hebu tuseti wakala wa AI ili kutumia zana za nje kupitia MCP, na kuboresha uwezo wake!

<<<<<<< HEAD
## Mahitaji
=======
## Mahitaji ya Awali
>>>>>>> origin/main

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit kwa Visual Studio Code](https://aka.ms/AIToolkit)

## Zoezi: Kutumia seva

> [!WARNING]
<<<<<<< HEAD
> Kidokezo kwa Watumiaji wa macOS. Kwa sasa tunachunguza tatizo linaloathiri usakinishaji wa utegemezi kwenye macOS. Kwa sababu hiyo, watumiaji wa macOS hawataweza kukamilisha mafunzo haya kwa sasa. Tutasasisha maelekezo mara tu suluhisho litakapopatikana. Asante kwa uvumilivu na uelewa wako!
=======
> Kumbuka kwa Watumiaji wa macOS. Kwa sasa tunachunguza tatizo linaloathiri usakinishaji wa utegemezi kwenye macOS. Kwa sababu hiyo, watumiaji wa macOS hawataweza kukamilisha mafunzo haya kwa sasa. Tutasasisha maelekezo mara tu suluhisho litakapopatikana. Asante kwa uvumilivu na uelewa wako!
>>>>>>> origin/main

Katika zoezi hili, utajenga, kuendesha, na kuboresha wakala wa AI na zana kutoka kwa seva ya MCP ndani ya Visual Studio Code kwa kutumia AI Toolkit.

### -0- Hatua ya awali, ongeza mfano wa OpenAI GPT-4o kwenye My Models

Zoezi linatumia mfano wa **GPT-4o**. Mfano unapaswa kuongezwa kwenye **My Models** kabla ya kuunda wakala.

1. Fungua kiendelezi cha **AI Toolkit** kutoka kwa **Activity Bar**.
1. Katika sehemu ya **Catalog**, chagua **Models** kufungua **Model Catalog**. Kuchagua **Models** kunafungua **Model Catalog** kwenye kichupo kipya cha mhariri.
1. Katika sehemu ya utafutaji ya **Model Catalog**, ingiza **OpenAI GPT-4o**.
<<<<<<< HEAD
1. Bonyeza **+ Add** ili kuongeza mfano kwenye orodha yako ya **My Models**. Hakikisha umechagua mfano unaoandaliwa na **GitHub**.
=======
1. Bonyeza **+ Add** ili kuongeza mfano kwenye orodha yako ya **My Models**. Hakikisha umechagua mfano ambao **Hosted by GitHub**.
>>>>>>> origin/main
1. Katika **Activity Bar**, hakikisha kwamba mfano wa **OpenAI GPT-4o** unaonekana kwenye orodha.

### -1- Unda wakala

<<<<<<< HEAD
**Agent (Prompt) Builder** inakuwezesha kuunda na kubinafsisha mawakala wako wenye nguvu wa AI. Katika sehemu hii, utaunda wakala mpya na kumteua mfano wa kuendesha mazungumzo.
=======
**Agent (Prompt) Builder** hukuwezesha kuunda na kubinafsisha mawakala wako wenye nguvu wa AI. Katika sehemu hii, utaunda wakala mpya na kumteua mfano wa kuendesha mazungumzo.
>>>>>>> origin/main

1. Fungua kiendelezi cha **AI Toolkit** kutoka kwa **Activity Bar**.
1. Katika sehemu ya **Tools**, chagua **Agent (Prompt) Builder**. Kuchagua **Agent (Prompt) Builder** kunafungua **Agent (Prompt) Builder** kwenye kichupo kipya cha mhariri.
1. Bonyeza kitufe cha **+ New Agent**. Kiendelezi kitaanzisha mwongozo wa usanidi kupitia **Command Palette**.
1. Ingiza jina **Calculator Agent** na bonyeza **Enter**.
1. Katika **Agent (Prompt) Builder**, kwa sehemu ya **Model**, chagua mfano wa **OpenAI GPT-4o (via GitHub)**.

<<<<<<< HEAD
### -2- Unda maelekezo ya mfumo kwa wakala

Baada ya kuunda muundo wa wakala, ni wakati wa kufafanua tabia na kusudi lake. Katika sehemu hii, utatumia kipengele cha **Generate system prompt** kuelezea tabia inayokusudiwa ya wakala—katika kesi hii, wakala wa kikokotoo—na kumruhusu mfano kuandika maelekezo ya mfumo kwa ajili yako.

1. Kwa sehemu ya **Prompts**, bonyeza kitufe cha **Generate system prompt**. Kitufe hiki hufungua mjenzi wa maelekezo ambao hutumia AI kuunda maelekezo ya mfumo kwa wakala.
1. Katika dirisha la **Generate a prompt**, ingiza yafuatayo: `Wewe ni msaidizi wa hesabu mwenye msaada na ufanisi. Unapopewa tatizo linalohusisha hesabu za msingi, unajibu kwa matokeo sahihi.`
1. Bonyeza kitufe cha **Generate**. Arifa itaonekana kwenye kona ya chini-kulia ikithibitisha kwamba maelekezo ya mfumo yanatengenezwa. Mara tu utengenezaji wa maelekezo ukikamilika, maelekezo yataonekana kwenye sehemu ya **System prompt** ya **Agent (Prompt) Builder**.
=======
### -2- Unda mwongozo wa mfumo kwa wakala

Baada ya kuunda muundo wa wakala, ni wakati wa kufafanua tabia na kusudi lake. Katika sehemu hii, utatumia kipengele cha **Generate system prompt** kuelezea tabia inayokusudiwa ya wakala—katika kesi hii, wakala wa kalkuleta—na kumruhusu mfano kuandika mwongozo wa mfumo kwa ajili yako.

1. Kwa sehemu ya **Prompts**, bonyeza kitufe cha **Generate system prompt**. Kitufe hiki hufungua mjenzi wa mwongozo ambao hutumia AI kuunda mwongozo wa mfumo kwa wakala.
1. Katika dirisha la **Generate a prompt**, ingiza yafuatayo: `Wewe ni msaidizi wa hesabu mwenye msaada na ufanisi. Unapopewa tatizo linalohusisha hesabu za msingi, unajibu kwa matokeo sahihi.`
1. Bonyeza kitufe cha **Generate**. Arifa itaonekana kwenye kona ya chini-kulia ikithibitisha kwamba mwongozo wa mfumo unazalishwa. Mara tu kizazi cha mwongozo kitakapokamilika, mwongozo utaonekana kwenye sehemu ya **System prompt** ya **Agent (Prompt) Builder**.
>>>>>>> origin/main
1. Kagua **System prompt** na ubadilishe ikiwa ni lazima.

### -3- Unda seva ya MCP

<<<<<<< HEAD
Sasa kwa kuwa umefafanua maelekezo ya mfumo wa wakala wako—yanayoongoza tabia na majibu yake—ni wakati wa kumpa wakala uwezo wa vitendo. Katika sehemu hii, utaunda seva ya MCP ya kikokotoo yenye zana za kutekeleza hesabu za kuongeza, kutoa, kuzidisha, na kugawanya. Seva hii itamwezesha wakala wako kufanya hesabu za hisabati kwa wakati halisi kwa kujibu maelekezo ya lugha ya kawaida.

AI Toolkit ina vifaa vya kutengeneza seva yako ya MCP kwa urahisi. Tutatumia kiolezo cha Python kuunda seva ya MCP ya kikokotoo.

*Kidokezo*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.
=======
Sasa kwa kuwa umefafanua mwongozo wa mfumo wa wakala wako—unaongoza tabia na majibu yake—ni wakati wa kumpa wakala uwezo wa vitendo. Katika sehemu hii, utaunda seva ya MCP ya kalkuleta yenye zana za kutekeleza hesabu za kuongeza, kutoa, kuzidisha, na kugawanya. Seva hii itamwezesha wakala wako kufanya hesabu za wakati halisi kwa kujibu maswali ya lugha ya kawaida.

AI Toolkit ina vifaa vya templates ili kurahisisha kuunda seva yako ya MCP. Tutatumia template ya Python kuunda seva ya MCP ya kalkuleta.

*Kumbuka*: AI Toolkit kwa sasa inaunga mkono Python na TypeScript.
>>>>>>> origin/main

1. Katika sehemu ya **Tools** ya **Agent (Prompt) Builder**, bonyeza kitufe cha **+ MCP Server**. Kiendelezi kitaanzisha mwongozo wa usanidi kupitia **Command Palette**.
1. Chagua **+ Add Server**.
1. Chagua **Create a New MCP Server**.
<<<<<<< HEAD
1. Chagua **python-weather** kama kiolezo.
1. Chagua **Default folder** kuhifadhi kiolezo cha seva ya MCP.
1. Ingiza jina lifuatalo kwa seva: **Calculator**
1. Dirisha jipya la Visual Studio Code litafunguka. Chagua **Yes, I trust the authors**.
1. Kutumia terminal (**Terminal** > **New Terminal**), unda mazingira ya kawaida: `python -m venv .venv`
1. Kutumia terminal, wezesha mazingira ya kawaida:
=======
1. Chagua **python-weather** kama template.
1. Chagua **Default folder** kuhifadhi template ya seva ya MCP.
1. Ingiza jina lifuatalo kwa seva: **Calculator**
1. Dirisha jipya la Visual Studio Code litafunguka. Chagua **Yes, I trust the authors**.
1. Kutumia terminal (**Terminal** > **New Terminal**), unda mazingira ya virtual: `python -m venv .venv`
1. Kutumia terminal, wezesha mazingira ya virtual:
>>>>>>> origin/main
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source .venv/bin/activate`
1. Kutumia terminal, sakinisha utegemezi: `pip install -e .[dev]`
1. Katika **Explorer** ya **Activity Bar**, panua saraka ya **src** na chagua **server.py** kufungua faili kwenye mhariri.
1. Badilisha msimbo katika faili ya **server.py** na yafuatayo na uhifadhi:

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

<<<<<<< HEAD
### -4- Endesha wakala na seva ya MCP ya kikokotoo

Sasa kwa kuwa wakala wako ana zana, ni wakati wa kuzitumia! Katika sehemu hii, utaingiza maelekezo kwa wakala ili kujaribu na kuthibitisha kama wakala anatumia zana sahihi kutoka kwa seva ya MCP ya kikokotoo.

1. Bonyeza `F5` kuanza kutatua seva ya MCP. **Agent (Prompt) Builder** itafunguka kwenye kichupo kipya cha mhariri. Hali ya seva inaonekana kwenye terminal.
1. Katika sehemu ya **User prompt** ya **Agent (Prompt) Builder**, ingiza maelekezo yafuatayo: `Nilinunua vitu 3 vyenye bei ya $25 kila kimoja, kisha nikatumia punguzo la $20. Niliwalipa kiasi gani?`
=======
### -4- Endesha wakala na seva ya MCP ya kalkuleta

Sasa kwa kuwa wakala wako ana zana, ni wakati wa kuzitumia! Katika sehemu hii, utaingiza maswali kwa wakala ili kujaribu na kuthibitisha kama wakala anatumia zana sahihi kutoka kwa seva ya MCP ya kalkuleta.

1. Bonyeza `F5` kuanza ku-debug seva ya MCP. **Agent (Prompt) Builder** itafunguka kwenye kichupo kipya cha mhariri. Hali ya seva inaonekana kwenye terminal.
1. Katika sehemu ya **User prompt** ya **Agent (Prompt) Builder**, ingiza swali lifuatalo: `Nilinunua vitu 3 vyenye bei ya $25 kila kimoja, kisha nikatumia punguzo la $20. Niliwalipa kiasi gani?`
>>>>>>> origin/main
1. Bonyeza kitufe cha **Run** kuzalisha jibu la wakala.
1. Kagua matokeo ya wakala. Mfano unapaswa kuhitimisha kwamba ulilipa **$55**.
1. Hivi ndivyo kinachopaswa kutokea:
    - Wakala huchagua zana za **multiply** na **subtract** kusaidia katika hesabu.
    - Thamani za `a` na `b` zinatolewa kwa zana ya **multiply**.
    - Thamani za `a` na `b` zinatolewa kwa zana ya **subtract**.
    - Jibu kutoka kwa kila zana linatolewa katika sehemu ya **Tool Response**.
    - Matokeo ya mwisho kutoka kwa mfano yanatolewa katika sehemu ya mwisho ya **Model Response**.
<<<<<<< HEAD
1. Ingiza maelekezo ya ziada ili kujaribu zaidi wakala. Unaweza kubadilisha maelekezo yaliyopo katika sehemu ya **User prompt** kwa kubonyeza ndani ya sehemu hiyo na kubadilisha maelekezo yaliyopo.
1. Mara tu unapomaliza kujaribu wakala, unaweza kusimamisha seva kupitia **terminal** kwa kuingiza **CTRL/CMD+C** kuacha.

## Kazi ya Nyumbani

Jaribu kuongeza zana ya ziada kwenye faili yako ya **server.py** (mfano: rudisha mzizi wa mraba wa nambari). Ingiza maelekezo ya ziada ambayo yatamfanya wakala kutumia zana yako mpya (au zana zilizopo). Hakikisha unarejesha seva ili kupakia zana mpya zilizoongezwa.
=======
1. Ingiza maswali ya ziada ili kujaribu zaidi wakala. Unaweza kubadilisha swali lililopo katika sehemu ya **User prompt** kwa kubonyeza ndani ya sehemu hiyo na kubadilisha swali lililopo.
1. Mara unapomaliza kujaribu wakala, unaweza kusimamisha seva kupitia **terminal** kwa kuingiza **CTRL/CMD+C** kuacha.

## Kazi ya Nyumbani

Jaribu kuongeza zana ya ziada kwenye faili yako ya **server.py** (mfano: rudisha mzizi wa mraba wa namba). Ingiza maswali ya ziada ambayo yatamfanya wakala kutumia zana yako mpya (au zana zilizopo). Hakikisha unarejesha seva ili kupakia zana mpya zilizoongezwa.
>>>>>>> origin/main

## Suluhisho

[Suluhisho](./solution/README.md)

## Mambo Muhimu ya Kujifunza

Mambo muhimu kutoka sura hii ni yafuatayo:

<<<<<<< HEAD
- Kiendelezi cha AI Toolkit ni mteja mzuri unaokuwezesha kutumia seva za MCP na zana zake.
- Unaweza kuongeza zana mpya kwenye seva za MCP, na kupanua uwezo wa wakala ili kukidhi mahitaji yanayobadilika.
- AI Toolkit inajumuisha violezo (mfano, violezo vya seva za MCP za Python) ili kurahisisha uundaji wa zana maalum.
=======
- Kiendelezi cha AI Toolkit ni mteja mzuri kinachokuwezesha kutumia seva za MCP na zana zake.
- Unaweza kuongeza zana mpya kwenye seva za MCP, na kupanua uwezo wa wakala ili kukidhi mahitaji yanayobadilika.
- AI Toolkit inajumuisha templates (mfano: templates za Python MCP server) ili kurahisisha kuunda zana maalum.
>>>>>>> origin/main

## Rasilimali za Ziada

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Nini Kinachofuata
<<<<<<< HEAD
- Kinachofuata: [Kujaribu na Kutatua Hitilafu](../08-testing/README.md)
=======
- Kinachofuata: [Kujaribu & Ku-debug](../08-testing/README.md)
>>>>>>> origin/main

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kutumia huduma ya tafsiri ya kitaalamu ya binadamu. Hatutawajibika kwa maelewano mabaya au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.