<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:38:43+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "nl"
}
-->
# Gevorderde Onderwerpen in MCP

Dit hoofdstuk behandelt een reeks gevorderde onderwerpen in de implementatie van het Model Context Protocol (MCP), waaronder multi-modale integratie, schaalbaarheid, beveiligingsrichtlijnen en integratie in ondernemingen. Deze onderwerpen zijn essentieel voor het bouwen van robuuste en productieklare MCP-toepassingen die voldoen aan de eisen van moderne AI-systemen.

## Overzicht

Deze les verkent geavanceerde concepten in de implementatie van het Model Context Protocol, met de nadruk op multi-modale integratie, schaalbaarheid, beveiligingsrichtlijnen en integratie binnen ondernemingen. Deze onderwerpen zijn cruciaal voor het ontwikkelen van productieklare MCP-applicaties die complexe eisen in zakelijke omgevingen aankunnen.

## Leerdoelen

Aan het einde van deze les kun je:

- Multi-modale mogelijkheden implementeren binnen MCP-frameworks
- Schaalbare MCP-architecturen ontwerpen voor scenario’s met hoge vraag
- Beveiligingsrichtlijnen toepassen die aansluiten bij de beveiligingsprincipes van MCP
- MCP integreren met AI-systemen en frameworks binnen ondernemingen
- Prestaties en betrouwbaarheid optimaliseren in productieomgevingen

## Lessen en voorbeeldprojecten

| Link | Titel | Beschrijving |
|------|-------|--------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integratie met Azure | Leer hoe je jouw MCP-server integreert op Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi-modale voorbeelden | Voorbeelden voor audio-, beeld- en multi-modale respons |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimale Spring Boot-app die OAuth2 met MCP laat zien, zowel als Authorization als Resource Server. Demonstreert veilige tokenuitgifte, beschermde endpoints, Azure Container Apps-implementatie en API Management-integratie. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root-contexten | Leer meer over root-contexten en hoe je ze implementeert |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Leer over verschillende soorten routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Leer hoe je met sampling werkt |
| [5.7 Scaling](./mcp-scaling/README.md) | Schalen | Leer over schalen |
| [5.8 Security](./mcp-security/README.md) | Beveiliging | Beveilig je MCP-server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server en client die integreren met SerpAPI voor real-time web-, nieuws-, productzoekopdrachten en Q&A. Demonstreert multi-tool orkestratie, externe API-integratie en robuuste foutafhandeling. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Real-time datastreaming is essentieel geworden in de huidige datagedreven wereld, waar bedrijven en applicaties directe toegang tot informatie nodig hebben om tijdig beslissingen te nemen. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Real-time webzoekopdrachten: hoe MCP real-time websearch transformeert door een gestandaardiseerde aanpak voor contextbeheer te bieden over AI-modellen, zoekmachines en applicaties heen. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authenticatie | Microsoft Entra ID biedt een robuuste cloudgebaseerde identiteits- en toegangsbeheeroplossing, waarmee wordt gegarandeerd dat alleen geautoriseerde gebruikers en applicaties met je MCP-server kunnen communiceren. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry Integratie | Leer hoe je Model Context Protocol-servers integreert met Azure AI Foundry-agents, wat krachtige toolorkestratie en enterprise AI-mogelijkheden mogelijk maakt met gestandaardiseerde verbindingen naar externe databronnen. |

## Aanvullende Referenties

Voor de meest actuele informatie over gevorderde MCP-onderwerpen, raadpleeg:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Belangrijkste Inzichten

- Multi-modale MCP-implementaties breiden AI-mogelijkheden uit voorbij alleen tekstverwerking
- Schaalbaarheid is essentieel voor bedrijfsimplementaties en kan worden bereikt via horizontale en verticale schaalvergroting
- Uitgebreide beveiligingsmaatregelen beschermen data en zorgen voor correcte toegangscontrole
- Integratie met platforms zoals Azure OpenAI en Microsoft AI Foundry versterkt de MCP-capaciteiten
- Geavanceerde MCP-implementaties profiteren van geoptimaliseerde architecturen en zorgvuldig resourcebeheer

## Oefening

Ontwerp een enterprise-grade MCP-implementatie voor een specifieke use case:

1. Bepaal de multi-modale vereisten voor jouw use case
2. Schets de beveiligingsmaatregelen die nodig zijn om gevoelige data te beschermen
3. Ontwerp een schaalbare architectuur die met wisselende belasting om kan gaan
4. Plan integratiepunten met enterprise AI-systemen
5. Documenteer mogelijke prestatieknelpunten en strategieën om deze te verhelpen

## Aanvullende Bronnen

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Wat volgt

- [5.1 MCP Integration](./mcp-integration/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal dient als de gezaghebbende bron te worden beschouwd. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.