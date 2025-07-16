<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:53:08+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hr"
}
-->
### -2- Kreirajte projekt

Sada kada imate instaliran SDK, sljedeći korak je kreirati projekt:

### -3- Kreirajte datoteke projekta

### -4- Napišite kod servera

### -5- Dodavanje alata i resursa

Dodajte alat i resurs dodavanjem sljedećeg koda:

### -6 Završni kod

Dodajmo posljednji kod koji je potreban da server može pokrenuti:

### -7- Testirajte server

Pokrenite server sljedećom naredbom:

### -8- Pokrenite pomoću inspektora

Inspektor je izvrstan alat koji može pokrenuti vaš server i omogućiti vam interakciju s njim kako biste testirali njegov rad. Pokrenimo ga:
> [!NOTE]
> u polju "command" može izgledati drugačije jer sadrži naredbu za pokretanje servera s vašim specifičnim runtime-om/
Trebali biste vidjeti sljedeće korisničko sučelje:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Povežite se sa serverom odabirom gumba Connect  
   Nakon što se povežete sa serverom, trebali biste vidjeti sljedeće:

   ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Odaberite "Tools" i "listTools", trebali biste vidjeti da se pojavljuje "Add", odaberite "Add" i ispunite vrijednosti parametara.

   Trebali biste vidjeti sljedeći odgovor, tj. rezultat iz "add" alata:

   ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Čestitamo, uspjeli ste kreirati i pokrenuti svoj prvi server!

### Službeni SDK-ovi

MCP pruža službene SDK-ove za više programskih jezika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u suradnji s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u suradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Službena TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Službena Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Službena Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u suradnji s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Službena Rust implementacija

## Ključne napomene

- Postavljanje MCP razvojne okoline je jednostavno uz SDK-ove specifične za jezik
- Izgradnja MCP servera uključuje kreiranje i registraciju alata s jasnim shemama
- Testiranje i otklanjanje pogrešaka su ključni za pouzdane MCP implementacije

## Primjeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zadatak

Kreirajte jednostavan MCP server s alatom po vašem izboru:

1. Implementirajte alat u željenom jeziku (.NET, Java, Python ili JavaScript).
2. Definirajte ulazne parametre i povratne vrijednosti.
3. Pokrenite alat za inspekciju kako biste provjerili radi li server kako treba.
4. Testirajte implementaciju s različitim ulazima.

## Rješenje

[Rješenje](./solution/README.md)

## Dodatni resursi

- [Izgradnja agenata koristeći Model Context Protocol na Azureu](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP s Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Što slijedi

Sljedeće: [Uvod u MCP klijente](../02-client/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.