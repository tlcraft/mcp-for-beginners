<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:42:44+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "nl"
}
-->
# Een client maken

Clients zijn aangepaste applicaties of scripts die direct communiceren met een MCP Server om bronnen, tools en prompts aan te vragen. In tegenstelling tot het gebruik van de inspector tool, die een grafische interface biedt voor interactie met de server, stelt het schrijven van je eigen client je in staat om programmatische en geautomatiseerde interacties uit te voeren. Dit stelt ontwikkelaars in staat om MCP-functionaliteiten te integreren in hun eigen workflows, taken te automatiseren en aangepaste oplossingen te bouwen die zijn afgestemd op specifieke behoeften.

## Overzicht

Deze les introduceert het concept van clients binnen het Model Context Protocol (MCP) ecosysteem. Je leert hoe je je eigen client kunt schrijven en deze kunt verbinden met een MCP Server.

## Leerdoelen

Aan het einde van deze les kun je:

- Begrijpen wat een client kan doen.
- Je eigen client schrijven.
- De client verbinden en testen met een MCP-server om ervoor te zorgen dat deze werkt zoals verwacht.

## Wat komt er kijken bij het schrijven van een client?

Om een client te schrijven, moet je het volgende doen:

- **Importeer de juiste bibliotheken**. Je zult dezelfde bibliotheek gebruiken als voorheen, maar met andere constructies.
- **Instantieer een client**. Dit houdt in dat je een clientinstantie maakt en deze verbindt met de gekozen transportmethode.
- **Bepaal welke bronnen je wilt opsommen**. Je MCP-server wordt geleverd met bronnen, tools en prompts, je moet beslissen welke je wilt opsommen.
- **Integreer de client in een hostapplicatie**. Zodra je de mogelijkheden van de server kent, moet je deze integreren in je hostapplicatie zodat als een gebruiker een prompt of een andere opdracht typt, de overeenkomstige serverfunctie wordt aangeroepen.

Nu we op hoog niveau begrijpen wat we gaan doen, laten we eens kijken naar een voorbeeld.

### Een voorbeeldclient

Laten we eens kijken naar deze voorbeeldclient:
Je bent getraind op data tot oktober 2023.

In de bovenstaande code:

- Importeer je de bibliotheken
- Maak je een instantie van een client en verbind je deze met behulp van stdio voor transport.
- Som je prompts, bronnen en tools op en roep je ze allemaal aan.

Daar heb je het, een client die kan communiceren met een MCP Server.

Laten we de tijd nemen in de volgende oefening en elk codefragment opsplitsen en uitleggen wat er gebeurt.

## Oefening: Een client schrijven

Zoals hierboven gezegd, laten we de tijd nemen om de code uit te leggen, en codeer vooral mee als je wilt.

### -1- Importeer de bibliotheken

Laten we de bibliotheken importeren die we nodig hebben, we hebben referenties nodig naar een client en naar ons gekozen transportprotocol, stdio. stdio is een protocol voor dingen die bedoeld zijn om op je lokale machine te draaien. SSE is een ander transportprotocol dat we in toekomstige hoofdstukken zullen laten zien, maar dat is je andere optie. Voor nu gaan we echter verder met stdio.

Laten we doorgaan naar de instantie.

### -2- Client en transport instantiëren

We moeten een instantie van het transport en die van onze client maken:

### -3- De serverfuncties opsommen

Nu hebben we een client die verbinding kan maken als het programma wordt uitgevoerd. Echter, het somt zijn functies niet echt op, dus laten we dat als volgende doen:

Geweldig, nu hebben we alle functies vastgelegd. Nu is de vraag wanneer we ze gebruiken? Welnu, deze client is vrij eenvoudig, eenvoudig in de zin dat we de functies expliciet moeten aanroepen wanneer we ze willen. In het volgende hoofdstuk maken we een meer geavanceerde client die toegang heeft tot zijn eigen grote taalmodel, LLM. Voor nu, laten we eens kijken hoe we de functies op de server kunnen aanroepen:

### -4- Functies aanroepen

Om de functies aan te roepen, moeten we ervoor zorgen dat we de juiste argumenten specificeren en in sommige gevallen de naam van wat we proberen aan te roepen.

### -5- De client uitvoeren

Om de client uit te voeren, typ je de volgende opdracht in de terminal:

## Opdracht

In deze opdracht gebruik je wat je hebt geleerd bij het maken van een client, maar maak je een eigen client.

Hier is een server die je kunt gebruiken en die je moet aanroepen via je clientcode, kijk of je meer functies aan de server kunt toevoegen om het interessanter te maken.

## Oplossing

[Oplossing](./solution/README.md)

## Belangrijkste inzichten

De belangrijkste inzichten voor dit hoofdstuk over clients zijn:

- Kunnen worden gebruikt om zowel functies op de server te ontdekken als aan te roepen.
- Kunnen een server starten terwijl het zichzelf start (zoals in dit hoofdstuk), maar clients kunnen ook verbinding maken met draaiende servers.
- Is een geweldige manier om servermogelijkheden uit te testen naast alternatieven zoals de Inspector zoals beschreven in het vorige hoofdstuk.

## Aanvullende bronnen

- [Clients bouwen in MCP](https://modelcontextprotocol.io/quickstart/client)

## Voorbeelden 

- [Java Rekenmachine](../samples/java/calculator/README.md)
- [.Net Rekenmachine](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Rekenmachine](../samples/javascript/README.md)
- [TypeScript Rekenmachine](../samples/typescript/README.md)
- [Python Rekenmachine](../../../../03-GettingStarted/samples/python) 

## Wat is het volgende

- Volgende: [Een client maken met een LLM](/03-GettingStarted/03-llm-client/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.