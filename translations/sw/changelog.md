<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-19T14:22:46+00:00",
  "source_file": "changelog.md",
  "language_code": "sw"
}
-->
# Changelog: MCP kwa Mtaala wa Wanaoanza

Hati hii ni rekodi ya mabadiliko yote muhimu yaliyofanywa kwenye mtaala wa Model Context Protocol (MCP) kwa Wanaoanza. Mabadiliko yameandikwa kwa mpangilio wa kinyume wa wakati (mabadiliko mapya kwanza).

## Agosti 18, 2025

### Sasisho Kamili la Nyaraka - Viwango vya MCP 2025-06-18

#### Mazoea Bora ya Usalama wa MCP (02-Security/) - Uboreshaji Kamili
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kuandikwa upya kikamilifu kulingana na Maelezo ya MCP 2025-06-18
  - **Mahitaji ya Lazima**: Yameongezwa mahitaji ya wazi ya MUST/MUST NOT kutoka kwenye maelezo rasmi na viashiria vya kuona vilivyo wazi
  - **Mazoea 12 ya Msingi ya Usalama**: Yamepangwa upya kutoka orodha ya vitu 15 hadi maeneo ya kina ya usalama
    - Usalama wa Tokeni & Uthibitishaji kwa ushirikiano na mtoa huduma wa kitambulisho wa nje
    - Usimamizi wa Vikao & Usalama wa Usafirishaji na mahitaji ya kriptografia
    - Ulinzi wa Vitisho Maalum vya AI kwa ushirikiano wa Microsoft Prompt Shields
    - Udhibiti wa Ufikiaji & Ruhusa kwa kanuni ya upendeleo wa chini kabisa
    - Usalama wa Maudhui & Ufuatiliaji kwa ushirikiano wa Azure Content Safety
    - Usalama wa Mnyororo wa Ugavi kwa uhakiki wa vipengele vya kina
    - Usalama wa OAuth & Kuzuia Shambulio la Confused Deputy kwa utekelezaji wa PKCE
    - Mwitikio wa Matukio & Urejeshaji kwa uwezo wa kiotomatiki
    - Uzingatiaji & Utawala kwa ulinganifu wa kisheria
    - Udhibiti wa Usalama wa Juu kwa usanifu wa zero trust
    - Ushirikiano wa Mfumo wa Usalama wa Microsoft kwa suluhisho za kina
    - Mageuzi Endelevu ya Usalama kwa mazoea yanayobadilika
  - **Suluhisho za Usalama za Microsoft**: Mwongozo ulioboreshwa wa ushirikiano kwa Prompt Shields, Azure Content Safety, Entra ID, na GitHub Advanced Security
  - **Rasilimali za Utekelezaji**: Viungo vya rasilimali vilivyopangwa kwa nyaraka rasmi za MCP, suluhisho za usalama za Microsoft, viwango vya usalama, na miongozo ya utekelezaji

#### Udhibiti wa Usalama wa Juu (02-Security/) - Utekelezaji wa Kiwango cha Biashara
- **MCP-SECURITY-CONTROLS-2025.md**: Mabadiliko kamili na mfumo wa usalama wa kiwango cha biashara
  - **Maeneo 9 ya Kina ya Usalama**: Yamepanuliwa kutoka kwa udhibiti wa msingi hadi mfumo wa kina wa biashara
    - Uthibitishaji & Uidhinishaji wa Juu kwa ushirikiano wa Microsoft Entra ID
    - Usalama wa Tokeni & Udhibiti wa Kuzuia Passthrough kwa uhakiki wa kina
    - Udhibiti wa Usalama wa Vikao kwa kuzuia utekaji
    - Udhibiti Maalum wa Usalama wa AI kwa kuzuia sindano ya prompt na sumu ya zana
    - Kuzuia Shambulio la Confused Deputy kwa usalama wa wakala wa OAuth
    - Usalama wa Utekelezaji wa Zana kwa kuweka kwenye sandbox na kutenganisha
    - Udhibiti wa Usalama wa Mnyororo wa Ugavi kwa uhakiki wa utegemezi
    - Udhibiti wa Ufuatiliaji & Ugunduzi kwa ushirikiano wa SIEM
    - Mwitikio wa Matukio & Urejeshaji kwa uwezo wa kiotomatiki
  - **Mifano ya Utekelezaji**: Imeongezwa vizuizi vya usanidi wa YAML na mifano ya msimbo
  - **Ushirikiano wa Suluhisho za Microsoft**: Ufunikaji wa kina wa huduma za usalama za Azure, GitHub Advanced Security, na usimamizi wa kitambulisho cha biashara

