<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:06:19+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

Preporučuje se instalacija `uv`, ali nije obavezno, pogledajte [uputstva](https://docs.astral.sh/uv/#highlights)

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

Dok server radi u jednom terminalu, otvorite drugi terminal i pokrenite sledeću komandu:

```bash
mcp dev server.py
```

Ovo bi trebalo da pokrene veb server sa vizuelnim interfejsom koji vam omogućava da testirate primer.

Kada se server poveže:

- pokušajte da nabrojite alate i pokrenete `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev`, koji je omotač oko njega.

Možete ga direktno pokrenuti u CLI modu pomoću sledeće komande:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Ovo će nabrojati sve alate dostupne na serveru. Trebalo bi da vidite sledeći izlaz:

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

Da biste pozvali alat, unesite:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Obično je mnogo brže pokrenuti inspektor u CLI modu nego u pretraživaču.
> Pročitajte više o inspektoru [ovde](https://github.com/modelcontextprotocol/inspector).

**Одрицање од одговорности**:  
Овај документ је преведен користећи AI услугу за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да обезбедимо тачност, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални превод од стране људи. Не сносимо одговорност за било какве неспоразуме или погрешна тумачења која проистичу из коришћења овог превода.