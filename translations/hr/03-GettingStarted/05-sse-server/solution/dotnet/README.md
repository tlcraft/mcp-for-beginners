<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:59:28+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

## -1- Instalirajte ovisnosti

```bash
dotnet run
```

## -2- Pokrenite primjer

```bash
dotnet run
```

## -3- Testirajte primjer

Pokrenite zasebni terminal prije nego što izvršite sljedeće (provjerite je li poslužitelj još uvijek pokrenut).

Dok je poslužitelj pokrenut u jednom terminalu, otvorite drugi terminal i pokrenite sljedeću naredbu:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

To bi trebalo pokrenuti web poslužitelj s vizualnim sučeljem koje vam omogućuje testiranje primjera.

Kada se poslužitelj poveže:

- pokušajte navesti alate i pokrenuti `add`, s argumentima 2 i 4, trebali biste vidjeti 6 u rezultatu.
- idite na resurse i predložak resursa i pozovite "greeting", upišite ime i trebali biste vidjeti pozdrav s imenom koje ste unijeli.

### Testiranje u CLI načinu

Možete ga pokrenuti izravno u CLI načinu pokretanjem sljedeće naredbe:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ovo će navesti sve alate dostupne na poslužitelju. Trebali biste vidjeti sljedeći izlaz:

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

Za pozivanje alata upišite:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Trebali biste vidjeti sljedeći izlaz:

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
> Obično je puno brže pokrenuti inspektor u CLI načinu nego u pregledniku.
> Više o inspektoru pročitajte [ovdje](https://github.com/modelcontextprotocol/inspector).

**Odricanje odgovornosti**:  
Ovaj dokument je preveden koristeći AI uslugu za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane ljudi. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.