<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:30:22+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "sw"
}
-->
## Muundo wa Mfumo

Mradi huu unaonyesha programu ya wavuti inayotumia ukaguzi wa usalama wa maudhui kabla ya kupeleka maombi ya mtumiaji kwa huduma ya kalkuleta kupitia Model Context Protocol (MCP).

### Jinsi Inavyofanya Kazi

1. **Ingizo la Mtumiaji**: Mtumiaji anaingiza ombi la hesabu kwenye kiolesura cha wavuti
2. **Uchunguzi wa Usalama wa Maudhui (Ingizo)**: Ombi linachambuliwa na Azure Content Safety API
3. **Uamuzi wa Usalama (Ingizo)**:
   - Ikiwa maudhui ni salama (ukali < 2 katika kategoria zote), linaendelea kwa kalkuleta
   - Ikiwa maudhui yanachukuliwa kuwa yanayoweza kuwa na madhara, mchakato unakoma na kurudi onyo
4. **Muunganiko wa Kalkuleta**: Maudhui salama yanachakatwa na LangChain4j, ambayo inaongea na seva ya kalkuleta ya MCP
5. **Uchunguzi wa Usalama wa Maudhui (Pato)**: Jibu la roboti linachambuliwa na Azure Content Safety API
6. **Uamuzi wa Usalama (Pato)**:
   - Ikiwa jibu la roboti ni salama, linaonyeshwa kwa mtumiaji
   - Ikiwa jibu la roboti linachukuliwa kuwa linayoweza kuwa na madhara, linabadilishwa na onyo
7. **Jibu**: Matokeo (ikiwa ni salama) yanaonyeshwa kwa mtumiaji pamoja na uchambuzi wa usalama wote

## Kutumia Model Context Protocol (MCP) na Huduma za Kalkuleta

Mradi huu unaonyesha jinsi ya kutumia Model Context Protocol (MCP) kuita huduma za kalkuleta za MCP kutoka LangChain4j. Utekelezaji unatumia seva ya MCP ya ndani inayotumia bandari 8080 kutoa operesheni za kalkuleta.

### Kuweka Huduma ya Usalama wa Maudhui ya Azure

Kabla ya kutumia vipengele vya usalama wa maudhui, unahitaji kuunda rasilimali ya huduma ya Usalama wa Maudhui ya Azure:

