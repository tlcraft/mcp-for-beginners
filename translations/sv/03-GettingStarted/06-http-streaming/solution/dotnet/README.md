<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:17:54+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "sv"
}
-->
# Köra detta exempel

## -1- Installera beroenden

```bash
dotnet restore
```

## -2- Kör exemplet

```bash
dotnet run
```

## -3- Testa exemplet

Starta en separat terminal innan du kör kommandot nedan (se till att servern fortfarande är igång).

Med servern igång i en terminal, öppna en annan terminal och kör följande kommando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Detta bör starta en webbserver med ett visuellt gränssnitt som låter dig testa exemplet.

> Se till att **Streamable HTTP** är valt som transporttyp, och URL är `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, med argumenten 2 och 4, du bör se 6 som resultat.
- gå till resources och resource template och kalla på "greeting", skriv in ett namn så bör du se en hälsning med det namn du angav.

### Testa i CLI-läge

Du kan starta det direkt i CLI-läge genom att köra följande kommando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Detta listar alla verktyg som finns tillgängliga på servern. Du bör se följande output:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

För att anropa ett verktyg, skriv:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Du bör se följande output:

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
> Det går oftast mycket snabbare att köra inspektören i CLI-läge än i webbläsaren.
> Läs mer om inspektören [här](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess ursprungliga språk ska betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår till följd av användningen av denna översättning.