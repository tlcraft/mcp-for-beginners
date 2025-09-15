<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:27:36+00:00",
  "source_file": "changelog.md",
  "language_code": "sw"
}
-->
# Changelog: MCP kwa Mtaala wa Kuanza

Hati hii ni rekodi ya mabadiliko yote muhimu yaliyofanywa kwenye mtaala wa Model Context Protocol (MCP) kwa wanaoanza. Mabadiliko yameandikwa kwa mpangilio wa kinyume cha wakati (mabadiliko mapya kwanza).

## Septemba 15, 2025

### Upanuzi wa Mada za Juu - Usafirishaji Maalum & Uhandisi wa Muktadha

#### Usafirishaji Maalum wa MCP (05-AdvancedTopics/mcp-transport/) - Mwongozo Mpya wa Utekelezaji wa Juu
- **README.md**: Mwongozo kamili wa utekelezaji wa mifumo maalum ya usafirishaji wa MCP
  - **Usafirishaji wa Azure Event Grid**: Utekelezaji wa usafirishaji wa matukio bila seva
    - Mifano ya C#, TypeScript, na Python na ujumuishaji wa Azure Functions
    - Mifumo ya usanifu wa matukio kwa suluhisho za MCP zinazoweza kupanuka
    - Wapokeaji wa webhook na usimamizi wa ujumbe unaosukumwa
  - **Usafirishaji wa Azure Event Hubs**: Utekelezaji wa usafirishaji wa mtiririko wa kasi ya juu
    - Uwezo wa mtiririko wa wakati halisi kwa hali za ucheleweshaji wa chini
    - Mikakati ya kugawanya na usimamizi wa alama za ukaguzi
    - Uboreshaji wa utendaji na upakiaji wa ujumbe
  - **Mifumo ya Ujumuishaji wa Biashara**: Mifano ya usanifu tayari kwa uzalishaji
    - Usindikaji wa MCP uliosambazwa kwenye Azure Functions nyingi
    - Usanifu mseto wa usafirishaji unaochanganya aina nyingi za usafirishaji
    - Mikakati ya uimara wa ujumbe, uaminifu, na usimamizi wa makosa
  - **Usalama & Ufuatiliaji**: Ujumuishaji wa Azure Key Vault na mifumo ya ufuatiliaji
    - Uthibitishaji wa utambulisho uliosimamiwa na ufikiaji wa kiwango cha chini
    - Telemetry ya Application Insights na ufuatiliaji wa utendaji
    - Mifumo ya kuvunja mzunguko na uvumilivu wa makosa
  - **Mifumo ya Kupima**: Mikakati kamili ya kupima usafirishaji maalum
    - Upimaji wa vitengo kwa kutumia mifumo ya kuiga na kuunda mfano
    - Upimaji wa ujumuishaji kwa kutumia Azure Test Containers
    - Mazingatio ya upimaji wa utendaji na mzigo

#### Uhandisi wa Muktadha (05-AdvancedTopics/mcp-contextengineering/) - Taaluma Inayochipuka ya AI
- **README.md**: Uchunguzi wa kina wa uhandisi wa muktadha kama uwanja unaochipuka
  - **Kanuni za Msingi**: Kushiriki muktadha kikamilifu, ufahamu wa maamuzi ya hatua, na usimamizi wa dirisha la muktadha
  - **Ulinganifu wa Itifaki ya MCP**: Jinsi usanifu wa MCP unavyoshughulikia changamoto za uhandisi wa muktadha
    - Vikwazo vya dirisha la muktadha na mikakati ya upakiaji wa hatua kwa hatua
    - Uamuzi wa umuhimu na upatikanaji wa muktadha wa nguvu
    - Ushughulikiaji wa muktadha wa njia nyingi na mazingatio ya usalama
  - **Mbinu za Utekelezaji**: Usanifu wa nyuzi moja dhidi ya usanifu wa mawakala wengi
    - Mbinu za kugawanya muktadha na kipaumbele
    - Upakiaji wa hatua kwa hatua wa muktadha na mikakati ya kubana
    - Mbinu za muktadha wa tabaka na uboreshaji wa upatikanaji
  - **Mfumo wa Kipimo**: Vipimo vinavyochipuka vya tathmini ya ufanisi wa muktadha
    - Ufanisi wa pembejeo, utendaji, ubora, na mazingatio ya uzoefu wa mtumiaji
    - Mbinu za majaribio za uboreshaji wa muktadha
    - Uchambuzi wa kushindwa na mbinu za kuboresha

