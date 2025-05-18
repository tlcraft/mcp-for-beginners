<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:15:52+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sr"
}
-->
## Početak

Ovaj odeljak se sastoji od nekoliko lekcija:

- **-1- Vaš prvi server**, u ovoj prvoj lekciji naučićete kako da kreirate svoj prvi server i pregledate ga pomoću alata za inspekciju, vredan način za testiranje i otklanjanje grešaka na vašem serveru, [do lekcije](/03-GettingStarted/01-first-server/README.md)

- **-2- Klijent**, u ovoj lekciji naučićete kako da napišete klijenta koji može da se poveže sa vašim serverom, [do lekcije](/03-GettingStarted/02-client/README.md)

- **-3- Klijent sa LLM**, još bolji način pisanja klijenta je dodavanje LLM-a kako bi mogao da "pregovara" sa vašim serverom o tome šta da radi, [do lekcije](/03-GettingStarted/03-llm-client/README.md)

- **-4- Konzumiranje servera GitHub Copilot Agent moda u Visual Studio Code-u**. Ovde ćemo razmotriti pokretanje našeg MCP Servera iz Visual Studio Code-a, [do lekcije](/03-GettingStarted/04-vscode/README.md)

- **-5- Konzumiranje sa SSE (Server Sent Events)** SSE je standard za streaming od servera ka klijentu, omogućavajući serverima da šalju ažuriranja u realnom vremenu klijentima preko HTTP-a [do lekcije](/03-GettingStarted/05-sse-server/README.md)

- **-6- Korišćenje AI Toolkit-a za VSCode** za konzumiranje i testiranje vaših MCP klijenata i servera [do lekcije](/03-GettingStarted/06-aitk/README.md)

- **-7 Testiranje**. Ovde ćemo se posebno fokusirati na to kako možemo testirati naš server i klijent na različite načine, [do lekcije](/03-GettingStarted/07-testing/README.md)

- **-8- Implementacija**. Ovaj poglavlje će razmotriti različite načine implementacije vaših MCP rešenja, [do lekcije](/03-GettingStarted/08-deployment/README.md)

Model Context Protocol (MCP) je otvoreni protokol koji standardizuje kako aplikacije pružaju kontekst LLM-ovima. Zamislite MCP kao USB-C port za AI aplikacije - pruža standardizovan način povezivanja AI modela sa različitim izvorima podataka i alatima.

## Ciljevi učenja

Na kraju ove lekcije, bićete sposobni da:

- Postavite razvojna okruženja za MCP u C#, Java, Python, TypeScript i JavaScript
- Izgradite i implementirate osnovne MCP servere sa prilagođenim funkcijama (resursima, upitima i alatima)
- Kreirate host aplikacije koje se povezuju sa MCP serverima
- Testirate i otklanjate greške MCP implementacija
- Razumete uobičajene izazove postavljanja i njihova rešenja
- Povežete vaše MCP implementacije sa popularnim LLM servisima

## Postavljanje MCP okruženja

Pre nego što počnete rad sa MCP-om, važno je da pripremite svoje razvojno okruženje i razumete osnovni tok rada. Ovaj odeljak će vas voditi kroz početne korake postavljanja kako biste osigurali gladak početak sa MCP-om.

### Preduslovi

Pre nego što se upustite u MCP razvoj, osigurajte da imate:

- **Razvojno okruženje**: Za vaš izabrani jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji moderni editor koda
- **Upravljači paketima**: NuGet, Maven/Gradle, pip, ili npm/yarn
- **API ključevi**: Za bilo koje AI usluge koje planirate da koristite u vašim host aplikacijama

### Zvanični SDK-ovi

U narednim poglavljima videćete rešenja izgrađena koristeći Python, TypeScript, Java i .NET. Ovde su svi zvanično podržani SDK-ovi.

MCP pruža zvanične SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u saradnji sa Microsoft-om
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u saradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Zvanična TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Zvanična Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Zvanična Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u saradnji sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Zvanična Rust implementacija

## Ključne stavke

- Postavljanje MCP razvojnog okruženja je jednostavno uz SDK-ove specifične za jezik
- Izgradnja MCP servera uključuje kreiranje i registraciju alata sa jasnim šemama
- MCP klijenti se povezuju sa serverima i modelima da iskoriste proširene mogućnosti
- Testiranje i otklanjanje grešaka su ključni za pouzdane MCP implementacije
- Opcije implementacije se kreću od lokalnog razvoja do rešenja zasnovanih na oblaku

## Vežbanje

Imamo set primera koji dopunjuju vežbe koje ćete videti u svim poglavljima ovog odeljka. Pored toga, svako poglavlje ima svoje vežbe i zadatke

- [Java Kalkulator](./samples/java/calculator/README.md)
- [.Net Kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](./samples/javascript/README.md)
- [TypeScript Kalkulator](./samples/typescript/README.md)
- [Python Kalkulator](../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [MCP GitHub Repozitorijum](https://github.com/microsoft/mcp-for-beginners)

## Šta je sledeće

Sledeće: [Kreiranje vašeg prvog MCP Servera](/03-GettingStarted/01-first-server/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да будете свесни да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитативним извором. За критичне информације, препоручује се професионални превод од стране људи. Не сносимо одговорност за било каква погрешна схватања или погрешна тумачења која произилазе из употребе овог превода.