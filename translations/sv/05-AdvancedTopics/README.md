<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a5c1d9e9856024d23da4a65a847c75ac",
  "translation_date": "2025-07-18T07:17:28+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sv"
}
-->
# Avancerade ämnen inom MCP

Detta kapitel täcker en rad avancerade ämnen inom implementering av Model Context Protocol (MCP), inklusive multimodal integration, skalbarhet, säkerhetsbästa praxis och företagsintegration. Dessa ämnen är avgörande för att bygga robusta och produktionsklara MCP-applikationer som kan möta kraven från moderna AI-system.

## Översikt

Denna lektion utforskar avancerade koncept inom implementering av Model Context Protocol, med fokus på multimodal integration, skalbarhet, säkerhetsbästa praxis och företagsintegration. Dessa ämnen är viktiga för att skapa produktionsfärdiga MCP-applikationer som kan hantera komplexa krav i företagsmiljöer.

## Lärandemål

Efter denna lektion kommer du att kunna:

- Implementera multimodala funktioner inom MCP-ramverk
- Designa skalbara MCP-arkitekturer för högbelastade scenarier
- Tillämpa säkerhetsbästa praxis i linje med MCP:s säkerhetsprinciper
- Integrera MCP med företags-AI-system och ramverk
- Optimera prestanda och tillförlitlighet i produktionsmiljöer

## Lektioner och exempelprojekt

| Länk | Titel | Beskrivning |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrera med Azure | Lär dig hur du integrerar din MCP-server på Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP multimodala exempel | Exempel för ljud, bild och multimodala svar |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2-demo | Minimal Spring Boot-app som visar OAuth2 med MCP, både som auktoriserings- och resurserver. Demonstrerar säker tokenutfärdelse, skyddade slutpunkter, distribution på Azure Container Apps och integration med API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Lär dig mer om root context och hur du implementerar dem |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Lär dig olika typer av routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lär dig hur du arbetar med sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalning | Lär dig om skalning |
| [5.8 Security](./mcp-security/README.md) | Säkerhet | Säkra din MCP-server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server och klient som integrerar med SerpAPI för realtidswebb-, nyhets-, produkt-sökning och Q&A. Visar multi-verktygsorkestrering, extern API-integration och robust felhantering. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Realtidsdataströmning har blivit avgörande i dagens datadrivna värld, där företag och applikationer kräver omedelbar tillgång till information för att fatta snabba beslut. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Realtidswebbsökning – hur MCP förändrar realtidswebbsökning genom att erbjuda en standardiserad metod för kontexthantering över AI-modeller, sökmotorer och applikationer. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authentication | Microsoft Entra ID erbjuder en robust molnbaserad lösning för identitets- och åtkomsthantering, som säkerställer att endast auktoriserade användare och applikationer kan interagera med din MCP-server. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry Integration | Lär dig hur du integrerar Model Context Protocol-servrar med Azure AI Foundry-agenter, vilket möjliggör kraftfull verktygsorkestrering och företags-AI-funktioner med standardiserade anslutningar till externa datakällor. |
| [5.14 Context Engineering](./mcp-contextengineering/README.md) | Context Engineering | Framtida möjligheter med context engineering-tekniker för MCP-servrar, inklusive kontextoptimering, dynamisk kontexthantering och strategier för effektiv prompt engineering inom MCP-ramverk. |

## Ytterligare referenser

För den mest aktuella informationen om avancerade MCP-ämnen, se:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Viktiga insikter

- Multimodala MCP-implementationer utökar AI:s kapacitet bortom textbearbetning
- Skalbarhet är avgörande för företagsdistributioner och kan hanteras genom horisontell och vertikal skalning
- Omfattande säkerhetsåtgärder skyddar data och säkerställer korrekt åtkomstkontroll
- Företagsintegration med plattformar som Azure OpenAI och Microsoft AI Foundry förbättrar MCP:s möjligheter
- Avancerade MCP-implementationer gynnas av optimerade arkitekturer och noggrann resursförvaltning

## Övning

Designa en företagsklassad MCP-implementation för ett specifikt användningsfall:

1. Identifiera multimodala krav för ditt användningsfall
2. Skissera säkerhetskontroller som behövs för att skydda känslig data
3. Designa en skalbar arkitektur som kan hantera varierande belastning
4. Planera integrationspunkter med företags-AI-system
5. Dokumentera potentiella prestandaflaskhalsar och strategier för att hantera dem

## Ytterligare resurser

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Vad händer härnäst

- [5.1 MCP Integration](./mcp-integration/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.