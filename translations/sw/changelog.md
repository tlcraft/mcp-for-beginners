<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T21:25:34+00:00",
  "source_file": "changelog.md",
  "language_code": "sw"
}
-->
# Rekodi ya Mabadiliko: Mtaala wa MCP kwa Kompyuta

Hati hii ni rekodi ya mabadiliko muhimu yaliyofanywa kwenye mtaala wa Model Context Protocol (MCP) kwa Kompyuta. Mabadiliko yameandikwa kwa mpangilio wa kinyume cha wakati (mabadiliko mapya kwanza).

## Septemba 29, 2025

### Maabara ya Ujumuishaji wa Hifadhidata ya MCP Server - Njia ya Kujifunza kwa Vitendo

#### 11-MCPServerHandsOnLabs - Mtaala Mpya wa Ujumuishaji wa Hifadhidata
- **Njia Kamili ya Kujifunza Maabara 13**: Imeongezwa mtaala wa vitendo wa kujenga seva za MCP zinazofaa kwa uzalishaji na ujumuishaji wa hifadhidata ya PostgreSQL
  - **Utekelezaji wa Kwenye Ulimwengu Halisi**: Kesi ya matumizi ya uchanganuzi wa Zava Retail ikionyesha mifumo ya kiwango cha biashara
  - **Maendeleo ya Kujifunza kwa Mpangilio**:
    - **Maabara 00-03: Misingi** - Utangulizi, Muundo wa Msingi, Usalama & Upangaji wa Watumiaji Wengi, Usanidi wa Mazingira
    - **Maabara 04-06: Kujenga Seva ya MCP** - Muundo wa Hifadhidata & Schema, Utekelezaji wa Seva ya MCP, Maendeleo ya Zana  
    - **Maabara 07-09: Vipengele vya Juu** - Ujumuishaji wa Utafutaji wa Kisemantiki, Upimaji & Urekebishaji, Ujumuishaji wa VS Code
    - **Maabara 10-12: Uzalishaji & Mazoea Bora** - Mikakati ya Utekelezaji, Ufuatiliaji & Uangalizi, Mazoea Bora & Uboreshaji
  - **Teknolojia za Biashara**: Mfumo wa FastMCP, PostgreSQL na pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Vipengele vya Juu**: Usalama wa Kiwango cha Safu (RLS), utafutaji wa kisemantiki, ufikiaji wa data wa watumiaji wengi, embeddings za vector, ufuatiliaji wa wakati halisi

#### Uboreshaji wa Istilahi - Kubadilisha Moduli kuwa Maabara
- **Sasisho Kamili la Nyaraka**: Imesasisha kimfumo faili zote za README katika 11-MCPServerHandsOnLabs kutumia istilahi ya "Maabara" badala ya "Moduli"
  - **Vichwa vya Sehemu**: Imesasisha "Kile Moduli Hii Inashughulikia" kuwa "Kile Maabara Hii Inashughulikia" katika maabara zote 13
  - **Maelezo ya Yaliyomo**: Imesasisha "Moduli hii inatoa..." kuwa "Maabara hii inatoa..." katika nyaraka zote
  - **Malengo ya Kujifunza**: Imesasisha "Mwisho wa moduli hii..." kuwa "Mwisho wa maabara hii..."
  - **Viungo vya Uelekezaji**: Imesasisha marejeleo yote ya "Moduli XX:" kuwa "Maabara XX:" katika marejeleo ya msalaba na uelekezaji
  - **Ufuatiliaji wa Kukamilisha**: Imesasisha "Baada ya kukamilisha moduli hii..." kuwa "Baada ya kukamilisha maabara hii..."
  - **Marejeleo ya Kiufundi Yaliyohifadhiwa**: Imedumisha marejeleo ya moduli za Python katika faili za usanidi (mfano, `"module": "mcp_server.main"`)

