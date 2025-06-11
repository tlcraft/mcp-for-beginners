<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T16:20:49+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sk"
}
-->
# Pokročilé témy v MCP

Táto kapitola je určená na pokrytie série pokročilých tém v implementácii Model Context Protocol (MCP), vrátane multimodálnej integrácie, škálovateľnosti, bezpečnostných najlepších praktík a podnikovej integrácie. Tieto témy sú kľúčové pre vytváranie robustných a produkčne pripravených MCP aplikácií, ktoré dokážu vyhovieť požiadavkám moderných AI systémov.

## Prehľad

Táto lekcia skúma pokročilé koncepty implementácie Model Context Protocol, so zameraním na multimodálnu integráciu, škálovateľnosť, bezpečnostné najlepšie praktiky a podnikové prepojenie. Tieto témy sú nevyhnutné pre budovanie produkčných MCP aplikácií, ktoré zvládnu zložité požiadavky v podnikových prostrediach.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Implementovať multimodálne schopnosti v rámci MCP frameworkov
- Navrhnúť škálovateľné MCP architektúry pre scénare s vysokou záťažou
- Použiť bezpečnostné najlepšie praktiky v súlade s bezpečnostnými princípmi MCP
- Integrovať MCP s podnikových AI systémami a frameworkmi
- Optimalizovať výkon a spoľahlivosť v produkčnom prostredí

## Lekcie a ukážkové projekty

| Link | Názov | Popis |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrácia s Azure | Naučte sa, ako integrovať váš MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodálne ukážky | Ukážky pre audio, obrázky a multimodálne odpovede |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimálna Spring Boot aplikácia ukazujúca OAuth2 s MCP, ako Autorizačný aj Resource Server. Demonštruje bezpečné vydávanie tokenov, chránené endpointy, nasadenie v Azure Container Apps a integráciu API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root kontexty | Naučte sa viac o root kontexte a jeho implementácii |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Spoznajte rôzne typy routingu |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte sa pracovať so samplingom |
| [5.7 Scaling](./mcp-scaling/README.md) | Škálovanie | Naučte sa o škálovaní |
| [5.8 Security](./mcp-security/README.md) | Bezpečnosť | Zabezpečte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server a klient integrujúci SerpAPI pre vyhľadávanie na webe, v správach, produktoch a Q&A v reálnom čase. Ukazuje orchestráciu viacerých nástrojov, integráciu externých API a robustné spracovanie chýb. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streamovanie dát v reálnom čase sa stalo nevyhnutnosťou v dnešnom dátovo orientovanom svete, kde firmy a aplikácie potrebujú okamžitý prístup k informáciám pre rýchle rozhodovanie. |

## Dodatočné odkazy

Pre najaktuálnejšie informácie o pokročilých témach MCP, pozrite si:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Kľúčové body

- Multimodálne implementácie MCP rozširujú AI schopnosti nad rámec spracovania textu
- Škálovateľnosť je nevyhnutná pre podnikové nasadenia a rieši sa horizontálnym a vertikálnym škálovaním
- Komplexné bezpečnostné opatrenia chránia dáta a zabezpečujú správnu kontrolu prístupu
- Podniková integrácia s platformami ako Azure OpenAI a Microsoft AI Foundry rozširuje schopnosti MCP
- Pokročilé implementácie MCP profitujú z optimalizovaných architektúr a dôkladného manažmentu zdrojov

## Cvičenie

Navrhnite podnikový MCP systém pre konkrétny prípad použitia:

1. Identifikujte multimodálne požiadavky pre váš prípad použitia
2. Nastavte bezpečnostné kontroly na ochranu citlivých dát
3. Navrhnite škálovateľnú architektúru, ktorá zvládne rôzne záťaže
4. Naplánujte integračné body s podnikových AI systémami
5. Zdokumentujte možné výkonnostné úzke miesta a stratégie ich riešenia

## Dodatočné zdroje

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Čo bude ďalej

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.