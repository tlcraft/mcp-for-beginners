<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:17:26+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

Preporučuje se instalirati `uv`, ali nije obavezno, pogledajte [upute](https://docs.astral.sh/uv/#highlights)

## -0- Kreirajte virtualno okruženje

```bash
python -m venv venv
```

## -1- Aktivirajte virtualno okruženje

```bash
venv\Scrips\activate
```

## -2- Instalirajte ovisnosti

```bash
pip install "mcp[cli]"
```

## -3- Pokrenite primjer

```bash
uvicorn server:app
```

## -4- Testirajte primjer

Dok je server pokrenut u jednom terminalu, otvorite drugi terminal i pokrenite sljedeću naredbu:

```bash
mcp dev server.py
```

Ovo bi trebalo pokrenuti web server s vizualnim sučeljem koje vam omogućuje testiranje primjera.

Kada se server poveže:

- pokušajte ispisati alate i pokrenuti `add` s argumentima 2 i 4, trebali biste vidjeti rezultat 6.
- idite na resources i resource template te pozovite get_greeting, unesite ime i trebali biste vidjeti pozdrav s imenom koje ste unijeli.

### Testiranje u CLI načinu

Inspektor koji ste pokrenuli zapravo je Node.js aplikacija, a `mcp dev` je omot oko nje.

Možete ga pokrenuti izravno u CLI načinu pokretanjem sljedeće naredbe:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Ovo će prikazati popis svih alata dostupnih na serveru. Trebali biste vidjeti sljedeći izlaz:

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

Za pozivanje alata unesite:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

> [!TIP]
> Obično je puno brže pokrenuti inspektor u CLI načinu nego u pregledniku.
> Pročitajte više o inspektoru [ovdje](https://github.com/modelcontextprotocol/inspector).

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.