#### Uboreshaji wa Mwongozo wa Kujifunza (study_guide.md)
- **Ramani ya Mtaala ya Kielelezo**: Imeongeza sehemu mpya ya "11. Maabara ya Ujumuishaji wa Hifadhidata" na muundo wa maabara wa kina
- **Muundo wa Hifadhi ya Hazina**: Imesasisha kutoka sehemu kumi hadi kumi na moja na maelezo ya kina ya 11-MCPServerHandsOnLabs
- **Mwongozo wa Njia ya Kujifunza**: Imesasisha maelekezo ya uelekezaji kufunika sehemu 00-11
- **Ujumuishaji wa Teknolojia**: Imeongeza maelezo ya ujumuishaji wa FastMCP, PostgreSQL, na huduma za Azure
- **Matokeo ya Kujifunza**: Imesisitiza maendeleo ya seva zinazofaa kwa uzalishaji, mifumo ya ujumuishaji wa hifadhidata, na usalama wa kiwango cha biashara

#### Uboreshaji wa Muundo wa README Kuu
- **Istilahi ya Maabara**: Imesasisha README.md kuu katika 11-MCPServerHandsOnLabs kutumia muundo wa "Maabara" kwa uthabiti
- **Muundo wa Njia ya Kujifunza**: Maendeleo wazi kutoka dhana za msingi kupitia utekelezaji wa hali ya juu hadi utekelezaji wa uzalishaji
- **Mtazamo wa Ulimwengu Halisi**: Msisitizo juu ya kujifunza kwa vitendo, mifumo ya kiwango cha biashara, na teknolojia za kisasa

### Uboreshaji wa Ubora wa Nyaraka & Uthabiti
- **Msisitizo wa Kujifunza kwa Vitendo**: Imesisitiza mbinu ya vitendo, inayotegemea maabara katika nyaraka zote
- **Mtazamo wa Mifumo ya Biashara**: Imesisitiza utekelezaji unaofaa kwa uzalishaji na masuala ya usalama wa kiwango cha biashara
- **Ujumuishaji wa Teknolojia**: Ufunikaji wa kina wa huduma za kisasa za Azure na mifumo ya ujumuishaji wa AI
- **Maendeleo ya Kujifunza**: Njia wazi, iliyopangwa kutoka dhana za msingi hadi utekelezaji wa uzalishaji

## Septemba 26, 2025

### Uboreshaji wa Kesi za Matumizi - Ujumuishaji wa Usajili wa MCP wa GitHub

#### Kesi za Matumizi (09-CaseStudy/) - Mtazamo wa Maendeleo ya Mfumo
- **README.md**: Upanuzi mkubwa na kesi ya matumizi ya Usajili wa MCP wa GitHub
  - **Kesi ya Matumizi ya Usajili wa MCP wa GitHub**: Kesi mpya ya matumizi ya kina inayochunguza uzinduzi wa Usajili wa MCP wa GitHub mnamo Septemba 2025
    - **Uchambuzi wa Tatizo**: Uchunguzi wa kina wa changamoto za ugunduzi na utekelezaji wa seva za MCP zilizogawanyika
    - **Muundo wa Suluhisho**: Mbinu ya usajili wa kati ya GitHub na usakinishaji wa moja kwa moja wa VS Code
    - **Athari za Biashara**: Uboreshaji unaoweza kupimika katika kuanza kwa watengenezaji na tija
    - **Thamani ya Kistratejia**: Mtazamo wa utekelezaji wa wakala wa moduli na uingiliano wa zana mbalimbali
    - **Maendeleo ya Mfumo**: Kuweka msingi kama jukwaa la ujumuishaji wa wakala
  - **Muundo wa Kesi za Matumizi Ulioboreshwa**: Imesasisha kesi zote saba za matumizi na muundo thabiti na maelezo ya kina
    - Mawakala wa AI wa Safari za Azure: Msisitizo wa uratibu wa wakala wengi
    - Ujumuishaji wa Azure DevOps: Mtazamo wa kiotomatiki wa mtiririko wa kazi
    - Urejeshaji wa Nyaraka wa Wakati Halisi: Utekelezaji wa mteja wa console ya Python
    - Jenereta ya Mpango wa Kujifunza wa Maingiliano: Programu ya wavuti ya mazungumzo ya Chainlit
    - Nyaraka Ndani ya Hariri: Ujumuishaji wa VS Code na GitHub Copilot
    - Usimamizi wa API ya Azure: Mifumo ya ujumuishaji wa API ya biashara
    - Usajili wa MCP wa GitHub: Maendeleo ya mfumo na jukwaa la jamii
  - **Hitimisho Kamili**: Sehemu ya hitimisho iliyorekebishwa ikionyesha kesi saba za matumizi zinazojumuisha vipengele mbalimbali vya utekelezaji wa MCP
    - Ujumuishaji wa Biashara, Uratibu wa Wakala Wengi, Tija ya Watengenezaji
    - Maendeleo ya Mfumo, Matumizi ya Kielimu
    - Uboreshaji wa maarifa kuhusu mifumo ya usanifu, mikakati ya utekelezaji, na mazoea bora
    - Msisitizo wa MCP kama itifaki iliyokomaa, inayofaa kwa uzalishaji