#### Mada za Juu za Usalama (05-AdvancedTopics/mcp-security/) - Utekelezaji Tayari kwa Uzalishaji
- **README.md**: Kuandikwa upya kikamilifu kwa utekelezaji wa usalama wa biashara
  - **Ulinganifu wa Maelezo ya Sasa**: Imeboreshwa kwa Maelezo ya MCP 2025-06-18 na mahitaji ya lazima ya usalama
  - **Uthibitishaji Ulioboreshwa**: Ushirikiano wa Microsoft Entra ID na mifano ya kina ya .NET na Java Spring Security
  - **Ushirikiano wa Usalama wa AI**: Utekelezaji wa Microsoft Prompt Shields na Azure Content Safety na mifano ya kina ya Python
  - **Kupunguza Vitisho vya Juu**: Mifano ya utekelezaji wa kina kwa
    - Kuzuia Shambulio la Confused Deputy kwa PKCE na uthibitishaji wa ridhaa ya mtumiaji
    - Kuzuia Passthrough ya Tokeni kwa uthibitishaji wa hadhira na usimamizi salama wa tokeni
    - Kuzuia Utekaji wa Vikao kwa kufunga kriptografia na uchambuzi wa tabia
  - **Ushirikiano wa Usalama wa Biashara**: Ufuatiliaji wa Azure Application Insights, mifumo ya ugunduzi wa vitisho, na usalama wa mnyororo wa ugavi
  - **Orodha ya Utekelezaji**: Udhibiti wa usalama wa lazima dhidi ya unaopendekezwa na faida za mfumo wa usalama wa Microsoft

### Ubora wa Nyaraka & Ulinganifu wa Viwango
- **Marejeleo ya Maelezo**: Yamesasishwa marejeleo yote kwa Maelezo ya MCP 2025-06-18
- **Mfumo wa Usalama wa Microsoft**: Mwongozo ulioboreshwa wa ushirikiano katika nyaraka zote za usalama
- **Utekelezaji wa Kivitendo**: Imeongezwa mifano ya kina ya msimbo katika .NET, Java, na Python kwa mifumo ya biashara
- **Mpangilio wa Rasilimali**: Uainishaji wa kina wa nyaraka rasmi, viwango vya usalama, na miongozo ya utekelezaji
- **Viashiria vya Kuona**: Alama wazi za mahitaji ya lazima dhidi ya mazoea yanayopendekezwa

#### Dhana za Msingi (01-CoreConcepts/) - Uboreshaji Kamili
- **Sasisho la Toleo la Itifaki**: Imeboreshwa kurejelea Maelezo ya MCP 2025-06-18 na upangaji wa toleo kwa tarehe (muundo wa YYYY-MM-DD)
- **Uboreshaji wa Usanifu**: Maelezo yaliyoboreshwa ya Wenyeji, Wateja, na Seva ili kuonyesha mifumo ya sasa ya usanifu wa MCP
  - Wenyeji sasa wamefafanuliwa wazi kama programu za AI zinazoratibu miunganisho mingi ya mteja wa MCP
  - Wateja wameelezewa kama viunganishi vya itifaki vinavyodumisha uhusiano wa moja kwa moja na seva
  - Seva zimeboreshwa na hali za usanidi wa ndani dhidi ya wa mbali
- **Urekebishaji wa Primitives**: Mabadiliko kamili ya primitives za seva na mteja
  - Primitives za Seva: Rasilimali (vyanzo vya data), Prompti (vigezo), Zana (kazi zinazoweza kutekelezwa) na maelezo ya kina na mifano
  - Primitives za Mteja: Sampuli (ukamilishaji wa LLM), Uchochezi (maingizo ya mtumiaji), Kumbukumbu (uondoaji hitilafu/ufuatiliaji)
  - Imeboreshwa na mifumo ya sasa ya ugunduzi (`*/list`), upatikanaji (`*/get`), na utekelezaji (`*/call`)
