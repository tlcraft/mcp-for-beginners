<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:26:33+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sk"
}
-->
### -2- Vytvorenie projektu

Teraz, keď máte nainštalovaný SDK, vytvorme ďalší projekt:

### -3- Vytvorenie súborov projektu

### -4- Vytvorenie kódu servera

### -5- Pridanie nástroja a zdroja

Pridajte nástroj a zdroj pridaním nasledujúceho kódu:

### -6- Finálny kód

Pridajme posledný kód, ktorý potrebujeme, aby sa server mohol spustiť:

### -7- Testovanie servera

Spustite server pomocou nasledujúceho príkazu:

### -8- Spustenie pomocou inspektora

Inspector je skvelý nástroj, ktorý dokáže spustiť váš server a umožní vám s ním interagovať, aby ste mohli otestovať, či funguje. Spustime ho:

> [!NOTE]
> v poli "príkaz" to môže vyzerať inak, pretože obsahuje príkaz na spustenie servera s vaším konkrétnym runtime

Mali by ste vidieť nasledujúce používateľské rozhranie:

![Pripojiť](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sk.png)

1. Pripojte sa k serveru kliknutím na tlačidlo Connect
  Po pripojení by ste mali vidieť toto:

  ![Pripojené](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.sk.png)

2. Vyberte "Tools" a "listTools", mali by ste vidieť možnosť "Add", vyberte ju a vyplňte hodnoty parametrov.

  Mali by ste vidieť nasledujúcu odpoveď, teda výsledok z nástroja "add":

  ![Výsledok spustenia add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.sk.png)

Gratulujeme, podarilo sa vám vytvoriť a spustiť váš prvý server!

### Oficiálne SDK

MCP poskytuje oficiálne SDK pre viaceré jazyky:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Udržiavané v spolupráci s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Udržiavané v spolupráci so Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiálna implementácia v TypeScripte
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiálna implementácia v Pythone
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficiálna implementácia v Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Udržiavané v spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficiálna implementácia v Rust

## Kľúčové poznatky

- Nastavenie vývojového prostredia MCP je jednoduché vďaka SDK špecifickým pre jednotlivé jazyky
- Vývoj MCP serverov zahŕňa tvorbu a registráciu nástrojov s jasne definovanými schémami
- Testovanie a ladenie sú nevyhnutné pre spoľahlivé implementácie MCP

## Ukážky

- [Java kalkulačka](../samples/java/calculator/README.md)
- [.Net kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulačka](../samples/javascript/README.md)
- [TypeScript kalkulačka](../samples/typescript/README.md)
- [Python kalkulačka](../../../../03-GettingStarted/samples/python)

## Zadanie

Vytvorte jednoduchý MCP server s nástrojom podľa vášho výberu:

1. Implementujte nástroj vo vašom preferovanom jazyku (.NET, Java, Python alebo JavaScript).
2. Definujte vstupné parametre a návratové hodnoty.
3. Spustite nástroj inspector, aby ste overili, že server funguje podľa očakávaní.
4. Otestujte implementáciu s rôznymi vstupmi.

## Riešenie

[Riešenie](./solution/README.md)

## Dodatočné zdroje

- [Vytváranie agentov pomocou Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Vzdialený MCP s Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Čo ďalej

Ďalej: [Začíname s MCP klientmi](/03-GettingStarted/02-client/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.