#### Sasisho za Mwongozo wa Kujifunza (study_guide.md)
- **Ramani ya Mtaala ya Kielelezo**: Imesasisha mindmap kujumuisha Usajili wa MCP wa GitHub katika sehemu ya Kesi za Matumizi
- **Maelezo ya Kesi za Matumizi**: Imesasisha kutoka maelezo ya jumla hadi muhtasari wa kina wa kesi saba za matumizi
- **Muundo wa Hifadhi ya Hazina**: Imesasisha sehemu ya 10 kuonyesha ufunikaji wa kina wa kesi za matumizi na maelezo maalum ya utekelezaji
- **Ujumuishaji wa Rekodi ya Mabadiliko**: Imeongeza kiingilio cha Septemba 26, 2025 kinachoandika nyongeza ya Usajili wa MCP wa GitHub na uboreshaji wa kesi za matumizi
- **Sasisho za Tarehe**: Imesasisha timestamp ya footer kuonyesha marekebisho ya hivi karibuni (Septemba 26, 2025)

### Uboreshaji wa Ubora wa Nyaraka
- **Uboreshaji wa Uthabiti**: Imesawazisha muundo wa kesi za matumizi na muundo katika mifano yote saba
- **Ufunikaji wa Kina**: Kesi za matumizi sasa zinajumuisha hali za biashara, tija ya watengenezaji, na maendeleo ya mfumo
- **Uwekaji wa Kistratejia**: Msisitizo ulioboreshwa wa MCP kama jukwaa la msingi kwa utekelezaji wa mifumo ya wakala
- **Ujumuishaji wa Rasilimali**: Imesasisha rasilimali za ziada kujumuisha kiungo cha Usajili wa MCP wa GitHub

## Septemba 15, 2025

### Upanuzi wa Mada za Juu - Usafirishaji Maalum & Uhandisi wa Muktadha

#### Usafirishaji Maalum wa MCP (05-AdvancedTopics/mcp-transport/) - Mwongozo Mpya wa Utekelezaji wa Juu
- **README.md**: Mwongozo kamili wa utekelezaji wa mifumo maalum ya usafirishaji wa MCP
  - **Usafirishaji wa Azure Event Grid**: Utekelezaji wa usafirishaji wa matukio bila seva
    - Mifano ya C#, TypeScript, na Python na ujumuishaji wa Azure Functions
    - Mifumo ya usanifu wa matukio kwa suluhisho za MCP zinazoweza kupanuka
    - Wapokeaji wa webhook na usimamizi wa ujumbe wa kushinikiza
  - **Usafirishaji wa Azure Event Hubs**: Utekelezaji wa usafirishaji wa mtiririko wa kiwango cha juu
    - Uwezo wa mtiririko wa wakati halisi kwa hali za ucheleweshaji wa chini
    - Mikakati ya kugawanya na usimamizi wa alama za ukaguzi
    - Upangaji wa ujumbe na uboreshaji wa utendaji
  - **Mifumo ya Ujumuishaji wa Biashara**: Mifano ya usanifu inayofaa kwa uzalishaji
    - Usindikaji wa MCP uliosambazwa katika Azure Functions nyingi
    - Miundombinu ya usafirishaji mseto inayojumuisha aina nyingi za usafirishaji
    - Uimara wa ujumbe, uaminifu, na mikakati ya kushughulikia makosa
  - **Usalama & Ufuatiliaji**: Ujumuishaji wa Azure Key Vault na mifumo ya uangalizi
    - Uthibitishaji wa utambulisho uliosimamiwa na ufikiaji wa upendeleo mdogo
    - Telemetry ya Application Insights na ufuatiliaji wa utendaji
    - Vizuizi vya mzunguko na mifumo ya uvumilivu wa makosa
  - **Mifumo ya Upimaji**: Mikakati kamili ya upimaji wa usafirishaji maalum
    - Upimaji wa vitengo na mifumo ya kuiga
    - Upimaji wa ujumuishaji na Azure Test Containers
    - Mazingatio ya upimaji wa utendaji na mzigo

