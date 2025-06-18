<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:18:00+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "da"
}
-->
# Kørsel af dette eksempel

## -1- Installer afhængighederne

```bash
dotnet restore
```

## -2- Kør eksemplet

```bash
dotnet run
```

## -3- Test eksemplet

Start et separat terminalvindue, før du kører nedenstående (sørg for, at serveren stadig kører).

Med serveren kørende i et terminalvindue, åbn et andet terminalvindue og kør følgende kommando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Dette burde starte en webserver med en visuel grænseflade, som gør det muligt at teste eksemplet.

> Sørg for, at **Streamable HTTP** er valgt som transporttype, og at URL’en er `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, med argumenterne 2 og 4, så du skulle se 6 i resultatet.
- gå til resources og resource template og kald "greeting", skriv et navn, og du skulle se en hilsen med det navn, du indtastede.

### Test i CLI-tilstand

Du kan starte det direkte i CLI-tilstand ved at køre følgende kommando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Dette vil liste alle tilgængelige værktøjer på serveren. Du skulle se følgende output:

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

For at kalde et værktøj, skriv:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Du skulle se følgende output:

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
> Det er som regel meget hurtigere at køre inspector i CLI-tilstand end i browseren.
> Læs mere om inspector [her](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.