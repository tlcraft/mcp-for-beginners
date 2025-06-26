<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:19:41+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sk"
}
-->
# Pokročilé témy v MCP

Táto kapitola sa venuje sérii pokročilých tém v implementácii Model Context Protocol (MCP), vrátane multimodálnej integrácie, škálovateľnosti, najlepších bezpečnostných postupov a integrácie do podnikového prostredia. Témy sú kľúčové pre vytváranie robustných a produkčne pripravených MCP aplikácií, ktoré dokážu splniť požiadavky moderných AI systémov.

## Prehľad

Táto lekcia skúma pokročilé koncepty implementácie Model Context Protocol, so zameraním na multimodálnu integráciu, škálovateľnosť, najlepšie bezpečnostné postupy a podnikové integrácie. Témy sú nevyhnutné pre tvorbu MCP aplikácií na produkčnej úrovni, ktoré zvládnu komplexné požiadavky v podnikových prostrediach.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Implementovať multimodálne schopnosti v rámci MCP frameworkov
- Navrhnúť škálovateľné MCP architektúry pre náročné scenáre
- Použiť najlepšie bezpečnostné postupy v súlade s bezpečnostnými princípmi MCP
- Integrovať MCP s podnikových AI systémami a frameworkmi
- Optimalizovať výkon a spoľahlivosť v produkčných prostrediach

## Lekcie a ukážkové projekty

| Odkaz | Názov | Popis |
|-------|--------|--------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrácia s Azure | Naučte sa, ako integrovať svoj MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Ukážky MCP multimodálnosti | Ukážky pre audio, obraz a multimodálne odpovede |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimálna Spring Boot aplikácia ukazujúca OAuth2 s MCP, ako Autorizačný a Resource Server. Demonštruje bezpečné vydávanie tokenov, chránené endpointy, nasadenie na Azure Container Apps a integráciu API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root kontexty | Viac o root kontexte a jeho implementácii |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Naučte sa rôzne typy routingu |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte sa pracovať so samplingom |
| [5.7 Scaling](./mcp-scaling/README.md) | Škálovanie | Naučte sa o škálovaní |
| [5.8 Security](./mcp-security/README.md) | Bezpečnosť | Zabezpečte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server a klient integrujúci SerpAPI pre vyhľadávanie na webe, v správach, produktoch a Q&A v reálnom čase. Ukazuje orchestráciu viacerých nástrojov, integráciu externých API a robustné spracovanie chýb. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming dát v reálnom čase sa stal nevyhnutnosťou v dnešnom dátovo orientovanom svete, kde firmy a aplikácie potrebujú okamžitý prístup k informáciám na rýchle rozhodovanie. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Ako MCP mení vyhľadávanie na webe v reálnom čase poskytovaním štandardizovaného prístupu k správe kontextu naprieč AI modelmi, vyhľadávačmi a aplikáciami. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authentication | Microsoft Entra ID poskytuje robustné cloudové riešenie pre správu identity a prístupov, ktoré zabezpečuje, že iba autorizovaní používatelia a aplikácie môžu komunikovať s vaším MCP serverom. |

## Ďalšie odkazy

Pre najaktuálnejšie informácie o pokročilých témach MCP sa pozrite na:
- [MCP Dokumentácia](https://modelcontextprotocol.io/)
- [MCP Špecifikácia](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Kľúčové poznatky

- Multimodálne implementácie MCP rozširujú AI schopnosti nad rámec spracovania textu
- Škálovateľnosť je nevyhnutná pre podnikové nasadenia a rieši sa horizontálnym aj vertikálnym škálovaním
- Komplexné bezpečnostné opatrenia chránia dáta a zabezpečujú správnu kontrolu prístupu
- Podniková integrácia s platformami ako Azure OpenAI a Microsoft AI Foundry rozširuje možnosti MCP
- Pokročilé implementácie MCP profitujú z optimalizovaných architektúr a starostlivého manažmentu zdrojov

## Cvičenie

Navrhnite podnikový MCP systém pre konkrétny prípad použitia:

1. Identifikujte multimodálne požiadavky pre váš prípad použitia
2. Nastavte bezpečnostné kontroly na ochranu citlivých dát
3. Navrhnite škálovateľnú architektúru schopnú zvládnuť rôzne záťaže
4. Naplánujte integračné body s podnikových AI systémami
5. Zdokumentujte možné výkonnostné úzke miesta a stratégie ich riešenia

## Ďalšie zdroje

- [Azure OpenAI Dokumentácia](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentácia](https://learn.microsoft.com/en-us/ai-services/)

---

## Čo ďalej

- [5.1 MCP Integration](./mcp-integration/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, majte prosím na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.