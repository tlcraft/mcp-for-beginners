<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:20:43+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "sv"
}
-->
# Köra detta exempel

## -1- Installera beroenden

```bash
npm install
```

## -3- Kör exemplet

```bash
npm run build
```

## -4- Testa exemplet

Med servern igång i ett terminalfönster, öppna ett annat terminalfönster och kör följande kommando:

```bash
npm run inspector
```

Detta bör starta en webbserver med ett visuellt gränssnitt som låter dig testa exemplet.

När servern är ansluten:

- prova att lista verktyg och kör `add` med argumenten 2 och 4, du bör se 6 som resultat.
- gå till resources och resource template och anropa "greeting", skriv in ett namn och du bör se en hälsning med det namn du angav.

### Testa i CLI-läge

Inspektören du körde är egentligen en Node.js-app och `mcp dev` är ett gränssnitt runt den.

- Starta servern med kommandot `npm run build`.

- I ett separat terminalfönster kör följande kommando:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Detta listar alla verktyg som finns tillgängliga på servern. Du bör se följande output:

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

- Anropa en verktygstyp genom att skriva följande kommando:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Du bör se följande output:

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
> Det går oftast mycket snabbare att köra inspektören i CLI-läge än i webbläsaren.
> Läs mer om inspektören [här](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.