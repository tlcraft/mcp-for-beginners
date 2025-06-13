<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:32:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sv"
}
-->
Fantastiskt, för vårt nästa steg, låt oss lista kapabiliteterna på servern.

### -2 Lista serverns kapabiliteter

Nu kommer vi att ansluta till servern och fråga efter dess kapabiliteter:

### -3- Konvertera serverkapabiliteter till LLM-verktyg

Nästa steg efter att ha listat serverns kapabiliteter är att omvandla dem till ett format som LLM förstår. När vi gjort det kan vi tillhandahålla dessa kapabiliteter som verktyg till vår LLM.

Fantastiskt, vi är nu redo att hantera användarförfrågningar, så låt oss ta itu med det härnäst.

### -4- Hantera användarens promptförfrågan

I den här delen av koden kommer vi att hantera användarens förfrågningar.

Bra jobbat, du klarade det!

## Uppgift

Ta koden från övningen och bygg ut servern med fler verktyg. Skapa sedan en klient med en LLM, som i övningen, och testa med olika prompts för att säkerställa att alla dina serververktyg anropas dynamiskt. Detta sätt att bygga en klient ger slutkunden en bättre användarupplevelse eftersom de kan använda prompts istället för exakta klientkommandon och slippa bry sig om att någon MCP-server anropas.

## Lösning

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Viktiga insikter

- Att lägga till en LLM i din klient ger ett bättre sätt för användare att interagera med MCP-servrar.
- Du behöver konvertera MCP-serverns svar till något som LLM kan förstå.

## Exempel

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ytterligare resurser

## Vad händer härnäst

- Nästa: [Använda en server med Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.