1. Ingia kwenye [Azure Portal](https://portal.azure.com)
2. Bofya "Create a resource" na utafute "Content Safety"
3. Chagua "Content Safety" na bofya "Create"
4. Ingiza jina la kipekee kwa rasilimali yako
5. Chagua usajili wako na kikundi cha rasilimali (au unda kipya)
6. Chagua eneo linaloungwa mkono (angalia [Upatikanaji wa Eneo](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) kwa maelezo)
7. Chagua kiwango cha bei kinachofaa
8. Bofya "Create" kupeleka rasilimali
9. Mara baada ya upelekaji kukamilika, bofya "Go to resource"
10. Katika paneli ya kushoto, chini ya "Resource Management", chagua "Keys and Endpoint"
11. Nakili mojawapo ya funguo na URL ya mwisho kwa matumizi katika hatua inayofuata

### Kuseti Mabadiliko ya Mazingira

Weka mabadiliko ya mazingira ya `GITHUB_TOKEN` kwa uthibitishaji wa mifano ya GitHub:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Kwa vipengele vya usalama wa maudhui, weka:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Mabadiliko haya ya mazingira yanatumiwa na programu kujiidhinisha na huduma ya Usalama wa Maudhui ya Azure. Ikiwa mabadiliko haya hayajawekwa, programu itatumia maadili ya nafasi kwa madhumuni ya kuonyesha, lakini vipengele vya usalama wa maudhui havitafanya kazi vizuri.

### Kuanza Seva ya Kalkuleta MCP

Kabla ya kuendesha mteja, unahitaji kuanza seva ya kalkuleta ya MCP katika hali ya SSE kwenye localhost:8080.

## Maelezo ya Mradi

Mradi huu unaonyesha muunganiko wa Model Context Protocol (MCP) na LangChain4j kuita huduma za kalkuleta. Vipengele muhimu ni pamoja na:

- Kutumia MCP kuunganisha na huduma ya kalkuleta kwa operesheni za hesabu za msingi
- Ukaguzi wa usalama wa maudhui wa tabaka mbili kwa maombi ya mtumiaji na majibu ya roboti
- Muunganiko na modeli ya gpt-4.1-nano ya GitHub kupitia LangChain4j
- Kutumia Matukio Yanayotumwa na Seva (SSE) kwa usafirishaji wa MCP

## Muunganiko wa Usalama wa Maudhui

Mradi unajumuisha vipengele vya kina vya usalama wa maudhui ili kuhakikisha kwamba maingizo ya mtumiaji na majibu ya mfumo ni huru kutokana na maudhui yenye madhara:

1. **Uchunguzi wa Ingizo**: Maombi yote ya mtumiaji yanachambuliwa kwa kategoria za maudhui yenye madhara kama vile hotuba ya chuki, vurugu, kujidhuru, na maudhui ya ngono kabla ya kuchakatwa.

2. **Uchunguzi wa Pato**: Hata wakati wa kutumia modeli zinazoweza kuwa hazijachujwa, mfumo unachunguza majibu yote yaliyotengenezwa kupitia vichujio vya usalama wa maudhui kabla ya kuyaonyesha kwa mtumiaji.

Mbinu hii ya tabaka mbili inahakikisha kwamba mfumo unakuwa salama bila kujali ni modeli gani ya AI inayotumiwa, ikilinda watumiaji kutokana na maingizo yenye madhara na matokeo yanayoweza kuwa na matatizo yanayotengenezwa na AI.

## Mteja wa Wavuti

Programu inajumuisha kiolesura cha wavuti rafiki kwa mtumiaji kinachoruhusu watumiaji kuingiliana na mfumo wa Kalkuleta wa Usalama wa Maudhui:

### Vipengele vya Kiolesura cha Wavuti

- Fomu rahisi na yenye kueleweka kwa kuingiza maombi ya hesabu
- Uthibitishaji wa usalama wa maudhui wa tabaka mbili (ingizo na pato)
- Maoni ya papo hapo kuhusu usalama wa ombi na jibu
- Viashiria vya usalama vilivyowekwa rangi kwa urahisi wa kutafsiri
- Muundo safi na unaoitikia unaofanya kazi kwenye vifaa mbalimbali
- Mifano ya maombi salama kuwaongoza watumiaji

### Kutumia Mteja wa Wavuti

1. Anzisha programu:
   ```sh
   mvn spring-boot:run
   ```

2. Fungua kivinjari chako na nenda kwenye `http://localhost:8087`

3. Ingiza ombi la hesabu kwenye eneo la maandishi lililotolewa (mfano, "Hesabu jumla ya 24.5 na 17.3")

4. Bofya "Submit" kuendesha ombi lako

5. Tazama matokeo, ambayo yatakuwa na:
   - Uchambuzi wa usalama wa maudhui ya ombi lako
   - Matokeo ya hesabu (ikiwa ombi lilikuwa salama)
   - Uchambuzi wa usalama wa maudhui ya jibu la roboti
   - Onyo lolote la usalama ikiwa ingizo au pato lilichukuliwa kuwa na matatizo

Mteja wa wavuti hushughulikia kiotomatiki michakato yote ya uthibitishaji wa usalama wa maudhui, kuhakikisha maingiliano yote ni salama na yanayofaa bila kujali ni modeli gani ya AI inayotumiwa.

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuelewana. Hati ya asili katika lugha yake ya kiasili inapaswa kuchukuliwa kuwa chanzo chenye mamlaka. Kwa habari muhimu, tafsiri ya kibinadamu ya kitaalamu inapendekezwa. Hatutawajibika kwa kutokuelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.