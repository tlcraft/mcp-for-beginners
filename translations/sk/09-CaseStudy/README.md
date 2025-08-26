<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-19T15:52:05+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sk"
}
-->
# MCP v praxi: Prípadové štúdie z reálneho sveta

[![MCP v praxi: Prípadové štúdie z reálneho sveta](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.sk.png)](https://youtu.be/IxshWb2Az5w)

_(Kliknite na obrázok vyššie pre zobrazenie videa k tejto lekcii)_

Protokol Model Context Protocol (MCP) mení spôsob, akým aplikácie AI interagujú s dátami, nástrojmi a službami. Táto sekcia predstavuje prípadové štúdie z reálneho sveta, ktoré demonštrujú praktické aplikácie MCP v rôznych podnikových scenároch.

## Prehľad

Táto sekcia predstavuje konkrétne príklady implementácií MCP, ktoré zdôrazňujú, ako organizácie využívajú tento protokol na riešenie zložitých obchodných výziev. Preskúmaním týchto prípadových štúdií získate prehľad o všestrannosti, škálovateľnosti a praktických výhodách MCP v reálnych scenároch.

## Kľúčové ciele učenia

Preskúmaním týchto prípadových štúdií sa naučíte:

- Pochopiť, ako MCP môže byť aplikovaný na riešenie konkrétnych obchodných problémov
- Získať informácie o rôznych integračných vzoroch a architektonických prístupoch
- Rozpoznať osvedčené postupy pri implementácii MCP v podnikových prostrediach
- Získať prehľad o výzvach a riešeniach, ktoré sa objavili pri implementáciách v reálnom svete
- Identifikovať príležitosti na aplikáciu podobných vzorov vo vlastných projektoch

## Vybrané prípadové štúdie

### 1. [Azure AI Travel Agents – Referenčná implementácia](./travelagentsample.md)

Táto prípadová štúdia skúma komplexné referenčné riešenie od Microsoftu, ktoré demonštruje, ako vytvoriť multi-agentovú aplikáciu na plánovanie ciest poháňanú AI pomocou MCP, Azure OpenAI a Azure AI Search. Projekt zahŕňa:

- Orchestráciu viacerých agentov prostredníctvom MCP
- Integráciu podnikových dát s Azure AI Search
- Bezpečnú, škálovateľnú architektúru využívajúcu služby Azure
- Rozšíriteľné nástroje s opakovane použiteľnými komponentmi MCP
- Konverzačný používateľský zážitok poháňaný Azure OpenAI

Architektúra a detaily implementácie poskytujú cenné poznatky o budovaní komplexných systémov s viacerými agentmi, kde MCP slúži ako koordinačná vrstva.

### 2. [Aktualizácia položiek Azure DevOps z dát YouTube](./UpdateADOItemsFromYT.md)

Táto prípadová štúdia demonštruje praktickú aplikáciu MCP na automatizáciu pracovných procesov. Ukazuje, ako je možné MCP nástroje použiť na:

- Extrakciu dát z online platforiem (YouTube)
- Aktualizáciu pracovných položiek v systémoch Azure DevOps
- Vytváranie opakovateľných automatizačných pracovných tokov
- Integráciu dát medzi rôznymi systémami

Tento príklad ilustruje, ako aj relatívne jednoduché implementácie MCP môžu priniesť významné zlepšenia efektivity automatizáciou rutinných úloh a zlepšením konzistencie dát medzi systémami.

### 3. [Získavanie dokumentácie v reálnom čase pomocou MCP](./docs-mcp/README.md)

Táto prípadová štúdia vás prevedie pripojením Python konzolového klienta k serveru Model Context Protocol (MCP) na získavanie a zapisovanie dokumentácie Microsoftu v reálnom čase. Naučíte sa:

- Pripojiť sa k MCP serveru pomocou Python klienta a oficiálneho MCP SDK
- Používať streaming HTTP klientov na efektívne získavanie dát v reálnom čase
- Volať nástroje na dokumentáciu na serveri a zapisovať odpovede priamo do konzoly
- Integrovať aktuálnu dokumentáciu Microsoftu do svojho pracovného toku bez opustenia terminálu

Kapitola obsahuje praktické zadanie, minimálny funkčný vzorový kód a odkazy na ďalšie zdroje pre hlbšie učenie. Pozrite si kompletný návod a kód v prepojenej kapitole, aby ste pochopili, ako MCP môže transformovať prístup k dokumentácii a produktivitu vývojárov v prostredí konzoly.

### 4. [Interaktívna webová aplikácia na generovanie študijných plánov pomocou MCP](./docs-mcp/README.md)

Táto prípadová štúdia demonštruje, ako vytvoriť interaktívnu webovú aplikáciu pomocou Chainlit a Model Context Protocol (MCP) na generovanie personalizovaných študijných plánov pre akúkoľvek tému. Používatelia môžu špecifikovať predmet (napríklad "certifikácia AI-900") a trvanie štúdia (napr. 8 týždňov), a aplikácia poskytne týždenný rozpis odporúčaného obsahu. Chainlit umožňuje konverzačné rozhranie, ktoré robí zážitok pútavým a adaptívnym.

- Konverzačná webová aplikácia poháňaná Chainlit
- Používateľom riadené výzvy na tému a trvanie
- Týždenné odporúčania obsahu pomocou MCP
- Odozvy v reálnom čase v konverzačnom rozhraní

Projekt ilustruje, ako je možné kombinovať konverzačnú AI a MCP na vytvorenie dynamických, používateľom riadených vzdelávacích nástrojov v modernom webovom prostredí.

### 5. [Dokumentácia v editore s MCP serverom vo VS Code](./docs-mcp/README.md)

Táto prípadová štúdia demonštruje, ako môžete priniesť dokumentáciu Microsoft Learn Docs priamo do prostredia VS Code pomocou MCP servera—už žiadne prepínanie medzi záložkami prehliadača! Uvidíte, ako:

- Okamžite vyhľadávať a čítať dokumentáciu priamo vo VS Code pomocou MCP panelu alebo príkazovej palety
- Vkladať odkazy na dokumentáciu priamo do README alebo markdown súborov kurzu
- Používať GitHub Copilot a MCP spoločne na bezproblémové pracovné toky dokumentácie a kódu poháňané AI
- Validovať a zlepšovať dokumentáciu pomocou spätnej väzby v reálnom čase a presnosti zdrojov Microsoftu
- Integrovať MCP s GitHub pracovnými tokmi na kontinuálnu validáciu dokumentácie

Implementácia zahŕňa:

- Príklad konfigurácie `.vscode/mcp.json` pre jednoduché nastavenie
- Návody založené na snímkach obrazovky pre zážitok v editore
- Tipy na kombinovanie Copilot a MCP pre maximálnu produktivitu

Tento scenár je ideálny pre autorov kurzov, dokumentačných pracovníkov a vývojárov, ktorí chcú zostať sústredení vo svojom editore pri práci s dokumentáciou, Copilotom a validačnými nástrojmi—všetko poháňané MCP.

### 6. [Vytvorenie MCP servera pomocou APIM](./apimsample.md)

Táto prípadová štúdia poskytuje podrobný návod, ako vytvoriť MCP server pomocou Azure API Management (APIM). Zahŕňa:

- Nastavenie MCP servera v Azure API Management
- Zverejnenie operácií API ako MCP nástrojov
- Konfiguráciu politík pre obmedzenie rýchlosti a bezpečnosť
- Testovanie MCP servera pomocou Visual Studio Code a GitHub Copilot

Tento príklad ilustruje, ako využiť schopnosti Azure na vytvorenie robustného MCP servera, ktorý môže byť použitý v rôznych aplikáciách, čím sa zlepšuje integrácia AI systémov s podnikovými API.

## Záver

Tieto prípadové štúdie zdôrazňujú všestrannosť a praktické aplikácie Model Context Protocol v reálnych scenároch. Od komplexných systémov s viacerými agentmi až po cielené automatizačné pracovné toky, MCP poskytuje štandardizovaný spôsob, ako prepojiť AI systémy s nástrojmi a dátami, ktoré potrebujú na poskytovanie hodnoty.

Štúdiom týchto implementácií môžete získať prehľad o architektonických vzoroch, stratégiách implementácie a osvedčených postupoch, ktoré je možné aplikovať vo vlastných MCP projektoch. Príklady demonštrujú, že MCP nie je len teoretický rámec, ale praktické riešenie reálnych obchodných výziev.

## Ďalšie zdroje

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Next: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby na automatický preklad [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, upozorňujeme, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie odporúčame profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.