- **Usanifu wa Itifaki**: Imeanzishwa mfano wa usanifu wa tabaka mbili
  - Tabaka la Data: Msingi wa JSON-RPC 2.0 na usimamizi wa mzunguko wa maisha na primitives
  - Tabaka la Usafirishaji: STDIO (ndani) na HTTP inayoweza kutiririka na SSE (mbali) kama mifumo ya usafirishaji
- **Mfumo wa Usalama**: Kanuni za kina za usalama zikiwemo ridhaa ya wazi ya mtumiaji, ulinzi wa faragha ya data, usalama wa utekelezaji wa zana, na usalama wa tabaka la usafirishaji
- **Mifumo ya Mawasiliano**: Imeboreshwa ujumbe wa itifaki kuonyesha mchakato wa kuanzisha, kugundua, kutekeleza, na kutoa taarifa
- **Mifano ya Msimbo**: Imeboreshwa mifano ya lugha nyingi (.NET, Java, Python, JavaScript) ili kuonyesha mifumo ya sasa ya MCP SDK

#### Usalama (02-Security/) - Uboreshaji Kamili wa Usalama  
- **Ulinganifu wa Viwango**: Ulinganifu kamili na mahitaji ya usalama ya Maelezo ya MCP 2025-06-18
- **Mageuzi ya Uthibitishaji**: Imeandikwa mageuzi kutoka seva za OAuth za kawaida hadi ugawaji wa mtoa huduma wa kitambulisho wa nje (Microsoft Entra ID)
- **Uchambuzi wa Vitisho Maalum vya AI**: Ufunikaji ulioboreshwa wa vishawishi vya kisasa vya mashambulio ya AI
  - Mifano ya kina ya mashambulio ya sindano ya prompt na mifano halisi
  - Mifumo ya sumu ya zana na mifano ya mashambulio ya "rug pull"
  - Mashambulio ya sumu ya dirisha la muktadha na kuchanganyikiwa kwa modeli
- **Suluhisho za Usalama wa AI za Microsoft**: Ufunikaji wa kina wa mfumo wa usalama wa Microsoft
  - AI Prompt Shields na ugunduzi wa hali ya juu, kuangazia, na mbinu za delimiter
  - Mifumo ya ushirikiano wa Azure Content Safety
  - GitHub Advanced Security kwa ulinzi wa mnyororo wa ugavi
- **Kupunguza Vitisho vya Juu**: Udhibiti wa kina wa usalama kwa
  - Utekaji wa vikao na mifano maalum ya mashambulio ya MCP na mahitaji ya kitambulisho cha kikao cha kriptografia
  - Matatizo ya Confused Deputy katika hali za wakala wa MCP na mahitaji ya ridhaa ya wazi
  - Udhaifu wa kupitisha tokeni na udhibiti wa uthibitishaji wa lazima
- **Usalama wa Mnyororo wa Ugavi**: Ufunikaji wa kina wa mnyororo wa ugavi wa AI ukiwemo mifano ya msingi, huduma za embeddings, watoa huduma wa muktadha, na API za wahusika wa tatu
- **Usalama wa Msingi**: Ushirikiano ulioboreshwa na mifumo ya usalama wa biashara ukiwemo usanifu wa zero trust na mfumo wa usalama wa Microsoft
- **Mpangilio wa Rasilimali**: Uainishaji wa kina wa viungo vya rasilimali kwa aina (Nyaraka Rasmi, Viwango, Utafiti, Suluhisho za Microsoft, Miongozo ya Utekelezaji)

### Maboresho ya Ubora wa Nyaraka
- **Malengo ya Kujifunza Yaliyopangiliwa**: Malengo ya kujifunza yaliyoboreshwa na matokeo mahususi, yanayoweza kutekelezeka
- **Marejeleo ya Msalaba**: Viungo vimeongezwa kati ya mada zinazohusiana za usalama na dhana za msingi
- **Taarifa za Sasa**: Marejeleo yote ya tarehe na viungo vya maelezo yamesasishwa kwa viwango vya sasa
- **Mwongozo wa Utekelezaji**: Mwongozo mahususi, unaoweza kutekelezeka umeongezwa katika sehemu zote mbili

## Julai 16, 2025

