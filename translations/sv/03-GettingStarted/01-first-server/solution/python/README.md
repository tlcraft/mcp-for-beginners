<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T23:07:50+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "sv"
}
-->
# Köra detta exempel

Det rekommenderas att du installerar `uv` men det är inte ett måste, se [instruktioner](https://docs.astral.sh/uv/#highlights)

## -0- Skapa en virtuell miljö

```bash
python -m venv venv
```

## -1- Aktivera den virtuella miljön

```bash
venv\Scrips\activate
```

## -2- Installera beroenden

```bash
pip install "mcp[cli]"
```

## -3- Kör exemplet

```bash
mcp run server.py
```

## -4- Testa exemplet

Med servern igång i ett terminalfönster, öppna ett annat terminalfönster och kör följande kommando:

```bash
mcp dev server.py
```

Detta bör starta en webbserver med ett visuellt gränssnitt som låter dig testa exemplet.

När servern är ansluten:

- prova att lista verktyg och kör `add` med argumenten 2 och 4, du bör se 6 som resultat.

- gå till resources och resource template och anropa get_greeting, skriv in ett namn och du bör se en hälsning med det namn du angav.

### Testa i CLI-läge

Inspektören du körde är egentligen en Node.js-app och `mcp dev` är ett omslag runt den.

Du kan starta den direkt i CLI-läge genom att köra följande kommando:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Detta listar alla verktyg som finns tillgängliga på servern. Du bör se följande utdata:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Du bör se följande utdata:

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
> Det är oftast mycket snabbare att köra inspektören i CLI-läge än i webbläsaren.
> Läs mer om inspektören [här](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.