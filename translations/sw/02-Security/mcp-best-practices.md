<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b2b9e15e78b9d9a2b3ff3e8fd7d1f434",
  "translation_date": "2025-08-18T19:02:06+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "sw"
}
-->
# MCP Mbinu Bora za Usalama 2025

Mwongozo huu wa kina unatoa mbinu bora za usalama muhimu kwa kutekeleza mifumo ya Model Context Protocol (MCP) kulingana na **MCP Specification 2025-06-18** ya hivi karibuni na viwango vya sasa vya sekta. Mbinu hizi zinashughulikia masuala ya usalama wa jadi pamoja na vitisho maalum vya AI vinavyohusiana na matumizi ya MCP.

## Mahitaji Muhimu ya Usalama

### Udhibiti wa Usalama wa Lazima (Mahitaji ya MUST)

1. **Uthibitishaji wa Tokeni**: Seva za MCP **HAZIRUHUSIWI** kukubali tokeni zozote ambazo hazijatolewa mahsusi kwa seva ya MCP yenyewe.
2. **Uhakiki wa Uidhinishaji**: Seva za MCP zinazotekeleza uidhinishaji **LAZIMA** zihakiki maombi yote yanayoingia na **HAZIRUHUSIWI** kutumia vikao kwa uthibitishaji.
3. **Idhini ya Mtumiaji**: Seva za wakala wa MCP zinazotumia vitambulisho vya wateja vya static **LAZIMA** zipate idhini ya wazi ya mtumiaji kwa kila mteja aliyesajiliwa kwa njia ya nguvu.
4. **Vitambulisho Salama vya Vikao**: Seva za MCP **LAZIMA** zitumie vitambulisho vya vikao visivyotabirika vilivyotengenezwa kwa jenereta za namba za nasibu salama.

## Mbinu za Msingi za Usalama

### 1. Uthibitishaji wa Ingizo na Usafi
- **Uthibitishaji wa Kina wa Ingizo**: Thibitisha na safisha maingizo yote ili kuzuia mashambulizi ya sindikizo, matatizo ya naibu aliyepotoshwa, na udhaifu wa sindikizo la maelekezo.
- **Utekelezaji wa Schema ya Parameta**: Tekeleza uthibitishaji mkali wa schema ya JSON kwa vigezo vyote vya zana na maingizo ya API.
- **Kuchuja Maudhui**: Tumia Microsoft Prompt Shields na Azure Content Safety kuchuja maudhui hatari katika maelekezo na majibu.
- **Usafi wa Matokeo**: Thibitisha na safisha matokeo yote ya modeli kabla ya kuyawasilisha kwa watumiaji au mifumo inayofuata.

### 2. Ubora wa Uthibitishaji na Uidhinishaji  
- **Watoa Utambulisho wa Nje**: Peana uthibitishaji kwa watoa utambulisho waliothibitishwa (Microsoft Entra ID, watoa OAuth 2.1) badala ya kutekeleza uthibitishaji wa kawaida.
- **Ruhusa za Kina**: Tekeleza ruhusa za kina, maalum kwa zana, kufuatia kanuni ya upendeleo wa chini kabisa.
- **Usimamizi wa Mzunguko wa Tokeni**: Tumia tokeni za ufikiaji za muda mfupi na mzunguko salama pamoja na uthibitishaji sahihi wa hadhira.
- **Uthibitishaji wa Vipengele Vingi**: Hitaji MFA kwa ufikiaji wote wa kiutawala na operesheni nyeti.

### 3. Itifaki Salama za Mawasiliano
- **Usalama wa Safu ya Usafiri**: Tumia HTTPS/TLS 1.3 kwa mawasiliano yote ya MCP na uthibitishaji sahihi wa cheti.
- **Usimbaji wa Mwisho hadi Mwisho**: Tekeleza tabaka za ziada za usimbaji kwa data nyeti sana inayosafirishwa na iliyohifadhiwa.
- **Usimamizi wa Vyeti**: Dhibiti mzunguko sahihi wa vyeti na michakato ya upya otomatiki.
- **Utekelezaji wa Toleo la Itifaki**: Tumia toleo la sasa la itifaki ya MCP (2025-06-18) na mazungumzo sahihi ya toleo.

