<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:33:24+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "nl"
}
-->
Geweldig, voor onze volgende stap gaan we de mogelijkheden op de server opvragen.

### -2 Mogelijkheden van de server opvragen

Nu verbinden we met de server en vragen we naar zijn mogelijkheden:

### -3 Servermogelijkheden omzetten naar LLM-tools

De volgende stap na het opvragen van de servermogelijkheden is om deze om te zetten naar een formaat dat het LLM begrijpt. Zodra we dat gedaan hebben, kunnen we deze mogelijkheden als tools aan ons LLM aanbieden.

Geweldig, we zijn nu klaar om gebruikersverzoeken te verwerken, dus laten we dat als volgende aanpakken.

### -4 Verwerken van gebruikersprompt

In dit deel van de code gaan we gebruikersverzoeken afhandelen.

Geweldig, je hebt het gedaan!

## Opdracht

Neem de code uit de oefening en breid de server uit met meer tools. Maak daarna een client met een LLM, zoals in de oefening, en test het met verschillende prompts om zeker te zijn dat alle servertools dynamisch worden aangeroepen. Deze manier van een client bouwen zorgt voor een uitstekende gebruikerservaring, omdat gebruikers prompts kunnen gebruiken in plaats van exacte clientcommando's, zonder dat ze merken dat er een MCP-server wordt aangesproken.

## Oplossing

[Oplossing](/03-GettingStarted/03-llm-client/solution/README.md)

## Belangrijkste punten

- Het toevoegen van een LLM aan je client zorgt voor een betere manier voor gebruikers om met MCP-servers te communiceren.
- Je moet de reactie van de MCP-server omzetten naar iets wat het LLM kan begrijpen.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Extra bronnen

## Wat volgt

- Volgende: [Een server gebruiken met Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal geldt als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.