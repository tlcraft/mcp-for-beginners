<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-13T00:51:05+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hu"
}
-->
# Haladó témakörök az MCP-ben

Ez a fejezet a Model Context Protocol (MCP) megvalósításának haladó témáit tárgyalja, beleértve a multimodális integrációt, skálázhatóságot, biztonsági legjobb gyakorlatokat és vállalati integrációt. Ezek a témák kulcsfontosságúak ahhoz, hogy robusztus és éles környezetben is használható MCP alkalmazásokat építsünk, amelyek megfelelnek a modern mesterséges intelligencia rendszerek igényeinek.

## Áttekintés

Ez a lecke a Model Context Protocol megvalósításának haladó koncepcióit vizsgálja, különös tekintettel a multimodális integrációra, skálázhatóságra, biztonsági legjobb gyakorlatokra és vállalati integrációra. Ezek a témák elengedhetetlenek olyan MCP alkalmazások létrehozásához, amelyek képesek kezelni a vállalati környezetek összetett követelményeit.

## Tanulási célok

A lecke végére képes leszel:

- Megvalósítani multimodális képességeket MCP keretrendszerekben
- Tervezni skálázható MCP architektúrákat nagy terhelésű helyzetekre
- Alkalmazni a MCP biztonsági elveivel összhangban álló legjobb biztonsági gyakorlatokat
- Integrálni az MCP-t vállalati AI rendszerekkel és keretrendszerekkel
- Optimalizálni a teljesítményt és megbízhatóságot éles környezetben

## Leckék és mintaprojektek

| Link | Cím | Leírás |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integráció Azure-rel | Tanuld meg, hogyan integráld MCP szerveredet Azure környezetbe |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodális minták | Minták hang-, kép- és multimodális válaszokhoz |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Egy egyszerű Spring Boot alkalmazás, amely bemutatja az OAuth2 használatát MCP-vel, mint hitelesítési és erőforrás szerver. Biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt mutat be. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root context-ek | Tudj meg többet a root context-ről és annak megvalósításáról |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Ismerd meg a különböző routing típusokat |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Tanuld meg, hogyan dolgozz samplinggel |
| [5.7 Scaling](./mcp-scaling/README.md) | Skálázás | Ismerd meg a skálázás lehetőségeit |
| [5.8 Security](./mcp-security/README.md) | Biztonság | Biztosítsd MCP szerveredet |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP szerver és kliens, amely integrálja a SerpAPI-t valós idejű webes, hírek, termékkeresés és kérdés-válasz funkciókhoz. Bemutatja a többeszközös együttműködést, külső API integrációt és robusztus hibakezelést. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | A valós idejű adatfolyam egyre fontosabb a mai adatvezérelt világban, ahol a vállalkozásoknak és alkalmazásoknak azonnali hozzáférésre van szükségük az információkhoz a gyors döntéshozatal érdekében. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Valós idejű webes keresés – hogyan alakítja át az MCP a valós idejű webes keresést azáltal, hogy egységes megközelítést nyújt a kontextuskezeléshez AI modellek, keresőmotorok és alkalmazások között. |

## További hivatkozások

A legfrissebb információkért a haladó MCP témákról, tekintsd meg:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Főbb tanulságok

- A multimodális MCP megvalósítások túlmutatnak a szövegfeldolgozáson és kibővítik az AI képességeit
- A skálázhatóság alapvető a vállalati bevezetéseknél, és vízszintes, valamint függőleges skálázással érhető el
- Átfogó biztonsági intézkedések védik az adatokat és biztosítják a megfelelő hozzáférés-ellenőrzést
- A vállalati integráció olyan platformokkal, mint az Azure OpenAI és a Microsoft AI Foundry, tovább növeli az MCP képességeit
- A haladó MCP megvalósítások előnyösek az optimalizált architektúrák és a gondos erőforrás-kezelés révén

## Gyakorlat

Tervezzen egy vállalati szintű MCP megvalósítást egy konkrét felhasználási esetre:

1. Határozd meg a multimodális követelményeket az adott esetre
2. Vázold fel az érzékeny adatok védelméhez szükséges biztonsági intézkedéseket
3. Tervezd meg a skálázható architektúrát, amely képes kezelni a változó terhelést
4. Tervezd meg az integrációs pontokat vállalati AI rendszerekkel
5. Dokumentáld a lehetséges teljesítménybeli szűk keresztmetszeteket és azok kezelési stratégiáit

## További források

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Mi következik

- [5.1 MCP Integration](./mcp-integration/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.