<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T16:15:16+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "hu"
}
-->
# Haladó témák az MCP-ben

Ez a fejezet a Model Context Protocol (MCP) megvalósításának haladó témáit tárgyalja, beleértve a multimodális integrációt, skálázhatóságot, biztonsági legjobb gyakorlatokat és vállalati integrációt. Ezek a témák elengedhetetlenek ahhoz, hogy robosztus és éles környezetben használható MCP alkalmazásokat építsünk, amelyek megfelelnek a modern AI rendszerek követelményeinek.

## Áttekintés

Ebben a leckében az MCP megvalósításának haladó fogalmait vizsgáljuk, különös tekintettel a multimodális integrációra, skálázhatóságra, biztonsági legjobb gyakorlatokra és vállalati integrációra. Ezek a témák kulcsfontosságúak a termelési szintű MCP alkalmazások kialakításához, amelyek képesek kezelni az összetett követelményeket vállalati környezetben.

## Tanulási célok

A lecke végére képes leszel:

- Megvalósítani multimodális képességeket MCP keretrendszerekben
- Skálázható MCP architektúrákat tervezni magas terhelésű helyzetekre
- Alkalmazni az MCP biztonsági elveinek megfelelő legjobb biztonsági gyakorlatokat
- Integrálni az MCP-t vállalati AI rendszerekkel és keretrendszerekkel
- Optimalizálni a teljesítményt és megbízhatóságot éles környezetben

## Leckék és mintaprojektek

| Link | Cím | Leírás |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integráció Azure-rel | Ismerd meg, hogyan integrálhatod MCP szerveredet Azure környezetbe |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodális minták | Minták hang-, kép- és multimodális válaszokra |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimális Spring Boot alkalmazás, amely bemutatja az OAuth2 használatát MCP-vel, mint Authorization és Resource Server. Biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt mutat be. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root context-ek | Tudj meg többet a root context-ről és annak megvalósításáról |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Ismerd meg a routing különböző típusait |
| [5.6 Sampling](./mcp-sampling/README.md) | Mintavételezés | Tanuld meg, hogyan dolgozhatsz mintavételezéssel |
| [5.7 Scaling](./mcp-scaling/README.md) | Skálázás | Ismerd meg a skálázás alapjait |
| [5.8 Security](./mcp-security/README.md) | Biztonság | Biztonságossá teheted MCP szerveredet |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP szerver és kliens, amely integrálja a SerpAPI-t valós idejű webes, hírek, termékkeresés és kérdés-válasz funkciókhoz. Bemutatja a többeszközös összehangolást, külső API integrációt és robosztus hibakezelést. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | A valós idejű adatfolyam mára elengedhetetlenné vált az adatalapú világban, ahol a vállalkozások és alkalmazások azonnali hozzáférést igényelnek az információkhoz a gyors döntéshozatal érdekében. |

## További hivatkozások

A legfrissebb információkért az MCP haladó témáiról tekintsd meg:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Főbb tanulságok

- A multimodális MCP megvalósítások kiterjesztik az AI képességeket a szöveges feldolgozáson túl
- A skálázhatóság alapvető a vállalati telepítésekhez, és vízszintes vagy függőleges skálázással érhető el
- Átfogó biztonsági intézkedések védik az adatokat és biztosítják a megfelelő hozzáférés-ellenőrzést
- A vállalati integráció platformokkal, mint az Azure OpenAI és a Microsoft AI Foundry, növeli az MCP képességeit
- A haladó MCP megvalósítások előnyösek az optimalizált architektúrákból és a gondos erőforrás-kezelésből

## Gyakorlat

Tervezd meg egy vállalati szintű MCP megvalósítását egy konkrét esetre:

1. Határozd meg a multimodális követelményeket az esetedhez
2. Vázold fel a biztonsági intézkedéseket az érzékeny adatok védelmére
3. Tervezd meg a skálázható architektúrát, amely képes kezelni a változó terhelést
4. Tervezd meg az integrációs pontokat vállalati AI rendszerekkel
5. Dokumentáld a lehetséges teljesítménybeli szűk keresztmetszeteket és a megoldási stratégiákat

## További források

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Mi következik

- [5.1 MCP Integration](./mcp-integration/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk. Bár igyekszünk pontos fordítást biztosítani, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.