<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:16:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ro"
}
-->
### -2- Crearea proiectului

Acum că ai instalat SDK-ul, să trecem la crearea unui proiect:

### -3- Crearea fișierelor proiectului

### -4- Crearea codului serverului

### -5- Adăugarea unui tool și a unei resurse

Adaugă un tool și o resursă prin includerea următorului cod:

### -6 Codul final

Să adăugăm codul final necesar pentru a porni serverul:

### -7- Testarea serverului

Pornește serverul cu următoarea comandă:

### -8- Rularea cu inspectorul

Inspectorul este un instrument excelent care poate porni serverul și îți permite să interacționezi cu el pentru a testa funcționarea. Să-l pornim:

> [!NOTE]
> poate arăta diferit în câmpul "command" deoarece conține comanda pentru rularea serverului cu runtime-ul tău specific/

Ar trebui să vezi următoarea interfață:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ro.png)

1. Conectează-te la server apăsând butonul Connect  
   Odată conectat la server, ar trebui să vezi următoarea imagine:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ro.png)

2. Selectează "Tools" și apoi "listTools", ar trebui să apară opțiunea "Add", selecteaz-o și completează valorile parametrilor.

   Vei vedea următorul răspuns, adică rezultatul de la tool-ul "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ro.png)

Felicitări, ai reușit să creezi și să rulezi primul tău server!

### SDK-uri oficiale

MCP oferă SDK-uri oficiale pentru mai multe limbaje:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Menținut în colaborare cu Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Menținut în colaborare cu Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementarea oficială TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementarea oficială Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementarea oficială Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Menținut în colaborare cu Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementarea oficială Rust

## Concluzii cheie

- Configurarea unui mediu de dezvoltare MCP este simplă cu SDK-urile specifice fiecărui limbaj
- Construirea serverelor MCP implică crearea și înregistrarea tool-urilor cu scheme clare
- Testarea și depanarea sunt esențiale pentru implementări MCP fiabile

## Exemple

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tema

Creează un server MCP simplu cu un tool la alegere:
1. Implementează tool-ul în limbajul preferat (.NET, Java, Python sau JavaScript).
2. Definește parametrii de intrare și valorile de returnare.
3. Rulează instrumentul inspector pentru a verifica dacă serverul funcționează corect.
4. Testează implementarea cu diverse inputuri.

## Soluție

[Soluție](./solution/README.md)

## Resurse suplimentare

- [Depozitul MCP pe GitHub](https://github.com/microsoft/mcp-for-beginners)

## Ce urmează

Următorul pas: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea în urma utilizării acestei traduceri.