### 4. Kiwango cha Juu cha Kuzuia Kiwango na Ulinzi wa Rasilimali
- **Kuzuia Kiwango cha Tabaka Nyingi**: Tekeleza kuzuia kiwango kwa mtumiaji, kikao, zana, na viwango vya rasilimali ili kuzuia matumizi mabaya.
- **Kuzuia Kiwango Kinachobadilika**: Tumia kuzuia kiwango kinachotegemea ujifunzaji wa mashine kinachobadilika kulingana na mifumo ya matumizi na viashiria vya vitisho.
- **Usimamizi wa Kiwango cha Rasilimali**: Weka mipaka inayofaa kwa rasilimali za kompyuta, matumizi ya kumbukumbu, na muda wa utekelezaji.
- **Ulinzi wa DDoS**: Tekeleza ulinzi wa kina wa DDoS na mifumo ya uchambuzi wa trafiki.

### 5. Ufuatiliaji na Uwekaji Kumbukumbu wa Kina
- **Uwekaji Kumbukumbu wa Ukaguzi Ulio na Muundo**: Tekeleza kumbukumbu za kina, zinazoweza kutafutwa kwa operesheni zote za MCP, utekelezaji wa zana, na matukio ya usalama.
- **Ufuatiliaji wa Usalama wa Wakati Halisi**: Tekeleza mifumo ya SIEM yenye uwezo wa kugundua hali isiyo ya kawaida kwa mzigo wa kazi wa MCP.
- **Uwekaji Kumbukumbu Unaoheshimu Faragha**: Weka kumbukumbu za matukio ya usalama huku ukiheshimu mahitaji ya faragha ya data na kanuni.
- **Ujumuishaji wa Majibu ya Matukio**: Unganisha mifumo ya uwekaji kumbukumbu na michakato ya majibu ya matukio otomatiki.

### 6. Mbinu Bora za Hifadhi Salama
- **Moduli za Usalama wa Vifaa**: Tumia hifadhi ya funguo inayoungwa mkono na HSM (Azure Key Vault, AWS CloudHSM) kwa operesheni muhimu za usimbaji.
- **Usimamizi wa Funguo za Usimbaji**: Tekeleza mzunguko sahihi wa funguo, mgawanyo, na udhibiti wa ufikiaji kwa funguo za usimbaji.
- **Usimamizi wa Siri**: Hifadhi funguo zote za API, tokeni, na hati za siri katika mifumo maalum ya usimamizi wa siri.
- **Uainishaji wa Data**: Ainisha data kulingana na viwango vya usikivu na tekeleza hatua zinazofaa za ulinzi.

### 7. Usimamizi wa Tokeni wa Juu
- **Kuzuia Uhamishaji wa Tokeni**: Kataza waziwazi mifumo ya uhamishaji wa tokeni inayopitia udhibiti wa usalama.
- **Uthibitishaji wa Hadhira**: Hakikisha madai ya hadhira ya tokeni yanalingana na utambulisho wa seva ya MCP inayokusudiwa.
- **Uidhinishaji Unaotegemea Madai**: Tekeleza uidhinishaji wa kina kulingana na madai ya tokeni na sifa za mtumiaji.
- **Ufungaji wa Tokeni**: Funga tokeni kwa vikao, watumiaji, au vifaa maalum inapofaa.

### 8. Usimamizi Salama wa Vikao
- **Vitambulisho vya Vikao vya Kificho**: Tengeneza vitambulisho vya vikao kwa kutumia jenereta za namba za nasibu salama (si mfuatano unaotabirika).
- **Ufungaji Maalum wa Mtumiaji**: Funga vitambulisho vya vikao kwa taarifa maalum za mtumiaji kwa kutumia fomati salama kama `<user_id>:<session_id>`.
- **Udhibiti wa Mzunguko wa Vikao**: Tekeleza muda wa vikao, mzunguko, na mifumo ya kubatilisha vikao.
- **Vichwa vya Usalama vya Vikao**: Tumia vichwa sahihi vya HTTP kwa ulinzi wa vikao.

