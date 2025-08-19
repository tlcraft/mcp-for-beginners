<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "057dd5cc6bea6434fdb788e6c93f3f3d",
<<<<<<< HEAD
  "translation_date": "2025-08-18T18:58:27+00:00",
=======
  "translation_date": "2025-08-18T14:01:54+00:00",
>>>>>>> origin/main
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "sw"
}
-->
<<<<<<< HEAD
# MCP Mbinu Bora za Usalama - Sasisho la Agosti 2025

> **Muhimu**: Hati hii inaonyesha mahitaji ya usalama ya hivi karibuni kulingana na [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) na [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices). Daima rejelea toleo la sasa la maelezo kwa mwongozo wa kisasa zaidi.

## Mbinu Muhimu za Usalama kwa Utekelezaji wa MCP

Model Context Protocol inaleta changamoto za kipekee za usalama zinazozidi zile za programu za kawaida. Mbinu hizi zinashughulikia mahitaji ya msingi ya usalama pamoja na vitisho maalum vya MCP kama vile sindano ya maelekezo, uchafuzi wa zana, utekaji wa vikao, matatizo ya naibu aliyedanganyika, na udhaifu wa kupitisha tokeni.

### **MAHITAJI YA LAZIMA YA USALAMA**

**Mahitaji Muhimu kutoka kwa MCP Specification:**

> **MUST NOT**: Seva za MCP **MUST NOT** kukubali tokeni zozote ambazo hazijatolewa mahsusi kwa seva ya MCP  
> 
> **MUST**: Seva za MCP zinazotekeleza idhini **MUST** kuthibitisha maombi yote yanayoingia  
>  
> **MUST NOT**: Seva za MCP **MUST NOT** kutumia vikao kwa uthibitishaji  
>
> **MUST**: Seva za wakala wa MCP zinazotumia vitambulisho vya wateja vya kudumu **MUST** kupata idhini ya mtumiaji kwa kila mteja aliyesajiliwa kwa njia ya nguvu  

---

## 1. **Usalama wa Tokeni na Uthibitishaji**

**Udhibiti wa Uthibitishaji na Idhini:**  
   - **Ukaguzi Mkali wa Idhini**: Fanya ukaguzi wa kina wa mantiki ya idhini ya seva ya MCP ili kuhakikisha kuwa ni watumiaji na wateja waliokusudiwa pekee wanaweza kufikia rasilimali  
   - **Ujumuishaji wa Mtoa Utambulisho wa Nje**: Tumia watoa utambulisho waliothibitishwa kama Microsoft Entra ID badala ya kutekeleza uthibitishaji wa kawaida  
   - **Uthibitishaji wa Hadhira ya Tokeni**: Daima hakikisha tokeni zilitolewa mahsusi kwa seva yako ya MCP - usikubali tokeni za juu  
   - **Mzunguko Sahihi wa Tokeni**: Tekeleza mzunguko salama wa tokeni, sera za kumalizika muda, na zuia mashambulizi ya kurudia tokeni  

**Uhifadhi Salama wa Tokeni:**  
   - Tumia Azure Key Vault au hifadhi salama za siri zinazofanana kwa siri zote  
   - Tekeleza usimbaji kwa tokeni wakati wa kupumzika na wakati wa kusafirishwa  
   - Mzunguko wa siri mara kwa mara na ufuatiliaji wa ufikiaji usioidhinishwa  

## 2. **Usimamizi wa Vikao na Usalama wa Usafirishaji**

**Mbinu Salama za Vikao:**  
   - **Vitambulisho vya Vikao vya Usimbaji Salama**: Tumia vitambulisho vya vikao visivyo na muundo vilivyotengenezwa kwa jenereta za nambari za nasibu salama  
   - **Ufungaji wa Kipekee wa Mtumiaji**: Funga vitambulisho vya vikao kwa utambulisho wa mtumiaji kwa kutumia fomati kama `<user_id>:<session_id>` ili kuzuia matumizi mabaya ya vikao vya watumiaji tofauti  
   - **Usimamizi wa Mzunguko wa Vikao**: Tekeleza kumalizika muda, mzunguko, na kubatilisha ipasavyo ili kupunguza madirisha ya udhaifu  
   - **Utekelezaji wa HTTPS/TLS**: HTTPS ya lazima kwa mawasiliano yote ili kuzuia utekaji wa vitambulisho vya vikao  

