<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T19:42:27+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "cs"
}
-->
# MCP v akci: Případové studie z reálného světa

[![MCP v akci: Případové studie z reálného světa](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.cs.png)](https://youtu.be/IxshWb2Az5w)

_(Klikněte na obrázek výše pro zhlédnutí videa této lekce)_

Model Context Protocol (MCP) mění způsob, jakým AI aplikace interagují s daty, nástroji a službami. Tato sekce představuje případové studie z reálného světa, které ukazují praktické využití MCP v různých podnikových scénářích.

## Přehled

Tato sekce představuje konkrétní příklady implementace MCP, které zdůrazňují, jak organizace využívají tento protokol k řešení složitých obchodních výzev. Prozkoumáním těchto případových studií získáte přehled o všestrannosti, škálovatelnosti a praktických přínosech MCP v reálných situacích.

## Klíčové cíle učení

Prozkoumáním těchto případových studií se naučíte:

- Pochopit, jak lze MCP aplikovat na řešení konkrétních obchodních problémů
- Seznámit se s různými integračními vzory a architektonickými přístupy
- Rozpoznat osvědčené postupy pro implementaci MCP v podnikových prostředích
- Získat přehled o výzvách a řešeních, se kterými se setkali při reálných implementacích
- Identifikovat příležitosti k aplikaci podobných vzorů ve vlastních projektech

## Představené případové studie

### 1. [Azure AI Travel Agents – Referenční implementace](./travelagentsample.md)

Tato případová studie zkoumá komplexní referenční řešení od Microsoftu, které ukazuje, jak vytvořit víceagentní AI aplikaci pro plánování cestování pomocí MCP, Azure OpenAI a Azure AI Search. Projekt zahrnuje:

- Orchestrace více agentů prostřednictvím MCP
- Integrace podnikových dat s Azure AI Search
- Bezpečná, škálovatelná architektura využívající Azure služby
- Rozšiřitelné nástroje s opakovaně použitelnými komponentami MCP
- Konverzační uživatelský zážitek poháněný Azure OpenAI

Architektura a implementační detaily poskytují cenné poznatky o budování složitých víceagentních systémů s MCP jako koordinační vrstvou.

### 2. [Aktualizace položek Azure DevOps z dat YouTube](./UpdateADOItemsFromYT.md)

Tato případová studie ukazuje praktické využití MCP pro automatizaci pracovních procesů. Ukazuje, jak lze MCP nástroje použít k:

- Extrakci dat z online platforem (YouTube)
- Aktualizaci pracovních položek v systémech Azure DevOps
- Vytváření opakovatelných automatizačních pracovních postupů
- Integraci dat mezi různými systémy

Tento příklad ilustruje, jak i relativně jednoduché implementace MCP mohou přinést významné zlepšení efektivity automatizací rutinních úkolů a zlepšením konzistence dat mezi systémy.

### 3. [Získávání dokumentace v reálném čase pomocí MCP](./docs-mcp/README.md)

Tato případová studie vás provede připojením Python konzolového klienta k serveru Model Context Protocol (MCP) za účelem získávání a logování dokumentace Microsoftu v reálném čase. Naučíte se:

- Připojit k MCP serveru pomocí Python klienta a oficiálního MCP SDK
- Používat streamovací HTTP klienty pro efektivní získávání dat v reálném čase
- Volat nástroje pro dokumentaci na serveru a logovat odpovědi přímo do konzole
- Integrovat aktuální dokumentaci Microsoftu do svého pracovního postupu bez opuštění terminálu

Kapitola obsahuje praktický úkol, minimální funkční ukázku kódu a odkazy na další zdroje pro hlubší učení. Podívejte se na kompletní průvodce a kód v odkazované kapitole, abyste pochopili, jak MCP může transformovat přístup k dokumentaci a produktivitu vývojářů v konzolových prostředích.

### 4. [Interaktivní webová aplikace pro generování studijních plánů s MCP](./docs-mcp/README.md)

Tato případová studie ukazuje, jak vytvořit interaktivní webovou aplikaci pomocí Chainlit a Model Context Protocol (MCP) pro generování personalizovaných studijních plánů na libovolné téma. Uživatelé mohou zadat předmět (např. "AI-900 certifikace") a dobu studia (např. 8 týdnů) a aplikace poskytne týdenní rozpis doporučeného obsahu. Chainlit umožňuje konverzační chatové rozhraní, které činí zážitek poutavým a adaptivním.

- Konverzační webová aplikace poháněná Chainlit
- Uživatelsky řízené zadávání tématu a doby trvání
- Týdenní doporučení obsahu pomocí MCP
- Reakce v reálném čase v chatovém rozhraní

Projekt ukazuje, jak lze kombinovat konverzační AI a MCP pro vytvoření dynamických, uživatelsky orientovaných vzdělávacích nástrojů v moderním webovém prostředí.

### 5. [Dokumentace v editoru s MCP serverem ve VS Code](./docs-mcp/README.md)

Tato případová studie ukazuje, jak můžete přinést dokumentaci Microsoft Learn přímo do prostředí VS Code pomocí MCP serveru – už žádné přepínání mezi záložkami prohlížeče! Naučíte se:

- Okamžitě vyhledávat a číst dokumentaci přímo ve VS Code pomocí MCP panelu nebo příkazové palety
- Odkazovat na dokumentaci a vkládat odkazy přímo do README nebo markdown souborů kurzu
- Používat GitHub Copilot a MCP společně pro bezproblémové pracovní postupy s dokumentací a kódem poháněné AI
- Validovat a vylepšovat dokumentaci s reálnou zpětnou vazbou a přesností zdrojů Microsoftu
- Integrovat MCP s GitHub pracovními postupy pro kontinuální validaci dokumentace

Implementace zahrnuje:

- Ukázkovou konfiguraci `.vscode/mcp.json` pro snadné nastavení
- Průvodce s obrázky ukazujícími prostředí v editoru
- Tipy pro kombinaci Copilot a MCP pro maximální produktivitu

Tento scénář je ideální pro autory kurzů, tvůrce dokumentace a vývojáře, kteří chtějí zůstat soustředění ve svém editoru při práci s dokumentací, Copilotem a validačními nástroji – vše poháněné MCP.

### 6. [Vytvoření MCP serveru pomocí APIM](./apimsample.md)

Tato případová studie poskytuje podrobný návod, jak vytvořit MCP server pomocí Azure API Management (APIM). Pokrývá:

- Nastavení MCP serveru v Azure API Management
- Zpřístupnění API operací jako MCP nástrojů
- Konfiguraci politik pro omezení rychlosti a zabezpečení
- Testování MCP serveru pomocí Visual Studio Code a GitHub Copilot

Tento příklad ukazuje, jak využít schopnosti Azure k vytvoření robustního MCP serveru, který lze použít v různých aplikacích, a zlepšit tak integraci AI systémů s podnikovými API.

## Závěr

Tyto případové studie zdůrazňují všestrannost a praktické využití Model Context Protocol v reálných scénářích. Od složitých víceagentních systémů po cílené automatizační pracovní postupy poskytuje MCP standardizovaný způsob propojení AI systémů s nástroji a daty, které potřebují k poskytování hodnoty.

Studováním těchto implementací získáte přehled o architektonických vzorech, implementačních strategiích a osvědčených postupech, které lze aplikovat na vaše vlastní MCP projekty. Příklady ukazují, že MCP není jen teoretický rámec, ale praktické řešení reálných obchodních výzev.

## Další zdroje

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Další: Praktická laboratoř [Zefektivnění AI pracovních postupů: Vytvoření MCP serveru s AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Upozornění**:  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o co největší přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za závazný zdroj. Pro důležité informace doporučujeme profesionální lidský překlad. Neodpovídáme za žádná nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.