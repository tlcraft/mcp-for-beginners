<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-07-14T02:32:58+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "sk"
}
-->
## Distribuovaná architektúra

Distribuované architektúry zahŕňajú viacero MCP uzlov, ktoré spolupracujú pri spracovaní požiadaviek, zdieľaní zdrojov a zabezpečujú redundanciu. Tento prístup zvyšuje škálovateľnosť a odolnosť voči chybám tým, že umožňuje uzlom komunikovať a koordinovať sa prostredníctvom distribuovaného systému.

Pozrime sa na príklad, ako implementovať distribuovanú architektúru MCP servera s využitím Redis na koordináciu.

## Čo bude ďalej

- [5.8 Security](../mcp-security/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.