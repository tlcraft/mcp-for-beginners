<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T10:15:08+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sw"
}
-->
# Mazoea Bora za Usalama

Kukubali Model Context Protocol (MCP) kunaleta uwezo mpya wenye nguvu kwa programu zinazoendeshwa na AI, lakini pia kunaleta changamoto za kipekee za usalama ambazo zinazidi hatari za kawaida za programu. Mbali na wasiwasi uliopo kama uandishi wa msimbo salama, ruhusa ndogo kabisa, na usalama wa mnyororo wa usambazaji, MCP na mzigo wa kazi wa AI wanakumbana na vitisho vipya kama sindano za maelekezo, sumu ya zana, mabadiliko ya zana kwa wakati halisi, udukuzi wa vikao, mashambulizi ya confused deputy, na udhaifu wa tokeni kupitishwa. Hatari hizi zinaweza kusababisha uvujaji wa data, ukiukaji wa faragha, na tabia zisizotarajiwa za mfumo ikiwa hazitadhibitiwa ipasavyo.

Somo hili linachunguza hatari muhimu za usalama zinazohusiana na MCP—ikiwa ni pamoja na uthibitishaji, idhini, ruhusa nyingi sana, sindano isiyo ya moja kwa moja ya maelekezo, usalama wa vikao, matatizo ya confused deputy, udhaifu wa tokeni kupitishwa, na udhaifu wa mnyororo wa usambazaji—na linatoa udhibiti unaoweza kutekelezwa pamoja na mbinu bora za kuzizuia. Pia utajifunza jinsi ya kutumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kuimarisha utekelezaji wako wa MCP. Kwa kuelewa na kutumia udhibiti huu, unaweza kupunguza kwa kiasi kikubwa uwezekano wa uvunjaji wa usalama na kuhakikisha mifumo yako ya AI inabaki imara na ya kuaminika.

# Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutambua na kueleza hatari za kipekee za usalama zinazotokana na Model Context Protocol (MCP), ikiwa ni pamoja na sindano za maelekezo, sumu ya zana, ruhusa nyingi sana, udukuzi wa vikao, matatizo ya confused deputy, udhaifu wa tokeni kupitishwa, na udhaifu wa mnyororo wa usambazaji.
- Kueleza na kutumia udhibiti madhubuti wa kupunguza hatari za usalama za MCP, kama vile uthibitishaji thabiti, ruhusa ndogo kabisa, usimamizi salama wa tokeni, udhibiti wa usalama wa vikao, na uhakiki wa mnyororo wa usambazaji.
- Kuelewa na kutumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kulinda MCP na mzigo wa kazi wa AI.
- Kutambua umuhimu wa kuthibitisha metadata ya zana, kufuatilia mabadiliko ya wakati halisi, kujilinda dhidi ya mashambulizi ya sindano isiyo ya moja kwa moja ya maelekezo, na kuzuia udukuzi wa vikao.
- Kuunganisha mbinu bora za usalama zilizothibitishwa—kama vile uandishi wa msimbo salama, kuimarisha seva, na usanifu wa zero trust—katika utekelezaji wako wa MCP ili kupunguza uwezekano na athari za uvunjaji wa usalama.

# Udhibiti wa Usalama wa MCP

Mfumo wowote unaopata rasilimali muhimu unakumbana na changamoto za usalama. Changamoto hizi kwa kawaida zinaweza kushughulikiwa kwa kutumia udhibiti na dhana za msingi za usalama kwa usahihi. Kwa kuwa MCP ni kipengele kipya tu, maelezo yake yanabadilika kwa kasi na itakapoendelea kubadilika, hatimaye udhibiti wa usalama ndani yake utakua, kuruhusu muingiliano bora na usanifu wa usalama wa taasisi na mbinu bora zilizopo.

