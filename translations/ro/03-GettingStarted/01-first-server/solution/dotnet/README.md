<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-09T22:00:13+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

## -1- Instalează dependențele

```bash
dotnet restore
```

## -3- Rulează exemplul

```bash
dotnet run
```

## -4- Testează exemplul

Cu serverul pornit într-un terminal, deschide un alt terminal și execută următoarea comandă:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Aceasta ar trebui să pornească un server web cu o interfață vizuală care îți permite să testezi exemplul.

Odată ce serverul este conectat:

- încearcă să listezi uneltele și rulează `add`, cu argumentele 2 și 4, ar trebui să vezi 6 ca rezultat.
- mergi la resources și resource template și apelează "greeting", introdu un nume și ar trebui să vezi un mesaj de salut cu numele pe care l-ai furnizat.

### Testare în modul CLI

Poți să îl lansezi direct în modul CLI rulând următoarea comandă:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Aceasta va lista toate uneltele disponibile pe server. Ar trebui să vezi următorul rezultat:

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

Pentru a apela o unealtă tastează:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Ar trebui să vezi următorul rezultat:

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

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.