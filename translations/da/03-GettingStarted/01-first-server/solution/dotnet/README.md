<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:10:02+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "da"
}
-->
# Køre dette eksempel

## -1- Installer afhængighederne

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Kør eksemplet

```bash
dotnet run
```

## -4- Test eksemplet

Med serveren kørende i en terminal, åbner du en anden terminal og kører følgende kommando:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Dette skulle starte en webserver med en visuel grænseflade, der giver dig mulighed for at teste eksemplet.

Når serveren er forbundet:

- prøv at liste værktøjer og kør `add` med argumenterne 2 og 4, du skulle se 6 i resultatet.
- gå til ressourcer og ressource skabelon og kald "greeting", skriv et navn, og du skulle se en hilsen med det navn, du indtastede.

### Test i CLI-tilstand

Du kan starte det direkte i CLI-tilstand ved at køre følgende kommando:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Dette vil liste alle de værktøjer, der er tilgængelige på serveren. Du skulle se følgende output:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

For at aktivere et værktøj, skriv:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Du skulle se følgende output:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Det er normalt meget hurtigere at køre inspektøren i CLI-tilstand end i browseren.
> Læs mere om inspektøren [her](https://github.com/modelcontextprotocol/inspector).

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.