<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:16:14+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sk"
}
-->
### -2- Vytvorenie projektu

Teraz, keď máte nainštalovaný SDK, poďme vytvoriť projekt:  

### -3- Vytvorenie súborov projektu

### -4- Vytvorenie kódu servera

### -5- Pridanie nástroja a zdroja

Pridajte nástroj a zdroj pridaním nasledujúceho kódu:  

### -6- Finálny kód

Pridajme posledný potrebný kód, aby sa server mohol spustiť:  

### -7- Testovanie servera

Spustite server pomocou nasledujúceho príkazu:  

### -8- Spustenie pomocou inspektora

Inspektor je skvelý nástroj, ktorý môže spustiť váš server a umožní vám s ním interagovať, aby ste mohli overiť jeho funkčnosť. Spustime ho:  

> [!NOTE]
> v poli "príkaz" to môže vyzerať inak, pretože obsahuje príkaz na spustenie servera pre váš konkrétny runtime/

Mali by ste vidieť nasledujúce používateľské rozhranie:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sk.png)

1. Pripojte sa k serveru výberom tlačidla Connect  
   Po pripojení k serveru by ste mali vidieť toto:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.sk.png)

2. Vyberte "Tools" a "listTools", mali by ste vidieť možnosť "Add", vyberte "Add" a vyplňte hodnoty parametrov.

   Mali by ste vidieť nasledujúcu odpoveď, teda výsledok z nástroja "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.sk.png)

Gratulujeme, podarilo sa vám vytvoriť a spustiť váš prvý server!

### Oficiálne SDK

MCP poskytuje oficiálne SDK pre viaceré jazyky:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - udržiavané v spolupráci s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - udržiavané v spolupráci so Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - oficiálna implementácia v TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - oficiálna implementácia v Pythone
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - oficiálna implementácia v Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - udržiavané v spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - oficiálna implementácia v Rust

## Kľúčové poznatky

- Nastavenie vývojového prostredia MCP je jednoduché vďaka SDK špecifickým pre jednotlivé jazyky
- Vývoj MCP serverov zahŕňa vytváranie a registráciu nástrojov s jasne definovanými schémami
- Testovanie a ladenie sú nevyhnutné pre spoľahlivé implementácie MCP

## Ukážky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zadanie

Vytvorte jednoduchý MCP server s nástrojom podľa vlastného výberu:
1. Implementujte nástroj vo vašom preferovanom jazyku (.NET, Java, Python alebo JavaScript).
2. Definujte vstupné parametre a návratové hodnoty.
3. Spustite inspektora, aby ste overili, že server funguje správne.
4. Otestujte implementáciu s rôznymi vstupmi.

## Riešenie

[Riešenie](./solution/README.md)

## Ďalšie zdroje

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Čo ďalej

Ďalej: [Začíname s MCP klientmi](/03-GettingStarted/02-client/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.