<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:32:16+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sw"
}
-->
# Mazoea Bora za Usalama

Kupitisha Model Context Protocol (MCP) huleta uwezo mpya wenye nguvu kwa programu zinazotumia AI, lakini pia huleta changamoto za kiusalama ambazo ni tofauti na hatari za kawaida za programu. Mbali na masuala yaliyojulikana kama uandishi wa msimbo salama, ruhusa za chini kabisa, na usalama wa mnyororo wa usambazaji, MCP na mizigo ya AI hukumbana na vitisho vipya kama vile sindano ya maelekezo (prompt injection), sumu ya zana (tool poisoning), na mabadiliko ya zana kwa wakati halisi. Hatari hizi zinaweza kusababisha uvuvi wa data, ukiukaji wa faragha, na tabia zisizotarajiwa za mfumo ikiwa hazidhibitiwi ipasavyo.

Somo hili linachunguza hatari muhimu zaidi za usalama zinazohusiana na MCP—ikiwa ni pamoja na uthibitishaji, idhini, ruhusa nyingi zaidi, sindano isiyo ya moja kwa moja ya maelekezo, na udhaifu wa mnyororo wa usambazaji—na linatoa mbinu na kanuni bora za kuzizuia. Pia utajifunza jinsi ya kutumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kuimarisha utekelezaji wako wa MCP. Kwa kuelewa na kutumia mbinu hizi, unaweza kupunguza kwa kiasi kikubwa uwezekano wa uvunjaji wa usalama na kuhakikisha mifumo yako ya AI inabaki imara na ya kuaminika.

# Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutambua na kueleza hatari za kiusalama za kipekee zinazotokana na Model Context Protocol (MCP), zikiwemo sindano ya maelekezo, sumu ya zana, ruhusa nyingi zaidi, na udhaifu wa mnyororo wa usambazaji.
- Kueleza na kutumia mbinu madhubuti za kupunguza hatari za usalama za MCP, kama uthibitishaji thabiti, ruhusa za chini kabisa, usimamizi salama wa tokeni, na uhakiki wa mnyororo wa usambazaji.
- Kuelewa na kutumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kulinda MCP na mizigo ya AI.
- Kutambua umuhimu wa kuthibitisha metadata ya zana, kufuatilia mabadiliko ya wakati halisi, na kujilinda dhidi ya mashambulizi ya sindano isiyo ya moja kwa moja ya maelekezo.
- Kuunganisha kanuni zilizothibitishwa za usalama—kama uandishi wa msimbo salama, kuimarisha seva, na usanifu wa zero trust—katika utekelezaji wako wa MCP ili kupunguza uwezekano na athari za uvunjaji wa usalama.

# Udhibiti wa usalama wa MCP

Mfumo wowote unaopata rasilimali muhimu unakumbwa na changamoto za usalama. Changamoto hizi kwa kawaida zinaweza kutatuliwa kwa kutumia mbinu sahihi za udhibiti na dhana za msingi za usalama. Kwa kuwa MCP ni mpya, vipimo vyake vinabadilika kwa kasi na kadri itakavyoendelea, udhibiti wa usalama ndani yake utakua na kuendana na usanifu wa usalama wa taasisi na kanuni bora zilizopo.

