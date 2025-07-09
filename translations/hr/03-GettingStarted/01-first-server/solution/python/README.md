<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T23:16:55+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

Preporučuje se instalacija `uv`, ali nije obavezno, pogledajte [upute](https://docs.astral.sh/uv/#highlights)

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
mcp run server.py
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

Inspector koji ste pokrenuli zapravo je Node.js aplikacija, a `mcp dev` je omotač oko nje.

Možete ga pokrenuti izravno u CLI načinu pokretanjem sljedeće naredbe:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Ovo će ispisati sve alate dostupne na serveru. Trebali biste vidjeti sljedeći ispis:

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

Za pozivanje alata upišite:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.