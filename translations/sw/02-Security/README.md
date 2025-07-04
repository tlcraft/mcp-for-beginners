<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T18:27:16+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sw"
}
-->
# Mazoea Bora ya Usalama

Kukubali Itifaki ya Muktadha wa Mfano (MCP) kunaleta uwezo mpya wenye nguvu kwa programu zinazotumia AI, lakini pia kunaleta changamoto za kiusalama ambazo ni tofauti na hatari za kawaida za programu. Mbali na wasiwasi uliopo kama uandishi wa msimbo salama, ruhusa ndogo kabisa, na usalama wa mnyororo wa usambazaji, MCP na mzigo wa kazi wa AI hukumbwa na vitisho vipya kama sindano za maelekezo, sumu ya zana, na mabadiliko ya zana kwa wakati halisi. Hatari hizi zinaweza kusababisha wizi wa data, uvunjaji wa faragha, na tabia zisizotarajiwa za mfumo ikiwa hazitadhibitiwa ipasavyo.

Somo hili linachunguza hatari muhimu za usalama zinazohusiana na MCP—ikiwa ni pamoja na uthibitishaji, idhini, ruhusa nyingi sana, sindano isiyo ya moja kwa moja ya maelekezo, na udhaifu wa mnyororo wa usambazaji—na linatoa udhibiti unaoweza kutekelezwa pamoja na mbinu bora za kuzizuia. Pia utajifunza jinsi ya kutumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kuimarisha utekelezaji wako wa MCP. Kwa kuelewa na kutumia udhibiti huu, unaweza kupunguza kwa kiasi kikubwa uwezekano wa uvunjaji wa usalama na kuhakikisha mifumo yako ya AI inabaki imara na ya kuaminika.

# Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutambua na kueleza hatari za kiusalama za kipekee zinazotokana na Itifaki ya Muktadha wa Mfano (MCP), ikiwa ni pamoja na sindano za maelekezo, sumu ya zana, ruhusa nyingi sana, na udhaifu wa mnyororo wa usambazaji.
- Kueleza na kutumia udhibiti madhubuti wa kupunguza hatari za usalama za MCP, kama vile uthibitishaji thabiti, ruhusa ndogo kabisa, usimamizi salama wa tokeni, na uhakiki wa mnyororo wa usambazaji.
- Kuelewa na kutumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kulinda MCP na mzigo wa kazi wa AI.
- Kutambua umuhimu wa kuthibitisha metadata ya zana, kufuatilia mabadiliko ya wakati halisi, na kujilinda dhidi ya mashambulizi ya sindano isiyo ya moja kwa moja ya maelekezo.
- Kuunganisha mbinu bora za usalama zilizothibitishwa—kama uandishi wa msimbo salama, kuimarisha seva, na usanifu wa zero trust—katika utekelezaji wako wa MCP ili kupunguza uwezekano na athari za uvunjaji wa usalama.

# Udhibiti wa usalama wa MCP

Mfumo wowote unaopata rasilimali muhimu unakumbwa na changamoto za usalama. Changamoto hizi kwa kawaida zinaweza kushughulikiwa kwa kutumia udhibiti na dhana za msingi za usalama kwa usahihi. Kwa kuwa MCP ni itifaki mpya tu, maelezo yake yanabadilika kwa kasi na itifaki inavyoendelea kubadilika. Hatimaye, udhibiti wa usalama ndani yake utakua, kuruhusu muunganisho bora na usanifu wa usalama wa makampuni na mbinu bora zilizopo.

