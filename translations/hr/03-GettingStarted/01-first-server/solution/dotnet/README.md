<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:13:02+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

## -1- Instalirajte ovisnosti

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Pokrenite primjer

```bash
dotnet run
```

## -4- Testirajte primjer

Dok je server pokrenut u jednom terminalu, otvorite drugi terminal i pokrenite sljedeću naredbu:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Ovo bi trebalo pokrenuti web server s vizualnim sučeljem koje vam omogućuje testiranje primjera.

Kada se server poveže:

- pokušajte navesti alate i pokrenuti `add`, s argumentima 2 i 4, trebali biste vidjeti 6 u rezultatu.
- idite na resurse i predložak resursa i pozovite "greeting", unesite ime i trebali biste vidjeti pozdrav s imenom koje ste unijeli.

### Testiranje u CLI načinu

Možete ga pokrenuti izravno u CLI načinu pokretanjem sljedeće naredbe:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ovo će navesti sve alate dostupne na serveru. Trebali biste vidjeti sljedeći ispis:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Za pozivanje alata upišite:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Trebali biste vidjeti sljedeći ispis:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Obično je puno brže pokrenuti ispektor u CLI načinu nego u pregledniku.
> Pročitajte više o ispektoru [ovdje](https://github.com/modelcontextprotocol/inspector).

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo ka točnosti, molimo vas da budete svjesni da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na njegovom izvornom jeziku treba smatrati mjerodavnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne odgovaramo za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.