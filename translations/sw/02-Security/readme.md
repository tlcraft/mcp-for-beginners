<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:46:24+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "sw"
}
-->
# Mbinu Bora za Usalama

Kutumia Model Context Protocol (MCP) kunaleta uwezo mpya wenye nguvu kwa programu zinazoendeshwa na AI, lakini pia huanzisha changamoto za kipekee za usalama ambazo zinaenda zaidi ya hatari za jadi za programu. Mbali na wasiwasi uliowekwa kama usimbaji salama, upendeleo mdogo, na usalama wa mnyororo wa ugavi, MCP na mizigo ya AI inakabiliwa na vitisho vipya kama sindano ya prompt, sumu ya zana, na mabadiliko ya zana ya nguvu. Hatari hizi zinaweza kusababisha uhamishaji wa data, uvunjaji wa faragha, na tabia isiyotarajiwa ya mfumo ikiwa hazitasimamiwa vizuri.

Somo hili linaangazia hatari za usalama zinazohusiana na MCP—ikiwa ni pamoja na uthibitishaji, idhini, ruhusa nyingi, sindano ya prompt isiyo ya moja kwa moja, na udhaifu wa mnyororo wa ugavi—na hutoa udhibiti wa vitendo na mbinu bora za kupunguza. Pia utajifunza jinsi ya kutumia suluhisho za Microsoft kama Prompt Shields, Usalama wa Maudhui ya Azure, na Usalama wa Juu wa GitHub ili kuimarisha utekelezaji wako wa MCP. Kwa kuelewa na kutumia udhibiti huu, unaweza kupunguza kwa kiasi kikubwa uwezekano wa uvunjaji wa usalama na kuhakikisha mifumo yako ya AI inabaki kuwa imara na ya kuaminika.

# Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Tambua na eleza hatari za kipekee za usalama zinazoletwa na Model Context Protocol (MCP), ikiwa ni pamoja na sindano ya prompt, sumu ya zana, ruhusa nyingi, na udhaifu wa mnyororo wa ugavi.
- Eleza na tumia udhibiti wa kupunguza madhara kwa hatari za usalama za MCP, kama uthibitishaji thabiti, upendeleo mdogo, usimamizi salama wa tokeni, na uthibitishaji wa mnyororo wa ugavi.
- Elewa na tumia suluhisho za Microsoft kama Prompt Shields, Usalama wa Maudhui ya Azure, na Usalama wa Juu wa GitHub ili kulinda mizigo ya MCP na AI.
- Tambua umuhimu wa kuthibitisha metadata ya zana, kufuatilia mabadiliko ya nguvu, na kujilinda dhidi ya mashambulizi ya sindano ya prompt isiyo ya moja kwa moja.
- Unganisha mbinu bora za usalama zilizowekwa—kama usimbaji salama, kuimarisha seva, na usanifu wa kuaminika sifuri—katika utekelezaji wako wa MCP ili kupunguza uwezekano na athari za uvunjaji wa usalama.

# Udhibiti wa usalama wa MCP

Mfumo wowote wenye ufikiaji wa rasilimali muhimu una changamoto za usalama zilizoonyeshwa. Changamoto za usalama kwa ujumla zinaweza kushughulikiwa kupitia utumiaji sahihi wa udhibiti wa usalama wa msingi na dhana. Kwa kuwa MCP imefafanuliwa tu hivi karibuni, maelezo yanabadilika haraka sana na kadri itakavyokuwa. Hatimaye udhibiti wa usalama ndani yake utakua, kuwezesha ushirikiano bora na usanifu wa usalama wa biashara na mbinu bora zilizowekwa.

