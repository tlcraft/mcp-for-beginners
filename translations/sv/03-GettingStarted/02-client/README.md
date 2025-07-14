<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:16:14+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sv"
}
-->
I föregående kod:

- Importerar vi biblioteken
- Skapar en instans av en klient och ansluter den med stdio som transport.
- Listar prompts, resurser och verktyg och anropar dem alla.

Där har du det, en klient som kan kommunicera med en MCP-server.

Låt oss ta oss tid i nästa övningsavsnitt och gå igenom varje kodsnutt och förklara vad som händer.

## Övning: Skriva en klient

Som sagt ovan, låt oss ta oss tid att förklara koden, och koda gärna med om du vill.

### -1- Importera biblioteken

Låt oss importera de bibliotek vi behöver, vi kommer att behöva referenser till en klient och till vårt valda transportprotokoll, stdio. stdio är ett protokoll för saker som är tänkta att köras på din lokala maskin. SSE är ett annat transportprotokoll som vi kommer att visa i framtida kapitel, men det är ditt andra alternativ. För nu, låt oss fortsätta med stdio.

Låt oss gå vidare till instansiering.

### -2- Instansiera klient och transport

Vi behöver skapa en instans av transporten och en av vår klient:

### -3- Lista serverns funktioner

Nu har vi en klient som kan ansluta till servern om programmet körs. Men den listar faktiskt inte dess funktioner, så låt oss göra det härnäst:

Bra, nu har vi fångat alla funktioner. Nu är frågan när använder vi dem? Den här klienten är ganska enkel, enkel i den meningen att vi behöver anropa funktionerna explicit när vi vill använda dem. I nästa kapitel kommer vi att skapa en mer avancerad klient som har tillgång till sin egen stora språkmodell, LLM. Men för nu, låt oss se hur vi kan anropa funktionerna på servern:

### -4- Anropa funktioner

För att anropa funktionerna behöver vi se till att vi anger rätt argument och i vissa fall namnet på det vi försöker anropa.

### -5- Kör klienten

För att köra klienten, skriv följande kommando i terminalen:

## Uppgift

I denna uppgift ska du använda det du lärt dig om att skapa en klient men skapa en egen klient.

Här är en server du kan använda som du behöver anropa via din klientkod, se om du kan lägga till fler funktioner till servern för att göra den mer intressant.

## Lösning

[Lösning](./solution/README.md)

## Viktiga punkter

De viktigaste punkterna i detta kapitel om klienter är följande:

- Kan användas både för att upptäcka och anropa funktioner på servern.
- Kan starta en server samtidigt som den startar sig själv (som i detta kapitel), men klienter kan också ansluta till redan körande servrar.
- Är ett utmärkt sätt att testa serverns kapabiliteter bredvid alternativ som Inspector, som beskrevs i föregående kapitel.

## Ytterligare resurser

- [Bygga klienter i MCP](https://modelcontextprotocol.io/quickstart/client)

## Exempel

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Vad händer härnäst

- Nästa: [Skapa en klient med en LLM](../03-llm-client/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.