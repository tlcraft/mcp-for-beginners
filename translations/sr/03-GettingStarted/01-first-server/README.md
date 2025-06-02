<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:43:10+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sr"
}
-->
### -2- Kreirajte projekat

Sada kada ste instalirali SDK, hajde da kreiramo projekat:

### -3- Kreirajte fajlove projekta

### -4- Napišite kod servera

### -5- Dodavanje alata i resursa

Dodajte alat i resurs dodavanjem sledećeg koda:

### -6- Završni kod

Dodajmo poslednji deo koda koji je potreban da bi server mogao da se pokrene:

### -7- Testirajte server

Pokrenite server sledećom komandom:

### -8- Pokretanje pomoću inspektora

Inspektor je odličan alat koji može da pokrene vaš server i omogući vam da komunicirate sa njim kako biste testirali da li radi. Hajde da ga pokrenemo:

> [!NOTE]
> u polju "command" može izgledati drugačije jer sadrži komandu za pokretanje servera sa vašim specifičnim runtime-om/

Treba da vidite sledeći korisnički interfejs:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sr.png)

1. Povežite se na server klikom na dugme Connect  
   Kada se povežete na server, trebalo bi da vidite sledeće:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.sr.png)

2. Izaberite "Tools" i "listTools", trebalo bi da se pojavi opcija "Add", kliknite na "Add" i unesite vrednosti parametara.

   Trebalo bi da dobijete sledeći odgovor, odnosno rezultat iz alata "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.sr.png)

Čestitamo, uspeli ste da kreirate i pokrenete svoj prvi server!

### Zvanični SDK-ovi

MCP nudi zvanične SDK-ove za više programskih jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u saradnji sa Microsoftom
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u saradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Zvanična TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Zvanična Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Zvanična Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u saradnji sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Zvanična Rust implementacija

## Ključne tačke

- Postavljanje MCP razvojne okoline je jednostavno uz SDK-ove za određene jezike
- Izgradnja MCP servera podrazumeva kreiranje i registraciju alata sa jasnim šemama
- Testiranje i otklanjanje grešaka su ključni za pouzdane MCP implementacije

## Primeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Zadatak

Napravite jednostavan MCP server sa alatom po vašem izboru:
1. Implementirajte alat u željenom jeziku (.NET, Java, Python ili JavaScript).
2. Definišite ulazne parametre i povratne vrednosti.
3. Pokrenite inspektor alat da biste proverili da li server radi kako treba.
4. Testirajte implementaciju sa različitim ulazima.

## Rešenje

[Rešenje](./solution/README.md)

## Dodatni resursi

- [MCP GitHub repozitorijum](https://github.com/microsoft/mcp-for-beginners)

## Šta sledi

Dalje: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен помоћу AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да имате у виду да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било какве неспоразуме или погрешне тумачења настала употребом овог превода.