**Usalama wa Safu ya Usafirishaji:**  
   - Sanidi TLS 1.3 inapowezekana na usimamizi sahihi wa vyeti  
   - Tekeleza upigaji pini wa vyeti kwa miunganisho muhimu  
   - Mzunguko wa vyeti mara kwa mara na uthibitishaji wa uhalali  

## 3. **Ulinzi Dhidi ya Vitisho Maalum vya AI** 🤖

**Ulinzi Dhidi ya Sindano ya Maelekezo:**  
   - **Microsoft Prompt Shields**: Tumia AI Prompt Shields kwa utambuzi wa hali ya juu na uchujaji wa maelekezo mabaya  
   - **Usafi wa Ingizo**: Thibitisha na safisha maingizo yote ili kuzuia mashambulizi ya sindano na matatizo ya naibu aliyedanganyika  
   - **Mipaka ya Maudhui**: Tumia mifumo ya alama na mipaka ya data kutofautisha kati ya maelekezo yanayoaminika na maudhui ya nje  

**Kuzuia Uchafuzi wa Zana:**  
   - **Uthibitishaji wa Metadata ya Zana**: Tekeleza ukaguzi wa uadilifu kwa ufafanuzi wa zana na ufuatiliaji wa mabadiliko yasiyotarajiwa  
   - **Ufuatiliaji wa Zana za Kawaida**: Fuatilia tabia ya wakati wa kukimbia na sanidi arifa kwa mifumo ya utekelezaji isiyotarajiwa  
   - **Mifumo ya Idhini**: Hitaji idhini ya mtumiaji kwa mabadiliko ya zana na uwezo  

## 4. **Udhibiti wa Ufikiaji na Ruhusa**

**Kanuni ya Ruhusa ya Kiwango cha Chini:**  
   - Peana seva za MCP ruhusa za kiwango cha chini zinazohitajika kwa utendaji uliokusudiwa  
   - Tekeleza udhibiti wa ufikiaji kulingana na majukumu (RBAC) na ruhusa za kina  
   - Ukaguzi wa ruhusa mara kwa mara na ufuatiliaji endelevu wa kupanda kwa ruhusa  

**Udhibiti wa Ruhusa Wakati wa Kukimbia:**  
=======
# MCP Mazoea Bora ya Usalama - Sasisho la Agosti 2025

> **Muhimu**: Hati hii inaonyesha mahitaji ya usalama ya hivi karibuni ya [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) na [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices). Daima rejelea toleo la sasa la maelezo kwa mwongozo wa kisasa zaidi.

## Mazoea Muhimu ya Usalama kwa Utekelezaji wa MCP

Model Context Protocol inaleta changamoto za kipekee za usalama zinazozidi zile za programu za kawaida. Mazoea haya yanashughulikia mahitaji ya msingi ya usalama na vitisho maalum vya MCP kama vile sindikizo la maelekezo (prompt injection), uchafuzi wa zana, utekaji wa vikao, matatizo ya confused deputy, na udhaifu wa token passthrough.

### **Mahitaji ya Usalama YA LAZIMA**

**Mahitaji Muhimu kutoka kwa MCP Specification:**

> **MUST NOT**: MCP servers **MUST NOT** kukubali token yoyote ambayo haikutolewa mahsusi kwa MCP server  
> 
> **MUST**: MCP servers zinazotekeleza idhini **MUST** kuthibitisha maombi yote yanayoingia  
>  
> **MUST NOT**: MCP servers **MUST NOT** kutumia vikao kwa uthibitishaji  
>
> **MUST**: MCP proxy servers zinazotumia static client IDs **MUST** kupata ridhaa ya mtumiaji kwa kila mteja aliyesajiliwa kwa nguvu  

---

## 1. **Usalama wa Token & Uthibitishaji**

**Udhibiti wa Uthibitishaji na Idhini:**
   - **Ukaguzi Mkali wa Idhini**: Fanya ukaguzi wa kina wa mantiki ya idhini ya MCP server ili kuhakikisha kuwa ni watumiaji na wateja waliokusudiwa pekee wanaweza kufikia rasilimali  
   - **Ujumuishaji wa Mtoa Utambulisho wa Nje**: Tumia watoa utambulisho waliothibitishwa kama Microsoft Entra ID badala ya kutekeleza uthibitishaji wa kawaida  
   - **Uthibitishaji wa Watazamaji wa Token**: Daima hakikisha kuwa token zilitolewa mahsusi kwa MCP server yako - usikubali token za juu  
   - **Mzunguko Sahihi wa Token**: Tekeleza mzunguko salama wa token, sera za kumalizika muda, na zuia mashambulizi ya kurudia token  

