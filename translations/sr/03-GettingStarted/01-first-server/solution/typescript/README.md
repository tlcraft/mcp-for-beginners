<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:26:59+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

Preporučuje se instalacija `uv`, ali nije obavezna, pogledajte [instrukcije](https://docs.astral.sh/uv/#highlights)

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

- pokušajte da prikažete listu alata i pokrenite `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev`, što je omotač oko toga.

Možete ga pokrenuti direktno u CLI modu pokretanjem sledeće komande:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
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

Da biste pokrenuli alat, unesite:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

**Одричање од одговорности**:  
Овај документ је преведен користећи услугу за превођење вештачке интелигенције [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да обезбедимо тачност, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на свом изворном језику треба сматрати ауторитативним извором. За критичне информације, препоручује се професионални превод од стране људи. Не сносимо одговорност за било каква неразумевања или погрешна тумачења која произилазе из коришћења овог превода.