### Maboresho ya README na Urambazaji
- Imeundwa upya kabisa urambazaji wa mtaala katika README.md
- Imebadilisha vitambulisho vya `<details>` na muundo wa jedwali unaopatikana zaidi
- Imeunda chaguo mbadala za mpangilio katika folda mpya ya "alternative_layouts"
- Imeongeza mifano ya urambazaji wa kadi, tabbed-style, na accordion-style
- Imeboresha sehemu ya muundo wa hifadhi ili kujumuisha faili zote za hivi karibuni
- Imeimarisha sehemu ya "Jinsi ya Kutumia Mtaala Huu" kwa mapendekezo wazi
- Viungo vya maelezo ya MCP vimesasishwa kuelekeza kwenye URL sahihi
- Imeongeza sehemu ya Uhandisi wa Muktadha (5.14) kwenye muundo wa mtaala

### Sasisho za Mwongozo wa Kujifunza
- Mwongozo wa kujifunza umefanyiwa marekebisho kikamilifu ili kuendana na muundo wa sasa wa hifadhi
- Sehemu mpya zimeongezwa kwa Wateja wa MCP na Zana, na Seva Maarufu za MCP
- Ramani ya Mtaala wa Kiona imeboreshwa ili kuonyesha mada zote kwa usahihi
- Maelezo ya Mada za Juu yameimarishwa ili kufunika maeneo yote maalum
- Sehemu ya Masomo ya Kesi imesasishwa ili kuonyesha mifano halisi
- Changelog hii ya kina imeongezwa

### Michango ya Jamii (06-CommunityContributions/)
- Maelezo ya kina yameongezwa kuhusu seva za MCP kwa ajili ya kizazi cha picha
- Sehemu ya kina imeongezwa kuhusu kutumia Claude katika VSCode
- Maelekezo ya usanidi na matumizi ya mteja wa terminal wa Cline yameongezwa
- Sehemu ya wateja wa MCP imesasishwa kujumuisha chaguo zote maarufu za wateja
- Mifano ya michango imeimarishwa kwa sampuli za msimbo sahihi zaidi

### Mada za Juu (05-AdvancedTopics/)
- Folda zote za mada maalum zimepangwa kwa majina thabiti
- Vifaa na mifano ya uhandisi wa muktadha imeongezwa
- Nyaraka za ushirikiano wa wakala wa Foundry zimeongezwa
- Nyaraka za ushirikiano wa usalama wa Entra ID zimeimarishwa

## Juni 11, 2025

### Uundaji wa Awali
- Toleo la kwanza la mtaala wa MCP kwa Wanaoanza limetolewa
- Muundo wa msingi wa sehemu zote 10 kuu umeundwa
- Ramani ya Mtaala wa Kiona imeundwa kwa urambazaji
- Miradi ya sampuli ya awali imeongezwa katika lugha mbalimbali za programu

### Kuanza (03-GettingStarted/)
- Mifano ya kwanza ya utekelezaji wa seva imeundwa
- Mwongozo wa maendeleo ya mteja umeongezwa
- Maelekezo ya ushirikiano wa mteja wa LLM yamejumuishwa
- Nyaraka za ushirikiano wa VS Code zimeongezwa
- Mifano ya seva ya Server-Sent Events (SSE) imetekelezwa

### Dhana za Msingi (01-CoreConcepts/)
- Maelezo ya kina ya usanifu wa mteja-seva yameongezwa
- Nyaraka za vipengele muhimu vya itifaki zimeundwa
- Mifumo ya ujumbe katika MCP imeandikwa

## Mei 23, 2025

### Muundo wa Hifadhi
- Hifadhi imeanzishwa na muundo wa msingi wa folda
- Faili za README zimeundwa kwa kila sehemu kuu
- Miundombinu ya tafsiri imewekwa
- Picha na michoro zimeongezwa

### Nyaraka
- README.md ya awali yenye muhtasari wa mtaala imeundwa
- CODE_OF_CONDUCT.md na SECURITY.md zimeongezwa
- SUPPORT.md imewekwa na mwongozo wa kupata msaada
- Muundo wa awali wa mwongozo wa kujifunza umeundwa

## Aprili 15, 2025

### Mipango na Mfumo
- Mipango ya awali ya mtaala wa MCP kwa Wanaoanza imeanzishwa
- Malengo ya kujifunza na hadhira lengwa yamefafanuliwa
- Muundo wa sehemu 10 za mtaala umeainishwa
- Mfumo wa dhana kwa mifano na masomo ya kesi umeundwa
- Mifano ya awali ya dhana muhimu imeundwa

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kutumia huduma ya tafsiri ya kitaalamu ya binadamu. Hatutawajibika kwa maelewano mabaya au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.