#### Sasisho za Uabiri wa Mtaala (README.md)
- **Muundo wa Moduli Ulioboreshwa**: Jedwali la mtaala lililosasishwa ili kujumuisha mada mpya za juu
  - Imeongeza Uhandisi wa Muktadha (5.14) na Usafirishaji Maalum (5.15)
  - Muundo thabiti na viungo vya uabiri katika moduli zote
  - Maelezo yaliyosasishwa ili kuonyesha wigo wa maudhui ya sasa

### Maboresho ya Muundo wa Saraka
- **Ulinganifu wa Majina**: Jina la "mcp transport" limebadilishwa kuwa "mcp-transport" kwa ulinganifu na folda nyingine za mada za juu
- **Upangaji wa Maudhui**: Folda zote za 05-AdvancedTopics sasa zinafuata muundo thabiti wa majina (mcp-[mada])

### Maboresho ya Ubora wa Nyaraka
- **Ulinganifu wa Maelezo ya MCP**: Maudhui yote mapya yanarejelea Maelezo ya MCP ya sasa 2025-06-18
- **Mifano ya Lugha Nyingi**: Mifano kamili ya msimbo katika C#, TypeScript, na Python
- **Mtazamo wa Biashara**: Mifumo tayari kwa uzalishaji na ujumuishaji wa wingu la Azure
- **Nyaraka za Kielelezo**: Michoro za Mermaid kwa usanifu na ufuatiliaji wa mtiririko

## Agosti 18, 2025

### Sasisho Kamili la Nyaraka - Viwango vya MCP 2025-06-18

#### Mazoea Bora ya Usalama wa MCP (02-Security/) - Kisasa Kamili
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kuandikwa upya kabisa kulingana na Maelezo ya MCP 2025-06-18
  - **Mahitaji ya Lazima**: Kuongeza mahitaji ya wazi ya MUST/MUST NOT kutoka kwa maelezo rasmi na viashiria vya kuona
  - **Mazoea 12 ya Msingi ya Usalama**: Imeundwa upya kutoka orodha ya vipengele 15 hadi kikoa kamili cha usalama
    - Usalama wa Tokeni & Uthibitishaji na ujumuishaji wa mtoa utambulisho wa nje
    - Usimamizi wa Kikao & Usalama wa Usafirishaji na mahitaji ya kimuundo
    - Ulinzi wa Vitisho Mahususi vya AI na ujumuishaji wa Microsoft Prompt Shields
    - Udhibiti wa Ufikiaji & Ruhusa na kanuni ya ufikiaji wa kiwango cha chini
    - Usalama wa Maudhui & Ufuatiliaji na ujumuishaji wa Azure Content Safety
    - Usalama wa Mnyororo wa Ugavi na uhakiki kamili wa vipengele
    - Usalama wa OAuth & Kuzuia Shambulio la Naibu Aliyechanganyikiwa na utekelezaji wa PKCE
    - Majibu ya Matukio & Urejeshaji na uwezo wa kiotomatiki
    - Uzingatiaji & Utawala na ulinganifu wa kanuni
    - Udhibiti wa Usalama wa Juu na usanifu wa uaminifu wa sifuri
    - Ujumuishaji wa Mfumo wa Usalama wa Microsoft na suluhisho kamili
    - Mageuzi Endelevu ya Usalama na mazoea ya kubadilika
  - **Suluhisho za Usalama za Microsoft**: Mwongozo ulioboreshwa wa ujumuishaji wa Prompt Shields, Azure Content Safety, Entra ID, na GitHub Advanced Security
  - **Rasilimali za Utekelezaji**: Viungo vya rasilimali vilivyopangwa kwa nyaraka rasmi za MCP, suluhisho za usalama za Microsoft, viwango vya usalama, na miongozo ya utekelezaji

