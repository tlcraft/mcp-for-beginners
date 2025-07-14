<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:10:48+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "nl"
}
-->
# Deze sample uitvoeren

## -1- Installeer de dependencies

```bash
dotnet restore
```

## -2- Voer de sample uit

```bash
dotnet run
```

## -3- Test de sample

Start een aparte terminal voordat je onderstaande uitvoert (zorg dat de server nog draait).

Met de server draaiend in één terminal, open je een andere terminal en voer je het volgende commando uit:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Dit zou een webserver moeten starten met een visuele interface waarmee je de sample kunt testen.

> Zorg ervoor dat **SSE** is geselecteerd als het transporttype, en dat de URL `http://localhost:3001/sse` is.

Zodra de server verbonden is:

- probeer tools op te sommen en voer `add` uit met argumenten 2 en 4, je zou 6 als resultaat moeten zien.
- ga naar resources en resource template en roep "greeting" aan, typ een naam in en je zou een begroeting met de opgegeven naam moeten zien.

### Testen in CLI-modus

Je kunt het direct in CLI-modus starten door het volgende commando uit te voeren:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Dit zal alle beschikbare tools op de server tonen. Je zou de volgende output moeten zien:

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

Om een tool aan te roepen, typ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Je zou de volgende output moeten zien:

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
> Het is meestal veel sneller om de inspector in CLI-modus te draaien dan in de browser.
> Lees meer over de inspector [hier](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.