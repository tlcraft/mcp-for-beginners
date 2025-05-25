<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:05:57+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Este recomandat să instalați `uv`, dar nu este obligatoriu, vedeți [instrucțiunile](https://docs.astral.sh/uv/#highlights)

## -0- Creați un mediu virtual

```bash
python -m venv venv
```

## -1- Activați mediul virtual

```bash
venv\Scrips\activate
```

## -2- Instalați dependențele

```bash
pip install "mcp[cli]"
```

## -3- Rulați exemplul

```bash
mcp run server.py
```

## -4- Testați exemplul

Cu serverul rulând într-un terminal, deschideți un alt terminal și executați următoarea comandă:

```bash
mcp dev server.py
```

Acest lucru ar trebui să pornească un server web cu o interfață vizuală care vă permite să testați exemplul.

Odată ce serverul este conectat:

- încercați să listați uneltele și să rulați `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` este un wrapper în jurul acestuia.

Puteți să-l lansați direct în modul CLI rulând următoarea comandă:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Aceasta va lista toate uneltele disponibile în server. Ar trebui să vedeți următorul output:

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

Pentru a invoca o unealtă, tastați:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Ar trebui să vedeți următorul output:

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
> De obicei, este mult mai rapid să rulați inspectorul în modul CLI decât în browser.
> Citiți mai multe despre inspector [aici](https://github.com/modelcontextprotocol/inspector).

**Declinare:**
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea umană profesională. Nu suntem responsabili pentru neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.