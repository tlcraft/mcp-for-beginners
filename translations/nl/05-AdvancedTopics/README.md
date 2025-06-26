<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:08:53+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "nl"
}
-->
# Geavanceerde Onderwerpen in MCP

Dit hoofdstuk behandelt een reeks geavanceerde onderwerpen in de implementatie van het Model Context Protocol (MCP), waaronder multimodale integratie, schaalbaarheid, beste beveiligingspraktijken en enterprise-integratie. Deze onderwerpen zijn essentieel voor het bouwen van robuuste en productieklare MCP-toepassingen die voldoen aan de eisen van moderne AI-systemen.

## Overzicht

Deze les verkent geavanceerde concepten in de implementatie van het Model Context Protocol, met de focus op multimodale integratie, schaalbaarheid, beste beveiligingspraktijken en enterprise-integratie. Deze onderwerpen zijn onmisbaar voor het bouwen van productieklare MCP-toepassingen die complexe eisen in bedrijfsomgevingen aankunnen.

## Leerdoelen

Aan het einde van deze les kun je:

- Multimodale functionaliteiten implementeren binnen MCP-frameworks
- Schaalbare MCP-architecturen ontwerpen voor scenario’s met hoge vraag
- Beveiligingsbest practices toepassen die aansluiten bij de beveiligingsprincipes van MCP
- MCP integreren met enterprise AI-systemen en -frameworks
- Prestaties en betrouwbaarheid optimaliseren in productieomgevingen

## Lessen en voorbeeldprojecten

| Link | Titel | Beschrijving |
|------|-------|--------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integratie met Azure | Leer hoe je je MCP-server integreert op Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multimodale voorbeelden | Voorbeelden voor audio-, beeld- en multimodale respons |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimale Spring Boot-app die OAuth2 toont met MCP, zowel als Authorization als Resource Server. Demonstreert veilige tokenuitgifte, beveiligde endpoints, Azure Container Apps-implementatie en API Management-integratie. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Leer meer over root contexten en hoe je deze implementeert |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Leer over verschillende soorten routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Leer hoe je met sampling werkt |
| [5.7 Scaling](./mcp-scaling/README.md) | Schalen | Leer meer over schalen |
| [5.8 Security](./mcp-security/README.md) | Beveiliging | Beveilig je MCP-server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server en client die integreren met SerpAPI voor real-time web-, nieuws-, productzoekopdrachten en Q&A. Demonstreert multi-tool orchestratie, externe API-integratie en robuuste foutafhandeling. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Real-time datastreaming is tegenwoordig essentieel in een data-gedreven wereld, waar bedrijven en applicaties directe toegang tot informatie nodig hebben om tijdig beslissingen te kunnen nemen. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Real-time websearch: hoe MCP real-time websearch transformeert door een gestandaardiseerde aanpak te bieden voor contextbeheer tussen AI-modellen, zoekmachines en applicaties. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authenticatie | Microsoft Entra ID biedt een robuuste cloudgebaseerde identiteit- en toegangsbeheeroplossing, waarmee wordt gegarandeerd dat alleen geautoriseerde gebruikers en applicaties met je MCP-server kunnen communiceren. |

## Aanvullende Referenties

Voor de meest actuele informatie over geavanceerde MCP-onderwerpen, raadpleeg:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Belangrijkste Leerpunten

- Multimodale MCP-implementaties breiden AI-mogelijkheden uit voorbij tekstverwerking
- Schaalbaarheid is cruciaal voor enterprise-implementaties en kan worden bereikt via horizontaal en verticaal schalen
- Uitgebreide beveiligingsmaatregelen beschermen data en zorgen voor juiste toegangscontrole
- Enterprise-integratie met platforms zoals Azure OpenAI en Microsoft AI Foundry versterkt MCP-mogelijkheden
- Geavanceerde MCP-implementaties profiteren van geoptimaliseerde architecturen en zorgvuldig resourcebeheer

## Oefening

Ontwerp een enterprise-grade MCP-implementatie voor een specifieke use case:

1. Identificeer multimodale vereisten voor je use case  
2. Schets de beveiligingsmaatregelen die nodig zijn om gevoelige data te beschermen  
3. Ontwerp een schaalbare architectuur die verschillende belasting aankan  
4. Plan integratiepunten met enterprise AI-systemen  
5. Documenteer mogelijke prestatieknelpunten en strategieën om deze te verhelpen

## Aanvullende Bronnen

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Wat volgt

- [5.1 MCP Integration](./mcp-integration/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.