<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:17:31+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sr"
}
-->
## Početak  

Ovaj deo se sastoji iz nekoliko lekcija:

- **1 Tvoj prvi server**, u ovoj prvoj lekciji naučićeš kako da kreiraš svoj prvi server i kako da ga pregledaš pomoću inspektora, korisnog alata za testiranje i otklanjanje grešaka na serveru, [na lekciju](/03-GettingStarted/01-first-server/README.md)

- **2 Klijent**, u ovoj lekciji naučićeš kako da napišeš klijenta koji može da se poveže sa tvojim serverom, [na lekciju](/03-GettingStarted/02-client/README.md)

- **3 Klijent sa LLM-om**, još bolji način pisanja klijenta je dodavanjem LLM-a kako bi mogao da "pregovara" sa tvojim serverom o tome šta treba da radi, [na lekciju](/03-GettingStarted/03-llm-client/README.md)

- **4 Korišćenje servera u režimu GitHub Copilot Agent u Visual Studio Code-u**. Ovde ćemo pogledati kako da pokrenemo naš MCP Server iz Visual Studio Code-a, [na lekciju](/03-GettingStarted/04-vscode/README.md)

- **5 Korišćenje SSE (Server Sent Events)** SSE je standard za strimovanje sa servera ka klijentu, omogućavajući serverima da šalju ažuriranja u realnom vremenu klijentima preko HTTP-a [na lekciju](/03-GettingStarted/05-sse-server/README.md)

- **6 Korišćenje AI Toolkit-a za VSCode** za korišćenje i testiranje tvojih MCP Klijenata i Servera [na lekciju](/03-GettingStarted/06-aitk/README.md)

- **7 Testiranje**. Ovde ćemo se posebno fokusirati na različite načine testiranja našeg servera i klijenta, [na lekciju](/03-GettingStarted/07-testing/README.md)

- **8 Deploy**. Ovo poglavlje će obraditi različite načine postavljanja tvojih MCP rešenja, [na lekciju](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) je otvoreni protokol koji standardizuje način na koji aplikacije obezbeđuju kontekst za LLM-ove. Zamislite MCP kao USB-C port za AI aplikacije - pruža standardizovan način povezivanja AI modela sa različitim izvorima podataka i alatima.

## Ciljevi učenja

Na kraju ove lekcije bićeš u stanju da:

- Postaviš razvojna okruženja za MCP u C#, Java, Python, TypeScript i JavaScript
- Kreiraš i postaviš osnovne MCP servere sa prilagođenim funkcijama (resursi, promptovi i alati)
- Napraviš host aplikacije koje se povezuju na MCP servere
- Testiraš i otklanjaš greške u MCP implementacijama
- Razumeš uobičajene probleme pri postavljanju i njihova rešenja
- Povežeš svoje MCP implementacije sa popularnim LLM servisima

## Postavljanje MCP okruženja

Pre nego što počneš da radiš sa MCP, važno je da pripremiš razvojno okruženje i razumeš osnovni tok rada. Ovaj deo će te voditi kroz početne korake postavljanja kako bi tvoj rad sa MCP-om tekao glatko.

### Preduslovi

Pre nego što se upustiš u razvoj sa MCP-om, proveri da li imaš:

- **Razvojno okruženje**: Za izabrani programski jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji moderan editor koda
- **Package menadžere**: NuGet, Maven/Gradle, pip ili npm/yarn
- **API ključeve**: Za bilo koje AI servise koje planiraš da koristiš u svojim host aplikacijama


### Zvanični SDK-ovi

U narednim poglavljima videćeš rešenja izrađena u Pythonu, TypeScript-u, Javi i .NET-u. Ovde su svi zvanično podržani SDK-ovi.

MCP pruža zvanične SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u saradnji sa Microsoft-om
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u saradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Zvanična TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Zvanična Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Zvanična Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u saradnji sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Zvanična Rust implementacija

## Ključni zaključci

- Postavljanje MCP razvojnog okruženja je jednostavno uz SDK-ove specifične za jezik
- Izgradnja MCP servera podrazumeva kreiranje i registraciju alata sa jasnim šemama
- MCP klijenti se povezuju sa serverima i modelima kako bi iskoristili dodatne mogućnosti
- Testiranje i otklanjanje grešaka su ključni za pouzdane MCP implementacije
- Opcije za postavljanje se kreću od lokalnog razvoja do rešenja zasnovanih na oblaku

## Vežbanje

Imamo set primera koji dopunjuju vežbe koje ćeš videti u svim poglavljima ovog dela. Pored toga, svako poglavlje ima svoje vežbe i zadatke.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Šta sledi

Sledeće: [Kreiranje tvog prvog MCP Servera](/03-GettingStarted/01-first-server/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI prevodilačke usluge [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Nismo odgovorni za bilo kakva nesporazumevanja ili pogrešna tumačenja nastala korišćenjem ovog prevoda.