Utafiti uliochapishwa katika [Microsoft Digital Defense Report](https://aka.ms/mddr) unaonyesha kuwa asilimia 98 ya uvunjaji uliripotiwa ungezuia kwa kutumia usafi mzuri wa usalama na kinga bora dhidi ya aina yoyote ya uvunjaji ni kupata usafi wako wa msingi wa usalama, mbinu bora za uandishi wa msimbo salama, na usalama wa mnyororo wa usambazaji kwa usahihi—mbinu hizi zilizojaribiwa na kuthibitishwa bado zina athari kubwa katika kupunguza hatari za usalama.

Tuchunguze baadhi ya njia unazoweza kuanza kuzitatua hatari za usalama unapoanzisha MCP.

> **Note:** Taarifa zifuatazo ni sahihi hadi **tarehe 29 Mei 2025**. Itifaki ya MCP inaendelea kubadilika, na utekelezaji wa baadaye unaweza kuleta mifumo mipya ya uthibitishaji na udhibiti. Kwa masasisho na mwongozo wa hivi karibuni, rejelea [MCP Specification](https://spec.modelcontextprotocol.io/) na [MCP GitHub repository](https://github.com/modelcontextprotocol) rasmi pamoja na [ukurasa wa mbinu bora za usalama](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Taarifa ya Tatizo  
Maelezo ya awali ya MCP yalidhani kuwa waendelezaji wangeandika seva yao ya uthibitishaji. Hii ilihitaji uelewa wa OAuth na vizingiti vingine vya usalama vinavyohusiana. Seva za MCP zilifanya kazi kama Seva za Uidhinishaji za OAuth 2.0, zikisimamia uthibitishaji wa mtumiaji moja kwa moja badala ya kuurudisha kwa huduma ya nje kama Microsoft Entra ID. Kuanzia **26 Aprili 2025**, sasisho la maelezo ya MCP linaruhusu seva za MCP kurudisha uthibitishaji wa mtumiaji kwa huduma ya nje.

### Hatari
- Mantiki isiyosahihi ya idhini kwenye seva ya MCP inaweza kusababisha kufichuliwa kwa data nyeti na udhibiti wa upatikanaji usio sahihi.
- Uziizi wa tokeni za OAuth kwenye seva ya MCP ya ndani. Ikiwa zitaporwa, tokeni inaweza kutumika kuigiza seva ya MCP na kupata rasilimali na data kutoka kwa huduma ambayo tokeni ya OAuth ni kwa ajili yake.

#### Token Passthrough  
Tokeni kupitishwa kinyume kabisa na maelezo ya idhini kwa sababu inaleta hatari kadhaa za usalama, zikiwemo:

#### Kuepuka Udhibiti wa Usalama  
Seva ya MCP au API za chini zinaweza kutekeleza udhibiti muhimu wa usalama kama vile kuweka kikomo cha kiwango, uthibitishaji wa maombi, au ufuatiliaji wa trafiki, ambazo hutegemea hadhira ya tokeni au vizingiti vingine vya cheti. Ikiwa wateja wanaweza kupata na kutumia tokeni moja kwa moja na API za chini bila seva ya MCP kuzikagua ipasavyo au kuhakikisha tokeni zimetolewa kwa huduma sahihi, wanapita udhibiti huu.

#### Masuala ya Uwajibikaji na Rekodi za Ukaguzi  
Seva ya MCP haitoweza kutambua au kutofautisha kati ya Wateja wa MCP wakati wateja wanapofanya maombi kwa tokeni ya upatikanaji iliyotolewa na huduma ya juu ambayo inaweza kuwa haieleweki kwa seva ya MCP.  
Rekodi za seva ya rasilimali ya chini zinaweza kuonyesha maombi yanayoonekana kutoka chanzo tofauti na utambulisho tofauti, badala ya seva ya MCP inayotuma tokeni hizo.  
Vitu hivi vyote vinafanya uchunguzi wa matukio, udhibiti, na ukaguzi kuwa vigumu zaidi.  
Ikiwa seva ya MCP inapita tokeni bila kuthibitisha madai yao (mfano, majukumu, ruhusa, au hadhira) au metadata nyingine, mhalifu mwenye tokeni iliyoporwa anaweza kutumia seva kama wakala wa kuondoa data.

#### Masuala ya Mipaka ya Uaminifu  
Seva ya rasilimali ya chini hutoa uaminifu kwa vyombo maalum. Uaminifu huu unaweza kujumuisha dhana kuhusu asili au tabia za mteja. Kuvunja mipaka hii ya uaminifu kunaweza kusababisha matatizo yasiyotarajiwa.  
Ikiwa tokeni inakubaliwa na huduma nyingi bila uthibitishaji sahihi, mdukuzi anayeathiri huduma moja anaweza kutumia tokeni hiyo kupata huduma nyingine zinazohusiana.

#### Hatari ya Ulinganifu wa Baadaye  
Hata kama seva ya MCP inaanza kama "wakala safi" leo, inaweza kuhitaji kuongeza udhibiti wa usalama baadaye. Kuanzia na utofauti sahihi wa hadhira ya tokeni kunarahisisha kuendeleza mfano wa usalama.

### Udhibiti wa Kupunguza Hatari

**Seva za MCP HAZIPASWI kukubali tokeni zozote ambazo hazikutolewa wazi kwa seva ya MCP**

- **Kagua na Imarisha Mantiki ya Idhini:** Fanya ukaguzi wa kina wa utekelezaji wa idhini kwenye seva yako ya MCP kuhakikisha kuwa watumiaji na wateja waliokusudiwa tu ndio wanaweza kupata rasilimali nyeti. Kwa mwongozo wa vitendo, angalia [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) na [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tekeleza Mbinu Salama za Tokeni:** Fuata [mbinu bora za Microsoft za uthibitishaji na muda wa tokeni](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) ili kuzuia matumizi mabaya ya tokeni za upatikanaji na kupunguza hatari ya kurudia au kuibiwa tokeni.
- **Linda Uhifadhi wa Tokeni:** Hifadhi tokeni kwa usalama kila wakati na tumia usimbaji fiche kuwalinda wakati wa kuhifadhi na kusafirisha. Kwa vidokezo vya utekelezaji, angalia [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Ruhusa Nyingi Sana kwa Seva za MCP

### Taarifa ya Tatizo  
Seva za MCP zinaweza kuwa zimepewa ruhusa nyingi sana kwa huduma/rasilimali wanayopata. Kwa mfano, seva ya MCP inayojumuishwa katika programu ya mauzo ya AI inayounganisha na hifadhi ya data ya taasisi inapaswa kuwa na ruhusa zilizopangwa kwa data ya mauzo tu na isiruhusiwe kupata faili zote katika hifadhi hiyo. Kurejelea kanuni ya ruhusa ndogo kabisa (moja ya kanuni za usalama za zamani zaidi), hakuna rasilimali inapaswa kuwa na ruhusa zaidi ya inavyohitajika kutekeleza kazi zilizokusudiwa. AI inaleta changamoto kubwa zaidi katika eneo hili kwa sababu ili kuifanya iwe rahisi kubadilika, inaweza kuwa vigumu kufafanua ruhusa halisi zinazohitajika.

### Hatari  
- Kutoa ruhusa nyingi sana kunaweza kuruhusu uvujaji au mabadiliko ya data ambayo seva ya MCP haikukusudiwa kuipata. Hii pia inaweza kuwa tatizo la faragha ikiwa data ni taarifa za mtu binafsi (PII).

### Udhibiti wa Kupunguza Hatari  
- **Tekeleza Kanuni ya Ruhusa Ndogo Kabisa:** Toa seva ya MCP ruhusa ndogo tu zinazohitajika kufanya kazi zake. Kagua na sasisha ruhusa hizi mara kwa mara kuhakikisha hazizidi mahitaji. Kwa mwongozo wa kina, angalia [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Tumia Udhibiti wa Upatikanaji kwa Misingi ya Majukumu (RBAC):** Weka majukumu kwa seva ya MCP yaliyo na mipaka thabiti kwa rasilimali na vitendo maalum, kuepuka ruhusa pana au zisizohitajika.
- **Fuatilia na Fanya Ukaguzi wa Ruhusa:** Fuatilia matumizi ya ruhusa kwa kuendelea na ukague rekodi za upatikanaji kugundua na kurekebisha ruhusa nyingi au zisizotumika haraka iwezekanavyo.

# Mashambulizi ya Sindano Isiyo ya Moja kwa Moja ya Maelekezo

### Taarifa ya Tatizo

Seva za MCP zilizo na madhumuni mabaya au zilizodukuliwa zinaweza kuleta hatari kubwa kwa kufichua data za wateja au kuruhusu vitendo visivyotarajiwa. Hatari hizi ni muhimu hasa katika mzigo wa kazi wa AI na MCP, ambapo:

- **Mashambulizi ya Sindano za Maelekezo:** Wadukuzi huingiza maagizo mabaya ndani ya maelekezo au maudhui ya nje, na kusababisha mfumo wa AI kufanya vitendo visivyotarajiwa au kuvuja data nyeti. Jifunze zaidi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Sumu ya Zana:** Wadukuzi hubadilisha metadata ya zana (kama maelezo au vigezo) kuathiri tabia ya AI, labda kupita udhibiti wa usalama au kuondoa data. Maelezo: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Sindano za Maelekezo za Mikoa Mbalimbali:** Maagizo mabaya huingizwa katika nyaraka, kurasa za wavuti, au barua pepe, ambazo kisha huchakatwa na AI, na kusababisha uvujaji au uathiri wa data.
- **Mabadiliko ya Zana kwa Wakati Halisi (Rug Pulls):** Maelezo ya zana yanaweza kubadilishwa baada ya idhini ya mtumiaji, kuleta tabia mpya mbaya bila mtumiaji kujua.

Udhaifu huu unaonyesha umuhimu wa uthibitishaji thabiti, ufuatiliaji, na udhibiti wa usalama wakati wa kuingiza seva za MCP na zana katika mazingira yako. Kwa uchunguzi wa kina, angalia marejeleo yaliyotajwa hapo juu.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sw.png)

**Sindano Isiyo ya Moja kwa Moja ya Maelekezo** (inayojulikana pia kama sindano ya maelekezo ya mikoa mbalimbali au XPIA) ni udhaifu mkubwa katika mifumo ya AI inayotengeneza maudhui, ikiwa ni pamoja na ile inayotumia Model Context Protocol (MCP). Katika shambulio hili, maagizo mabaya yamefichwa ndani ya maudhui ya nje—kama nyaraka, kurasa za wavuti, au barua pepe. Wakati mfumo wa AI unachakata maudhui haya, unaweza kufasiri maagizo yaliyofichwa kama amri halali za mtumiaji, na kusababisha vitendo visivyotarajiwa kama uvujaji wa data, uzalishaji wa maudhui hatarishi, au uathiri wa mwingiliano wa mtumiaji. Kwa maelezo ya kina na mifano halisi, angalia [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Aina hatari ya shambulio hili ni **Sumu ya Zana**. Hapa, wadukuzi huingiza maagizo mabaya katika metadata ya zana za MCP (kama maelezo au vigezo vya zana). Kwa kuwa mifano mikubwa ya lugha (LLMs) hutegemea metadata hii kuamua zana gani zitaitwa, maelezo yaliyodukuliwa yanaweza kudanganya mfano kufanya simu za zana zisizoruhusiwa au kupita udhibiti wa usalama. Mabadiliko haya mara nyingi hayaonekani kwa watumiaji wa mwisho lakini yanaweza kufasiriwa na kutekelezwa na mfumo wa AI. Hatari hii inaongezeka katika mazingira ya seva za MCP zilizo hifadhiwa, ambapo maelezo ya zana yanaweza kusasishwa baada ya idhini ya mtumiaji—hali inayojulikana kama "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Katika hali kama hizi, zana iliyokuwa salama awali inaweza kubadilishwa baadaye kufanya vitendo vya uovu, kama uvujaji wa data au kubadilisha tabia ya mfumo, bila mtumiaji kujua. Kwa zaidi kuhusu njia hii ya shambulio, angalia [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sw.png)

## Hatari  
Vitendo visivyotarajiwa vya AI vina hatari mbalimbali za usalama zikiwemo uvujaji wa data na ukiukaji wa faragha.

### Udhibiti wa Kupunguza Hatari  
### Kutumia prompt shields kulinda dhidi ya mashambulizi ya Sindano Isiyo ya Moja kwa Moja ya Maelekezo  
-----------------------------------------------------------------------------

**AI Prompt Shields** ni suluhisho lililotengenezwa na Microsoft kulinda dhidi ya mashambulizi ya sindano za maelekezo ya moja kwa moja na isiyo ya moja kwa moja. Husaidia kwa:

1.  **Kugundua na Kuchuja:** Prompt Shields hutumia algorithms za hali ya juu za kujifunza mashine na usindikaji wa lugha asilia kugundua na kuchuja maagizo mabaya yaliyofichwa katika maudhui ya nje, kama nyaraka, kurasa za wavuti, au barua pepe.
    
2.  **Spotlighting:** Mbinu hii husaidia mfumo wa AI kutofautisha kati ya maagizo halali ya mfumo na maingizo ya nje ambayo yanaweza kuwa hayana uaminifu. Kwa kubadilisha maandishi ya ingizo kwa njia inayofaa zaidi kwa mfano, Spotlighting huhakikisha AI inaweza kutambua na kupuuza maagizo mabaya.
    
3.  **
Tatizo la confused deputy ni udhaifu wa usalama unaotokea wakati seva ya MCP inafanya kazi kama wakala kati ya wateja wa MCP na API za wahusika wengine. Udhaifu huu unaweza kutumiwa pale seva ya MCP inapotumia kitambulisho cha mteja cha kudumu kujiandikisha na seva ya idhini ya mhusika wa tatu ambayo haina msaada wa usajili wa mteja wa mabadiliko.

### Hatari

- **Kupitisha idhini kwa kutumia cookie**: Ikiwa mtumiaji amewahi kujiandikisha kupitia seva ya wakala ya MCP, seva ya idhini ya mhusika wa tatu inaweza kuweka cookie ya idhini kwenye kivinjari cha mtumiaji. Mshambuliaji anaweza baadaye kutumia hili kwa kumtumia mtumiaji kiungo chenye maombi ya idhini yaliyoandaliwa yenye URI ya kuhamisha kwa madhumuni mabaya.
- **Uziizi wa msimbo wa idhini**: Mtumiaji anapobofya kiungo chenye madhumuni mabaya, seva ya idhini ya mhusika wa tatu inaweza kuruka skrini ya idhini kutokana na kuwepo kwa cookie, na msimbo wa idhini unaweza kuhamishiwa seva ya mshambuliaji.
- **Upatikanaji usioidhinishwa wa API**: Mshambuliaji anaweza kubadilisha msimbo wa idhini ulioporwa kwa tokeni za upatikanaji na kujifanya mtumiaji ili kupata API ya mhusika wa tatu bila idhini wazi.

### Udhibiti wa kupunguza

- **Mahitaji ya idhini wazi**: Seva za wakala za MCP zinazotumia vitambulisho vya mteja vya kudumu **Lazima** zipate idhini ya mtumiaji kwa kila mteja aliyejisajili kwa mabadiliko kabla ya kuwasilisha kwa seva za idhini za wahusika wa tatu.
- **Utekelezaji sahihi wa OAuth**: Fuata mbinu bora za usalama za OAuth 2.1, ikiwa ni pamoja na kutumia changamoto za msimbo (PKCE) kwa maombi ya idhini ili kuzuia mashambulizi ya kukamata maombi.
- **Uthibitishaji wa mteja**: Tekeleza uthibitishaji mkali wa URI za kuhamisha na vitambulisho vya mteja ili kuzuia matumizi mabaya na wahalifu.

# Udhaifu wa Kupitisha Tokeni

### Taarifa ya tatizo

"Token passthrough" ni mtindo mbaya ambapo seva ya MCP inakubali tokeni kutoka kwa mteja wa MCP bila kuthibitisha kuwa tokeni hizo zilitolewa kwa seva ya MCP yenyewe, kisha "zinaipitisha" kwa API za chini. Tabia hii inakiuka wazi maelezo ya idhini ya MCP na kuleta hatari kubwa za usalama.

### Hatari

- **Kupitisha udhibiti wa usalama**: Wateja wanaweza kupita udhibiti muhimu wa usalama kama vile ukomo wa kiwango, uthibitishaji wa maombi, au ufuatiliaji wa trafiki ikiwa wanaweza kutumia tokeni moja kwa moja na API za chini bila uthibitishaji sahihi.
- **Masuala ya uwajibikaji na ufuatiliaji**: Seva ya MCP haitoweza kutambua au kutofautisha kati ya wateja wa MCP wakati wateja wanapotumia tokeni za upatikanaji zilizotolewa na seva za juu, na kufanya uchunguzi wa matukio na ukaguzi kuwa mgumu.
- **Utoaji wa data bila idhini**: Ikiwa tokeni zinapitishwa bila uthibitishaji sahihi wa madai, mshambuliaji mwenye tokeni iliyoporwa anaweza kutumia seva kama wakala kwa ajili ya kutoa data bila idhini.
- **Uvunjaji wa mipaka ya kuaminika**: Seva za rasilimali za chini zinaweza kuamini vyombo maalum kwa misingi ya asili au tabia. Kuvunja mipaka hii ya kuaminika kunaweza kusababisha matatizo yasiyotarajiwa ya usalama.
- **Matumizi mabaya ya tokeni kwa huduma nyingi**: Ikiwa tokeni zinakubaliwa na huduma nyingi bila uthibitishaji sahihi, mshambuliaji anayeathiri huduma moja anaweza kutumia tokeni hiyo kupata huduma nyingine zinazohusiana.

### Udhibiti wa kupunguza

- **Uthibitishaji wa tokeni**: Seva za MCP **HAZIFAI** kukubali tokeni zozote ambazo hazikutolewa wazi kwa seva ya MCP yenyewe.
- **Uthibitishaji wa hadhira**: Daima hakikisha tokeni zina madai ya hadhira inayolingana na utambulisho wa seva ya MCP.
- **Usimamizi sahihi wa mzunguko wa tokeni**: Tekeleza tokeni za muda mfupi na mbinu sahihi za mzunguko wa tokeni ili kupunguza hatari ya wizi na matumizi mabaya ya tokeni.

# Kunyakuliwa kwa Kikao

### Taarifa ya tatizo

Kunyakuliwa kwa kikao ni njia ya shambulizi ambapo mteja anapewa kitambulisho cha kikao na seva, na mtu asiyeidhinishwa anapata na kutumia kitambulisho hicho cha kikao kuigiza mteja halali na kufanya vitendo visivyoidhinishwa kwa niaba yake. Hili ni jambo la wasiwasi hasa kwa seva za HTTP zenye hali zinazoshughulikia maombi ya MCP.

### Hatari

- **Kuingizwa kwa amri za kunyakuwa kikao**: Mshambuliaji anayeweza kupata kitambulisho cha kikao anaweza kutuma matukio yenye madhumuni mabaya kwa seva inayoshirikiana hali ya kikao na seva ambayo mteja ameunganishwa nayo, na kusababisha vitendo hatari au kupata data nyeti.
- **Kuigiza kunyakuliwa kwa kikao**: Mshambuliaji mwenye kitambulisho cha kikao aliyoporwa anaweza kuita moja kwa moja seva ya MCP, kupita uthibitishaji na kutendewa kama mtumiaji halali.
- **Mtiririko wa data unaoweza kuendelea uliovunjika**: Seva inayounga mkono utoaji upya/mitiririko inayoweza kuendelea, mshambuliaji anaweza kukatisha ombi mapema, na kuufanya uendelee baadaye na mteja halali na maudhui yenye madhumuni mabaya.

### Udhibiti wa kupunguza

- **Uthibitishaji wa idhini**: Seva za MCP zinazotekeleza idhini **LAZIMA** zithibitishe maombi yote yanayoingia na **HAZIFAI** kutumia vikao kwa uthibitishaji.
- **Vitambulisho salama vya kikao**: Seva za MCP **LAZIMA** zitumie vitambulisho salama, visivyo na mfuatano vinavyotengenezwa kwa jenereta salama za nambari za nasibu. Epuka vitambulisho vinavyoweza kutabirika au mfuatano.
- **Kufunga kikao kwa mtumiaji binafsi**: Seva za MCP **ZINAPENDEKEZWA** kufunga vitambulisho vya kikao na taarifa za mtumiaji binafsi, kwa kuchanganya kitambulisho cha kikao na taarifa za mtumiaji aliyeidhinishwa (kama ID ya mtumiaji wa ndani) kwa muundo kama `
<user_id>:<session_id>`.
- **Muda wa kumalizika kwa kikao**: Tekeleza kumalizika na mzunguko sahihi wa vikao ili kupunguza dirisha la hatari ikiwa kitambulisho cha kikao kitavunjika.
- **Usalama wa usafirishaji**: Daima tumia HTTPS kwa mawasiliano yote ili kuzuia kukamatwa kwa kitambulisho cha kikao.

# Usalama wa Mnyororo wa Ugavi

Usalama wa mnyororo wa ugavi unabaki kuwa msingi katika enzi ya AI, lakini wigo wa kile kinachojumuisha mnyororo wako wa ugavi umeongezeka. Mbali na vifurushi vya kawaida vya msimbo, sasa lazima uhakikishe na kufuatilia kwa ukaribu vipengele vyote vinavyohusiana na AI, ikiwa ni pamoja na mifano ya msingi, huduma za embeddings, watoa muktadha, na API za wahusika wa tatu. Kila kimoja kinaweza kuleta udhaifu au hatari ikiwa hakidhibitiwi ipasavyo.

**Mazingira muhimu ya usalama wa mnyororo wa ugavi kwa AI na MCP:**
- **Thibitisha vipengele vyote kabla ya kuunganisha:** Hii ni pamoja na maktaba za chanzo huria, mifano ya AI, vyanzo vya data, na API za nje. Daima hakikisha asili, leseni, na udhaifu unaojulikana.
- **Dumisha njia salama za utoaji:** Tumia njia za CI/CD zilizo otomatiki zenye skanning ya usalama ili kugundua matatizo mapema. Hakikisha tu vitu vinavyoaminika vinawekwa kwenye uzalishaji.
- **Fuatilia na ukague mara kwa mara:** Tekeleza ufuatiliaji endelevu wa utegemezi wote, ikiwa ni pamoja na mifano na huduma za data, kugundua udhaifu mpya au mashambulizi ya mnyororo wa ugavi.
- **Tumia kanuni ya udhibiti wa upatikanaji mdogo:** Zuia upatikanaji wa mifano, data, na huduma kwa kile tu kinachohitajika kwa seva yako ya MCP kufanya kazi.
- **Jibu haraka kwa vitisho:** Kuwa na mchakato wa kufunga au kubadilisha vipengele vilivyovamiwa, na kwa mzunguko wa siri au nyaraka ikiwa uvunjaji utagunduliwa.

[GitHub Advanced Security](https://github.com/security/advanced-security) hutoa vipengele kama skanning ya siri, skanning ya utegemezi, na uchambuzi wa CodeQL. Zana hizi zinaunganishwa na [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) na [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) kusaidia timu kugundua na kupunguza udhaifu katika msimbo na vipengele vya mnyororo wa ugavi wa AI.

Microsoft pia inatekeleza mbinu za kina za usalama wa mnyororo wa ugavi ndani kwa bidhaa zote. Jifunze zaidi katika [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Mbinu Bora za Usalama Zilizothibitishwa Zitakazoboresha Usalama wa Utekelezaji wa MCP Wako

Utekelezaji wowote wa MCP unarithi hali ya usalama iliyopo ya mazingira ya shirika lako ambayo umejengwa juu yake, hivyo unapotafakari usalama wa MCP kama sehemu ya mifumo yako ya AI kwa ujumla, inashauriwa uangalie kuboresha hali yako ya usalama iliyopo. Udhibiti wa usalama ulioanzishwa una umuhimu mkubwa:

-   Mbinu bora za uandishi wa msimbo salama katika programu yako ya AI - linda dhidi ya [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 kwa LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), tumia hifadhi salama kwa siri na tokeni, tekeleza mawasiliano salama ya mwisho hadi mwisho kati ya vipengele vyote vya programu, n.k.
-   Kuimarisha seva -- tumia MFA inapowezekana, endelea kusasisha viraka, ungana na mtoa huduma wa utambulisho wa mtu wa tatu kwa upatikanaji, n.k.
-   Weka vifaa, miundombinu na programu zikiwa na viraka vya kisasa
-   Ufuatiliaji wa usalama -- tekeleza uandikishaji na ufuatiliaji wa programu ya AI (ikiwa ni pamoja na wateja/seva za MCP) na tuma kumbukumbu hizo kwa SIEM kuu kwa kugundua shughuli zisizo za kawaida
-   Msingi wa kuamini sifuri -- tengeneza vipengele kwa kutumia udhibiti wa mtandao na utambulisho kwa njia ya mantiki ili kupunguza harakati za upande hadi upande ikiwa programu ya AI itavamiwa.

# Muhimu Kuu

- Misingi ya usalama bado ni muhimu: Uandishi wa msimbo salama, upatikanaji mdogo, uthibitishaji wa mnyororo wa ugavi, na ufuatiliaji endelevu ni muhimu kwa MCP na mzigo wa AI.
- MCP inaleta hatari mpya—kama vile kuingizwa kwa amri, sumu ya zana, kunyakuliwa kwa kikao, matatizo ya confused deputy, udhaifu wa kupitisha tokeni, na ruhusa nyingi—zinazohitaji udhibiti wa jadi na maalum wa AI.
- Tumia mbinu thabiti za uthibitishaji, idhini, na usimamizi wa tokeni, ukitumia watoa huduma wa utambulisho wa nje kama Microsoft Entra ID inapowezekana.
- Linda dhidi ya kuingizwa kwa amri isiyo ya moja kwa moja na sumu ya zana kwa kuthibitisha metadata ya zana, kufuatilia mabadiliko ya mabadiliko, na kutumia suluhisho kama Microsoft Prompt Shields.
- Tekeleza usimamizi salama wa kikao kwa kutumia vitambulisho vya kikao visivyo na mfuatano, kufunga vikao na utambulisho wa mtumiaji, na kamwe usitumie vikao kwa uthibitishaji.
- Zuia mashambulizi ya confused deputy kwa kuhitaji idhini wazi ya mtumiaji kwa kila mteja aliyejisajili kwa mabadiliko na kutekeleza mbinu bora za usalama za OAuth.
- Epuka udhaifu wa kupitisha tokeni kwa kuhakikisha seva za MCP zinakubali tokeni zilizotolewa wazi kwao na kuthibitisha madai ya tokeni ipasavyo.
- Tibu vipengele vyote katika mnyororo wako wa ugavi wa AI—ikiwa ni pamoja na mifano, embeddings, na watoa muktadha—kwa ukaribu sawa na utegemezi wa msimbo.
- Endelea kufuatilia maelezo ya MCP yanayobadilika na changia jamii kusaidia kuunda viwango salama.

# Rasilimali Zaidi

## Rasilimali za Nje
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Nyaraka Zaidi za Usalama

Kwa mwongozo wa kina zaidi wa usalama, tafadhali rejea nyaraka hizi:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Orodha kamili ya mbinu bora za usalama kwa utekelezaji wa MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Mifano ya utekelezaji wa kuunganisha Azure Content Safety na seva za MCP
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Udhibiti na mbinu za usalama za hivi karibuni kwa usalama wa MCP
- [MCP Best Practices](./mcp-best-practices.md) - Mwongozo wa haraka wa usalama wa MCP

### Ifuatayo

Ifuatayo: [Sura ya 3: Kuanzia](../03-GettingStarted/README.md)

**Kiarifu cha Msamaha**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.