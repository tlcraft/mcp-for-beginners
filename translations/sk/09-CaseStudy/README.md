<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "23899e82d806f25e5e46e89aab564dca",
  "translation_date": "2025-06-13T21:29:04+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sk"
}
-->
# MCP v praxi: Skutočné prípadové štúdie

Model Context Protocol (MCP) mení spôsob, akým AI aplikácie komunikujú s dátami, nástrojmi a službami. Táto časť predstavuje skutočné prípadové štúdie, ktoré ukazujú praktické využitie MCP v rôznych podnikových scenároch.

## Prehľad

Táto sekcia ukazuje konkrétne príklady implementácií MCP a zdôrazňuje, ako organizácie využívajú tento protokol na riešenie zložitých obchodných výziev. Preskúmaním týchto prípadových štúdií získate pohľad na všestrannosť, škálovateľnosť a praktické výhody MCP v reálnych situáciách.

## Kľúčové vzdelávacie ciele

Preskúmaním týchto prípadových štúdií budete:

- Rozumieť, ako možno MCP použiť na riešenie konkrétnych obchodných problémov
- Naučiť sa o rôznych integračných vzorcoch a architektonických prístupoch
- Spoznávať osvedčené postupy implementácie MCP v podnikových prostrediach
- Získať prehľad o výzvach a riešeniach, ktoré sa vyskytli pri reálnych implementáciách
- Identifikovať príležitosti na použitie podobných vzorcov vo vlastných projektoch

## Vybrané prípadové štúdie

### 1. [Azure AI Travel Agents – Referenčná implementácia](./travelagentsample.md)

Táto prípadová štúdia skúma komplexné referenčné riešenie od Microsoftu, ktoré demonštruje, ako vytvoriť multi-agentnú, AI-poháňanú aplikáciu na plánovanie ciest pomocou MCP, Azure OpenAI a Azure AI Search. Projekt predstavuje:

- Multi-agentnú orchestráciu cez MCP
- Integráciu podnikových dát s Azure AI Search
- Bezpečnú a škálovateľnú architektúru využívajúcu Azure služby
- Rozšíriteľné nástroje s opakovane použiteľnými MCP komponentmi
- Konverzačné používateľské rozhranie poháňané Azure OpenAI

Architektúra a detaily implementácie poskytujú cenné poznatky o budovaní zložitých multi-agentných systémov s MCP ako koordinačnou vrstvou.

### 2. [Aktualizácia Azure DevOps položiek z YouTube dát](./UpdateADOItemsFromYT.md)

Táto prípadová štúdia ukazuje praktické využitie MCP na automatizáciu pracovných procesov. Demonštruje, ako možno MCP nástroje použiť na:

- Extrahovanie dát z online platforiem (YouTube)
- Aktualizáciu pracovných položiek v Azure DevOps systémoch
- Vytváranie opakovateľných automatizačných pracovných tokov
- Integráciu dát medzi rôznymi systémami

Tento príklad ilustruje, že aj relatívne jednoduché implementácie MCP môžu priniesť výrazné zvýšenie efektivity automatizáciou rutinných úloh a zlepšením konzistencie dát naprieč systémami.

## Záver

Tieto prípadové štúdie zdôrazňujú všestrannosť a praktické využitie Model Context Protocol v reálnych situáciách. Od zložitých multi-agentných systémov po cielene automatizované pracovné toky, MCP poskytuje štandardizovaný spôsob, ako prepojiť AI systémy s nástrojmi a dátami, ktoré potrebujú na vytváranie hodnoty.

Štúdiom týchto implementácií získate poznatky o architektonických vzorcoch, stratégiách implementácie a osvedčených postupoch, ktoré môžete aplikovať vo vlastných MCP projektoch. Príklady ukazujú, že MCP nie je len teoretický rámec, ale praktické riešenie skutočných obchodných výziev.

## Dodatočné zdroje

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.