Utafiti uliochapishwa katika [Microsoft Digital Defense Report](https://aka.ms/mddr) unasema kuwa asilimia 98 ya uvunjaji ulioripotiwa ungezuiawa kwa kutumia usafi wa usalama thabiti na kinga bora dhidi ya aina yoyote ya uvunjaji ni kupata usafi wako wa msingi wa usalama, mbinu bora za uandishi wa msimbo salama, na usalama wa mnyororo wa usambazaji kwa usahihi—mbinu hizo zilizojaribiwa na kuthibitishwa bado zina athari kubwa katika kupunguza hatari za usalama.

Tuchunguze baadhi ya njia unazoweza kuanza kuzitatua hatari za usalama unapoanzisha MCP.

> **[!NOTE]:** Taarifa zifuatazo ni sahihi hadi **tarehe 29 Mei 2025**. Itifaki ya MCP inaendelea kubadilika, na utekelezaji wa baadaye unaweza kuleta mifumo mipya ya uthibitishaji na udhibiti. Kwa masasisho na mwongozo wa hivi karibuni, rejelea [MCP Specification](https://spec.modelcontextprotocol.io/) na [MCP GitHub repository](https://github.com/modelcontextprotocol) rasmi pamoja na [ukurasa wa mbinu bora za usalama](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Taarifa ya tatizo  
Maelezo ya awali ya MCP yalidhani kuwa waendelezaji wangeandika seva yao ya uthibitishaji. Hii ilihitaji uelewa wa OAuth na vizingiti vingine vya usalama vinavyohusiana. Seva za MCP zilifanya kazi kama Seva za Uidhinishaji za OAuth 2.0, zikisimamia uthibitishaji wa mtumiaji moja kwa moja badala ya kuurudisha kwa huduma ya nje kama Microsoft Entra ID. Kuanzia **26 Aprili 2025**, sasisho la maelezo ya MCP linaruhusu seva za MCP kurudisha uthibitishaji wa mtumiaji kwa huduma ya nje.

### Hatari
- Mantiki isiyosahihi ya idhini kwenye seva ya MCP inaweza kusababisha kufichuliwa kwa data nyeti na udhibiti wa upatikanaji usio sahihi.
- Uibiwa wa tokeni za OAuth kwenye seva ya MCP ya ndani. Ikiwa zitaporwa, tokeni inaweza kutumika kuigiza seva ya MCP na kupata rasilimali na data kutoka kwa huduma inayotumia tokeni hiyo.

#### Kupitisha Tokeni
Kupitisha tokeni kinaruhusiwa kabisa katika maelezo ya idhini kwa sababu huleta hatari kadhaa za usalama, zikiwemo:

#### Kuepuka Udhibiti wa Usalama
Seva ya MCP au API za chini zinaweza kutekeleza udhibiti muhimu wa usalama kama vile kupunguza kiwango cha maombi, uthibitishaji wa maombi, au ufuatiliaji wa trafiki, ambazo hutegemea hadhira ya tokeni au vizingiti vingine vya cheti. Ikiwa wateja wanaweza kupata na kutumia tokeni moja kwa moja na API za chini bila seva ya MCP kuzikagua ipasavyo au kuhakikisha tokeni zimetolewa kwa huduma sahihi, basi wanapita udhibiti huu.

#### Masuala ya Uwajibikaji na Rekodi za Ukaguzi
Seva ya MCP haitoweza kutambua au kutofautisha kati ya Wateja wa MCP wakati wateja wanapofanya maombi kwa tokeni ya upatikanaji iliyotolewa na huduma ya juu ambayo inaweza kuwa haieleweki kwa seva ya MCP.
Rekodi za seva ya rasilimali ya chini zinaweza kuonyesha maombi yanayoonekana kutoka chanzo tofauti na utambulisho tofauti, badala ya seva ya MCP inayotuma tokeni hizo.
Vitu hivi vyote vinafanya uchunguzi wa matukio, udhibiti, na ukaguzi kuwa mgumu zaidi.
Ikiwa seva ya MCP inapita tokeni bila kuthibitisha madai yao (mfano, majukumu, ruhusa, au hadhira) au metadata nyingine, mtu mwenye nia mbaya mwenye tokeni iliyoporwa anaweza kutumia seva kama wakala wa kuondoa data.

#### Masuala ya Mipaka ya Uaminifu
Seva ya rasilimali ya chini hutoa uaminifu kwa vyombo maalum. Uaminifu huu unaweza kujumuisha dhana kuhusu asili au tabia za mteja. Kuvunja mipaka hii ya uaminifu kunaweza kusababisha matatizo yasiyotarajiwa.
Ikiwa tokeni inakubaliwa na huduma nyingi bila uthibitishaji sahihi, mshambuliaji anayeathiri huduma moja anaweza kutumia tokeni hiyo kupata huduma nyingine zinazohusiana.

#### Hatari ya Ulinganifu wa Baadaye
Hata kama seva ya MCP inaanza kama “wakala safi” leo, inaweza kuhitaji kuongeza udhibiti wa usalama baadaye. Kuanzia na utofauti sahihi wa hadhira ya tokeni kunarahisisha kuendeleza mfano wa usalama.

### Udhibiti wa Kupunguza

**Seva za MCP HAZIKUBALI tokeni zozote ambazo hazikutolewa wazi kwa seva ya MCP**

- **Kagua na Imarisha Mantiki ya Idhini:** Fanya ukaguzi wa kina wa utekelezaji wa idhini kwenye seva yako ya MCP kuhakikisha kuwa watumiaji na wateja waliokusudiwa tu ndio wanaweza kupata rasilimali nyeti. Kwa mwongozo wa vitendo, angalia [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) na [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tekeleza Mbinu Salama za Tokeni:** Fuata [mbinu bora za Microsoft za uthibitishaji na muda wa tokeni](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) ili kuzuia matumizi mabaya ya tokeni za upatikanaji na kupunguza hatari ya kurudishwa au wizi wa tokeni.
- **Linda Uhifadhi wa Tokeni:** Hifadhi tokeni kwa usalama kila wakati na tumia usimbaji fiche kuwalinda wakati wa kuhifadhi na kusafirisha. Kwa vidokezo vya utekelezaji, angalia [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Ruhusa nyingi sana kwa seva za MCP

### Taarifa ya tatizo  
Seva za MCP zinaweza kuwa zimepewa ruhusa nyingi sana kwa huduma/rasilimali wanayopata. Kwa mfano, seva ya MCP inayojumuishwa katika programu ya mauzo ya AI inayounganisha na hifadhi ya data ya kampuni inapaswa kuwa na ruhusa zilizopangwa kwa data ya mauzo tu na isiruhusiwe kupata faili zote katika hifadhi hiyo. Kurejelea kanuni ya ruhusa ndogo kabisa (moja ya kanuni za usalama za zamani zaidi), hakuna rasilimali inapaswa kuwa na ruhusa zaidi ya inavyohitajika kutekeleza kazi zake. AI inaleta changamoto kubwa zaidi hapa kwa sababu ili kuifanya iwe rahisi kubadilika, inaweza kuwa vigumu kufafanua ruhusa halisi zinazohitajika.

### Hatari  
- Kutoa ruhusa nyingi sana kunaweza kuruhusu kuondolewa au kubadilishwa kwa data ambayo seva ya MCP haikukusudiwa kuipata. Hii pia inaweza kuwa tatizo la faragha ikiwa data ni taarifa za mtu binafsi (PII).

### Udhibiti wa Kupunguza  
- **Tekeleza Kanuni ya Ruhusa Ndogo Kabisa:** Toa seva ya MCP ruhusa ndogo tu zinazohitajika kwa ajili ya kutekeleza kazi zake. Kagua na sasisha ruhusa hizi mara kwa mara kuhakikisha hazizidi mahitaji. Kwa mwongozo wa kina, angalia [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Tumia Udhibiti wa Upatikanaji kwa Misingi ya Majukumu (RBAC):** Weka majukumu kwa seva ya MCP yaliyo na mipaka thabiti kwa rasilimali na vitendo maalum, kuepuka ruhusa pana au zisizohitajika.
- **Fuatilia na Kagua Ruhusa:** Fuatilia matumizi ya ruhusa na kagua rekodi za upatikanaji ili kugundua na kurekebisha ruhusa nyingi au zisizotumika haraka iwezekanavyo.

# Mashambulizi ya sindano isiyo ya moja kwa moja ya maelekezo

### Taarifa ya tatizo

Seva za MCP zilizo na nia mbaya au zilizoharibiwa zinaweza kuleta hatari kubwa kwa kufichua data za wateja au kuwezesha vitendo visivyotarajiwa. Hatari hizi ni muhimu hasa katika mzigo wa kazi wa AI na MCP, ambapo:

- **Mashambulizi ya Sindano za Maelekezo:** Washambuliaji huingiza maagizo mabaya ndani ya maelekezo au maudhui ya nje, na kusababisha mfumo wa AI kufanya vitendo visivyotarajiwa au kufichua data nyeti. Jifunze zaidi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Sumu ya Zana:** Washambuliaji hubadilisha metadata ya zana (kama maelezo au vigezo) kuathiri tabia ya AI, kwa mfano kupita udhibiti wa usalama au kuondoa data. Maelezo: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Sindano za Maelekezo za Mikoa Mbalimbali:** Maagizo mabaya huingizwa katika nyaraka, kurasa za wavuti, au barua pepe, ambazo kisha huchakatwa na AI, na kusababisha uvujaji au uathiri wa data.
- **Mabadiliko ya Zana kwa Wakati Halisi (Rug Pulls):** Maelezo ya zana yanaweza kubadilishwa baada ya idhini ya mtumiaji, kuleta tabia mpya mbaya bila mtumiaji kujua.

Udhaifu huu unaonyesha umuhimu wa uthibitishaji thabiti, ufuatiliaji, na udhibiti wa usalama wakati wa kuingiza seva za MCP na zana katika mazingira yako. Kwa uchunguzi wa kina, angalia marejeleo yaliyotajwa hapo juu.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sw.png)

**Sindano Isiyo ya Moja kwa Moja ya Maelekezo** (inayojulikana pia kama sindano ya maelekezo ya mikoa mbalimbali au XPIA) ni udhaifu mkubwa katika mifumo ya AI inayotengeneza maudhui, ikiwa ni pamoja na ile inayotumia Itifaki ya Muktadha wa Mfano (MCP). Katika shambulio hili, maagizo mabaya yamefichwa ndani ya maudhui ya nje—kama nyaraka, kurasa za wavuti, au barua pepe. AI inapotumia maudhui haya, inaweza kufasiri maagizo yaliyofichwa kama amri halali za mtumiaji, na kusababisha vitendo visivyotarajiwa kama uvujaji wa data, uzalishaji wa maudhui hatari, au uathiri wa mwingiliano wa mtumiaji. Kwa maelezo ya kina na mifano halisi, angalia [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Aina hatari zaidi ya shambulio hili ni **Sumu ya Zana**. Hapa, washambuliaji huingiza maagizo mabaya katika metadata ya zana za MCP (kama maelezo au vigezo vya zana). Kwa kuwa mifano mikubwa ya lugha (LLMs) hutegemea metadata hii kuamua zana gani zitaitwa, maelezo yaliyoharibiwa yanaweza kudanganya mfano kutekeleza simu za zana zisizoruhusiwa au kupita udhibiti wa usalama. Mabadiliko haya mara nyingi hayaonekani kwa watumiaji wa mwisho lakini yanaweza kufasiriwa na kutekelezwa na mfumo wa AI. Hatari hii inaongezeka katika mazingira ya seva za MCP zilizo hifadhiwa, ambapo maelezo ya zana yanaweza kusasishwa baada ya idhini ya mtumiaji—hali inayojulikana kama "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Katika hali kama hizi, zana iliyokuwa salama awali inaweza kubadilishwa baadaye kufanya vitendo vya uharibifu, kama kuondoa data au kubadilisha tabia ya mfumo, bila mtumiaji kujua. Kwa zaidi kuhusu njia hii ya shambulio, angalia [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sw.png)

## Hatari  
Vitendo visivyotarajiwa vya AI vina hatari mbalimbali za usalama zikiwemo uvujaji wa data na uvunjaji wa faragha.

### Udhibiti wa Kupunguza  
### Kutumia prompt shields kulinda dhidi ya mashambulizi ya Sindano Isiyo ya Moja kwa Moja ya Maelekezo
-----------------------------------------------------------------------------

**AI Prompt Shields** ni suluhisho lililotengenezwa na Microsoft kulinda dhidi ya mashambulizi ya sindano za maelekezo ya moja kwa moja na isiyo ya moja kwa moja. Husaidia kwa:

1.  **Ugunduzi na Kuchuja:** Prompt Shields hutumia algoriti za hali ya juu za kujifunza mashine na usindikaji wa lugha asilia kugundua na kuchuja maagizo mabaya yaliyofichwa katika maudhui ya nje, kama nyaraka, kurasa za wavuti, au barua pepe.
    
2.  **Spotlighting:** Mbinu hii husaidia mfumo wa AI kutofautisha kati ya maagizo halali ya mfumo na maingizo ya nje ambayo yanaweza kuwa hayana uaminifu. Kwa kubadilisha maandishi ya ingizo kwa njia inayofaa zaidi kwa mfano, Spotlighting huhakikisha AI inaweza kutambua na kupuuza maagizo mabaya.
    
3.  **Delimiters na Datamarking:** Kuweka delimiters katika ujumbe wa mfumo huonyesha wazi eneo la maandishi ya ingizo, kusaidia AI kutambua na kutenganisha maingizo ya mtumiaji kutoka kwa maudhui ya nje yenye hatari. Datamarking inaongeza wazo hili kwa kutumia alama maalum kuonyesha mipaka ya data yenye uaminifu na isiyo na uaminifu.
    
4.
Usalama wa mnyororo wa usambazaji unabaki kuwa msingi katika enzi ya AI, lakini wigo wa kile kinachojumuisha mnyororo wako wa usambazaji umeongezeka. Mbali na vifurushi vya kawaida vya msimbo, sasa lazima uhakikishe na kufuatilia kwa ukaribu vipengele vyote vinavyohusiana na AI, ikiwa ni pamoja na mifano ya msingi, huduma za embeddings, watoa muktadha, na API za wahusika wengine. Kila kimoja cha hivi kinaweza kuleta udhaifu au hatari ikiwa hakitatunzwa ipasavyo.

**Mazingira muhimu ya usalama wa mnyororo wa usambazaji kwa AI na MCP:**
- **Thibitisha vipengele vyote kabla ya kuunganisha:** Hii haijumuishi tu maktaba za chanzo huria, bali pia mifano ya AI, vyanzo vya data, na API za nje. Daima hakikisha asili, leseni, na udhaifu unaojulikana.
- **Dumisha njia salama za utoaji:** Tumia njia za CI/CD zilizo otomatiki zenye uchunguzi wa usalama uliounganishwa ili kugundua matatizo mapema. Hakikisha kuwa vitu vinavyotegemewa pekee ndivyo vinawekwa kwenye uzalishaji.
- **Fuatilia na hakiki mara kwa mara:** Tekeleza ufuatiliaji endelevu kwa utegemezi wote, ikiwa ni pamoja na mifano na huduma za data, ili kugundua udhaifu mpya au mashambulizi ya mnyororo wa usambazaji.
- **Tumia kanuni ya upungufu wa ruhusa na udhibiti wa upatikanaji:** Zuia upatikanaji wa mifano, data, na huduma kwa kile tu kinachohitajika kwa seva yako ya MCP kufanya kazi.
- **Jibu haraka kwa vitisho:** Kuwa na mchakato wa kufunga au kubadilisha vipengele vilivyovamiwa, na kwa kuzungusha siri au nyaraka ikiwa uvunjaji utagunduliwa.

[GitHub Advanced Security](https://github.com/security/advanced-security) hutoa vipengele kama uchunguzi wa siri, uchunguzi wa utegemezi, na uchambuzi wa CodeQL. Zana hizi zinaunganishwa na [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) na [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) kusaidia timu kugundua na kupunguza udhaifu katika msimbo na vipengele vya mnyororo wa usambazaji wa AI.

Microsoft pia inatekeleza mbinu za kina za usalama wa mnyororo wa usambazaji ndani ya kampuni kwa bidhaa zote. Jifunze zaidi katika [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Mazingira bora ya usalama yaliyothibitishwa yatakayoboresha hali ya usalama ya utekelezaji wako wa MCP

Utekelezaji wowote wa MCP unachukua hali ya usalama iliyopo katika mazingira ya shirika lako ambayo umejengwa juu yake, hivyo unapotafakari usalama wa MCP kama sehemu ya mifumo yako ya AI kwa ujumla, inashauriwa uangalie kuboresha hali yako ya usalama iliyopo kwa ujumla. Udhibiti wa usalama ulioanzishwa una umuhimu mkubwa:

-   Mazingira bora ya uandishi wa msimbo salama katika programu yako ya AI - kinga dhidi ya [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 kwa LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), matumizi ya hazina salama kwa siri na tokeni, kutekeleza mawasiliano salama ya mwisho hadi mwisho kati ya vipengele vyote vya programu, n.k.
-   Kuimarisha seva -- tumia MFA inapowezekana, endelea kusasisha viraka, ungana na seva na mtoa huduma wa utambulisho wa mtu wa tatu kwa upatikanaji, n.k.
-   Weka vifaa, miundombinu na programu zikiwa na viraka vya kisasa
-   Ufuatiliaji wa usalama -- tekeleza uandikishaji na ufuatiliaji wa programu ya AI (ikiwa ni pamoja na wateja/seva wa MCP) na tuma kumbukumbu hizo kwa SIEM kuu kwa kugundua shughuli zisizo za kawaida
-   Msingi wa imani sifuri -- kutenganisha vipengele kupitia udhibiti wa mtandao na utambulisho kwa njia ya mantiki ili kupunguza harakati za upande ikiwa programu ya AI itavamiwa.

# Muhimu Kuu

- Misingi ya usalama bado ni muhimu: Uandishi wa msimbo salama, upungufu wa ruhusa, uhakiki wa mnyororo wa usambazaji, na ufuatiliaji endelevu ni muhimu kwa MCP na mzigo wa kazi wa AI.
- MCP inaleta hatari mpya—kama sindano za maelekezo, sumu ya zana, na ruhusa nyingi sana—zinazohitaji udhibiti wa jadi na maalum wa AI.
- Tumia mbinu thabiti za uthibitishaji, idhini, na usimamizi wa tokeni, ukitumia watoa huduma wa utambulisho wa nje kama Microsoft Entra ID inapowezekana.
- Linda dhidi ya sindano zisizo za moja kwa moja za maelekezo na sumu ya zana kwa kuthibitisha metadata ya zana, kufuatilia mabadiliko ya nguvu, na kutumia suluhisho kama Microsoft Prompt Shields.
- Tibu vipengele vyote katika mnyororo wako wa usambazaji wa AI—ikiwa ni pamoja na mifano, embeddings, na watoa muktadha—kwa umakini sawa na utegemezi wa msimbo.
- Endelea kufuatilia vipimo vinavyobadilika vya MCP na changia kwa jamii kusaidia kuunda viwango salama.

# Rasilimali Zaidi

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
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
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Ifuatayo

Ifuatayo: [Sura ya 3: Kuanzia](../03-GettingStarted/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.