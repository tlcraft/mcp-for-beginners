<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T17:09:50+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hr"
}
-->
### -2- Kreirajte projekt

Sad kad ste instalirali SDK, sljedeći korak je kreiranje projekta:

### -3- Kreirajte datoteke projekta

### -4- Napišite kod servera

### -5- Dodavanje alata i resursa

Dodajte alat i resurs dodavanjem sljedećeg koda:

### -6 Završni kod

Dodajmo posljednji dio koda koji je potreban da server može pokrenuti:

### -7- Testirajte server

Pokrenite server sljedećom naredbom:

### -8- Pokretanje pomoću inspektora

Inspektor je izvrstan alat koji može pokrenuti vaš server i omogućiti vam interakciju s njim kako biste testirali njegov rad. Pokrenimo ga:

> [!NOTE]
> može izgledati drugačije u polju "command" jer sadrži naredbu za pokretanje servera s vašim specifičnim runtime-om/

Trebali biste vidjeti sljedeće korisničko sučelje:

![Poveži](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hr.png)

1. Povežite se na server klikom na gumb Connect  
   Nakon povezivanja sa serverom, trebali biste vidjeti sljedeće:

   ![Povezano](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hr.png)

2. Odaberite "Tools" i "listTools", trebali biste vidjeti opciju "Add", odaberite "Add" i unesite vrijednosti parametara.

   Trebali biste vidjeti sljedeći odgovor, tj. rezultat alata "add":

   ![Rezultat izvršavanja add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hr.png)

Čestitamo, uspjeli ste kreirati i pokrenuti svoj prvi server!

### Službeni SDK-ovi

MCP nudi službene SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u suradnji s Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u suradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Službena TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Službena Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Službena Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u suradnji s Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Službena Rust implementacija

## Ključne točke

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
3. Pokrenite alat inspektora kako biste osigurali da server radi kako treba.  
4. Testirajte implementaciju s različitim unosima.

## Rješenje

[Rješenje](./solution/README.md)

## Dodatni resursi

- [MCP GitHub repozitorij](https://github.com/microsoft/mcp-for-beginners)

## Što slijedi

Sljedeće: [Uvod u MCP klijente](/03-GettingStarted/02-client/README.md)

**Odricanje od odgovornosti**:  
Ovaj je dokument preveden pomoću AI usluge za prijevod [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Nismo odgovorni za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.