### 9. Udhibiti Maalum wa Usalama wa AI
- **Ulinzi Dhidi ya Sindikizo la Maelekezo**: Tekeleza Microsoft Prompt Shields na mbinu za kuangazia, vizuizi, na alama za data.
- **Kuzuia Uchafuzi wa Zana**: Thibitisha metadata ya zana, fuatilia mabadiliko ya nguvu, na hakiki uadilifu wa zana.
- **Uthibitishaji wa Matokeo ya Modeli**: Chunguza matokeo ya modeli kwa uwezekano wa uvujaji wa data, maudhui hatari, au ukiukaji wa sera za usalama.
- **Ulinzi wa Dirisha la Muktadha**: Tekeleza udhibiti wa kuzuia uchafuzi wa dirisha la muktadha na mashambulizi ya udanganyifu.

### 10. Usalama wa Utekelezaji wa Zana
- **Uwekaji Sanduku wa Utekelezaji**: Endesha utekelezaji wa zana katika mazingira yaliyotengwa, yaliyowekwa kwenye kontena, yenye mipaka ya rasilimali.
- **Mgawanyo wa Upendeleo**: Tekeleza zana kwa upendeleo mdogo unaohitajika na akaunti za huduma zilizotengwa.
- **Kutengwa kwa Mtandao**: Tekeleza mgawanyo wa mtandao kwa mazingira ya utekelezaji wa zana.
- **Ufuatiliaji wa Utekelezaji**: Fuatilia utekelezaji wa zana kwa tabia isiyo ya kawaida, matumizi ya rasilimali, na ukiukaji wa usalama.

### 11. Uthibitishaji wa Usalama Endelevu
- **Upimaji wa Usalama Otomatiki**: Jumuisha upimaji wa usalama katika mabomba ya CI/CD kwa kutumia zana kama GitHub Advanced Security.
- **Usimamizi wa Udhaifu**: Kagua mara kwa mara utegemezi wote, ikiwa ni pamoja na modeli za AI na huduma za nje.
- **Upimaji wa Kupenya**: Fanya tathmini za usalama mara kwa mara zinazolenga utekelezaji wa MCP.
- **Mapitio ya Kanuni za Usalama**: Tekeleza mapitio ya lazima ya usalama kwa mabadiliko yote ya kanuni zinazohusiana na MCP.

### 12. Usalama wa Mnyororo wa Ugavi kwa AI
- **Uthibitishaji wa Vipengele**: Thibitisha asili, uadilifu, na usalama wa vipengele vyote vya AI (modeli, embeddings, APIs).
- **Usimamizi wa Utegemezi**: Dhibiti orodha za sasa za utegemezi wote wa programu na AI pamoja na ufuatiliaji wa udhaifu.
- **Hifadhi Zinazoaminika**: Tumia vyanzo vilivyothibitishwa, vinavyoaminika kwa modeli zote za AI, maktaba, na zana.
- **Ufuatiliaji wa Mnyororo wa Ugavi**: Fuatilia mara kwa mara kwa maelewano katika watoa huduma wa AI na hifadhi za modeli.

## Mifumo ya Juu ya Usalama

### Usanifu wa Zero Trust kwa MCP
- **Usiamini Kamwe, Thibitisha Kila Wakati**: Tekeleza uthibitishaji endelevu kwa washiriki wote wa MCP.
- **Mgawanyo wa Micro**: Tenga vipengele vya MCP kwa udhibiti wa mtandao na utambulisho wa kina.
- **Ufikiaji wa Masharti**: Tekeleza udhibiti wa ufikiaji unaotegemea hatari unaobadilika kulingana na muktadha na tabia.
- **Tathmini Endelevu ya Hatari**: Pima hali ya usalama kwa nguvu kulingana na viashiria vya vitisho vya sasa.

### Utekelezaji wa AI Unaohifadhi Faragha
- **Kupunguza Data**: Onyesha data ya lazima tu kwa kila operesheni ya MCP.
- **Faragha ya Tofauti**: Tekeleza mbinu za kuhifadhi faragha kwa usindikaji wa data nyeti.
- **Usimbaji wa Homomorphic**: Tumia mbinu za usimbaji wa hali ya juu kwa hesabu salama kwenye data iliyosimbwa.
- **Mafunzo ya Kifederali**: Tekeleza mbinu za mafunzo ya kusambazwa zinazohifadhi eneo la data na faragha.

