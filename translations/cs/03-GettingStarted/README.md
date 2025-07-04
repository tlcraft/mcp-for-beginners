<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T18:37:02+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "cs"
}
-->
## Začínáme  

Tato sekce obsahuje několik lekcí:

- **1 Váš první server**, v této první lekci se naučíte, jak vytvořit svůj první server a prohlédnout si ho pomocí nástroje inspector, což je užitečný způsob, jak server testovat a ladit, [k lekci](/03-GettingStarted/01-first-server/README.md)

- **2 Klient**, v této lekci se naučíte, jak napsat klienta, který se dokáže připojit k vašemu serveru, [k lekci](/03-GettingStarted/02-client/README.md)

- **3 Klient s LLM**, ještě lepší způsob, jak napsat klienta, je přidat mu LLM, aby mohl s vaším serverem „vyjednávat“ o tom, co dělat, [k lekci](/03-GettingStarted/03-llm-client/README.md)

- **4 Použití serveru v režimu GitHub Copilot Agent ve Visual Studio Code**. Zde se podíváme, jak spustit náš MCP Server přímo ve Visual Studio Code, [k lekci](/03-GettingStarted/04-vscode/README.md)

- **5 Použití SSE (Server Sent Events)** SSE je standard pro streamování ze serveru na klienta, který umožňuje serverům posílat klientům aktualizace v reálném čase přes HTTP [k lekci](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP streamování s MCP (Streamable HTTP)**. Naučte se o moderním HTTP streamování, notifikacích o průběhu a jak implementovat škálovatelné, reálné MCP servery a klienty pomocí Streamable HTTP. [k lekci](/03-GettingStarted/06-http-streaming/README.md)

- **7 Využití AI Toolkit pro VSCode** k používání a testování vašich MCP klientů a serverů [k lekci](/03-GettingStarted/07-aitk/README.md)

- **8 Testování**. Zde se zaměříme hlavně na různé způsoby, jak testovat náš server a klienta, [k lekci](/03-GettingStarted/08-testing/README.md)

- **9 Nasazení**. Tato kapitola se bude věnovat různým způsobům nasazení vašich MCP řešení, [k lekci](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) je otevřený protokol, který standardizuje způsob, jakým aplikace poskytují kontext LLM. MCP si můžete představit jako USB-C port pro AI aplikace – poskytuje standardizovaný způsob připojení AI modelů k různým zdrojům dat a nástrojům.

## Cíle učení

Na konci této lekce budete umět:

- Nastavit vývojové prostředí pro MCP v C#, Java, Python, TypeScript a JavaScript
- Vytvořit a nasadit základní MCP servery s vlastními funkcemi (zdroje, výzvy a nástroje)
- Vytvořit hostitelské aplikace, které se připojují k MCP serverům
- Testovat a ladit implementace MCP
- Pochopit běžné problémy při nastavení a jejich řešení
- Připojit své MCP implementace k populárním LLM službám

## Nastavení vašeho MCP prostředí

Než začnete pracovat s MCP, je důležité připravit si vývojové prostředí a pochopit základní pracovní postup. Tato sekce vás provede počátečním nastavením, aby byl váš start s MCP co nejplynulejší.

### Požadavky

Než se pustíte do vývoje s MCP, ujistěte se, že máte:

- **Vývojové prostředí**: Pro vámi zvolený jazyk (C#, Java, Python, TypeScript nebo JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm nebo jakýkoli moderní editor kódu
- **Správce balíčků**: NuGet, Maven/Gradle, pip nebo npm/yarn
- **API klíče**: Pro jakékoli AI služby, které plánujete používat ve svých hostitelských aplikacích


### Oficiální SDK

V následujících kapitolách uvidíte řešení postavená pomocí Pythonu, TypeScriptu, Javy a .NET. Zde jsou všechny oficiálně podporované SDK.

MCP poskytuje oficiální SDK pro více jazyků:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Udržováno ve spolupráci s Microsoftem
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Udržováno ve spolupráci se Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiální implementace pro TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiální implementace pro Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficiální implementace pro Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Udržováno ve spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficiální implementace pro Rust

## Hlavní poznatky

- Nastavení vývojového prostředí MCP je jednoduché díky SDK specifickým pro jednotlivé jazyky
- Vytváření MCP serverů zahrnuje tvorbu a registraci nástrojů s jasnými schématy
- MCP klienti se připojují k serverům a modelům, aby využili rozšířené funkce
- Testování a ladění jsou klíčové pro spolehlivé implementace MCP
- Možnosti nasazení sahají od lokálního vývoje po cloudová řešení

## Procvičování

Máme sadu ukázek, které doplňují cvičení, jež uvidíte ve všech kapitolách této sekce. Navíc každá kapitola má také vlastní cvičení a úkoly.

- [Java Kalkulačka](./samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](./samples/javascript/README.md)
- [TypeScript Kalkulačka](./samples/typescript/README.md)
- [Python Kalkulačka](../../../03-GettingStarted/samples/python)

## Další zdroje

- [Vytváření agentů pomocí Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Vzdálené MCP s Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Co dál

Další: [Vytvoření vašeho prvního MCP serveru](./01-first-server/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.