#### Uhandisi wa Muktadha (05-AdvancedTopics/mcp-contextengineering/) - Taaluma Inayochipuka ya AI
- **README.md**: Uchunguzi wa kina wa uhandisi wa muktadha kama taaluma inayochipuka
  - **Kanuni za Msingi**: Kushiriki muktadha kikamilifu, ufahamu wa maamuzi ya hatua, na usimamizi wa dirisha la muktadha
  - **Ulinganifu wa Itifaki ya MCP**: Jinsi muundo wa MCP unavyoshughulikia changamoto za uhandisi wa muktadha
    - Vikwazo vya dirisha la muktadha na mikakati ya upakiaji wa hatua kwa hatua
    - Uamuzi wa umuhimu na urejeshaji wa muktadha wa nguvu
    - Ushughulikiaji wa muktadha wa njia nyingi na masuala ya usalama
  - **Mbinu za Utekelezaji**: Miundombinu ya wakala mmoja dhidi ya wakala wengi
    - Mbinu za kugawanya muktadha na kipaumbele
    - Upakiaji wa hatua kwa hatua wa muktadha na mikakati ya ukandamizaji
    - Mbinu za muktadha wa tabaka na uboreshaji wa urejeshaji
  - **Mfumo wa Upimaji**: Vipimo vinavyochipuka vya tathmini ya ufanisi wa muktadha
    - Ufanisi wa pembejeo, utendaji, ubora, na mazingatio ya uzoefu wa mtumiaji
    - Mbinu za majaribio za uboreshaji wa muktadha
    - Uchambuzi wa kushindwa na mbinu za kuboresha

#### Sasisho za Uelekezaji wa Mtaala (README.md)
- **Muundo wa Moduli Ulioboreshwa**: Imesasisha jedwali la mtaala kujumuisha mada mpya za juu
  - Imeongeza Uhandisi wa Muktadha (5.14) na Usafirishaji Maalum (5.15)
  - Muundo thabiti na viungo vya uelekezaji katika moduli zote
  - Maelezo yaliyosasishwa kuonyesha wigo wa yaliyomo ya sasa

### Uboreshaji wa Muundo wa Hifadhi ya Hazina
- **Uthabiti wa Majina**: Imesasisha "mcp transport" kuwa "mcp-transport" kwa uthabiti na folda nyingine za mada za juu
- **Muundo wa Yaliyomo**: Folda zote za 05-AdvancedTopics sasa zinafuata muundo wa majina thabiti (mcp-[mada])

### Uboreshaji wa Ubora wa Nyaraka
- **Ulinganifu wa Maelezo ya MCP**: Yaliyomo yote mapya yanarejelea Maelezo ya MCP ya sasa 2025-06-18
- **Mifano ya Lugha Nyingi**: Mifano kamili ya msimbo katika C#, TypeScript, na Python
- **Mtazamo wa Biashara**: Mifumo inayofaa kwa uzalishaji na ujumuishaji wa wingu la Azure katika nyaraka zote
- **Nyaraka za Kielelezo**: Michoro ya Mermaid kwa usanifu na uelekezaji wa mtiririko

## Agosti 18, 2025

### Sasisho Kamili la Nyaraka - Viwango vya MCP 2025-06-18

