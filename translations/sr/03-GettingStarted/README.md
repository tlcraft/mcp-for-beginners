<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T01:14:52+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sr"
}
-->
## Početak  

Ovaj odeljak se sastoji iz nekoliko lekcija:

- **1 Vaš prvi server**, u ovoj prvoj lekciji naučićete kako da napravite svoj prvi server i pregledate ga pomoću alata za inspekciju, što je korisno za testiranje i otklanjanje grešaka na serveru, [na lekciju](/03-GettingStarted/01-first-server/README.md)

- **2 Klijent**, u ovoj lekciji naučićete kako da napišete klijenta koji može da se poveže sa vašim serverom, [na lekciju](/03-GettingStarted/02-client/README.md)

- **3 Klijent sa LLM-om**, još bolji način pisanja klijenta je dodavanjem LLM-a kako bi mogao "da pregovara" sa vašim serverom o tome šta treba da radi, [na lekciju](/03-GettingStarted/03-llm-client/README.md)

- **4 Korišćenje servera u režimu GitHub Copilot agenta u Visual Studio Code-u**. Ovde ćemo pogledati kako da pokrenemo naš MCP Server iz Visual Studio Code-a, [na lekciju](/03-GettingStarted/04-vscode/README.md)

- **5 Korišćenje SSE (Server Sent Events)** SSE je standard za strimovanje sa servera ka klijentu, omogućavajući serverima da šalju ažuriranja u realnom vremenu klijentima preko HTTP-a [na lekciju](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP strimovanje sa MCP-om (Streamable HTTP)**. Naučite o modernom HTTP strimovanju, obaveštenjima o napretku i kako da implementirate skalabilne, real-time MCP servere i klijente koristeći Streamable HTTP. [na lekciju](/03-GettingStarted/06-http-streaming/README.md)

- **7 Korišćenje AI Toolkit-a za VSCode** za konzumiranje i testiranje vaših MCP klijenata i servera [na lekciju](/03-GettingStarted/07-aitk/README.md)

- **8 Testiranje**. Ovde ćemo se posebno fokusirati na različite načine testiranja našeg servera i klijenta, [na lekciju](/03-GettingStarted/08-testing/README.md)

- **9 Deploy**. Ovaj deo će obraditi različite načine postavljanja vaših MCP rešenja u produkciju, [na lekciju](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) je otvoreni protokol koji standardizuje način na koji aplikacije pružaju kontekst LLM-ovima. Zamislite MCP kao USB-C priključak za AI aplikacije – on pruža standardizovani način povezivanja AI modela sa različitim izvorima podataka i alatima.

## Ciljevi učenja

Do kraja ove lekcije bićete u stanju da:

- Postavite razvojna okruženja za MCP u C#, Java, Python, TypeScript i JavaScript
- Kreirate i postavite osnovne MCP servere sa prilagođenim funkcijama (resursi, upiti i alati)
- Napravite host aplikacije koje se povezuju na MCP servere
- Testirate i otklanjate greške u MCP implementacijama
- Razumete uobičajene izazove u postavljanju i njihova rešenja
- Povežete svoje MCP implementacije sa popularnim LLM servisima

## Podešavanje MCP okruženja

Pre nego što počnete da radite sa MCP-om, važno je da pripremite razvojno okruženje i razumete osnovni tok rada. Ovaj deo će vas voditi kroz početne korake kako biste osigurali nesmetan početak sa MCP-om.

### Preduslovi

Pre nego što započnete razvoj sa MCP-om, proverite da imate:

- **Razvojno okruženje**: Za izabrani programski jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji moderan uređivač koda
- **Package menadžeri**: NuGet, Maven/Gradle, pip ili npm/yarn
- **API ključeve**: Za bilo koje AI servise koje planirate da koristite u svojim host aplikacijama


### Zvanični SDK-ovi

U narednim poglavljima videćete rešenja napravljena koristeći Python, TypeScript, Java i .NET. Evo svih zvanično podržanih SDK-ova.

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
- MCP klijenti se povezuju na servere i modele da bi iskoristili dodatne mogućnosti
- Testiranje i otklanjanje grešaka su ključni za pouzdane MCP implementacije
- Opcije za postavljanje se kreću od lokalnog razvoja do rešenja baziranih na oblaku

## Vežbanje

Imamo set primera koji dopunjuju vežbe koje ćete videti u svim poglavljima ovog odeljka. Pored toga, svako poglavlje ima svoje vežbe i zadatke

- [Java Kalkulator](./samples/java/calculator/README.md)
- [.Net Kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](./samples/javascript/README.md)
- [TypeScript Kalkulator](./samples/typescript/README.md)
- [Python Kalkulator](../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Šta sledi

Sledeće: [Kreiranje vašeg prvog MCP servera](/03-GettingStarted/01-first-server/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем АИ сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења настала коришћењем овог превода.