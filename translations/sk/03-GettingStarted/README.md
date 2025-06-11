<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:16:03+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sk"
}
-->
## Začíname  

Táto sekcia obsahuje niekoľko lekcií:

- **1 Váš prvý server**, v tejto prvej lekcii sa naučíte, ako vytvoriť svoj prvý server a skontrolovať ho pomocou nástroja inspector, čo je užitočný spôsob, ako testovať a ladit svoj server, [do lekcie](/03-GettingStarted/01-first-server/README.md)

- **2 Klient**, v tejto lekcii sa naučíte, ako napísať klienta, ktorý sa dokáže pripojiť k vášmu serveru, [do lekcie](/03-GettingStarted/02-client/README.md)

- **3 Klient s LLM**, ešte lepší spôsob písania klienta je pridať mu LLM, aby mohol „vyjednávať“ so serverom o tom, čo robiť, [do lekcie](/03-GettingStarted/03-llm-client/README.md)

- **4 Použitie režimu GitHub Copilot agenta servera vo Visual Studio Code**. Tu sa pozrieme na spustenie nášho MCP Servera priamo vo Visual Studio Code, [do lekcie](/03-GettingStarted/04-vscode/README.md)

- **5 Spotreba zo SSE (Server Sent Events)** SSE je štandard pre streaming zo servera ku klientovi, ktorý umožňuje serverom posielať klientom aktualizácie v reálnom čase cez HTTP [do lekcie](/03-GettingStarted/05-sse-server/README.md)

- **6 Využitie AI Toolkit pre VSCode** na spotrebu a testovanie vašich MCP klientov a serverov [do lekcie](/03-GettingStarted/06-aitk/README.md)

- **7 Testovanie**. Tu sa zameriame najmä na to, ako môžeme rôznymi spôsobmi testovať náš server a klienta, [do lekcie](/03-GettingStarted/07-testing/README.md)

- **8 Nasadenie**. Táto kapitola sa bude venovať rôznym spôsobom nasadzovania vašich MCP riešení, [do lekcie](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) je otvorený protokol, ktorý štandardizuje spôsob, akým aplikácie poskytujú kontext LLM. Predstavte si MCP ako USB-C port pre AI aplikácie – poskytuje štandardizovaný spôsob pripojenia AI modelov k rôznym zdrojom dát a nástrojom.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Nastaviť vývojové prostredia pre MCP v C#, Java, Python, TypeScript a JavaScript
- Vytvárať a nasadzovať základné MCP servery s vlastnými funkciami (zdroje, výzvy a nástroje)
- Vytvárať hostiteľské aplikácie, ktoré sa pripájajú k MCP serverom
- Testovať a ladiť implementácie MCP
- Pochopiť bežné problémy pri nastavovaní a ich riešenia
- Pripojiť vaše MCP implementácie k populárnym LLM službám

## Nastavenie vášho MCP prostredia

Pred začatím práce s MCP je dôležité pripraviť si vývojové prostredie a pochopiť základný pracovný postup. Táto sekcia vás prevedie počiatočnými krokmi nastavenia, aby ste mohli s MCP začať bez problémov.

### Požiadavky

Predtým, než sa pustíte do vývoja MCP, uistite sa, že máte:

- **Vývojové prostredie**: Pre váš vybraný jazyk (C#, Java, Python, TypeScript alebo JavaScript)
- **IDE/Editory**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm alebo akýkoľvek moderný kódový editor
- **Správcovia balíčkov**: NuGet, Maven/Gradle, pip alebo npm/yarn
- **API kľúče**: Pre akékoľvek AI služby, ktoré plánujete používať vo vašich hostiteľských aplikáciách


### Oficiálne SDK

V nasledujúcich kapitolách uvidíte riešenia postavené pomocou Python, TypeScript, Java a .NET. Tu sú všetky oficiálne podporované SDK.

MCP poskytuje oficiálne SDK pre viaceré jazyky:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Udržiavané v spolupráci s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Udržiavané v spolupráci so Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiálna TypeScript implementácia
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiálna Python implementácia
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficiálna Kotlin implementácia
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Udržiavané v spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficiálna Rust implementácia

## Kľúčové poznatky

- Nastavenie vývojového prostredia MCP je jednoduché vďaka SDK špecifickým pre jednotlivé jazyky
- Vytváranie MCP serverov zahŕňa tvorbu a registráciu nástrojov s jasnými schémami
- MCP klienti sa pripájajú k serverom a modelom, aby využili rozšírené možnosti
- Testovanie a ladenie sú nevyhnutné pre spoľahlivé implementácie MCP
- Možnosti nasadenia sa pohybujú od lokálneho vývoja až po cloudové riešenia

## Precvičovanie

Máme súbor ukážok, ktoré dopĺňajú cvičenia, ktoré uvidíte vo všetkých kapitolách tejto sekcie. Okrem toho má každá kapitola aj svoje vlastné cvičenia a zadania

- [Java kalkulačka](./samples/java/calculator/README.md)
- [.Net kalkulačka](../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulačka](./samples/javascript/README.md)
- [TypeScript kalkulačka](./samples/typescript/README.md)
- [Python kalkulačka](../../../03-GettingStarted/samples/python)

## Ďalšie zdroje

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Čo bude ďalej

Ďalej: [Vytvorenie vášho prvého MCP Servera](/03-GettingStarted/01-first-server/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.