#### Mazoea Bora ya Usalama wa MCP (02-Security/) - Kisasa Kamili
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Uandishi upya kamili unaolingana na Maelezo ya MCP 2025-06-18
  - **Mahitaji ya Lazima**: Imeongeza mahitaji ya wazi ya MUST/MUST NOT kutoka kwa maelezo rasmi na viashiria vya kuona vya wazi
  - **Mazoea 12 ya Msingi ya Usalama**: Imepangwa upya kutoka orodha ya vipengele 15 hadi vikoa vya usalama vya kina
    - Usalama wa Tokeni & Uthibitishaji na ujumuishaji wa mtoa utambulisho wa nje
    - Usimamizi wa Kikao & Usalama wa Usafirishaji na mahitaji ya kimuundo
    - Ulinzi wa Vitisho Maalum vya AI na ujumuishaji wa Microsoft Prompt Shields
    - Udhibiti wa Ufikiaji & Ruhusa na kanuni ya upendeleo mdogo
    - Usalama wa Yaliyomo & Ufuatiliaji na ujumuishaji wa Azure Content Safety
    - Usalama wa Mnyororo wa Ugavi na uthibitishaji wa vipengele vya kina
    - Usalama wa OAuth & Kuzuia Shambulio la Confused Deputy na utekelezaji wa PKCE
    - Majibu ya Matukio & Urejeshaji na uwezo wa kiotomatiki
    - Uzingatiaji & Utawala na ulinganifu wa kanuni
    - Udhibiti wa Usalama wa Juu na usanifu wa zero trust
    - Ujumuishaji wa Mfumo wa Usalama wa Microsoft na suluhisho za kina
    - Mageuzi Endelevu ya Usalama na mazoea ya kubadil
- **Viashiria vya Kielelezo**: Alama wazi za mahitaji ya lazima dhidi ya mazoea yanayopendekezwa

#### Dhana za Msingi (01-CoreConcepts/) - Uboreshaji wa Kisasa Kamili
- **Sasisho la Toleo la Itifaki**: Imeboreshwa kurejelea Maelezo ya MCP ya sasa ya 2025-06-18 kwa kutumia mfumo wa toleo la tarehe (muundo wa YYYY-MM-DD)
- **Uboreshaji wa Usanifu**: Maelezo yaliyoboreshwa ya Wenyeji, Wateja, na Seva ili kuonyesha mifumo ya usanifu wa MCP ya sasa
  - Wenyeji sasa wamefafanuliwa wazi kama programu za AI zinazoratibu miunganisho mingi ya wateja wa MCP
  - Wateja wameelezwa kama viunganishi vya itifaki vinavyodumisha uhusiano wa moja kwa moja na seva
  - Seva zimeboreshwa na hali za utekelezaji wa ndani dhidi ya wa mbali
- **Marekebisho ya Primitives**: Mabadiliko kamili ya primitives za seva na wateja
  - Primitives za Seva: Rasilimali (vyanzo vya data), Maelezo (vigezo), Zana (kazi zinazoweza kutekelezwa) na maelezo ya kina na mifano
  - Primitives za Wateja: Sampuli (ukamilishaji wa LLM), Uchochezi (maingizo ya mtumiaji), Kumbukumbu (uangalizi/ufuatiliaji)
  - Imeboreshwa na mifumo ya sasa ya ugunduzi (`*/list`), upatikanaji (`*/get`), na utekelezaji (`*/call`)
- **Usanifu wa Itifaki**: Mfano wa usanifu wa tabaka mbili umeanzishwa
  - Tabaka la Data: Msingi wa JSON-RPC 2.0 na usimamizi wa mzunguko wa maisha na primitives
  - Tabaka la Usafirishaji: STDIO (ndani) na HTTP inayoweza kutiririka na SSE (mbali) kama mifumo ya usafirishaji
- **Mfumo wa Usalama**: Kanuni za usalama za kina ikiwa ni pamoja na idhini ya wazi ya mtumiaji, ulinzi wa faragha ya data, usalama wa utekelezaji wa zana, na usalama wa tabaka la usafirishaji
- **Mifumo ya Mawasiliano**: Ujumbe wa itifaki ulioboreshwa kuonyesha mchakato wa kuanzisha, kugundua, kutekeleza, na kutoa taarifa
- **Mifano ya Nambari**: Mifano ya lugha nyingi iliyosasishwa (.NET, Java, Python, JavaScript) ili kuonyesha mifumo ya sasa ya MCP SDK

