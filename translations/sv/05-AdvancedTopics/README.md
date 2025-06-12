<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:46:41+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sv"
}
-->
# Avancerade ämnen i MCP

Detta kapitel är avsett att täcka en rad avancerade ämnen inom implementering av Model Context Protocol (MCP), inklusive multimodal integration, skalbarhet, säkerhetsrutiner och företagsintegration. Dessa ämnen är avgörande för att bygga robusta och produktionsklara MCP-applikationer som kan möta kraven från moderna AI-system.

## Översikt

Den här lektionen utforskar avancerade koncept inom implementering av Model Context Protocol, med fokus på multimodal integration, skalbarhet, säkerhetsrutiner och företagsintegration. Dessa ämnen är viktiga för att bygga produktionsklara MCP-applikationer som kan hantera komplexa krav i företagsmiljöer.

## Lärandemål

I slutet av denna lektion kommer du att kunna:

- Implementera multimodala funktioner inom MCP-ramverk
- Designa skalbara MCP-arkitekturer för högbelastade scenarier
- Tillämpa säkerhetsrutiner i linje med MCP:s säkerhetsprinciper
- Integrera MCP med företags-AI-system och ramverk
- Optimera prestanda och tillförlitlighet i produktionsmiljöer

## Lektioner och exempelprojekt

| Länk | Titel | Beskrivning |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrera med Azure | Lär dig hur du integrerar din MCP-server på Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodala exempel | Exempel för ljud, bild och multimodala svar |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal Spring Boot-app som visar OAuth2 med MCP, både som Authorization och Resource Server. Demonstrerar säker tokenutfärdelse, skyddade endpoints, Azure Container Apps-distribution och API Management-integration. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Lär dig mer om root context och hur man implementerar dem |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Lär dig olika typer av routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lär dig hur man arbetar med sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalning | Lär dig om skalning |
| [5.8 Security](./mcp-security/README.md) | Säkerhet | Säkra din MCP-server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server och klient som integrerar med SerpAPI för realtidswebb-, nyhets-, produkt-sökning och Q&A. Visar multitool-orkestrering, extern API-integration och robust felhantering. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Realtidsdata-streaming har blivit avgörande i dagens datadrivna värld, där företag och applikationer behöver omedelbar tillgång till information för att fatta snabba beslut. |

## Ytterligare referenser

För den mest aktuella informationen om avancerade MCP-ämnen, se:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Viktiga punkter att ta med sig

- Multimodala MCP-implementationer utökar AI:s kapabiliteter bortom textbehandling
- Skalbarhet är avgörande för företagsdistributioner och kan hanteras genom horisontell och vertikal skalning
- Omfattande säkerhetsåtgärder skyddar data och säkerställer korrekt åtkomstkontroll
- Företagsintegration med plattformar som Azure OpenAI och Microsoft AI Foundry förbättrar MCP:s kapabiliteter
- Avancerade MCP-implementationer gynnas av optimerade arkitekturer och noggrann resurshantering

## Övning

Designa en företagsklassad MCP-implementation för ett specifikt användningsfall:

1. Identifiera multimodala krav för ditt användningsfall
2. Skissera säkerhetskontroller som behövs för att skydda känslig data
3. Designa en skalbar arkitektur som kan hantera varierande belastning
4. Planera integrationspunkter med företags-AI-system
5. Dokumentera potentiella prestandaflaskhalsar och strategier för att mildra dem

## Ytterligare resurser

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Vad händer härnäst

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess ursprungsspråk ska betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.