<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:28:16+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sl"
}
-->
### -2- Ustvarite projekt

Zdaj, ko imate nameščen SDK, ustvarimo naslednji projekt:

### -3- Ustvarite datoteke projekta

### -4- Ustvarite kodo strežnika

### -5- Dodajanje orodja in vira

Dodajte orodje in vir z naslednjo kodo:

### -6 Končna koda

Dodajmo zadnjo kodo, ki jo potrebujemo, da se strežnik lahko zažene:

### -7- Preizkusite strežnik

Zaženite strežnik z naslednjim ukazom:

### -8- Zaženite z uporabo inspectorja

Inspector je odlično orodje, ki lahko zažene vaš strežnik in omogoči interakcijo z njim, da lahko preizkusite njegovo delovanje. Zaženimo ga:

> [!NOTE]
> v polju "ukaz" je lahko prikazan drugačen ukaz, saj vsebuje ukaz za zagon strežnika z vašim specifičnim runtime-om

Videli boste naslednji uporabniški vmesnik:

![Poveži](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sl.png)

1. Povežite se s strežnikom s klikom na gumb Connect  
   Ko se povežete s strežnikom, bi morali videti naslednje:

   ![Povezan](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.sl.png)

2. Izberite "Tools" in "listTools", prikazal se bo gumb "Add", kliknite "Add" in izpolnite vrednosti parametrov.

   Videli boste naslednji odgovor, torej rezultat orodja "add":

   ![Rezultat zagona add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.sl.png)

Čestitke, uspelo vam je ustvariti in zagnati vaš prvi strežnik!

### Uradni SDK-ji

MCP nudi uradne SDK-je za več programskih jezikov:

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
3. Zaženite inspector orodje, da zagotovite, da strežnik deluje kot je predvideno.
4. Preizkusite implementacijo z različnimi vhodnimi podatki.

## Rešitev

[Rešitev](./solution/README.md)

## Dodatni viri

- [Gradnja agentov z Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Oddaljeni MCP z Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Kaj sledi

Naslednje: [Začetek z MCP klienti](/03-GettingStarted/02-client/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.