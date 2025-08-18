<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d26f746e21775c30b4d7ed97962b24df",
  "translation_date": "2025-08-18T20:49:07+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Se recomandă să instalați `uv`, dar nu este obligatoriu, consultați [instrucțiunile](https://docs.astral.sh/uv/#highlights)

## -0- Creați un mediu virtual

```bash
python -m venv venv
```

## -1- Activați mediul virtual

```bash
venv\Scripts\activate
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

Cu serverul pornit într-un terminal, deschideți un alt terminal și rulați următoarea comandă:

```bash
mcp dev server.py
```

Aceasta ar trebui să pornească un server web cu o interfață vizuală care vă permite să testați exemplul.

Odată ce serverul este conectat:

- încercați să listați uneltele și să rulați `add`, cu argumentele 2 și 4, ar trebui să vedeți 6 în rezultat.

- mergeți la resurse și șablonul de resurse și apelați get_greeting, introduceți un nume și ar trebui să vedeți un mesaj de salut cu numele pe care l-ați furnizat.

### Testarea în modul CLI

Inspectorul pe care l-ați rulat este de fapt o aplicație Node.js, iar `mcp dev` este un wrapper în jurul acesteia.

Îl puteți lansa direct în modul CLI rulând următoarea comandă:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Aceasta va lista toate uneltele disponibile pe server. Ar trebui să vedeți următorul rezultat:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Ar trebui să vedeți următorul rezultat:

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

**Declinarea responsabilității**:  
Acest document a fost tradus utilizând serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși depunem eforturi pentru a asigura acuratețea, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.