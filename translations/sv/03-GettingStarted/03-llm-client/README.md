<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:52:36+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sv"
}
-->
Fantastiskt, för vårt nästa steg, låt oss lista kapabiliteterna på servern.

### -2 Lista serverns kapabiliteter

Nu kommer vi att ansluta till servern och fråga efter dess kapabiliteter:

### -3- Konvertera serverns kapabiliteter till LLM-verktyg

Nästa steg efter att ha listat serverns kapabiliteter är att konvertera dem till ett format som LLM förstår. När vi gjort det kan vi tillhandahålla dessa kapabiliteter som verktyg till vår LLM.

Fantastiskt, vi är nu redo att hantera användarförfrågningar, så låt oss ta itu med det nästa.

### -4- Hantera användarens promptförfrågan

I den här delen av koden kommer vi att hantera användarförfrågningar.

Fantastiskt, du klarade det!

## Uppgift

Ta koden från övningen och bygg ut servern med fler verktyg. Skapa sedan en klient med en LLM, som i övningen, och testa med olika prompts för att säkerställa att alla dina serververktyg anropas dynamiskt. Detta sätt att bygga en klient ger slutanvändaren en utmärkt användarupplevelse eftersom de kan använda prompts istället för exakta klientkommandon och vara omedvetna om att någon MCP-server anropas.

## Lösning

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Viktiga insikter

- Att lägga till en LLM till din klient ger ett bättre sätt för användare att interagera med MCP-servrar.
- Du behöver konvertera MCP-serverns svar till något som LLM kan förstå.

## Exempel

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ytterligare resurser

## Vad händer härnäst

- Nästa: [Använda en server med Visual Studio Code](../04-vscode/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål ska betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.