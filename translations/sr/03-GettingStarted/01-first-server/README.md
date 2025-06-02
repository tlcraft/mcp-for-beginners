<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T17:09:20+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sr"
}
-->
### -2- Kreirajte projekat

Sada kada ste instalirali SDK, hajde da kreiramo projekat:

### -3- Kreirajte fajlove projekta

### -4- Kreirajte kod servera

### -5- Dodavanje alata i resursa

Dodajte alat i resurs tako što ćete dodati sledeći kod:

### -6- Završni kod

Dodajmo poslednji kod koji nam je potreban da server može da se pokrene:

### -7- Testirajte server

Pokrenite server sledećom komandom:

### -8- Pokretanje pomoću inspektora

Inspektor je sjajan alat koji može da pokrene vaš server i omogućava vam da sa njim interagujete kako biste testirali da li radi. Hajde da ga pokrenemo:

> [!NOTE]
> može izgledati drugačije u polju "command" jer sadrži komandu za pokretanje servera sa vašim specifičnim runtime-om/

Treba da vidite sledeći korisnički interfejs:

![Poveži](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sr.png)

1. Povežite se sa serverom klikom na dugme Connect  
   Kada se povežete sa serverom, trebalo bi da vidite sledeće:

   ![Povezano](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.sr.png)

2. Izaberite "Tools" i "listTools", trebalo bi da se pojavi opcija "Add", kliknite na "Add" i unesite vrednosti parametara.

   Trebalo bi da vidite sledeći odgovor, tj. rezultat sa alata "add":

   ![Rezultat izvršavanja add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.sr.png)

Čestitamo, uspešno ste kreirali i pokrenuli svoj prvi server!

### Zvanični SDK-ovi

MCP pruža zvanične SDK-ove za više jezika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Održava se u saradnji sa Microsoft-om
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Održava se u saradnji sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Zvanična TypeScript implementacija
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Zvanična Python implementacija
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Zvanična Kotlin implementacija
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Održava se u saradnji sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Zvanična Rust implementacija

## Ključni zaključci

- Postavljanje MCP razvojne sredine je jednostavno uz SDK-ove specifične za jezik
- Izgradnja MCP servera podrazumeva kreiranje i registraciju alata sa jasno definisanim šemama
- Testiranje i otklanjanje grešaka su ključni za pouzdane MCP implementacije

## Primeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Zadatak

Kreirajte jednostavan MCP server sa alatom po vašem izboru:
1. Implementirajte alat u jeziku koji preferirate (.NET, Java, Python ili JavaScript).
2. Definišite ulazne parametre i vrednosti povratka.
3. Pokrenite inspektor alat da proverite da li server radi kako treba.
4. Testirajte implementaciju sa različitim ulazima.

## Rešenje

[Rešenje](./solution/README.md)

## Dodatni resursi

- [MCP GitHub Repozitorijum](https://github.com/microsoft/mcp-for-beginners)

## Šta sledi

Dalje: [Uvod u MCP klijente](/03-GettingStarted/02-client/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен помоћу AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални превод од стране људског стручњака. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.