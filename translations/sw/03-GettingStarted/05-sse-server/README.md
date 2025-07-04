<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-04T18:26:20+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sw"
}
-->
Sasa tunapojua kidogo zaidi kuhusu SSE, hebu tujenge seva ya SSE ifuatayo.

## Zoef: Kuunda Seva ya SSE

Ili kuunda seva yetu, tunahitaji kuzingatia mambo mawili:

- Tunahitaji kutumia seva ya wavuti kufungua njia za kuunganishwa na ujumbe.
- Jenga seva yetu kama kawaida tunavyofanya kwa kutumia zana, rasilimali na maelekezo tulipokuwa tunatumia stdio.

### -1- Unda mfano wa seva

Ili kuunda seva yetu, tunatumia aina zile zile kama stdio. Hata hivyo, kwa usafirishaji, tunahitaji kuchagua SSE.

Hebu tuongeze njia zinazohitajika ifuatayo.

### -2- Ongeza njia

Hebu tuongeze njia zinazoshughulikia muunganisho na ujumbe unaoingia:

Hebu tuongeze uwezo kwa seva ifuatayo.

### -3- Kuongeza uwezo wa seva

Sasa tumeweka kila kitu maalum cha SSE, hebu tuongeze uwezo wa seva kama zana, maelekezo na rasilimali.

Msimbo wako mzima unapaswa kuonekana kama huu:

Nzuri, tuna seva inayotumia SSE, hebu tujaribu sasa.

## Zoef: Kurekebisha Seva ya SSE kwa kutumia Inspector

Inspector ni zana nzuri tuliyoiona katika somo la awali [Kuunda seva yako ya kwanza](/03-GettingStarted/01-first-server/README.md). Hebu tuone kama tunaweza kutumia Inspector hata hapa:

### -1- Kuendesha inspector

Ili kuendesha inspector, kwanza lazima uwe na seva ya SSE inayoendesha, hivyo hebu tufanye hivyo sasa:

1. Endesha seva

1. Endesha inspector

    > ![NOTE]
    > Endesha hii katika dirisha tofauti la terminal tofauti na ile seva inayoendesha. Pia kumbuka, unahitaji kurekebisha amri iliyo chini ili ifae URL ambapo seva yako inaendesha.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Kuendesha inspector ni sawa katika mazingira yote ya utekelezaji. Angalia jinsi badala ya kupitisha njia ya seva yetu na amri ya kuanzisha seva, tunapita URL ambapo seva inaendesha na pia tunaelekeza njia ya `/sse`.

### -2- Kuijaribu zana

Unganisha seva kwa kuchagua SSE kwenye orodha ya kushuka na jaza sehemu ya url ambapo seva yako inaendesha, kwa mfano http:localhost:4321/sse. Sasa bonyeza kitufe cha "Connect". Kama awali, chagua kuorodhesha zana, chagua zana na toa maingizo. Unapaswa kuona matokeo kama ifuatavyo:

![Seva ya SSE ikifanya kazi katika inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sw.png)

Nzuri, unaweza kufanya kazi na inspector, hebu tuone jinsi tunavyoweza kufanya kazi na Visual Studio Code ifuatayo.

## Kazi ya Nyumbani

Jaribu kujenga seva yako na uwezo zaidi. Angalia [ukurasa huu](https://api.chucknorris.io/) ili, kwa mfano, kuongeza zana inayopiga API. Uamuzi ni wako jinsi seva inavyopaswa kuonekana. Furahia :)

## Suluhisho

[Suluhisho](./solution/README.md) Hapa kuna suluhisho linalowezekana lenye msimbo unaofanya kazi.

## Muhimu Kumbuka

Muhimu kumbuka kutoka sura hii ni yafuatayo:

- SSE ni usafirishaji wa pili unaoungwa mkono baada ya stdio.
- Ili kuunga mkono SSE, unahitaji kusimamia muunganisho unaoingia na ujumbe kwa kutumia mfumo wa wavuti.
- Unaweza kutumia Inspector na Visual Studio Code kula seva ya SSE, kama vile seva za stdio. Angalia jinsi inavyotofautiana kidogo kati ya stdio na SSE. Kwa SSE, unahitaji kuanzisha seva kando kisha kuendesha zana yako ya inspector. Kwa zana ya inspector, pia kuna tofauti kidogo kwamba unahitaji kubainisha URL.

## Sampuli

- [Kalkuleta ya Java](../samples/java/calculator/README.md)
- [Kalkuleta ya .Net](../../../../03-GettingStarted/samples/csharp)
- [Kalkuleta ya JavaScript](../samples/javascript/README.md)
- [Kalkuleta ya TypeScript](../samples/typescript/README.md)
- [Kalkuleta ya Python](../../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Nini Kifuatacho

- Ifuatayo: [HTTP Streaming na MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.