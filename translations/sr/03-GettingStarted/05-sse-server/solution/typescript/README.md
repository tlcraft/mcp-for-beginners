<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:13:20+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

## -1- Instalirajte zavisnosti

```bash
npm install
```

## -3- Pokrenite primer

```bash
npm run build
```

## -4- Testirajte primer

Sa serverom koji radi u jednom terminalu, otvorite drugi terminal i pokrenite sledeću komandu:

```bash
npm run inspector
```

Ovo bi trebalo da pokrene web server sa vizuelnim interfejsom koji vam omogućava da testirate primer.

Kada se server poveže:

- pokušajte da prikažete alate i pokrenete `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- U zasebnom terminalu pokrenite sledeću komandu:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
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

- Pokrenite tip alata tako što ćete uneti sledeću komandu:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Trebalo bi da vidite sledeći izlaz:

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
> Obično je mnogo brže pokrenuti inspektor u CLI modu nego u pregledaču.
> Pročitajte više o inspektoru [ovde](https://github.com/modelcontextprotocol/inspector).

**Odricanje odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo da postignemo tačnost, molimo vas da budete svesni da automatski prevodi mogu sadržati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazume ili pogrešna tumačenja koja proizilaze iz korišćenja ovog prevoda.