#### Usalama (02-Security/) - Uboreshaji wa Usalama wa Kina  
- **Ulinganifu wa Viwango**: Ulinganifu kamili na mahitaji ya usalama ya Maelezo ya MCP ya 2025-06-18
- **Mageuzi ya Uthibitishaji**: Mageuzi yaliyoandikwa kutoka seva za OAuth maalum hadi udelegation wa mtoa utambulisho wa nje (Microsoft Entra ID)
- **Uchambuzi wa Vitisho vya AI**: Uboreshaji wa chanjo ya vectors za mashambulizi ya AI ya kisasa
  - Mifano ya hali halisi ya mashambulizi ya sindano ya maelezo
  - Mbinu za sumu za zana na mifumo ya mashambulizi ya "rug pull"
  - Uchafuzi wa dirisha la muktadha na mashambulizi ya mkanganyiko wa modeli
- **Suluhisho za Usalama za Microsoft AI**: Chanjo ya kina ya mfumo wa usalama wa Microsoft
  - Kinga za Maelezo ya AI na mbinu za kugundua, kuonyesha, na kutenganisha
  - Mifumo ya ushirikiano wa Usalama wa Maudhui ya Azure
  - Usalama wa Juu wa GitHub kwa ulinzi wa mnyororo wa usambazaji
- **Kupunguza Vitisho vya Juu**: Udhibiti wa usalama wa kina kwa
  - Utekaji wa vikao na hali maalum za mashambulizi ya MCP na mahitaji ya kitambulisho cha kikao cha cryptographic
  - Matatizo ya naibu aliyekanganyikiwa katika hali za wakala wa MCP na mahitaji ya idhini ya wazi
  - Udhaifu wa upitishaji wa tokeni na udhibiti wa uthibitishaji wa lazima
- **Usalama wa Mnyororo wa Ugavi**: Chanjo ya mnyororo wa ugavi wa AI iliyopanuliwa ikiwa ni pamoja na modeli za msingi, huduma za embeddings, watoa muktadha, na API za wahusika wa tatu
- **Usalama wa Msingi**: Ushirikiano ulioboreshwa na mifumo ya usalama ya biashara ikiwa ni pamoja na usanifu wa uaminifu sifuri na mfumo wa usalama wa Microsoft
- **Mpangilio wa Rasilimali**: Viungo vya rasilimali vilivyopangwa kwa aina (Nyaraka Rasmi, Viwango, Utafiti, Suluhisho za Microsoft, Miongozo ya Utekelezaji)

### Uboreshaji wa Ubora wa Nyaraka
- **Malengo ya Kujifunza Yaliyopangiliwa**: Malengo ya kujifunza yaliyoboreshwa na matokeo maalum, yanayoweza kutekelezwa
- **Marejeleo ya Msalaba**: Viungo vilivyoongezwa kati ya mada zinazohusiana za usalama na dhana za msingi
- **Taarifa za Sasa**: Marejeleo yote ya tarehe na viungo vya maelezo vimesasishwa kwa viwango vya sasa
- **Mwongozo wa Utekelezaji**: Miongozo maalum, inayoweza kutekelezwa ya utekelezaji imeongezwa katika sehemu zote mbili

## Julai 16, 2025

### README na Uboreshaji wa Uabiri
- Uabiri wa mtaala katika README.md umerekebishwa kabisa
- Lebo za `<details>` zimebadilishwa na muundo wa meza unaoweza kufikiwa zaidi
- Chaguo mbadala za mpangilio zimeundwa katika folda mpya ya "alternative_layouts"
- Mifano ya uabiri wa mtindo wa kadi, tabbed, na accordion imeongezwa
- Sehemu ya muundo wa hifadhi ya jalada imeboreshwa ili kujumuisha faili zote za hivi karibuni
- Sehemu ya "Jinsi ya Kutumia Mtaala Huu" imeboreshwa na mapendekezo wazi
- Viungo vya maelezo ya MCP vimesasishwa ili kuelekeza kwenye URL sahihi
- Sehemu ya Uhandisi wa Muktadha (5.14) imeongezwa kwenye muundo wa mtaala

