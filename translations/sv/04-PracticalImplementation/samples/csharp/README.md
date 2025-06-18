<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:50:41+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "sv"
}
-->
# Exempel

Det föregående exemplet visar hur man använder ett lokalt .NET-projekt med typen `stdio`. Och hur man kör servern lokalt i en container. Detta är en bra lösning i många situationer. Men det kan vara användbart att ha servern igång på distans, till exempel i en molnmiljö. Det är här typen `http` kommer in.

Om man tittar på lösningen i mappen `04-PracticalImplementation` kan den verka mycket mer komplex än den tidigare. Men i verkligheten är det inte så. Om du tittar noga på projektet `src/Calculator` ser du att det mestadels är samma kod som i det föregående exemplet. Den enda skillnaden är att vi använder ett annat bibliotek `ModelContextProtocol.AspNetCore` för att hantera HTTP-förfrågningarna. Och vi ändrar metoden `IsPrime` till att vara privat, bara för att visa att du kan ha privata metoder i din kod. Resten av koden är densamma som tidigare.

De andra projekten kommer från [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview). Att ha .NET Aspire i lösningen förbättrar utvecklarupplevelsen vid utveckling och testning och hjälper till med observabilitet. Det är inte nödvändigt för att köra servern, men det är god praxis att ha det i din lösning.

## Starta servern lokalt

1. I VS Code (med C# DevKit-tillägget), navigera till katalogen `04-PracticalImplementation/samples/csharp`.
1. Kör följande kommando för att starta servern:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. När en webbläsare öppnar .NET Aspire-instrumentpanelen, notera URL:en `http`. Den bör vara något i stil med `http://localhost:5058/`.

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.sv.png)

## Testa Streamable HTTP med MCP Inspector

Om du har Node.js 22.7.5 eller senare kan du använda MCP Inspector för att testa din server.

Starta servern och kör följande kommando i en terminal:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.sv.png)

- Välj `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`. Det bör vara `http` (inte `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` server som skapades tidigare för att se ut så här:

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

Gör några tester:

- Be om "3 primtal efter 6780". Notera hur Copilot använder de nya verktygen `NextFivePrimeNumbers` och bara returnerar de första 3 primtalen.
- Be om "7 primtal efter 111", för att se vad som händer.
- Be om "John har 24 klubbor och vill dela ut dem alla till sina 3 barn. Hur många klubbor får varje barn?", för att se vad som händer.

## Distribuera servern till Azure

Låt oss distribuera servern till Azure så att fler kan använda den.

Från en terminal, navigera till mappen `04-PracticalImplementation/samples/csharp` och kör följande kommando:

```bash
azd up
```

När distributionen är klar bör du se ett meddelande som detta:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.sv.png)

Ta URL:en och använd den i MCP Inspector och i GitHub Copilot Chat.

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

## Vad händer härnäst?

Vi testar olika transporttyper och testverktyg. Vi distribuerar också din MCP-server till Azure. Men vad händer om vår server behöver åtkomst till privata resurser? Till exempel en databas eller ett privat API? I nästa kapitel ska vi se hur vi kan förbättra säkerheten för vår server.

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.