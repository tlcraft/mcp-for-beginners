<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:14:28+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "cs"
}
-->
## Začínáme  

Tato sekce se skládá z několika lekcí:

- **-1- Váš první server**, v této první lekci se naučíte, jak vytvořit svůj první server a prozkoumat ho pomocí inspektoru, což je cenný nástroj pro testování a ladění vašeho serveru, [k lekci](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, v této lekci se naučíte, jak napsat klienta, který se může připojit k vašemu serveru, [k lekci](/03-GettingStarted/02-client/README.md)

- **-3- Klient s LLM**, ještě lepší způsob, jak napsat klienta, je přidat k němu LLM, aby mohl "vyjednávat" s vaším serverem, co má dělat, [k lekci](/03-GettingStarted/03-llm-client/README.md)

- **-4- Použití serveru v režimu GitHub Copilot Agent ve Visual Studio Code**. Zde se podíváme na spuštění našeho MCP Serveru přímo ve Visual Studio Code, [k lekci](/03-GettingStarted/04-vscode/README.md)

- **-5- Spotřeba ze SSE (Server Sent Events)** SSE je standard pro streamování server-klient, který umožňuje serverům posílat klientům aktualizace v reálném čase přes HTTP [k lekci](/03-GettingStarted/05-sse-server/README.md)

- **-6- Využití AI Toolkit pro VSCode** k využití a testování vašich MCP Klientů a Serverů [k lekci](/03-GettingStarted/06-aitk/README.md)

- **-7 Testování**. Zde se zaměříme zejména na to, jak můžeme testovat náš server a klienta různými způsoby, [k lekci](/03-GettingStarted/07-testing/README.md)

- **-8- Nasazení**. Tato kapitola se zaměří na různé způsoby nasazení vašich MCP řešení, [k lekci](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) je otevřený protokol, který standardizuje, jak aplikace poskytují kontext LLMs. Představte si MCP jako USB-C port pro AI aplikace - poskytuje standardizovaný způsob, jak propojit AI modely s různými datovými zdroji a nástroji.

## Cíle učení

Na konci této lekce budete schopni:

- Nastavit vývojová prostředí pro MCP v C#, Java, Python, TypeScript a JavaScript
- Vytvořit a nasadit základní MCP servery s vlastními funkcemi (zdroje, výzvy a nástroje)
- Vytvořit hostitelské aplikace, které se připojují k MCP serverům
- Testovat a ladit implementace MCP
- Pochopit běžné problémy při nastavování a jejich řešení
- Připojit vaše implementace MCP k populárním LLM službám

## Nastavení vašeho MCP prostředí

Než začnete pracovat s MCP, je důležité připravit vaše vývojové prostředí a pochopit základní pracovní postup. Tato sekce vás provede počátečními kroky nastavení, abyste mohli hladce začít s MCP.

### Předpoklady

Předtím, než se pustíte do vývoje MCP, ujistěte se, že máte:

- **Vývojové prostředí**: Pro váš vybraný jazyk (C#, Java, Python, TypeScript nebo JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm nebo jakýkoli moderní editor kódu
- **Správci balíčků**: NuGet, Maven/Gradle, pip nebo npm/yarn
- **API klíče**: Pro jakékoli AI služby, které plánujete použít ve vašich hostitelských aplikacích


### Oficiální SDK

V nadcházejících kapitolách uvidíte řešení postavená pomocí Pythonu, TypeScriptu, Javy a .NET. Zde jsou všechny oficiálně podporované SDK.

MCP poskytuje oficiální SDK pro více jazyků:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Udržováno ve spolupráci s Microsoftem
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Udržováno ve spolupráci s Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Oficiální implementace TypeScriptu
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Oficiální implementace Pythonu
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Oficiální implementace Kotlinu
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Udržováno ve spolupráci s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Oficiální implementace Rustu

## Klíčové poznatky

- Nastavení vývojového prostředí MCP je jednoduché s jazykově specifickými SDK
- Vytváření MCP serverů zahrnuje vytváření a registraci nástrojů s jasnými schématy
- MCP klienti se připojují k serverům a modelům pro využití rozšířených schopností
- Testování a ladění jsou zásadní pro spolehlivé implementace MCP
- Možnosti nasazení sahají od místního vývoje až po cloudová řešení

## Procvičování

Máme sadu příkladů, které doplňují cvičení, která uvidíte ve všech kapitolách této sekce. Každá kapitola navíc obsahuje vlastní cvičení a úkoly

- [Java Kalkulačka](./samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](./samples/javascript/README.md)
- [TypeScript Kalkulačka](./samples/typescript/README.md)
- [Python Kalkulačka](../../../03-GettingStarted/samples/python)

## Další zdroje

- [MCP GitHub Repozitář](https://github.com/microsoft/mcp-for-beginners)

## Co dál

Dále: [Vytvoření vašeho prvního MCP serveru](/03-GettingStarted/01-first-server/README.md)

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby pro překlad AI [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.