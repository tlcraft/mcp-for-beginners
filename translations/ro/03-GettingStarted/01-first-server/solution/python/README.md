<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T23:15:16+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Se recomandă instalarea `uv`, dar nu este obligatoriu, vezi [instrucțiunile](https://docs.astral.sh/uv/#highlights)

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

Cu serverul pornit într-un terminal, deschide un alt terminal și execută următoarea comandă:

```bash
mcp dev server.py
```

Aceasta ar trebui să pornească un server web cu o interfață vizuală care îți permite să testezi exemplul.

Odată ce serverul este conectat:

- încearcă să listezi uneltele și rulează `add`, cu argumentele 2 și 4, ar trebui să vezi 6 ca rezultat.

- mergi la resources și resource template și apelează get_greeting, introdu un nume și ar trebui să vezi un mesaj de salut cu numele pe care l-ai introdus.

### Testare în modul CLI

Inspectorul pe care l-ai rulat este de fapt o aplicație Node.js, iar `mcp dev` este un wrapper pentru aceasta.

Poți să îl lansezi direct în modul CLI rulând următoarea comandă:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Aceasta va lista toate uneltele disponibile pe server. Ar trebui să vezi următorul rezultat:

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

Pentru a apela o unealtă tastează:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.