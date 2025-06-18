<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:51:25+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "nl"
}
-->
# Voorbeeld

Het vorige voorbeeld laat zien hoe je een lokaal .NET-project gebruikt met het `stdio` type. En hoe je de server lokaal in een container draait. Dit is in veel situaties een goede oplossing. Toch kan het handig zijn om de server op afstand te laten draaien, bijvoorbeeld in een cloudomgeving. Hiervoor is het `http` type bedoeld.

Als je naar de oplossing in de `04-PracticalImplementation` map kijkt, lijkt het misschien veel complexer dan het vorige voorbeeld. Maar in werkelijkheid is dat niet zo. Als je goed kijkt naar het project `src/Calculator`, zie je dat het grotendeels dezelfde code is als in het vorige voorbeeld. Het enige verschil is dat we een andere bibliotheek gebruiken, `ModelContextProtocol.AspNetCore`, om de HTTP-verzoeken af te handelen. En we maken de methode `IsPrime` privé, alleen om te laten zien dat je privé-methodes in je code kunt hebben. De rest van de code is hetzelfde als voorheen.

De andere projecten zijn van [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview). Het toevoegen van .NET Aspire aan de oplossing verbetert de ervaring van de ontwikkelaar tijdens het ontwikkelen en testen en helpt bij de observatie. Het is niet verplicht om de server te laten draaien, maar het is een goede gewoonte om het in je oplossing te hebben.

## Start de server lokaal

1. Ga in VS Code (met de C# DevKit-extensie) naar de `04-PracticalImplementation/samples/csharp` map.
1. Voer het volgende commando uit om de server te starten:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. Wanneer een webbrowser het .NET Aspire dashboard opent, noteer dan de `http` URL. Dit zou iets moeten zijn als `http://localhost:5058/`.

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.nl.png)

## Test Streamable HTTP met de MCP Inspector

Als je Node.js 22.7.5 of hoger hebt, kun je de MCP Inspector gebruiken om je server te testen.

Start de server en voer het volgende commando uit in een terminal:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.nl.png)

- Selecteer `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`. Dit zou `http` moeten zijn (niet `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` server die eerder is gemaakt, zodat het er zo uitziet:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

Doe een paar tests:

- Vraag om "3 priemgetallen na 6780". Let erop dat Copilot de nieuwe tools `NextFivePrimeNumbers` gebruikt en alleen de eerste 3 priemgetallen teruggeeft.
- Vraag om "7 priemgetallen na 111" om te zien wat er gebeurt.
- Vraag om "John heeft 24 lolly's en wil ze verdelen over zijn 3 kinderen. Hoeveel lolly's krijgt elk kind?", om te zien wat er gebeurt.

## Zet de server in Azure

Laten we de server in Azure zetten zodat meer mensen er gebruik van kunnen maken.

Ga in een terminal naar de `04-PracticalImplementation/samples/csharp` map en voer het volgende commando uit:

```bash
azd up
```

Als de deployment klaar is, zou je een bericht moeten zien zoals dit:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.nl.png)

Pak de URL en gebruik deze in de MCP Inspector en in de GitHub Copilot Chat.

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## Wat nu?

We proberen verschillende transporttypes en testtools uit. We zetten ook je MCP-server in Azure. Maar wat als onze server toegang nodig heeft tot privébronnen? Bijvoorbeeld een database of een privé-API? In het volgende hoofdstuk bekijken we hoe we de beveiliging van onze server kunnen verbeteren.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal geldt als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.