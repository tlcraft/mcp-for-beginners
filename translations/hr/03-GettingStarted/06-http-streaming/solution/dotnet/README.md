<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:19:36+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

## -1- Instalirajte ovisnosti

```bash
dotnet restore
```

## -2- Pokrenite primjer

```bash
dotnet run
```

## -3- Testirajte primjer

Prije nego što pokrenete naredbu u nastavku, otvorite zasebni terminal (provjerite da je server još uvijek pokrenut).

Dok je server pokrenut u jednom terminalu, otvorite drugi terminal i pokrenite sljedeću naredbu:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Time bi se trebao pokrenuti web server s vizualnim sučeljem koje vam omogućuje testiranje primjera.

> Provjerite je li kao tip prijenosa odabran **Streamable HTTP**, a URL je `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, s argumentima 2 i 4, trebali biste vidjeti rezultat 6.
- idite na resources i resource template, pozovite "greeting", upišite ime i trebali biste vidjeti pozdrav s imenom koje ste unijeli.

### Testiranje u CLI načinu

Možete ga pokrenuti izravno u CLI načinu pomoću sljedeće naredbe:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ovo će prikazati sve alate dostupne na serveru. Trebali biste vidjeti sljedeći ispis:

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

Trebali biste vidjeti sljedeći ispis:

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
> Obično je puno brže pokrenuti inspector u CLI načinu nego u pregledniku.
> Više o inspectoru pročitajte [ovdje](https://github.com/modelcontextprotocol/inspector).

**Odricanje od odgovornosti**:  
Ovaj je dokument preveden pomoću AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Nismo odgovorni za bilo kakve nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.