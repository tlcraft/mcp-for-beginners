<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T18:42:52+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sk"
}
-->
## Začíname  

Táto sekcia obsahuje niekoľko lekcií:

- **1 Váš prvý server**, v tejto prvej lekcii sa naučíte, ako vytvoriť svoj prvý server a skontrolovať ho pomocou nástroja inspector, čo je cenný spôsob, ako testovať a ladiť váš server, [k lekcii](/03-GettingStarted/01-first-server/README.md)

- **2 Klient**, v tejto lekcii sa naučíte, ako napísať klienta, ktorý sa dokáže pripojiť k vášmu serveru, [k lekcii](/03-GettingStarted/02-client/README.md)

- **3 Klient s LLM**, ešte lepší spôsob, ako napísať klienta, je pridať mu LLM, aby mohol „vyjednávať“ s vaším serverom o tom, čo robiť, [k lekcii](/03-GettingStarted/03-llm-client/README.md)

- **4 Použitie servera v režime GitHub Copilot Agent vo Visual Studio Code**. Tu sa pozrieme na spustenie nášho MCP Servera priamo vo Visual Studio Code, [k lekcii](/03-GettingStarted/04-vscode/README.md)

- **5 Spotreba zo SSE (Server Sent Events)** SSE je štandard pre streamovanie zo servera na klienta, ktorý umožňuje serverom posielať klientom aktualizácie v reálnom čase cez HTTP [k lekcii](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP streamovanie s MCP (Streamable HTTP)**. Naučte sa o modernom HTTP streamovaní, notifikáciách o priebehu a ako implementovať škálovateľné, real-time MCP servery a klientov pomocou Streamable HTTP. [k lekcii](/03-GettingStarted/06-http-streaming/README.md)

- **7 Využitie AI Toolkit pre VSCode** na spotrebu a testovanie vašich MCP klientov a serverov [k lekcii](/03-GettingStarted/07-aitk/README.md)

- **8 Testovanie**. Tu sa zameriame najmä na to, ako môžeme testovať náš server a klienta rôznymi spôsobmi, [k lekcii](/03-GettingStarted/08-testing/README.md)

- **9 Nasadenie**. Táto kapitola sa pozrie na rôzne spôsoby nasadenia vašich MCP riešení, [k lekcii](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) je otvorený protokol, ktorý štandardizuje spôsob, akým aplikácie poskytujú kontext LLM. Predstavte si MCP ako USB-C port pre AI aplikácie – poskytuje štandardizovaný spôsob pripojenia AI modelov k rôznym zdrojom dát a nástrojom.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Nastaviť vývojové prostredia pre MCP v C#, Java, Python, TypeScript a JavaScript
- Vytvoriť a nasadiť základné MCP servery s vlastnými funkciami (zdroje, prompt-y a nástroje)
- Vytvoriť hostiteľské aplikácie, ktoré sa pripájajú k MCP serverom
- Testovať a ladiť implementácie MCP
- Pochopiť bežné problémy pri nastavovaní a ich riešenia
- Pripojiť svoje MCP implementácie k populárnym LLM službám

## Nastavenie vášho MCP prostredia

Predtým, než začnete pracovať s MCP, je dôležité pripraviť si vývojové prostredie a pochopiť základný pracovný postup. Táto sekcia vás prevedie po úvodných krokoch nastavenia, aby ste mohli hladko začať s MCP.

### Predpoklady

Predtým, než sa pustíte do vývoja MCP, uistite sa, že máte:

- **Vývojové prostredie**: Pre váš zvolený jazyk (C#, Java, Python, TypeScript alebo JavaScript)
- **IDE/Editory**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm alebo akýkoľvek moderný kódový editor
- **Správca balíkov**: NuGet, Maven/Gradle, pip alebo npm/yarn
- **API kľúče**: Pre akékoľvek AI služby, ktoré plánujete používať vo vašich hostiteľských aplikáciách


### Oficiálne SDK

V nasledujúcich kapitolách uvidíte riešenia vytvorené pomocou Python, TypeScript, Java a .NET. Tu sú všetky oficiálne podporované SDK.

MCP poskytuje oficiálne SDK pre viaceré jazyky:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Udržiavané v spolupráci s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Udržiavané v spolupráci so Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiálna implementácia pre TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiálna implementácia pre Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficiálna implementácia pre Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Udržiavané v spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficiálna implementácia pre Rust

## Kľúčové poznatky

- Nastavenie vývojového prostredia MCP je jednoduché vďaka SDK špecifickým pre jednotlivé jazyky
- Vytváranie MCP serverov zahŕňa tvorbu a registráciu nástrojov s jasnými schémami
- MCP klienti sa pripájajú k serverom a modelom, aby využili rozšírené možnosti
- Testovanie a ladenie sú nevyhnutné pre spoľahlivé implementácie MCP
- Možnosti nasadenia sa pohybujú od lokálneho vývoja až po cloudové riešenia

## Praktické cvičenia

Máme súbor príkladov, ktoré dopĺňajú cvičenia, ktoré uvidíte vo všetkých kapitolách tejto sekcie. Okrem toho má každá kapitola aj vlastné cvičenia a úlohy.

- [Java kalkulačka](./samples/java/calculator/README.md)
- [.Net kalkulačka](../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulačka](./samples/javascript/README.md)
- [TypeScript kalkulačka](./samples/typescript/README.md)
- [Python kalkulačka](../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [Vytváranie agentov pomocou Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Vzdialený MCP s Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Čo ďalej

Ďalej: [Vytvorenie vášho prvého MCP servera](./01-first-server/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.