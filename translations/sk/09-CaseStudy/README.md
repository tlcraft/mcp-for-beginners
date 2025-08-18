<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T15:18:52+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sk"
}
-->
# MCP v praxi: Prípadové štúdie z reálneho sveta

[![MCP v praxi: Prípadové štúdie z reálneho sveta](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.sk.png)](https://youtu.be/IxshWb2Az5w)

_(Kliknite na obrázok vyššie pre zobrazenie videa k tejto lekcii)_

Model Context Protocol (MCP) mení spôsob, akým AI aplikácie interagujú s dátami, nástrojmi a službami. Táto sekcia predstavuje prípadové štúdie z reálneho sveta, ktoré ukazujú praktické využitie MCP v rôznych podnikových scenároch.

## Prehľad

Táto sekcia prezentuje konkrétne príklady implementácie MCP, pričom zdôrazňuje, ako organizácie využívajú tento protokol na riešenie zložitých obchodných výziev. Štúdiom týchto prípadov získate prehľad o všestrannosti, škálovateľnosti a praktických výhodách MCP v reálnych situáciách.

## Kľúčové vzdelávacie ciele

Štúdiom týchto prípadových štúdií sa naučíte:

- Pochopiť, ako MCP môže byť aplikovaný na riešenie konkrétnych obchodných problémov
- Zoznámiť sa s rôznymi integračnými vzormi a architektonickými prístupmi
- Rozpoznať osvedčené postupy pri implementácii MCP v podnikových prostrediach
- Získať prehľad o výzvach a riešeniach, s ktorými sa stretli pri reálnych implementáciách
- Identifikovať príležitosti na aplikáciu podobných vzorov vo vlastných projektoch

## Vybrané prípadové štúdie

### 1. [Azure AI Travel Agents – Referenčná implementácia](./travelagentsample.md)

Táto prípadová štúdia skúma komplexné referenčné riešenie od Microsoftu, ktoré demonštruje, ako vytvoriť multi-agentovú, AI-poháňanú aplikáciu na plánovanie ciest pomocou MCP, Azure OpenAI a Azure AI Search. Projekt zahŕňa:

- Orchestráciu viacerých agentov prostredníctvom MCP
- Integráciu podnikových dát s Azure AI Search
- Bezpečnú a škálovateľnú architektúru využívajúcu služby Azure
- Rozšíriteľné nástroje s opakovane použiteľnými komponentmi MCP
- Konverzačné používateľské rozhranie poháňané Azure OpenAI

Architektúra a implementačné detaily poskytujú cenné poznatky o budovaní komplexných multi-agentových systémov s MCP ako koordinačnou vrstvou.

### 2. [Aktualizácia položiek Azure DevOps z údajov YouTube](./UpdateADOItemsFromYT.md)

Táto prípadová štúdia ukazuje praktické využitie MCP na automatizáciu pracovných procesov. Demonštruje, ako môžu byť MCP nástroje použité na:

- Extrakciu údajov z online platforiem (YouTube)
- Aktualizáciu pracovných položiek v systémoch Azure DevOps
- Vytváranie opakovateľných automatizačných pracovných tokov
- Integráciu dát medzi rôznymi systémami

Tento príklad ilustruje, ako aj relatívne jednoduché implementácie MCP môžu priniesť významné zlepšenia efektivity automatizáciou rutinných úloh a zlepšením konzistencie dát medzi systémami.

### 3. [Získavanie dokumentácie v reálnom čase pomocou MCP](./docs-mcp/README.md)

Táto prípadová štúdia vás prevedie pripojením Python konzolového klienta k serveru Model Context Protocol (MCP) na získavanie a zaznamenávanie kontextovo relevantnej dokumentácie Microsoftu v reálnom čase. Naučíte sa:

- Pripojiť sa k MCP serveru pomocou Python klienta a oficiálneho MCP SDK
- Používať streaming HTTP klientov na efektívne získavanie dát v reálnom čase
- Volanie nástrojov na serveri a zaznamenávanie odpovedí priamo do konzoly
- Integrovať aktuálnu dokumentáciu Microsoftu do svojho pracovného toku bez opustenia terminálu

Kapitola obsahuje praktickú úlohu, minimálny funkčný vzorový kód a odkazy na ďalšie zdroje pre hlbšie štúdium. Pozrite si kompletný návod a kód v prepojenej kapitole, aby ste pochopili, ako MCP môže transformovať prístup k dokumentácii a produktivitu vývojárov v konzolových prostrediach.

### 4. [Interaktívna webová aplikácia na generovanie študijných plánov pomocou MCP](./docs-mcp/README.md)

Táto prípadová štúdia ukazuje, ako vytvoriť interaktívnu webovú aplikáciu pomocou Chainlit a Model Context Protocol (MCP) na generovanie personalizovaných študijných plánov pre akúkoľvek tému. Používatelia môžu špecifikovať predmet (napr. "AI-900 certifikácia") a trvanie štúdia (napr. 8 týždňov) a aplikácia poskytne týždeň po týždni odporúčania obsahu. Chainlit umožňuje konverzačné chatové rozhranie, ktoré robí zážitok pútavým a adaptívnym.

- Konverzačná webová aplikácia poháňaná Chainlit
- Používateľom riadené zadania pre tému a trvanie
- Týždenné odporúčania obsahu pomocou MCP
- Reakcie v reálnom čase v chatovom rozhraní

Projekt ilustruje, ako možno kombinovať konverzačné AI a MCP na vytváranie dynamických, používateľsky orientovaných vzdelávacích nástrojov v modernom webovom prostredí.

### 5. [Dokumentácia v editore s MCP serverom vo VS Code](./docs-mcp/README.md)

Táto prípadová štúdia ukazuje, ako môžete priniesť dokumentáciu Microsoft Learn Docs priamo do prostredia VS Code pomocou MCP servera—už žiadne prepínanie medzi kartami prehliadača! Naučíte sa:

- Okamžite vyhľadávať a čítať dokumentáciu vo VS Code pomocou MCP panela alebo príkazovej palety
- Odkazovať na dokumentáciu a vkladať odkazy priamo do README alebo markdown súborov kurzu
- Používať GitHub Copilot a MCP spoločne pre bezproblémové, AI-poháňané pracovné toky dokumentácie a kódu
- Validovať a zlepšovať svoju dokumentáciu s reálnou spätnou väzbou a presnosťou zdrojov Microsoftu
- Integrovať MCP s GitHub pracovnými tokmi pre kontinuálnu validáciu dokumentácie

Implementácia zahŕňa:

- Príklad konfigurácie `.vscode/mcp.json` pre jednoduché nastavenie
- Návody založené na snímkach obrazovky pre zážitok v editore
- Tipy na kombinovanie Copilot a MCP pre maximálnu produktivitu

Tento scenár je ideálny pre autorov kurzov, tvorcov dokumentácie a vývojárov, ktorí chcú zostať sústredení vo svojom editore pri práci s dokumentáciou, Copilotom a validačnými nástrojmi—všetko poháňané MCP.

### 6. [Vytvorenie MCP servera pomocou APIM](./apimsample.md)

Táto prípadová štúdia poskytuje podrobný návod, ako vytvoriť MCP server pomocou Azure API Management (APIM). Zahŕňa:

- Nastavenie MCP servera v Azure API Management
- Zverejnenie API operácií ako MCP nástrojov
- Konfiguráciu politík pre obmedzenie rýchlosti a bezpečnosť
- Testovanie MCP servera pomocou Visual Studio Code a GitHub Copilot

Tento príklad ilustruje, ako využiť schopnosti Azure na vytvorenie robustného MCP servera, ktorý môže byť použitý v rôznych aplikáciách, čím sa zlepšuje integrácia AI systémov s podnikovými API.

## Záver

Tieto prípadové štúdie zdôrazňujú všestrannosť a praktické využitie Model Context Protocol v reálnych scenároch. Od komplexných multi-agentových systémov po cielené automatizačné pracovné toky, MCP poskytuje štandardizovaný spôsob, ako prepojiť AI systémy s nástrojmi a dátami, ktoré potrebujú na poskytovanie hodnoty.

Štúdiom týchto implementácií môžete získať prehľad o architektonických vzoroch, implementačných stratégiách a osvedčených postupoch, ktoré môžete aplikovať vo svojich vlastných MCP projektoch. Príklady ukazujú, že MCP nie je len teoretický rámec, ale praktické riešenie reálnych obchodných výziev.

## Ďalšie zdroje

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Next: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.