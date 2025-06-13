<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-13T00:44:59+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sw"
}
-->
Sasa tunajua kidogo zaidi kuhusu SSE, hebu tujenge server ya SSE sasa.

## Zoef: Kuunda Server ya SSE

Ili kuunda server yetu, tunapaswa kuzingatia mambo mawili:

- Tunahitaji kutumia web server kufungua endpoints za connection na messages.
- Tujenge server yetu kama kawaida tunavyofanya na tools, resources na prompts tulipokuwa tunatumia stdio.

### -1- Unda instance ya server

Ili kuunda server yetu, tunatumia types zile zile kama stdio. Hata hivyo, kwa transport, tunapaswa kuchagua SSE.

Hebu tuongeze routes zinazohitajika sasa.

### -2- Ongeza routes

Tuweke routes zinazoshughulikia connection na messages zinazoingia:

Sasa ongeza uwezo kwa server.

### -3- Kuongeza uwezo wa server

Sasa tunapokuwa tumebainisha kila kitu maalum cha SSE, ongeza uwezo wa server kama tools, prompts na resources.

Msimbo wako mzima unapaswa kuonekana hivi:

Nzuri, tuna server inayotumia SSE, hebu tujaribu sasa.

## Zoef: Kurekebisha Server ya SSE kwa kutumia Inspector

Inspector ni zana nzuri tuliyoiona katika somo la awali [Kuunda server yako ya kwanza](/03-GettingStarted/01-first-server/README.md). Hebu tuone kama tunaweza kutumia Inspector hapa pia:

### -1- Kuendesha inspector

Ili kuendesha inspector, lazima kwanza uwe na server ya SSE inayoendesha, basi tufanye hivyo sasa:

1. Endesha server

1. Endesha inspector

    > ![NOTE]
    > Endesha hii katika dirisha tofauti la terminal na ile server inayoendesha. Pia kumbuka, unahitaji kubadilisha amri hapa chini ili ifae URL ambapo server yako inafanya kazi.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Kuendesha inspector ni sawa katika runtimes zote. Angalia jinsi badala ya kupeleka path ya server yetu na amri ya kuanzisha server, tunapeleka URL ambapo server inafanya kazi na pia tunaeleza route ya `/sse`.

### -2- Kuangalia zana

Unganisha server kwa kuchagua SSE kwenye droplist na jaza sehemu ya url ambapo server yako inafanya kazi, kwa mfano http:localhost:4321/sse. Sasa bonyeza kitufe cha "Connect". Kama awali, chagua kuorodhesha tools, chagua tool na toa thamani za input. Utapata matokeo kama ifuatavyo:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sw.png)

Nzuri, unaweza kutumia inspector, hebu tuone jinsi ya kutumia Visual Studio Code sasa.

## Kazi ya Nyumbani

Jaribu kuendeleza server yako na uwezo zaidi. Angalia [ukurasa huu](https://api.chucknorris.io/) kuongeza mfano tool inayopiga API, wewe uamue server ijeje. Furahia :)

## Suluhisho

[Suluhisho](./solution/README.md) Hapa kuna suluhisho linalowezekana na msimbo unaofanya kazi.

## Muhimu Kumbuka

Mambo muhimu kutoka sura hii ni:

- SSE ni transport ya pili inayounga mkono baada ya stdio.
- Ili kuunga mkono SSE, unahitaji kusimamia connections na messages zinazoingia kwa kutumia web framework.
- Unaweza kutumia Inspector na Visual Studio Code kula server ya SSE, kama servers za stdio. Angalia tofauti kidogo kati ya stdio na SSE. Kwa SSE, unahitaji kuanzisha server tofauti kisha kuendesha zana ya inspector. Kwa zana ya inspector, pia kuna tofauti kidogo kwa kuwa unahitaji kueleza URL.

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Nini Kifuatacho

- Ifuatayo: [HTTP Streaming na MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Kenyata ya Msamaha**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya mama inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu na ya binadamu inashauriwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.