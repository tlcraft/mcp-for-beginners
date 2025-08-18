<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "858362ce0118de3fec0f9114bf396101",
  "translation_date": "2025-08-18T17:29:10+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hr"
}
-->
## Početak rada  

[![Izgradite svoj prvi MCP poslužitelj](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.hr.png)](https://youtu.be/sNDZO9N4m9Y)

_(Kliknite na sliku iznad za pregled videa ove lekcije)_

Ovaj odjeljak sastoji se od nekoliko lekcija:

- **1 Vaš prvi poslužitelj**, u ovoj prvoj lekciji naučit ćete kako stvoriti svoj prvi poslužitelj i pregledati ga pomoću alata za inspekciju, vrijednog alata za testiranje i otklanjanje pogrešaka na vašem poslužitelju, [na lekciju](01-first-server/README.md)

- **2 Klijent**, u ovoj lekciji naučit ćete kako napisati klijenta koji se može povezati s vašim poslužiteljem, [na lekciju](02-client/README.md)

- **3 Klijent s LLM-om**, još bolji način pisanja klijenta je dodavanje LLM-a kako bi mogao "pregovarati" s vašim poslužiteljem o tome što treba učiniti, [na lekciju](03-llm-client/README.md)

- **4 Korištenje poslužitelja u GitHub Copilot Agent modu unutar Visual Studio Code-a**. Ovdje ćemo pogledati kako pokrenuti naš MCP poslužitelj unutar Visual Studio Code-a, [na lekciju](04-vscode/README.md)

- **5 Korištenje SSE-a (Server Sent Events)** SSE je standard za streaming od poslužitelja prema klijentu, omogućujući poslužiteljima da šalju ažuriranja u stvarnom vremenu klijentima putem HTTP-a [na lekciju](05-sse-server/README.md)

- **6 HTTP Streaming s MCP-om (Streamable HTTP)**. Naučite o modernom HTTP streamingu, obavijestima o napretku i kako implementirati skalabilne, real-time MCP poslužitelje i klijente koristeći Streamable HTTP. [na lekciju](06-http-streaming/README.md)

- **7 Korištenje AI alata za VSCode** za konzumiranje i testiranje vaših MCP klijenata i poslužitelja [na lekciju](07-aitk/README.md)

- **8 Testiranje**. Ovdje ćemo se posebno fokusirati na različite načine testiranja vašeg poslužitelja i klijenta, [na lekciju](08-testing/README.md)

- **9 Implementacija**. Ovo poglavlje će istražiti različite načine implementacije vaših MCP rješenja, [na lekciju](09-deployment/README.md)

Model Context Protocol (MCP) je otvoreni protokol koji standardizira način na koji aplikacije pružaju kontekst LLM-ovima. Zamislite MCP kao USB-C priključak za AI aplikacije - pruža standardizirani način povezivanja AI modela s različitim izvorima podataka i alatima.

## Ciljevi učenja

Na kraju ove lekcije, moći ćete:

- Postaviti razvojna okruženja za MCP u C#, Java, Python, TypeScript i JavaScript
- Izgraditi i implementirati osnovne MCP poslužitelje s prilagođenim značajkama (resursi, upiti i alati)
- Stvoriti host aplikacije koje se povezuju s MCP poslužiteljima
- Testirati i otklanjati pogreške MCP implementacija
- Razumjeti uobičajene izazove pri postavljanju i njihova rješenja
- Povezati svoje MCP implementacije s popularnim LLM uslugama

## Postavljanje MCP okruženja

Prije nego što počnete raditi s MCP-om, važno je pripremiti razvojno okruženje i razumjeti osnovni tijek rada. Ovaj odjeljak će vas voditi kroz početne korake postavljanja kako biste osigurali nesmetan početak rada s MCP-om.

### Preduvjeti

Prije nego što zaronite u MCP razvoj, osigurajte da imate:

- **Razvojno okruženje**: Za odabrani jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Uređivač**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji moderni uređivač koda
- **Upravitelji paketa**: NuGet, Maven/Gradle, pip ili npm/yarn
- **API ključeve**: Za bilo koje AI usluge koje planirate koristiti u svojim host aplikacijama

### Službeni SDK-ovi

U nadolazećim poglavljima vidjet ćete rješenja izgrađena koristeći Python, TypeScript, Java i .NET. Ovdje su svi službeno podržani SDK-ovi.

MCP pruža službene SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u suradnji s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u suradnji s Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Službena TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Službena Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Službena Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u suradnji s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Službena Rust implementacija

## Ključne točke

- Postavljanje MCP razvojnog okruženja je jednostavno uz SDK-ove specifične za jezik
- Izgradnja MCP poslužitelja uključuje stvaranje i registraciju alata s jasnim shemama
- MCP klijenti povezuju se s poslužiteljima i modelima kako bi iskoristili proširene mogućnosti
- Testiranje i otklanjanje pogrešaka ključni su za pouzdane MCP implementacije
- Opcije implementacije kreću se od lokalnog razvoja do rješenja temeljenih na oblaku

## Vježbanje

Imamo set primjera koji nadopunjuju vježbe koje ćete vidjeti u svim poglavljima ovog odjeljka. Osim toga, svako poglavlje također ima svoje vježbe i zadatke.

- [Java Kalkulator](./samples/java/calculator/README.md)
- [.Net Kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](./samples/javascript/README.md)
- [TypeScript Kalkulator](./samples/typescript/README.md)
- [Python Kalkulator](../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [Izgradite agente koristeći Model Context Protocol na Azureu](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Udaljeni MCP s Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Što slijedi

Sljedeće: [Stvaranje vašeg prvog MCP poslužitelja](01-first-server/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prijevod [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane stručnjaka. Ne preuzimamo odgovornost za bilo kakve nesporazume ili pogrešne interpretacije proizašle iz korištenja ovog prijevoda.