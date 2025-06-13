<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:50:52+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sw"
}
-->
Katika msimbo uliotangulia tulifanya yafuatayo:

- Kuleta maktaba
- Kuunda mfano wa client na kuunganisha kwa kutumia stdio kama njia ya usafirishaji.
- Orodhesha prompts, rasilimali na zana na kuzitekeleza zote.

Hapo una client inayoweza kuzungumza na MCP Server.

Tuchukue muda wetu katika sehemu ya zoezi ijayo kuelezea kila kipande cha msimbo na kueleza kinachoendelea.

## Zoezi: Kuandika client

Kama ilivyoelezwa hapo juu, tuchukue muda kuelezea msimbo, na kwa njia yoyote unaweza kuandika msimbo pamoja nasi ikiwa unataka.

### -1- Kuleta maktaba

Tulete maktaba tunazohitaji, tutahitaji marejeleo kwa client na kwa itifaki ya usafirishaji tuliyochagua, stdio. stdio ni itifaki kwa vitu vinavyokusudiwa kuendeshwa kwenye mashine yako ya ndani. SSE ni itifaki nyingine ya usafirishaji tutakayoionyesha katika sura zijazo lakini hiyo ni chaguo lako jingine. Kwa sasa, tuendelee na stdio.

---

Tuendelee na kuanzisha.

### -2- Kuanzisha client na usafirishaji

Tutahitaji kuunda mfano wa usafirishaji na wa client wetu: 

---

### -3- Kurodhesha vipengele vya server

Sasa, tuna client inayoweza kuungana ikiwa programu itaendeshwa. Hata hivyo, haionyeshi vipengele vyake hivyo tufanye hivyo sasa:

---

Nzuri, sasa tumeshapata vipengele vyote. Sasa swali ni lini tutavitumia? Client hii ni rahisi sana, rahisi kwa maana kwamba tutahitaji kuitisha vipengele waziwazi tunapotaka. Katika sura inayofuata, tutaunda client ya hali ya juu zaidi inayopata upatikanaji wa mfano wake mkubwa wa lugha, LLM. Kwa sasa, tuone jinsi ya kuitisha vipengele kwenye server:

### -4- Kuitisha vipengele

Ili kuitisha vipengele tunahitaji kuhakikisha tunaeleza hoja sahihi na katika baadhi ya matukio jina la kile tunachojaribu kuitisha.

---

### -5- Kuendesha client

Ili kuendesha client, andika amri ifuatayo kwenye terminal:

---

## Kazi ya Nyumbani

Katika kazi hii ya nyumbani, utatumia kile ulichojifunza katika kuunda client lakini tengeneza client yako mwenyewe.

Hapa kuna server unayoweza kutumia ambayo unahitaji kuitisha kupitia msimbo wako wa client, jaribu kuongeza vipengele zaidi kwenye server ili kuifanya iwe ya kuvutia zaidi.

---

## Suluhisho

[Suluhisho](./solution/README.md)

## Muhimu Kumbukumbu

Muhimu kumbukumbu kwa sura hii kuhusu clients ni yafuatayo:

- Inaweza kutumika kugundua na kuitisha vipengele kwenye server.
- Inaweza kuanzisha server wakati inajiendesha (kama ilivyo katika sura hii) lakini clients pia zinaweza kuungana na server zinazotumika tayari.
- Ni njia nzuri ya kujaribu uwezo wa server kando na mbadala kama Inspector ilivyoelezwa katika sura iliyopita.

## Rasilimali Zaidi

- [Kujenga clients katika MCP](https://modelcontextprotocol.io/quickstart/client)

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Nini Kinachofuata

- Ifuatayo: [Kuunda client na LLM](/03-GettingStarted/03-llm-client/README.md)

**Kasi ya Kukataa**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatubebwi na dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.