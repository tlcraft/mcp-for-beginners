<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1949cb32394aeb1bdec8870f309005a3",
  "translation_date": "2025-07-17T10:23:00+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hu"
}
-->
# Fejlett témák az MCP-ben

Ez a fejezet a Model Context Protocol (MCP) megvalósításának fejlett témáit tárgyalja, beleértve a multimodális integrációt, a skálázhatóságot, a biztonsági legjobb gyakorlatokat és a vállalati integrációt. Ezek a témák elengedhetetlenek ahhoz, hogy megbízható és éles környezetben is használható MCP alkalmazásokat építsünk, amelyek megfelelnek a modern AI rendszerek igényeinek.

## Áttekintés

Ebben a leckében a Model Context Protocol megvalósításának fejlett fogalmait vizsgáljuk, különös tekintettel a multimodális integrációra, a skálázhatóságra, a biztonsági legjobb gyakorlatokra és a vállalati integrációra. Ezek a témák alapvetőek ahhoz, hogy éles környezetben is működőképes MCP alkalmazásokat hozzunk létre, amelyek képesek kezelni a vállalati környezetek összetett követelményeit.

## Tanulási célok

A lecke végére képes leszel:

- Megvalósítani multimodális képességeket az MCP keretrendszerekben
- Tervezni skálázható MCP architektúrákat nagy igénybevételű helyzetekre
- Alkalmazni a biztonsági legjobb gyakorlatokat az MCP biztonsági elveinek megfelelően
- Integrálni az MCP-t vállalati AI rendszerekkel és keretrendszerekkel
- Optimalizálni a teljesítményt és a megbízhatóságot éles környezetben

## Leckék és mintaprojektek

| Link | Cím | Leírás |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integráció Azure-rel | Tanuld meg, hogyan integrálhatod MCP szerveredet Azure környezetbe |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodális minták | Minták hang, kép és multimodális válaszokhoz |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 demó | Minimális Spring Boot alkalmazás, amely bemutatja az OAuth2 használatát MCP-vel, mind mint Authorization, mind Resource Server. Biztonságos tokenkiadást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt mutat be. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root context-ek | Ismerd meg a root context fogalmát és megvalósítását |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Ismerd meg a különböző routing típusokat |
| [5.6 Sampling](./mcp-sampling/README.md) | Mintavételezés | Tanuld meg, hogyan dolgozz mintavételezéssel |
| [5.7 Scaling](./mcp-scaling/README.md) | Skálázás | Ismerd meg a skálázás alapjait |
| [5.8 Security](./mcp-security/README.md) | Biztonság | Biztosítsd MCP szerveredet |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP szerver és kliens, amely integrálja a SerpAPI-t valós idejű webes, hírek, termékkeresés és kérdés-válasz funkciókhoz. Bemutatja a többeszközös koordinációt, külső API integrációt és robusztus hibakezelést. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | A valós idejű adatfolyam kulcsfontosságú a mai adatvezérelt világban, ahol az üzletek és alkalmazások azonnali információhoz jutnak a gyors döntéshozatal érdekében. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Valós idejű webes keresés – hogyan alakítja át az MCP a valós idejű webes keresést azáltal, hogy egységes megközelítést kínál a kontextuskezeléshez AI modellek, keresőmotorok és alkalmazások között. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID hitelesítés | A Microsoft Entra ID egy megbízható, felhőalapú identitás- és hozzáférés-kezelési megoldás, amely biztosítja, hogy csak jogosult felhasználók és alkalmazások férhessenek hozzá az MCP szerveredhez. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry integráció | Tanuld meg, hogyan integrálhatók az MCP szerverek az Azure AI Foundry ügynökeivel, lehetővé téve a hatékony eszközkoordinációt és a vállalati AI képességeket szabványosított külső adatforrás kapcsolatokkal. |

## További hivatkozások

A legfrissebb információkért a fejlett MCP témákról, tekintsd meg:
- [MCP Dokumentáció](https://modelcontextprotocol.io/)
- [MCP Specifikáció](https://spec.modelcontextprotocol.io/)
- [GitHub tárhely](https://github.com/modelcontextprotocol)

## Főbb tanulságok

- A multimodális MCP megvalósítások az AI képességeit a szövegfeldolgozáson túl is kiterjesztik
- A skálázhatóság elengedhetetlen a vállalati telepítésekhez, és vízszintes és függőleges skálázással érhető el
- Átfogó biztonsági intézkedések védik az adatokat és biztosítják a megfelelő hozzáférés-ellenőrzést
- A vállalati integráció olyan platformokkal, mint az Azure OpenAI és a Microsoft AI Foundry, tovább növeli az MCP képességeit
- A fejlett MCP megvalósítások optimalizált architektúrákból és gondos erőforrás-kezelésből profitálnak

## Gyakorlat

Tervezzen egy vállalati szintű MCP megvalósítást egy konkrét felhasználási esetre:

1. Határozd meg a multimodális követelményeket az adott esetre
2. Vázold fel a biztonsági intézkedéseket az érzékeny adatok védelmére
3. Tervezd meg a skálázható architektúrát, amely képes kezelni a változó terhelést
4. Tervezd meg az integrációs pontokat a vállalati AI rendszerekkel
5. Dokumentáld a lehetséges teljesítménybeli szűk keresztmetszeteket és azok kezelési stratégiáit

## További források

- [Azure OpenAI dokumentáció](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry dokumentáció](https://learn.microsoft.com/en-us/ai-services/)

---

## Mi következik

- [5.1 MCP integráció](./mcp-integration/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.