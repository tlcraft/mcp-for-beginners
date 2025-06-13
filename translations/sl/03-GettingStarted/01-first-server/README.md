<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T06:10:04+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sl"
}
-->
### -2- Ustvari projekt

Zdaj, ko imaš nameščen SDK, ustvarimo naslednji projekt:

### -3- Ustvari projektne datoteke

### -4- Ustvari kodo strežnika

### -5- Dodajanje orodja in vira

Dodaj orodje in vir z naslednjo kodo:

### -6 Končna koda

Dodajmo zadnjo kodo, ki jo potrebujemo, da se strežnik lahko zažene:

### -7- Preizkusi strežnik

Zaženi strežnik z naslednjim ukazom:

### -8- Zaženi z uporabo inspektorja

Inspektor je odlično orodje, ki lahko zažene tvoj strežnik in ti omogoči interakcijo z njim, da preveriš, ali deluje. Zaženi ga tako:

> [!NOTE]
> v polju "command" se lahko prikaže drugačen ukaz, saj vsebuje ukaz za zagon strežnika s tvojim specifičnim runtime-om

Videti bi moral naslednji uporabniški vmesnik:

![Poveži](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sl.png)

1. Poveži se s strežnikom s klikom na gumb Connect  
   Ko se povežeš s strežnikom, bi moral videti naslednje:

   ![Povezan](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.sl.png)

2. Izberi "Tools" in "listTools", prikazati bi se moral gumb "Add", klikni "Add" in izpolni vrednosti parametrov.

Videti bi moral naslednji odgovor, torej rezultat iz orodja "add":

![Rezultat izvajanja add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.sl.png)

Čestitke, uspel si ustvariti in zagnati svoj prvi strežnik!

### Uradni SDK-ji

MCP ponuja uradne SDK-je za več jezikov:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - vzdrževanje v sodelovanju z Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - vzdrževanje v sodelovanju s Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - uradna TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - uradna Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - uradna Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - vzdrževanje v sodelovanju z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - uradna Rust implementacija

## Ključne ugotovitve

- Nastavitev MCP razvojnega okolja je preprosta z jezikovno specifičnimi SDK-ji
- Gradnja MCP strežnikov vključuje ustvarjanje in registracijo orodij z jasnimi shemami
- Testiranje in odpravljanje napak sta ključna za zanesljive MCP implementacije

## Primeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Naloga

Ustvari preprost MCP strežnik z orodjem po tvoji izbiri:  
1. Implementiraj orodje v svojem priljubljenem jeziku (.NET, Java, Python ali JavaScript).  
2. Določi vhodne parametre in povratne vrednosti.  
3. Zaženi orodje inspektor, da preveriš, ali strežnik deluje pravilno.  
4. Testiraj implementacijo z različnimi vnosi.

## Rešitev

[Rešitev](./solution/README.md)

## Dodatni viri

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Kaj sledi

Naslednje: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazumevanja ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.