<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:26:36+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Este recomandat să instalați `uv`, dar nu este obligatoriu, vedeți [instrucțiunile](https://docs.astral.sh/uv/#highlights)

## -1- Instalați dependențele

```bash
npm install
```

## -3- Rulați exemplul

```bash
npm run build
```

## -4- Testați exemplul

Cu serverul rulând într-un terminal, deschideți un alt terminal și executați următoarea comandă:

```bash
npm run inspector
```

Aceasta ar trebui să pornească un server web cu o interfață vizuală care vă permite să testați exemplul.

Odată ce serverul este conectat:

- încercați să listați uneltele și să rulați `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` este un wrapper în jurul său.

Îl puteți lansa direct în modul CLI rulând următoarea comandă:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Aceasta va lista toate uneltele disponibile pe server. Ar trebui să vedeți următoarea ieșire:

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Ar trebui să vedeți următoarea ieșire:

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

**Declinare responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți de faptul că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem responsabili pentru neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.