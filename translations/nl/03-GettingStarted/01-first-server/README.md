<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:37:42+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "nl"
}
-->
### -2- Maak een project aan

Nu je de SDK hebt geïnstalleerd, gaan we een project aanmaken:

### -3- Maak projectbestanden aan

### -4- Maak de servercode aan

### -5- Een tool en een resource toevoegen

Voeg een tool en een resource toe door de volgende code toe te voegen:

### -6- Volledige code

Laten we de laatste code toevoegen die nodig is zodat de server kan starten:

### -7- Test de server

Start de server met het volgende commando:

### -8- Gebruik de inspector

De inspector is een geweldig hulpmiddel dat je server kan opstarten en waarmee je kunt interacteren om te testen of alles werkt. Laten we hem starten:

> [!NOTE]
> Het kan er anders uitzien in het "command" veld omdat het commando het draaien van een server met jouw specifieke runtime bevat.

Je zou de volgende gebruikersinterface moeten zien:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.nl.png)

1. Verbind met de server door op de knop Connect te klikken. 
   Zodra je verbonden bent, zou je het volgende moeten zien:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.nl.png)

2. Selecteer "Tools" en vervolgens "listTools", je zou "Add" moeten zien verschijnen. Selecteer "Add" en vul de parameterwaarden in.

   Je zou de volgende respons moeten zien, dit is het resultaat van de "add" tool:

   ![Resultaat van het uitvoeren van add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.nl.png)

Gefeliciteerd, je hebt je eerste server gemaakt en succesvol draaien!

### Officiële SDK's

MCP biedt officiële SDK's voor meerdere talen:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Onderhouden in samenwerking met Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Onderhouden in samenwerking met Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - De officiële TypeScript-implementatie
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - De officiële Python-implementatie
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - De officiële Kotlin-implementatie
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Onderhouden in samenwerking met Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - De officiële Rust-implementatie

## Belangrijke punten

- Het opzetten van een MCP-ontwikkelomgeving is eenvoudig met taalspecifieke SDK's
- Het bouwen van MCP-servers omvat het creëren en registreren van tools met duidelijke schema's
- Testen en debuggen zijn essentieel voor betrouwbare MCP-implementaties

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Opdracht

Maak een eenvoudige MCP-server met een tool naar keuze:
1. Implementeer de tool in jouw favoriete taal (.NET, Java, Python of JavaScript).
2. Definieer invoerparameters en retourwaarden.
3. Gebruik de inspector om te controleren of de server werkt zoals bedoeld.
4. Test de implementatie met verschillende invoerwaarden.

## Oplossing

[Oplossing](./solution/README.md)

## Extra bronnen

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Wat nu?

Volgende stap: [Aan de slag met MCP Clients](/03-GettingStarted/02-client/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.