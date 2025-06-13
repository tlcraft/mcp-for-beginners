<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:48:21+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "nl"
}
-->
In de vorige code hebben we:

- De bibliotheken geïmporteerd
- Een instantie van een client aangemaakt en verbonden via stdio als transport.
- Prompts, resources en tools opgesomd en ze allemaal aangeroepen.

Daar heb je het, een client die kan communiceren met een MCP Server.

Laten we in de volgende oefensectie de tijd nemen om elk stukje code te ontleden en uit te leggen wat er gebeurt.

## Oefening: Een client schrijven

Zoals hierboven gezegd, nemen we de tijd om de code uit te leggen, en voel je vrij om mee te coderen als je dat wilt.

### -1- Bibliotheken importeren

Laten we de benodigde bibliotheken importeren, we hebben referenties nodig naar een client en naar ons gekozen transportprotocol, stdio. stdio is een protocol voor dingen die bedoeld zijn om op je lokale machine te draaien. SSE is een ander transportprotocol dat we in toekomstige hoofdstukken zullen laten zien, maar dat is je andere optie. Voor nu gaan we door met stdio.

Laten we doorgaan met het aanmaken van de instantie.

### -2- Client en transport instantieren

We moeten een instantie van het transport maken en die van onze client:

### -3- Serverfuncties opsommen

Nu hebben we een client die verbinding kan maken zodra het programma wordt uitgevoerd. Maar het somt zijn functies nog niet op, dus laten we dat nu doen:

Geweldig, nu hebben we alle functies vastgelegd. De vraag is: wanneer gebruiken we ze? Deze client is vrij eenvoudig, eenvoudig in de zin dat we de functies expliciet moeten aanroepen wanneer we ze willen gebruiken. In het volgende hoofdstuk maken we een geavanceerdere client die toegang heeft tot zijn eigen grote taalmodel, LLM. Voor nu bekijken we hoe we de functies op de server kunnen aanroepen:

### -4- Functies aanroepen

Om de functies aan te roepen moeten we ervoor zorgen dat we de juiste argumenten specificeren en in sommige gevallen de naam van wat we proberen aan te roepen.

### -5- De client uitvoeren

Om de client uit te voeren, typ je het volgende commando in de terminal:

## Opdracht

In deze opdracht ga je gebruiken wat je hebt geleerd over het maken van een client, maar maak je een client helemaal zelf.

Hier is een server die je kunt gebruiken en die je via je clientcode moet aanroepen. Kijk of je meer functies aan de server kunt toevoegen om het interessanter te maken.

## Oplossing

[Oplossing](./solution/README.md)

## Belangrijkste punten

De belangrijkste punten van dit hoofdstuk over clients zijn:

- Ze kunnen gebruikt worden om zowel functies op de server te ontdekken als aan te roepen.
- Ze kunnen een server starten terwijl ze zelf starten (zoals in dit hoofdstuk), maar clients kunnen ook verbinding maken met reeds draaiende servers.
- Het is een uitstekende manier om servermogelijkheden te testen naast alternatieven zoals de Inspector, zoals in het vorige hoofdstuk beschreven.

## Aanvullende bronnen

- [Clients bouwen in MCP](https://modelcontextprotocol.io/quickstart/client)

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Wat is de volgende stap

- Volgend: [Een client maken met een LLM](/03-GettingStarted/03-llm-client/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.