<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T09:11:41+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "nl"
}
-->
# Complete MCP Client Voorbeelden

Deze map bevat complete, werkende voorbeelden van MCP-clients in verschillende programmeertalen. Elke client toont de volledige functionaliteit zoals beschreven in de hoofd README.md tutorial.

## Beschikbare Clients

### 1. Java Client (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) via HTTP
- **Doelserver**: `http://localhost:8080`
- **Kenmerken**: 
  - Verbinding maken en ping
  - Lijst van tools
  - Rekenmachinebewerkingen (optellen, aftrekken, vermenigvuldigen, delen, help)
  - Foutafhandeling en resultaatextractie

**Om te starten:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Client (`client_example_csharp.cs`)
- **Transport**: Stdio (Standaard Invoer/Uitvoer)
- **Doelserver**: Lokale .NET MCP-server via dotnet run
- **Kenmerken**:
  - Automatisch opstarten van server via stdio transport
  - Lijst van tools en resources
  - Rekenmachinebewerkingen
  - JSON-resultaat parsing
  - Uitgebreide foutafhandeling

**Om te starten:**
```bash
dotnet run
```

### 3. TypeScript Client (`client_example_typescript.ts`)
- **Transport**: Stdio (Standaard Invoer/Uitvoer)
- **Doelserver**: Lokale Node.js MCP-server
- **Kenmerken**:
  - Volledige ondersteuning van het MCP-protocol
  - Tool-, resource- en promptbewerkingen
  - Rekenmachinebewerkingen
  - Resource lezen en prompt uitvoeren
  - Robuuste foutafhandeling

**Om te starten:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Client (`client_example_python.py`)
- **Transport**: Stdio (Standaard Invoer/Uitvoer)  
- **Doelserver**: Lokale Python MCP-server
- **Kenmerken**:
  - Async/await patroon voor bewerkingen
  - Tool- en resource-ontdekking
  - Testen van rekenmachinebewerkingen
  - Lezen van resource-inhoud
  - Klassen-gebaseerde organisatie

**Om te starten:**
```bash
python client_example_python.py
```

## Gemeenschappelijke Kenmerken van Alle Clients

Elke clientimplementatie laat zien:

1. **Verbindingsbeheer**
   - Verbinding maken met MCP-server
   - Afhandelen van verbindingsfouten
   - Correct opruimen en resourcebeheer

2. **Serverontdekking**
   - Lijst van beschikbare tools
   - Lijst van beschikbare resources (indien ondersteund)
   - Lijst van beschikbare prompts (indien ondersteund)

3. **Tool-aanroep**
   - Basis rekenmachinebewerkingen (optellen, aftrekken, vermenigvuldigen, delen)
   - Help-commando voor serverinformatie
   - Correct doorgeven van argumenten en afhandelen van resultaten

4. **Foutafhandeling**
   - Verbindingsfouten
   - Fouten bij tooluitvoering
   - Vriendelijke foutafhandeling en feedback aan gebruiker

5. **Resultaatverwerking**
   - Extractie van tekstinhoud uit reacties
   - Opmaak van output voor leesbaarheid
   - Afhandeling van verschillende antwoordformaten

## Vereisten

Voordat je deze clients gebruikt, zorg dat je:

1. **De bijbehorende MCP-server draait** (uit `../01-first-server/`)
2. **Benodigde dependencies geïnstalleerd** hebt voor je gekozen taal
3. **Goede netwerkverbinding** hebt (voor HTTP-gebaseerde transports)

## Belangrijkste Verschillen Tussen Implementaties

| Taal       | Transport | Server Opstarten | Async Model | Belangrijke Bibliotheken |
|------------|-----------|------------------|-------------|-------------------------|
| Java       | SSE/HTTP  | Extern           | Synchroon   | WebFlux, MCP SDK        |
| C#         | Stdio     | Automatisch      | Async/Await | .NET MCP SDK            |
| TypeScript | Stdio     | Automatisch      | Async/Await | Node MCP SDK            |
| Python     | Stdio     | Automatisch      | AsyncIO     | Python MCP SDK          |

## Volgende Stappen

Na het verkennen van deze clientvoorbeelden:

1. **Pas de clients aan** om nieuwe functies of bewerkingen toe te voegen
2. **Maak je eigen server** en test deze met deze clients
3. **Experimenteer met verschillende transports** (SSE vs. Stdio)
4. **Bouw een complexere applicatie** die MCP-functionaliteit integreert

## Probleemoplossing

### Veelvoorkomende Problemen

1. **Verbinding geweigerd**: Controleer of de MCP-server draait op de verwachte poort/pad
2. **Module niet gevonden**: Installeer de benodigde MCP SDK voor je taal
3. **Toegang geweigerd**: Controleer bestandsrechten voor stdio transport
4. **Tool niet gevonden**: Controleer of de server de verwachte tools implementeert

### Debug Tips

1. **Schakel uitgebreide logging in** in je MCP SDK
2. **Controleer serverlogs** op foutmeldingen
3. **Controleer of toolnamen en handtekeningen** overeenkomen tussen client en server
4. **Test eerst met MCP Inspector** om serverfunctionaliteit te valideren

## Gerelateerde Documentatie

- [Main Client Tutorial](./README.md)
- [MCP Server Examples](../../../../03-GettingStarted/01-first-server)
- [MCP with LLM Integration](../../../../03-GettingStarted/03-llm-client)
- [Official MCP Documentation](https://modelcontextprotocol.io/)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.