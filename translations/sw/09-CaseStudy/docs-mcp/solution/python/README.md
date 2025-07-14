<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:43:03+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "sw"
}
-->
# Kizalishaji cha Mpango wa Kusoma kwa Chainlit & Microsoft Learn Docs MCP

## Mahitaji ya Awali

- Python 3.8 au zaidi
- pip (msimamizi wa vifurushi vya Python)
- Muunganisho wa intaneti kuweza kuunganishwa na seva ya Microsoft Learn Docs MCP

## Usanidi

1. Nakili hifadhidata hii au pakua faili za mradi.
2. Sakinisha utegemezi unaohitajika:

   ```bash
   pip install -r requirements.txt
   ```

## Matumizi

### Hali ya 1: Utafutaji Rahisi kwa Docs MCP
Mteja wa mstari wa amri unaounganisha na seva ya Docs MCP, kutuma swali, na kuchapisha matokeo.

1. Endesha script:
   ```bash
   python scenario1.py
   ```
2. Weka swali lako la nyaraka kwenye sehemu ya kuingiza.

### Hali ya 2: Kizalishaji cha Mpango wa Kusoma (Chainlit Web App)
Kiolesura cha wavuti (kinatumia Chainlit) kinachowezesha watumiaji kuunda mpango wa kusoma wa kibinafsi, wa wiki kwa wiki kwa mada yoyote ya kiufundi.

1. Anzisha app ya Chainlit:
   ```bash
   chainlit run scenario2.py
   ```
2. Fungua URL ya ndani iliyotolewa kwenye terminal yako (mfano, http://localhost:8000) kwenye kivinjari chako.
3. Katika dirisha la mazungumzo, ingiza mada yako ya kusoma na idadi ya wiki unayotaka kusoma (mfano, "AI-900 certification, 8 weeks").
4. App itajibu na mpango wa kusoma wa wiki kwa wiki, ikiwa na viungo vya nyaraka zinazohusiana za Microsoft Learn.

**Mazingira ya Kuweka Yanayohitajika:**

Ili kutumia Hali ya 2 (app ya wavuti ya Chainlit na Azure OpenAI), lazima uweke mabadiliko ya mazingira yafuatayo katika faili `.env` kwenye saraka ya `python`:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Jaza maelezo haya kwa taarifa zako za rasilimali za Azure OpenAI kabla ya kuendesha app.

> **Tip:** Unaweza kwa urahisi kupeleka mifano yako mwenyewe ukitumia [Azure AI Foundry](https://ai.azure.com/).

### Hali ya 3: Nyaraka Ndani ya Mhariri na MCP Server katika VS Code

Badala ya kubadili tabo za kivinjari kutafuta nyaraka, unaweza kuleta Microsoft Learn Docs moja kwa moja ndani ya VS Code yako ukitumia seva ya MCP. Hii inakuwezesha:
- Kutafuta na kusoma nyaraka ndani ya VS Code bila kuondoka kwenye mazingira yako ya kuandika msimbo.
- Kurejelea nyaraka na kuingiza viungo moja kwa moja kwenye README au faili za kozi.
- Kutumia GitHub Copilot na MCP pamoja kwa mtiririko wa kazi wa nyaraka unaotumia AI kwa urahisi.

**Mifano ya Matumizi:**
- Kuongeza viungo vya rejea haraka kwenye README wakati wa kuandika nyaraka za kozi au mradi.
- Kutumia Copilot kuunda msimbo na MCP kupata na kutaja nyaraka zinazohusiana mara moja.
- Kubaki makini ndani ya mhariri wako na kuongeza ufanisi.

> [!IMPORTANT]
> Hakikisha una usanidi halali wa [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) katika eneo la kazi lako (mahali ni `.vscode/mcp.json`).

## Kwa Nini Chainlit kwa Hali ya 2?

Chainlit ni mfumo wa kisasa wa chanzo huria wa kujenga programu za mazungumzo za wavuti. Inafanya iwe rahisi kuunda kiolesura cha mtumiaji cha mazungumzo kinachounganisha na huduma za nyuma kama seva ya Microsoft Learn Docs MCP. Mradi huu unatumia Chainlit kutoa njia rahisi na ya mwingiliano ya kuunda mipango ya kusoma ya kibinafsi kwa wakati halisi. Kwa kutumia Chainlit, unaweza haraka kujenga na kupeleka zana za mazungumzo zinazoongeza ufanisi na kujifunza.

## Hii Inafanya Nini

App hii inaruhusu watumiaji kuunda mpango wa kusoma wa kibinafsi kwa kuingiza mada na muda tu. App inachambua maingizo yako, kuomba seva ya Microsoft Learn Docs MCP kwa maudhui yanayofaa, na kupanga matokeo katika mpango uliopangwa wa wiki kwa wiki. Mapendekezo ya kila wiki yanaonyeshwa katika mazungumzo, kufanya iwe rahisi kufuatilia na kuendelea na maendeleo yako. Muunganiko huu unahakikisha unapata rasilimali za kujifunza za hivi karibuni na zinazofaa kila wakati.

## Maswali ya Mfano

Jaribu maswali haya katika dirisha la mazungumzo kuona jinsi app inavyojibu:

- `AI-900 certification, 8 weeks`
- `Learn Azure Functions, 4 weeks`
- `Azure DevOps, 6 weeks`
- `Data engineering on Azure, 10 weeks`
- `Microsoft security fundamentals, 5 weeks`
- `Power Platform, 7 weeks`
- `Azure AI services, 12 weeks`
- `Cloud architecture, 9 weeks`

Mifano hii inaonyesha ufanisi wa app kwa malengo tofauti ya kujifunza na vipindi vya muda.

## Marejeleo

- [Chainlit Documentation](https://docs.chainlit.io/)
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.