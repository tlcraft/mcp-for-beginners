<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:50:24+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "cs"
}
-->
# MCP v praxi: Případové studie ze skutečného světa

Model Context Protocol (MCP) mění způsob, jakým AI aplikace komunikují s daty, nástroji a službami. Tato sekce představuje případové studie ze skutečného světa, které ukazují praktické využití MCP v různých podnikových scénářích.

## Přehled

Tato část ukazuje konkrétní příklady implementací MCP a zdůrazňuje, jak organizace využívají tento protokol k řešení složitých obchodních výzev. Prozkoumáním těchto případových studií získáte přehled o všestrannosti, škálovatelnosti a praktických přínosech MCP v reálných situacích.

## Hlavní cíle učení

Prozkoumáním těchto případových studií budete schopni:

- Pochopit, jak lze MCP použít k řešení konkrétních obchodních problémů
- Seznámit se s různými integračními vzory a architektonickými přístupy
- Rozpoznat osvědčené postupy pro implementaci MCP v podnikových prostředích
- Získat přehled o výzvách a řešeních, které se objevují při reálných implementacích
- Identifikovat příležitosti k aplikaci podobných vzorů ve vlastních projektech

## Vybrané případové studie

### 1. [Azure AI Travel Agents – Referenční implementace](./travelagentsample.md)

Tato případová studie zkoumá komplexní referenční řešení od Microsoftu, které ukazuje, jak vytvořit multi-agentní aplikaci pro plánování cestování poháněnou AI pomocí MCP, Azure OpenAI a Azure AI Search. Projekt představuje:

- Orchestrace více agentů pomocí MCP
- Integraci podnikových dat s Azure AI Search
- Bezpečnou a škálovatelnou architekturu využívající Azure služby
- Rozšiřitelné nástroje s opakovaně použitelnými komponentami MCP
- Konverzační uživatelský zážitek poháněný Azure OpenAI

Architektura a detaily implementace poskytují cenné poznatky o budování složitých multi-agentních systémů s MCP jako koordinační vrstvou.

### 2. [Aktualizace položek Azure DevOps z dat YouTube](./UpdateADOItemsFromYT.md)

Tato případová studie ukazuje praktické využití MCP pro automatizaci pracovních procesů. Demonstruje, jak lze nástroje MCP použít k:

- Extrakci dat z online platforem (YouTube)
- Aktualizaci pracovních položek v systémech Azure DevOps
- Vytváření opakovatelných automatizačních workflow
- Integraci dat napříč různými systémy

Tento příklad ilustruje, jak i relativně jednoduché implementace MCP mohou přinést výrazné zvýšení efektivity automatizací rutinních úkolů a zlepšením konzistence dat mezi systémy.

### 3. [Získávání dokumentace v reálném čase s MCP](./docs-mcp/README.md)

Tato případová studie vás provede připojením Python konzolového klienta k MCP serveru pro získávání a zaznamenávání aktuální, kontextově relevantní dokumentace Microsoftu v reálném čase. Naučíte se, jak:

- Připojit se k MCP serveru pomocí Python klienta a oficiálního MCP SDK
- Používat streamingové HTTP klienty pro efektivní získávání dat v reálném čase
- Volat dokumentační nástroje na serveru a zaznamenávat odpovědi přímo do konzole
- Integrovat aktuální dokumentaci Microsoftu do svého pracovního postupu bez opuštění terminálu

Kapitola obsahuje praktické cvičení, minimální funkční ukázku kódu a odkazy na další zdroje pro hlubší studium. Kompletní průvodce a kód najdete v přiložené kapitole, která ukazuje, jak MCP může změnit přístup k dokumentaci a zvýšit produktivitu vývojářů v konzolových prostředích.

### 4. [Interaktivní webová aplikace pro generování studijního plánu s MCP](./docs-mcp/README.md)

Tato případová studie ukazuje, jak vytvořit interaktivní webovou aplikaci pomocí Chainlit a Model Context Protocol (MCP) pro generování personalizovaných studijních plánů na libovolné téma. Uživatelé mohou zadat předmět (např. „AI-900 certifikace“) a délku studia (např. 8 týdnů) a aplikace poskytne týdenní rozpis doporučeného obsahu. Chainlit umožňuje konverzační chatové rozhraní, které dělá zážitek poutavým a adaptivním.

- Konverzační webová aplikace poháněná Chainlit
- Uživatelské vstupy pro téma a délku studia
- Doporučení obsahu týden po týdnu pomocí MCP
- Adaptivní odpovědi v reálném čase v chatovém rozhraní

Projekt ukazuje, jak lze konverzační AI a MCP spojit k vytvoření dynamických, uživatelsky řízených vzdělávacích nástrojů v moderním webovém prostředí.

### 5. [Dokumentace přímo v editoru s MCP serverem ve VS Code](./docs-mcp/README.md)

Tato případová studie ukazuje, jak přinést Microsoft Learn Docs přímo do prostředí VS Code pomocí MCP serveru – už žádné přepínání mezi záložkami v prohlížeči! Uvidíte, jak:

- Okamžitě vyhledávat a číst dokumentaci přímo ve VS Code pomocí MCP panelu nebo příkazové palety
- Odkazovat na dokumentaci a vkládat odkazy přímo do README nebo markdown souborů kurzů
- Používat GitHub Copilot a MCP společně pro plynulé AI-poháněné workflow dokumentace a kódu
- Validovat a vylepšovat dokumentaci s okamžitou zpětnou vazbou a přesností od Microsoftu
- Integrovat MCP s GitHub workflow pro kontinuální validaci dokumentace

Implementace zahrnuje:
- Příklad konfigurace `.vscode/mcp.json` pro snadné nastavení
- Průvodce s obrázky ukazujícími práci v editoru
- Tipy pro kombinaci Copilota a MCP pro maximální produktivitu

Tento scénář je ideální pro autory kurzů, tvůrce dokumentace a vývojáře, kteří chtějí zůstat soustředění v editoru při práci s dokumentací, Copilotem a validačními nástroji – vše poháněné MCP.

### 6. [Vytvoření MCP serveru pomocí APIM](./apimsample.md)

Tato případová studie nabízí krok za krokem návod, jak vytvořit MCP server pomocí Azure API Management (APIM). Pokrývá:

- Nastavení MCP serveru v Azure API Management
- Zpřístupnění API operací jako MCP nástrojů
- Konfiguraci politik pro omezení rychlosti a zabezpečení
- Testování MCP serveru pomocí Visual Studio Code a GitHub Copilot

Tento příklad ukazuje, jak využít možnosti Azure k vytvoření robustního MCP serveru, který lze použít v různých aplikacích a zlepšit tak integraci AI systémů s podnikových API.

## Závěr

Tyto případové studie zdůrazňují všestrannost a praktické využití Model Context Protocol v reálných scénářích. Od složitých multi-agentních systémů po cílené automatizační workflow, MCP poskytuje standardizovaný způsob, jak propojit AI systémy s nástroji a daty, které potřebují k přinášení hodnoty.

Studiem těchto implementací získáte přehled o architektonických vzorech, strategiích implementace a osvědčených postupech, které můžete aplikovat ve svých vlastních MCP projektech. Příklady ukazují, že MCP není jen teoretický rámec, ale praktické řešení skutečných obchodních výzev.

## Další zdroje

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Další: Hands on Lab [Zjednodušení AI workflow: Vytvoření MCP serveru s AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.