**Hifadhi Salama ya Token:**
   - Tumia Azure Key Vault au hifadhi salama za sifa kama hizo kwa siri zote  
   - Tekeleza usimbaji wa token wakati wa kupumzika na wakati wa kusafirishwa  
   - Mzunguko wa mara kwa mara wa sifa na ufuatiliaji wa ufikiaji usioidhinishwa  

## 2. **Usimamizi wa Vikao & Usalama wa Usafirishaji**

**Mazoea Salama ya Vikao:**
   - **Vitambulisho vya Vikao Vilivyolindwa Kificho**: Tumia vitambulisho vya vikao visivyotabirika vilivyotengenezwa na jenereta za namba za nasibu salama  
   - **Ufungaji wa Mtumiaji Maalum**: Funga vitambulisho vya vikao kwa utambulisho wa watumiaji kwa kutumia fomati kama `<user_id>:<session_id>` ili kuzuia matumizi mabaya ya vikao vya watumiaji wengine  
   - **Usimamizi wa Mzunguko wa Vikao**: Tekeleza kumalizika muda, mzunguko, na kubatilisha ipasavyo ili kupunguza madirisha ya udhaifu  
   - **Utekelezaji wa HTTPS/TLS**: HTTPS ni lazima kwa mawasiliano yote ili kuzuia utekaji wa vitambulisho vya vikao  

**Usalama wa Safu ya Usafirishaji:**
   - Sanidi TLS 1.3 inapowezekana na usimamizi sahihi wa vyeti  
   - Tekeleza pinning ya vyeti kwa miunganisho muhimu  
   - Mzunguko wa mara kwa mara wa vyeti na uthibitishaji wa uhalali  

## 3. **Ulinzi Dhidi ya Vitisho Maalum vya AI** 🤖

**Ulinzi Dhidi ya Sindikizo la Maelekezo:**
   - **Microsoft Prompt Shields**: Tumia AI Prompt Shields kwa utambuzi wa hali ya juu na uchujaji wa maelekezo mabaya  
   - **Usafishaji wa Ingizo**: Thibitisha na safisha maingizo yote ili kuzuia mashambulizi ya sindikizo na matatizo ya confused deputy  
   - **Mipaka ya Maudhui**: Tumia mifumo ya alama na mipaka ya data kutofautisha kati ya maelekezo yanayoaminika na maudhui ya nje  

**Kuzuia Uchafuzi wa Zana:**
   - **Uthibitishaji wa Metadata ya Zana**: Tekeleza ukaguzi wa uadilifu wa ufafanuzi wa zana na ufuatilie mabadiliko yasiyotarajiwa  
   - **Ufuatiliaji wa Zana kwa Wakati Halisi**: Fuatilia tabia ya wakati wa utekelezaji na weka arifa kwa mifumo isiyotarajiwa ya utekelezaji  
   - **Mtiririko wa Idhini**: Hitaji idhini ya wazi ya mtumiaji kwa mabadiliko ya zana na uwezo  

## 4. **Udhibiti wa Ufikiaji & Ruhusa**

**Kanuni ya Upendeleo wa Chini Kabisa:**
   - Toa MCP servers ruhusa za chini kabisa zinazohitajika kwa utendaji uliokusudiwa  
   - Tekeleza udhibiti wa ufikiaji unaotegemea majukumu (RBAC) na ruhusa za kina  
   - Mapitio ya mara kwa mara ya ruhusa na ufuatiliaji wa kuendelea wa kupandishwa kwa ruhusa  

**Udhibiti wa Ruhusa Wakati wa Utekelezaji:**
>>>>>>> origin/main
   - Tumia mipaka ya rasilimali ili kuzuia mashambulizi ya uchovu wa rasilimali  
   - Tumia kutengwa kwa kontena kwa mazingira ya utekelezaji wa zana  
   - Tekeleza ufikiaji wa wakati tu kwa kazi za kiutawala  

<<<<<<< HEAD
## 5. **Usalama wa Maudhui na Ufuatiliaji**

