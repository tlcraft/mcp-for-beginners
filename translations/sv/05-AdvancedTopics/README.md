<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:07:38+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "sv"
}
-->
# Avancerade ämnen inom MCP

Det här kapitlet täcker en rad avancerade ämnen inom implementering av Model Context Protocol (MCP), inklusive multimodal integration, skalbarhet, säkerhetsbästa praxis och företagsintegration. Dessa ämnen är avgörande för att bygga robusta och produktionsklara MCP-applikationer som kan möta kraven från moderna AI-system.

## Översikt

Den här lektionen utforskar avancerade koncept inom implementering av Model Context Protocol med fokus på multimodal integration, skalbarhet, säkerhetsbästa praxis och företagsintegration. Dessa ämnen är viktiga för att bygga produktionsfärdiga MCP-applikationer som kan hantera komplexa krav i företagsmiljöer.

## Lärandemål

I slutet av denna lektion kommer du att kunna:

- Implementera multimodala funktioner inom MCP-ramverk
- Designa skalbara MCP-arkitekturer för scenarier med hög efterfrågan
- Tillämpa säkerhetsbästa praxis i linje med MCP:s säkerhetsprinciper
- Integrera MCP med företags-AI-system och ramverk
- Optimera prestanda och tillförlitlighet i produktionsmiljöer

## Lektioner och exempelprojekt

| Länk | Titel | Beskrivning |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrera med Azure | Lär dig hur du integrerar din MCP Server på Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multimodala exempel | Exempel för ljud, bild och multimodala svar |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal Spring Boot-app som visar OAuth2 med MCP, både som Authorization och Resource Server. Demonstrerar säker tokenutfärdelse, skyddade slutpunkter, distribution på Azure Container Apps och integration med API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Lär dig mer om root context och hur man implementerar dem |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Lär dig olika typer av routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Lär dig hur man arbetar med sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling | Lär dig om skalning |
| [5.8 Security](./mcp-security/README.md) | Security | Säkra din MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP-server och klient som integrerar med SerpAPI för realtidssökning på webben, nyheter, produkter och Q&A. Visar multi-verktygsorkestrering, extern API-integration och robust felhantering. |

## Ytterligare referenser

För den senaste informationen om avancerade MCP-ämnen, se:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Viktiga insikter

- Multimodala MCP-implementationer utökar AI:s kapabiliteter bortom textbearbetning
- Skalbarhet är avgörande för företagsdistributioner och kan hanteras genom horisontell och vertikal skalning
- Omfattande säkerhetsåtgärder skyddar data och säkerställer korrekt åtkomstkontroll
- Företagsintegration med plattformar som Azure OpenAI och Microsoft AI Foundry förbättrar MCP:s möjligheter
- Avancerade MCP-implementationer gynnas av optimerade arkitekturer och noggrann resursförvaltning

## Övning

Designa en företagsklassad MCP-implementation för ett specifikt användningsfall:

1. Identifiera multimodala krav för ditt användningsfall
2. Skissa upp säkerhetskontroller som behövs för att skydda känslig data
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
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.