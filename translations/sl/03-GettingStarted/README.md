<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:18:18+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sl"
}
-->
## Getting Started  

Ta oddelek vsebuje več lekcij:

- **1 Your first server**, v tej prvi lekciji se boste naučili, kako ustvariti svoj prvi strežnik in ga pregledati z orodjem inspector, kar je koristen način za testiranje in odpravljanje napak na strežniku, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, v tej lekciji se boste naučili, kako napisati klienta, ki se lahko poveže z vašim strežnikom, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, še boljši način pisanja klienta je dodajanje LLM, da lahko "pogaja" z vašim strežnikom o tem, kaj naj naredi, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**. Tukaj si ogledujemo, kako zagnati naš MCP Server neposredno znotraj Visual Studio Code, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE je standard za pretakanje s strežnika na klienta, ki omogoča strežnikom, da preko HTTP-ja pošiljajo posodobitve v realnem času klientom [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilising AI Toolkit for VSCode** za uporabo in testiranje vaših MCP klientov in strežnikov [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **7 Testing**. Tukaj se bomo osredotočili predvsem na različne načine testiranja našega strežnika in klienta, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **8 Deployment**. Ta poglavje bo predstavilo različne načine nameščanja vaših MCP rešitev, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) je odprt protokol, ki standardizira, kako aplikacije zagotavljajo kontekst LLM-jem. MCP lahko razumete kot USB-C priključek za AI aplikacije – omogoča standardiziran način povezovanja AI modelov z različnimi viri podatkov in orodji.

## Learning Objectives

Na koncu te lekcije boste znali:

- Nastaviti razvojna okolja za MCP v C#, Javi, Pythonu, TypeScriptu in JavaScriptu
- Zgraditi in namestiti osnovne MCP strežnike s prilagojenimi funkcijami (viri, pozivi in orodja)
- Ustvariti gostiteljske aplikacije, ki se povežejo z MCP strežniki
- Testirati in odpravljati napake v MCP implementacijah
- Razumeti pogoste izzive pri nastavitvi in njihove rešitve
- Povezati svoje MCP implementacije s priljubljenimi LLM storitvami

## Setting Up Your MCP Environment

Preden začnete z delom na MCP, je pomembno pripraviti razvojno okolje in razumeti osnovni potek dela. Ta oddelek vas bo vodil skozi začetne korake za nemoten začetek z MCP.

### Prerequisites

Preden se lotite razvoja MCP, poskrbite, da imate:

- **Razvojno okolje**: za izbrani programski jezik (C#, Java, Python, TypeScript ali JavaScript)
- **IDE/Urejevalnik**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ali kateri koli sodoben urejevalnik kode
- **Upravitelji paketov**: NuGet, Maven/Gradle, pip ali npm/yarn
- **API ključi**: za katerokoli AI storitev, ki jo nameravate uporabiti v gostiteljskih aplikacijah


### Official SDKs

V prihajajočih poglavjih boste videli rešitve, zgrajene s pomočjo Pythona, TypeScripta, Jave in .NET. Tukaj so vsi uradno podprti SDK-ji.

MCP ponuja uradne SDK-je za več jezikov:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - vzdrževan v sodelovanju z Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - vzdrževan v sodelovanju s Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - uradna implementacija za TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - uradna implementacija za Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - uradna implementacija za Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - vzdrževan v sodelovanju z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - uradna implementacija za Rust

## Key Takeaways

- Nastavitev MCP razvojnega okolja je enostavna z jezikovno specifičnimi SDK-ji
- Gradnja MCP strežnikov vključuje ustvarjanje in registracijo orodij z jasnimi shemami
- MCP klienti se povezujejo s strežniki in modeli za uporabo razširjenih zmogljivosti
- Testiranje in odpravljanje napak sta ključna za zanesljive MCP implementacije
- Možnosti nameščanja segajo od lokalnega razvoja do rešitev v oblaku

## Practicing

Imamo nabor primerov, ki dopolnjujejo vaje, ki jih boste videli v vseh poglavjih tega oddelka. Poleg tega ima vsako poglavje tudi svoje vaje in naloge

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Naslednje: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.