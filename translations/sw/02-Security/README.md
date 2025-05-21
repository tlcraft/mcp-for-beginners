<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:21:19+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sw"
}
-->
# Mazoea Bora za Usalama

Kupitisha Model Context Protocol (MCP) huleta uwezo mpya wenye nguvu kwa programu zinazoendeshwa na AI, lakini pia huleta changamoto za kiusalama ambazo ni tofauti na hatari za kawaida za programu. Mbali na masuala yaliyojulikana kama uandishi salama wa msimbo, upunguzaji wa ruhusa, na usalama wa mnyororo wa usambazaji, MCP na mzigo wa kazi wa AI hukabiliwa na vitisho vipya kama vile sindano za maelekezo, sumu ya zana, na mabadiliko ya zana kwa wakati halisi. Hatari hizi zinaweza kusababisha uvujaji wa data, ukiukaji wa faragha, na tabia zisizotarajiwa za mfumo ikiwa hazitashughulikiwa ipasavyo.

Somo hili linachunguza hatari muhimu zaidi za kiusalama zinazohusiana na MCP—ikiwemo uthibitishaji, ruhusa, ruhusa kupita kiasi, sindano ya maelekezo isiyo ya moja kwa moja, na udhaifu wa mnyororo wa usambazaji—na linatoa udhibiti unaoweza kutekelezeka pamoja na mbinu bora za kuzizuia. Pia utajifunza jinsi ya kutumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kuimarisha utekelezaji wako wa MCP. Kwa kuelewa na kutumia vidhibiti hivi, unaweza kupunguza kwa kiasi kikubwa uwezekano wa uvunjaji wa usalama na kuhakikisha mifumo yako ya AI inabaki imara na ya kuaminika.

# Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutambua na kueleza hatari za kiusalama za kipekee zinazotokana na Model Context Protocol (MCP), ikiwa ni pamoja na sindano ya maelekezo, sumu ya zana, ruhusa kupita kiasi, na udhaifu wa mnyororo wa usambazaji.
- Kueleza na kutumia vidhibiti madhubuti vya kupunguza hatari za usalama wa MCP, kama vile uthibitishaji imara, upunguzaji wa ruhusa, usimamizi salama wa tokeni, na uhakiki wa mnyororo wa usambazaji.
- Kuelewa na kutumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kulinda MCP na mzigo wa kazi wa AI.
- Kutambua umuhimu wa kuthibitisha metadata ya zana, kufuatilia mabadiliko ya wakati halisi, na kujilinda dhidi ya mashambulizi ya sindano ya maelekezo isiyo ya moja kwa moja.
- Kuunganisha mbinu za kawaida bora za usalama—kama uandishi salama wa msimbo, kuimarisha seva, na usanifu wa zero trust—katika utekelezaji wako wa MCP ili kupunguza uwezekano na athari za uvunjaji wa usalama.

# Vidhibiti vya Usalama vya MCP

Kifaa chochote kinachopata rasilimali muhimu kina changamoto za kiusalama zinazojitokeza. Changamoto hizi kwa ujumla zinaweza kushughulikiwa kwa kutumia vidhibiti na dhana za msingi za usalama kwa usahihi. Kwa kuwa MCP ni protocol mpya tu, vipimo vyake vinabadilika kwa kasi na kadri protocol inavyoendelea, vidhibiti vya usalama ndani yake vitaendelea kukomaa, kuruhusu muunganisho bora na usanifu wa usalama wa kampuni na mbinu bora zilizopo.

