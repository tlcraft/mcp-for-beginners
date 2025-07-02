<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:49:21+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hu"
}
-->
# Haladó témák az MCP-ben

Ez a fejezet az Model Context Protocol (MCP) megvalósításának haladó témaköreit tárgyalja, beleértve a többmodalitás integrációját, skálázhatóságot, biztonsági legjobb gyakorlatokat és vállalati integrációt. Ezek a témák kulcsfontosságúak ahhoz, hogy megbízható és éles környezetben használható MCP alkalmazásokat építsünk, amelyek megfelelnek a modern AI rendszerek igényeinek.

## Áttekintés

Ebben a leckében az MCP megvalósításának haladó fogalmait vizsgáljuk meg, különös tekintettel a többmodalitás integrációjára, skálázhatóságra, biztonsági legjobb gyakorlatokra és vállalati integrációra. Ezek a témák elengedhetetlenek ahhoz, hogy olyan MCP alkalmazásokat hozzunk létre, amelyek képesek kezelni a bonyolult követelményeket vállalati környezetben.

## Tanulási célok

A lecke végére képes leszel:

- Többmodalitás funkciókat megvalósítani MCP keretrendszerekben
- Skálázható MCP architektúrákat tervezni nagy terhelésű helyzetekre
- Alkalmazni az MCP biztonsági elveivel összhangban álló legjobb biztonsági gyakorlatokat
- Integrálni az MCP-t vállalati AI rendszerekkel és keretrendszerekkel
- Optimalizálni a teljesítményt és megbízhatóságot éles környezetben

## Leckék és mintaprojektek

| Link | Cím | Leírás |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integráció Azure-rel | Ismerd meg, hogyan integrálhatod MCP szerveredet az Azure platformmal |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP többmodalitás minták | Minták hang, kép és többmodalitású válaszokhoz |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 demó | Minimális Spring Boot alkalmazás, amely bemutatja az OAuth2 használatát MCP-vel, mind hitelesítő, mind erőforrás szerverként. Biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt mutat be. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root context-ek | Ismerd meg a root context-eket és azok megvalósítását |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Tanuld meg a különböző routing típusokat |
| [5.6 Sampling](./mcp-sampling/README.md) | Mintavételezés | Ismerd meg, hogyan kell dolgozni mintavételezéssel |
| [5.7 Scaling](./mcp-scaling/README.md) | Skálázás | Tanuld meg a skálázás alapjait |
| [5.8 Security](./mcp-security/README.md) | Biztonság | Biztosítsd MCP szerveredet |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web keresés MCP | Python MCP szerver és kliens, amely a SerpAPI-val integrálva valós idejű webes, hírek, termék keresést és kérdés-válasz funkciókat biztosít. Bemutatja a többeszközös koordinációt, külső API integrációt és megbízható hibakezelést. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | A valós idejű adatfolyam ma már elengedhetetlen a gyors döntéshozatalt igénylő üzleti és alkalmazási környezetekben. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web keresés | Valós idejű webes keresés: hogyan alakítja át az MCP a valós idejű webes keresést azáltal, hogy szabványosított kontextuskezelést biztosít AI modellek, keresőmotorok és alkalmazások között. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID hitelesítés | A Microsoft Entra ID egy megbízható felhőalapú identitás- és hozzáférés-kezelő megoldás, amely biztosítja, hogy csak jogosult felhasználók és alkalmazások férhessenek hozzá az MCP szerveredhez. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry integráció | Tanuld meg, hogyan integráld az MCP szervereket az Azure AI Foundry ügynökeivel, lehetővé téve a hatékony eszközkoordinációt és vállalati AI képességeket szabványosított külső adatforrás kapcsolatokkal. |

## További hivatkozások

A legfrissebb információkért az MCP haladó témáiról tekintsd meg a következőket:
- [MCP dokumentáció](https://modelcontextprotocol.io/)
- [MCP specifikáció](https://spec.modelcontextprotocol.io/)
- [GitHub tárhely](https://github.com/modelcontextprotocol)

## Főbb tanulságok

- A többmodalitású MCP megvalósítások túlmutatnak a szövegfeldolgozáson és kibővítik az AI képességeit
- A skálázhatóság elengedhetetlen a vállalati alkalmazásokhoz, mely vízszintes és függőleges skálázással érhető el
- Átfogó biztonsági intézkedések védik az adatokat és biztosítják a megfelelő hozzáférés-szabályozást
- A vállalati integráció olyan platformokkal, mint az Azure OpenAI és a Microsoft AI Foundry, tovább növeli az MCP képességeit
- A haladó MCP megvalósítások előnyösek az optimalizált architektúrák és a gondos erőforrás-kezelés révén

## Gyakorlat

Tervezzen egy vállalati szintű MCP megvalósítást egy konkrét felhasználási esetre:

1. Határozd meg a többmodalitású követelményeket az esetedhez
2. Vázold fel a biztonsági intézkedéseket az érzékeny adatok védelmére
3. Tervezd meg a skálázható architektúrát, amely képes kezelni a változó terhelést
4. Tervezd meg az integrációs pontokat vállalati AI rendszerekkel
5. Dokumentáld a lehetséges teljesítménybeli szűk keresztmetszeteket és azok kezelési stratégiáit

## További források

- [Azure OpenAI dokumentáció](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry dokumentáció](https://learn.microsoft.com/en-us/ai-services/)

---

## Mi következik

- [5.1 MCP Integráció](./mcp-integration/README.md)

**Nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum a saját nyelvén tekintendő hivatalos forrásnak. Fontos információk esetén javasolt szakmai emberi fordítást igénybe venni. Nem vállalunk felelősséget az ezen fordítás használatából eredő félreértésekért vagy félreértelmezésekért.