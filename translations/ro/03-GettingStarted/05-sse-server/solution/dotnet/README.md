<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:58:53+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

## -1- Instalează dependențele

```bash
dotnet run
```

## -2- Rulează exemplul

```bash
dotnet run
```

## -3- Testează exemplul

Deschide un terminal separat înainte de a rula cele de mai jos (asigură-te că serverul este încă activ).

Cu serverul rulând într-un terminal, deschide un alt terminal și execută următoarea comandă:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Aceasta ar trebui să pornească un server web cu o interfață vizuală care îți permite să testezi exemplul.

Odată ce serverul este conectat:

- încearcă să listezi uneltele și rulează `add`, cu argumentele 2 și 4, ar trebui să vezi 6 în rezultat.
- mergi la resurse și șablonul de resurse și apelează "greeting", tastează un nume și ar trebui să vezi o urare cu numele pe care l-ai furnizat.

### Testarea în modul CLI

Poți lansa direct în modul CLI rulând următoarea comandă:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Aceasta va lista toate uneltele disponibile în server. Ar trebui să vezi următorul rezultat:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
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
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Ar trebui să vezi următorul rezultat:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> De obicei, este mult mai rapid să rulezi inspectorul în modul CLI decât în browser.
> Citește mai multe despre inspector [aici](https://github.com/modelcontextprotocol/inspector).

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să obținem acuratețe, vă rugăm să fiți conștienți de faptul că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de oameni. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.