**Utekelezaji wa Usalama wa Maudhui:**  
   - **Ujumuishaji wa Usalama wa Maudhui ya Azure**: Tumia Azure Content Safety kutambua maudhui hatari, majaribio ya kuvunja sheria, na ukiukaji wa sera  
   - **Uchambuzi wa Tabia**: Tekeleza ufuatiliaji wa tabia ya wakati wa kukimbia ili kutambua hali isiyo ya kawaida katika seva ya MCP na utekelezaji wa zana  
   - **Kumbukumbu Kamili**: Rekodi majaribio yote ya uthibitishaji, miito ya zana, na matukio ya usalama na uhifadhi salama usioweza kubadilishwa  

**Ufuatiliaji Endelevu:**  
   - Arifa za wakati halisi kwa mifumo ya kutiliwa shaka na majaribio ya ufikiaji usioidhinishwa  
   - Ujumuishaji na mifumo ya SIEM kwa usimamizi wa matukio ya usalama wa kati  
   - Ukaguzi wa usalama mara kwa mara na majaribio ya kupenya kwa utekelezaji wa MCP  

## 6. **Usalama wa Mnyororo wa Ugavi**

**Uthibitishaji wa Vipengele:**  
   - **Uchunguzi wa Utegemezi**: Tumia uchunguzi wa kiotomatiki wa udhaifu kwa utegemezi wote wa programu na vipengele vya AI  
   - **Uthibitishaji wa Asili**: Thibitisha asili, leseni, na uadilifu wa mifano, vyanzo vya data, na huduma za nje  
   - **Pakiti Zilizotiwa Saini**: Tumia pakiti zilizotiwa saini kwa usimbaji na uthibitisha saini kabla ya kupelekwa  

**Mchakato Salama wa Maendeleo:**  
   - **GitHub Advanced Security**: Tekeleza uchunguzi wa siri, uchambuzi wa utegemezi, na uchambuzi tuli wa CodeQL  
   - **Usalama wa CI/CD**: Jumuisha uthibitishaji wa usalama katika mchakato wa kupelekwa kiotomatiki  
   - **Uadilifu wa Vifaa**: Tekeleza uthibitishaji wa usimbaji kwa vifaa vilivyotumwa na usanidi  

## 7. **Usalama wa OAuth na Kuzuia Naibu Aliyedanganyika**

**Utekelezaji wa OAuth 2.1:**  
   - **Utekelezaji wa PKCE**: Tumia Proof Key for Code Exchange (PKCE) kwa maombi yote ya idhini  
   - **Idhini ya Wazi**: Pata idhini ya mtumiaji kwa kila mteja aliyesajiliwa kwa nguvu ili kuzuia mashambulizi ya naibu aliyedanganyika  
   - **Uthibitishaji wa URI ya Uelekezaji**: Tekeleza uthibitishaji mkali wa URI za uelekezaji na vitambulisho vya wateja  

**Usalama wa Wakala:**  
   - Zuia upitishaji wa idhini kupitia unyonyaji wa vitambulisho vya wateja vya kudumu  
   - Tekeleza mifumo sahihi ya idhini kwa ufikiaji wa API za wahusika wa tatu  
   - Fuatilia wizi wa nambari za idhini na ufikiaji wa API usioidhinishwa  

## 8. **Majibu ya Matukio na Urejeshaji**

**Uwezo wa Majibu ya Haraka:**  
   - **Majibu ya Kiotomatiki**: Tekeleza mifumo ya kiotomatiki kwa mzunguko wa siri na udhibiti wa vitisho  
   - **Taratibu za Kurejesha**: Uwezo wa kurudi haraka kwa usanidi na vipengele vilivyojulikana kuwa salama  
   - **Uwezo wa Uchunguzi**: Njia za ukaguzi wa kina na kumbukumbu kwa uchunguzi wa matukio  

**Mawasiliano na Uratibu:**  
   - Taratibu wazi za kupandisha matukio ya usalama  
   - Ujumuishaji na timu za majibu ya matukio za shirika  
   - Mazoezi ya mara kwa mara ya matukio ya usalama na mazoezi ya mezani  

## 9. **Uzingatiaji wa Kanuni na Utawala**

**Uzingatiaji wa Kanuni:**  
=======
## 5. **Usalama wa Maudhui & Ufuatiliaji**

