<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:24:02+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "sv"
}
-->
# Köra detta exempel

Det rekommenderas att installera `uv` men det är inte ett måste, se [instruktioner](https://docs.astral.sh/uv/#highlights)

## -1- Installera beroenden

```bash
npm install
```

## -3- Kör exemplet

```bash
npm run build
```

## -4- Testa exemplet

Med servern igång i en terminal, öppna en annan terminal och kör följande kommando:

```bash
npm run inspector
```

Detta bör starta en webbserver med ett visuellt gränssnitt som låter dig testa exemplet.

När servern är ansluten:

- försök att lista verktyg och kör `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` är en wrapper runt det.

Du kan starta det direkt i CLI-läge genom att köra följande kommando:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Detta kommer att lista alla verktyg som finns tillgängliga på servern. Du bör se följande utmatning:

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

För att anropa ett verktyg, skriv:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Du bör se följande utmatning:

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
> Det är vanligtvis mycket snabbare att köra inspektorn i CLI-läge än i webbläsaren.
> Läs mer om inspektorn [här](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, bör du vara medveten om att automatiserade översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess originalspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller misstolkningar som uppstår från användningen av denna översättning.