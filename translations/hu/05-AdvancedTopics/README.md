<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:27:03+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hu"
}
-->
# Haladó témák az MCP-ben

Ez a fejezet a Model Context Protocol (MCP) megvalósításának számos haladó témáját tárgyalja, beleértve a multimodális integrációt, skálázhatóságot, biztonsági legjobb gyakorlatokat és vállalati integrációt. Ezek a témák elengedhetetlenek ahhoz, hogy megbízható és éles környezetben használható MCP alkalmazásokat építsünk, amelyek megfelelnek a modern AI rendszerek követelményeinek.

## Áttekintés

Ebben a leckében az MCP megvalósításának haladó koncepcióit vizsgáljuk, különös tekintettel a multimodális integrációra, skálázhatóságra, biztonsági legjobb gyakorlatokra és vállalati integrációra. Ezek a témák alapvetőek olyan MCP alkalmazások fejlesztéséhez, amelyek képesek kezelni a vállalati környezetek összetett igényeit.

## Tanulási célok

A lecke végére képes leszel:

- Megvalósítani multimodális képességeket MCP keretrendszerekben
- Tervezni skálázható MCP architektúrákat nagy igényű helyzetekhez
- Alkalmazni az MCP biztonsági elveivel összhangban álló legjobb biztonsági gyakorlatokat
- Integrálni az MCP-t vállalati AI rendszerekkel és keretrendszerekkel
- Optimalizálni a teljesítményt és megbízhatóságot éles környezetben

## Leckék és mintaprojektek

| Link | Cím | Leírás |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integráció Azure-rel | Tanuld meg, hogyan integrálhatod MCP szerveredet az Azure platformon |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodális minták | Minták hang-, kép- és multimodális válaszokra |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimális Spring Boot alkalmazás, amely bemutatja az OAuth2 használatát MCP-vel, mint Authorization és Resource Server. Biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt szemléltet. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root context-ek | Ismerd meg jobban a root context fogalmát és megvalósítását |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Ismerd meg a különböző routing típusokat |
| [5.6 Sampling](./mcp-sampling/README.md) | Mintavételezés | Tanuld meg, hogyan dolgozz mintavételezéssel |
| [5.7 Scaling](./mcp-scaling/README.md) | Skálázás | Ismerd meg a skálázás alapjait |
| [5.8 Security](./mcp-security/README.md) | Biztonság | Biztosítsd MCP szervered biztonságát |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP szerver és kliens, amely integrálja a SerpAPI-t valós idejű webes, hírek, termék kereséshez és kérdés-válasz funkcióhoz. Bemutatja a többeszközös koordinációt, külső API integrációt és robusztus hibakezelést. |

## További hivatkozások

A legfrissebb információkért a haladó MCP témákról, tekintsd meg a következőket:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Főbb tanulságok

- A multimodális MCP megvalósítások az AI képességeit a szövegfeldolgozáson túl is kiterjesztik
- A skálázhatóság elengedhetetlen a vállalati bevezetéseknél, amelyet vízszintes és függőleges skálázással lehet megoldani
- Átfogó biztonsági intézkedések védik az adatokat és biztosítják a megfelelő hozzáférés-ellenőrzést
- A vállalati integráció olyan platformokkal, mint az Azure OpenAI és a Microsoft AI Foundry, tovább erősíti az MCP képességeit
- A haladó MCP megvalósítások előnyét élvezik az optimalizált architektúrák és a gondos erőforrás-kezelés

## Gyakorlat

Tervezzen vállalati szintű MCP megvalósítást egy konkrét esetre:

1. Határozd meg a multimodális követelményeket az esetedhez
2. Vázold fel a biztonsági intézkedéseket az érzékeny adatok védelmére
3. Tervezd meg a skálázható architektúrát, amely képes kezelni a változó terhelést
4. Tervezd meg az integrációs pontokat vállalati AI rendszerekkel
5. Dokumentáld a potenciális teljesítménybeli szűk keresztmetszeteket és azok enyhítési stratégiáit

## További források

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Mi következik

- [5.1 MCP Integration](./mcp-integration/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvű változata tekintendő hiteles forrásnak. Kritikus információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy helytelen értelmezésekért.