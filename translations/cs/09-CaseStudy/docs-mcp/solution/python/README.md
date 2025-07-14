<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:43:32+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "cs"
}
-->
# Generátor studijního plánu s Chainlit & Microsoft Learn Docs MCP

## Požadavky

- Python 3.8 nebo novější
- pip (správce balíčků pro Python)
- Připojení k internetu pro komunikaci se serverem Microsoft Learn Docs MCP

## Instalace

1. Naklonujte si tento repozitář nebo stáhněte soubory projektu.
2. Nainstalujte potřebné závislosti:

   ```bash
   pip install -r requirements.txt
   ```

## Použití

### Scénář 1: Jednoduchý dotaz na Docs MCP
Klient příkazové řádky, který se připojí k serveru Docs MCP, odešle dotaz a vypíše výsledek.

1. Spusťte skript:
   ```bash
   python scenario1.py
   ```
2. Zadejte svůj dotaz ohledně dokumentace na výzvu.

### Scénář 2: Generátor studijního plánu (webová aplikace Chainlit)
Webové rozhraní (využívající Chainlit), které umožňuje uživatelům vytvořit si osobní studijní plán rozdělený na týdny pro jakékoliv technické téma.

1. Spusťte aplikaci Chainlit:
   ```bash
   chainlit run scenario2.py
   ```
2. Otevřete v prohlížeči lokální URL zobrazenou v terminálu (např. http://localhost:8000).
3. V chatovacím okně zadejte téma studia a počet týdnů, po které chcete studovat (např. „AI-900 certifikace, 8 týdnů“).
4. Aplikace vám odpoví týdenním studijním plánem včetně odkazů na relevantní dokumentaci Microsoft Learn.

**Požadované proměnné prostředí:**

Pro použití scénáře 2 (webová aplikace Chainlit s Azure OpenAI) musíte v adresáři `python` vytvořit soubor `.env` a nastavit v něm tyto proměnné:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Vyplňte tyto hodnoty podle údajů vašeho Azure OpenAI zdroje před spuštěním aplikace.

> **Tip:** Snadno si můžete nasadit vlastní modely pomocí [Azure AI Foundry](https://ai.azure.com/).

### Scénář 3: Dokumentace v editoru s MCP serverem ve VS Code

Místo přepínání mezi záložkami v prohlížeči můžete mít Microsoft Learn Docs přímo ve VS Code díky MCP serveru. To vám umožní:
- Vyhledávat a číst dokumentaci přímo ve VS Code, aniž byste opustili své vývojové prostředí.
- Odkazovat na dokumentaci a vkládat odkazy přímo do README nebo souborů kurzu.
- Používat GitHub Copilot a MCP společně pro plynulý pracovní postup s AI podporou dokumentace.

**Příklady použití:**
- Rychle přidat odkazy na dokumentaci do README při psaní kurzu nebo projektové dokumentace.
- Použít Copilot k generování kódu a MCP k okamžitému nalezení a citování relevantní dokumentace.
- Zůstat soustředěný v editoru a zvýšit produktivitu.

> [!IMPORTANT]
> Ujistěte se, že máte ve svém workspace platnou konfiguraci [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) (umístění je `.vscode/mcp.json`).

## Proč Chainlit pro scénář 2?

Chainlit je moderní open-source framework pro tvorbu konverzačních webových aplikací. Umožňuje snadno vytvářet chatovací uživatelská rozhraní, která se připojují k backendovým službám, jako je Microsoft Learn Docs MCP server. Tento projekt využívá Chainlit k jednoduchému a interaktivnímu generování personalizovaných studijních plánů v reálném čase. Díky Chainlit můžete rychle vyvíjet a nasazovat chatovací nástroje, které zvyšují produktivitu a usnadňují učení.

## Co to dělá

Tato aplikace umožňuje uživatelům vytvořit si osobní studijní plán jednoduše zadáním tématu a délky studia. Aplikace zpracuje váš vstup, odešle dotaz na Microsoft Learn Docs MCP server pro relevantní obsah a uspořádá výsledky do strukturovaného plánu rozděleného na týdny. Doporučení pro každý týden se zobrazí v chatu, takže je snadné sledovat svůj pokrok. Integrace zajišťuje, že vždy získáte nejnovější a nejrelevantnější studijní materiály.

## Ukázkové dotazy

Vyzkoušejte tyto dotazy v chatovacím okně a uvidíte, jak aplikace reaguje:

- `AI-900 certifikace, 8 týdnů`
- `Learn Azure Functions, 4 týdny`
- `Azure DevOps, 6 týdnů`
- `Data engineering on Azure, 10 týdnů`
- `Microsoft security fundamentals, 5 týdnů`
- `Power Platform, 7 týdnů`
- `Azure AI services, 12 týdnů`
- `Cloud architecture, 9 týdnů`

Tyto příklady ukazují flexibilitu aplikace pro různé vzdělávací cíle a časové rámce.

## Odkazy

- [Chainlit Dokumentace](https://docs.chainlit.io/)
- [MCP Dokumentace](https://github.com/MicrosoftDocs/mcp)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.