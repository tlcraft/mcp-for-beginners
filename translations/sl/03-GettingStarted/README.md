<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:36:05+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sl"
}
-->
## Začetek  

Ta razdelek vsebuje več lekcij:

- **1 Vaš prvi strežnik**, v tej prvi lekciji se boste naučili, kako ustvariti svoj prvi strežnik in ga pregledati z orodjem za inšpekcijo, kar je dragocen način za testiranje in odpravljanje napak na strežniku, [do lekcije](01-first-server/README.md)

- **2 Odjemalec**, v tej lekciji se boste naučili, kako napisati odjemalca, ki se lahko poveže z vašim strežnikom, [do lekcije](02-client/README.md)

- **3 Odjemalec z LLM**, še boljši način pisanja odjemalca je dodajanje LLM, da lahko "pogaja" z vašim strežnikom o tem, kaj naj naredi, [do lekcije](03-llm-client/README.md)

- **4 Uporaba strežnika v načinu GitHub Copilot Agent v Visual Studio Code**. Tukaj si ogledamo, kako zagnati naš MCP strežnik znotraj Visual Studio Code, [do lekcije](04-vscode/README.md)

- **5 Poraba iz SSE (Server Sent Events)** SSE je standard za pretakanje s strežnika na odjemalca, ki omogoča strežnikom, da preko HTTP-ja pošiljajo posodobitve v realnem času, [do lekcije](05-sse-server/README.md)

- **6 HTTP pretakanje z MCP (Streamable HTTP)**. Spoznajte sodobno HTTP pretakanje, obvestila o napredku in kako implementirati razširljive, realnočasovne MCP strežnike in odjemalce z uporabo Streamable HTTP, [do lekcije](06-http-streaming/README.md)

- **7 Uporaba AI Toolkit za VSCode** za porabo in testiranje vaših MCP odjemalcev in strežnikov, [do lekcije](07-aitk/README.md)

- **8 Testiranje**. Tukaj se bomo osredotočili predvsem na različne načine testiranja našega strežnika in odjemalca, [do lekcije](08-testing/README.md)

- **9 Namestitev**. Ta poglavje bo obravnavalo različne načine nameščanja vaših MCP rešitev, [do lekcije](09-deployment/README.md)


Model Context Protocol (MCP) je odprt protokol, ki standardizira, kako aplikacije zagotavljajo kontekst LLM-jem. MCP si lahko predstavljate kot USB-C priključek za AI aplikacije – omogoča standardiziran način povezovanja AI modelov z različnimi viri podatkov in orodji.

## Cilji učenja

Na koncu te lekcije boste znali:

- Nastaviti razvojna okolja za MCP v C#, Javi, Pythonu, TypeScriptu in JavaScriptu
- Zgraditi in namestiti osnovne MCP strežnike s prilagojenimi funkcijami (viri, pozivi in orodja)
- Ustvariti gostiteljske aplikacije, ki se povezujejo z MCP strežniki
- Testirati in odpravljati napake v MCP implementacijah
- Razumeti pogoste izzive pri nastavitvi in njihove rešitve
- Povezati svoje MCP implementacije s priljubljenimi LLM storitvami

## Nastavitev vašega MCP okolja

Preden začnete delati z MCP, je pomembno, da pripravite razvojno okolje in razumete osnovni potek dela. Ta razdelek vas bo vodil skozi začetne korake nastavitve, da bo začetek z MCP potekal gladko.

### Predpogoji

Preden se lotite razvoja MCP, poskrbite, da imate:

- **Razvojno okolje**: za izbrani programski jezik (C#, Java, Python, TypeScript ali JavaScript)
- **IDE/Urejevalnik**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ali kateri koli sodoben urejevalnik kode
- **Upravitelji paketov**: NuGet, Maven/Gradle, pip ali npm/yarn
- **API ključi**: za vse AI storitve, ki jih nameravate uporabljati v gostiteljskih aplikacijah


### Uradni SDK-ji

V prihajajočih poglavjih boste videli rešitve, zgrajene z uporabo Pythona, TypeScripta, Jave in .NET. Tukaj so vsi uradno podprti SDK-ji.

MCP ponuja uradne SDK-je za več jezikov:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - vzdrževan v sodelovanju z Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - vzdrževan v sodelovanju s Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - uradna implementacija za TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - uradna implementacija za Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - uradna implementacija za Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - vzdrževan v sodelovanju z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - uradna implementacija za Rust

## Ključne ugotovitve

- Nastavitev MCP razvojnega okolja je enostavna z jezikovno specifičnimi SDK-ji
- Gradnja MCP strežnikov vključuje ustvarjanje in registracijo orodij z jasnimi shemami
- MCP odjemalci se povezujejo s strežniki in modeli za izkoriščanje razširjenih zmogljivosti
- Testiranje in odpravljanje napak sta ključna za zanesljive MCP implementacije
- Možnosti nameščanja segajo od lokalnega razvoja do rešitev v oblaku

## Vaja

Imamo nabor primerov, ki dopolnjujejo vaje, ki jih boste videli v vseh poglavjih tega razdelka. Poleg tega ima vsako poglavje tudi svoje vaje in naloge.

- [Java kalkulator](./samples/java/calculator/README.md)
- [.Net kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](./samples/javascript/README.md)
- [TypeScript kalkulator](./samples/typescript/README.md)
- [Python kalkulator](../../../03-GettingStarted/samples/python)

## Dodatni viri

- [Gradnja agentov z uporabo Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Oddaljeni MCP z Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Kaj sledi

Naslednje: [Ustvarjanje vašega prvega MCP strežnika](01-first-server/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.