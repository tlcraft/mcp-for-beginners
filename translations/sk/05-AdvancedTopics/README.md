<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1949cb32394aeb1bdec8870f309005a3",
  "translation_date": "2025-07-17T10:57:43+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sk"
}
-->
# Pokročilé témy v MCP

Táto kapitola sa zaoberá radom pokročilých tém v implementácii Model Context Protocol (MCP), vrátane multimodálnej integrácie, škálovateľnosti, najlepších bezpečnostných praktík a integrácie do podnikového prostredia. Tieto témy sú kľúčové pre vytváranie robustných a produkčne pripravených MCP aplikácií, ktoré dokážu splniť požiadavky moderných AI systémov.

## Prehľad

Táto lekcia skúma pokročilé koncepty implementácie Model Context Protocol, so zameraním na multimodálnu integráciu, škálovateľnosť, najlepšie bezpečnostné praktiky a integráciu do podnikového prostredia. Témy sú nevyhnutné pre tvorbu produkčných MCP aplikácií, ktoré zvládnu komplexné požiadavky v podnikových prostrediach.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Implementovať multimodálne schopnosti v rámci MCP frameworkov
- Navrhnúť škálovateľné MCP architektúry pre náročné scenáre
- Použiť najlepšie bezpečnostné praktiky v súlade s bezpečnostnými princípmi MCP
- Integrovať MCP s podnikových AI systémami a frameworkmi
- Optimalizovať výkon a spoľahlivosť v produkčnom prostredí

## Lekcie a ukážkové projekty

| Odkaz | Názov | Popis |
|-------|--------|--------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrácia s Azure | Naučte sa, ako integrovať váš MCP Server na Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodálne ukážky | Ukážky pre audio, obraz a multimodálne odpovede |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimálna Spring Boot aplikácia ukazujúca OAuth2 s MCP, ako Authorization a Resource Server. Demonštruje bezpečné vydávanie tokenov, chránené endpointy, nasadenie na Azure Container Apps a integráciu API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root kontexty | Viac o root kontexte a ako ich implementovať |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Naučte sa rôzne typy routingu |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Naučte sa pracovať so samplingom |
| [5.7 Scaling](./mcp-scaling/README.md) | Škálovanie | Naučte sa o škálovaní |
| [5.8 Security](./mcp-security/README.md) | Bezpečnosť | Zabezpečte svoj MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server a klient integrujúci SerpAPI pre vyhľadávanie na webe, v správach, produktoch a Q&A v reálnom čase. Demonštruje orchestráciu viacerých nástrojov, integráciu externých API a robustné spracovanie chýb. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming dát v reálnom čase sa stal nevyhnutným v dnešnom dátovo orientovanom svete, kde firmy a aplikácie potrebujú okamžitý prístup k informáciám pre včasné rozhodovanie. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Ako MCP mení vyhľadávanie na webe v reálnom čase tým, že poskytuje štandardizovaný prístup k správe kontextu naprieč AI modelmi, vyhľadávačmi a aplikáciami. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID autentifikácia | Microsoft Entra ID poskytuje robustné cloudové riešenie pre správu identity a prístupu, ktoré zabezpečuje, že len autorizovaní používatelia a aplikácie môžu komunikovať s vaším MCP serverom. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integrácia Azure AI Foundry | Naučte sa, ako integrovať Model Context Protocol servery s Azure AI Foundry agentmi, čo umožňuje výkonnú orchestráciu nástrojov a podnikové AI schopnosti so štandardizovanými pripojeniami na externé zdroje dát. |

## Ďalšie odkazy

Pre najaktuálnejšie informácie o pokročilých témach MCP navštívte:
- [MCP Dokumentácia](https://modelcontextprotocol.io/)
- [MCP Špecifikácia](https://spec.modelcontextprotocol.io/)
- [GitHub Repozitár](https://github.com/modelcontextprotocol)

## Kľúčové poznatky

- Multimodálne implementácie MCP rozširujú AI schopnosti nad rámec spracovania textu
- Škálovateľnosť je nevyhnutná pre podnikové nasadenia a rieši sa horizontálnym a vertikálnym škálovaním
- Komplexné bezpečnostné opatrenia chránia dáta a zabezpečujú správnu kontrolu prístupu
- Podniková integrácia s platformami ako Azure OpenAI a Microsoft AI Foundry rozširuje možnosti MCP
- Pokročilé MCP implementácie profitujú z optimalizovaných architektúr a starostlivého manažmentu zdrojov

## Cvičenie

Navrhnite podnikové MCP riešenie pre konkrétny prípad použitia:

1. Identifikujte multimodálne požiadavky pre váš prípad použitia
2. Načrtnite bezpečnostné opatrenia potrebné na ochranu citlivých dát
3. Navrhnite škálovateľnú architektúru, ktorá zvládne rôzne zaťaženie
4. Naplánujte integračné body s podnikových AI systémami
5. Zdokumentujte možné výkonnostné úzke miesta a stratégie ich riešenia

## Ďalšie zdroje

- [Azure OpenAI Dokumentácia](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Dokumentácia](https://learn.microsoft.com/en-us/ai-services/)

---

## Čo ďalej

- [5.1 MCP Integration](./mcp-integration/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.