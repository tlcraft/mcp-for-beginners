<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T01:19:22+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hr"
}
-->
## Početak  

Ovaj odjeljak sastoji se od nekoliko lekcija:

- **1 Vaš prvi server**, u ovoj prvoj lekciji naučit ćete kako napraviti svoj prvi server i pregledati ga pomoću alata za inspekciju, korisnog za testiranje i otklanjanje grešaka na serveru, [na lekciju](/03-GettingStarted/01-first-server/README.md)

- **2 Klijent**, u ovoj lekciji naučit ćete kako napisati klijenta koji se može povezati s vašim serverom, [na lekciju](/03-GettingStarted/02-client/README.md)

- **3 Klijent s LLM-om**, još bolji način pisanja klijenta je dodavanjem LLM-a kako bi mogao "pregovarati" sa serverom o tome što treba raditi, [na lekciju](/03-GettingStarted/03-llm-client/README.md)

- **4 Korištenje servera u GitHub Copilot Agent modu u Visual Studio Codeu**. Ovdje gledamo kako pokrenuti naš MCP Server iz Visual Studio Codea, [na lekciju](/03-GettingStarted/04-vscode/README.md)

- **5 Korištenje SSE (Server Sent Events)** SSE je standard za streaming sa servera prema klijentu, omogućujući serverima da šalju ažuriranja u stvarnom vremenu preko HTTP-a [na lekciju](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP streaming s MCP-om (Streamable HTTP)**. Naučite o modernom HTTP streamingu, obavijestima o napretku i kako implementirati skalabilne MCP servere i klijente u stvarnom vremenu koristeći Streamable HTTP. [na lekciju](/03-GettingStarted/06-http-streaming/README.md)

- **7 Korištenje AI Toolkit-a za VSCode** za korištenje i testiranje vaših MCP klijenata i servera [na lekciju](/03-GettingStarted/07-aitk/README.md)

- **8 Testiranje**. Ovdje ćemo se posebno fokusirati na različite načine testiranja servera i klijenta, [na lekciju](/03-GettingStarted/08-testing/README.md)

- **9 Deployanje**. Ovo poglavlje će obraditi različite načine postavljanja vaših MCP rješenja, [na lekciju](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) je otvoreni protokol koji standardizira način na koji aplikacije pružaju kontekst LLM-ovima. Zamislite MCP kao USB-C priključak za AI aplikacije – pruža standardizirani način povezivanja AI modela s različitim izvorima podataka i alatima.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Postaviti razvojna okruženja za MCP u C#, Javi, Pythonu, TypeScriptu i JavaScriptu
- Izgraditi i deployati osnovne MCP servere s prilagođenim značajkama (resursi, promptovi i alati)
- Kreirati host aplikacije koje se povezuju s MCP serverima
- Testirati i otklanjati greške u MCP implementacijama
- Razumjeti uobičajene izazove postavljanja i njihova rješenja
- Povezati svoje MCP implementacije s popularnim LLM servisima

## Postavljanje MCP okruženja

Prije nego što započnete rad s MCP-om, važno je pripremiti razvojno okruženje i razumjeti osnovni tijek rada. Ovaj odjeljak će vas voditi kroz početne korake postavljanja kako bi vaš početak s MCP-om bio što jednostavniji.

### Preduvjeti

Prije nego što se upustite u razvoj MCP-a, provjerite imate li:

- **Razvojno okruženje**: Za odabrani programski jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji suvremeni uređivač koda
- **Package Manageri**: NuGet, Maven/Gradle, pip ili npm/yarn
- **API ključeve**: Za bilo koje AI servise koje planirate koristiti u svojim host aplikacijama


### Službeni SDK-ovi

U nadolazećim poglavljima vidjet ćete rješenja izrađena u Pythonu, TypeScriptu, Javi i .NET-u. Ovo su svi službeno podržani SDK-ovi.

MCP nudi službene SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u suradnji s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u suradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Službena TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Službena Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Službena Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u suradnji s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Službena Rust implementacija

## Ključne točke

- Postavljanje MCP razvojnog okruženja je jednostavno uz SDK-ove specifične za jezik
- Izgradnja MCP servera uključuje kreiranje i registraciju alata s jasnim shemama
- MCP klijenti se povezuju sa serverima i modelima kako bi iskoristili proširene mogućnosti
- Testiranje i otklanjanje grešaka su ključni za pouzdane MCP implementacije
- Opcije deployanja kreću se od lokalnog razvoja do rješenja u oblaku

## Vježbanje

Imamo skup primjera koji nadopunjuju vježbe koje ćete vidjeti u svim poglavljima ovog odjeljka. Također, svako poglavlje ima svoje vježbe i zadatke

- [Java Kalkulator](./samples/java/calculator/README.md)
- [.Net Kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](./samples/javascript/README.md)
- [TypeScript Kalkulator](./samples/typescript/README.md)
- [Python Kalkulator](../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Što slijedi

Sljedeće: [Kreiranje vašeg prvog MCP Servera](/03-GettingStarted/01-first-server/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.