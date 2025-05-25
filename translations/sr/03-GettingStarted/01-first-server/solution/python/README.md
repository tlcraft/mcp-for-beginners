<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:19:58+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

Preporučuje se instalacija `uv`, ali nije obavezna, pogledajte [uputstva](https://docs.astral.sh/uv/#highlights)

## -0- Kreirajte virtuelno okruženje

```bash
python -m venv venv
```

## -1- Aktivirajte virtuelno okruženje

```bash
venv\Scrips\activate
```

## -2- Instalirajte zavisnosti

```bash
pip install "mcp[cli]"
```

## -3- Pokrenite primer

```bash
mcp run server.py
```

## -4- Testirajte primer

Sa serverom koji radi u jednom terminalu, otvorite drugi terminal i pokrenite sledeću komandu:

```bash
mcp dev server.py
```

Ovo bi trebalo da pokrene veb server sa vizuelnim interfejsom koji vam omogućava da testirate primer.

Kada se server poveže:

- pokušajte da prikažete alate i pokrenete `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev`, što je omotač oko njega.

Možete ga pokrenuti direktno u CLI modu izvršavanjem sledeće komande:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Ovo će prikazati sve dostupne alate na serveru. Trebalo bi da vidite sledeći izlaz:

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

Da biste pozvali alat, otkucajte:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Trebalo bi da vidite sledeći izlaz:

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
> Obično je mnogo brže pokrenuti ispektor u CLI modu nego u pretraživaču.
> Pročitajte više o ispektoru [ovde](https://github.com/modelcontextprotocol/inspector).

**Одричање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да постигнемо тачност, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални превод од стране људи. Не сносимо одговорност за било какве неспоразуме или погрешна тумачења која могу произаћи из употребе овог превода.