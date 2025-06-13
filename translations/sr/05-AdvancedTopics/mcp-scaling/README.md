<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-13T01:18:28+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "sr"
}
-->
## Distribuirana arhitektura

Distribuirane arhitekture podrazumevaju više MCP čvorova koji zajedno rade na obradi zahteva, deljenju resursa i obezbeđivanju redundancije. Ovaj pristup poboljšava skalabilnost i otpornost na greške omogućavajući čvorovima da komuniciraju i koordiniraju se kroz distribuirani sistem.

Pogledajmo primer kako implementirati distribuiranu MCP arhitekturu koristeći Redis za koordinaciju.

## Šta sledi

- [5.8 Bezbednost](../mcp-security/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала употребом овог превода.