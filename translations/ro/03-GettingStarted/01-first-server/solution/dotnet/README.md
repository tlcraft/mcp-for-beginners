<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:12:22+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

## -1- Instalează dependențele

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Rulează exemplul

```bash
dotnet run
```

## -4- Testează exemplul

Cu serverul rulând într-un terminal, deschide un alt terminal și execută următoarea comandă:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Acest lucru ar trebui să pornească un server web cu o interfață vizuală care îți permite să testezi exemplul.

Odată ce serverul este conectat:

- încearcă să listezi uneltele și să rulezi `add`, cu argumentele 2 și 4, ar trebui să vezi 6 în rezultat.
- mergi la resurse și șablon de resurse și apelează "greeting", tastează un nume și ar trebui să vezi un salut cu numele pe care l-ai furnizat.

### Testarea în modul CLI

Poți să-l lansezi direct în modul CLI rulând următoarea comandă:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Acest lucru va lista toate uneltele disponibile în server. Ar trebui să vezi următoarea ieșire:

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

Pentru a invoca o unealtă tastează:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Ar trebui să vezi următoarea ieșire:

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
> De obicei, este mult mai rapid să rulezi inspectorul în modul CLI decât în browser.
> Citește mai multe despre inspector [aici](https://github.com/modelcontextprotocol/inspector).

**Declinări de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți de faptul că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.