**Utekelezaji wa Usalama wa Maudhui:**
   - **Ujumuishaji wa Azure Content Safety**: Tumia Azure Content Safety kugundua maudhui hatari, majaribio ya jailbreak, na ukiukaji wa sera  
   - **Uchambuzi wa Tabia**: Tekeleza ufuatiliaji wa tabia ya wakati wa utekelezaji ili kugundua hali isiyo ya kawaida katika MCP server na utekelezaji wa zana  
   - **Kumbukumbu Kamili**: Rekodi majaribio yote ya uthibitishaji, miito ya zana, na matukio ya usalama na hifadhi salama isiyoweza kubadilishwa  

**Ufuatiliaji Endelevu:**
   - Arifa za wakati halisi kwa mifumo ya kutiliwa shaka na majaribio ya ufikiaji usioidhinishwa  
   - Ujumuishaji na mifumo ya SIEM kwa usimamizi wa kati wa matukio ya usalama  
   - Ukaguzi wa mara kwa mara wa usalama na majaribio ya kupenya kwa utekelezaji wa MCP  

## 6. **Usalama wa Mnyororo wa Ugavi**

**Uthibitishaji wa Vipengele:**
   - **Uchunguzi wa Utegemezi**: Tumia uchunguzi wa kiotomatiki wa udhaifu kwa utegemezi wote wa programu na vipengele vya AI  
   - **Uthibitishaji wa Asili**: Thibitisha asili, leseni, na uadilifu wa mifano, vyanzo vya data, na huduma za nje  
   - **Paket Zilizotiwa Saini**: Tumia paket zilizotiwa saini kificho na thibitisha saini kabla ya kupeleka  

**Mchakato Salama wa Maendeleo:**
   - **GitHub Advanced Security**: Tekeleza uchunguzi wa siri, uchambuzi wa utegemezi, na uchambuzi tuli wa CodeQL  
   - **Usalama wa CI/CD**: Jumuisha uthibitishaji wa usalama katika mchakato wa kiotomatiki wa kupeleka  
   - **Uadilifu wa Vifaa**: Tekeleza uthibitishaji wa kificho kwa vifaa vilivyotumwa na usanidi  

## 7. **Usalama wa OAuth & Kuzuia Confused Deputy**

**Utekelezaji wa OAuth 2.1:**
   - **Utekelezaji wa PKCE**: Tumia Proof Key for Code Exchange (PKCE) kwa maombi yote ya idhini  
   - **Ridhaa ya Wazi**: Pata ridhaa ya mtumiaji kwa kila mteja aliyesajiliwa kwa nguvu ili kuzuia mashambulizi ya confused deputy  
   - **Uthibitishaji wa Redirect URI**: Tekeleza uthibitishaji mkali wa Redirect URIs na vitambulisho vya mteja  

**Usalama wa Proxy:**
   - Zuia kupitishwa kwa idhini kupitia unyonyaji wa static client ID  
   - Tekeleza mitiririko sahihi ya ridhaa kwa ufikiaji wa API za wahusika wa tatu  
   - Fuatilia wizi wa nambari za idhini na ufikiaji wa API usioidhinishwa  

## 8. **Majibu ya Matukio & Urejeshaji**

**Uwezo wa Kujibu Haraka:**
   - **Majibu ya Kiotomatiki**: Tekeleza mifumo ya kiotomatiki kwa mzunguko wa sifa na kudhibiti vitisho  
   - **Taratibu za Kurudisha**: Uwezo wa kurudi haraka kwenye usanidi na vipengele vilivyo salama  
   - **Uwezo wa Uchunguzi**: Njia za ukaguzi wa kina na kumbukumbu kwa uchunguzi wa matukio  

**Mawasiliano & Uratibu:**
   - Taratibu wazi za kupandisha matukio ya usalama  
   - Ujumuishaji na timu za majibu ya matukio ya shirika  
   - Mazoezi ya mara kwa mara ya matukio ya usalama na mazoezi ya mezani  

## 9. **Uzingatiaji & Utawala**

**Uzingatiaji wa Kisheria:**
>>>>>>> origin/main
   - Hakikisha utekelezaji wa MCP unakidhi mahitaji maalum ya sekta (GDPR, HIPAA, SOC 2)  
   - Tekeleza udhibiti wa uainishaji wa data na faragha kwa usindikaji wa data ya AI  
   - Dumisha nyaraka kamili kwa ukaguzi wa uzingatiaji  

<<<<<<< HEAD
**Usimamizi wa Mabadiliko:**  
   - Michakato rasmi ya ukaguzi wa usalama kwa mabadiliko yote ya mfumo wa MCP  
   - Udhibiti wa toleo na mifumo ya idhini kwa mabadiliko ya usanidi  