Utafiti uliochapishwa katika [Microsoft Digital Defense Report](https://aka.ms/mddr) unaonyesha kuwa asilimia 98 ya uvunjaji ulioripotiwa ungezuiawa kwa kutumia mbinu thabiti za usafi wa usalama na kinga bora dhidi ya aina yoyote ya uvunjaji ni kuhakikisha usafi wako wa msingi wa usalama, mbinu bora za uandishi wa msimbo, na usalama wa mnyororo wa usambazaji vimezingatiwa—mbinu hizi zilizojaribiwa bado zina athari kubwa katika kupunguza hatari za usalama.

Tuchunguze baadhi ya njia unazoweza kuanza kuzitumia kukabiliana na hatari za usalama unapoanzisha MCP.

> **Note:** Taarifa zifuatazo ni sahihi hadi tarehe **29 Mei 2025**. Itifaki ya MCP inaendelea kubadilika, na utekelezaji wa baadaye unaweza kuleta mifumo mipya ya uthibitishaji na udhibiti. Kwa masasisho na miongozo ya hivi punde, rejelea [MCP Specification](https://spec.modelcontextprotocol.io/), [MCP GitHub repository](https://github.com/modelcontextprotocol) na [ukurasa wa kanuni bora za usalama](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Tatizo lililopo  
Ufafanuzi wa awali wa MCP ulidhani kuwa watengenezaji wangeandika seva yao ya uthibitishaji. Hii ilihitaji ujuzi wa OAuth na vizingiti vingine vya usalama. Seva za MCP zilifanya kazi kama Seva za Uthibitishaji wa OAuth 2.0, zikisimamia uthibitishaji wa mtumiaji moja kwa moja badala ya kuurudisha kwa huduma ya nje kama Microsoft Entra ID. Kuanzia **26 Aprili 2025**, sasisho la ufafanuzi wa MCP linaruhusu seva za MCP kurudisha uthibitishaji wa watumiaji kwa huduma ya nje.

### Hatari
- Mipangilio isiyo sahihi ya mantiki ya idhini kwenye seva ya MCP inaweza kusababisha kufichuliwa kwa data nyeti na matumizi mabaya ya udhibiti wa upatikanaji.
- Uibiwa wa tokeni za OAuth kwenye seva ya MCP ya ndani. Ikiibiwa, tokeni inaweza kutumiwa kuiga seva ya MCP na kupata rasilimali na data kutoka kwa huduma inayotumia tokeni hiyo.

#### Kupelekwa Tokeni Bila Mabadiliko
Kupelekwa tokeni bila mabadiliko kumewekwa marufuku wazi katika ufafanuzi wa idhini kwa sababu huleta hatari kadhaa za usalama, zikiwemo:

#### Kupindua Udhibiti wa Usalama
Seva ya MCP au APIs zinazofuata zinaweza kutekeleza udhibiti muhimu wa usalama kama vile kupunguza idadi ya maombi, uthibitishaji wa maombi, au ufuatiliaji wa trafiki, ambao hutegemea hadhira ya tokeni au vizingiti vingine vya cheti. Ikiwa wateja wanaweza kupata na kutumia tokeni moja kwa moja na APIs zinazofuata bila seva ya MCP kuzikagua ipasavyo au kuhakikisha tokeni imetolewa kwa huduma sahihi, wanazuiwa udhibiti huu.

#### Masuala ya Uwajibikaji na Rekodi za Ukaguzi
Seva ya MCP haitoweza kutambua au kutofautisha kati ya Wateja wa MCP wanapoitumia tokeni za upatikanaji zilizotolewa na chanzo cha juu ambazo zinaweza kuwa gumu kwa seva ya MCP.
Rekodi za seva ya rasilimali inayofuata zinaweza kuonyesha maombi yanayoonekana kutoka chanzo tofauti na utambulisho tofauti, badala ya seva ya MCP inayosafirisha tokeni.
Vitu hivi vyote vinafanya uchunguzi wa matukio, udhibiti, na ukaguzi kuwa mgumu zaidi.
Ikiwa seva ya MCP inapeleka tokeni bila kuangalia madai yake (kama vile majukumu, ruhusa, au hadhira) au metadata nyingine, mwovu mwenye tokeni iliyoporwa anaweza kutumia seva kama mpokeaji wa uvuvi wa data.

#### Masuala ya Mipaka ya Uaminifu
Seva ya rasilimali inayofuata inampa uaminifu taasisi maalum. Uaminifu huu unaweza kujumuisha makadirio kuhusu asili au tabia za mteja. Kuvunja mipaka hii ya uaminifu kunaweza kusababisha matatizo yasiyotegemewa.
Ikiwa tokeni inakubaliwa na huduma nyingi bila uhakiki sahihi, mshambuliaji anayevuruga huduma moja anaweza kutumia tokeni hiyo kufikia huduma zingine zinazohusiana.

#### Hatari ya Ulinganifu wa Baadaye
Hata kama seva ya MCP inaanza kama "wakala safi" leo, inaweza kuhitaji kuongeza udhibiti wa usalama baadaye. Kuanzisha kwa kutenganisha hadhira ya tokeni kunarahisisha kuendeleza mfano wa usalama.

### Udhibiti wa kupunguza hatari

**Seva za MCP HAZIKUBALI tokeni yoyote ambayo haikutolewa wazi kwa seva ya MCP**

- **Kagua na Imarisha Mantiki ya Idhini:** Fanyia ukaguzi wa kina utekelezaji wa idhini kwenye seva yako ya MCP kuhakikisha kuwa watumiaji na wateja waliokusudiwa pekee ndio wanaweza kupata rasilimali nyeti. Kwa mwongozo wa vitendo, angalia [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) na [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tekeleza Mbinu Salama za Tokeni:** Fuata [kanuni bora za Microsoft za uhakiki na muda wa tokeni](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) ili kuzuia matumizi mabaya ya tokeni za upatikanaji na kupunguza hatari ya kurudiwa au uibiwa wa tokeni.
- **Linda Uhifadhi wa Tokeni:** Hifadhi tokeni kwa usalama na tumia usimbaji fiche kulinda tokeni wakati ziko hifadhi au zinaposafirishwa. Kwa vidokezo vya utekelezaji, angalia [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Ruhusa nyingi zaidi kwa seva za MCP

### Tatizo lililopo
Seva za MCP huenda zimepewa ruhusa nyingi zaidi ya zinazohitajika kwa huduma/rasilimali wanayofikia. Kwa mfano, seva ya MCP inayotumika katika programu ya mauzo ya AI inayounganisha na hifadhi ya data ya shirika inapaswa kupata ruhusa tu za data za mauzo, si ruhusa za kufikia faili zote katika hifadhi. Kurejelea kanuni ya ruhusa ya chini kabisa (moja ya kanuni za usalama za zamani kabisa), hakuna rasilimali inapaswa kuwa na ruhusa zaidi ya zinazohitajika kutekeleza kazi zake. AI inaleta changamoto kubwa hapa kwa sababu ili iwe na ufanisi, mara nyingi ni vigumu kubainisha ruhusa halisi zinazohitajika.

### Hatari  
- Kutoa ruhusa nyingi sana kunaweza kuruhusu uvuvi au mabadiliko ya data ambayo seva ya MCP haikukusudiwa kuifikia. Hii pia inaweza kuwa tatizo la faragha ikiwa data ni taarifa za kibinafsi (PII).

### Udhibiti wa kupunguza hatari
- **Tekeleza Kanuni ya Ruhusa ya Chini Kabisa:** Toa seva ya MCP ruhusa ndogo kabisa zinazohitajika kwa kazi zake. Pitia na sasisha ruhusa hizi mara kwa mara kuhakikisha hazizidi mahitaji. Kwa mwongozo wa kina, angalia [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Tumia Udhibiti wa Upatikanaji Kwa Kila Kazi (RBAC):** Weka majukumu kwa seva ya MCP yaliyo na mipaka madhubuti kwa rasilimali na vitendo maalum, epuka ruhusa pana au zisizohitajika.
- **Fuatilia na Kagua Ruhusa:** Fuatilia matumizi ya ruhusa na kagua rekodi za upatikanaji ili kugundua na kurekebisha ruhusa nyingi au zisizotumika haraka iwezekanavyo.

# Mashambulizi ya sindano isiyo ya moja kwa moja ya maelekezo

### Tatizo lililopo

Seva za MCP zilizo hatarini au zilizoibiwa zinaweza kuleta hatari kubwa kwa kufichua data za wateja au kuruhusu vitendo visivyokusudiwa. Hatari hizi ni muhimu hasa kwa mizigo ya AI na MCP, ambapo:

- **Mashambulizi ya Sindano ya Maelekezo:** Washambuliaji huingiza maelekezo mabaya katika maelekezo au maudhui ya nje, na kusababisha mfumo wa AI kufanya vitendo visivyokusudiwa au kufichua data nyeti. Jifunze zaidi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Sumu ya Zana:** Washambuliaji hubadilisha metadata ya zana (kama maelezo au vigezo) kuathiri tabia ya AI, na huenda wakapita udhibiti wa usalama au kufanya uvuvi wa data. Maelezo: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Sindano ya Maelekezo ya Mikoa Mbalimbali:** Maelekezo mabaya huingizwa katika hati, kurasa za wavuti, au barua pepe, ambayo huchakatwa na AI na kusababisha uvujaji wa data au uathiri wa maudhui.
- **Mabadiliko ya Zana kwa Wakati Halisi (Rug Pulls):** Maelezo ya zana yanaweza kubadilishwa baada ya idhini ya mtumiaji, kuleta tabia mbaya bila ufahamu wa mtumiaji.

Udhaifu huu unaonyesha umuhimu wa uhakiki thabiti, ufuatiliaji, na udhibiti wa usalama wakati wa kuingiza seva za MCP na zana katika mazingira yako. Kwa ufafanuzi wa kina, angalia marejeleo yaliyotajwa hapo juu.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sw.png)

**Sindano Isiyo ya Moja kwa Moja ya Maelekezo** (inayojulikana pia kama sindano ya maelekezo ya mikoa mbalimbali au XPIA) ni udhaifu mkubwa katika mifumo ya AI inayotumia uzalishaji, ikiwemo ile inayotumia Model Context Protocol (MCP). Katika shambulio hili, maelekezo mabaya yamefichwa ndani ya maudhui ya nje—kama hati, kurasa za wavuti, au barua pepe. AI inapochakata maudhui haya, inaweza kufasiri maelekezo yaliyofichwa kama amri halali za mtumiaji, na kusababisha vitendo visivyokusudiwa kama uvujaji wa data, uzalishaji wa maudhui hatarishi, au uathiri wa mwingiliano wa mtumiaji. Kwa maelezo ya kina na mifano halisi, angalia [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Aina hatari zaidi ya shambulio hili ni **Sumu ya Zana**. Hapa, washambuliaji huingiza maelekezo mabaya katika metadata ya zana za MCP (kama maelezo au vigezo vya zana). Kwa kuwa modeli kubwa za lugha (LLMs) hutegemea metadata hii kuamua zana gani za kuitumia, maelezo yaliyoharibika yanaweza kumdanganya modeli kutekeleza simu za zana zisizoruhusiwa au kupita udhibiti wa usalama. Mabadiliko haya mara nyingi hayaonekani kwa watumiaji wa mwisho lakini yanatafsiriwa na kutekelezwa na mfumo wa AI. Hatari hii huongezeka katika mazingira ya seva za MCP zinazohudumiwa, ambapo maelezo ya zana yanaweza kubadilishwa baada ya idhini ya mtumiaji—hali inayojulikana kama "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Katika hali hizi, zana ambayo awali ilikuwa salama inaweza kubadilishwa baadaye kufanya vitendo vya uovu kama uvuvi wa data au kubadilisha tabia ya mfumo bila ufahamu wa mtumiaji. Kwa zaidi kuhusu njia hii ya shambulio, angalia [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sw.png)

## Hatari
Vitendo visivyotarajiwa vya AI vina hatari mbalimbali za usalama ikiwemo uvuvi wa data na ukiukaji wa faragha.

### Udhibiti wa kupunguza hatari
### Kutumia prompt shields kulinda dhidi ya mashambulizi ya sindano isiyo ya moja kwa moja ya maelekezo
-----------------------------------------------------------------------------

**AI Prompt Shields** ni suluhisho lililotengenezwa na Microsoft kulinda dhidi ya mashambulizi ya sindano ya maelekezo ya moja kwa moja na isiyo ya moja kwa moja. Husaidia kwa:

1.  **Kugundua na Kuchuja:** Prompt Shields hutumia algorithms za juu za kujifunza mashine na usindikaji wa lugha asilia kugundua na kuchuja maelekezo mabaya yaliyofichwa katika maudhui ya nje kama hati, kurasa za wavuti, au barua pepe.
    
2.  **Spotlighting:** Mbinu hii husaidia mfumo wa AI kutofautisha kati ya maelekezo halali ya mfumo na maingizo ya nje yanayoweza kuwa hatari. Kwa kubadilisha maandishi ya ingizo kwa njia inayofaa zaidi kwa modeli, Spotlighting huhakikisha AI inaweza kutambua na kupuuza maelekezo mabaya.
    
3.  **Delimiters na Datamarking:** Kuweka delimiters katika ujumbe wa mfumo huonyesha wazi sehemu ya maandishi ya ingizo, kusaidia AI kutambua na kutenganisha maingizo ya mtumiaji kutoka kwa maudhui ya nje yanayoweza kuwa hatari. Datamarking inaongeza kwa kutumia alama maalum kuonyesha mipaka ya data yenye uaminifu na isiyo ya uaminifu.
    
4.  **Ufuatiliaji na Sasisho Endelevu:** Microsoft inaendelea kufuatilia na kusasisha Prompt Shields kukabiliana na vitisho vipya vinavyoibuka. Mbinu hii ya kujiandaa inahakikisha kinga zinab
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

Ifuatayo: [Sura ya 3: Kuanzia](/03-GettingStarted/README.md)

**Kibali cha kuwajibika**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Hati asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatubebei jukumu lolote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.