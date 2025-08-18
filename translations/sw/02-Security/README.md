<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T14:04:20+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sw"
}
-->
# Usalama wa MCP: Ulinzi Kamili kwa Mifumo ya AI

[![MCP Security Best Practices](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.sw.png)](https://youtu.be/88No8pw706o)

_(Bofya picha hapo juu kutazama video ya somo hili)_

Usalama ni msingi wa muundo wa mifumo ya AI, ndiyo sababu tunaupa kipaumbele kama sehemu yetu ya pili. Hii inalingana na kanuni ya Microsoft ya **Secure by Design** kutoka [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/).

Model Context Protocol (MCP) inaleta uwezo mpya wenye nguvu kwa programu zinazoendeshwa na AI huku ikianzisha changamoto za kipekee za usalama zinazozidi hatari za programu za jadi. Mifumo ya MCP inakabiliwa na masuala ya usalama yaliyopo (kama usimbaji salama, upatikanaji wa chini kabisa, usalama wa mnyororo wa ugavi) pamoja na vitisho vipya vinavyohusiana na AI kama sindano ya maelekezo, uchafuzi wa zana, utekaji wa vikao, mashambulizi ya naibu aliyedanganywa, udhaifu wa kupitisha tokeni, na mabadiliko ya uwezo wa wakati halisi.

Somo hili linachunguza hatari muhimu zaidi za usalama katika utekelezaji wa MCP—likijumuisha uthibitishaji, ruhusa, ruhusa kupita kiasi, sindano ya maelekezo isiyo ya moja kwa moja, usalama wa vikao, matatizo ya naibu aliyedanganywa, usimamizi wa tokeni, na udhaifu wa mnyororo wa ugavi. Utajifunza udhibiti wa vitendo na mbinu bora za kupunguza hatari hizi huku ukitumia suluhisho za Microsoft kama Prompt Shields, Azure Content Safety, na GitHub Advanced Security kuimarisha utekelezaji wa MCP.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- **Kutambua Vitisho Maalum vya MCP**: Kutambua hatari za kipekee za usalama katika mifumo ya MCP ikiwa ni pamoja na sindano ya maelekezo, uchafuzi wa zana, ruhusa kupita kiasi, utekaji wa vikao, matatizo ya naibu aliyedanganywa, udhaifu wa kupitisha tokeni, na hatari za mnyororo wa ugavi
- **Kutumia Udhibiti wa Usalama**: Kutekeleza hatua madhubuti ikiwa ni pamoja na uthibitishaji thabiti, upatikanaji wa chini kabisa, usimamizi salama wa tokeni, udhibiti wa usalama wa vikao, na uhakiki wa mnyororo wa ugavi
- **Kutumia Suluhisho za Usalama za Microsoft**: Kuelewa na kutumia Microsoft Prompt Shields, Azure Content Safety, na GitHub Advanced Security kwa ulinzi wa mzigo wa kazi wa MCP
- **Kuthibitisha Usalama wa Zana**: Kutambua umuhimu wa uthibitishaji wa metadata ya zana, ufuatiliaji wa mabadiliko ya wakati halisi, na kujilinda dhidi ya mashambulizi ya sindano ya maelekezo isiyo ya moja kwa moja
- **Kuunganisha Mbinu Bora**: Kuchanganya misingi ya usalama iliyowekwa (usimbaji salama, kuimarisha seva, uaminifu wa sifuri) na udhibiti maalum wa MCP kwa ulinzi kamili

# Usanifu wa Usalama wa MCP na Udhibiti

Utekelezaji wa kisasa wa MCP unahitaji mbinu za usalama za tabaka zinazoshughulikia usalama wa programu za jadi na vitisho maalum vya AI. Maelezo ya MCP yanayoendelea kubadilika yanaendelea kuboresha udhibiti wake wa usalama, kuwezesha ujumuishaji bora na usanifu wa usalama wa biashara na mbinu bora zilizowekwa.

Utafiti kutoka [Microsoft Digital Defense Report](https://aka.ms/mddr) unaonyesha kuwa **98% ya uvunjaji wa usalama ulioripotiwa ungeweza kuzuiwa na usafi wa usalama thabiti**. Mkakati bora wa ulinzi unachanganya mbinu za msingi za usalama na udhibiti maalum wa MCP—hatua za msingi za usalama zilizothibitishwa zinabaki kuwa zenye athari kubwa zaidi katika kupunguza hatari ya usalama kwa ujumla.

## Mandhari ya Sasa ya Usalama

> **Note:** Taarifa hii inaonyesha viwango vya usalama vya MCP hadi **Agosti 18, 2025**. Itifaki ya MCP inaendelea kubadilika haraka, na utekelezaji wa siku zijazo unaweza kuanzisha mifumo mipya ya uthibitishaji na udhibiti ulioboreshwa. Daima rejelea [MCP Specification](https://spec.modelcontextprotocol.io/), [MCP GitHub repository](https://github.com/modelcontextprotocol), na [nyaraka za mbinu bora za usalama](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) kwa mwongozo wa hivi karibuni.

### Mabadiliko ya Uthibitishaji wa MCP

Maelezo ya MCP yamebadilika sana katika mbinu yake ya uthibitishaji na ruhusa:

- **Mbinu ya Awali**: Maelezo ya awali yalihitaji watengenezaji kutekeleza seva za uthibitishaji maalum, huku seva za MCP zikifanya kazi kama Seva za Ruhusa za OAuth 2.0 zinazodhibiti uthibitishaji wa watumiaji moja kwa moja
- **Kiwango cha Sasa (2025-06-18)**: Maelezo yaliyosasishwa yanaruhusu seva za MCP kuhamishia uthibitishaji kwa watoa huduma wa kitambulisho wa nje (kama Microsoft Entra ID), kuboresha hali ya usalama na kupunguza ugumu wa utekelezaji
- **Usalama wa Tabaka la Usafiri**: Msaada ulioboreshwa kwa mifumo salama ya usafiri na mifumo sahihi ya uthibitishaji kwa miunganisho ya ndani (STDIO) na ya mbali (Streamable HTTP)

## Usalama wa Uthibitishaji na Ruhusa

### Changamoto za Sasa za Usalama

Utekelezaji wa kisasa wa MCP unakabiliwa na changamoto kadhaa za uthibitishaji na ruhusa:

### Hatari na Njia za Mashambulizi

- **Mantiki ya Ruhusa Iliyosanidi Vibaya**: Utekelezaji wa ruhusa usio sahihi katika seva za MCP unaweza kufichua data nyeti na kutumia vibaya udhibiti wa upatikanaji
- **Kompromasi ya Tokeni ya OAuth**: Wizi wa tokeni za seva za MCP za ndani unawawezesha washambuliaji kujifanya seva na kufikia huduma za mnyororo wa chini
- **Udhaifu wa Kupitisha Tokeni**: Ushughulikiaji usio sahihi wa tokeni unaunda njia za kupita udhibiti wa usalama na mapengo ya uwajibikaji
- **Ruhusa Kupita Kiasi**: Seva za MCP zenye ruhusa nyingi zinakiuka kanuni za upatikanaji wa chini kabisa na kupanua nyuso za mashambulizi

#### Kupitisha Tokeni: Muundo wa Hatari Muhimu

**Kupitisha tokeni kunakatazwa wazi** katika maelezo ya sasa ya ruhusa ya MCP kutokana na athari kubwa za usalama:

##### Upitishaji wa Udhibiti wa Usalama
- Seva za MCP na API za mnyororo wa chini zinatekeleza udhibiti muhimu wa usalama (kama kupunguza kasi, uthibitishaji wa maombi, ufuatiliaji wa trafiki) unaotegemea uthibitishaji sahihi wa tokeni
- Matumizi ya moja kwa moja ya tokeni za mteja kwa API hupita ulinzi muhimu, kudhoofisha usanifu wa usalama

##### Changamoto za Uwajibikaji na Ukaguzi  
- Seva za MCP haziwezi kutofautisha kati ya wateja wanaotumia tokeni zilizotolewa na mnyororo wa juu, kuvunja njia za ukaguzi
- Magogo ya seva za rasilimali za mnyororo wa chini yanaonyesha asili ya maombi isiyo sahihi badala ya wapatanishi halisi wa seva za MCP
- Uchunguzi wa matukio na ukaguzi wa kufuata unakuwa mgumu zaidi

##### Hatari za Uvujaji wa Data
- Madai ya tokeni yasiyothibitishwa yanawawezesha wahusika waovu wenye tokeni zilizoibiwa kutumia seva za MCP kama wakala wa uvujaji wa data
- Ukiukaji wa mipaka ya uaminifu huruhusu mifumo ya upatikanaji isiyoidhinishwa inayopita udhibiti wa usalama uliokusudiwa

##### Njia za Mashambulizi ya Huduma Nyingi
- Tokeni zilizokompromasi zinazokubaliwa na huduma nyingi huruhusu harakati za upande katika mifumo iliyounganishwa
- Dhana za uaminifu kati ya huduma zinaweza kuvunjwa wakati asili ya tokeni haiwezi kuthibitishwa

### Udhibiti wa Usalama na Hatua za Kupunguza

**Mahitaji Muhimu ya Usalama:**

> **LAZIMA**: Seva za MCP **HAZIRUHUSIWI** kukubali tokeni zozote ambazo hazikutolewa mahsusi kwa seva ya MCP

#### Udhibiti wa Uthibitishaji na Ruhusa

- **Ukaguzi Mkali wa Ruhusa**: Fanya ukaguzi wa kina wa mantiki ya ruhusa ya seva za MCP ili kuhakikisha watumiaji na wateja waliokusudiwa pekee wanaweza kufikia rasilimali nyeti
  - **Mwongozo wa Utekelezaji**: [Azure API Management kama Lango la Uthibitishaji kwa Seva za MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
  - **Ujumuishaji wa Kitambulisho**: [Kutumia Microsoft Entra ID kwa Uthibitishaji wa Seva za MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

- **Usimamizi Salama wa Tokeni**: Tekeleza [mbinu bora za uthibitishaji wa tokeni na mzunguko wa maisha za Microsoft](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)
  - Thibitisha madai ya tokeni ya hadhira yanalingana na kitambulisho cha seva ya MCP
  - Tekeleza sera sahihi za mzunguko na muda wa tokeni
  - Zuia mashambulizi ya kurudia tokeni na matumizi yasiyoidhinishwa

- **Hifadhi Salama ya Tokeni**: Hifadhi tokeni kwa usalama kwa usimbaji fiche wakati wa kupumzika na wakati wa usafiri
  - **Mbinu Bora**: [Mwongozo wa Usimbaji Fiche na Hifadhi Salama ya Tokeni](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

#### Utekelezaji wa Udhibiti wa Upatikanaji

- **Kanuni ya Upatikanaji wa Chini Kabisa**: Peana seva za MCP ruhusa ndogo tu zinazohitajika kwa utendaji uliokusudiwa
  - Ukaguzi wa ruhusa mara kwa mara na masasisho ili kuzuia kuongezeka kwa ruhusa
  - **Nyaraka za Microsoft**: [Upatikanaji Salama wa Chini Kabisa](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)

- **Udhibiti wa Upatikanaji wa Kulingana na Majukumu (RBAC)**: Tekeleza ugawaji wa majukumu ya kina
  - Majukumu ya upeo kwa rasilimali na vitendo maalum
  - Epuka ruhusa pana au zisizo za lazima zinazopanua nyuso za mashambulizi

- **Ufuatiliaji Endelevu wa Ruhusa**: Tekeleza ukaguzi wa upatikanaji na ufuatiliaji unaoendelea
  - Fuatilia mifumo ya matumizi ya ruhusa kwa hali isiyo ya kawaida
  - Rekebisha mara moja ruhusa kupita kiasi au zisizotumika

## Vitisho Maalum vya Usalama vya AI

### Mashambulizi ya Sindano ya Maelekezo na Udanganyifu wa Zana

Utekelezaji wa kisasa wa MCP unakabiliwa na njia za mashambulizi ya kisasa zinazohusiana na AI ambazo hatua za usalama za jadi haziwezi kushughulikia kikamilifu:

#### **Sindano ya Maelekezo Isiyo ya Moja kwa Moja (Sindano ya Maelekezo ya Nyanja Mbalimbali)**

**Sindano ya Maelekezo Isiyo ya Moja kwa Moja** inawakilisha mojawapo ya udhaifu muhimu zaidi katika mifumo ya AI inayowezeshwa na MCP. Washambuliaji huingiza maelekezo ya uovu ndani ya maudhui ya nje—nyaraka, kurasa za wavuti, barua pepe, au vyanzo vya data—ambavyo mifumo ya AI baadaye huchakata kama maagizo halali.

**Mazingira ya Mashambulizi:**
- **Sindano ya Nyaraka**: Maelekezo ya uovu yaliyofichwa katika nyaraka zinazochakatwa ambayo husababisha vitendo visivyokusudiwa vya AI
- **Unyonyaji wa Maudhui ya Wavuti**: Kurasa za wavuti zilizokompromasi zenye maelekezo yaliyopachikwa ambayo hudanganya tabia ya AI wakati wa kuchanganua
- **Mashambulizi ya Barua Pepe**: Maelekezo ya uovu katika barua pepe ambayo husababisha wasaidizi wa AI kutoa taarifa au kufanya vitendo visivyoidhinishwa
- **Uchafuzi wa Vyanzo vya Data**: Mifumo ya data au API zilizokompromasi zinazotoa maudhui yaliyochafuliwa kwa mifumo ya AI

**Athari Halisi**: Mashambulizi haya yanaweza kusababisha uvujaji wa data, ukiukaji wa faragha, uzalishaji wa maudhui hatari, na udanganyifu wa mwingiliano wa watumiaji. Kwa uchambuzi wa kina, angalia [Sindano ya Maelekezo katika MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

![Prompt Injection Attack Diagram](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sw.png)

#### **Mashambulizi ya Uchafuzi wa Zana**

**Uchafuzi wa Zana** unalenga metadata inayofafanua zana za MCP, ikitumia jinsi LLM zinavyotafsiri maelezo ya zana na vigezo kufanya maamuzi ya utekelezaji.

**Njia za Mashambulizi:**
- **Udanganyifu wa Metadata**: Washambuliaji huingiza maelekezo ya uovu katika maelezo ya zana, ufafanuzi wa vigezo, au mifano ya matumizi
- **Maelekezo Yasiyoonekana**: Maelekezo yaliyofichwa katika metadata ya zana ambayo huchakatwa na mifumo ya AI lakini hayaonekani kwa watumiaji wa binadamu
- **Mabadiliko ya Zana ya Wakati Halisi ("Rug Pulls")**: Zana zilizokubaliwa na watumiaji hubadilishwa baadaye kufanya vitendo vya uovu bila ufahamu wa mtumiaji
- **Sindano ya Vigezo**: Maudhui ya uovu yaliyopachikwa katika mifumo ya vigezo vya zana ambayo huathiri tabia ya modeli

**Hatari za Seva Zinazohifadhiwa**: Seva za MCP za mbali zinawasilisha hatari zilizoongezeka kwani ufafanuzi wa zana unaweza kusasishwa baada ya idhini ya awali ya mtumiaji, kuunda hali ambapo zana zilizokuwa salama awali zinakuwa za uovu. Kwa uchambuzi wa kina, angalia [Mashambulizi ya Uchafuzi wa Zana (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![Tool Injection Attack Diagram](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sw.png)

#### **Njia za Mashambulizi ya AI Ziada**

- **Sindano ya Maelekezo ya Nyanja Mbalimbali (XPIA)**: Mashambulizi ya kisasa yanayotumia maudhui kutoka nyanja nyingi kupita udhibiti wa usalama
- **Mabadiliko ya Uwezo wa Wakati Halisi**: Mabadiliko ya uwezo wa zana yanayofanyika wakati halisi ambayo yanapita tathmini za usalama za awali
- **Uchafuzi wa Dirisha la Muktadha**: Mashambulizi yanayodanganya madirisha makubwa ya muktadha kuficha maelekezo ya uovu
- **Mashambulizi ya Kuchanganya Modeli**: Kutumia mapungufu ya modeli kuunda tabia zisizotabirika au zisizo salama

### Athari za Hatari za Usalama wa AI

**Athari Zenye Madhara Makubwa:**
- **Uvujaji wa Data**: Upatikanaji usioidhinishwa na wizi wa data nyeti ya biashara au ya kibinafsi
- **Ukiukaji wa Faragha**: Ufunuo wa taarifa zinazotambulika binafsi (PII) na data ya siri ya biashara  
- **Udanganyifu wa Mfumo**: Mabadiliko yasiyokusudiwa kwa mifumo muhimu na mtiririko wa kazi
- **Wizi wa Kitambulisho**: Kompromasi ya tokeni za uthibitishaji na hati za huduma
- **Harakati za Upande**: Matumizi ya mifumo ya AI iliyokompromasi kama sehemu za kuanzia kwa mashambulizi makubwa ya mtandao

### Suluhisho za Usalama za Microsoft kwa AI

#### **AI Prompt Shields: Ulinzi wa Juu Dhidi ya Mashambulizi ya Sindano**

Microsoft **AI Prompt Shields** hutoa ulinzi kamili dhidi
- **Uundaji wa Vikao Salama**: Tumia vitambulisho vya vikao visivyotabirika vilivyotengenezwa kwa njia salama ya kriptografia kwa kutumia jenereta za namba za bahati nasibu salama  
- **Ufungaji wa Mtumiaji Maalum**: Funga vitambulisho vya vikao na taarifa maalum za mtumiaji kwa kutumia fomati kama `<user_id>:<session_id>` ili kuzuia matumizi mabaya ya vikao kati ya watumiaji  
- **Usimamizi wa Mzunguko wa Vikao**: Tekeleza muda wa kuisha, mzunguko, na kufutwa kwa vikao ipasavyo ili kupunguza madirisha ya udhaifu  
- **Usalama wa Usafirishaji**: Tumia HTTPS kwa lazima katika mawasiliano yote ili kuzuia kunaswa kwa vitambulisho vya vikao  

### Tatizo la Naibu Aliyechanganyikiwa  

**Tatizo la naibu aliyechanganyikiwa** hutokea pale ambapo seva za MCP zinapofanya kazi kama mawakala wa uthibitishaji kati ya wateja na huduma za wahusika wa tatu, na hivyo kuunda fursa za kupitisha mamlaka kupitia unyonyaji wa vitambulisho vya wateja vya static.  

#### **Mbinu za Shambulio na Hatari**  

- **Kupitisha Idhini kwa Kutumia Vidakuzi**: Uthibitishaji wa awali wa mtumiaji huunda vidakuzi vya idhini ambavyo washambuliaji hutumia kupitia maombi ya idhini yenye URL za kuelekeza zilizotengenezwa kwa hila  
- **Wizi wa Msimbo wa Idhini**: Vidakuzi vya idhini vilivyopo vinaweza kusababisha seva za idhini kuruka skrini za idhini, na kuelekeza misimbo kwa maeneo yanayodhibitiwa na washambuliaji  
- **Ufikiaji wa API Usioidhinishwa**: Misimbo ya idhini iliyoporwa inaruhusu kubadilishana tokeni na kuiga watumiaji bila idhini ya wazi  

#### **Mikakati ya Kuzuia**  

**Udhibiti wa Lazima:**  
- **Mahitaji ya Idhini ya Wazi**: Seva za wakala za MCP zinazotumia vitambulisho vya wateja vya static **LAZIMA** zipate idhini ya mtumiaji kwa kila mteja aliyesajiliwa kwa njia ya nguvu  
- **Utekelezaji wa Usalama wa OAuth 2.1**: Fuata mbinu bora za usalama za OAuth za sasa ikiwa ni pamoja na PKCE (Uthibitisho wa Ufunguo wa Kubadilisha Msimbo) kwa maombi yote ya idhini  
- **Uthibitishaji Mkali wa Wateja**: Tekeleza uthibitishaji madhubuti wa URL za kuelekeza na vitambulisho vya wateja ili kuzuia unyonyaji  

### Udhaifu wa Kupitisha Tokeni  

**Kupitisha tokeni** ni muundo mbaya ambapo seva za MCP zinakubali tokeni za wateja bila uthibitishaji sahihi na kuzisambaza kwa API za chini, kinyume na vipimo vya idhini vya MCP.  

#### **Athari za Kiusalama**  

- **Kupitisha Udhibiti**: Matumizi ya moja kwa moja ya tokeni za mteja kwa API hupuuza udhibiti muhimu wa kiwango, uthibitishaji, na ufuatiliaji  
- **Uharibifu wa Njia za Ukaguzi**: Tokeni zilizotolewa na seva za juu hufanya utambulisho wa mteja kuwa mgumu, na hivyo kuvuruga uwezo wa uchunguzi wa matukio  
- **Utoroshaji wa Data Kupitia Wakala**: Tokeni zisizothibitishwa huruhusu wahalifu kutumia seva kama mawakala wa kufikia data bila idhini  
- **Uvunjaji wa Mipaka ya Uaminifu**: Dhana za uaminifu za huduma za chini zinaweza kuvunjwa pale ambapo asili ya tokeni haiwezi kuthibitishwa  
- **Upanuzi wa Shambulio la Huduma Nyingi**: Tokeni zilizovurugwa zinazokubalika katika huduma nyingi huruhusu harakati za upande  

#### **Udhibiti wa Usalama Unaohitajika**  

**Mahitaji Yasiyoweza Kujadiliwa:**  
- **Uthibitishaji wa Tokeni**: Seva za MCP **HAZIRUHUSIWI** kukubali tokeni ambazo hazijatolewa mahsusi kwa seva ya MCP  
- **Uhakiki wa Watazamaji**: Kila mara hakikisha madai ya watazamaji wa tokeni yanalingana na utambulisho wa seva ya MCP  
- **Mzunguko Sahihi wa Tokeni**: Tekeleza tokeni za ufikiaji zenye muda mfupi na mbinu salama za mzunguko  

## Usalama wa Mnyororo wa Ugavi kwa Mifumo ya AI  

Usalama wa mnyororo wa ugavi umebadilika zaidi ya utegemezi wa programu za jadi na sasa unajumuisha mfumo mzima wa AI. Utekelezaji wa kisasa wa MCP lazima uthibitishe na kufuatilia kwa makini vipengele vyote vinavyohusiana na AI, kwani kila kimoja kinaweza kuanzisha udhaifu unaoweza kuhatarisha uadilifu wa mfumo.  

### Vipengele Vilivyopanuliwa vya Mnyororo wa Ugavi wa AI  

**Utegemezi wa Programu za Jadi:**  
- Maktaba na mifumo ya chanzo huria  
- Picha za kontena na mifumo ya msingi  
- Zana za maendeleo na njia za ujenzi  
- Vipengele vya miundombinu na huduma  

**Vipengele Maalum vya Mnyororo wa Ugavi wa AI:**  
- **Mifano ya Msingi**: Mifano iliyofunzwa awali kutoka kwa watoa huduma mbalimbali inayohitaji uthibitishaji wa asili  
- **Huduma za Kuweka Misingi**: Huduma za nje za vektorizi na utafutaji wa maana  
- **Watoa Muktadha**: Vyanzo vya data, hifadhidata za maarifa, na hazina za nyaraka  
- **API za Wahusika wa Tatu**: Huduma za nje za AI, njia za ML, na sehemu za usindikaji wa data  
- **Vifaa vya Mfano**: Uzito, usanidi, na aina za mifano zilizofunzwa upya  
- **Vyanzo vya Data vya Mafunzo**: Seti za data zinazotumika kwa mafunzo na urekebishaji wa mifano  

### Mkakati wa Kina wa Usalama wa Mnyororo wa Ugavi  

#### **Uthibitishaji wa Vipengele na Uaminifu**  
- **Uthibitishaji wa Asili**: Thibitisha asili, leseni, na uadilifu wa vipengele vyote vya AI kabla ya kuviunganisha  
- **Tathmini ya Usalama**: Fanya uchunguzi wa udhaifu na mapitio ya usalama kwa mifano, vyanzo vya data, na huduma za AI  
- **Uchambuzi wa Sifa**: Pima rekodi ya usalama na mazoea ya watoa huduma za AI  
- **Uthibitishaji wa Uzingatiaji**: Hakikisha vipengele vyote vinakidhi mahitaji ya usalama na kanuni za shirika  

#### **Njia Salama za Utekelezaji**  
- **Usalama wa Kiotomatiki wa CI/CD**: Jumuisha uchunguzi wa usalama katika njia za utekelezaji kiotomatiki  
- **Uadilifu wa Vifaa**: Tekeleza uthibitishaji wa kriptografia kwa vifaa vyote vilivyotumika (msimbo, mifano, usanidi)  
- **Utekelezaji wa Hatua kwa Hatua**: Tumia mikakati ya utekelezaji wa hatua kwa hatua na uthibitishaji wa usalama katika kila hatua  
- **Hifadhi za Vifaa Zenye Uaminifu**: Tumia tu vifaa kutoka kwenye hifadhi zilizothibitishwa na salama  

#### **Ufuatiliaji Endelevu na Majibu**  
- **Uchunguzi wa Utegemezi**: Ufuatiliaji wa udhaifu unaoendelea kwa utegemezi wote wa programu na vipengele vya AI  
- **Ufuatiliaji wa Mfano**: Tathmini endelevu ya tabia ya mifano, mwelekeo wa utendaji, na hali zisizo za kawaida za usalama  
- **Ufuatiliaji wa Afya ya Huduma**: Fuata hali ya huduma za nje za AI kwa upatikanaji, matukio ya usalama, na mabadiliko ya sera  
- **Ujumuishaji wa Ujasusi wa Vitisho**: Jumuisha vyanzo vya vitisho vinavyohusiana na usalama wa AI na ML  

#### **Udhibiti wa Ufikiaji na Upendeleo wa Chini Kabisa**  
- **Ruhusa za Kiwango cha Kipengele**: Punguza ufikiaji wa mifano, data, na huduma kulingana na mahitaji ya biashara  
- **Usimamizi wa Akaunti za Huduma**: Tekeleza akaunti za huduma maalum zenye ruhusa ndogo zinazohitajika  
- **Ugawaji wa Mtandao**: Tenganisha vipengele vya AI na punguza ufikiaji wa mtandao kati ya huduma  
- **Udhibiti wa Lango la API**: Tumia malango ya API yaliyosentralishwa kudhibiti na kufuatilia ufikiaji wa huduma za nje za AI  

#### **Majibu ya Matukio na Urejeshaji**  
- **Taratibu za Majibu ya Haraka**: Michakato iliyoanzishwa ya kurekebisha au kubadilisha vipengele vya AI vilivyohatarishwa  
- **Mzunguko wa Kitambulisho**: Mifumo ya kiotomatiki ya kubadilisha siri, funguo za API, na vitambulisho vya huduma  
- **Uwezo wa Kurejesha**: Uwezo wa kurudi haraka kwenye matoleo ya awali yaliyothibitishwa ya vipengele vya AI  
- **Urejeshaji wa Uvunjaji wa Mnyororo wa Ugavi**: Taratibu maalum za kujibu uvunjaji wa huduma za AI za juu  

...
### **Suluhisho za Usalama za Microsoft**
- [Microsoft Prompt Shields Documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Huduma ya Usalama wa Maudhui ya Azure](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Usalama wa Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Mbinu Bora za Usimamizi wa Tokeni za Azure](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [GitHub Advanced Security](https://github.com/security/advanced-security)

### **Miongozo ya Utekelezaji na Mafunzo**
- [Azure API Management kama Lango la Uthibitishaji wa MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Uthibitishaji wa Microsoft Entra ID na Seva za MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Uhifadhi Salama wa Tokeni na Usimbaji (Video)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### **Usalama wa DevOps na Mnyororo wa Ugavi**
- [Usalama wa Azure DevOps](https://azure.microsoft.com/products/devops)
- [Usalama wa Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Safari ya Usalama wa Mnyororo wa Ugavi wa Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)

## **Nyaraka za Ziada za Usalama**

Kwa mwongozo wa kina wa usalama, rejelea nyaraka maalum katika sehemu hii:

- **[MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md)** - Mbinu bora za usalama kamili kwa utekelezaji wa MCP  
- **[Azure Content Safety Implementation](./azure-content-safety-implementation.md)** - Mifano ya utekelezaji wa vitendo kwa ujumuishaji wa Usalama wa Maudhui ya Azure  
- **[MCP Security Controls 2025](./mcp-security-controls-2025.md)** - Udhibiti wa usalama wa hivi karibuni na mbinu za utekelezaji wa MCP  
- **[MCP Best Practices Quick Reference](./mcp-best-practices.md)** - Mwongozo wa haraka wa mbinu muhimu za usalama wa MCP  

---

## Kinachofuata

Kinachofuata: [Sura ya 3: Kuanza](../03-GettingStarted/README.md)

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya kutafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati asilia katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.