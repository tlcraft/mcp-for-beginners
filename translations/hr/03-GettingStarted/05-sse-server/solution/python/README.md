<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:06:29+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

Preporučuje se instalirati `uv`, ali nije obavezno, pogledajte [upute](https://docs.astral.sh/uv/#highlights)

## -0- Kreirajte virtualno okruženje

```bash
python -m venv venv
```

## -1- Aktivirajte virtualno okruženje

```bash
venv\Scrips\activate
```

## -2- Instalirajte ovisnosti

```bash
pip install "mcp[cli]"
```

## -3- Pokrenite primjer

```bash
mcp run server.py
```

## -4- Testirajte primjer

Dok server radi u jednom terminalu, otvorite drugi terminal i pokrenite sljedeću naredbu:

```bash
mcp dev server.py
```

Ovo bi trebalo pokrenuti web server s vizualnim sučeljem koje vam omogućuje testiranje primjera.

Kada je server povezan:

- pokušajte nabrojati alate i pokrenuti `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` je omotač oko toga.

Možete ga pokrenuti izravno u CLI načinu pokretanjem sljedeće naredbe:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Ovo će nabrojati sve dostupne alate na serveru. Trebali biste vidjeti sljedeći izlaz:

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

Za pozivanje alata upišite:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Trebali biste vidjeti sljedeći izlaz:

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
> Obično je mnogo brže pokrenuti inspektor u CLI načinu nego u pregledniku.
> Pročitajte više o inspektoru [ovdje](https://github.com/modelcontextprotocol/inspector).

**Izjava o odricanju odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, molimo vas da budete svjesni da automatizirani prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne preuzimamo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.