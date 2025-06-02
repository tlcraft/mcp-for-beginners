<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:15:47+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "cs"
}
-->
### -2- Vytvoření projektu

Nyní, když máte SDK nainstalované, pojďme vytvořit projekt:

### -3- Vytvoření souborů projektu

### -4- Vytvoření kódu serveru

### -5- Přidání nástroje a zdroje

Přidejte nástroj a zdroj přidáním následujícího kódu:

### -6- Finální kód

Přidáme poslední kód, který potřebujeme, aby server mohl startovat:

### -7- Testování serveru

Spusťte server pomocí následujícího příkazu:

### -8- Spuštění pomocí inspektoru

Inspektor je skvělý nástroj, který dokáže spustit váš server a umožní vám s ním interagovat, abyste mohli otestovat, že vše funguje. Pojďme ho spustit:

> [!NOTE]
> V poli „command“ může být zobrazen příkaz pro spuštění serveru ve vašem konkrétním runtime, takže to může vypadat trochu jinak.

Měli byste vidět následující uživatelské rozhraní:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.cs.png)

1. Připojte se k serveru kliknutím na tlačítko Connect.  
   Po připojení k serveru byste měli vidět následující:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.cs.png)

2. Vyberte „Tools“ a „listTools“, měli byste vidět možnost „Add“. Klikněte na „Add“ a vyplňte hodnoty parametrů.

   Měli byste vidět následující odpověď, tedy výsledek z nástroje „add“:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.cs.png)

Gratulujeme, podařilo se vám vytvořit a spustit váš první server!

### Oficiální SDK

MCP nabízí oficiální SDK pro více jazyků:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – udržováno ve spolupráci s Microsoftem
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – udržováno ve spolupráci se Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – oficiální implementace v TypeScriptu
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – oficiální implementace v Pythonu
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – oficiální implementace v Kotlinu
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – udržováno ve spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – oficiální implementace v Rustu

## Klíčové body

- Nastavení vývojového prostředí MCP je jednoduché díky SDK specifickým pro jednotlivé jazyky
- Vytváření MCP serverů zahrnuje tvorbu a registraci nástrojů s jasně definovanými schématy
- Testování a ladění jsou nezbytné pro spolehlivé implementace MCP

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Úkol

Vytvořte jednoduchý MCP server s nástrojem podle vašeho výběru:
1. Implementujte nástroj ve vámi preferovaném jazyce (.NET, Java, Python nebo JavaScript).
2. Definujte vstupní parametry a návratové hodnoty.
3. Spusťte inspektor, abyste ověřili, že server funguje podle očekávání.
4. Otestujte implementaci s různými vstupy.

## Řešení

[Řešení](./solution/README.md)

## Další zdroje

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Co dál

Další: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné interpretace vyplývající z použití tohoto překladu.