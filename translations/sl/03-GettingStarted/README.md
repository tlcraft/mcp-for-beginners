<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T01:23:51+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sl"
}
-->
## Začetek

Ta razdelek vsebuje več lekcij:

- **1 Vaš prvi strežnik**, v tej prvi lekciji se boste naučili, kako ustvariti svoj prvi strežnik in ga pregledati z orodjem za inšpekcijo, kar je dragocen način za testiranje in odpravljanje napak na strežniku, [do lekcije](/03-GettingStarted/01-first-server/README.md)

- **2 Odjemalec**, v tej lekciji se boste naučili, kako napisati odjemalca, ki se lahko poveže z vašim strežnikom, [do lekcije](/03-GettingStarted/02-client/README.md)

- **3 Odjemalec z LLM**, še boljši način pisanja odjemalca je, da mu dodate LLM, da lahko "pogaja" s strežnikom, kaj naj naredi, [do lekcije](/03-GettingStarted/03-llm-client/README.md)

- **4 Uporaba strežnika v načinu GitHub Copilot Agent v Visual Studio Code**. Tukaj si ogledujemo, kako poganjati naš MCP strežnik neposredno v Visual Studio Code, [do lekcije](/03-GettingStarted/04-vscode/README.md)

- **5 Poraba preko SSE (Server Sent Events)** SSE je standard za pretakanje s strežnika na odjemalca, ki omogoča strežnikom pošiljanje posodobitev v realnem času preko HTTP, [do lekcije](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP pretakanje z MCP (Streamable HTTP)**. Spoznajte sodobno HTTP pretakanje, obvestila o napredku in kako implementirati razširljive, realnočasovne MCP strežnike in odjemalce z uporabo Streamable HTTP, [do lekcije](/03-GettingStarted/06-http-streaming/README.md)

- **7 Uporaba AI Toolkit za VSCode** za uporabo in testiranje vaših MCP odjemalcev in strežnikov, [do lekcije](/03-GettingStarted/07-aitk/README.md)

- **8 Testiranje**. Tukaj se bomo osredotočili predvsem na različne načine testiranja strežnika in odjemalca, [do lekcije](/03-GettingStarted/08-testing/README.md)

- **9 Namestitev**. Ta poglavje bo obravnavalo različne načine nameščanja vaših MCP rešitev, [do lekcije](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) je odprt protokol, ki standardizira način, kako aplikacije zagotavljajo kontekst LLM-jem. MCP lahko primerjate z USB-C priključkom za AI aplikacije – zagotavlja standardiziran način povezovanja AI modelov z različnimi podatkovnimi viri in orodji.

## Cilji učenja

Na koncu te lekcije boste znali:

- Nastaviti razvojno okolje za MCP v C#, Javi, Pythonu, TypeScriptu in JavaScriptu
- Zgraditi in namestiti osnovne MCP strežnike s prilagojenimi funkcijami (viri, pozivi in orodja)
- Ustvariti gostiteljske aplikacije, ki se povežejo z MCP strežniki
- Testirati in odpravljati napake v MCP implementacijah
- Razumeti pogoste težave pri nastavitvi in njihove rešitve
- Povezati vaše MCP implementacije s priljubljenimi LLM storitvami

## Nastavitev MCP okolja

Preden začnete z delom na MCP, je pomembno, da pripravite razvojno okolje in razumete osnovni potek dela. Ta razdelek vas bo vodil skozi začetne korake, da boste lahko brez težav začeli z MCP.

### Predpogoji

Preden začnete z razvojem MCP, poskrbite, da imate:

- **Razvojno okolje**: za izbrani programski jezik (C#, Java, Python, TypeScript ali JavaScript)
- **IDE/Urejevalnik**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ali kateri koli sodoben urejevalnik kode
- **Upravitelji paketov**: NuGet, Maven/Gradle, pip ali npm/yarn
- **API ključi**: za vse AI storitve, ki jih nameravate uporabljati v gostiteljskih aplikacijah

### Uradni SDK-ji

V naslednjih poglavjih boste videli rešitve, zgrajene v Pythonu, TypeScriptu, Javi in .NET. Tukaj so vsi uradno podprti SDK-ji.

MCP ponuja uradne SDK-je za več jezikov:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - vzdržuje ga Microsoft v sodelovanju
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - vzdržuje ga Spring AI v sodelovanju
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - uradna TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - uradna Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - uradna Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - vzdržuje ga Loopwork AI v sodelovanju
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - uradna Rust implementacija

## Glavne ugotovitve

- Nastavitev MCP razvojnega okolja je enostavna z jezikovno specifičnimi SDK-ji
- Gradnja MCP strežnikov vključuje ustvarjanje in registracijo orodij s jasnimi shemami
- MCP odjemalci se povezujejo s strežniki in modeli za izkoriščanje razširjenih zmogljivosti
- Testiranje in odpravljanje napak sta ključna za zanesljive MCP implementacije
- Možnosti nameščanja segajo od lokalnega razvoja do rešitev v oblaku

## Vaje

Imamo nabor primerov, ki dopolnjujejo vaje, ki jih boste videli v vseh poglavjih tega razdelka. Poleg tega ima vsako poglavje svoje vaje in naloge.

- [Java Kalkulator](./samples/java/calculator/README.md)
- [.Net Kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](./samples/javascript/README.md)
- [TypeScript Kalkulator](./samples/typescript/README.md)
- [Python Kalkulator](../../../03-GettingStarted/samples/python)

## Dodatni viri

- [Gradnja agentov z uporabo Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Oddaljeni MCP z Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Kaj sledi

Naslednje: [Ustvarjanje vašega prvega MCP strežnika](/03-GettingStarted/01-first-server/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.