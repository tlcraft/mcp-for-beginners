<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:59:17+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

## -1- Instalirajte zavisnosti

```bash
dotnet run
```

## -2- Pokrenite primer

```bash
dotnet run
```

## -3- Testirajte primer

Pokrenite zaseban terminal pre nego što izvršite naredbu ispod (osigurajte da server još uvek radi).

Sa serverom koji radi u jednom terminalu, otvorite drugi terminal i izvršite sledeću komandu:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ovo bi trebalo da pokrene veb server sa vizuelnim interfejsom koji vam omogućava da testirate primer.

Kada se server poveže:

- pokušajte da prikažete listu alata i pokrenete `add`, sa argumentima 2 i 4, trebalo bi da vidite 6 kao rezultat.
- idite na resurse i šablon resursa i pozovite "greeting", unesite ime i trebalo bi da vidite pozdrav sa imenom koje ste uneli.

### Testiranje u CLI režimu

Možete ga pokrenuti direktno u CLI režimu izvršavanjem sledeće komande:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ovo će prikazati sve dostupne alate na serveru. Trebalo bi da vidite sledeći izlaz:

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

Da biste pokrenuli alat, unesite:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Trebalo bi da vidite sledeći izlaz:

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
> Obično je mnogo brže pokrenuti inspektor u CLI režimu nego u pretraživaču.
> Pročitajte više o inspektoru [ovde](https://github.com/modelcontextprotocol/inspector).

**Одричање од одговорности**:  
Овај документ је преведен коришћењем услуге вештачке интелигенције за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако настојимо да постигнемо тачност, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на свом изворном језику треба сматрати меродавним извором. За критичне информације препоручује се професионални људски превод. Не сносимо одговорност за било какве неспоразуме или погрешна тумачења настала коришћењем овог превода.