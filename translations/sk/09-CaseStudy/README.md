<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T14:05:34+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sk"
}
-->
# MCP v praxi: Prípadové štúdie zo skutočného sveta

Model Context Protocol (MCP) mení spôsob, akým AI aplikácie komunikujú s dátami, nástrojmi a službami. Táto časť predstavuje prípadové štúdie zo skutočného sveta, ktoré ukazujú praktické využitie MCP v rôznych podnikových scenároch.

## Prehľad

V tejto sekcii nájdete konkrétne príklady implementácií MCP, ktoré zdôrazňujú, ako organizácie využívajú tento protokol na riešenie zložitých obchodných výziev. Štúdium týchto prípadových štúdií vám poskytne prehľad o všestrannosti, škálovateľnosti a praktických výhodách MCP v reálnych situáciách.

## Hlavné ciele učenia

Preskúmaním týchto prípadových štúdií budete:

- Rozumieť tomu, ako možno MCP použiť na riešenie konkrétnych obchodných problémov
- Naučiť sa rôzne integračné vzory a architektonické prístupy
- Spoznávať osvedčené postupy implementácie MCP v podnikových prostrediach
- Získať poznatky o výzvach a riešeniach, ktoré sa vyskytli pri reálnych implementáciách
- Identifikovať príležitosti na použitie podobných vzorov vo vlastných projektoch

## Predstavené prípadové štúdie

### 1. [Azure AI Travel Agents – Referenčná implementácia](./travelagentsample.md)

Táto prípadová štúdia skúma komplexné referenčné riešenie Microsoftu, ktoré demonštruje, ako vytvoriť viacagentovú AI aplikáciu na plánovanie ciest pomocou MCP, Azure OpenAI a Azure AI Search. Projekt ukazuje:

- Orchestráciu viacerých agentov cez MCP
- Integráciu podnikových dát s Azure AI Search
- Bezpečnú a škálovateľnú architektúru využívajúcu Azure služby
- Rozšíriteľné nástroje s opakovane použiteľnými MCP komponentmi
- Konverzačný používateľský zážitok poháňaný Azure OpenAI

Architektúra a detaily implementácie poskytujú cenné poznatky o budovaní zložitých viacagentových systémov s MCP ako koordinačnou vrstvou.

### 2. [Aktualizácia položiek Azure DevOps z údajov YouTube](./UpdateADOItemsFromYT.md)

Táto prípadová štúdia ukazuje praktické využitie MCP na automatizáciu pracovných procesov. Demonštruje, ako možno nástroje MCP použiť na:

- Extrahovanie dát z online platforiem (YouTube)
- Aktualizáciu pracovných položiek v systémoch Azure DevOps
- Vytvorenie opakovateľných automatizačných pracovných tokov
- Integráciu dát naprieč rôznorodými systémami

Tento príklad ilustruje, ako aj relatívne jednoduché implementácie MCP môžu priniesť výrazné zlepšenie efektivity automatizáciou rutinných úloh a zlepšením konzistencie dát medzi systémami.

### 3. [Získavanie dokumentácie v reálnom čase pomocou MCP](./docs-mcp/README.md)

Táto prípadová štúdia vás prevedie pripojením Python konzolového klienta k MCP serveru na získavanie a zaznamenávanie aktuálnej, kontextovo relevantnej Microsoft dokumentácie v reálnom čase. Naučíte sa, ako:

- Pripojiť sa k MCP serveru pomocou Python klienta a oficiálneho MCP SDK
- Použiť streaming HTTP klientov na efektívne získavanie dát v reálnom čase
- Volat nástroje na dokumentáciu na serveri a zaznamenávať odpovede priamo do konzoly
- Integrovať aktuálnu Microsoft dokumentáciu do vášho pracovného toku bez opustenia terminálu

Kapitola obsahuje praktické zadanie, minimálny funkčný ukážkový kód a odkazy na ďalšie zdroje pre hlbšie štúdium. Kompletný návod a kód nájdete v prepojenej kapitole, kde uvidíte, ako MCP môže zmeniť prístup k dokumentácii a zvýšiť produktivitu vývojárov v konzolovom prostredí.

### 4. [Interaktívny generátor študijných plánov – webová aplikácia s MCP](./docs-mcp/README.md)

Táto prípadová štúdia ukazuje, ako vytvoriť interaktívnu webovú aplikáciu pomocou Chainlit a Model Context Protocol (MCP) na generovanie personalizovaných študijných plánov pre ľubovoľnú tému. Používatelia môžu zadať predmet (napr. "certifikácia AI-900") a dobu štúdia (napr. 8 týždňov), pričom aplikácia poskytne rozpis odporúčaného obsahu týždeň po týždni. Chainlit umožňuje konverzačné chat rozhranie, ktoré robí zážitok pútavým a prispôsobivým.

- Konverzačná webová aplikácia poháňaná Chainlit
- Používateľom riadené vstupy pre tému a dĺžku štúdia
- Odporúčania obsahu týždeň po týždni pomocou MCP
- Adaptívne odpovede v reálnom čase v chat rozhraní

Projekt ukazuje, ako možno kombinovať konverzačnú AI a MCP na vytvorenie dynamických, používateľom riadených vzdelávacích nástrojov v modernom webovom prostredí.

### 5. [Dokumentácia priamo v editore s MCP serverom vo VS Code](./docs-mcp/README.md)

Táto prípadová štúdia ukazuje, ako si môžete priniesť Microsoft Learn Docs priamo do prostredia VS Code pomocou MCP servera – už žiadne prepínanie kariet v prehliadači! Ukáže vám, ako:

- Okamžite vyhľadávať a čítať dokumentáciu priamo vo VS Code pomocou MCP panelu alebo príkazovej palety
- Odkazovať na dokumentáciu a vkladať odkazy priamo do README alebo markdown súborov kurzov
- Používať GitHub Copilot a MCP spoločne pre bezproblémové AI-poháňané pracovné toky s dokumentáciou a kódom
- Overovať a vylepšovať dokumentáciu s reálnou spätnou väzbou a presnosťou od Microsoftu
- Integrovať MCP s GitHub pracovnými tokmi pre kontinuálnu validáciu dokumentácie

Implementácia obsahuje:
- Príklad konfigurácie `.vscode/mcp.json` pre jednoduché nastavenie
- Návody so screenshotmi z prostredia editora
- Tipy na kombinovanie Copilota a MCP pre maximálnu produktivitu

Tento scenár je ideálny pre autorov kurzov, tvorcov dokumentácie a vývojárov, ktorí chcú zostať sústredení v editore pri práci s dokumentáciou, Copilotom a nástrojmi na validáciu – všetko poháňané MCP.

## Záver

Tieto prípadové štúdie zdôrazňujú všestrannosť a praktické využitie Model Context Protocol v reálnych situáciách. Od zložitých viacagentových systémov po cielené automatizačné pracovné toky, MCP poskytuje štandardizovaný spôsob, ako prepojiť AI systémy s nástrojmi a dátami, ktoré potrebujú na poskytovanie hodnoty.

Štúdiom týchto implementácií môžete získať poznatky o architektonických vzoroch, stratégiách implementácie a osvedčených postupoch, ktoré môžete aplikovať vo vlastných MCP projektoch. Príklady dokazujú, že MCP nie je len teoretický rámec, ale praktické riešenie reálnych obchodných výziev.

## Dodatočné zdroje

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.