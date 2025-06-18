<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:26:11+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "cs"
}
-->
### -2- Vytvoření projektu

Nyní, když máte nainstalované SDK, vytvoříme další krok – projekt:

### -3- Vytvoření souborů projektu

### -4- Vytvoření kódu serveru

### -5- Přidání nástroje a zdroje

Přidejte nástroj a zdroj přidáním následujícího kódu:

### -6- Konečný kód

Přidejme poslední část kódu, kterou potřebujeme, aby server mohl startovat:

### -7- Testování serveru

Spusťte server následujícím příkazem:

### -8- Spuštění pomocí inspektoru

Inspektor je skvělý nástroj, který může spustit váš server a umožní vám s ním interagovat, abyste mohli otestovat, že funguje. Spusťme ho:

> [!NOTE]
> může to v poli „příkaz“ vypadat jinak, protože obsahuje příkaz pro spuštění serveru s vaším konkrétním runtime/

Měli byste vidět následující uživatelské rozhraní:

![Připojení](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.cs.png)

1. Připojte se k serveru kliknutím na tlačítko Připojit  
   Po připojení byste měli vidět toto:

   ![Připojeno](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.cs.png)

2. Vyberte „Tools“ a „listTools“, měli byste vidět možnost „Add“, klikněte na „Add“ a vyplňte hodnoty parametrů.

   Měli byste vidět následující odpověď, tedy výsledek z nástroje „add“:

   ![Výsledek spuštění add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.cs.png)

Gratulujeme, podařilo se vám vytvořit a spustit váš první server!

### Oficiální SDK

MCP poskytuje oficiální SDK pro několik jazyků:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Udržováno ve spolupráci s Microsoftem  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Udržováno ve spolupráci se Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Oficiální implementace v TypeScriptu  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Oficiální implementace v Pythonu  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Oficiální implementace v Kotlinu  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Udržováno ve spolupráci s Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Oficiální implementace v Rustu  

## Hlavní poznatky

- Nastavení vývojového prostředí MCP je jednoduché díky jazykově specifickým SDK  
- Vytváření MCP serverů zahrnuje tvorbu a registraci nástrojů s jasnými schématy  
- Testování a ladění jsou nezbytné pro spolehlivé MCP implementace  

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Zadání

Vytvořte jednoduchý MCP server s nástrojem dle vašeho výběru:

1. Implementujte nástroj ve vašem preferovaném jazyce (.NET, Java, Python nebo JavaScript).  
2. Definujte vstupní parametry a návratové hodnoty.  
3. Spusťte inspektor, abyste ověřili, že server funguje správně.  
4. Otestujte implementaci s různými vstupy.  

## Řešení

[Řešení](./solution/README.md)

## Další zdroje

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Co dál

Další: [Začínáme s MCP klienty](/03-GettingStarted/02-client/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro zásadní informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.