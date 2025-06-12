<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:57:06+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "nl"
}
-->
# Gevorderde onderwerpen in MCP

Dit hoofdstuk behandelt een reeks gevorderde onderwerpen in de implementatie van het Model Context Protocol (MCP), waaronder multi-modale integratie, schaalbaarheid, beste beveiligingspraktijken en integratie binnen ondernemingen. Deze onderwerpen zijn cruciaal voor het bouwen van robuuste en productieklaar MCP-toepassingen die voldoen aan de eisen van moderne AI-systemen.

## Overzicht

Deze les verkent gevorderde concepten in de implementatie van het Model Context Protocol, met de focus op multi-modale integratie, schaalbaarheid, beste beveiligingspraktijken en integratie binnen ondernemingen. Deze onderwerpen zijn essentieel voor het bouwen van productieklare MCP-toepassingen die complexe eisen in zakelijke omgevingen aankunnen.

## Leerdoelen

Aan het einde van deze les kun je:

- Multi-modale mogelijkheden binnen MCP-frameworks implementeren
- Schaalbare MCP-architecturen ontwerpen voor scenario’s met hoge vraag
- Beveiligingsbest practices toepassen die aansluiten bij de beveiligingsprincipes van MCP
- MCP integreren met AI-systemen en frameworks binnen ondernemingen
- Prestaties en betrouwbaarheid optimaliseren in productieomgevingen

## Lessen en voorbeeldprojecten

| Link | Titel | Beschrijving |
|------|-------|--------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integratie met Azure | Leer hoe je je MCP Server op Azure integreert |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi-modale voorbeelden | Voorbeelden voor audio, beeld en multi-modale respons |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimalistische Spring Boot-app die OAuth2 met MCP toont, zowel als Authorization als Resource Server. Laat zien hoe je veilige tokenuitgifte, beveiligde endpoints, Azure Container Apps-deployments en API Management-integratie uitvoert. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Leer meer over root contexts en hoe je ze implementeert |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Leer over verschillende soorten routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Leer hoe je met sampling werkt |
| [5.7 Scaling](./mcp-scaling/README.md) | Schalen | Leer over schaalbaarheid |
| [5.8 Security](./mcp-security/README.md) | Beveiliging | Beveilig je MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server en client die integreert met SerpAPI voor realtime web-, nieuws-, productzoekopdrachten en Q&A. Toont multi-tool orchestratie, integratie van externe API’s en robuuste foutafhandeling. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Realtime datastreaming is essentieel geworden in de hedendaagse datagedreven wereld, waar bedrijven en applicaties directe toegang tot informatie nodig hebben om tijdig beslissingen te nemen. |

## Aanvullende referenties

Voor de meest actuele informatie over gevorderde MCP-onderwerpen, raadpleeg:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Belangrijkste punten

- Multi-modale MCP-implementaties breiden AI-mogelijkheden uit voorbij tekstverwerking
- Schaalbaarheid is essentieel voor zakelijke implementaties en kan worden bereikt via horizontale en verticale schaalvergroting
- Uitgebreide beveiligingsmaatregelen beschermen data en zorgen voor juiste toegangscontrole
- Integratie binnen ondernemingen met platforms zoals Azure OpenAI en Microsoft AI Foundry versterkt MCP-mogelijkheden
- Gevorderde MCP-implementaties profiteren van geoptimaliseerde architecturen en zorgvuldig resourcebeheer

## Oefening

Ontwerp een MCP-implementatie op ondernemingsniveau voor een specifieke use case:

1. Identificeer de multi-modale vereisten voor je use case
2. Schets de beveiligingsmaatregelen die nodig zijn om gevoelige data te beschermen
3. Ontwerp een schaalbare architectuur die variërende belasting aankan
4. Plan integratiepunten met enterprise AI-systemen
5. Documenteer mogelijke prestatieknelpunten en strategieën om deze te verminderen

## Aanvullende bronnen

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Wat volgt

- [5.1 MCP Integration](./mcp-integration/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.