Utafiti uliochapishwa katika [Microsoft Digital Defense Report](https://aka.ms/mddr) unaonyesha kuwa asilimia 98 ya uvunjaji uliripotiwa ungezuia kwa kutumia usafi mzuri wa usalama na kinga bora dhidi ya aina yoyote ya uvunjaji ni kupata usafi wako wa msingi wa usalama, mbinu bora za uandishi salama wa msimbo, na usalama wa mnyororo wa usambazaji kwa usahihi—mbinu hizi zilizojaribiwa na kuthibitishwa bado zina athari kubwa katika kupunguza hatari za usalama.

Tuchunguze baadhi ya njia unazoweza kuanza kuzitatua hatari za usalama wakati wa kupitisha MCP.

# Uthibitishaji wa seva ya MCP (ikiwa utekelezaji wako wa MCP ulikuwa kabla ya 26 Aprili 2025)

> **Note:** Taarifa zifuatazo ni sahihi hadi 26 Aprili 2025. Protocol ya MCP inaendelea kubadilika, na utekelezaji wa baadaye unaweza kuleta mifumo na vidhibiti vipya vya uthibitishaji. Kwa masasisho na mwongozo wa hivi karibuni, daima rejelea [MCP Specification](https://spec.modelcontextprotocol.io/) na [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Tatizo lililopo  
Vipimo vya awali vya MCP vilidhani kuwa watengenezaji wangeandika seva yao ya uthibitishaji. Hii ilihitaji ujuzi wa OAuth na vizingiti vingine vya usalama vinavyohusiana. Seva za MCP zilifanya kazi kama Seva za Uthibitishaji za OAuth 2.0, zikisimamia uthibitishaji wa mtumiaji moja kwa moja badala ya kuurusha kwa huduma ya nje kama Microsoft Entra ID. Kuanzia 26 Aprili 2025, sasisho la vipimo vya MCP limeruhusu seva za MCP kuwaruhusu uthibitishaji wa watumiaji kufanywa na huduma ya nje.

### Hatari
- Mantiki ya ruhusa isiyosanidiwa vizuri katika seva ya MCP inaweza kusababisha kufichuliwa kwa data nyeti na matumizi mabaya ya vidhibiti vya upatikanaji.
- Utekaji tokeni za OAuth kwenye seva ya MCP ya ndani. Ikiwa zitateketezwa, tokeni inaweza kutumiwa kuigiza seva ya MCP na kupata rasilimali na data kutoka kwa huduma inayotumia tokeni hiyo.

### Vidhibiti vya kupunguza hatari
- **Kagua na Imarisha Mantiki ya Ruhusa:** Fanya ukaguzi wa kina wa utekelezaji wa ruhusa wa seva yako ya MCP kuhakikisha watumiaji na wateja waliokusudiwa tu ndio wanaweza kupata rasilimali nyeti. Kwa mwongozo wa vitendo, angalia [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) na [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tekeleza Mbinu Salama za Tokeni:** Fuata [mbinu bora za Microsoft za uhakiki wa tokeni na muda wake](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) ili kuzuia matumizi mabaya ya tokeni za upatikanaji na kupunguza hatari ya kuigwa au kuibiwa tokeni.
- **Linda Uhifadhi wa Tokeni:** Hifadhi tokeni kwa usalama kila wakati na tumia usimbaji fiche kuwalinda wakati wa kuhifadhi na kusafirisha. Kwa vidokezo vya utekelezaji, angalia [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Ruhusa kupita kiasi kwa seva za MCP

### Tatizo lililopo  
Seva za MCP zinaweza kuwa zimepewa ruhusa kupita kiasi kwa huduma/rasilimali wanayofikia. Kwa mfano, seva ya MCP inayohusiana na programu ya mauzo ya AI inayounganisha na hifadhi ya data ya kampuni inapaswa kupata ruhusa zinazolenga tu data ya mauzo na isiruhusiwe kufikia faili zote katika hifadhi hiyo. Kumbuka kanuni ya upunguzaji wa ruhusa (prinsipali ya least privilege), hakuna rasilimali inayopaswa kuwa na ruhusa zaidi ya inavyohitajika kutekeleza kazi zake. AI inaleta changamoto zaidi hapa kwa sababu ili iwe na ufanisi, inaweza kuwa vigumu kufafanua kwa usahihi ruhusa zinazohitajika.

### Hatari  
- Kutoa ruhusa kupita kiasi kunaweza kuruhusu uvujaji au mabadiliko ya data ambayo seva ya MCP haikukusudiwa kufikia. Hii pia inaweza kuwa tatizo la faragha ikiwa data ni taarifa za mtu binafsi (PII).

### Vidhibiti vya kupunguza hatari
- **Tumia Kanuni ya Upunguzaji wa Ruhusa:** Toa ruhusa kwa seva ya MCP kwa kiwango cha chini kinachohitajika tu kwa kutekeleza kazi zake. Pitia na sasisha ruhusa hizi mara kwa mara kuhakikisha hazizidi mahitaji. Kwa mwongozo wa kina, angalia [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Tumia Udhibiti wa Upatikanaji Kwa Kazi (RBAC):** Weka majukumu kwa seva ya MCP yaliyo na mipaka thabiti kwa rasilimali na vitendo maalum, epuka ruhusa pana au zisizohitajika.
- **Fuatilia na Fanya Ukaguzi wa Ruhusa:** Endelea kufuatilia matumizi ya ruhusa na fanya ukaguzi wa rekodi za upatikanaji kugundua na kurekebisha ruhusa kupita kiasi au zisizotumika haraka iwezekanavyo.

# Mashambulizi ya sindano ya maelekezo isiyo ya moja kwa moja

### Tatizo lililopo

Seva za MCP zilizoibiwa au zilizoathiriwa zinaweza kuleta hatari kubwa kwa kufichua data za wateja au kuwezesha vitendo visivyotarajiwa. Hatari hizi ni muhimu hasa katika mzigo wa kazi wa AI na MCP, ambapo:

- **Mashambulizi ya Sindano ya Maelekezo:** Wadukuzi huingiza maagizo mabaya katika maelekezo au maudhui ya nje, na kusababisha mfumo wa AI kufanya vitendo visivyotarajiwa au kufichua data nyeti. Jifunze zaidi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Sumu ya Zana:** Wadukuzi hubadilisha metadata ya zana (kama maelezo au vigezo) kuathiri tabia ya AI, kwa njia ya kuepuka vidhibiti vya usalama au kuvujisha data. Maelezo zaidi: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Sindano ya Maelekezo ya Mikoa Mbalimbali:** Maagizo mabaya huingizwa katika nyaraka, kurasa za wavuti, au barua pepe, ambazo kisha huchakatwa na AI, na kusababisha uvujaji au udanganyifu wa data.
- **Mabadiliko ya Zana kwa Wakati Halisi (Rug Pulls):** Maelezo ya zana yanaweza kubadilishwa baada ya idhini ya mtumiaji, kuleta tabia mpya za uovu bila mtumiaji kujua.

Udhaifu huu unaonyesha umuhimu wa uthibitishaji thabiti, ufuatiliaji, na vidhibiti vya usalama wakati wa kuunganisha seva za MCP na zana katika mazingira yako. Kwa uchunguzi zaidi, angalia marejeleo yaliyoambatanishwa hapo juu.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sw.png)

**Sindano ya Maelekezo Isiyo ya Moja kwa Moja** (pia inajulikana kama sindano ya maelekezo ya mikoa mbalimbali au XPIA) ni udhaifu mkubwa katika mifumo ya AI inayozalisha, ikiwa ni pamoja na zile zinazotumia Model Context Protocol (MCP). Katika shambulio hili, maagizo mabaya yamefichwa ndani ya maudhui ya nje—kama vile nyaraka, kurasa za wavuti, au barua pepe. Wakati mfumo wa AI unachakata maudhui haya, unaweza kuyachukulia maagizo yaliyofichwa kama amri halali za mtumiaji, na kusababisha vitendo visivyotarajiwa kama uvujaji wa data, uzalishaji wa maudhui hatarishi, au udanganyifu wa mwingiliano wa mtumiaji. Kwa maelezo ya kina na mifano halisi, angalia [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Aina hatari zaidi ya shambulio hili ni **Sumu ya Zana**. Hapa, wadukuzi huingiza maagizo mabaya ndani ya metadata ya zana za MCP (kama maelezo ya zana au vigezo). Kwa kuwa mifano mikubwa ya lugha (LLMs) hutegemea metadata hii kuamua zana gani zitaitwa, maelezo yaliyoathiriwa yanaweza kudanganya mfano kutekeleza simu zisizoidhinishwa za zana au kuepuka vidhibiti vya usalama. Mabadiliko haya mara nyingi hayaonekani kwa watumiaji wa mwisho lakini yanaweza kufasiriwa na kutekelezwa na mfumo wa AI. Hatari hii huongezeka katika mazingira ya seva za MCP zilizoandaliwa, ambapo maelezo ya zana yanaweza kusasishwa baada ya idhini ya mtumiaji—hali inayojulikana kama "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Katika matukio kama haya, zana iliyokuwa salama awali inaweza kubadilishwa baadaye kufanya vitendo vya uovu, kama uvujaji wa data au kubadilisha tabia ya mfumo, bila taarifa kwa mtumiaji. Kwa habari zaidi kuhusu njia hii ya shambulio, angalia [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sw.png)

## Hatari  
Vitendo visivyotarajiwa vya AI vina hatari mbalimbali za usalama ikiwa ni pamoja na uvujaji wa data na ukiukaji wa faragha.

### Vidhibiti vya kupunguza hatari  
### Kutumia prompt shields kulinda dhidi ya mashambulizi ya sindano ya maelekezo isiyo ya moja kwa moja
-----------------------------------------------------------------------------

**AI Prompt Shields** ni suluhisho lililotengenezwa na Microsoft kulinda dhidi ya mashambulizi ya sindano ya maelekezo ya moja kwa moja na isiyo ya moja kwa moja. Husaidia kwa:

1.  **Ugunduzi na Ufuatiliaji:** Prompt Shields hutumia algorithms za hali ya juu za kujifunza mashine na usindikaji wa lugha asilia kugundua na kuchuja maagizo mabaya yaliyofichwa katika maudhui ya nje, kama vile nyaraka, kurasa za wavuti, au barua pepe.
    
2.  **Spotlighting:** Mbinu hii husaidia mfumo wa AI kutofautisha kati ya maagizo halali ya mfumo na maingizo ya nje ambayo yanaweza kuwa hatari. Kwa kubadilisha maandishi ya ingizo kwa njia inayofanya yafae zaidi kwa mfano, Spotlighting inahakikisha AI inaweza kutambua na kupuuza maagizo mabaya.
    
3.  **Delimiters na Datamarking:** Kuweka delimiters katika ujumbe wa mfumo kunafafanua kwa uwazi sehemu ya maandishi ya ingizo, kusaidia mfumo wa AI kutambua na kutenganisha maingizo ya mtumiaji na maudhui ya nje yanayoweza kuwa hatari. Datamarking inaongeza dhana hii kwa kutumia alama maalum kuonyesha mipaka ya data yenye kuaminika na isiyoaminika.
    
4.  **Ufuatiliaji Endelevu na Sasisho:** Microsoft inaendelea kufuatilia na kusasisha Prompt Shields kukabiliana na vitisho vipya vinavyoibuka. Mbinu hii ya kuzuia mapema inahakikisha kinga zinaendelea kuwa madhubuti dhidi ya mbinu mpya za mashambulizi.
    
5. **Muunganisho na Azure Content Safety:** Prompt Shields ni sehemu ya suite pana ya Azure AI Content Safety, inayotoa zana za ziada za kugundua jaribio la kuingia kwa nguvu (jailbreak), maudhui hatarishi, na hatari nyingine za usalama katika programu za AI.

Unaweza kusoma zaidi kuhusu AI prompt shields katika [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sw.png)

### Usalama wa mnyororo wa usambazaji

Usalama wa mnyororo wa usambazaji bado ni msingi katika enzi ya AI, lakini wigo wa kile kinachojumuishwa katika mnyororo wako wa usambazaji umeongezeka. Mbali na vifurushi vya msimbo vya jadi, sasa lazima uhakikishe na kufuatilia kwa ukamilifu vipengele vyote vinavyohusiana na AI, ikiwa ni pamoja na mifano ya msingi, huduma za embeddings, watoa muktadha, na API za watu wengine. Kila kimoja kinaweza kuleta udhaifu au hatari ikiwa hakishughulikiwa ipasavyo.

**Mbinu muhimu za usalama wa mnyororo wa usambazaji kwa AI na MCP:**
- **Thibitisha vipengele vyote kabla ya kuingiza:** Hii inajumuisha sio tu maktaba za chanzo huria, bali pia mifano ya AI, vyanzo vya data, na API za nje. Daima angalia asili, leseni, na udhaifu unaojulikana.
- **Dumisha mizunguko salama ya usambazaji:** Tumia mizunguko ya CI/CD yenye usalama iliyojumuishwa ili kugundua matatizo mapema. Hakikisha kuwa vipengele vilivyoaminika tu vinawekwa kwenye uzalishaji.
- **Fuatilia na fanya ukaguzi endelevu:** Tekeleza ufuatiliaji endelevu wa utegemezi wote, ikiwa ni pamoja na mifano na huduma za data, kugundua udhaifu mpya au mashambulizi ya mnyororo wa usambazaji.
- **Tumia upunguzaji wa ruhusa na vidhibiti vya upatikanaji:** Zuia upatikanaji kwa
- [OWASP Top 10 kwa LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Safari ya Kuhakikisha Usalama wa Mnyororo wa Ugavi wa Programu Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Tumia Upatikanaji wa Kidogo Kinachohitajika (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Mbinu Bora za Kuhakikisha na Kudhibiti Muda wa Tokeni](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Tumia Hifadhi Salama ya Tokeni na Ficha Tokeni (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management kama Lango la Uthibitishaji kwa MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Kutumia Microsoft Entra ID Kuhakikisha na MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Ifuatayo

Ifuatayo: [Sura ya 3: Kuanzia](/03-GettingStarted/README.md)

**Kang’amuzi**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za moja kwa moja zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya mama inapaswa kuzingatiwa kama chanzo halali. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebeki dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.