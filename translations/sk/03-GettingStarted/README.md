<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:45:13+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sk"
}
-->
## Začíname  

Táto sekcia obsahuje niekoľko lekcií:

- **-1- Váš prvý server**, v tejto prvej lekcii sa naučíte, ako vytvoriť svoj prvý server a skontrolovať ho pomocou nástroja inspector, čo je cenný spôsob, ako testovať a ladiť server, [k lekcii](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, v tejto lekcii sa naučíte, ako napísať klienta, ktorý sa dokáže pripojiť k vášmu serveru, [k lekcii](/03-GettingStarted/02-client/README.md)

- **-3- Klient s LLM**, ešte lepší spôsob, ako napísať klienta, je pridať k nemu LLM, aby mohol „vyjednávať“ so serverom, čo má robiť, [k lekcii](/03-GettingStarted/03-llm-client/README.md)

- **-4- Použitie režimu GitHub Copilot Agenta servera vo Visual Studio Code**. Tu sa pozrieme na spustenie nášho MCP Servera priamo vo Visual Studio Code, [k lekcii](/03-GettingStarted/04-vscode/README.md)

- **-5- Prijímanie zo SSE (Server Sent Events)** SSE je štandard pre streamovanie zo servera na klienta, ktorý umožňuje serverom posielať klientom aktualizácie v reálnom čase cez HTTP [k lekcii](/03-GettingStarted/05-sse-server/README.md)

- **-6- Využitie AI Toolkit pre VSCode** na spotrebovanie a testovanie vašich MCP klientov a serverov [k lekcii](/03-GettingStarted/06-aitk/README.md)

- **-7 Testovanie**. Tu sa zameriame najmä na to, ako môžeme testovať náš server a klienta rôznymi spôsobmi, [k lekcii](/03-GettingStarted/07-testing/README.md)

- **-8- Nasadenie**. Táto kapitola sa pozrie na rôzne spôsoby nasadzovania vašich MCP riešení, [k lekcii](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) je otvorený protokol, ktorý štandardizuje spôsob, akým aplikácie poskytujú kontext LLM. MCP si môžete predstaviť ako USB-C port pre AI aplikácie – poskytuje štandardizovaný spôsob pripojenia AI modelov k rôznym zdrojom dát a nástrojom.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Nastaviť vývojové prostredia pre MCP v C#, Java, Python, TypeScript a JavaScript
- Vytvoriť a nasadiť základné MCP servery s vlastnými funkciami (zdroje, promptové správy a nástroje)
- Vytvoriť hostiteľské aplikácie, ktoré sa pripájajú k MCP serverom
- Testovať a ladiť implementácie MCP
- Pochopiť bežné problémy pri nastavovaní a ich riešenia
- Pripojiť svoje MCP implementácie k populárnym LLM službám

## Nastavenie vášho MCP prostredia

Pred začatím práce s MCP je dôležité pripraviť si vývojové prostredie a pochopiť základný pracovný postup. Táto sekcia vás prevedie po úvodných krokoch nastavenia, aby ste mohli hladko začať s MCP.

### Požiadavky

Predtým, než sa pustíte do vývoja s MCP, uistite sa, že máte:

- **Vývojové prostredie**: Pre vybraný jazyk (C#, Java, Python, TypeScript alebo JavaScript)
- **IDE/Editory**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm alebo akýkoľvek moderný kódový editor
- **Správca balíčkov**: NuGet, Maven/Gradle, pip alebo npm/yarn
- **API kľúče**: Pre akékoľvek AI služby, ktoré plánujete používať vo svojich hostiteľských aplikáciách


### Oficiálne SDK

V nasledujúcich kapitolách uvidíte riešenia vytvorené pomocou Pythonu, TypeScriptu, Javy a .NET. Tu sú všetky oficiálne podporované SDK.

MCP poskytuje oficiálne SDK pre viaceré jazyky:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Udržiavané v spolupráci s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Udržiavané v spolupráci so Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiálna implementácia pre TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiálna implementácia pre Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficiálna implementácia pre Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Udržiavané v spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficiálna implementácia pre Rust

## Kľúčové poznatky

- Nastavenie MCP vývojového prostredia je jednoduché vďaka SDK špecifickým pre jednotlivé jazyky
- Budovanie MCP serverov zahŕňa vytváranie a registráciu nástrojov s jasnými schémami
- MCP klienti sa pripájajú k serverom a modelom, aby využili rozšírené funkcie
- Testovanie a ladenie sú nevyhnutné pre spoľahlivé implementácie MCP
- Možnosti nasadenia sa pohybujú od lokálneho vývoja až po cloudové riešenia

## Praktické cvičenia

Máme súbor príkladov, ktoré dopĺňajú cvičenia, ktoré uvidíte vo všetkých kapitolách tejto sekcie. Okrem toho má každá kapitola aj svoje vlastné cvičenia a úlohy.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../../../03-GettingStarted/samples/javascript)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Čo ďalej

Ďalej: [Vytvorenie vášho prvého MCP Servera](/03-GettingStarted/01-first-server/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.