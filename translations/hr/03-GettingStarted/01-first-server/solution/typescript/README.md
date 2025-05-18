<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:27:11+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

Preporučuje se instalacija `uv`, ali nije obavezna, pogledajte [upute](https://docs.astral.sh/uv/#highlights)

## -1- Instalirajte ovisnosti

```bash
npm install
```

## -3- Pokrenite primjer

```bash
npm run build
```

## -4- Testirajte primjer

S pokrenutim serverom u jednom terminalu, otvorite drugi terminal i pokrenite sljedeću naredbu:

```bash
npm run inspector
```

To bi trebalo pokrenuti web server s vizualnim sučeljem koje vam omogućuje testiranje primjera.

Kada se server poveže:

- pokušajte nabrojati alate i pokrenuti `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` je omotač oko njega.

Možete ga pokrenuti izravno u CLI načinu pokretanjem sljedeće naredbe:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Ovo će prikazati sve alate dostupne na serveru. Trebali biste vidjeti sljedeći izlaz:

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

Za pokretanje alata upišite:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Obično je puno brže pokrenuti inspektor u CLI načinu nego u pregledniku.
> Pročitajte više o inspektoru [ovdje](https://github.com/modelcontextprotocol/inspector).

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden koristeći AI uslugu za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, molimo vas da budete svjesni da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.