=======
**Usimamizi wa Mabadiliko:**
   - Michakato rasmi ya ukaguzi wa usalama kwa mabadiliko yote ya mfumo wa MCP  
   - Udhibiti wa matoleo na mitiririko ya idhini kwa mabadiliko ya usanidi  
>>>>>>> origin/main
   - Tathmini za mara kwa mara za uzingatiaji na uchambuzi wa mapengo  

## 10. **Udhibiti wa Usalama wa Juu**

<<<<<<< HEAD
**Usanifu wa Zero Trust:**  
   - **Usiamini Kamwe, Thibitisha Daima**: Uthibitishaji endelevu wa watumiaji, vifaa, na miunganisho  
   - **Mgawanyiko wa Ndani**: Udhibiti wa mtandao wa kina unaotenga vipengele vya MCP  
   - **Ufikiaji wa Masharti**: Udhibiti wa ufikiaji kulingana na hatari unaobadilika kulingana na muktadha wa sasa na tabia  

**Ulinzi wa Programu Wakati wa Kukimbia:**  
   - **Ulinzi wa Programu Wakati wa Kukimbia (RASP)**: Tekeleza mbinu za RASP kwa utambuzi wa vitisho wa wakati halisi  
   - **Ufuatiliaji wa Utendaji wa Programu**: Fuatilia hali isiyo ya kawaida ya utendaji ambayo inaweza kuonyesha mashambulizi  
   - **Sera za Usalama Zinazobadilika**: Tekeleza sera za usalama zinazobadilika kulingana na mazingira ya vitisho vya sasa  

## 11. **Ujumuishaji wa Mfumo wa Usalama wa Microsoft**

**Usalama Kamili wa Microsoft:**  
   - **Microsoft Defender for Cloud**: Usimamizi wa mkao wa usalama wa wingu kwa mzigo wa kazi wa MCP  
   - **Azure Sentinel**: Uwezo wa SIEM na SOAR wa asili wa wingu kwa utambuzi wa vitisho vya hali ya juu  
   - **Microsoft Purview**: Utawala wa data na uzingatiaji kwa mtiririko wa kazi wa AI na vyanzo vya data  

**Usimamizi wa Utambulisho na Ufikiaji:**  
   - **Microsoft Entra ID**: Usimamizi wa utambulisho wa biashara na sera za ufikiaji wa masharti  
   - **Usimamizi wa Utambulisho wa Kipekee (PIM)**: Ufikiaji wa wakati tu na mifumo ya idhini kwa kazi za kiutawala  
   - **Ulinzi wa Utambulisho**: Udhibiti wa ufikiaji kulingana na hatari na majibu ya vitisho ya kiotomatiki  

## 12. **Mageuzi Endelevu ya Usalama**

**Kuwa na Ujuzi wa Kisasa:**  
   - **Ufuatiliaji wa Maelezo**: Ukaguzi wa mara kwa mara wa sasisho za maelezo ya MCP na mabadiliko ya mwongozo wa usalama  
   - **Ujasusi wa Vitisho**: Ujumuishaji wa mitiririko ya vitisho maalum vya AI na viashiria vya hatari  
   - **Ushirikiano wa Jamii ya Usalama**: Ushiriki wa kazi katika jamii ya usalama ya MCP na programu za kufichua udhaifu  

**Usalama Unaobadilika:**  
   - **Usalama wa Kujifunza kwa Mashine**: Tumia utambuzi wa hali isiyo ya kawaida unaotegemea ML kutambua mifumo mpya ya mashambulizi  
   - **Uchambuzi wa Usalama wa Kihisia**: Tekeleza mifano ya utabiri kwa utambuzi wa vitisho wa mapema  
   - **Kiotomatiki ya Usalama**: Sasisho za sera za usalama kiotomatiki kulingana na ujasusi wa vitisho na mabadiliko ya maelezo  
=======
**Miundombinu ya Zero Trust:**
   - **Usiamini Kamwe, Thibitisha Daima**: Uthibitishaji wa kuendelea wa watumiaji, vifaa, na miunganisho  
   - **Mgawanyiko wa Ndani**: Udhibiti wa mtandao wa kina unaotenga vipengele vya MCP binafsi  
   - **Ufikiaji wa Masharti**: Udhibiti wa ufikiaji unaotegemea hatari unaobadilika kulingana na muktadha wa sasa na tabia  

