<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:18:49+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "nl"
}
-->
Nu we wat meer weten over SSE, laten we als volgende een SSE-server bouwen.

## Oefening: Een SSE-server maken

Om onze server te maken, moeten we twee dingen in gedachten houden:

- We moeten een webserver gebruiken om eindpunten bloot te stellen voor verbinding en berichten.
- Bouw onze server zoals we normaal doen met tools, bronnen en prompts, zoals we deden bij het gebruik van stdio.

### -1- Maak een serverinstance aan

Om onze server te maken, gebruiken we dezelfde types als bij stdio. Voor het transport moeten we echter SSE kiezen.

Laten we nu de benodigde routes toevoegen.

### -2- Routes toevoegen

Laten we routes toevoegen die de verbinding en binnenkomende berichten afhandelen:

Laten we nu functionaliteiten aan de server toevoegen.

### -3- Serverfunctionaliteiten toevoegen

Nu we alles wat specifiek is voor SSE hebben gedefinieerd, voegen we serverfunctionaliteiten toe zoals tools, prompts en bronnen.

Je volledige code zou er als volgt uit moeten zien:

Geweldig, we hebben een server met SSE, laten we die nu eens uitproberen.

## Oefening: Een SSE-server debuggen met Inspector

Inspector is een geweldige tool die we al zagen in een vorige les [Je eerste server maken](/03-GettingStarted/01-first-server/README.md). Laten we kijken of we de Inspector ook hier kunnen gebruiken:

### -1- De inspector starten

Om de inspector te starten, moet je eerst een SSE-server draaien, dus laten we dat eerst doen:

1. Start de server

1. Start de inspector

    > ![NOTE]
    > Voer dit uit in een apart terminalvenster dan waar de server draait. Let ook op dat je de onderstaande opdracht moet aanpassen aan de URL waar jouw server draait.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Het starten van de inspector ziet er in alle runtimes hetzelfde uit. Let erop dat we in plaats van een pad naar onze server en een opdracht om de server te starten, nu de URL doorgeven waar de server draait en ook de `/sse` route specificeren.

### -2- De tool uitproberen

Verbind met de server door in de keuzelijst SSE te selecteren en vul het URL-veld in met de locatie waar je server draait, bijvoorbeeld http://localhost:4321/sse. Klik daarna op de knop "Connect". Zoals eerder, selecteer je een lijst met tools, kies je een tool en geef je invoerwaarden op. Je zou een resultaat zoals hieronder moeten zien:

![SSE-server draait in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.nl.png)

Geweldig, je kunt met de inspector werken, laten we nu kijken hoe je met Visual Studio Code kunt werken.

## Opdracht

Probeer je server uit te breiden met meer functionaliteiten. Bekijk [deze pagina](https://api.chucknorris.io/) om bijvoorbeeld een tool toe te voegen die een API aanroept. Jij bepaalt hoe de server eruit moet zien. Veel plezier :)

## Oplossing

[Oplossing](./solution/README.md) Hier is een mogelijke oplossing met werkende code.

## Belangrijkste punten

De belangrijkste punten uit dit hoofdstuk zijn:

- SSE is het tweede ondersteunde transport naast stdio.
- Om SSE te ondersteunen, moet je binnenkomende verbindingen en berichten beheren met een webframework.
- Je kunt zowel Inspector als Visual Studio Code gebruiken om een SSE-server te gebruiken, net als bij stdio-servers. Let erop dat het iets anders werkt tussen stdio en SSE. Voor SSE moet je de server apart starten en daarna je inspectietool draaien. Voor de inspectietool moet je ook de URL specificeren.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Aanvullende bronnen

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Wat volgt hierna

- Volgende: [HTTP Streaming met MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.