#### Udhibiti wa Usalama wa Juu (02-Security/) - Utekelezaji wa Biashara
- **MCP-SECURITY-CONTROLS-2025.md**: Kuandikwa upya kabisa na mfumo wa usalama wa daraja la biashara
  - **Vikoa 9 Kamili vya Usalama**: Imeongezwa kutoka udhibiti wa msingi hadi mfumo wa kina wa biashara
    - Uthibitishaji wa Juu & Uidhinishaji na ujumuishaji wa Microsoft Entra ID
    - Usalama wa Tokeni & Udhibiti wa Kupitisha na uthibitishaji kamili
    - Udhibiti wa Usalama wa Kikao na kuzuia utekaji nyara
    - Udhibiti wa Usalama Mahususi wa AI na kuzuia sindano ya maelezo na sumu ya zana
    - Kuzuia Shambulio la Naibu Aliyechanganyikiwa na usalama wa wakala wa OAuth
    - Usalama wa Utekelezaji wa Zana na kutenganisha na kutenga
    - Udhibiti wa Usalama wa Mnyororo wa Ugavi na uhakiki wa utegemezi
    - Udhibiti wa Ufuatiliaji & Ugunduzi na ujumuishaji wa SIEM
    - Majibu ya Matukio & Urejeshaji na uwezo wa kiotomatiki
  - **Mifano ya Utekelezaji**: Kuongeza vizuizi vya usanidi wa YAML na mifano ya msimbo
  - **Ujumuishaji wa Suluhisho za Microsoft**: Ufunikaji kamili wa huduma za usalama za Azure, GitHub Advanced Security, na usimamizi wa utambulisho wa biashara

#### Usalama wa Mada za Juu (05-AdvancedTopics/mcp-security/) - Utekelezaji Tayari kwa Uzalishaji
- **README.md**: Kuandikwa upya kabisa kwa utekelezaji wa usalama wa biashara
  - **Ulinganifu wa Maelezo ya Sasa**: Imeboreshwa kwa Maelezo ya MCP 2025-06-18 na mahitaji ya lazima ya usalama
  - **Uthibitishaji Ulioboreshwa**: Ujumuishaji wa Microsoft Entra ID na mifano kamili ya usalama wa .NET na Java Spring
  - **Ujumuishaji wa Usalama wa AI**: Utekelezaji wa Microsoft Prompt Shields na Azure Content Safety na mifano ya kina ya Python
  - **Upunguzaji wa Vitisho vya Juu**: Mifano kamili ya utekelezaji kwa
    - Kuzuia Shambulio la Naibu Aliyechanganyikiwa na PKCE na uthibitishaji wa ridhaa ya mtumiaji
    - Kuzuia Kupitisha Tokeni na uthibitishaji wa hadhira na usimamizi salama wa tokeni
    - Kuzuia Utekaji Nyara wa Kikao na kufunga kimuundo na uchambuzi wa tabia
  - **Ujumuishaji wa Usalama wa Biashara**: Ufuatiliaji wa Azure Application Insights, mifumo ya ugunduzi wa vitisho, na usalama wa mnyororo wa ugavi
  - **Orodha ya Utekelezaji**: Udhibiti wa usalama wa lazima dhidi ya unaopendekezwa na faida za mfumo wa usalama wa Microsoft

### Maboresho ya Ubora wa Nyaraka & Ulinganifu wa Viwango
- **Marejeleo ya Maelezo**: Kusasisha marejeleo yote kwa Maelezo ya MCP ya sasa 2025-06-18
- **Mfumo wa Usalama wa Microsoft**: Mwongozo ulioboreshwa wa ujumuishaji katika nyaraka zote za usalama
- **Uongozi wa Utekelezaji wa Kivitendo**: Kuongeza mifano ya msimbo ya kina katika .NET, Java, na Python na mifumo ya biashara
- **Upangaji wa Rasilimali**: Uainishaji kamili wa nyaraka rasmi, viwango vya usalama, na miongozo ya utekelezaji
- **Viashiria vya Kuona**: Alama wazi za mahitaji ya lazima dhidi ya mazoea yanayopendekezwa

## Julai 16, 2025

