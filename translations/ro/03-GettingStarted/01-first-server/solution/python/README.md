<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:19:36+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Se recomandă instalarea `uv`, dar nu este obligatoriu, vezi [instrucțiuni](https://docs.astral.sh/uv/#highlights)

## -0- Creează un mediu virtual

```bash
python -m venv venv
```

## -1- Activează mediul virtual

```bash
venv\Scrips\activate
```

## -2- Instalează dependențele

```bash
pip install "mcp[cli]"
```

## -3- Rulează exemplul

```bash
mcp run server.py
```

## -4- Testează exemplul

Cu serverul rulând într-un terminal, deschide un alt terminal și rulează următoarea comandă:

```bash
mcp dev server.py
```

Aceasta ar trebui să pornească un server web cu o interfață vizuală care îți permite să testezi exemplul.

Odată ce serverul este conectat:

- încearcă să listezi uneltele și rulează `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` este un înveliș în jurul acestuia.

Poți să-l lansezi direct în modul CLI rulând următoarea comandă:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Aceasta va lista toate uneltele disponibile pe server. Ar trebui să vezi următorul output:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Pentru a invoca o unealtă, tastează:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Ar trebui să vezi următorul output:

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
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți de faptul că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.