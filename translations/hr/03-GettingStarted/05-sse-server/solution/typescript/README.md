<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:13:29+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

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

Nakon što se server poveže:

- pokušajte navesti alate i pokrenite `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- U odvojenom terminalu pokrenite sljedeću naredbu:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Ovo će navesti sve dostupne alate na serveru. Trebali biste vidjeti sljedeći izlaz:

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

- Pokrenite tip alata upisivanjem sljedeće naredbe:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Trebali biste vidjeti sljedeći izlaz:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Obično je puno brže pokrenuti inspector u CLI načinu nego u pregledniku.
> Pročitajte više o inspectoru [ovdje](https://github.com/modelcontextprotocol/inspector).

**Odricanje odgovornosti**:  
Ovaj dokument je preveden koristeći AI uslugu za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo postići točnost, molimo vas da budete svjesni da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.