### Sasisho za Mwongozo wa Kujifunza
- Mwongozo wa kujifunza umerekebishwa kabisa ili kuendana na muundo wa hifadhi ya jalada ya sasa
- Sehemu mpya zimeongezwa kwa Wateja wa MCP na Zana, na Seva Maarufu za MCP
- Ramani ya Mtaala wa Kielelezo imeboreshwa ili kuonyesha mada zote kwa usahihi
- Maelezo ya Mada za Juu yameboreshwa ili kufunika maeneo yote maalum
- Sehemu ya Masomo ya Kesi imeboreshwa ili kuonyesha mifano halisi
- Changelog hii ya kina imeongezwa

### Michango ya Jamii (06-CommunityContributions/)
- Taarifa za kina kuhusu seva za MCP kwa kizazi cha picha zimeongezwa
- Sehemu ya kina kuhusu kutumia Claude katika VSCode imeongezwa
- Maelekezo ya usanidi wa mteja wa terminal wa Cline na matumizi yameongezwa
- Sehemu ya mteja wa MCP imeboreshwa ili kujumuisha chaguo zote maarufu za wateja
- Mifano ya michango imeboreshwa na sampuli sahihi zaidi za nambari

### Mada za Juu (05-AdvancedTopics/)
- Folda zote za mada maalum zimepangwa kwa majina thabiti
- Vifaa na mifano ya uhandisi wa muktadha imeongezwa
- Nyaraka za ushirikiano wa wakala wa Foundry zimeongezwa
- Nyaraka za ushirikiano wa usalama wa Entra ID zimeboreshwa

## Juni 11, 2025

### Uundaji wa Awali
- Toleo la kwanza la mtaala wa MCP kwa Kompyuta limetolewa
- Muundo wa msingi wa sehemu zote 10 umeundwa
- Ramani ya Mtaala wa Kielelezo imeanzishwa kwa uabiri
- Miradi ya sampuli ya awali katika lugha nyingi za programu imeongezwa

### Kuanza (03-GettingStarted/)
- Mifano ya utekelezaji wa seva ya kwanza imeundwa
- Mwongozo wa maendeleo ya mteja umeongezwa
- Maelekezo ya ushirikiano wa mteja wa LLM yamejumuishwa
- Nyaraka za ushirikiano wa VS Code zimeongezwa
- Mifano ya seva ya Server-Sent Events (SSE) imeanzishwa

### Dhana za Msingi (01-CoreConcepts/)
- Maelezo ya kina ya usanifu wa mteja-seva yameongezwa
- Nyaraka za vipengele muhimu vya itifaki zimeundwa
- Mifumo ya ujumbe katika MCP imeandikwa

## Mei 23, 2025

### Muundo wa Hifadhi ya Jalada
- Hifadhi ya jalada imeanzishwa na muundo wa folda wa msingi
- Faili za README kwa kila sehemu kuu zimeundwa
- Miundombinu ya tafsiri imewekwa
- Vifaa vya picha na michoro vimeongezwa

### Nyaraka
- README.md ya awali yenye muhtasari wa mtaala imeundwa
- CODE_OF_CONDUCT.md na SECURITY.md zimeongezwa
- SUPPORT.md yenye mwongozo wa kupata msaada imeundwa
- Muundo wa awali wa mwongozo wa kujifunza umeundwa

## Aprili 15, 2025

### Mipango na Mfumo
- Mipango ya awali ya mtaala wa MCP kwa Kompyuta imeanzishwa
- Malengo ya kujifunza na hadhira lengwa yamefafanuliwa
- Muundo wa sehemu 10 za mtaala umeainishwa
- Mfumo wa dhana kwa mifano na masomo ya kesi umeundwa
- Mifano ya awali ya prototype kwa dhana muhimu imeundwa

---

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.