Utafiti uliochapishwa katika [Ripoti ya Ulinzi wa Dijitali ya Microsoft](https://aka.ms/mddr) unasema kuwa 98% ya uvunjaji ulioarifiwa ungezuiwa na usafi wa usalama thabiti na ulinzi bora dhidi ya aina yoyote ya uvunjaji ni kupata usafi wako wa msingi wa usalama, mbinu bora za usimbaji salama na usalama wa mnyororo wa ugavi sawa -- zile mbinu zilizojaribiwa na kuthibitishwa ambazo tayari tunajua bado zinafanya athari kubwa zaidi katika kupunguza hatari ya usalama.

Hebu tuangalie baadhi ya njia ambazo unaweza kuanza kushughulikia hatari za usalama wakati wa kutumia MCP.

# Uthibitishaji wa seva ya MCP (ikiwa utekelezaji wako wa MCP ulikuwa kabla ya tarehe 26 Aprili 2025)

> **Note:** Taarifa ifuatayo ni sahihi hadi tarehe 26 Aprili 2025. Itifaki ya MCP inaendelea kubadilika, na utekelezaji wa siku zijazo unaweza kuanzisha mifumo na udhibiti mpya wa uthibitishaji. Kwa masasisho na mwongozo wa hivi karibuni, daima rejelea [MCP Specification](https://spec.modelcontextprotocol.io/) na [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Taarifa ya tatizo 
Maelezo ya awali ya MCP yalidhani kuwa wasanidi programu wangeandika seva yao ya uthibitishaji. Hii ilihitaji ujuzi wa OAuth na vikwazo vya usalama vinavyohusiana. Seva za MCP zilifanya kazi kama Seva za Idhini za OAuth 2.0, zikisimamia uthibitishaji wa watumiaji moja kwa moja badala ya kuikabidhi kwa huduma ya nje kama Microsoft Entra ID. Kuanzia tarehe 26 Aprili 2025, sasisho la maelezo ya MCP linawezesha seva za MCP kukabidhi uthibitishaji wa watumiaji kwa huduma ya nje.

### Hatari
- Mantiki ya idhini iliyosanidiwa vibaya katika seva ya MCP inaweza kusababisha kufichuliwa kwa data nyeti na udhibiti wa ufikiaji kutumika vibaya.
- Wizi wa tokeni ya OAuth kwenye seva ya MCP ya ndani. Ikiwa imeibiwa, tokeni inaweza kutumika kuiga seva ya MCP na kufikia rasilimali na data kutoka kwa huduma ambayo tokeni ya OAuth ni kwa ajili yake.

### Udhibiti wa kupunguza madhara
- **Pitia na Imarisha Mantiki ya Idhini:** Kagua kwa makini utekelezaji wa idhini ya seva yako ya MCP ili kuhakikisha kuwa watumiaji na wateja waliokusudiwa pekee wanaweza kufikia rasilimali nyeti. Kwa mwongozo wa vitendo, tazama [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) na [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tumia Mbinu Salama za Tokeni:** Fuata [mbinu bora za Microsoft za uthibitishaji wa tokeni na muda wa maisha](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) ili kuzuia matumizi mabaya ya tokeni za ufikiaji na kupunguza hatari ya kurudia au wizi wa tokeni.
- **Linda Uhifadhi wa Tokeni:** Daima hifadhi tokeni kwa usalama na tumia usimbaji ili kuzilinda katika hali ya kupumzika na kusafiri. Kwa vidokezo vya utekelezaji, tazama [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).


# Ruhusa nyingi kwa seva za MCP

### Taarifa ya tatizo
Seva za MCP zinaweza kuwa zimetolewa ruhusa nyingi kwa huduma/rasilimali wanazofikia. Kwa mfano, seva ya MCP ambayo ni sehemu ya programu ya mauzo ya AI inayounganisha na hifadhi ya data ya biashara inapaswa kuwa na ufikiaji uliowekwa kwa data ya mauzo na isiweze kufikia faili zote katika hifadhi. Rejelea kanuni ya upendeleo mdogo (moja ya kanuni za zamani za usalama), hakuna rasilimali inapaswa kuwa na ruhusa zaidi ya zinazohitajika ili kutekeleza kazi ambazo ilikusudiwa. AI inatoa changamoto iliyoongezeka katika eneo hili kwa sababu ili kuiwezesha kuwa rahisi, inaweza kuwa changamoto kufafanua ruhusa halisi zinazohitajika.

### Hatari 
- Kutoa ruhusa nyingi kunaweza kuruhusu uhamishaji au kubadilisha data ambayo seva ya MCP haikukusudiwa kuweza kufikia. Hii inaweza pia kuwa suala la faragha ikiwa data ni taarifa inayotambulika kibinafsi (PII).

### Udhibiti wa kupunguza madhara
- **Tumia Kanuni ya Upendeleo Mdogo:** Toa seva ya MCP ruhusa za chini tu zinazohitajika kutekeleza kazi zake zinazohitajika. Pitia na sasisha ruhusa hizi mara kwa mara ili kuhakikisha hazizidi kile kinachohitajika. Kwa mwongozo wa kina, tazama [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Tumia Udhibiti wa Ufikiaji wa Kulingana na Majukumu (RBAC):** Weka majukumu kwenye seva ya MCP ambayo yamewekwa kwa karibu kwenye rasilimali na vitendo maalum, kuepuka ruhusa pana au zisizohitajika.
- **Fuatilia na Kagua Ruhusa:** Fuatilia kwa kuendelea matumizi ya ruhusa na kagua magogo ya ufikiaji ili kugundua na kurekebisha ruhusa nyingi au zisizotumika haraka.

# Mashambulizi ya sindano ya prompt isiyo ya moja kwa moja

### Taarifa ya tatizo

Seva za MCP zilizo na uovu au zilizoathirika zinaweza kuanzisha hatari kubwa kwa kufichua data ya wateja au kuwezesha vitendo visivyokusudiwa. Hatari hizi ni muhimu hasa katika mizigo inayotegemea AI na MCP, ambapo:

- **Mashambulizi ya Sindano ya Prompt**: Washambulizi huingiza maagizo ya uovu katika maoni au maudhui ya nje, na kusababisha mfumo wa AI kutekeleza vitendo visivyokusudiwa au kuvuja data nyeti. Jifunze zaidi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Sumu ya Zana**: Washambulizi hubadilisha metadata ya zana (kama maelezo au vigezo) ili kuathiri tabia ya AI, ikiwezekana kupitisha udhibiti wa usalama au kuhamisha data. Maelezo: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Sindano ya Prompt ya Kikoa Kimoja**: Maagizo ya uovu huingizwa katika hati, kurasa za wavuti, au barua pepe, ambazo kisha zinachakatwa na AI, na kusababisha uvujaji wa data au uharibifu.
- **Mabadiliko ya Zana ya Nguvu (Rug Pulls)**: Maelezo ya zana yanaweza kubadilishwa baada ya idhini ya mtumiaji, kuanzisha tabia mpya za uovu bila ufahamu wa mtumiaji.

Udhaifu huu unasisitiza hitaji la uthibitishaji thabiti, ufuatiliaji, na udhibiti wa usalama wakati wa kuunganisha seva na zana za MCP katika mazingira yako. Kwa uchambuzi wa kina, tazama marejeleo yaliyotajwa hapo juu.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.sw.png)

**Sindano ya Prompt Isiyo ya Moja kwa Moja** (pia inajulikana kama sindano ya prompt ya kikoa kimoja au XPIA) ni udhaifu muhimu katika mifumo ya AI inayozalisha, ikiwa ni pamoja na zile zinazotumia Model Context Protocol (MCP). Katika shambulio hili, maagizo ya uovu yamefichwa ndani ya maudhui ya nje—kama hati, kurasa za wavuti, au barua pepe. Wakati mfumo wa AI unachakata maudhui haya, inaweza kutafsiri maagizo yaliyowekwa kama amri halali za mtumiaji, na kusababisha vitendo visivyokusudiwa kama uvujaji wa data, kizazi cha maudhui hatari, au uharibifu wa mwingiliano wa mtumiaji. Kwa maelezo ya kina na mifano halisi, tazama [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Aina hatari sana ya shambulio hili ni **Sumu ya Zana**. Hapa, washambulizi huingiza maagizo ya uovu katika metadata ya zana za MCP (kama maelezo ya zana au vigezo). Kwa kuwa mifano mikubwa ya lugha (LLMs) inategemea metadata hii kuamua zana gani za kutumia, maelezo yaliyoathirika yanaweza kudanganya mfano kutekeleza miito ya zana isiyoidhinishwa au kupitisha udhibiti wa usalama. Udanganyifu huu mara nyingi hauonekani kwa watumiaji wa mwisho lakini unaweza kutafsiriwa na kutekelezwa na mfumo wa AI. Hatari hii inaongezeka katika mazingira ya seva za MCP zinazohifadhiwa, ambapo maelezo ya zana yanaweza kusasishwa baada ya idhini ya mtumiaji—hali inayojulikana wakati mwingine kama "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Katika hali kama hizo, zana ambayo hapo awali ilikuwa salama inaweza baadaye kubadilishwa ili kutekeleza vitendo vya uovu, kama kuhamisha data au kubadilisha tabia ya mfumo, bila ufahamu wa mtumiaji. Kwa zaidi juu ya vector hii ya shambulio, tazama [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).


![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.sw.png)


## Hatari
Vitendo visivyokusudiwa vya AI vinatoa aina mbalimbali za hatari za usalama zinazojumuisha uhamishaji wa data na uvunjaji wa faragha.

### Udhibiti wa kupunguza madhara
### Kutumia ngao za prompt kulinda dhidi ya mashambulizi ya sindano ya prompt isiyo ya moja kwa moja
-----------------------------------------------------------------------------

**AI Prompt Shields** ni suluhisho lililotengenezwa na Microsoft ili kujilinda dhidi ya mashambulizi ya sindano ya prompt ya moja kwa moja na isiyo ya moja kwa moja. Zinasaidia kupitia:

1.  **Uchunguzi na Uchujaji**: Prompt Shields hutumia algorithimu za kujifunza mashine za hali ya juu na usindikaji wa lugha asilia kutambua na kuchuja maagizo ya uovu yaliyoingizwa katika maudhui ya nje, kama hati, kurasa za wavuti, au barua pepe.
    
2.  **Spotlighting**: Mbinu hii husaidia mfumo wa AI kutofautisha kati ya maagizo halali ya mfumo na pembejeo za nje zinazoweza kutokuwa na uaminifu. Kwa kubadilisha maandishi ya pembejeo kwa njia ambayo inafanya kuwa muhimu zaidi kwa mfano, Spotlighting inahakikisha kuwa AI inaweza kutambua na kupuuza maagizo ya uovu.
    
3.  **Vipimo na Alama za Data**: Kujumuisha vipimo katika ujumbe wa mfumo hueleza wazi eneo la maandishi ya pembejeo, kusaidia mfumo wa AI kutambua na kutenganisha pembejeo za mtumiaji kutoka kwa maudhui ya nje yanayoweza kuwa hatari. Alama za data zinapanua dhana hii kwa kutumia alama maalum kuonyesha mipaka ya data inayotegemewa na isiyoweza kutegemewa.
    
4.  **Ufuatiliaji na Sasisho Endelevu**: Microsoft inafuatilia na kusasisha Prompt Shields mara kwa mara ili kushughulikia vitisho vipya na vinavyoendelea. Mbinu hii ya kujitolea inahakikisha kuwa ulinzi unabaki kuwa na ufanisi dhidi ya mbinu za shambulio za hivi karibuni.
    
5. **Muunganisho na Usalama wa Maudhui ya Azure:** Prompt Shields ni sehemu ya suite pana ya Usalama wa Maudhui ya Azure AI, ambayo hutoa zana za ziada za kugundua majaribio ya jailbreak, maudhui hatari, na hatari nyingine za usalama katika programu za AI.

Unaweza kusoma zaidi kuhusu ngao za prompt za AI katika [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.sw.png)


### Usalama wa mnyororo wa ugavi

Usalama wa mnyororo wa ugavi unabaki kuwa msingi katika enzi ya AI, lakini upeo wa kile kinachounda mnyororo wako wa ugavi umepanuka. Mbali na pakiti za msimbo za jadi, lazima sasa uthibitishe na kufuatilia kwa uangalifu vipengele vyote vinavyohusiana na AI, ikiwa ni pamoja na mifano ya msingi, huduma za embeddings, watoa muktadha, na API za watu wengine. Kila moja ya hizi inaweza kuanzisha udhaifu au hatari ikiwa hazitasimamiwa vizuri.

**Mbinu muhimu za usalama wa mnyororo wa ugavi kwa AI na MCP:**
- **Thibitisha vipengele vyote kabla ya kuunganisha:** Hii ni pamoja na si tu maktaba za chanzo wazi, lakini pia mifano ya AI, vyanzo vya data, na API za nje. Daima angalia asili, leseni, na udhaifu unaojulikana.
- **Dumisha mitambo salama ya utoaji:** Tumia mitambo ya CI/CD iliyojumuishwa na uchunguzi wa usalama ili kugundua masuala mapema. Hakikisha kuwa ni vifaa vinavyotegemewa pekee vinavyotolewa kwa uzalishaji.
- **Fuatilia na kagua kwa kuendelea:** Tekeleza ufuatiliaji endelevu wa utegemezi wote, ikiwa ni pamoja na mifano na huduma za data, ili kugundua udhaifu mpya au mashambulizi ya mnyororo wa ugavi.
- **Tumia upendeleo mdogo na
- [OWASP Top 10 kwa LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Safari ya Kuhakikisha Usalama wa Ugavi wa Programu Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Ufikiaji wa Usalama wa Kiwango cha Chini Zaidi (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Mbinu Bora za Uthibitishaji wa Tokeni na Muda wa Maisha](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Tumia Hifadhi ya Tokeni Salama na Ficha Tokeni (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management kama Lango la Uthibitishaji kwa MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Kutumia Microsoft Entra ID kuthibitisha na MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Ifuatayo 

Ifuatayo: [Sura ya 3: Kuanza](/03-GettingStarted/README.md)

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.