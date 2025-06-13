<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-13T00:04:14+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "sv"
}
-->
## Distribuerad Arkitektur

Distribuerade arkitekturer innebär att flera MCP-noder samarbetar för att hantera förfrågningar, dela resurser och erbjuda redundans. Denna metod förbättrar skalbarhet och feltolerans genom att noder kan kommunicera och samordna via ett distribuerat system.

Låt oss titta på ett exempel på hur man implementerar en distribuerad MCP-serverarkitektur med Redis för samordning.

## Vad händer härnäst

- [5.8 Security](../mcp-security/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.