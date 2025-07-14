<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:43:46+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "sk"
}
-->
# Generátor študijného plánu s Chainlit & Microsoft Learn Docs MCP

## Požiadavky

- Python 3.8 alebo novší
- pip (správca balíčkov pre Python)
- Prístup na internet na pripojenie k serveru Microsoft Learn Docs MCP

## Inštalácia

1. Naklonujte si tento repozitár alebo si stiahnite súbory projektu.
2. Nainštalujte potrebné závislosti:

   ```bash
   pip install -r requirements.txt
   ```

## Použitie

### Scenár 1: Jednoduchý dotaz na Docs MCP
Príkazový klient, ktorý sa pripojí k serveru Docs MCP, odošle dotaz a vypíše výsledok.

1. Spustite skript:
   ```bash
   python scenario1.py
   ```
2. Zadajte svoju otázku ohľadom dokumentácie na výzvu.

### Scenár 2: Generátor študijného plánu (Chainlit webová aplikácia)
Webové rozhranie (používajúce Chainlit), ktoré umožňuje používateľom vytvoriť si personalizovaný študijný plán rozdelený na týždne pre akúkoľvek technickú tému.

1. Spustite Chainlit aplikáciu:
   ```bash
   chainlit run scenario2.py
   ```
2. Otvorte lokálnu URL adresu zobrazenú v termináli (napr. http://localhost:8000) vo vašom prehliadači.
3. V chatovacom okne zadajte tému štúdia a počet týždňov, počas ktorých chcete študovať (napr. „AI-900 certifikácia, 8 týždňov“).
4. Aplikácia vám odpovie študijným plánom rozdeleným po týždňoch vrátane odkazov na relevantnú dokumentáciu Microsoft Learn.

**Vyžadované premenné prostredia:**

Ak chcete použiť Scenár 2 (Chainlit webovú aplikáciu s Azure OpenAI), musíte nastaviť nasledujúce premenné prostredia v súbore `.env` v adresári `python`:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Vyplňte tieto hodnoty podľa údajov vášho Azure OpenAI zdroja pred spustením aplikácie.

> **Tip:** Svoje vlastné modely môžete jednoducho nasadiť pomocou [Azure AI Foundry](https://ai.azure.com/).

### Scenár 3: Dokumentácia v editore s MCP serverom vo VS Code

Namiesto prepínania kariet v prehliadači na vyhľadávanie dokumentácie môžete mať Microsoft Learn Docs priamo vo VS Code pomocou MCP servera. To vám umožní:
- Vyhľadávať a čítať dokumentáciu priamo vo VS Code bez opustenia vývojového prostredia.
- Odkazovať na dokumentáciu a vkladať odkazy priamo do README alebo súborov kurzu.
- Používať GitHub Copilot a MCP spoločne pre plynulý pracovný tok s podporou AI.

**Príklady použitia:**
- Rýchlo pridať referenčné odkazy do README počas písania dokumentácie ku kurzu alebo projektu.
- Použiť Copilot na generovanie kódu a MCP na okamžité vyhľadanie a citovanie relevantnej dokumentácie.
- Zostať sústredený v editore a zvýšiť produktivitu.

> [!IMPORTANT]
> Uistite sa, že máte platnú konfiguráciu [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) vo vašom pracovnom priestore (umiestnenie je `.vscode/mcp.json`).

## Prečo Chainlit pre Scenár 2?

Chainlit je moderný open-source framework na tvorbu konverzačných webových aplikácií. Uľahčuje vytváranie chatových používateľských rozhraní, ktoré sa pripájajú k backendovým službám, ako je Microsoft Learn Docs MCP server. Tento projekt využíva Chainlit na jednoduchý a interaktívny spôsob generovania personalizovaných študijných plánov v reálnom čase. Vďaka Chainlit môžete rýchlo vytvárať a nasadzovať chatové nástroje, ktoré zlepšujú produktivitu a učenie.

## Čo toto robí

Táto aplikácia umožňuje používateľom vytvoriť si personalizovaný študijný plán jednoducho zadaním témy a dĺžky štúdia. Aplikácia spracuje váš vstup, odošle dotaz na Microsoft Learn Docs MCP server pre relevantný obsah a usporiada výsledky do štruktúrovaného plánu rozdeleného po týždňoch. Odporúčania na každý týždeň sa zobrazia v chate, čo uľahčuje sledovanie a dodržiavanie plánu. Integrácia zabezpečuje, že vždy získate najnovšie a najrelevantnejšie vzdelávacie zdroje.

## Ukážkové dotazy

Vyskúšajte tieto dotazy v chatovacom okne a pozrite sa, ako aplikácia reaguje:

- `AI-900 certification, 8 weeks`
- `Learn Azure Functions, 4 weeks`
- `Azure DevOps, 6 weeks`
- `Data engineering on Azure, 10 weeks`
- `Microsoft security fundamentals, 5 weeks`
- `Power Platform, 7 weeks`
- `Azure AI services, 12 weeks`
- `Cloud architecture, 9 weeks`

Tieto príklady ukazujú flexibilitu aplikácie pre rôzne vzdelávacie ciele a časové rámce.

## Referencie

- [Chainlit Documentation](https://docs.chainlit.io/)
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.