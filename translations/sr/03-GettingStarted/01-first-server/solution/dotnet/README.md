<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:12:51+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

## -1- Instalirajte zavisnosti

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Pokrenite primer

```bash
dotnet run
```

## -4- Testirajte primer

Sa serverom koji radi u jednom terminalu, otvorite drugi terminal i pokrenite sledeću komandu:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Ovo bi trebalo da pokrene veb server sa vizuelnim interfejsom koji vam omogućava da testirate primer.

Kada se server poveže:

- pokušajte da izlistate alate i pokrenete `add`, sa argumentima 2 i 4, trebalo bi da vidite 6 u rezultatu.
- idite na resurse i šablon resursa i pozovite "greeting", unesite ime i trebalo bi da vidite pozdrav sa imenom koje ste uneli.

### Testiranje u CLI režimu

Možete ga pokrenuti direktno u CLI režimu pokretanjem sledeće komande:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ovo će izlistati sve dostupne alate na serveru. Trebalo bi da vidite sledeći izlaz:

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

Da biste pozvali alat, otkucajte:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Trebalo bi da vidite sledeći izlaz:

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
> Obično je mnogo brže pokrenuti inspektor u CLI režimu nego u pregledaču.
> Pročitajte više o inspektoru [ovde](https://github.com/modelcontextprotocol/inspector).

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитативним извором. За критичне информације, препоручује се професионални превод од стране људи. Не сносимо одговорност за било каква неразумевања или погрешна тумачења која произилазе из употребе овог превода.