<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:47:25+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sr"
}
-->
## Početak rada  

Ovaj odeljak se sastoji iz nekoliko lekcija:

- **-1- Vaš prvi server**, u ovoj prvoj lekciji naučićete kako da napravite svoj prvi server i pregledate ga pomoću inspektora, korisnog alata za testiranje i otklanjanje grešaka na serveru, [ka lekciji](/03-GettingStarted/01-first-server/README.md)

- **-2- Klijent**, u ovoj lekciji naučićete kako da napišete klijenta koji može da se poveže sa vašim serverom, [ka lekciji](/03-GettingStarted/02-client/README.md)

- **-3- Klijent sa LLM-om**, još bolji način pisanja klijenta je dodavanjem LLM-a kako bi mogao da "pregovara" sa vašim serverom o tome šta treba da radi, [ka lekciji](/03-GettingStarted/03-llm-client/README.md)

- **-4- Korišćenje režima GitHub Copilot agenta servera u Visual Studio Code-u**. Ovde ćemo videti kako pokrenuti naš MCP Server iz samog Visual Studio Code-a, [ka lekciji](/03-GettingStarted/04-vscode/README.md)

- **-5- Korišćenje SSE (Server Sent Events)** SSE je standard za streaming sa servera ka klijentu, koji omogućava serverima da šalju ažuriranja u realnom vremenu klijentima preko HTTP-a [ka lekciji](/03-GettingStarted/05-sse-server/README.md)

- **-6- Korišćenje AI Toolkit za VSCode** za konzumiranje i testiranje vaših MCP klijenata i servera [ka lekciji](/03-GettingStarted/06-aitk/README.md)

- **-7 Testiranje**. Ovde ćemo se posebno fokusirati na različite načine testiranja našeg servera i klijenta, [ka lekciji](/03-GettingStarted/07-testing/README.md)

- **-8- Deploy**. Ovo poglavlje će pokriti različite načine deploy-ovanja vaših MCP rešenja, [ka lekciji](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) je otvoreni protokol koji standardizuje način na koji aplikacije pružaju kontekst LLM-ovima. Zamislite MCP kao USB-C priključak za AI aplikacije - omogućava standardizovani način povezivanja AI modela sa različitim izvorima podataka i alatima.

## Ciljevi učenja

Na kraju ove lekcije bićete u stanju da:

- Postavite razvojno okruženje za MCP u C#, Java, Python, TypeScript i JavaScript
- Kreirate i deploy-ujete osnovne MCP servere sa prilagođenim funkcijama (resursi, promptovi i alati)
- Napravite host aplikacije koje se povezuju sa MCP serverima
- Testirate i otklanjate greške u MCP implementacijama
- Razumete uobičajene probleme pri postavljanju i njihova rešenja
- Povežete svoje MCP implementacije sa popularnim LLM servisima

## Postavljanje MCP okruženja

Pre nego što počnete da radite sa MCP-om, važno je da pripremite razvojno okruženje i razumete osnovni tok rada. Ovaj deo će vas voditi kroz početne korake kako biste osigurali nesmetan početak rada sa MCP-om.

### Preduslovi

Pre nego što započnete razvoj sa MCP-om, proverite da imate:

- **Razvojno okruženje**: za izabrani programski jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji moderan editor koda
- **Package menadžere**: NuGet, Maven/Gradle, pip ili npm/yarn
- **API ključeve**: za bilo koje AI servise koje planirate da koristite u host aplikacijama


### Zvanični SDK-ovi

U narednim poglavljima videćete rešenja izrađena u Pythonu, TypeScript-u, Javi i .NET-u. Ovo su svi zvanično podržani SDK-ovi.

MCP nudi zvanične SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u saradnji sa Microsoft-om
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u saradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Zvanična TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Zvanična Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Zvanična Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u saradnji sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Zvanična Rust implementacija

## Ključni zaključci

- Postavljanje MCP razvojnog okruženja je jednostavno uz SDK-ove specifične za jezik
- Kreiranje MCP servera podrazumeva pravljenje i registraciju alata sa jasnim šemama
- MCP klijenti se povezuju sa serverima i modelima kako bi iskoristili proširene mogućnosti
- Testiranje i otklanjanje grešaka su ključni za pouzdane MCP implementacije
- Opcije deploy-ovanja se kreću od lokalnog razvoja do rešenja zasnovanih na oblaku

## Vežbanje

Imamo set primera koji dopunjuju vežbe koje ćete videti u svim poglavljima ovog odeljka. Pored toga, svako poglavlje ima i svoje vežbe i zadatke

- [Java Kalkulator](./samples/java/calculator/README.md)
- [.Net Kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](./samples/javascript/README.md)
- [TypeScript Kalkulator](./samples/typescript/README.md)
- [Python Kalkulator](../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [Pravljenje agenata korišćenjem Model Context Protocol-a na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP sa Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Šta sledi

Sledeće: [Kreiranje vašeg prvog MCP servera](/03-GettingStarted/01-first-server/README.md)

**Ограничење одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетом. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне интерпретације настале коришћењем овог превода.