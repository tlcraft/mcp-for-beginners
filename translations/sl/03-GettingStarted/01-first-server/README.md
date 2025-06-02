<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:18:36+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sl"
}
-->
### -2- Ustvari projekt

Zdaj, ko imaš nameščen SDK, ustvarimo naslednji projekt:

### -3- Ustvari datoteke projekta

### -4- Ustvari kodo strežnika

### -5- Dodajanje orodja in vira

Dodaj orodje in vir z naslednjo kodo:

### -6 Končna koda

Dodajmo zadnjo kodo, ki jo potrebujemo, da se strežnik lahko zažene:

### -7- Preizkusi strežnik

Zaženi strežnik z naslednjim ukazom:

### -8- Zaženi z inspektorjem

Inspektor je odlično orodje, ki lahko zažene tvoj strežnik in ti omogoči interakcijo z njim, da lahko preveriš, ali deluje. Začnimo:

> [!NOTE]
> V polju "ukaz" se lahko prikaže drugače, saj vsebuje ukaz za zagon strežnika s tvojim specifičnim runtime-om.

Videti bi moral naslednji uporabniški vmesnik:

![Poveži](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sl.png)

1. Poveži se s strežnikom tako, da izbereš gumb Connect  
   Ko se povežeš s strežnikom, bi moral videti naslednje:

   ![Povezan](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.sl.png)

2. Izberi "Tools" in "listTools", prikazati bi se moral "Add", izberi "Add" in izpolni vrednosti parametrov.

   Videti bi moral naslednji odgovor, torej rezultat orodja "add":

   ![Rezultat izvajanja add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.sl.png)

Čestitke, uspel si ustvariti in zagnati svoj prvi strežnik!

### Uradni SDK-ji

MCP ponuja uradne SDK-je za več programskih jezikov:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - vzdrževan v sodelovanju z Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - vzdrževan v sodelovanju s Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - uradna TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - uradna Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - uradna Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - vzdrževan v sodelovanju z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - uradna Rust implementacija

## Ključne ugotovitve

- Nastavitev MCP razvojnega okolja je preprosta z jezikovno specifičnimi SDK-ji
- Izgradnja MCP strežnikov vključuje ustvarjanje in registracijo orodij z jasnimi shemami
- Testiranje in odpravljanje napak sta ključna za zanesljive MCP implementacije

## Vzorci

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Naloga

Ustvari preprost MCP strežnik z orodjem po tvoji izbiri:
1. Implementiraj orodje v želenem jeziku (.NET, Java, Python ali JavaScript).
2. Določi vhodne parametre in povratne vrednosti.
3. Zaženi inspektor, da preveriš, ali strežnik deluje kot je predvideno.
4. Testiraj implementacijo z različnimi vnosi.

## Rešitev

[Rešitev](./solution/README.md)

## Dodatni viri

- [MCP GitHub repozitorij](https://github.com/microsoft/mcp-for-beginners)

## Kaj sledi

Naslednje: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.