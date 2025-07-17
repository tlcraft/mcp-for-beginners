<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T13:45:14+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "sw"
}
-->
# MCP Security Best Practices - Sasisho la Julai 2025

## Mbinu Kamili za Usalama kwa Utekelezaji wa MCP

Unapofanya kazi na seva za MCP, fuata mbinu hizi bora za usalama ili kulinda data yako, miundombinu, na watumiaji:

1. **Uhakiki wa Ingizo**: Daima hakiki na safisha ingizo ili kuzuia mashambulizi ya sindano na matatizo ya confused deputy.
   - Tekeleza uhakiki mkali kwa vigezo vyote vya zana
   - Tumia uhakiki wa skimu kuhakikisha maombi yanazingatia muundo unaotarajiwa
   - Chuja maudhui yanayoweza kuwa hatari kabla ya kusindika

2. **Udhibiti wa Upatikanaji**: Tekeleza uthibitishaji na idhini sahihi kwa seva yako ya MCP kwa ruhusa za kina.
   - Tumia OAuth 2.0 na watoa huduma wa utambulisho waliothibitishwa kama Microsoft Entra ID
   - Tekeleza udhibiti wa upatikanaji kwa misingi ya majukumu (RBAC) kwa zana za MCP
   - Usitekeleze uthibitishaji wa kawaida wakati suluhisho zilizothibitishwa zipo

3. **Mawasiliano Salama**: Tumia HTTPS/TLS kwa mawasiliano yote na seva yako ya MCP na fikiria kuongeza usimbaji wa ziada kwa data nyeti.
   - Sanidi TLS 1.3 pale inapowezekana
   - Tekeleza kuweka alama za vyeti kwa miunganisho muhimu
   - Badilisha vyeti mara kwa mara na hakiki uhalali wake

4. **Kudhibiti Kiwango cha Maombi**: Tekeleza mipaka ya kiwango cha maombi ili kuzuia matumizi mabaya, mashambulizi ya DoS, na kusimamia matumizi ya rasilimali.
   - Weka mipaka inayofaa ya maombi kulingana na mifumo ya matumizi inayotarajiwa
   - Tekeleza majibu ya hatua kwa maombi ya ziada
   - Fikiria mipaka ya kiwango cha maombi kwa watumiaji binafsi kulingana na hali ya uthibitishaji

5. **Kurekodi na Kufuatilia**: Fuata seva yako ya MCP kwa shughuli za kutiliwa shaka na tekeleza njia kamili za ukaguzi.
   - Rekodi jaribio zote za uthibitishaji na matumizi ya zana
   - Tekeleza tahadhari za papo hapo kwa mifumo ya kutiliwa shaka
   - Hakikisha rekodi zinahifadhiwa kwa usalama na haziwezi kubadilishwa

6. **Uhifadhi Salama**: Linda data nyeti na nyaraka za siri kwa usimbaji salama wakati wa kuhifadhi.
   - Tumia key vaults au hifadhi salama za nyaraka za siri kwa siri zote
   - Tekeleza usimbaji wa kiwango cha shamba kwa data nyeti
   - Badilisha funguo za usimbaji na nyaraka za siri mara kwa mara

7. **Usimamizi wa Tokeni**: Zuia udhaifu wa tokeni kwa kuhakiki na kusafisha ingizo na matokeo yote ya modeli.
   - Tekeleza uhakiki wa tokeni kulingana na madai ya hadhira
   - Usikubali tokeni zisizotolewa wazi kwa seva yako ya MCP
   - Tekeleza usimamizi sahihi wa muda wa tokeni na mzunguko wake

8. **Usimamizi wa Kikao**: Tekeleza usimamizi salama wa vikao ili kuzuia wizi wa kikao na mashambulizi ya fixation.
   - Tumia vitambulisho vya kikao visivyo vya utabiri na salama
   - Liganisha vikao na taarifa za mtumiaji binafsi
   - Tekeleza kumalizika na mzunguko sahihi wa vikao

9. **Kutekeleza Zana kwa Mazingira Yaliyojitenga**: Endesha utekelezaji wa zana katika mazingira yaliyojitenga ili kuzuia kusambaa kwa mashambulizi ikiwa imevamiwa.
   - Tekeleza kutengwa kwa kontena kwa utekelezaji wa zana
   - Weka mipaka ya rasilimali kuzuia mashambulizi ya matumizi ya rasilimali kupita kiasi
   - Tumia muktadha tofauti wa utekelezaji kwa maeneo tofauti ya usalama

10. **Ukaguzi wa Usalama wa Mara kwa Mara**: Fanya mapitio ya mara kwa mara ya usalama kwa utekelezaji na utegemezi wa MCP.
    - Panga vipimo vya mara kwa mara vya upenyezaji
    - Tumia zana za skanning za moja kwa moja kugundua udhaifu
    - Sasisha utegemezi ili kushughulikia matatizo ya usalama yanayojulikana

11. **Kuchuja Usalama wa Maudhui**: Tekeleza vichujio vya usalama wa maudhui kwa ingizo na matokeo.
    - Tumia Azure Content Safety au huduma zinazofanana kugundua maudhui hatari
    - Tekeleza mbinu za kuzuia sindano za maelekezo
    - Chunguza maudhui yaliyotengenezwa kwa uwezekano wa kuvuja data nyeti

12. **Usalama wa Mnyororo wa Ugavi**: Hakiki uadilifu na uhalisia wa vipengele vyote katika mnyororo wako wa ugavi wa AI.
    - Tumia vifurushi vilivyo saini na hakiki saini
    - Tekeleza uchambuzi wa orodha ya vifaa vya programu (SBOM)
    - Fuata kwa karibu masasisho hatari kwa utegemezi

13. **Ulinzi wa Ufafanuzi wa Zana**: Zuia sumu ya zana kwa kulinda ufafanuzi na metadata ya zana.
    - Hakiki ufafanuzi wa zana kabla ya matumizi
    - Fuata mabadiliko yasiyotarajiwa ya metadata ya zana
    - Tekeleza ukaguzi wa uadilifu kwa ufafanuzi wa zana

14. **Ufuatiliaji wa Utekelezaji wa Muda Halisi**: Fuata tabia za wakati wa utekelezaji wa seva na zana za MCP.
    - Tekeleza uchambuzi wa tabia kugundua kasoro
    - Weka tahadhari kwa mifumo isiyotegemewa ya utekelezaji
    - Tumia mbinu za ulinzi wa programu zinazojiendesha wakati wa utekelezaji (RASP)

15. **Kanuni ya Ruhusa Ndogo Zaidi**: Hakikisha seva na zana za MCP zinaendesha kwa ruhusa chache zinazohitajika tu.
    - Toa ruhusa maalum tu zinazohitajika kwa kila operesheni
    - Pitia na ukague matumizi ya ruhusa mara kwa mara
    - Tekeleza upatikanaji wa wakati muafaka kwa kazi za usimamizi

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.