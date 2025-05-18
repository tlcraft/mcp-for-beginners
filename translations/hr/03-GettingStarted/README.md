<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:16:09+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hr"
}
-->
## Početak rada

Ovaj odjeljak sastoji se od nekoliko lekcija:

- **-1- Vaš prvi server**, u ovoj prvoj lekciji naučit ćete kako stvoriti svoj prvi server i pregledati ga pomoću alata za inspekciju, vrijednog načina za testiranje i otklanjanje pogrešaka na vašem serveru, [do lekcije](/03-GettingStarted/01-first-server/README.md)

- **-2- Klijent**, u ovoj lekciji naučit ćete kako napisati klijenta koji se može povezati s vašim serverom, [do lekcije](/03-GettingStarted/02-client/README.md)

- **-3- Klijent s LLM**, još bolji način pisanja klijenta je dodavanje LLM-a kako bi mogao "pregovarati" s vašim serverom o tome što učiniti, [do lekcije](/03-GettingStarted/03-llm-client/README.md)

- **-4- Korištenje servera u načinu rada GitHub Copilot Agent u Visual Studio Code**. Ovdje ćemo pogledati kako pokrenuti naš MCP Server unutar Visual Studio Code, [do lekcije](/03-GettingStarted/04-vscode/README.md)

- **-5- Korištenje SSE (Server Sent Events)** SSE je standard za streaming od servera do klijenta, omogućujući serverima da šalju ažuriranja u stvarnom vremenu klijentima putem HTTP-a [do lekcije](/03-GettingStarted/05-sse-server/README.md)

- **-6- Korištenje AI Toolkit za VSCode** za korištenje i testiranje vaših MCP Klijenata i Servera [do lekcije](/03-GettingStarted/06-aitk/README.md)

- **-7 Testiranje**. Ovdje ćemo se posebno fokusirati na to kako možemo testirati naš server i klijent na različite načine, [do lekcije](/03-GettingStarted/07-testing/README.md)

- **-8- Implementacija**. Ovaj će poglavlje razmotriti različite načine implementacije vaših MCP rješenja, [do lekcije](/03-GettingStarted/08-deployment/README.md)

Model Context Protocol (MCP) je otvoreni protokol koji standardizira kako aplikacije pružaju kontekst LLM-ovima. Zamislite MCP kao USB-C port za AI aplikacije - pruža standardizirani način povezivanja AI modela s različitim izvorima podataka i alatima.

## Ciljevi učenja

Do kraja ove lekcije, moći ćete:

- Postaviti razvojna okruženja za MCP u C#, Java, Python, TypeScript i JavaScript
- Izgraditi i implementirati osnovne MCP servere s prilagođenim značajkama (resursi, upiti i alati)
- Stvoriti aplikacije domaćina koje se povezuju s MCP serverima
- Testirati i otklanjati pogreške u MCP implementacijama
- Razumjeti uobičajene izazove postavljanja i njihova rješenja
- Povezati vaše MCP implementacije s popularnim LLM uslugama

## Postavljanje vašeg MCP okruženja

Prije nego počnete raditi s MCP-om, važno je pripremiti vaše razvojno okruženje i razumjeti osnovni tijek rada. Ovaj će vas odjeljak voditi kroz početne korake postavljanja kako bi osigurao lagan početak s MCP-om.

### Preduvjeti

Prije nego zaronite u MCP razvoj, osigurajte da imate:

- **Razvojno okruženje**: Za vaš odabrani jezik (C#, Java, Python, TypeScript ili JavaScript)
- **IDE/Urednik**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ili bilo koji moderni urednik koda
- **Upravitelji paketa**: NuGet, Maven/Gradle, pip ili npm/yarn
- **API Ključevi**: Za bilo koje AI usluge koje planirate koristiti u vašim aplikacijama domaćina

### Službeni SDK-ovi

U nadolazećim poglavljima vidjet ćete rješenja izgrađena korištenjem Python, TypeScript, Java i .NET. Ovdje su svi službeno podržani SDK-ovi.

MCP pruža službene SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u suradnji s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u suradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Službena TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Službena Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Službena Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u suradnji s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Službena Rust implementacija

## Ključni zaključci

- Postavljanje MCP razvojnog okruženja je jednostavno s SDK-ovima specifičnim za jezik
- Izgradnja MCP servera uključuje stvaranje i registraciju alata s jasnim shemama
- MCP klijenti povezuju se s serverima i modelima kako bi iskoristili proširene mogućnosti
- Testiranje i otklanjanje pogrešaka su ključni za pouzdane MCP implementacije
- Opcije implementacije kreću se od lokalnog razvoja do rješenja temeljenih na oblaku

## Vježbanje

Imamo set uzoraka koji nadopunjuju vježbe koje ćete vidjeti u svim poglavljima u ovom odjeljku. Osim toga, svako poglavlje također ima svoje vježbe i zadatke

- [Java Kalkulator](./samples/java/calculator/README.md)
- [.Net Kalkulator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](./samples/javascript/README.md)
- [TypeScript Kalkulator](./samples/typescript/README.md)
- [Python Kalkulator](../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [MCP GitHub Repozitorij](https://github.com/microsoft/mcp-for-beginners)

## Što je sljedeće

Sljedeće: [Stvaranje vašeg prvog MCP servera](/03-GettingStarted/01-first-server/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, molimo vas da budete svjesni da automatizirani prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja mogu proizaći iz korištenja ovog prijevoda.