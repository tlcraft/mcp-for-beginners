<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:48:14+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hr"
}
-->
## Getting Started  

Ovaj odjeljak sastoji se od nekoliko lekcija:

- **-1- Your first server**, u ovoj prvoj lekciji naučit ćete kako napraviti svoj prvi server i pregledati ga pomoću alata za inspekciju, vrijednog načina za testiranje i otklanjanje pogrešaka na serveru, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, u ovoj lekciji naučit ćete kako napisati klijenta koji se može povezati s vašim serverom, [to the lesson](/03-GettingStarted/02-client/README.md)

- **-3- Client with LLM**, još bolji način pisanja klijenta je dodavanjem LLM-a kako bi mogao "pregovarati" sa serverom o tome što treba raditi, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **-4- Consuming a server GitHub Copilot Agent mode in Visual Studio Code**. Ovdje ćemo pogledati kako pokrenuti naš MCP Server unutar Visual Studio Code, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **-5- Consuming from a SSE (Server Sent Events)** SSE je standard za streaming s poslužitelja prema klijentu, koji omogućuje poslužiteljima da šalju ažuriranja u stvarnom vremenu klijentima preko HTTP-a [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utilising AI Toolkit for VSCode** za korištenje i testiranje vaših MCP klijenata i servera [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **-7 Testing**. Ovdje ćemo se posebno fokusirati na različite načine testiranja našeg servera i klijenta, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **-8- Deployment**. Ovo poglavlje će obraditi različite načine postavljanja vaših MCP rješenja, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) je otvoreni protokol koji standardizira način na koji aplikacije pružaju kontekst LLM-ovima. Zamislite MCP kao USB-C priključak za AI aplikacije - pruža standardizirani način povezivanja AI modela s različitim izvorima podataka i alatima.

## Learning Objectives

Na kraju ove lekcije moći ćete:

- Postaviti razvojna okruženja za MCP u C#, Java, Python, TypeScript i JavaScript
- Izgraditi i postaviti osnovne MCP servere s prilagođenim značajkama (resursi, promptovi i alati)
- Kreirati host aplikacije koje se povezuju s MCP serverima
- Testirati i otklanjati pogreške u MCP implementacijama
- Razumjeti uobičajene izazove pri postavljanju i njihova rješenja
- Povezati svoje MCP implementacije s popularnim LLM servisima

## Setting Up Your MCP Environment

Prije nego što započnete rad s MCP-om, važno je pripremiti razvojno okruženje i razumjeti osnovni tijek rada. Ovaj odjeljak će vas voditi kroz početne korake postavljanja kako biste osigurali nesmetan početak rada s MCP-om.

### Prerequisites

Prije nego što započnete s razvojem MCP-a, provjerite imate li:

- **Development Environment**: Za odabrani programski jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji suvremeni uređivač koda
- **Package Managers**: NuGet, Maven/Gradle, pip ili npm/yarn
- **API Keys**: Za bilo koje AI servise koje planirate koristiti u svojim host aplikacijama


### Official SDKs

U nadolazećim poglavljima vidjet ćete rješenja izrađena koristeći Python, TypeScript, Java i .NET. Ovdje su svi službeno podržani SDK-ovi.

MCP pruža službene SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u suradnji s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u suradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Službena TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Službena Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Službena Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u suradnji s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Službena Rust implementacija

## Key Takeaways

- Postavljanje MCP razvojnih okruženja je jednostavno uz SDK-ove specifične za svaki jezik
- Izgradnja MCP servera uključuje kreiranje i registraciju alata s jasnim shemama
- MCP klijenti se povezuju sa serverima i modelima kako bi iskoristili proširene mogućnosti
- Testiranje i otklanjanje pogrešaka ključno je za pouzdane MCP implementacije
- Opcije postavljanja kreću se od lokalnog razvoja do rješenja u oblaku

## Practicing

Imamo set primjera koji nadopunjuju vježbe koje ćete vidjeti u svim poglavljima ovog odjeljka. Osim toga, svako poglavlje ima i vlastite vježbe i zadatke

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../../../03-GettingStarted/samples/javascript)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.