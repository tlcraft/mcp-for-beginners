<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-13T17:20:51+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hr"
}
-->
## Početak  

Ovaj odjeljak sastoji se od nekoliko lekcija:

- **1 Vaš prvi server**, u ovoj prvoj lekciji naučit ćete kako napraviti svoj prvi server i pregledati ga pomoću alata za inspekciju, što je koristan način za testiranje i otklanjanje pogrešaka na serveru, [na lekciju](01-first-server/README.md)

- **2 Klijent**, u ovoj lekciji naučit ćete kako napisati klijenta koji se može povezati s vašim serverom, [na lekciju](02-client/README.md)

- **3 Klijent s LLM-om**, još bolji način pisanja klijenta je dodavanjem LLM-a kako bi mogao "pregovarati" sa serverom o tome što treba raditi, [na lekciju](03-llm-client/README.md)

- **4 Korištenje servera u GitHub Copilot Agent modu u Visual Studio Code-u**. Ovdje gledamo kako pokrenuti naš MCP Server iz Visual Studio Code-a, [na lekciju](04-vscode/README.md)

- **5 Korištenje SSE (Server Sent Events)** SSE je standard za streaming s poslužitelja na klijenta, koji omogućuje serverima da šalju ažuriranja u stvarnom vremenu klijentima preko HTTP-a [na lekciju](05-sse-server/README.md)

- **6 HTTP streaming s MCP-om (Streamable HTTP)**. Naučite o modernom HTTP streamingu, obavijestima o napretku i kako implementirati skalabilne, real-time MCP servere i klijente koristeći Streamable HTTP. [na lekciju](06-http-streaming/README.md)

- **7 Korištenje AI Toolkit-a za VSCode** za korištenje i testiranje vaših MCP klijenata i servera [na lekciju](07-aitk/README.md)

- **8 Testiranje**. Ovdje ćemo se posebno fokusirati na različite načine testiranja vašeg poslužitelja i klijenta, [na lekciju](08-testing/README.md)

- **9 Deployanje**. Ovaj će poglavlje obraditi različite načine deployanja vaših MCP rješenja, [na lekciju](09-deployment/README.md)

Model Context Protocol (MCP) je otvoreni protokol koji standardizira način na koji aplikacije pružaju kontekst LLM-ovima. Zamislite MCP kao USB-C priključak za AI aplikacije - pruža standardizirani način povezivanja AI modela s različitim izvorima podataka i alatima.

## Ciljevi učenja

Na kraju ove lekcije, moći ćete:

- Postaviti razvojna okruženja za MCP u C#, Javi, Pythonu, TypeScriptu i JavaScriptu
- Izgraditi i deployati osnovne MCP servere s prilagođenim značajkama (resursi, promptovi i alati)
- Kreirati host aplikacije koje se povezuju na MCP servere
- Testirati i otklanjati pogreške u MCP implementacijama
- Razumjeti uobičajene izazove pri postavljanju i njihova rješenja
- Povezati svoje MCP implementacije s popularnim LLM uslugama

## Postavljanje MCP okruženja

Prije nego što počnete raditi s MCP-om, važno je pripremiti razvojno okruženje i razumjeti osnovni tijek rada. Ovaj odjeljak će vas voditi kroz početne korake postavljanja kako biste osigurali nesmetan početak rada s MCP-om.

### Preduvjeti

Prije nego što se upustite u razvoj s MCP-om, provjerite imate li:

- **Razvojno okruženje**: za odabrani programski jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji moderni uređivač koda
- **Package manageri**: NuGet, Maven/Gradle, pip ili npm/yarn
- **API ključevi**: za bilo koje AI servise koje planirate koristiti u svojim host aplikacijama


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

Imamo skup primjera koji nadopunjuju vježbe koje ćete vidjeti u svim poglavljima ovog odjeljka. Osim toga, svako poglavlje ima i svoje vježbe i zadatke.

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
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.