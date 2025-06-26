<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:16:59+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hu"
}
-->
# Fejlett témák az MCP-ben

Ez a fejezet a Model Context Protocol (MCP) megvalósításának fejlett témáit tárgyalja, beleértve a többmodális integrációt, a skálázhatóságot, a biztonsági legjobb gyakorlatokat és a vállalati integrációt. Ezek a témák elengedhetetlenek ahhoz, hogy megbízható, éles környezetben használható MCP alkalmazásokat építsünk, amelyek megfelelnek a modern AI rendszerek igényeinek.

## Áttekintés

Ebben a leckében a Model Context Protocol megvalósításának fejlett fogalmait vizsgáljuk, különös tekintettel a többmodális integrációra, a skálázhatóságra, a biztonsági legjobb gyakorlatokra és a vállalati integrációra. Ezek a témák kulcsfontosságúak ahhoz, hogy olyan MCP alkalmazásokat hozzunk létre, amelyek képesek kezelni a vállalati környezetek összetett követelményeit.

## Tanulási célok

A lecke végére képes leszel:

- Többmodális képességek megvalósítása MCP keretrendszerekben
- Skálázható MCP architektúrák tervezése magas terhelésű helyzetekhez
- Biztonsági legjobb gyakorlatok alkalmazása az MCP biztonsági elveinek megfelelően
- MCP integrálása vállalati AI rendszerekkel és keretrendszerekkel
- Teljesítmény és megbízhatóság optimalizálása éles környezetekben

## Leckék és mintaprojektek

| Link | Cím | Leírás |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integráció Azure-rel | Tanuld meg, hogyan integráld MCP szerveredet az Azure környezetbe |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP többmodális minták | Minták hang-, kép- és többmodális válaszokhoz |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimális Spring Boot alkalmazás, amely bemutatja az OAuth2 használatát MCP-vel, mint Authorization és Resource Server. Biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt mutat be. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Gyökér kontextusok | Tudj meg többet a gyökér kontextusról és annak megvalósításáról |
| [5.5 Routing](./mcp-routing/README.md) | Útválasztás | Ismerd meg az útválasztás különböző típusait |
| [5.6 Sampling](./mcp-sampling/README.md) | Mintavételezés | Tanuld meg, hogyan dolgozz a mintavételezéssel |
| [5.7 Scaling](./mcp-scaling/README.md) | Skálázás | Ismerd meg a skálázás lehetőségeit |
| [5.8 Security](./mcp-security/README.md) | Biztonság | Biztosítsd MCP szerveredet |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP szerver és kliens, amely integrálja a SerpAPI-t valós idejű web-, hírek-, termékkereséshez és kérdés-válasz funkcióhoz. Több eszköz összehangolását, külső API integrációt és robusztus hibakezelést mutat be. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | A valós idejű adatfolyam ma már elengedhetetlen a gyors döntéshozatalt igénylő üzleti és alkalmazási környezetekben. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | A valós idejű webes keresés, és hogyan alakítja át az MCP a kontextuskezelést AI modellek, keresőmotorok és alkalmazások között egységes módon. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID hitelesítés | A Microsoft Entra ID egy megbízható, felhőalapú identitás- és hozzáférés-kezelési megoldás, amely biztosítja, hogy csak jogosult felhasználók és alkalmazások férjenek hozzá MCP szerveredhez. |

## További hivatkozások

A legfrissebb információkért az MCP fejlett témáiról tekintsd meg a következő forrásokat:
- [MCP Dokumentáció](https://modelcontextprotocol.io/)
- [MCP Specifikáció](https://spec.modelcontextprotocol.io/)
- [GitHub tárhely](https://github.com/modelcontextprotocol)

## Főbb tanulságok

- A többmodális MCP megvalósítások kibővítik az AI képességeit a szöveges feldolgozáson túl
- A skálázhatóság elengedhetetlen a vállalati bevezetéseknél, amit vízszintes és függőleges skálázással lehet megoldani
- Átfogó biztonsági intézkedések védik az adatokat és biztosítják a megfelelő hozzáférés-szabályozást
- A vállalati integráció platformokkal, mint az Azure OpenAI és a Microsoft AI Foundry, tovább növeli az MCP képességeit
- A fejlett MCP megvalósítások optimalizált architektúrákból és gondos erőforrás-kezelésből profitálnak

## Gyakorlat

Tervezd meg egy vállalati szintű MCP megvalósítását egy konkrét esethez:

1. Határozd meg a többmodális követelményeket az esetedhez
2. Vázold fel a biztonsági intézkedéseket az érzékeny adatok védelmére
3. Tervezd meg a skálázható architektúrát, amely képes kezelni a változó terhelést
4. Készíts integrációs pontokat vállalati AI rendszerekkel
5. Dokumentáld a lehetséges teljesítménybeli szűk keresztmetszeteket és azok kezelésének stratégiáit

## További források

- [Azure OpenAI dokumentáció](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry dokumentáció](https://learn.microsoft.com/en-us/ai-services/)

---

## Mi következik

- [5.1 MCP Integráció](./mcp-integration/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.