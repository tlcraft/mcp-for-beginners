<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:23:51+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "nl"
}
-->
# Een client maken met LLM

Tot nu toe heb je gezien hoe je een server en een client kunt maken. De client heeft de server expliciet kunnen aanroepen om zijn tools, resources en prompts op te sommen. Echter, dit is niet erg praktisch. Jouw gebruiker leeft in het agentische tijdperk en verwacht prompts te gebruiken en te communiceren met een LLM om dit te doen. Voor jouw gebruiker maakt het niet uit of je MCP gebruikt om je mogelijkheden op te slaan, maar ze verwachten wel dat ze natuurlijke taal kunnen gebruiken om te communiceren. Hoe lossen we dit op? De oplossing is het toevoegen van een LLM aan de client.

## Overzicht

In deze les richten we ons op het toevoegen van een LLM aan je client en laten we zien hoe dit een veel betere ervaring biedt voor je gebruiker.

## Leerdoelen

Aan het einde van deze les kun je:

- Een client maken met een LLM.
- Naadloos communiceren met een MCP-server met behulp van een LLM.
- Een betere eindgebruikerservaring bieden aan de clientzijde.

## Aanpak

Laten we proberen de aanpak te begrijpen die we moeten volgen. Het toevoegen van een LLM klinkt eenvoudig, maar gaan we dit echt doen?

Zo zal de client communiceren met de server:

1. Maak verbinding met de server.

1. Lijst mogelijkheden, prompts, resources en tools op, en sla hun schema op.

1. Voeg een LLM toe en geef de opgeslagen mogelijkheden en hun schema door in een formaat dat de LLM begrijpt.

1. Verwerk een gebruikersprompt door deze samen met de tools die door de client zijn opgesomd, door te geven aan de LLM.

Geweldig, nu we begrijpen hoe we dit op hoog niveau kunnen doen, laten we dit proberen in de onderstaande oefening.

## Oefening: Een client maken met een LLM

In deze oefening leren we een LLM aan onze client toe te voegen.

### -1- Verbinden met server

Laten we eerst onze client maken:
Je bent getraind op data tot oktober 2023.

Geweldig, voor onze volgende stap, laten we de mogelijkheden op de server opsommen.

### -2 Lijst servermogelijkheden op

Nu gaan we verbinding maken met de server en vragen naar zijn mogelijkheden:

### -3- Converteer servermogelijkheden naar LLM-tools

De volgende stap na het opsommen van servermogelijkheden is deze omzetten in een formaat dat de LLM begrijpt. Zodra we dat doen, kunnen we deze mogelijkheden als tools aan onze LLM geven.

Geweldig, we zijn nu klaar om gebruikersverzoeken te verwerken, dus laten we dat als volgende aanpakken.

### -4- Verwerk gebruikerspromptverzoek

In dit deel van de code gaan we gebruikersverzoeken verwerken.

Geweldig, je hebt het gedaan!

## Opdracht

Neem de code uit de oefening en bouw de server verder uit met meer tools. Maak vervolgens een client met een LLM, zoals in de oefening, en test het uit met verschillende prompts om ervoor te zorgen dat al je servertools dynamisch worden aangeroepen. Op deze manier van een client bouwen betekent dat de eindgebruiker een geweldige gebruikerservaring zal hebben omdat ze prompts kunnen gebruiken, in plaats van exacte clientcommando's, en zich niet bewust zijn van enige MCP-server die wordt aangeroepen.

## Oplossing

[Oplossing](/03-GettingStarted/03-llm-client/solution/README.md)

## Belangrijke Punten

- Het toevoegen van een LLM aan je client biedt een betere manier voor gebruikers om te communiceren met MCP-servers.
- Je moet de MCP-serverrespons omzetten in iets dat de LLM kan begrijpen.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Aanvullende Bronnen

## Wat Nu

- Volgende: [Een server gebruiken met Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.