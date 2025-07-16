<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:53:35+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sl"
}
-->
### -2- Ustvari projekt

Zdaj, ko imate nameščen SDK, ustvarimo naslednji projekt:

### -3- Ustvari datoteke projekta

### -4- Ustvari kodo strežnika

### -5- Dodajanje orodja in vira

Dodajte orodje in vir z naslednjo kodo:

### -6 Končna koda

Dodajmo zadnjo kodo, ki jo potrebujemo, da se strežnik lahko zažene:

### -7- Preizkusi strežnik

Zaženi strežnik z naslednjim ukazom:

### -8- Zaženi z uporabo inspectorja

Inspector je odlično orodje, ki lahko zažene vaš strežnik in vam omogoči interakcijo z njim, da lahko preizkusite, ali deluje. Zaženimo ga:
> [!NOTE]
> v polju "command" je lahko videti drugače, saj vsebuje ukaz za zagon strežnika z vašim specifičnim runtime-om/
Videti bi morali naslednji uporabniški vmesnik:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Povežite se s strežnikom s klikom na gumb Connect
  Ko se povežete s strežnikom, bi morali videti naslednje:

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Izberite "Tools" in "listTools", prikazal se bo "Add", izberite "Add" in vnesite vrednosti parametrov.

  Videli boste naslednji odgovor, torej rezultat orodja "add":

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Čestitke, uspelo vam je ustvariti in zagnati svoj prvi strežnik!

### Uradni SDK-ji

MCP ponuja uradne SDK-je za več programskih jezikov:

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
- Testiranje in odpravljanje napak sta ključna za zanesljive MCP implementacije

## Primeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Naloga

Ustvarite preprost MCP strežnik z orodjem po vaši izbiri:

1. Implementirajte orodje v vašem priljubljenem jeziku (.NET, Java, Python ali JavaScript).
2. Določite vhodne parametre in vrednosti, ki jih orodje vrača.
3. Zaženite orodje inspector, da preverite, ali strežnik deluje kot je predvideno.
4. Preizkusite implementacijo z različnimi vhodnimi podatki.

## Rešitev

[Solution](./solution/README.md)

## Dodatni viri

- [Gradnja agentov z Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Oddaljeni MCP z Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Kaj sledi

Naslednje: [Začetek z MCP odjemalci](../02-client/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.