### Maboresho ya README na Uabiri
- Kubuni upya kabisa uabiri wa mtaala katika README.md
- Kubadilisha vitambulisho vya `<details>` na muundo wa jedwali unaopatikana zaidi
- Kuunda chaguo mbadala za mpangilio katika folda mpya ya "alternative_layouts"
- Kuongeza mifano ya uabiri wa mtindo wa kadi, tabbed, na accordion
- Kusasisha sehemu ya muundo wa hifadhi ili kujumuisha faili zote za hivi karibuni
- Kuboresha sehemu ya "Jinsi ya Kutumia Mtaala Huu" na mapendekezo wazi
- Kusasisha viungo vya maelezo ya MCP ili kuelekeza kwenye URL sahihi
- Kuongeza sehemu ya Uhandisi wa Muktadha (5.14) kwenye muundo wa mtaala

### Sasisho za Mwongozo wa Kujifunza
- Kuandika upya mwongozo wa kujifunza ili ulingane na muundo wa hifadhi ya sasa
- Kuongeza sehemu mpya za Wateja wa MCP na Zana, na Seva Maarufu za MCP
- Kusasisha Ramani ya Mtaala wa Kielelezo ili kuonyesha mada zote kwa usahihi
- Kuboresha maelezo ya Mada za Juu ili kufunika maeneo yote maalum
- Kusasisha sehemu ya Masomo ya Kesi ili kuonyesha mifano halisi
- Kuongeza changelog hii kamili

### Michango ya Jamii (06-CommunityContributions/)
- Kuongeza maelezo ya kina kuhusu seva za MCP kwa kizazi cha picha
- Kuongeza sehemu kamili ya kutumia Claude katika VSCode
- Kuongeza maagizo ya usanidi wa mteja wa terminal wa Cline na matumizi
- Kusasisha sehemu ya mteja wa MCP ili kujumuisha chaguo zote maarufu za wateja
- Kuboresha mifano ya michango na sampuli sahihi zaidi za msimbo

### Mada za Juu (05-AdvancedTopics/)
- Kuandaa folda zote za mada maalum kwa muundo thabiti
- Kuongeza vifaa vya uhandisi wa muktadha na mifano
- Kuongeza nyaraka za ujumuishaji wa wakala wa Foundry
- Kuboresha nyaraka za ujumuishaji wa usalama wa Entra ID

## Juni 11, 2025

### Uundaji wa Awali
- Kutoa toleo la kwanza la mtaala wa MCP kwa wanaoanza
- Kuunda muundo wa msingi kwa sehemu zote 10 kuu
- Kutekeleza Ramani ya Mtaala wa Kielelezo kwa uabiri
- Kuongeza miradi ya sampuli ya awali katika lugha nyingi za programu

### Kuanza (03-GettingStarted/)
- Kuunda mifano ya kwanza ya utekelezaji wa seva
- Kuongeza mwongozo wa maendeleo ya mteja
- Kujumuisha maagizo ya ujumuishaji wa mteja wa LLM
- Kuongeza nyaraka za ujumuishaji wa VS Code
- Kutekeleza mifano ya seva ya Server-Sent Events (SSE)

### Dhana za Msingi (01-CoreConcepts/)
- Kuongeza maelezo ya kina ya usanifu wa mteja-seva
- Kuunda nyaraka za vipengele muhimu vya itifaki
- Kurekodi mifumo ya ujumbe katika MCP

## Mei 23, 2025

### Muundo wa Hifadhi
- Kuanzisha hifadhi na muundo wa folda wa msingi
- Kuunda faili za README kwa kila sehemu kuu
- Kuweka miundombinu ya tafsiri
- Kuongeza mali za picha na michoro

### Nyaraka
- Kuunda README.md ya awali na muhtasari wa mtaala
- Kuongeza CODE_OF_CONDUCT.md na SECURITY.md
- Kuweka SUPPORT.md na mwongozo wa kupata msaada
- Kuunda muundo wa awali wa mwongozo wa kujifunza

## Aprili 15, 2025

### Mipango na Mfumo
- Mipango ya awali ya mtaala wa MCP kwa wanaoanza
- Kufafanua malengo ya kujifunza na hadhira lengwa
- Kuelezea muundo wa sehemu 10 wa mtaala
- Kuendeleza mfumo wa dhana kwa mifano na masomo ya kesi
- Kuunda mifano ya awali ya dhana muhimu

---

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.