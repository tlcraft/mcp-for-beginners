<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:34:10+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "nl"
}
-->
Geweldig, voor onze volgende stap gaan we de mogelijkheden op de server opvragen.

### -2 Mogelijkheden van de server opvragen

Nu verbinden we met de server en vragen we naar de beschikbare mogelijkheden:

### -3- Servermogelijkheden omzetten naar LLM-tools

De volgende stap na het opvragen van de servermogelijkheden is om deze om te zetten naar een formaat dat de LLM begrijpt. Zodra we dat gedaan hebben, kunnen we deze mogelijkheden als tools aan onze LLM aanbieden.

Geweldig, we zijn nu klaar om gebruikersverzoeken te verwerken, dus laten we dat als volgende aanpakken.

### -4- Verwerking van gebruikersprompt

In dit deel van de code gaan we gebruikersverzoeken afhandelen.

Geweldig, je hebt het gedaan!

## Opdracht

Neem de code uit de oefening en breid de server uit met wat meer tools. Maak vervolgens een client met een LLM, zoals in de oefening, en test deze met verschillende prompts om te zorgen dat al je servertools dynamisch worden aangeroepen. Deze manier van een client bouwen zorgt voor een uitstekende gebruikerservaring, omdat gebruikers prompts kunnen gebruiken in plaats van exacte clientcommando's, zonder dat ze iets merken van het aanroepen van een MCP-server.

## Oplossing

[Oplossing](/03-GettingStarted/03-llm-client/solution/README.md)

## Belangrijkste punten

- Het toevoegen van een LLM aan je client biedt gebruikers een betere manier om met MCP-servers te communiceren.
- Je moet de respons van de MCP-server omzetten naar iets wat de LLM kan begrijpen.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Aanvullende bronnen

## Wat is de volgende stap

- Volgende: [Een server gebruiken met Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.