### Majibu ya Matukio kwa Mifumo ya AI
- **Taratibu Maalum za Matukio ya AI**: Tengeneza taratibu za majibu ya matukio zinazolengwa kwa vitisho maalum vya AI na MCP.
- **Majibu Otomatiki**: Tekeleza udhibiti na urejeshaji otomatiki kwa matukio ya kawaida ya usalama wa AI.
- **Uwezo wa Uchunguzi**: Dhibiti utayari wa uchunguzi kwa maelewano ya mfumo wa AI na uvujaji wa data.
- **Taratibu za Urejeshaji**: Weka taratibu za kurejesha kutoka kwa uchafuzi wa modeli za AI, mashambulizi ya sindikizo la maelekezo, na maelewano ya huduma.

## Rasilimali za Utekelezaji na Viwango

### Nyaraka Rasmi za MCP
- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) - Maelezo ya sasa ya itifaki ya MCP
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) - Mwongozo rasmi wa usalama
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization) - Mifumo ya uthibitishaji na uidhinishaji
- [MCP Transport Security](https://modelcontextprotocol.io/specification/2025-06-18/transports/) - Mahitaji ya usalama wa safu ya usafiri

### Suluhisho za Usalama za Microsoft
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) - Ulinzi wa hali ya juu dhidi ya sindikizo la maelekezo
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/) - Kuchuja maudhui ya AI kwa kina
- [Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow) - Usimamizi wa utambulisho wa biashara na ufikiaji
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/basic-concepts) - Usimamizi salama wa siri na hati za siri
- [GitHub Advanced Security](https://github.com/security/advanced-security) - Ufuatiliaji wa usalama wa mnyororo wa ugavi na kanuni

### Viwango vya Usalama na Mifumo
- [OAuth 2.1 Security Best Practices](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-security-topics) - Mwongozo wa sasa wa usalama wa OAuth
- [OWASP Top 10](https://owasp.org/www-project-top-ten/) - Hatari za usalama wa programu za wavuti
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559) - Hatari maalum za usalama wa AI
- [NIST AI Risk Management Framework](https://www.nist.gov/itl/ai-risk-management-framework) - Usimamizi wa hatari wa AI kwa kina
- [ISO 27001:2022](https://www.iso.org/standard/27001) - Mifumo ya usimamizi wa usalama wa taarifa

### Miongozo ya Utekelezaji na Mafunzo
- [Azure API Management as MCP Auth Gateway](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) - Mifumo ya uthibitishaji wa biashara
- [Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/) - Ujumuishaji wa mtoa utambulisho
- [Secure Token Storage Implementation](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) - Mbinu bora za usimamizi wa tokeni
- [End-to-End Encryption for AI](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption) - Mifumo ya hali ya juu ya usimbaji

### Rasilimali za Usalama wa Juu
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl) - Mbinu za maendeleo salama
- [AI Red Team Guidance](https://learn.microsoft.com/security/ai-red-team/) - Upimaji wa usalama maalum wa AI
- [Threat Modeling for AI Systems](https://learn.microsoft.com/security/adoption/approach/threats-ai) - Mbinu za uundaji wa vitisho vya AI
- [Privacy Engineering for AI](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/) - Mbinu za kuhifadhi faragha kwa AI

### Uzingatiaji na Utawala
- [GDPR Compliance for AI](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments) - Uzingatiaji wa faragha katika mifumo ya AI
- [AI Governance Framework](https://learn.microsoft.com/azure/architecture/guide/responsible-ai/responsible-ai-overview) - Utekelezaji wa AI unaowajibika
- [SOC 2 for AI Services](https://learn.microsoft.com/compliance/regulatory/offering-soc) - Udhibiti wa usalama kwa watoa huduma wa AI
- [HIPAA Compliance for AI](https://learn.microsoft.com/compliance/regulatory/offering-hipaa-hitech) - Mahitaji ya uzingatiaji wa AI katika huduma za afya

### DevSecOps na Uendeshaji Otomatiki
-
- **Uundaji wa Zana**: Tengeneza na shiriki zana za usalama na maktaba kwa mfumo wa ikolojia wa MCP

---

*Hati hii inaonyesha mbinu bora za usalama za MCP kufikia Agosti 18, 2025, kulingana na Maelezo ya MCP 2025-06-18. Mbinu za usalama zinapaswa kupitiwa na kusasishwa mara kwa mara kadri itifaki na mazingira ya vitisho yanavyobadilika.*

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kutumia huduma ya tafsiri ya kitaalamu ya binadamu. Hatutawajibika kwa maelewano mabaya au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.