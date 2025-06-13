<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:39:01+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "mo"
}
-->
Katika msimbo uliotangulia tulifanya:

- Kuleta maktaba
- Kuunda mfano wa client na kuunganisha kwa kutumia stdio kama njia ya usafirishaji.
- Orodhesha prompts, rasilimali na zana na kuzitumia zote.

Hapo unayo, client inayoweza kuwasiliana na MCP Server.

Tuchukue muda wetu katika sehemu inayofuata ya mazoezi na kugawanya kila kipande cha msimbo na kuelezea kinachotokea.

## Mazoezi: Kuandika client

Kama ilivyosemwa hapo juu, tuchukue muda wetu kuelezea msimbo, na bila shaka andika pamoja nasi kama unataka.

### -1- Kuleta maktaba

Tulete maktaba tunazohitaji, tutahitaji marejeleo ya client na ya itifaki ya usafirishaji tuliyochagua, stdio. stdio ni itifaki kwa vitu vinavyokusudiwa kuendesha kwenye mashine yako ya ndani. SSE ni itifaki nyingine ya usafirishaji tutakayoonyesha katika sura zijazo lakini hiyo ni chaguo lako jingine. Kwa sasa, tuendelee na stdio.

### -2- Kuanzisha client na usafirishaji

Tutahitaji kuunda mfano wa usafirishaji na huo wa client wetu:

### -3- Kurodha vipengele vya server

Sasa, tuna client inayoweza kuungana ikiwa programu itaendeshwa. Hata hivyo, haionyeshi vipengele vyake, basi tufanye hivyo sasa:

Sawa, sasa tumechukua vipengele vyote. Sasa swali ni lini tunavitumia? Hii client ni rahisi sana, rahisi kwa maana kwamba tutahitaji kuitisha vipengele moja kwa moja tunapotaka. Katika sura inayofuata, tutaunda client iliyo na uwezo wa kupata lugha yake kubwa ya mfano, LLM. Kwa sasa, tuone jinsi ya kuitisha vipengele kwenye server:

### -4- Kuitisha vipengele

Ili kuitisha vipengele tunahitaji kuhakikisha tunabainisha hoja sahihi na katika baadhi ya kesi jina la kile tunachojaribu kuitisha.

### -5- Kuendesha client

Ili kuendesha client, andika amri ifuatayo kwenye terminal:

## Kazi ya Nyumbani

Katika kazi hii ya nyumbani, utatumia kile ulichojifunza katika kuunda client lakini utaunda client yako mwenyewe.

Hapa kuna server unayoweza kutumia ambayo unahitaji kuitisha kupitia msimbo wako wa client, angalia kama unaweza kuongeza vipengele zaidi kwenye server ili kuifanya iwe ya kuvutia zaidi.

## Suluhisho

[Suluhisho](./solution/README.md)

## Muhimu Kuu

Muhimu kuu wa sura hii kuhusu clients ni yafuatayo:

- Inaweza kutumika kugundua na kuitisha vipengele kwenye server.
- Inaweza kuanzisha server wakati inapoanzisha yenyewe (kama ilivyo katika sura hii) lakini clients pia zinaweza kuungana na server zinazotendeka.
- Ni njia nzuri ya kujaribu uwezo wa server kando na mbadala kama Inspector ilivyoelezwa katika sura iliyopita.

## Rasilimali Zaidi

- [Kujenga clients katika MCP](https://modelcontextprotocol.io/quickstart/client)

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Nini Kifuatacho

- Ifuatayo: [Kuunda client na LLM](/03-GettingStarted/03-llm-client/README.md)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.