**Ulinzi wa Programu Wakati wa Utekelezaji:**
   - **Ulinzi wa Programu Wakati wa Utekelezaji (RASP)**: Tekeleza mbinu za RASP kwa utambuzi wa vitisho wakati halisi  
   - **Ufuatiliaji wa Utendaji wa Programu**: Fuatilia hali isiyo ya kawaida ya utendaji inayoweza kuonyesha mashambulizi  
   - **Sera za Usalama Zinazobadilika**: Tekeleza sera za usalama zinazobadilika kulingana na mazingira ya sasa ya vitisho  

## 11. **Ujumuishaji wa Mfumo wa Usalama wa Microsoft**

**Usalama Kamili wa Microsoft:**
   - **Microsoft Defender for Cloud**: Usimamizi wa mkao wa usalama wa wingu kwa mizigo ya MCP  
   - **Azure Sentinel**: Uwezo wa SIEM na SOAR wa asili wa wingu kwa utambuzi wa hali ya juu wa vitisho  
   - **Microsoft Purview**: Utawala wa data na uzingatiaji kwa mtiririko wa kazi wa AI na vyanzo vya data  

**Usimamizi wa Utambulisho & Ufikiaji:**
   - **Microsoft Entra ID**: Usimamizi wa utambulisho wa biashara na sera za ufikiaji wa masharti  
   - **Privileged Identity Management (PIM)**: Ufikiaji wa wakati tu na mitiririko ya idhini kwa kazi za kiutawala  
   - **Ulinzi wa Utambulisho**: Udhibiti wa ufikiaji unaotegemea hatari na majibu ya kiotomatiki ya vitisho  

## 12. **Mageuzi Endelevu ya Usalama**

**Kukaa Kisasa:**
   - **Ufuatiliaji wa Maelezo**: Mapitio ya mara kwa mara ya sasisho za MCP specification na mabadiliko ya mwongozo wa usalama  
   - **Ujasusi wa Vitisho**: Ujumuishaji wa milisho ya vitisho maalum vya AI na viashiria vya maelewano  
   - **Ushirikiano wa Jumuiya ya Usalama**: Ushiriki wa kazi katika jumuiya ya usalama ya MCP na programu za kufichua udhaifu  

**Usalama Unaobadilika:**
   - **Usalama wa Kujifunza kwa Mashine**: Tumia utambuzi wa hali isiyo ya kawaida unaotegemea ML kwa kutambua mifumo mipya ya mashambulizi  
   - **Uchanganuzi wa Usalama wa Kutabiri**: Tekeleza mifano ya kutabiri kwa utambuzi wa vitisho kwa njia ya proakti  
   - **Kiotomatiki cha Usalama**: Sasisho za kiotomatiki za sera za usalama kulingana na ujasusi wa vitisho na mabadiliko ya maelezo  
>>>>>>> origin/main

---

## **Rasilimali Muhimu za Usalama**

### **Hati Rasmi za MCP**
- [MCP Specification (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)  
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)  
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)  

### **Suluhisho za Usalama za Microsoft**
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [Microsoft Entra ID Security](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)  
- [GitHub Advanced Security](https://github.com/security/advanced-security)  

### **Viwango vya Usalama**
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [OWASP Top 10 for Large Language Models](https://genai.owasp.org/)  
- [NIST AI Risk Management Framework](https://www.nist.gov/itl/ai-risk-management-framework)  

### **Miongozo ya Utekelezaji**
- [Azure API Management MCP Authentication Gateway](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  
- [Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)  

---

<<<<<<< HEAD
> **Tangazo la Usalama**: Mbinu za usalama za MCP zinabadilika haraka. Daima hakikisha dhidi ya [maelezo ya sasa ya MCP](https://spec.modelcontextprotocol.io/) na [hati rasmi za usalama](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) kabla ya utekelezaji.

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.
=======
> **Ilani ya Usalama**: Mazoea ya usalama ya MCP yanabadilika haraka. Daima hakikisha dhidi ya [MCP specification](https://spec.modelcontextprotocol.io/) ya sasa na [hati rasmi za usalama](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) kabla ya utekelezaji.

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kutumia tafsiri ya kitaalamu ya binadamu. Hatutawajibika kwa maelewano mabaya au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.
>>>>>>> origin/main
