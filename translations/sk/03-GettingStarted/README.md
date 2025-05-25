<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:14:48+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sk"
}
-->
## Začíname

Táto sekcia obsahuje niekoľko lekcií:

- **-1- Váš prvý server**, v tejto prvej lekcii sa naučíte, ako vytvoriť svoj prvý server a skontrolovať ho pomocou nástroja inspector, čo je cenný spôsob, ako testovať a ladiť váš server, [k lekcii](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, v tejto lekcii sa naučíte, ako napísať klienta, ktorý sa môže pripojiť k vášmu serveru, [k lekcii](/03-GettingStarted/02-client/README.md)

- **-3- Klient s LLM**, ešte lepší spôsob, ako napísať klienta, je pridať k nemu LLM, aby mohol "vyjednávať" s vaším serverom, čo má robiť, [k lekcii](/03-GettingStarted/03-llm-client/README.md)

- **-4- Využitie režimu GitHub Copilot Agent servera vo Visual Studio Code**. Tu sa pozrieme na spustenie nášho MCP servera z prostredia Visual Studio Code, [k lekcii](/03-GettingStarted/04-vscode/README.md)

- **-5- Využitie SSE (Server Sent Events)** SEE je štandard pre streamovanie zo servera na klienta, ktorý umožňuje serverom posielať aktualizácie v reálnom čase klientom cez HTTP [k lekcii](/03-GettingStarted/05-sse-server/README.md)

- **-6- Využitie AI Toolkit pre VSCode** na využitie a testovanie vašich MCP klientov a serverov [k lekcii](/03-GettingStarted/06-aitk/README.md)

- **-7 Testovanie**. Tu sa zameriame najmä na to, ako môžeme testovať náš server a klienta rôznymi spôsobmi, [k lekcii](/03-GettingStarted/07-testing/README.md)

- **-8- Nasadenie**. Táto kapitola sa zameriava na rôzne spôsoby nasadenia vašich MCP riešení, [k lekcii](/03-GettingStarted/08-deployment/README.md)

Model Context Protocol (MCP) je otvorený protokol, ktorý štandardizuje, ako aplikácie poskytujú kontext LLM. Predstavte si MCP ako USB-C port pre AI aplikácie - poskytuje štandardizovaný spôsob, ako pripojiť AI modely k rôznym zdrojom dát a nástrojom.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Nastaviť vývojové prostredia pre MCP v C#, Java, Python, TypeScript a JavaScript
- Vytvoriť a nasadiť základné MCP servery s vlastnými funkciami (zdroje, výzvy a nástroje)
- Vytvoriť hostiteľské aplikácie, ktoré sa pripájajú k MCP serverom
- Testovať a ladiť implementácie MCP
- Pochopiť bežné výzvy pri nastavení a ich riešenia
- Pripojiť vaše implementácie MCP k populárnym LLM službám

## Nastavenie vášho MCP prostredia

Predtým, ako začnete pracovať s MCP, je dôležité pripraviť si vývojové prostredie a pochopiť základný pracovný postup. Táto sekcia vás prevedie počiatočnými krokmi nastavenia, aby ste mohli s MCP začať hladko.

### Predpoklady

Predtým, ako sa pustíte do vývoja MCP, uistite sa, že máte:

- **Vývojové prostredie**: Pre váš zvolený jazyk (C#, Java, Python, TypeScript alebo JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm alebo akýkoľvek moderný editor kódu
- **Správcovia balíkov**: NuGet, Maven/Gradle, pip alebo npm/yarn
- **API kľúče**: Pre akékoľvek AI služby, ktoré plánujete použiť vo vašich hostiteľských aplikáciách

### Oficiálne SDK

V nadchádzajúcich kapitolách uvidíte riešenia vytvorené pomocou Python, TypeScript, Java a .NET. Tu sú všetky oficiálne podporované SDK.

MCP poskytuje oficiálne SDK pre viacero jazykov:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Udržiavané v spolupráci s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Udržiavané v spolupráci so Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiálna implementácia pre TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiálna implementácia pre Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficiálna implementácia pre Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Udržiavané v spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficiálna implementácia pre Rust

## Kľúčové poznatky

- Nastavenie vývojového prostredia MCP je jednoduché s jazykovo špecifickými SDK
- Vytváranie MCP serverov zahŕňa tvorbu a registráciu nástrojov s jasnými schémami
- MCP klienti sa pripájajú k serverom a modelom, aby využili rozšírené schopnosti
- Testovanie a ladenie sú nevyhnutné pre spoľahlivé implementácie MCP
- Možnosti nasadenia sa pohybujú od lokálneho vývoja po cloudové riešenia

## Precvičovanie

Máme súbor príkladov, ktoré dopĺňajú cvičenia, ktoré uvidíte vo všetkých kapitolách tejto sekcie. Okrem toho má každá kapitola aj vlastné cvičenia a úlohy

- [Java Kalkulačka](./samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](./samples/javascript/README.md)
- [TypeScript Kalkulačka](./samples/typescript/README.md)
- [Python Kalkulačka](../../../03-GettingStarted/samples/python)

## Ďalšie zdroje

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Čo ďalej

Ďalej: [Vytvorenie vášho prvého MCP servera](/03-GettingStarted/01-first-server/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.