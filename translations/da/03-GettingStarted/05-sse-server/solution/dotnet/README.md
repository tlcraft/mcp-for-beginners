<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:01:17+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "da"
}
-->
# Kør denne prøve

## -1- Installer afhængighederne

```bash
dotnet restore
```

## -2- Kør prøven

```bash
dotnet run
```

## -3- Test prøven

Start et separat terminalvindue, før du kører nedenstående (sørg for, at serveren stadig kører).

Med serveren kørende i et terminalvindue, åbn et andet terminalvindue og kør følgende kommando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Dette skulle starte en webserver med en visuel grænseflade, der giver dig mulighed for at teste prøven.

> Sørg for, at **SSE** er valgt som transporttype, og at URL'en er `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, med argumenterne 2 og 4, så burde du se 6 som resultat.
- gå til resources og resource template og kald "greeting", skriv et navn, og du skulle se en hilsen med det navn, du indtastede.

### Test i CLI-tilstand

Du kan starte det direkte i CLI-tilstand ved at køre følgende kommando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Dette vil liste alle tilgængelige værktøjer på serveren. Du burde se følgende output:

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

Du burde se følgende output:

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
> Det er som regel meget hurtigere at køre inspectoren i CLI-tilstand end i browseren.
> Læs mere om inspectoren [her](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.