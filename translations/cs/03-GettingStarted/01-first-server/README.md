<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5331ffd328a54b90f76706c52b673e27",
  "translation_date": "2025-05-27T16:21:30+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "cs"
}
-->
### -2- Vytvoření projektu

Nyní, když máte nainstalovaný SDK, pojďme vytvořit projekt:

### -3- Vytvoření souborů projektu

### -4- Vytvoření kódu serveru

### -5- Přidání nástroje a zdroje

Přidejte nástroj a zdroj přidáním následujícího kódu:

### -6- Konečný kód

Přidáme poslední kód, který potřebujeme, aby server mohl startovat:

### -7- Testování serveru

Spusťte server následujícím příkazem:

### -8- Spuštění pomocí inspektoru

Inspektor je skvělý nástroj, který dokáže spustit váš server a umožní vám s ním interagovat, abyste mohli ověřit, že funguje. Pojďme ho spustit:

> [!NOTE]
> v poli "command" to může vypadat trochu jinak, protože obsahuje příkaz pro spuštění serveru ve vašem konkrétním runtime

Měli byste vidět následující uživatelské rozhraní:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.cs.png)

1. Připojte se k serveru kliknutím na tlačítko Connect  
   Po připojení byste měli vidět následující:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.cs.png)

2. Vyberte "Tools" a "listTools", měli byste vidět možnost "Add", klikněte na "Add" a vyplňte hodnoty parametrů.

   Měli byste vidět následující odpověď, tedy výsledek z nástroje "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.cs.png)

Gratulujeme, podařilo se vám vytvořit a spustit váš první server!

### Oficiální SDK

MCP nabízí oficiální SDK pro několik jazyků:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Spravováno ve spolupráci s Microsoftem
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spravováno ve spolupráci se Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiální implementace pro TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiální implementace pro Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficiální implementace pro Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Spravováno ve spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficiální implementace pro Rust

## Hlavní poznatky

- Nastavení vývojového prostředí pro MCP je jednoduché díky SDK specifickým pro jednotlivé jazyky
- Vytváření MCP serverů zahrnuje tvorbu a registraci nástrojů s jasně definovanými schématy
- Testování a ladění jsou klíčové pro spolehlivou implementaci MCP

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zadání

Vytvořte jednoduchý MCP server s nástrojem podle vašeho výběru:
1. Implementujte nástroj ve vašem preferovaném jazyce (.NET, Java, Python nebo JavaScript).
2. Definujte vstupní parametry a návratové hodnoty.
3. Spusťte inspektor, abyste ověřili, že server funguje správně.
4. Testujte implementaci s různými vstupy.

## Řešení

[Řešení](./solution/README.md)

## Další zdroje

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Co dál

Další krok: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.