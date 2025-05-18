<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:21:56+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sv"
}
-->
# Skapa en klient med LLM

Hittills har du sett hur man skapar en server och en klient. Klienten har kunnat anropa servern explicit för att lista dess verktyg, resurser och uppmaningar. Detta är dock inte ett särskilt praktiskt tillvägagångssätt. Din användare lever i den agentiska eran och förväntar sig att använda uppmaningar och kommunicera med en LLM för att göra det. För din användare spelar det ingen roll om du använder MCP eller inte för att lagra dina funktioner, men de förväntar sig att använda naturligt språk för att interagera. Så hur löser vi detta? Lösningen är att lägga till en LLM till klienten.

## Översikt

I denna lektion fokuserar vi på att lägga till en LLM till din klient och visar hur detta ger en mycket bättre upplevelse för din användare.

## Inlärningsmål

I slutet av denna lektion kommer du att kunna:

- Skapa en klient med en LLM.
- Sömlöst interagera med en MCP-server med hjälp av en LLM.
- Ge en bättre användarupplevelse på klientsidan.

## Tillvägagångssätt

Låt oss försöka förstå det tillvägagångssätt vi behöver ta. Att lägga till en LLM låter enkelt, men hur gör vi egentligen detta?

Så här kommer klienten att interagera med servern:

1. Upprätta anslutning med servern.

1. Lista funktioner, uppmaningar, resurser och verktyg, och spara deras schema.

1. Lägg till en LLM och överför de sparade funktionerna och deras schema i ett format som LLM förstår.

1. Hantera en användaruppmaning genom att skicka den till LLM tillsammans med de verktyg som listas av klienten.

Bra, nu förstår vi hur vi kan göra detta på en hög nivå, låt oss prova detta i övningen nedan.

## Övning: Skapa en klient med en LLM

I denna övning kommer vi att lära oss att lägga till en LLM till vår klient.

### -1- Anslut till servern

Låt oss först skapa vår klient:
Du är tränad på data fram till oktober 2023.

Bra, för vårt nästa steg, låt oss lista funktionerna på servern.

### -2 Lista serverfunktioner

Nu kommer vi att ansluta till servern och be om dess funktioner:

### -3- Konvertera serverfunktioner till LLM-verktyg

Nästa steg efter att ha listat serverfunktioner är att konvertera dem till ett format som LLM förstår. När vi gör det kan vi tillhandahålla dessa funktioner som verktyg till vår LLM.

Bra, vi är nu redo att hantera alla användarförfrågningar, så låt oss ta itu med det nästa.

### -4- Hantera användaruppmaning

I den här delen av koden kommer vi att hantera användarförfrågningar.

Bra, du gjorde det!

## Uppgift

Ta koden från övningen och bygg ut servern med några fler verktyg. Skapa sedan en klient med en LLM, som i övningen, och testa den med olika uppmaningar för att säkerställa att alla dina serververktyg anropas dynamiskt. Detta sätt att bygga en klient innebär att slutanvändaren får en fantastisk användarupplevelse eftersom de kan använda uppmaningar istället för exakta klientkommandon och vara omedvetna om att någon MCP-server anropas.

## Lösning 

[Lösning](/03-GettingStarted/03-llm-client/solution/README.md)

## Viktiga insikter

- Att lägga till en LLM till din klient ger ett bättre sätt för användare att interagera med MCP-servrar.
- Du behöver konvertera MCP-serverns svar till något som LLM kan förstå.

## Exempel 

- [Java Kalkylator](../samples/java/calculator/README.md)
- [.Net Kalkylator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkylator](../samples/javascript/README.md)
- [TypeScript Kalkylator](../samples/typescript/README.md)
- [Python Kalkylator](../../../../03-GettingStarted/samples/python) 

## Ytterligare resurser

## Vad är nästa

- Nästa: [Konsumera en server med Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen notera att automatiserade översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess originalspråk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller misstolkningar som uppstår från användningen av denna översättning.